// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Integration.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Allors.Integration
{
    using System.IO;
    using System.Linq;
    using Allors.Database;
    using Allors.Database.Domain;
    using Microsoft.Extensions.Logging;
    using OfficeOpenXml;

    public partial class Integration
    {
        public Integration(IDatabase databaseServiceDatabase, DirectoryInfo dataPath, ILoggerFactory loggerFactory)
        {
            this.DataPath = dataPath;
            this.LoggerFactory = loggerFactory;
            this.Database = databaseServiceDatabase;
            this.Logger = loggerFactory.CreateLogger<Integration>();
        }

        public IDatabase Database { get; }

        public DirectoryInfo DataPath { get; }

        public ILoggerFactory LoggerFactory { get; }

        public ILogger<Integration> Logger { get; }

        public void Integrate()
        {
            // Extract
            Source.Source source;
            using (var equipmentStockList = new ExcelPackage(this.GetFile("Equipment Stock List.xlsx")))
            using (var customerList = new ExcelPackage(this.GetFile("AVIACO_Customers_new.xlsx")))
            using (var partsList = new ExcelPackage(this.GetFile("FICHERO RECAMBIO.xlsx")))
            using (var partCategoryList = new ExcelPackage(this.GetFile("SPARE PARTS - ITEM CATEGORIES DESCRIPTION.xlsx")))
            {
                var extraction = new Extract.Extract(equipmentStockList, customerList, partsList, partCategoryList, this.LoggerFactory);
                source = extraction.Execute();
            }

            this.Integrate(source);
        }

        public void Integrate(Source.Source source)
        {
            using (var transaction = this.Database.CreateTransaction())
            {
                transaction.Services.Get<IUserService>().User = new AutomatedAgents(transaction).System;

                var population = new Population { Transaction = transaction };

                // Transform
                var transform = new Transform.Transform(source, population, this.LoggerFactory);
                var staging = transform.Execute();

                // Load
                var load = new Load.Load(staging, population, this.LoggerFactory, this.DataPath);
                load.Execute();

                this.Logger.LogInformation("Start Derive");

                transaction.Derive();

                this.Logger.LogInformation("End Derivation");

                transaction.Commit();
            }
        }

        private FileInfo GetFile(params string[] fileName)
        {
            var paths = fileName.Prepend(this.DataPath.FullName).ToArray();
            var combine = Path.Combine(paths);
            return new FileInfo(combine);
        }
    }
}
