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
    using Derivations.Rules;

    public class ProposalSearchStringRule : Rule
    {
        public ProposalSearchStringRule(MetaPopulation m) : base(m, new Guid("c4936d90-d5e1-4ae5-822d-47c94865a8f9")) =>
            this.Patterns = new Pattern[]
            {
                m.Quote.RolePattern(v => v.QuoteNumber, m.Proposal),
                m.Quote.RolePattern(v => v.QuoteState, m.Proposal),
                m.Quote.RolePattern(v => v.Issuer, m.Proposal),
                m.Quote.RolePattern(v => v.DerivedCurrency, m.Proposal),
                m.Quote.RolePattern(v => v.InternalComment, m.Proposal),
                m.Quote.RolePattern(v => v.Description, m.Proposal),
                m.Quote.RolePattern(v => v.DerivedIrpfRegime, m.Proposal),
                m.Quote.RolePattern(v => v.DerivedVatRegime, m.Proposal),
                m.Quote.RolePattern(v => v.DerivedVatClause, m.Proposal),
                m.Quote.RolePattern(v => v.Request, m.Proposal),
                m.Quote.RolePattern(v => v.ContactPerson, m.Proposal),
                m.Person.RolePattern(v => v.DisplayName, v => v.QuotesWhereContactPerson.Quote, m.Proposal),
                m.Quote.RolePattern(v => v.QuoteTerms, m.Proposal),
                m.QuoteTerm.RolePattern(v => v.TermValue, v => v.QuotesWhereQuoteTerm.Quote, m.Proposal),
                m.QuoteTerm.RolePattern(v => v.TermType, v => v.QuotesWhereQuoteTerm.Quote, m.Proposal),
                m.QuoteTerm.RolePattern(v => v.Description, v => v.QuotesWhereQuoteTerm.Quote, m.Proposal),
                m.Quote.RolePattern(v => v.Receiver, m.Proposal),
                m.Party.RolePattern(v => v.DisplayName, v => v.QuotesWhereReceiver.Quote, m.Proposal),
                m.Quote.RolePattern(v => v.FullfillContactMechanism, m.Proposal),
                m.ContactMechanism.RolePattern(v => v.DisplayName, v => v.QuotesWhereFullfillContactMechanism.Quote, m.Proposal),

                m.QuoteItem.RolePattern(v => v.QuoteItemState, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.DerivedIrpfRegime, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.DerivedVatRegime, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.InvoiceItemType, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.InternalComment, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.Authorizer, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.Party.RolePattern(v => v.DisplayName, v => v.QuoteItemsWhereAuthorizer.QuoteItem.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.Product, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.ProductFeature, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.SerialisedItem, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.SerialisedItem.RolePattern(v => v.DisplayName, v => v.QuoteItemsWhereSerialisedItem.QuoteItem.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.WorkEffort, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.QuoteTerms, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteTerm.RolePattern(v => v.TermValue, v => v.QuoteItemWhereQuoteTerm.QuoteItem.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteTerm.RolePattern(v => v.TermType, v => v.QuoteItemWhereQuoteTerm.QuoteItem.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteTerm.RolePattern(v => v.Description, v => v.QuoteItemWhereQuoteTerm.QuoteItem.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.RequestItem, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
                m.QuoteItem.RolePattern(v => v.Details, v => v.QuoteWhereQuoteItem.Quote, m.Proposal),
            };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<Proposal>())
            {
                var array = new string[] {
                    @this.QuoteNumber,
                    @this.QuoteState?.Name,
                    @this.Issuer?.DisplayName,
                    @this.DerivedCurrency?.Abbreviation,
                    @this.DerivedCurrency?.Name,
                    @this.InternalComment,
                    @this.Description,
                    @this.DerivedIrpfRegime?.Name,
                    @this.DerivedVatRegime?.Name,
                    @this.DerivedVatClause?.Name,
                    @this.Request?.RequestNumber,
                    @this.ContactPerson?.DisplayName,
                    @this.ExistQuoteTerms ? string.Join(" ", @this.QuoteTerms?.Select(v => v.TermValue)) : null,
                    @this.ExistQuoteTerms ? string.Join(" ", @this.QuoteTerms?.Select(v => v.TermType?.Name)) : null,
                    @this.ExistQuoteTerms ? string.Join(" ", @this.QuoteTerms?.Select(v => v.Description)) : null,
                    @this.Receiver?.DisplayName,
                    @this.FullfillContactMechanism?.DisplayName,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.QuoteItemState?.Name)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.DerivedIrpfRegime?.Name)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.DerivedVatRegime?.Name)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.InvoiceItemType?.Name)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.InternalComment)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.Authorizer?.DisplayName)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.Product?.DisplayName)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.ProductFeature?.Description)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.SerialisedItem?.DisplayName)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.WorkEffort?.WorkEffortNumber)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.QuoteTerms.Select(v => v.TermValue))) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.QuoteTerms.Select(v => v.TermType?.Name))) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.QuoteTerms.Select(v => v.Description))) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.RequestItem?.RequestWhereRequestItem?.RequestNumber)) : null,
                    @this.ExistQuoteItems ? string.Join(" ", @this.QuoteItems?.Select(v => v.Details)) : null,
                };

                if (array.Any(s => !string.IsNullOrEmpty(s)))
                {
                    @this.SearchString = string.Join(" ", array.Where(s => !string.IsNullOrEmpty(s)));
                }
            }
        }
    }
}
