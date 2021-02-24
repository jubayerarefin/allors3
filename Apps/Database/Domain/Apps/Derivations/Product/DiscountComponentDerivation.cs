// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Derivations;
    using Meta;
    using Database.Derivations;

    public class DiscountComponentDerivation : DomainDerivation
    {
        public DiscountComponentDerivation(M m) : base(m, new Guid("C395DB2E-C4A6-4974-BE35-EF2CC70D347D")) =>
            this.Patterns = new Pattern[]
            {
                new AssociationPattern(this.M.DiscountComponent.Price),
                new AssociationPattern(this.M.DiscountComponent.Percentage),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<DiscountComponent>())
            {
                validation.AssertExistsAtMostOne(@this, this.M.DiscountComponent.Price, this.M.DiscountComponent.Percentage);
            }
        }
    }
}
