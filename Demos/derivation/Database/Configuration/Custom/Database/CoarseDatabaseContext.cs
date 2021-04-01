// <copyright file="DefaultDatabaseScope.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the DomainTest type.</summary>

namespace Allors.Database.Configuration
{
    using Domain;
    using Domain.Derivations.Default;
    using Microsoft.AspNetCore.Http;


    public class CourseDatabaseContext : DatabaseContext
    {
        public CourseDatabaseContext(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor) { }

        public override void OnInit(IDatabase database)
        {
            base.OnInit(database);

            var m = this.M;

            var rules = new Rule[]
            {
                // Core
                new MediaRule(m),
                new TransitionalDeniedPermissionRule(m),

                // Custom
                new CoarseRule(m),
            };

            var engine = new Engine(rules);
            this.DerivationFactory = new DerivationFactory(engine);
        }
    }
}