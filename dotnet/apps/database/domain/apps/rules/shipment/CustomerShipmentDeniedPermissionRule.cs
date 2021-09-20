// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Derivations;
    using Meta;
    using Derivations.Rules;

    public class CustomerShipmentDeniedPermissionRule : Rule
    {
        public CustomerShipmentDeniedPermissionRule(MetaPopulation m) : base(m, new Guid("1121e021-7483-47ec-b8cf-1030e5dec9c3")) =>
            this.Patterns = new Pattern[]
        {
            m.CustomerShipment.RolePattern(v => v.TransitionalRevocations),
        };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            var transaction = cycle.Transaction;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<CustomerShipment>())
            {
                @this.Revocations = @this.Revocations;
            }
        }
    }
}
