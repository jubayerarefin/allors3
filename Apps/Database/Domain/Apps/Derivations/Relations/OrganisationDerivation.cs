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

    public class OrganisationDerivation : DomainDerivation
    {
        public OrganisationDerivation(M m) : base(m, new Guid("0379B923-210D-46DD-9D18-9D7BF5ED6FEA")) =>
            this.Patterns = new Pattern[]
            {
                new AssociationPattern(m.Organisation.Name),
                new AssociationPattern(m.Organisation.UniqueId),
                new AssociationPattern(m.Organisation.DerivationTrigger),
                new AssociationPattern(m.Employment.Employer) {Steps = new IPropertyType[]{ m.Employment.Employer} },
                new AssociationPattern(m.Employment.FromDate) {Steps = new IPropertyType[]{ m.Employment.Employer}, OfType = m.Organisation.Class},
                new AssociationPattern(m.Employment.ThroughDate) {Steps = new IPropertyType[]{ m.Employment.Employer}, OfType = m.Organisation.Class},
                new AssociationPattern(m.CustomerRelationship.InternalOrganisation) {Steps = new IPropertyType[]{ m.CustomerRelationship.InternalOrganisation} },
                new AssociationPattern(m.CustomerRelationship.FromDate) {Steps = new IPropertyType[]{ m.CustomerRelationship.InternalOrganisation} },
                new AssociationPattern(m.CustomerRelationship.ThroughDate) {Steps = new IPropertyType[]{ m.CustomerRelationship.InternalOrganisation} },
                new AssociationPattern(m.SupplierRelationship.InternalOrganisation) {Steps = new IPropertyType[]{ m.SupplierRelationship.InternalOrganisation} },
                new AssociationPattern(m.SupplierRelationship.FromDate) {Steps = new IPropertyType[]{ m.SupplierRelationship.InternalOrganisation} },
                new AssociationPattern(m.SupplierRelationship.ThroughDate) {Steps = new IPropertyType[]{ m.SupplierRelationship.InternalOrganisation} },
                new AssociationPattern(m.OrganisationContactRelationship.Organisation) {Steps = new IPropertyType[]{ m.OrganisationContactRelationship.Organisation} },
                new AssociationPattern(m.OrganisationContactRelationship.FromDate) {Steps = new IPropertyType[]{ m.OrganisationContactRelationship.Organisation} },
                new AssociationPattern(m.OrganisationContactRelationship.ThroughDate) {Steps = new IPropertyType[]{ m.OrganisationContactRelationship.Organisation} },
                new AssociationPattern(m.SubContractorRelationship.Contractor) {Steps = new IPropertyType[]{ m.SubContractorRelationship.Contractor } },
                new AssociationPattern(m.SubContractorRelationship.FromDate) {Steps = new IPropertyType[]{ m.SubContractorRelationship.Contractor } },
                new AssociationPattern(m.SubContractorRelationship.ThroughDate) {Steps = new IPropertyType[]{ m.SubContractorRelationship.Contractor } },
                new AssociationPattern(m.Organisation.PartyContactMechanisms),
                new AssociationPattern(m.PartyContactMechanism.FromDate) {Steps = new IPropertyType[]{ m.PartyContactMechanism.PartyWherePartyContactMechanism }, OfType = m.Organisation.Class },
                new AssociationPattern(m.PartyContactMechanism.ThroughDate) {Steps = new IPropertyType[]{ m.PartyContactMechanism.PartyWherePartyContactMechanism }, OfType = m.Organisation.Class },
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var transaction = cycle.Transaction;

            foreach (var @this in matches.Cast<Organisation>())
            {
                var now = transaction.Now();

                transaction.Prefetch(@this.PrefetchPolicy);

                @this.PartyName = @this.Name;

                if (!@this.ExistContactsUserGroup)
                {
                    var customerContactGroupName = $"Customer contacts at {@this.Name} ({@this.UniqueId})";
                    @this.ContactsUserGroup = new UserGroupBuilder(@this.Strategy.Transaction).WithName(customerContactGroupName).Build();
                }

                @this.DeriveRelationships();

                var partyContactMechanisms = @this.PartyContactMechanisms?.ToArray();
                foreach (OrganisationContactRelationship organisationContactRelationship in @this.OrganisationContactRelationshipsWhereOrganisation)
                {
                    organisationContactRelationship.Contact?.Sync(partyContactMechanisms);
                }
            }
        }
    }
}
