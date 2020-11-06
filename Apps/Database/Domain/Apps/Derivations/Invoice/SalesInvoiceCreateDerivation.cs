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
    using Resources;

    public class SalesInvoiceCreateDerivation : DomainDerivation
    {
        public SalesInvoiceCreateDerivation(M m) : base(m, new Guid("57040119-7df9-4f5f-a77c-606504c2439c")) =>
            this.Patterns = new Pattern[]
        {
            // Do not listen for changes in InternalOrganisation BillingAddress or GeneralCorrespondence or PreferredCurrency.
            // Do not listen for changes in Singleton DefaultLocale.
            // Do not listen for changes in BillToCustomer VatRegime, IrpfRegime, PreferredCurrency, Locale.
            // Do not listen for changes in CustomerRelationship PaymentNetDays. 
            // Do not listen for changes in Store PaymentNetDays.
            // All these properties are only used for newly created invoices.

            new CreatedPattern(this.M.SalesInvoice.Class),
        };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var session = cycle.Session;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<SalesInvoice>())
            {
                if (!@this.ExistEntryDate)
                {
                    @this.EntryDate = session.Now();
                }

                if (!@this.ExistInvoiceDate)
                {
                    @this.InvoiceDate = session.Now();
                }

                if (!@this.ExistSalesInvoiceType)
                {
                    @this.SalesInvoiceType = new SalesInvoiceTypes(session).SalesInvoice;
                }

                var internalOrganisations = new Organisations(session).InternalOrganisations();

                if (!@this.ExistBilledFrom && internalOrganisations.Count() == 1)
                {
                    @this.BilledFrom = internalOrganisations.First();
                }

                @this.DefaultLocale = session.GetSingleton().DefaultLocale;
                @this.DefaultCurrency = session.GetSingleton().DefaultLocale.Country.Currency;

                @this.AddSecurityToken(new SecurityTokens(@this.Session()).DefaultSecurityToken);
            }
        }
    }
}