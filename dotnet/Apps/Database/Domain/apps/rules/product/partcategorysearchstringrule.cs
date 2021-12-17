// <copyright file="InventoryItemSearchStringDerivation.cs" company="Allors bvba">
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

    public class PartCategorySearchStringRule : Rule
    {
        public PartCategorySearchStringRule(MetaPopulation m) : base(m, new Guid("897d896f-9d30-4697-90f9-89579b9e6634")) =>
            this.Patterns = new Pattern[]
            {
                m.PartCategory.RolePattern(v => v.DisplayName),
                m.PartCategory.RolePattern(v => v.Name),
                m.PartCategory.RolePattern(v => v.Description),
                m.PartCategory.RolePattern(v => v.LocalisedNames),
                m.LocalisedText.RolePattern(v => v.Text, v => v.PartCategoryWhereLocalisedName.PartCategory),
                m.PartCategory.RolePattern(v => v.LocalisedDescriptions),
                m.LocalisedText.RolePattern(v => v.Text, v => v.PartCategoryWhereLocalisedDescription.PartCategory),
            };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<PartCategory>())
            {
                var array = new string[] {
                    @this.DisplayName,
                    @this.Name,
                    @this.Description,
                    string.Join(" ", @this.LocalisedNames?.Select(v => v.Text)),
                    string.Join(" ", @this.LocalisedDescriptions?.Select(v => v.Text)),
                };

                @this.SearchString = string.Join(" ", array.Where(s => !string.IsNullOrEmpty(s)));
            }
        }
    }
}
