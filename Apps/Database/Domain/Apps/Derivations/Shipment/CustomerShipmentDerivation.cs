// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Derivations;
    using Meta;
    using Database.Derivations;

    public class CustomerShipmentDerivation : DomainDerivation
    {
        public CustomerShipmentDerivation(M m) : base(m, new Guid("7FE90E97-A4B4-4991-9063-91BF5670B4A9")) =>
            this.Patterns = new Pattern[]
            {
                new ChangedPattern(m.CustomerShipment.Store),
                new ChangedPattern(m.CustomerShipment.ShipFromParty),
                new ChangedPattern(m.CustomerShipment.ShipFromAddress),
                new ChangedPattern(m.CustomerShipment.ShipToParty),
                new ChangedPattern(m.CustomerShipment.ShipToAddress),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<CustomerShipment>())
            {
                if (!@this.ExistShipmentNumber && @this.ExistStore)
                {
                    var year = @this.Session().Now().Year;
                    @this.ShipmentNumber = @this.Store.NextCustomerShipmentNumber(year);

                    var fiscalYearStoreSequenceNumbers = @this.Store.FiscalYearsStoreSequenceNumbers.FirstOrDefault(v => v.FiscalYear == year);
                    var prefix = ((InternalOrganisation)@this.ShipFromParty).CustomerShipmentSequence.IsEnforcedSequence ? @this.Store.CustomerShipmentNumberPrefix : fiscalYearStoreSequenceNumbers.CustomerShipmentNumberPrefix;
                    @this.SortableShipmentNumber = @this.Session().GetSingleton().SortableNumber(prefix, @this.ShipmentNumber, year.ToString());
                }

                if (!@this.ExistShipToAddress && @this.ExistShipToParty)
                {
                    @this.ShipToAddress = @this.ShipToParty.ShippingAddress;
                }

                if (!@this.ExistShipFromAddress)
                {
                    @this.ShipFromAddress = @this.ShipFromParty?.ShippingAddress;
                }
            }
        }
    }
}
