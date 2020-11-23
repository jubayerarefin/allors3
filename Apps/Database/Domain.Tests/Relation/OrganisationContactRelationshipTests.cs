// <copyright file="OrganisationContactRelationshipTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using System.Linq;
    using Xunit;

    public class OrganisationContactRelationshipTests : DomainTest, IClassFixture<Fixture>
    {
        private OrganisationContactRelationship organisationContactRelationship;
        private Organisation organisation;
        private Person contact;

        public OrganisationContactRelationshipTests(Fixture fixture) : base(fixture)
        {
            this.organisation = (Organisation)this.InternalOrganisation.ActiveCustomers.FirstOrDefault(v => v.GetType().Name == typeof(Organisation).Name);
            this.organisationContactRelationship = this.organisation.OrganisationContactRelationshipsWhereOrganisation.FirstOrDefault();
            this.contact = this.organisationContactRelationship.Contact;

            this.Session.Derive();
            this.Session.Commit();
        }

        [Fact]
        public void GivenorganisationContactRelationship_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var contact = new PersonBuilder(this.Session).WithLastName("organisationContact").Build();
            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            var builder = new OrganisationContactRelationshipBuilder(this.Session);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithContact(contact);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithOrganisation(new OrganisationBuilder(this.Session).WithName("organisation").WithLocale(this.Session.GetSingleton().DefaultLocale).Build());
            builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenPerson_WhenFirstContactForOrganisationIsCreated_ThenContactUserGroupIsCreated()
        {
            this.InstantiateObjects(this.Session);

            var usergroup = this.organisationContactRelationship.Organisation.ContactsUserGroup;
            Assert.Contains(this.organisationContactRelationship.Contact, usergroup.Members);
        }

        [Fact]
        public void GivenNextPerson_WhenContactForOrganisationIsCreated_ThenContactIsAddedToUserGroup()
        {
            this.InstantiateObjects(this.Session);

            var usergroup = this.organisationContactRelationship.Organisation.ContactsUserGroup;
            Assert.Single(usergroup.Members);
            Assert.Contains(this.organisationContactRelationship.Contact, usergroup.Members);

            var secondRelationship = new OrganisationContactRelationshipBuilder(this.Session)
                .WithContact(new PersonBuilder(this.Session).WithLastName("contact 2").Build())
                .WithOrganisation(this.organisation)
                .WithFromDate(this.Session.Now())
                .Build();

            this.Session.Derive();

            Assert.Equal(2, usergroup.Members.Count);
            Assert.Contains(secondRelationship.Contact, usergroup.Members);
        }

        [Fact]
        public void GivenOrganisationContactRelationship_WhenRelationshipPeriodIsNotValid_ThenContactIsNotInCustomerContactUserGroup()
        {
            this.InstantiateObjects(this.Session);

            var usergroup = this.organisationContactRelationship.Organisation.ContactsUserGroup;

            Assert.Single(usergroup.Members);
            Assert.Contains(this.contact, usergroup.Members);

            this.organisationContactRelationship.FromDate = this.Session.Now().AddDays(+1);
            this.organisationContactRelationship.RemoveThroughDate();

            this.Session.Derive();

            Assert.Empty(usergroup.Members);

            this.organisationContactRelationship.FromDate = this.Session.Now();
            this.organisationContactRelationship.RemoveThroughDate();

            this.Session.Derive();

            Assert.Single(usergroup.Members);
            Assert.Contains(this.contact, usergroup.Members);

            this.organisationContactRelationship.FromDate = this.Session.Now().AddDays(-2);
            this.organisationContactRelationship.ThroughDate = this.Session.Now().AddDays(-1);

            this.Session.Derive();

            Assert.Empty(usergroup.Members);
        }

        private void InstantiateObjects(ISession session)
        {
            this.contact = (Person)session.Instantiate(this.contact);
            this.organisationContactRelationship = (OrganisationContactRelationship)session.Instantiate(this.organisationContactRelationship);
        }
    }
}
