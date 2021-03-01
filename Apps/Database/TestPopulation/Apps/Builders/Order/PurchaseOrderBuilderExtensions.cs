// <copyright file="PurchaseOrderBuilderExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>

namespace Allors.Database.Domain.TestPopulation
{
    using System.Linq;

    public static partial class PurchaseOrderBuilderExtensions
    {
        public static PurchaseOrderBuilder WithDefaults(this PurchaseOrderBuilder @this, Organisation internalOrganisation)
        {
            var faker = @this.Transaction.Faker();

            var postalAddress = new PostalAddressBuilder(@this.Transaction).WithDefaults().Build();
            var supplier = faker.Random.ListItem(internalOrganisation.ActiveSuppliers);

            @this.WithDescription(faker.Lorem.Sentence());
            @this.WithComment(faker.Lorem.Sentence());
            @this.WithInternalComment(faker.Lorem.Sentence());
            @this.WithShipToContactPerson(internalOrganisation.CurrentContacts.FirstOrDefault());
            @this.WithAssignedShipToAddress(internalOrganisation.ShippingAddress);
            @this.WithBillToContactPerson(internalOrganisation.CurrentContacts.FirstOrDefault());
            @this.WithAssignedBillToContactMechanism(internalOrganisation.CurrentPartyContactMechanisms.Select(v => v.ContactMechanism).FirstOrDefault());
            @this.WithTakenViaContactPerson(internalOrganisation.CurrentContacts.FirstOrDefault());
            @this.WithAssignedTakenViaContactMechanism(internalOrganisation.CurrentPartyContactMechanisms.Select(v => v.ContactMechanism).FirstOrDefault());
            @this.WithTakenViaSupplier(supplier);
            @this.WithStoredInFacility(faker.Random.ListItem(internalOrganisation.FacilitiesWhereOwner));
            @this.WithOrderedBy(internalOrganisation);

            return @this;
        }
    }
}