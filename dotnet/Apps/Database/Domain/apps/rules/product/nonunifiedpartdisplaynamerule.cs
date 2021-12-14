// <copyright file="NonUnifiedPartDerivation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Database.Derivations;
    using Meta;
    using Derivations.Rules;

    public class NonUnifiedPartDisplayNameRule : Rule
    {
        public NonUnifiedPartDisplayNameRule(MetaPopulation m) : base(m, new Guid("66f3c4bc-d5c7-4d6a-bf15-fc06595fcf47")) =>
            this.Patterns = new Pattern[]
            {
                m.NonUnifiedPart.RolePattern(v => v.Name),
            };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<NonUnifiedPart>())
            {
                @this.DisplayName = @this.Name ?? "N/A";
            }
        }
    }
}
