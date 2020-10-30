// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Meta;

    public class InternalOrganisationDerivation : DomainDerivation
    {
        public InternalOrganisationDerivation(M m) : base(m, new Guid("258A6E3B-7940-4FCC-A33E-AE07C6FBFC32")) =>
            this.Patterns = new Pattern[]
            {
                new CreatedPattern(this.M.InternalOrganisation.Interface),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<InternalOrganisation>())
            {
                var organisation = (Organisation)@this;
                if (organisation.IsInternalOrganisation)
                {
                    if (!@this.ExistDefaultCollectionMethod && @this.Strategy.Session.Extent<PaymentMethod>().Count == 1)
                    {
                        @this.DefaultCollectionMethod = @this.Strategy.Session.Extent<PaymentMethod>().First;
                    }

                    if (!@this.ExistPurchaseInvoiceCounter)
                    {
                        @this.PurchaseInvoiceCounter = new CounterBuilder(@this.Strategy.Session)
                            .WithUniqueId(Guid.NewGuid()).WithValue(0).Build();
                    }

                    if (!@this.ExistRequestCounter)
                    {
                        @this.RequestCounter = new CounterBuilder(@this.Strategy.Session).WithUniqueId(Guid.NewGuid())
                            .WithValue(0).Build();
                    }

                    if (!@this.ExistQuoteCounter)
                    {
                        @this.QuoteCounter = new CounterBuilder(@this.Strategy.Session).WithUniqueId(Guid.NewGuid())
                            .WithValue(0).Build();
                    }

                    if (!@this.ExistPurchaseOrderCounter)
                    {
                        @this.PurchaseOrderCounter = new CounterBuilder(@this.Strategy.Session).WithUniqueId(Guid.NewGuid())
                            .WithValue(0).Build();
                    }

                    if (!@this.ExistIncomingShipmentCounter)
                    {
                        @this.IncomingShipmentCounter = new CounterBuilder(@this.Strategy.Session)
                            .WithUniqueId(Guid.NewGuid()).WithValue(0).Build();
                    }

                    if (!@this.ExistSubAccountCounter)
                    {
                        @this.SubAccountCounter = new CounterBuilder(@this.Strategy.Session).WithUniqueId(Guid.NewGuid())
                            .WithValue(0).Build();
                    }

                    if (!@this.ExistInvoiceSequence)
                    {
                        @this.InvoiceSequence = new InvoiceSequences(@this.Strategy.Session).RestartOnFiscalYear;
                    }

                    if (!@this.ExistFiscalYearStartMonth)
                    {
                        @this.FiscalYearStartMonth = 1;
                    }

                    if (!@this.ExistFiscalYearStartDay)
                    {
                        @this.FiscalYearStartDay = 1;
                    }
                }
            }
        }
    }
}
