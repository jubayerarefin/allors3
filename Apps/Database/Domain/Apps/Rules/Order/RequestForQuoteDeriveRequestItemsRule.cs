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

    public class RequestForQuoteDeriveRequestItemsRule : Rule
    {
        public RequestForQuoteDeriveRequestItemsRule(MetaPopulation m) : base(m, new Guid("8505acf9-e8b6-4d35-b0c1-a6af03217df2")) =>
            this.Patterns = new[]
            {
                new RolePattern(m.RequestForQuote, m.RequestForQuote.RequestItems)
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<RequestForQuote>())
            {
                foreach (RequestItem requestItem in @this.RequestItems)
                {
                    requestItem.Sync(@this);
                }
            }
        }
    }
}
