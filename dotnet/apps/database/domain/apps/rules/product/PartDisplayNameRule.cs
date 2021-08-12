// <copyright file="PartDerivation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Derivations;
    using Derivations.Rules;
    using Meta;

    public class PartDisplayNameRule : Rule
    {
        public PartDisplayNameRule(MetaPopulation m) : base(m, new Guid("42968959-6d66-46c7-a5a6-6892840803d8")) =>
            this.Patterns = new Pattern[]
            {
                m.Part.RolePattern(v => v.Name),
            };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<Part>())
            {
                @this.SetDisplayName();
            }
        }
    }
}
