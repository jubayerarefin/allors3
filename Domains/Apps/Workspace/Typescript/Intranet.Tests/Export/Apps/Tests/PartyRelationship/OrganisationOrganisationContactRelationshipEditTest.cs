using Allors.Meta;
using Pages.PartyRelationshipTests;
using src.allors.material.apps.objects.organisation.list;

namespace Tests.PartyRelationshipTests
{
    using System.Linq;

    using Allors;
    using Allors.Domain;

    using Components;

    using Xunit;

    [Collection("Test collection")]
    public class OrganisationOrganisationContactRelationshipEditTest : Test
    {
        private readonly OrganisationListComponent organisations;

        private readonly OrganisationContactRelationship editPartyRelationship;

        private readonly Organisation organisation;

        private readonly Person contact;

        public OrganisationOrganisationContactRelationshipEditTest(TestFixture fixture)
            : base(fixture)
        {
            this.organisation = new OrganisationBuilder(this.Session).WithName("organisation").Build();
            this.contact = new PersonBuilder(this.Session).WithLastName("contact").Build();

            this.editPartyRelationship = new OrganisationContactRelationshipBuilder(this.Session)
                .WithContactKind(new OrganisationContactKinds(this.Session).GeneralContact)
                .WithContact(this.contact)
                .WithOrganisation(this.organisation)
                .Build();

            this.Session.Derive();
            this.Session.Commit();

            this.Login();
            this.organisations = this.Sidenav.NavigateToOrganisations();
        }

        [Fact]
        public void Create()
        {
            var before = new OrganisationContactRelationships(this.Session).Extent().ToArray();

            var organisationOverviewPage = this.organisations.Select(this.organisation);
            var partyRelationshipOverviewPanelComponent = organisationOverviewPage.PartyrelationshipOverviewPanel.Click();
            partyRelationshipOverviewPanelComponent.Factory.Create(M.OrganisationContactRelationship);

            var partyRelationshipEdit = new PartyRelationshipEditComponent(organisationOverviewPage.Driver);
            partyRelationshipEdit
                .FromDate.Set(DateTimeFactory.CreateDate(2018, 12, 22))
                .ThroughDate.Set(DateTimeFactory.CreateDate(2018, 12, 22).AddYears(1))
                .ContactKinds.Toggle(new OrganisationContactKinds(this.Session).SalesContact.Description)
                .Contact.Set(this.contact.PartyName)
                .Save.Click();

            this.Driver.WaitForAngular();
            this.Session.Rollback();

            var after = new OrganisationContactRelationships(this.Session).Extent().ToArray();

            Assert.Equal(after.Length, before.Length + 1);

            var partyRelationship = after.Except(before).First();

            //Assert.Equal(DateTimeFactory.CreateDate(2018, 12, 22).Date, partyRelationship.FromDate.Date.ToUniversalTime().Date);
            //Assert.Equal(DateTimeFactory.CreateDate(2018, 12, 22).AddYears(1).Date, partyRelationship.ThroughDate.Value.Date.ToUniversalTime().Date);
            Assert.Equal(2, partyRelationship.ContactKinds.Count);
            Assert.Contains(new OrganisationContactKinds(this.Session).GeneralContact, partyRelationship.ContactKinds);
            Assert.Contains(new OrganisationContactKinds(this.Session).SalesContact, partyRelationship.ContactKinds);
            Assert.Equal(this.organisation, partyRelationship.Organisation);
            Assert.Equal(this.contact, partyRelationship.Contact);
        }

        [Fact]
        public void Edit()
        {
            var before = new OrganisationContactRelationships(this.Session).Extent().ToArray();

            var organisationOverview = this.organisations.Select(this.organisation);

            var partyRelationshipOverview = organisationOverview.PartyrelationshipOverviewPanel.Click();
            var row = partyRelationshipOverview.Table.FindRow(this.editPartyRelationship);
            var cell = row.FindCell("type");
            cell.Click();

            var partyRelationshipEdit = new PartyRelationshipEditComponent(organisationOverview.Driver);
            partyRelationshipEdit
                .FromDate.Set(DateTimeFactory.CreateDate(2018, 12, 22))
                .ThroughDate.Set(DateTimeFactory.CreateDate(2018, 12, 22).AddYears(1))
                .ContactKinds.Toggle(new OrganisationContactKinds(this.Session).GeneralContact.Description)
                .ContactKinds.Toggle(new OrganisationContactKinds(this.Session).SalesContact.Description)
                .ContactKinds.Toggle(new OrganisationContactKinds(this.Session).SupplierContact.Description)
                .Save.Click();

            this.Driver.WaitForAngular();
            this.Session.Rollback();

            var after = new OrganisationContactRelationships(this.Session).Extent().ToArray();

            Assert.Equal(after.Length, before.Length);

            //Assert.Equal(DateTimeFactory.CreateDate(2018, 12, 22).Date, this.editPartyRelationship.FromDate.Date.ToUniversalTime().Date);
            //Assert.Equal(DateTimeFactory.CreateDate(2018, 12, 22).AddYears(1).Date, this.editPartyRelationship.ThroughDate.Value.Date.ToUniversalTime().Date);
            Assert.Equal(2, this.editPartyRelationship.ContactKinds.Count);
            Assert.Contains(new OrganisationContactKinds(this.Session).SalesContact, this.editPartyRelationship.ContactKinds);
            Assert.Contains(new OrganisationContactKinds(this.Session).SupplierContact, this.editPartyRelationship.ContactKinds);
            Assert.Equal(this.organisation, this.editPartyRelationship.Organisation);
            Assert.Equal(this.contact, this.editPartyRelationship.Contact);
        }
    }
}
