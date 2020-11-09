// <copyright file="PriceComponentDerivation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Meta;

    public class PriceComponentDerivation : DomainDerivation
    {
        public PriceComponentDerivation(M m) : base(m, new Guid("34F7833F-170D-45C3-92F0-B8AD33C3A028")) =>
            this.Patterns = new Pattern[]
            {
                new ChangedPattern(this.M.PriceComponent.FromDate),
                new ChangedPattern(this.M.PriceComponent.ThroughDate),
                new ChangedPattern(this.M.PriceComponent.Price),
                new ChangedPattern(this.M.PriceComponent.Product),
                new ChangedPattern(this.M.PriceComponent.Part),
                new ChangedPattern(this.M.PriceComponent.ProductFeature),

                new ChangedPattern(this.M.DiscountComponent.Percentage),
                new ChangedPattern(this.M.SurchargeComponent.Percentage),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<PriceComponent>())
            {
                var internalOrganisations = new Organisations(@this.Strategy.Session).Extent().Where(v => Equals(v.IsInternalOrganisation, true)).ToArray();

                if (!@this.ExistPricedBy && internalOrganisations.Count() == 1)
                {
                    @this.PricedBy = internalOrganisations.First();
                }

                var salesInvoices = (@this.PricedBy as InternalOrganisation)?.SalesInvoicesWhereBilledFrom.Where(v => v.ExistSalesInvoiceState && v.SalesInvoiceState.IsReadyForPosting);
                foreach (var salesInvoice in salesInvoices)
                {
                    salesInvoice.DerivationTrigger = Guid.NewGuid();
                }
            }
        }
    }
}
