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

    public class QuoteCreatedDeriveVatRegimeRule : Rule
    {
        public QuoteCreatedDeriveVatRegimeRule(MetaPopulation m) : base(m, new Guid("7dfea429-5232-4b78-9674-0d84e83340b2")) =>
            this.Patterns = new Pattern[]
            {
                new RolePattern(m.Quote, m.Quote.QuoteState),
                new RolePattern(m.Quote, m.Quote.Issuer),
                new RolePattern(m.Quote, m.Quote.Receiver),
                new RolePattern(m.Quote, m.Quote.AssignedVatRegime),
                new RolePattern(m.Quote, m.Quote.IssueDate),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<Quote>().Where(v => v.QuoteState.IsCreated))
            {
                @this.DerivedVatRegime = @this.AssignedVatRegime;

                if (@this.ExistIssueDate)
                {
                    @this.DerivedVatRate = @this.DerivedVatRegime?.VatRates.First(v => v.FromDate <= @this.IssueDate && (!v.ExistThroughDate || v.ThroughDate >= @this.IssueDate));
                }
            }
        }
    }
}
