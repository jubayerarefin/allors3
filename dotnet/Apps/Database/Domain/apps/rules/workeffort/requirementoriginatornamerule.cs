// <copyright file="RequirementOriginatorNameRule.cs" company="Allors bvba">
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

    public class RequirementOriginatorNameRule : Rule
    {
        public RequirementOriginatorNameRule(MetaPopulation m) : base(m, new Guid("cd29a154-487e-4764-8408-009720cbe92f")) =>
            this.Patterns = new Pattern[]
        {
            m.Requirement.RolePattern(v => v.Originator),
            m.Party.RolePattern(v => v.PartyName, v => v.RequirementsWhereOriginator),
        };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<Requirement>())
            {
                @this.OriginatorName = @this.Originator?.PartyName;
            }
        }
    }
}
