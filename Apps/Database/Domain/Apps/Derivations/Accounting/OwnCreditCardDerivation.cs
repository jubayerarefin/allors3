// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Allors.Meta;
    using Derivations;
    using Resources;

    public class OwnCreditCardDerivation : DomainDerivation
    {
        public OwnCreditCardDerivation(M m) : base(m, new Guid("838dbea6-9123-4cfe-acfe-1c6347ec7ff2")) =>
            this.Patterns = new Pattern[]
            {
                new ChangedPattern(m.InternalOrganisation.PaymentMethods),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<OwnCreditCard>())
            {
                if (@this.ExistInternalOrganisationWherePaymentMethod && @this.InternalOrganisationWherePaymentMethod.DoAccounting)
                {
                    validation.AssertAtLeastOne(@this, @this.M.Cash.GeneralLedgerAccount, @this.M.Cash.Journal);
                }

                if (@this.ExistCreditCard)
                {
                    if (@this.CreditCard.ExpirationYear <= @this.Session().Now().Year && @this.CreditCard.ExpirationMonth <= @this.Session().Now().Month)
                    {
                        @this.IsActive = false;
                    }
                }

                validation.AssertExistsAtMostOne(@this, @this.M.Cash.GeneralLedgerAccount, @this.M.Cash.Journal);
            }
        }
    }
}
