// <copyright file="DomainTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the DomainTest type.</summary>

namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Allors;
    using Allors.Database.Adapters.Memory;
    using Allors.Domain;
    using Allors.Meta;
    using Allors.State;

    public abstract class DomainTest : IDisposable
    {
        protected DomainTest(Fixture fixture, bool populate = true)
        {
            var database = new Database(
                new DefaultDatabaseState(),
                new Configuration
                {
                    ObjectFactory = new ObjectFactory(fixture.MetaPopulation, typeof(User)),
                });

            this.M = database.State().M;

            this.Setup(database, populate);
        }

        public static IEnumerable<object[]> TestedDerivationTypes
            => new object[][] {
                new object[] {DerivationTypes.Coarse },
                new object[] {DerivationTypes.Fine },
            };
        
        public M M { get; }

        public virtual Config Config { get; } = new Config { SetupSecurity = false };

        public ISession Session { get; private set; }

        public ITimeService TimeService => this.Session.Database.State().TimeService;

        public IDerivationService DerivationService => this.Session.Database.State().DerivationService;

        public TimeSpan? TimeShift
        {
            get => this.TimeService.Shift;

            set => this.TimeService.Shift = value;
        }

        
        public void Dispose()
        {
            this.Session.Rollback();
            this.Session = null;
        }

        protected void Setup(IDatabase database, bool populate)
        {
            database.Init();

            database.RegisterDerivations();

            this.Session = database.CreateSession();

            if (populate)
            {
                new Setup(this.Session, this.Config).Apply();
                this.Session.Commit();
            }
        }

        protected void RegisterAdditionalDerivations(DerivationTypes derivationType)
        {
            if (derivationType == DerivationTypes.Fine)
            {
                this.Session.Database.RegisterFineDerivations();
            }
            else
            {
                this.Session.Database.RegisterCoarseDerivations();
            }
        }
    }
}
