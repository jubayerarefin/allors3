// <copyright file="Store.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Linq;

    public partial class Store
    {
        public string NextInvoiceNumber(int year)
        {
            int salesInvoiceNumber;
            if (this.InternalOrganisation.InvoiceSequence.Equals(new InvoiceSequences(this.Strategy.Session).EnforcedSequence))
            {
                salesInvoiceNumber = this.SalesInvoiceCounter.NextValue();
            }
            else
            {
                var fiscalYearInvoiceNumbers = new FiscalYearInvoiceNumbers(this.Strategy.Session).Extent();
                fiscalYearInvoiceNumbers.Filter.AddEquals(this.M.FiscalYearInvoiceNumber.FiscalYear, year);
                var fiscalYearInvoiceNumber = fiscalYearInvoiceNumbers.First;

                if (fiscalYearInvoiceNumber == null)
                {
                    fiscalYearInvoiceNumber = new FiscalYearInvoiceNumberBuilder(this.Strategy.Session).WithFiscalYear(year).Build();
                    this.AddFiscalYearInvoiceNumber(fiscalYearInvoiceNumber);
                }

                salesInvoiceNumber = fiscalYearInvoiceNumber.DeriveNextSalesInvoiceNumber();
            }

            return string.Concat(this.SalesInvoiceNumberPrefix, salesInvoiceNumber).Replace("{year}", year.ToString());
        }

        public string NextCreditNoteNumber(int year)
        {
            int creditNoteNumber;
            if (this.InternalOrganisation.InvoiceSequence.Equals(new InvoiceSequences(this.Strategy.Session).EnforcedSequence))
            {
                creditNoteNumber = this.CreditNoteCounter.NextValue();
            }
            else
            {
                var fiscalYearInvoiceNumbers = new FiscalYearInvoiceNumbers(this.Strategy.Session).Extent();
                fiscalYearInvoiceNumbers.Filter.AddEquals(this.M.FiscalYearInvoiceNumber.FiscalYear, year);
                var fiscalYearInvoiceNumber = fiscalYearInvoiceNumbers.First;

                if (fiscalYearInvoiceNumber == null)
                {
                    fiscalYearInvoiceNumber = new FiscalYearInvoiceNumberBuilder(this.Strategy.Session).WithFiscalYear(year).Build();
                    this.AddFiscalYearInvoiceNumber(fiscalYearInvoiceNumber);
                }

                creditNoteNumber = fiscalYearInvoiceNumber.DeriveNextCreditNoteNumber();
            }

            return string.Concat(this.CreditNoteNumberPrefix, creditNoteNumber).Replace("{year}", year.ToString());
        }

        public string NextTemporaryInvoiceNumber() => this.SalesInvoiceTemporaryCounter.NextValue().ToString();

        public string NextShipmentNumber() => string.Concat(this.OutgoingShipmentNumberPrefix, this.OutgoingShipmentCounter.NextValue());

        public string NextSalesOrderNumber(int year) => string.Concat(this.SalesOrderNumberPrefix, this.SalesOrderCounter.NextValue()).Replace("{year}", year.ToString());
    }
}
