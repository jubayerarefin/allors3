// <copyright file="TakenViaModel.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain.Print.PurchaseOrderModel
{
    using System.Collections.Generic;

    public class TakenViaModel
    {
        public TakenViaModel(PurchaseOrder order)
        {
            var takenVia = order.TakenViaSupplier ?? order.TakenViaSubcontractor;
            var contactPerson = order.TakenViaContactPerson;
            var contactMechanisam = order.DerivedTakenViaContactMechanism;

            var billTo = takenVia;
            var billToOrganisation = billTo;
            if (billTo != null)
            {
                this.Name = billTo.DisplayName;
                this.TaxId = billToOrganisation?.TaxNumber;
            }

            this.Contact = contactPerson?.DisplayName;

            var address = new List<string>();

            if (contactMechanisam is PostalAddress postalAddress)
            {
                address.Add(postalAddress.Address1);
                if (!string.IsNullOrWhiteSpace(postalAddress.Address2))
                {
                    address.Add(postalAddress.Address2);
                }

                if (!string.IsNullOrWhiteSpace(postalAddress.Address3))
                {
                    address.Add(postalAddress.Address3);
                }

                this.City = postalAddress.Locality;
                this.State = postalAddress.Region;
                this.PostalCode = postalAddress.PostalCode;
                this.Country = postalAddress.Country?.Name;
                this.PrintPostalCode = !string.IsNullOrEmpty(this.PostalCode);
                this.PrintCity = !this.PrintPostalCode;
            }

            if (contactMechanisam is ElectronicAddress electronicAddress)
            {
                address.Add(electronicAddress.ElectronicAddressString);
            }

            this.Address = address.ToArray();
        }

        public bool PrintPostalCode { get; }

        public bool PrintCity { get; }

        public string Name { get; }

        public string[] Address { get; }

        public string City { get; }

        public string State { get; }

        public string Country { get; }

        public string PostalCode { get; }

        public string TaxId { get; }

        public string Contact { get; }
    }
}
