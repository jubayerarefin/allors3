// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartyProductCategoryRevenueHistoryTests.cs" company="Allors bvba">
//   Copyright 2002-2009 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    using System;
    using Meta;
    using Xunit;

    
    public class PartyProductCategoryRevenueHistoryTests : DomainTest
    {
        [Fact]
        public void GivenSalesInvoice_WhenDerived_ThenTotalExVatIsAddedToPartyProductCategoryRevenueHistory()
        {
            var productItem = new SalesInvoiceItemTypes(this.DatabaseSession).ProductItem;
            var contactMechanism = new ContactMechanisms(this.DatabaseSession).Extent().First;

            var euro = new Currencies(this.DatabaseSession).FindBy(M.Currency.IsoCode, "EUR");
            var vatRate21 = new VatRateBuilder(this.DatabaseSession).WithRate(21).Build();
            var catMain = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("main cat").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .Build();
            var cat1 = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("cat for good1").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithParent(catMain)
                .Build();

            var good1 = new GoodBuilder(this.DatabaseSession)
                .WithSku("10101")
                .WithVatRate(vatRate21)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("good1").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithInventoryItemKind(new InventoryItemKinds(this.DatabaseSession).NonSerialized)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.DatabaseSession).Piece)
                .WithPrimaryProductCategory(cat1)
                .Build();

            var customer = new Organisations(this.DatabaseSession).FindBy(M.Organisation.Name, "customer");
            var internalOrganisation = new InternalOrganisations(this.DatabaseSession).FindBy(M.InternalOrganisation.Name, "internalOrganisation");
            internalOrganisation.PreferredCurrency = euro;

            new CustomerRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer).WithInternalOrganisation(internalOrganisation).Build();

            this.DatabaseSession.Derive(true);
            this.DatabaseSession.Commit();

            var date = DateTime.UtcNow.AddYears(-1).AddMonths(-1);
            decimal revenuePastTwelveMonths = 0;
            for (var i = 1; i <= 13; i++)
            {
                var invoice = new SalesInvoiceBuilder(this.DatabaseSession)
                    .WithInvoiceDate(date)
                    .WithBillToCustomer(customer)
                    .WithBillToContactMechanism(contactMechanism)
                    .WithSalesChannel(new SalesChannels(this.DatabaseSession).WebChannel)
                    .WithSalesInvoiceType(new SalesInvoiceTypes(this.DatabaseSession).SalesInvoice)
                    .Build();

                var item = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(1).WithActualUnitPrice(i * 10M).WithSalesInvoiceItemType(productItem).Build();
                invoice.AddSalesInvoiceItem(item);

                this.DatabaseSession.Derive(true);
                this.DatabaseSession.Commit();

                var history = customer.PartyProductCategoryRevenueHistoriesWhereParty.First;

                //// first iteration is too old
                if (i > 1)
                {
                    revenuePastTwelveMonths += i * 10M;
                }

                ////date in first iteration is too old, no history yet.
                if (history != null)
                {
                    Assert.Equal(revenuePastTwelveMonths, history.Revenue);
                }

                date = date.AddMonths(1);
            }
        }

        [Fact]
        public void DeriveHistory()
        {
            var productItem = new SalesInvoiceItemTypes(this.DatabaseSession).ProductItem;
            var contactMechanism = new ContactMechanisms(this.DatabaseSession).Extent().First;

            var customer1 = new OrganisationBuilder(this.DatabaseSession).WithName("customer1").Build();
            var customer2 = new OrganisationBuilder(this.DatabaseSession).WithName("customer2").Build();
            var salesRep1 = new PersonBuilder(this.DatabaseSession).WithLastName("salesRep1").Build();
            var salesRep2 = new PersonBuilder(this.DatabaseSession).WithLastName("salesRep2").Build();
            var catMain = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("main cat").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .Build();
            var cat1 = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("cat for good1").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithParent(catMain)
                .Build();
            var cat2 = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("cat for good2").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithParent(catMain)
                .Build();

            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer1).WithProductCategory(cat1).WithSalesRepresentative(salesRep1).Build();
            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer1).WithProductCategory(cat2).WithSalesRepresentative(salesRep2).Build();

            this.DatabaseSession.Derive(true);

            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer2).WithProductCategory(cat1).WithSalesRepresentative(salesRep1).Build();
            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer2).WithProductCategory(cat2).WithSalesRepresentative(salesRep2).Build();

            this.DatabaseSession.Derive(true);

            var euro = new Currencies(this.DatabaseSession).FindBy(M.Currency.IsoCode, "EUR");
            var vatRate21 = new VatRateBuilder(this.DatabaseSession).WithRate(21).Build();

            var good1 = new GoodBuilder(this.DatabaseSession)
                .WithSku("10101")
                .WithVatRate(vatRate21)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("good1").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithInventoryItemKind(new InventoryItemKinds(this.DatabaseSession).NonSerialized)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.DatabaseSession).Piece)
                .WithPrimaryProductCategory(cat1)
                .Build();

            var good2 = new GoodBuilder(this.DatabaseSession)
                .WithSku("10102")
                .WithVatRate(vatRate21)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("good2").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithInventoryItemKind(new InventoryItemKinds(this.DatabaseSession).NonSerialized)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.DatabaseSession).Piece)
                .WithPrimaryProductCategory(cat2)
                .Build();

            var internalOrganisation = new InternalOrganisations(this.DatabaseSession).FindBy(M.InternalOrganisation.Name, "internalOrganisation");
            internalOrganisation.PreferredCurrency = euro;

            new CustomerRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer1).WithInternalOrganisation(internalOrganisation).Build();
            new CustomerRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer2).WithInternalOrganisation(internalOrganisation).Build();

            this.DatabaseSession.Derive(true);

            var invoice1 = new SalesInvoiceBuilder(this.DatabaseSession)
                .WithInvoiceDate(DateTime.UtcNow.AddMonths(-1))
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer1)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.DatabaseSession).SalesInvoice)
                .Build();

            var item1a = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(3).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice1.AddSalesInvoiceItem(item1a);

            var item1b = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(3).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice1.AddSalesInvoiceItem(item1b);

            var item1c = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good2).WithQuantity(5).WithActualUnitPrice(10).WithSalesInvoiceItemType(productItem).Build();
            invoice1.AddSalesInvoiceItem(item1c);

            this.DatabaseSession.Derive(true);

            var invoice2 = new SalesInvoiceBuilder(this.DatabaseSession)
                .WithInvoiceDate(DateTime.UtcNow)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer1)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.DatabaseSession).SalesInvoice)
                .Build();

            var item2a = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(3).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice2.AddSalesInvoiceItem(item2a);

            var item2b = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(3).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice2.AddSalesInvoiceItem(item2b);

            var item2c = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good2).WithQuantity(5).WithActualUnitPrice(10).WithSalesInvoiceItemType(productItem).Build();
            invoice2.AddSalesInvoiceItem(item2c);

            this.DatabaseSession.Derive(true);

            Singleton.Instance(this.DatabaseSession).DeriveRevenues(new NonLogging.Derivation(this.DatabaseSession));

            var customer1Cat1RevenueHistories = customer1.PartyProductCategoryRevenueHistoriesWhereParty;
            customer1Cat1RevenueHistories.Filter.AddEquals(M.PartyProductCategoryRevenueHistory.ProductCategory, cat1);
            var customer1Cat1RevenueHistory = customer1Cat1RevenueHistories.First;

            var customer1Cat2RevenueHistories = customer1.PartyProductCategoryRevenueHistoriesWhereParty;
            customer1Cat2RevenueHistories.Filter.AddEquals(M.PartyProductCategoryRevenueHistory.ProductCategory, cat2);
            var customer1Cat2RevenueHistory = customer1Cat2RevenueHistories.First;

            var customer1CatMainRevenueHistories = customer1.PartyProductCategoryRevenueHistoriesWhereParty;
            customer1CatMainRevenueHistories.Filter.AddEquals(M.PartyProductCategoryRevenueHistory.ProductCategory, catMain);
            var customer1CatMainRevenueHistory = customer1CatMainRevenueHistories.First;

            Assert.Equal(180, customer1Cat1RevenueHistory.Revenue);
            Assert.Equal(100, customer1Cat2RevenueHistory.Revenue);
            Assert.Equal(280, customer1CatMainRevenueHistory.Revenue);

            var invoice3 = new SalesInvoiceBuilder(this.DatabaseSession)
                .WithInvoiceDate(DateTime.UtcNow)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer2)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.DatabaseSession).SalesInvoice)
                .Build();

            var item3a = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(1).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice3.AddSalesInvoiceItem(item3a);

            var item3b = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good2).WithQuantity(1).WithActualUnitPrice(10).WithSalesInvoiceItemType(productItem).Build();
            invoice3.AddSalesInvoiceItem(item3b);

            this.DatabaseSession.Derive(true);

            Singleton.Instance(this.DatabaseSession).DeriveRevenues(new NonLogging.Derivation(this.DatabaseSession));

            var customer2Cat1RevenueHistories = customer2.PartyProductCategoryRevenueHistoriesWhereParty;
            customer2Cat1RevenueHistories.Filter.AddEquals(M.PartyProductCategoryRevenueHistory.ProductCategory, cat1);
            var customer2Cat1RevenueHistory = customer2Cat1RevenueHistories.First;

            var customer2Cat2RevenueHistories = customer2.PartyProductCategoryRevenueHistoriesWhereParty;
            customer2Cat2RevenueHistories.Filter.AddEquals(M.PartyProductCategoryRevenueHistory.ProductCategory, cat2);
            var customer2Cat2RevenueHistory = customer2Cat2RevenueHistories.First;

            var customer2CatMainRevenueHistories = customer2.PartyProductCategoryRevenueHistoriesWhereParty;
            customer2CatMainRevenueHistories.Filter.AddEquals(M.PartyProductCategoryRevenueHistory.ProductCategory, catMain);
            var customer2CatMainRevenueHistory = customer2CatMainRevenueHistories.First;

            Assert.Equal(180, customer1Cat1RevenueHistory.Revenue);
            Assert.Equal(100, customer1Cat2RevenueHistory.Revenue);
            Assert.Equal(280, customer1CatMainRevenueHistory.Revenue);

            Assert.Equal(15, customer2Cat1RevenueHistory.Revenue);
            Assert.Equal(10, customer2Cat2RevenueHistory.Revenue);
            Assert.Equal(25, customer2CatMainRevenueHistory.Revenue);
        }
    }
}
