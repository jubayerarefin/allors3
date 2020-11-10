// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Allors.Meta;

    public class InventoryItemDerivation : DomainDerivation
    {
        public InventoryItemDerivation(M m) : base(m, new Guid("E1BE8D0A-DD31-404F-A0F5-B03B0D3DB3AB")) =>
            this.Patterns = new[]
            {
                new ChangedPattern(this.M.InventoryItem.Part)
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<InventoryItem>())
            {
                var now = cycle.Session.Now();

                (@this).PartDisplayName = @this.Part?.DisplayName;

                if (!@this.ExistFacility && @this.ExistPart && @this.Part.ExistDefaultFacility)
                {
                    @this.Facility = @this.Part.DefaultFacility;
                }

                // TODO: Let Sync set Unit of Measure
                if (!@this.ExistUnitOfMeasure)
                {
                    @this.UnitOfMeasure = @this.Part?.UnitOfMeasure;
                }

                var part = @this.Part;

                var builder = new StringBuilder();

                builder.Append(part.SearchString);

                @this.SearchString = builder.ToString();
            }

        }

    }
}
