// <copyright file="DefaultDatabaseScope.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the DomainTest type.</summary>

namespace Allors
{
    using Microsoft.AspNetCore.Http;
    using State;

    public class DefaultDatabaseState : DatabaseState
    {
        public DefaultDatabaseState(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor) { }

        public override void OnInit(IDatabase database)
        {
            base.OnInit(database);

            this.DerivationFactory = new DefaultDerivationFactory();
        }
    }
}