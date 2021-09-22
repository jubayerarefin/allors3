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

    public class RequirementDeniedPermissionRule : Rule
    {
        public RequirementDeniedPermissionRule(MetaPopulation m) : base(m, new Guid("f0023baa-b40f-4840-8f8f-db90304809e5")) =>
            this.Patterns = new Pattern[]
        {
            m.Requirement.RolePattern(v => v.TransitionalRevocations),
        };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<Requirement>())
            {
                @this.Revocations = @this.TransitionalRevocations;
            }
        }
    }
}