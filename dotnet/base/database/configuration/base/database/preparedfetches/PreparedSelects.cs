// <copyright file="PreparedSelects.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Configuration
{
    using System;
    using System.Collections.Concurrent;
    using Data;
    using Domain;

    public class PreparedSelects : IPreparedSelects
   {
       private readonly ConcurrentDictionary<Guid, Select> selectById;

        public PreparedSelects(IDomainDatabaseServices domainDatabaseServices)
        {
            this.DomainDatabaseServices = domainDatabaseServices;
            this.selectById = new ConcurrentDictionary<Guid, Select>();
        }

        public IDomainDatabaseServices DomainDatabaseServices { get; }

        public Select Get(Guid id)
        {
            if (!this.selectById.TryGetValue(id, out var select))
            {
                var transaction = this.DomainDatabaseServices.Database.CreateTransaction();
                try
                {
                    var m = transaction.Database.Services().M;

                    var filter = new Extent(m.PersistentPreparedSelect)
                    {
                        Predicate = new Equals(m.PersistentPreparedSelect.UniqueId) { Value = id },
                    };

                    var preparedSelect = (PersistentPreparedSelect)filter.Build(transaction).First;
                    if (preparedSelect != null)
                    {
                        select = preparedSelect.Select;
                        this.selectById[id] = select;
                    }
                }
                finally
                {
                    if (this.DomainDatabaseServices.Database.IsShared)
                    {
                        transaction.Dispose();
                    }
                }
            }

            return select;
        }
    }
}