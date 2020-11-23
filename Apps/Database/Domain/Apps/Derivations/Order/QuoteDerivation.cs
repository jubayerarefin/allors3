// <copyright file="Domain.cs" company="Allors bvba">
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

    public class QuoteDerivation : DomainDerivation
    {
        public QuoteDerivation(M m) : base(m, new Guid("B2464D89-5370-44D7-BB6B-7E6FA48EEF0B")) =>
            this.Patterns = new Pattern[]
            {
                new ChangedPattern(this.M.Quote.Issuer),
                new ChangedPattern(this.M.Quote.AssignedCurrency),
                new ChangedPattern(this.M.Party.Locale) { Steps = new IPropertyType[] { this.M.Party.QuotesWhereReceiver }},
                new ChangedPattern(this.M.Organisation.Locale) { Steps = new IPropertyType[] { this.M.Organisation.QuotesWhereIssuer }},
                new ChangedPattern(this.M.Party.PreferredCurrency) { Steps = new IPropertyType[] { this.M.Party.QuotesWhereReceiver }},
                new ChangedPattern(this.M.Organisation.PreferredCurrency) { Steps = new IPropertyType[] { this.M.Organisation.QuotesWhereReceiver }},
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<Quote>())
            {
                if (!@this.ExistIssuer)
                {
                    var internalOrganisations = new Organisations(cycle.Session).InternalOrganisations();

                    if (internalOrganisations.Count() == 1)
                    {
                        @this.Issuer = internalOrganisations.First();
                    }
                }

                if (!@this.ExistQuoteNumber && @this.ExistIssuer)
                {
                    @this.QuoteNumber = @this.Issuer.NextQuoteNumber(cycle.Session.Now().Year);
                    (@this).SortableQuoteNumber = NumberFormatter.SortableNumber(@this.Issuer.QuoteNumberPrefix, @this.QuoteNumber, @this.IssueDate.Year.ToString());
                }

                if (@this.QuoteState.IsCreated)
                {
                    @this.DerivedLocale = @this.Locale ?? @this.Receiver?.Locale ?? @this.Issuer?.Locale;
                    @this.DerivedCurrency = @this.AssignedCurrency ?? @this.Receiver?.PreferredCurrency ?? @this.Issuer?.PreferredCurrency;

                    foreach (QuoteItem quoteItem in @this.QuoteItems)
                    {
                        var quoteItemDerivedRoles = quoteItem;

                        quoteItemDerivedRoles.DerivedVatRegime = quoteItem.AssignedVatRegime ?? @this.DerivedVatRegime;
                        quoteItemDerivedRoles.VatRate = quoteItem.DerivedVatRegime?.VatRate;

                        quoteItemDerivedRoles.DerivedIrpfRegime = quoteItem.AssignedIrpfRegime ?? @this.DerivedIrpfRegime;
                        quoteItemDerivedRoles.IrpfRate = quoteItem.DerivedIrpfRegime?.IrpfRate;
                    }
                }

                @this.AddSecurityToken(new SecurityTokens(cycle.Session).DefaultSecurityToken);
            }
        }
    }
}
