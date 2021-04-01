// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;
    using Database.Derivations;
    using Resources;

    public class InvoiceItemTotalIncVatRule : Rule
    {
        public InvoiceItemTotalIncVatRule(M m) : base(m, new Guid("DB8D8C77-4E1A-4775-A243-79C7A558CFE4")) =>
            this.Patterns = new Pattern[]
            {
                new RolePattern(m.SalesInvoiceItem, m.SalesInvoiceItem.TotalIncVat),
                new RolePattern(m.PurchaseInvoiceItem, m.PurchaseInvoiceItem.TotalIncVat),
                new RolePattern(m.PaymentApplication, m.PaymentApplication.AmountApplied) { Steps =  new IPropertyType[] {this.M.PaymentApplication.InvoiceItem} },
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<InvoiceItem>())
            {
                var totalInvoiceItemAmountPaid = @this?.PaymentApplicationsWhereInvoiceItem.Sum(v => v.AmountApplied);
                if (totalInvoiceItemAmountPaid > @this.TotalIncVat)
                {
                    cycle.Validation.AddError($"{@this} {this.M.PaymentApplication.AmountApplied} {ErrorMessages.PaymentApplicationNotLargerThanInvoiceItemAmount}");
                }
            }
        }
    }
}