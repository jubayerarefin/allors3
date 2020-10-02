// <copyright file="Profile.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Adapters
{
    using System;
    using System.Collections.Generic;

    using Allors;
    using Domain;
    using Memory;
    using Meta;
    using ObjectFactory = Allors.ObjectFactory;

    public abstract class Profile : IProfile
    {
        public ISession Session { get; private set; }

        public IDatabase Database { get; private set; }

        public abstract Action[] Markers { get; }

        public virtual Action[] Inits
        {
            get
            {
                var inits = new List<Action> { this.Init };

                if (Settings.ExtraInits)
                {
                    inits.Add(this.Init);
                }

                return inits.ToArray();
            }
        }

        public void SwitchDatabase()
        {
            this.Session.Rollback();
            this.Database = this.CreateDatabase();
            this.Session = this.Database.CreateSession();
            this.Session.Commit();
        }

        public virtual void Dispose()
        {
            this.Session?.Rollback();

            this.Session = null;
            this.Database = null;
        }

        public IDatabase CreateMemoryDatabase()
        {
            var metaPopulation = new MetaBuilder().Build();
            var scope = new DatabaseInstance();
            return new Database(scope, new Memory.Configuration
            {
                ObjectFactory = new ObjectFactory(metaPopulation, typeof(C1)),
            });
        }

        public abstract IDatabase CreateDatabase();

        internal ISession CreateSession() => this.Database.CreateSession();

        protected internal void Init()
        {
            try
            {
                this.Session?.Rollback();

                this.Database = this.CreateDatabase();
                this.Database.Init();
                this.Session = this.Database.CreateSession();
                this.Session.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
