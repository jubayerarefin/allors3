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

    public class InternalOrganisationCustomerReturnSequenceRule : Rule
    {
        public InternalOrganisationCustomerReturnSequenceRule(MetaPopulation m) : base(m, new Guid("fbef3c80-a576-4a5c-9dbf-fd7cf2cc967c")) =>
            this.Patterns = new Pattern[]
            {
                m.InternalOrganisation.RolePattern(v => v.CustomerReturnSequence),
            };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<InternalOrganisation>())
            {
                //Altijd
                var organisation = (Organisation)@this;
                if (organisation.IsInternalOrganisation)
                {
                    if (@this.CustomerReturnSequence != new CustomerReturnSequences(@this.Strategy.Transaction).RestartOnFiscalYear && !@this.ExistCustomerReturnNumberCounter)
                    {
                        @this.CustomerReturnNumberCounter = new CounterBuilder(@this.Strategy.Transaction).Build();
                    }
                }
            }
        }
    }
}
