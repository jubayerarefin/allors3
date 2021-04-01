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

    public class CustomerReturnRule : Rule
    {
        public CustomerReturnRule(M m) : base(m, new Guid("F43BD748-619E-4A3C-A002-21AD436EA764")) =>
            this.Patterns = new Pattern[]
            {
                new RolePattern(m.CustomerReturn, m.CustomerReturn.ShipFromParty),
                new RolePattern(m.CustomerReturn, m.CustomerReturn.ShipFromAddress),
                new RolePattern(m.CustomerReturn, m.CustomerReturn.ShipToParty),
                new RolePattern(m.CustomerReturn, m.CustomerReturn.ShipToAddress),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<CustomerReturn>())
            {
                if (!@this.ExistShipmentNumber && @this.ShipToParty is InternalOrganisation shipToParty)
                {
                    var year = @this.Strategy.Transaction.Now().Year;
                    @this.ShipmentNumber = shipToParty.NextCustomerReturnNumber(year);

                    var fiscalYearInternalOrganisationSequenceNumbers = shipToParty.FiscalYearsInternalOrganisationSequenceNumbers.FirstOrDefault(v => v.FiscalYear == year);
                    var prefix = ((InternalOrganisation)@this.ShipToParty).CustomerShipmentSequence.IsEnforcedSequence ? ((InternalOrganisation)@this.ShipToParty).CustomerReturnNumberPrefix : fiscalYearInternalOrganisationSequenceNumbers.CustomerReturnNumberPrefix;
                    @this.SortableShipmentNumber = @this.Transaction().GetSingleton().SortableNumber(prefix, @this.ShipmentNumber, year.ToString());
                }

                if (!@this.ExistShipToAddress && @this.ExistShipToParty)
                {
                    @this.ShipToAddress = @this.ShipToParty.ShippingAddress;
                }

                if (!@this.ExistShipFromAddress && @this.ExistShipFromParty)
                {
                    @this.ShipFromAddress = @this.ShipFromParty.ShippingAddress;
                }
            }
        }
    }
}