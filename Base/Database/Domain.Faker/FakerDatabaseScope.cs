// <copyright file="DefaultDatabaseScope.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the DomainTest type.</summary>

namespace Allors
{
    using Bogus;
    using Meta;
    using Microsoft.AspNetCore.Http;
    using Services;

    public class FakerDatabaseScope : DefaultDatabaseScope
    {
        public FakerDatabaseScope(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor) { }

        public override void OnInit(IDatabase database)
        {
            base.OnInit(database);

            this.Faker = new Faker();
        }

        public Faker Faker { get; set; }
    }
}
