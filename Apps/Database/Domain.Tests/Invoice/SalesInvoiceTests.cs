// <copyright file="SalesInvoiceTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Domain
{
    using System;
    using System.Linq;
    using Allors.Domain.TestPopulation;
    using Resources;
    using Xunit;
    using Allors.Meta;

    public class SalesInvoiceTests : DomainTest, IClassFixture<Fixture>
    {
        public SalesInvoiceTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void GivenSalesInvoice_WhenBuild_ThenLastObjectStateEqualsCurrencObjectState()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            Assert.Equal(new SalesInvoiceStates(this.Session).ReadyForPosting, invoice.SalesInvoiceState);
            Assert.Equal(invoice.LastSalesInvoiceState, invoice.SalesInvoiceState);
        }

        [Fact]
        public void GivenSalesInvoice_WhenBuild_ThenPreviousObjectStateIsNull()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            Assert.Null(invoice.PreviousSalesInvoiceState);
        }

        [Fact]
        public void GivenSalesInvoice_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            ContactMechanism billToContactMechanism = new PostalAddressBuilder(this.Session).WithPostalAddressBoundary(mechelen).WithAddress1("Haverwerf 15").Build();

            new CustomerRelationshipBuilder(this.Session).WithCustomer(customer).Build();

            this.Session.Derive();
            this.Session.Commit();

            var builder = new SalesInvoiceBuilder(this.Session);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithBillToCustomer(customer);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithBillToContactMechanism(billToContactMechanism);
            var invoice = builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);

            Assert.Equal(invoice.SalesInvoiceState, new SalesInvoiceStates(this.Session).ReadyForPosting);
            Assert.Equal(invoice.SalesInvoiceState, invoice.LastSalesInvoiceState);

            builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenSalesInvoice_WhenDerivingWithMultipleInternalOrganisations_ThenBilledFromMustExist()
        {
            var internalOrganisation = new Organisations(this.Session).FindBy(this.M.Organisation.IsInternalOrganisation, true);

            var anotherInternalOrganisation = new OrganisationBuilder(this.Session)
                .WithIsInternalOrganisation(true)
                .WithDoAccounting(false)
                .WithName("internalOrganisation")
                .WithPreferredCurrency(new Currencies(this.Session).CurrencyByCode["EUR"])
                .WithIncomingShipmentNumberPrefix("incoming shipmentno: ")
                .WithPurchaseInvoiceNumberPrefix("incoming invoiceno: ")
                .WithPurchaseOrderNumberPrefix("purchase orderno: ")
                .WithSubAccountCounter(new CounterBuilder(this.Session).WithUniqueId(Guid.NewGuid()).WithValue(0).Build())
                .Build();

            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            ContactMechanism billToContactMechanism = new PostalAddressBuilder(this.Session).WithPostalAddressBoundary(mechelen).WithAddress1("Haverwerf 15").Build();

            new CustomerRelationshipBuilder(this.Session).WithCustomer(customer).WithInternalOrganisation(internalOrganisation).Build();

            this.Session.Commit();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(billToContactMechanism)
                .Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            invoice.BilledFrom = this.InternalOrganisation;

            Assert.False(this.Session.Derive(true).HasErrors);
        }

        [Fact]
        public void GivenSalesInvoice_WhenDeriving_ThenBillToCustomerMustBeActiveCustomer()
        {
            var customer = new OrganisationBuilder(this.Session)
                .WithName("customer")

                .Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            var expectedError = ErrorMessages.PartyIsNotACustomer;
            Assert.Equal(expectedError, this.Session.Derive(false).Errors[0].Message);

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenSalesInvoice_WhenDeriving_ThenShipToCustomerMustBeActiveCustomer()
        {
            var billtoCcustomer = new OrganisationBuilder(this.Session).WithName("billToCustomer").Build();
            var shipToCustomer = new OrganisationBuilder(this.Session).WithName("shipToCustomer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(billtoCcustomer)
                .WithShipToCustomer(shipToCustomer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            var expectedError = ErrorMessages.PartyIsNotACustomer;
            Assert.Equal(expectedError, this.Session.Derive(false).Errors[0].Message);

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(shipToCustomer).Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenSalesInvoice_WhenGettingInvoiceNumberWithoutFormat_ThenInvoiceNumberShouldBeReturned()
        {
            var store = new Stores(this.Session).Extent().First(v => Equals(v.InternalOrganisation, this.InternalOrganisation));
            store.RemoveSalesInvoiceNumberPrefix();

            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice1 = new SalesInvoiceBuilder(this.Session)
                .WithStore(store)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            this.Session.Derive();

            Assert.Equal("1", invoice1.InvoiceNumber);

            var invoice2 = new SalesInvoiceBuilder(this.Session)
                .WithStore(store)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            this.Session.Derive();

            Assert.Equal("2", invoice2.InvoiceNumber);
        }

        [Fact]
        public void GivenBilledFromWithoutInvoiceNumberPrefix_WhenDeriving_ThenSortableInvoiceNumberIsSet()
        {
            this.InternalOrganisation.StoresWhereInternalOrganisation.First.RemoveSalesInvoiceNumberPrefix();
            new UnifiedGoodBuilder(this.Session).WithSerialisedDefaults(this.InternalOrganisation).Build();
            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();
            this.Session.Derive();

            invoice.Send();
            this.Session.Derive();

            Assert.Equal(int.Parse(invoice.InvoiceNumber), invoice.SortableInvoiceNumber);
        }

        [Fact]
        public void GivenBilledFromWithInvoiceNumberPrefix_WhenDeriving_ThenSortableInvoiceNumberIsSet()
        {
            this.InternalOrganisation.StoresWhereInternalOrganisation.First.SalesInvoiceNumberPrefix = "prefix-";
            new UnifiedGoodBuilder(this.Session).WithSerialisedDefaults(this.InternalOrganisation).Build();
            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();
            this.Session.Derive();

            invoice.Send();
            this.Session.Derive();

            Assert.Equal(int.Parse(invoice.InvoiceNumber.Split('-')[1]), invoice.SortableInvoiceNumber);
        }

        [Fact]
        public void GivenBilledFromWithParametrizedInvoiceNumberPrefix_WhenDeriving_ThenSortableInvoiceNumberIsSet()
        {
            this.InternalOrganisation.StoresWhereInternalOrganisation.First.SalesInvoiceNumberPrefix = "prefix-{year}-";
            new UnifiedGoodBuilder(this.Session).WithSerialisedDefaults(this.InternalOrganisation).Build();
            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();
            this.Session.Derive();

            invoice.Send();
            this.Session.Derive();

            Assert.Equal(int.Parse(string.Concat(this.Session.Now().Date.Year.ToString(), invoice.InvoiceNumber.Split('-').Last())), invoice.SortableInvoiceNumber);
        }

        [Fact]
        public void GivenSingletonWithInvoiceSequenceFiscalYear_WhenCreatingInvoice_ThenInvoiceNumberFromFiscalYearMustBeUsed()
        {
            var store = new Stores(this.Session).Extent().First(v => Equals(v.InternalOrganisation, this.InternalOrganisation));
            store.RemoveSalesInvoiceNumberPrefix();

            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice1 = new SalesInvoiceBuilder(this.Session)
                .WithStore(store)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            this.Session.Derive();

            invoice1.Send();

            Assert.False(store.ExistSalesInvoiceCounter);
            Assert.Equal(this.Session.Now().Year, store.FiscalYearInvoiceNumbers.First.FiscalYear);
            Assert.Equal("1", invoice1.InvoiceNumber);

            var invoice2 = new SalesInvoiceBuilder(this.Session)
                .WithStore(store)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            this.Session.Derive();

            invoice2.Send();

            Assert.False(store.ExistSalesInvoiceCounter);
            Assert.Equal(this.Session.Now().Year, store.FiscalYearInvoiceNumbers.First.FiscalYear);
            Assert.Equal("2", invoice2.InvoiceNumber);
        }

        [Fact]
        public void GivenSalesInvoiceSend_WhenGettingInvoiceNumberWithFormat_ThenFormattedInvoiceNumberShouldBeReturned()
        {
            var store = new Stores(this.Session).Extent().First(v => Equals(v.InternalOrganisation, this.InternalOrganisation));
            store.SalesInvoiceNumberPrefix = "the format is ";
            store.SalesInvoiceTemporaryCounter = new CounterBuilder(this.Session).WithUniqueId(Guid.NewGuid()).WithValue(10).Build();

            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithStore(store)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            this.Session.Derive();

            invoice.Send();

            this.Session.Derive();

            Assert.Equal("the format is 1", invoice.InvoiceNumber);
        }

        [Fact]
        public void GivenSalesInvoiceNotSend_WhenGettingInvoiceNumberWithFormat_ThenTemporaryInvoiceNumberShouldBeReturned()
        {
            var store = new Stores(this.Session).Extent().First(v => Equals(v.InternalOrganisation, this.InternalOrganisation));
            store.SalesInvoiceNumberPrefix = "the format is ";
            store.SalesInvoiceTemporaryCounter = new CounterBuilder(this.Session).WithUniqueId(Guid.NewGuid()).WithValue(10).Build();

            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithStore(store)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            this.Session.Derive();

            Assert.Equal("11", invoice.InvoiceNumber);
        }

        [Fact]
        public void GivenSalesInvoice_WhenDeriving_ThenBilledFromContactMechanismMustExist()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var homeAddress = new PostalAddressBuilder(this.Session)
                .WithAddress1("Sint-Lambertuslaan 78")
                .WithLocality("Muizen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var billingAddress = new PartyContactMechanismBuilder(this.Session)
                .WithContactMechanism(homeAddress)
                .WithContactPurpose(new ContactMechanismPurposes(this.Session).BillingAddress)
                .WithUseAsDefault(true)
                .Build();

            customer.AddPartyContactMechanism(billingAddress);

            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            Assert.Equal(this.InternalOrganisation.BillingAddress, invoice.BilledFromContactMechanism);
        }

        [Fact]
        public void GivenSalesInvoiceWithBillToCustomerWithBillingAsdress_WhenDeriving_ThendBillToContactMechanismMustExist()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            ContactMechanism billToContactMechanism = new PostalAddressBuilder(this.Session).WithAddress1("Haverwerf 15").WithPostalAddressBoundary(mechelen).Build();

            var billingAddress = new PartyContactMechanismBuilder(this.Session)
                .WithContactMechanism(billToContactMechanism)
                .WithContactPurpose(new ContactMechanismPurposes(this.Session).BillingAddress)
                .WithUseAsDefault(true)
                .Build();

            customer.AddPartyContactMechanism(billingAddress);
            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            Assert.Equal(billingAddress.ContactMechanism, invoice.BillToContactMechanism);
        }

        [Fact]
        public void GivenSalesInvoiceBuilderWithBillToCustomerWithPreferredCurrency_WhenBuilding_ThenDerivedCurrencyIsCustomersPreferredCurrency()
        {
            var euro = new Currencies(this.Session).FindBy(this.M.Currency.IsoCode, "EUR");

            var customer = new OrganisationBuilder(this.Session)
                .WithName("customer")
                .WithPreferredCurrency(euro)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            var billToContactMechanismMechelen = new WebAddressBuilder(this.Session).WithElectronicAddressString("dummy").Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(billToContactMechanismMechelen)
                .Build();

            this.Session.Derive();

            Assert.Equal(euro, invoice.Currency);
        }

        [Fact]
        public void GivenSalesInvoiceWithShipToCustomerWithShippingAddress_WhenDeriving_ThenShipToAddressMustExist()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            ContactMechanism shipToContactMechanism = new PostalAddressBuilder(this.Session).WithAddress1("Haverwerf 15").WithPostalAddressBoundary(mechelen).Build();

            var shippingAddress = new PartyContactMechanismBuilder(this.Session)
                .WithContactMechanism(shipToContactMechanism)
                .WithContactPurpose(new ContactMechanismPurposes(this.Session).ShippingAddress)
                .WithUseAsDefault(true)
                .Build();

            customer.AddPartyContactMechanism(shippingAddress);

            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(customer)
                .WithShipToCustomer(customer)
                .WithBillToContactMechanism(shipToContactMechanism)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            Assert.Equal(shippingAddress.ContactMechanism, invoice.ShipToAddress);
        }

        [Fact]
        public void GivenSalesInvoiceBuilderWithoutBillToCustomer_WhenBuilding_ThenDerivedCurrencyIsSingletonsPreferredCurrency()
        {
            var euro = new Currencies(this.Session).FindBy(this.M.Currency.IsoCode, "EUR");

            var customer = new OrganisationBuilder(this.Session)
                .WithName("customer")
                .WithLocale(new Locales(this.Session).DutchBelgium)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            this.Session.Derive();

            Assert.Equal(euro, invoice.Currency);
        }

        [Fact]
        public void GivenSalesInvoice_WhenDeriving_ThenLocaleMustExist()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice1 = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).WithBillToContactMechanism(contactMechanism).Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            Assert.Equal(this.Session.GetSingleton().DefaultLocale, invoice1.Locale);

            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            customer.Locale = dutchLocale;

            var invoice2 = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).WithBillToContactMechanism(contactMechanism).Build();

            this.Session.Derive();

            Assert.Equal(dutchLocale, invoice2.Locale);
        }

        [Fact]
        public void GivenSalesInvoice_WhenDeriving_ThenTotalAmountMustBeDerived()
        {
            var euro = new Currencies(this.Session).FindBy(this.M.Currency.IsoCode, "EUR");
            var supplier = new OrganisationBuilder(this.Session).WithName("supplier").Build();

            var good = new NonUnifiedGoods(this.Session).FindBy(this.M.Good.Name, "good1");

            new SupplierOfferingBuilder(this.Session)
                .WithPart(good.Part)
                .WithSupplier(supplier)
                .WithFromDate(this.Session.Now())
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(7)
                .WithCurrency(euro)
                .Build();

            var productItem = new InvoiceItemTypes(this.Session).ProductItem;

            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithVatRegime(new VatRegimes(this.Session).Assessable21)
                .WithIrpfRegime(new IrpfRegimes(this.Session).Assessable19)
                .Build();

            var item1 = new SalesInvoiceItemBuilder(this.Session)
                .WithProduct(good)
                .WithInvoiceItemType(productItem)
                .WithQuantity(1)
                .WithAssignedUnitPrice(8)
                .Build();

            invoice.AddSalesInvoiceItem(item1);

            this.Session.Derive();

            Assert.Equal(8, invoice.TotalExVat);
            Assert.Equal(1.68M, invoice.TotalVat);
            Assert.Equal(9.68M, invoice.TotalIncVat);
            Assert.Equal(1.52M, invoice.TotalIrpf);
            Assert.Equal(8.16M, invoice.GrandTotal);

            var item2 = new SalesInvoiceItemBuilder(this.Session)
                .WithProduct(good)
                .WithInvoiceItemType(productItem)
                .WithQuantity(1)
                .WithAssignedUnitPrice(8)
                .Build();

            var item3 = new SalesInvoiceItemBuilder(this.Session)
                .WithProduct(good)
                .WithInvoiceItemType(productItem)
                .WithQuantity(1)
                .WithAssignedUnitPrice(8)
                .Build();

            invoice.AddSalesInvoiceItem(item2);
            invoice.AddSalesInvoiceItem(item3);

            this.Session.Derive();

            Assert.Equal(24, invoice.TotalExVat);
            Assert.Equal(5.04M, invoice.TotalVat);
            Assert.Equal(29.04M, invoice.TotalIncVat);
            Assert.Equal(invoice.TotalListPrice, invoice.TotalExVat);
        }

        [Fact]
        public void GivenSalesInvoiceWithShippingAndHandlingAmount_WhenDeriving_ThenInvoiceTotalsMustIncludeShippingAndHandlingAmount()
        {
            var adjustment = new ShippingAndHandlingChargeBuilder(this.Session).WithAmount(7.5M).Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(new OrganisationBuilder(this.Session).WithName("customer").Build())
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithOrderAdjustment(adjustment)
                .WithVatRegime(new VatRegimes(this.Session).Assessable21)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            var item1 = new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(3).WithAssignedUnitPrice(15).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build();
            invoice.AddSalesInvoiceItem(item1);

            this.Session.Derive();

            Assert.Equal(45, invoice.TotalBasePrice);
            Assert.Equal(0, invoice.TotalDiscount);
            Assert.Equal(0, invoice.TotalSurcharge);
            Assert.Equal(7.5m, invoice.TotalShippingAndHandling);
            Assert.Equal(0, invoice.TotalFee);
            Assert.Equal(52.5m, invoice.TotalExVat);
            Assert.Equal(11.03m, invoice.TotalVat);
            Assert.Equal(63.53m, invoice.TotalIncVat);
        }

        [Fact]
        public void GivenSalesInvoiceWithShippingAndHandlingPercentage_WhenDeriving_ThenSalesInvoiceTotalsMustIncludeShippingAndHandlingAmount()
        {
            var adjustment = new ShippingAndHandlingChargeBuilder(this.Session).WithPercentage(5).Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(new OrganisationBuilder(this.Session).WithName("customer").Build())
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithOrderAdjustment(adjustment)
                .WithVatRegime(new VatRegimes(this.Session).Assessable21)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            var item1 = new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(3).WithAssignedUnitPrice(15).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build();
            invoice.AddSalesInvoiceItem(item1);

            this.Session.Derive();

            Assert.Equal(45, invoice.TotalBasePrice);
            Assert.Equal(0, invoice.TotalDiscount);
            Assert.Equal(0, invoice.TotalSurcharge);
            Assert.Equal(2.25m, invoice.TotalShippingAndHandling);
            Assert.Equal(0, invoice.TotalFee);
            Assert.Equal(47.25m, invoice.TotalExVat);
            Assert.Equal(9.92m, invoice.TotalVat);
            Assert.Equal(57.17m, invoice.TotalIncVat);
        }

        [Fact]
        public void GivenSalesInvoiceWithFeeAmount_WhenDeriving_ThenSalesInvoiceTotalsMustIncludeFeeAmount()
        {
            var adjustment = new FeeBuilder(this.Session).WithAmount(7.5M).Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(new OrganisationBuilder(this.Session).WithName("customer").Build())
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithOrderAdjustment(adjustment)
                .WithVatRegime(new VatRegimes(this.Session).Assessable21)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            var item1 = new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(3).WithAssignedUnitPrice(15).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build();
            invoice.AddSalesInvoiceItem(item1);

            this.Session.Derive();

            Assert.Equal(45, invoice.TotalBasePrice);
            Assert.Equal(0, invoice.TotalDiscount);
            Assert.Equal(0, invoice.TotalSurcharge);
            Assert.Equal(0, invoice.TotalShippingAndHandling);
            Assert.Equal(7.5m, invoice.TotalFee);
            Assert.Equal(52.5m, invoice.TotalExVat);
            Assert.Equal(11.03m, invoice.TotalVat);
            Assert.Equal(63.53m, invoice.TotalIncVat);
        }

        [Fact]
        public void GivenSalesInvoiceWithFeePercentage_WhenDeriving_ThenSalesInvoiceTotalsMustIncludeFeeAmount()
        {
            var adjustment = new FeeBuilder(this.Session).WithPercentage(5).Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(new OrganisationBuilder(this.Session).WithName("customer").Build())
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithOrderAdjustment(adjustment)
                .WithVatRegime(new VatRegimes(this.Session).Assessable21)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            var item1 = new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(3).WithAssignedUnitPrice(15).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build();
            invoice.AddSalesInvoiceItem(item1);

            this.Session.Derive();

            Assert.Equal(45, invoice.TotalBasePrice);
            Assert.Equal(0, invoice.TotalDiscount);
            Assert.Equal(0, invoice.TotalSurcharge);
            Assert.Equal(0, invoice.TotalShippingAndHandling);
            Assert.Equal(2.25m, invoice.TotalFee);
            Assert.Equal(47.25m, invoice.TotalExVat);
            Assert.Equal(9.92m, invoice.TotalVat);
            Assert.Equal(57.17m, invoice.TotalIncVat);
        }

        [Fact]
        public void GivenSalesInvoice_WhenShipToAndBillToAreSameCustomer_ThenDerivedCustomersIsSingleCustomer()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithShipToCustomer(customer)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            Assert.Single(invoice.Customers);
            Assert.Equal(customer, invoice.Customers.First);
        }

        [Fact]
        public void GivenSalesInvoice_WhenShipToAndBillToAreDifferentCustomers_ThenDerivedCustomersHoldsBothCustomers()
        {
            var billToCustomer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var shipToCustomer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithShipToCustomer(shipToCustomer)
                .WithBillToCustomer(billToCustomer)
                .WithBillToContactMechanism(contactMechanism)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();
            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.ShipToCustomer).Build();

            this.Session.Derive();

            Assert.Equal(2, invoice.Customers.Count);
            Assert.Contains(billToCustomer, invoice.Customers);
            Assert.Contains(shipToCustomer, invoice.Customers);
        }

        [Fact]
        public void GivenSalesInvoice_WhenPartialPaymentIsReceived_ThenInvoiceStateIsSetToPartiallyPaid()
        {
            var billToCustomer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            this.Session.Derive();
            this.Session.Commit();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(billToCustomer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(2).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            this.Session.Derive();

            new ReceiptBuilder(this.Session)
                .WithAmount(90)
                .WithPaymentApplication(new PaymentApplicationBuilder(this.Session).WithInvoiceItem(invoice.SalesInvoiceItems[0]).WithAmountApplied(90).Build())
                .Build();

            this.Session.Derive();

            Assert.Equal(new SalesInvoiceStates(this.Session).PartiallyPaid, invoice.SalesInvoiceState);
        }

        [Fact]
        public void GiveninvoiceItem_WhenFullPaymentIsReceived_ThenInvoiceItemStateIsSetToPaid()
        {
            var billToCustomer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");
            good.VatRate = new VatRateBuilder(this.Session).WithRate(0).Build();

            this.Session.Derive();
            this.Session.Commit();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(billToCustomer)
                .WithBillToContactMechanism(contactMechanism)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            invoice.AddSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build());

            this.Session.Derive();

            new ReceiptBuilder(this.Session)
                .WithAmount(100)
                .WithPaymentApplication(new PaymentApplicationBuilder(this.Session).WithInvoiceItem(invoice.InvoiceItems[0]).WithAmountApplied(100).Build())
                .Build();

            this.Session.Derive();

            Assert.Equal(new SalesInvoiceStates(this.Session).Paid, invoice.SalesInvoiceState);
        }

        [Fact]
        public void GiveninvoiceItem_WhenCancelled_ThenInvoiceItemsAreCancelled()
        {
            var billToCustomer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            this.Session.Derive();
            this.Session.Commit();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(billToCustomer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            this.Session.Derive();

            invoice.CancelInvoice();

            this.Session.Derive();

            Assert.Equal(new SalesInvoiceStates(this.Session).Cancelled, invoice.SalesInvoiceState);
            Assert.Equal(new SalesInvoiceItemStates(this.Session).CancelledByInvoice, invoice.SalesInvoiceItems[0].SalesInvoiceItemState);
            Assert.Equal(new SalesInvoiceItemStates(this.Session).CancelledByInvoice, invoice.SalesInvoiceItems[1].SalesInvoiceItemState);
        }

        [Fact]
        public void GiveninvoiceItem_WhenWrittenOff_ThenInvoiceItemsAreWrittenOff()
        {
            var billToCustomer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            this.Session.Derive();
            this.Session.Commit();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(billToCustomer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(invoice.BillToCustomer).Build();

            invoice.WriteOff();

            this.Session.Derive();

            Assert.Equal(new SalesInvoiceStates(this.Session).WrittenOff, invoice.SalesInvoiceState);
            Assert.Equal(new SalesInvoiceItemStates(this.Session).WrittenOff, invoice.SalesInvoiceItems[0].SalesInvoiceItemState);
            Assert.Equal(new SalesInvoiceItemStates(this.Session).WrittenOff, invoice.SalesInvoiceItems[1].SalesInvoiceItemState);
        }

        [Fact]
        public void GivenSalesOrder_WhenBillngForOrderItemsAndConfirmed_ThenInvoiceIsCreated()
        {
            var store = this.Session.Extent<Store>().First;
            store.IsAutomaticallyShipped = true;
            store.IsImmediatelyPicked = true;
            store.BillingProcess = new BillingProcesses(this.Session).BillingForOrderItems;

            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            var mechelenAddress = new PostalAddressBuilder(this.Session).WithPostalAddressBoundary(mechelen).WithAddress1("Haverwerf 15").Build();
            var shipToMechelen = new PartyContactMechanismBuilder(this.Session)
                .WithContactMechanism(mechelenAddress)
                .WithContactPurpose(new ContactMechanismPurposes(this.Session).ShippingAddress)
                .WithUseAsDefault(true)
                .Build();

            var supplier = new OrganisationBuilder(this.Session).WithName("supplier").Build();
            var customer = new PersonBuilder(this.Session).WithLastName("person1").WithPartyContactMechanism(shipToMechelen).Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            new SupplierRelationshipBuilder(this.Session)
                .WithSupplier(supplier)
                .WithFromDate(this.Session.Now())
                .Build();

            var good1 = new NonUnifiedGoods(this.Session).FindBy(this.M.Good.Name, "good1");

            new SupplierOfferingBuilder(this.Session)
                .WithPart(good1.Part)
                .WithSupplier(supplier)
                .WithFromDate(this.Session.Now())
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(7)
                .WithCurrency(new Currencies(this.Session).FindBy(this.M.Currency.IsoCode, "EUR"))
                .Build();

            this.Session.Derive();

            new InventoryItemTransactionBuilder(this.Session).WithQuantity(100).WithReason(new InventoryTransactionReasons(this.Session).Unknown).WithPart(good1.Part).Build();

            this.Session.Derive();

            var order = new SalesOrderBuilder(this.Session)
                .WithBillToCustomer(customer)
                .WithShipToCustomer(customer)
                .Build();

            var item1 = new SalesOrderItemBuilder(this.Session).WithProduct(good1).WithQuantityOrdered(1).WithAssignedUnitPrice(15).Build();
            order.AddSalesOrderItem(item1);

            this.Session.Derive();

            order.SetReadyForPosting();

            this.Session.Derive();

            order.Post();
            this.Session.Derive(true);

            order.Accept();
            this.Session.Derive(true);

            order.Invoice();

            this.Session.Derive();

            Assert.Equal(new SalesOrderStates(this.Session).InProcess, order.SalesOrderState);
            Assert.Equal(new SalesOrderPaymentStates(this.Session).NotPaid, order.SalesOrderPaymentState);
        }
    }

    public class SalesInvoiceDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public SalesInvoiceDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void OnCreateDeriveSalesInvoiceState()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.SalesInvoiceState, new SalesInvoiceStates(this.Session).ReadyForPosting);
        }

        [Fact]
        public void OnCreateDeriveEntryDate()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.True(invoice.ExistEntryDate);
        }

        [Fact]
        public void OnCreateDeriveInvoiceDate()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.True(invoice.ExistInvoiceDate);
        }

        [Fact]
        public void OnCreateDeriveSalesInvoiceType()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.SalesInvoiceType, new SalesInvoiceTypes(this.Session).SalesInvoice);
        }

        [Fact]
        public void OnCreateDeriveBilledFrom()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.BilledFrom, this.InternalOrganisation);
        }

        [Fact]
        public void OnCreateDeriveStore()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.Store, new Stores(this.Session).Extent().First);
        }

        [Fact]
        public void OnCreateDeriveInvoiceNumber()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();
            var number = new Stores(this.Session).Extent().First.SalesInvoiceTemporaryCounter.Value;

            this.Session.Derive(false);

            Assert.Equal(invoice.InvoiceNumber, (number + 1).ToString());
        }

        [Fact]
        public void OnCreateDeriveSortableInvoiceNumber()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();
            var number = new Stores(this.Session).Extent().First.SalesInvoiceTemporaryCounter.Value;

            this.Session.Derive(false);

            Assert.Equal(invoice.SortableInvoiceNumber.Value, number + 1);
        }

        [Fact]
        public void OnCreateDeriveBilledFromContactMechanism()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.BilledFromContactMechanism, this.InternalOrganisation.BillingAddress);
        }

        [Fact]
        public void OnCreateDeriveBillToContactMechanism()
        {
            var customer = this.InternalOrganisation.ActiveCustomers.First;
            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.BillToContactMechanism, customer.BillingAddress);
        }

        [Fact]
        public void OnCreateDeriveBillToEndCustomerContactMechanism()
        {
            var customer = this.InternalOrganisation.ActiveCustomers.First;
            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToEndCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.BillToEndCustomerContactMechanism, customer.BillingAddress);
        }

        [Fact]
        public void OnCreateDeriveShipToAddress()
        {
            var customer = this.InternalOrganisation.ActiveCustomers.First;
            var invoice = new SalesInvoiceBuilder(this.Session).WithShipToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.ShipToAddress, customer.ShippingAddress);
        }

        [Fact]
        public void OnCreateDeriveShipToEndCustomerAddress()
        {
            var customer = this.InternalOrganisation.ActiveCustomers.First;
            var invoice = new SalesInvoiceBuilder(this.Session).WithShipToEndCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.ShipToEndCustomerAddress, customer.ShippingAddress);
        }

        [Fact]
        public void OnCreateDeriveCurrencyFromInternalOrganisationPreferredCurrency()
        {
            Assert.True(this.InternalOrganisation.ExistPreferredCurrency);

            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.Currency, this.InternalOrganisation.PreferredCurrency);
        }

        [Fact]
        public void OnCreateDeriveCurrencyFromSingletonDefaultLocale()
        {
            this.InternalOrganisation.RemovePreferredCurrency();

            this.Session.GetSingleton().DefaultLocale = new LocaleBuilder(this.Session)
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "SE"))
                .WithLanguage(new Languages(this.Session).FindBy(this.M.Language.IsoCode, "sv"))
                .Build();

            this.Session.Derive();

            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.Currency, this.Session.GetSingleton().DefaultLocale.Country.Currency);
        }

        [Fact]
        public void OnCreateDeriveCurrencyFromBillToCustomerPreferredCurrency()
        {
            var newLocale = new LocaleBuilder(this.Session)
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "SE"))
                .WithLanguage(new Languages(this.Session).FindBy(this.M.Language.IsoCode, "sv"))
                .Build();

            var customer = this.InternalOrganisation.ActiveCustomers.First;
            customer.RemoveLocale();
            customer.PreferredCurrency = newLocale.Country.Currency;

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.Currency, customer.PreferredCurrency);
        }

        [Fact]
        public void OnCreateDeriveCurrencyFromBillToCustomerLocale()
        {
            var newLocale = new LocaleBuilder(this.Session)
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "SE"))
                .WithLanguage(new Languages(this.Session).FindBy(this.M.Language.IsoCode, "sv"))
                .Build();

            var customer = this.InternalOrganisation.ActiveCustomers.First;
            customer.Locale = newLocale;
            customer.RemovePreferredCurrency();

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.Currency, newLocale.Country.Currency);
        }

        [Fact]
        public void OnCreateDeriveVatRegimeFromBillToCustomerVatRegime()
        {
            var customer = this.InternalOrganisation.ActiveCustomers.First;

            Assert.True(customer.ExistVatRegime);

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.VatRegime, customer.VatRegime);
        }

        [Fact]
        public void OnCreateDeriveIrpfRegimeFromBillToCustomerIrpfRegime()
        {
            var customer = this.InternalOrganisation.ActiveCustomers.First;
            customer.IrpfRegime = new IrpfRegimes(this.Session).Assessable15;

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.IrpfRegime, customer.IrpfRegime);
        }

        [Fact]
        public void OnCreateDeriveLocaleFromBillToCustomerLocale()
        {
            var swedishLocale = new LocaleBuilder(this.Session)
               .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "SE"))
               .WithLanguage(new Languages(this.Session).FindBy(this.M.Language.IsoCode, "sv"))
               .Build();

            var customer = this.InternalOrganisation.ActiveCustomers.First;
            customer.Locale = swedishLocale;

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.Locale, swedishLocale);
        }

        [Fact]
        public void OnCreateDeriveLocaleFromsingletonDefaultLocale()
        {
            var swedishLocale = new LocaleBuilder(this.Session)
               .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "SE"))
               .WithLanguage(new Languages(this.Session).FindBy(this.M.Language.IsoCode, "sv"))
               .Build();

            this.Session.GetSingleton().DefaultLocale = swedishLocale;

            var customer = this.InternalOrganisation.ActiveCustomers.First;
            customer.RemoveLocale();

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer).Build();

            this.Session.Derive(false);

            Assert.False(customer.ExistLocale);
            Assert.Equal(invoice.Locale, swedishLocale);
        }

        [Fact]
        public void OnCreateDerivePaymentDays()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.PaymentDays, int.Parse(invoice.SalesTerms.First(v => v.TermType.UniqueId.Equals(InvoiceTermTypes.PaymentNetDaysId)).TermValue));
        }

        [Fact]
        public void OnCreateDeriveDueDate()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();

            this.Session.Derive(false);

            var paymentDays = invoice.SalesTerms.First(v => v.TermType.UniqueId.Equals(InvoiceTermTypes.PaymentNetDaysId));
            var days = int.Parse(paymentDays.TermValue);

            Assert.Equal(invoice.DueDate, invoice.InvoiceDate.AddDays(days));
        }

        [Fact]
        public void OnCreateDeriveDerivedVatClauseFromVatRegime()
        {
            var intraCommunautair = new VatRegimes(this.Session).IntraCommunautair;
            var invoice = new SalesInvoiceBuilder(this.Session).WithVatRegime(intraCommunautair).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.DerivedVatClause, intraCommunautair.VatClause);
        }

        [Fact]
        public void OnCreateDeriveDerivedVatClauseIsNull()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.Null(invoice.DerivedVatClause);
        }

        [Fact]
        public void OnCreateDeriveDerivedVatClauseFromAssignedVatClause()
        {
            var vatClause = new VatClauses(this.Session).BeArt14Par2;
            var invoice = new SalesInvoiceBuilder(this.Session).WithAssignedVatClause(vatClause).Build();

            this.Session.Derive(false);

            Assert.Equal(invoice.DerivedVatClause, vatClause);
        }

        [Fact]
        public void OnCreateDeriveCustomers()
        {
            var customer1 = this.InternalOrganisation.ActiveCustomers.First;
            var customer2 = this.InternalOrganisation.ActiveCustomers.Last();

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer1).WithShipToCustomer(customer2).Build();

            this.Session.Derive(false);

            Assert.Equal(2, invoice.Customers.Count);
            Assert.Contains(customer1, invoice.Customers);
            Assert.Contains(customer2, invoice.Customers);
        }

        [Fact]
        public void OnChangedRoleBillToCustomerDerivePreviousBillToCustomer()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            invoice.BillToCustomer = invoice.BilledFrom.ActiveCustomers.First;
            this.Session.Derive(false);

            Assert.Equal(invoice.PreviousBillToCustomer, invoice.BillToCustomer);
        }

        [Fact]
        public void OnChangedRoleBillToCustomerDeriveBillToContactMechanism()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            invoice.BillToCustomer = invoice.BilledFrom.ActiveCustomers.First;
            this.Session.Derive(false);

            Assert.Equal(invoice.BillToContactMechanism, invoice.BillToCustomer.BillingAddress);
        }

        [Fact]
        public void OnChangedRoleBillToEndCustomerDeriveBillToEndCustomerContactMechanism()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            invoice.BillToEndCustomer = invoice.BilledFrom.ActiveCustomers.First;
            this.Session.Derive(false);

            Assert.Equal(invoice.BillToEndCustomerContactMechanism, invoice.BillToEndCustomer.BillingAddress);
        }

        [Fact]
        public void OnChangedRoleShipToCustomerDeriveShipToAddress()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            invoice.ShipToCustomer = invoice.BilledFrom.ActiveCustomers.First;
            this.Session.Derive(false);

            Assert.Equal(invoice.ShipToAddress, invoice.ShipToCustomer.ShippingAddress);
        }

        [Fact]
        public void OnChangedRoleShipToEndCustomerDeriveShipToEndCustomerAddress()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            invoice.ShipToEndCustomer = invoice.BilledFrom.ActiveCustomers.First;
            this.Session.Derive(false);

            Assert.Equal(invoice.ShipToEndCustomerAddress, invoice.ShipToEndCustomer.ShippingAddress);
        }

        [Fact]
        public void OnChangedRoleRepeatingSalesInvoiceNextExecutionDateDeriveIsRepeatingInvoice()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();

            this.Session.Derive();

            new RepeatingSalesInvoiceBuilder(this.Session)
                .WithSource(invoice)
                .WithFrequency(new TimeFrequencies(this.Session).Month)
                .WithNextExecutionDate(this.Session.Now().AddDays(1))
                .Build();

            this.Session.Derive();

            Assert.True(invoice.IsRepeatingInvoice);
        }

        [Fact]
        public void OnChangedRoleRepeatingSalesInvoiceFinalExecutionDateDeriveIsRepeatingInvoice()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();

            this.Session.Derive();

            var repeatingSalesInvoice = new RepeatingSalesInvoiceBuilder(this.Session)
                .WithSource(invoice)
                .WithFrequency(new TimeFrequencies(this.Session).Month)
                .WithNextExecutionDate(this.Session.Now().AddDays(-1))
                .Build();

            this.Session.Derive();

            Assert.True(invoice.IsRepeatingInvoice);

            repeatingSalesInvoice.FinalExecutionDate = this.Session.Now().AddDays(-1);

            this.Session.Derive();

            Assert.False(invoice.IsRepeatingInvoice);
        }

        [Fact]
        public void OnChangedRoleOrderItemBillingInvoiceItemDeriveSalesOrders()
        {
            this.InternalOrganisation.StoresWhereInternalOrganisation.First.BillingProcess = new BillingProcesses(this.Session).BillingForOrderItems;

            var salesOrder = new SalesOrderBuilder(this.Session).WithOrganisationExternalDefaults(this.InternalOrganisation).Build();
            this.Session.Derive();

            salesOrder.SetReadyForPosting();
            this.Session.Derive();

            salesOrder.Post();
            this.Session.Derive();

            salesOrder.Accept();
            this.Session.Derive();

            salesOrder.Invoice();
            this.Session.Derive();

            var invoice = salesOrder.SalesInvoicesWhereSalesOrder.First;

            Assert.Single(invoice.SalesOrders);
        }

        [Fact]
        public void OnChangedRoleWorkEffortBillingInvoiceItemDeriveWorkEfforts()
        {
            var workTask = new WorkTaskBuilder(this.Session).WithScheduledWorkForExternalCustomer(this.InternalOrganisation).Build();
            this.Session.Derive();

            //// Work Effort Inventory Assignmets
            var part = new NonUnifiedPartBuilder(this.Session)
                .WithProductIdentification(new PartNumberBuilder(this.Session)
                .WithIdentification("Part")
                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                .Build();

            this.Session.Derive(true);

            new InventoryItemTransactionBuilder(this.Session)
                .WithPart(part)
                .WithReason(new InventoryTransactionReasons(this.Session).IncomingShipment)
                .WithQuantity(1)
                .Build();

            this.Session.Derive();

            new WorkEffortInventoryAssignmentBuilder(this.Session)
                .WithAssignment(workTask)
                .WithInventoryItem(part.InventoryItemsWherePart.First)
                .WithQuantity(1)
                .Build();

            workTask.Complete();
            this.Session.Derive();

            workTask.Invoice();
            this.Session.Derive();

            var invoice = workTask.SalesInvoicesWhereWorkEffort.First;

            Assert.Single(invoice.WorkEfforts);
        }

        [Fact]
        public void OnChangedRoleTimeEntryBillingInvoiceItemDeriveWorkEfforts()
        {
            var employee = new PersonBuilder(this.Session).WithFirstName("Good").WithLastName("Worker").Build();
            new EmploymentBuilder(this.Session).WithEmployee(employee).WithEmployer(this.InternalOrganisation).Build();
            this.Session.Derive();

            var workTask = new WorkTaskBuilder(this.Session).WithScheduledWorkForExternalCustomer(this.InternalOrganisation).Build();
            this.Session.Derive();

            var yesterday = DateTimeFactory.CreateDateTime(this.Session.Now().AddDays(-1));
            var laterYesterday = DateTimeFactory.CreateDateTime(yesterday.AddHours(3));

            var timeEntry = new TimeEntryBuilder(this.Session)
                .WithRateType(new RateTypes(this.Session).StandardRate)
                .WithFromDate(yesterday)
                .WithThroughDate(laterYesterday)
                .WithTimeFrequency(new TimeFrequencies(this.Session).Day)
                .WithWorkEffort(workTask)
                .Build();

            employee.TimeSheetWhereWorker.AddTimeEntry(timeEntry);

            this.Session.Derive();

            workTask.Complete();
            this.Session.Derive();

            workTask.Invoice();
            this.Session.Derive();

            var invoice = workTask.SalesInvoicesWhereWorkEffort.First;

            Assert.Single(invoice.WorkEfforts);
        }

        [Fact]
        public void OnChangedRoleInvoiceTermTermValueDerivePaymentDays()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();

            this.Session.Derive(false);

            var paymentDays = invoice.SalesTerms.First(v => v.TermType.UniqueId.Equals(InvoiceTermTypes.PaymentNetDaysId));
            var oldValue = int.Parse(paymentDays.TermValue);
            var newValue = ++oldValue;
            paymentDays.TermValue = newValue.ToString();

            this.Session.Derive(false);

            Assert.Equal(invoice.PaymentDays, newValue);
        }

        [Fact]
        public void OnChangedRoleInvoiceTermTermValueDeriveDueDate()
        {
            var invoice = new SalesInvoiceBuilder(this.Session).WithSalesExternalB2BInvoiceDefaults(this.InternalOrganisation).Build();

            this.Session.Derive(false);

            var paymentDays = invoice.SalesTerms.First(v => v.TermType.UniqueId.Equals(InvoiceTermTypes.PaymentNetDaysId));
            var oldValue = int.Parse(paymentDays.TermValue);
            var newValue = ++oldValue;
            paymentDays.TermValue = newValue.ToString();

            this.Session.Derive(false);

            Assert.Equal(invoice.DueDate, invoice.InvoiceDate.AddDays(newValue));
        }

        [Fact]
        public void OnChangedRoleVatRegimeDeriveDerivedVatClause()
        {
            var intraCommunautair = new VatRegimes(this.Session).IntraCommunautair;
            var assessable9 = new VatRegimes(this.Session).Assessable9;

            var invoice = new SalesInvoiceBuilder(this.Session).Build();
            invoice.VatRegime = assessable9;
            this.Session.Derive(false);

            invoice.VatRegime = intraCommunautair;
            this.Session.Derive(false);

            Assert.Equal(invoice.DerivedVatClause, intraCommunautair.VatClause);
        }

        [Fact]
        public void OnChangedRoleAssignedVatClauseDeriveDerivedVatClause()
        {
            var vatClause = new VatClauses(this.Session).BeArt14Par2;
            var invoice = new SalesInvoiceBuilder(this.Session).Build();

            this.Session.Derive(false);

            invoice.AssignedVatClause = vatClause;
            this.Session.Derive(false);

            Assert.Equal(invoice.DerivedVatClause, vatClause);
        }

        [Fact]
        public void OnChangedRoleBillToCustomerDeriveCustomers()
        {
            var customer1 = this.InternalOrganisation.ActiveCustomers.First;
            var customer2 = this.InternalOrganisation.ActiveCustomers.Last();

            var invoice = new SalesInvoiceBuilder(this.Session).WithBillToCustomer(customer1).Build();

            this.Session.Derive(false);

            invoice.BillToCustomer = customer2;
            this.Session.Derive(false);

            Assert.Single(invoice.Customers);
            Assert.Contains(customer2, invoice.Customers);
        }

        [Fact]
        public void OnChangedRoleShipToCustomerDeriveCustomers()
        {
            var customer1 = this.InternalOrganisation.ActiveCustomers.First;
            var customer2 = this.InternalOrganisation.ActiveCustomers.Last();

            var invoice = new SalesInvoiceBuilder(this.Session).WithShipToCustomer(customer1).Build();

            this.Session.Derive(false);

            invoice.ShipToCustomer = customer2;
            this.Session.Derive(false);

            Assert.Single(invoice.Customers);
            Assert.Contains(customer2, invoice.Customers);
        }
    }

    [Trait("Category", "Security")]
    public class SalesInvoiceSecurityTests : DomainTest, IClassFixture<Fixture>
    {
        public SalesInvoiceSecurityTests(Fixture fixture) : base(fixture) { }

        public override Config Config => new Config { SetupSecurity = true };

        [Fact]
        public void GivenSalesInvoice_WhenObjectStateIsReadyForPosting_ThenCheckTransitions()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            this.Session.Derive();
            this.Session.Commit();

            User user = this.Administrator;
            this.Session.SetUser(user);

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();
            this.Session.Commit();

            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[invoice];
            Assert.True(acl.CanExecute(this.M.SalesInvoice.Send));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.WriteOff));
            Assert.True(acl.CanExecute(this.M.SalesInvoice.CancelInvoice));
            Assert.True(acl.CanExecute(this.M.SalesInvoice.Delete));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.SetPaid));
        }

        [Fact]
        public void GivenSalesInvoice_WhenObjectStateIsNotPaid_ThenCheckTransitions()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            this.Session.Derive();
            this.Session.Commit();

            User user = this.Administrator;
            this.Session.SetUser(user);

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(1000M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            invoice.Send();

            this.Session.Derive();
            this.Session.Commit();

            Assert.Equal(new SalesInvoiceStates(this.Session).NotPaid, invoice.SalesInvoiceState);

            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[invoice];
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Send));
            Assert.True(acl.CanExecute(this.M.SalesInvoice.WriteOff));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.CancelInvoice));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Delete));
            Assert.True(acl.CanExecute(this.M.SalesInvoice.SetPaid));
        }

        ////[Fact]
        ////public void GivenSalesInvoice_WhenObjectStateIsReceived_ThenCheckTransitions()
        ////{
        ////    SecurityPopulation securityPopulation = new SecurityPopulation(this.Session);
        ////    securityPopulation.CoreCreateUserGroups();
        ////    securityPopulation.CoreAssignDefaultPermissions();
        ////    new Invoices(this.Session).Populate();
        ////    new SalesInvoices(this.Session).Populate();

        ////    Person administrator = new PersonBuilder(this.Session).WithUserName("administrator").Build();
        ////    securityPopulation.CoreAdministrators.AddMember(administrator);

        ////    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("administrator", "Forms"), new string[0]);
        ////    SalesInvoice invoice = new SalesInvoiceBuilder(this.Session)
        ////        .WithInvoiceStatus(new InvoiceStatusBuilder(this.Session).WithObjectState(new Invoices(this.Session).Received).Build())
        ////        .Build();

        ////    AccessControlList acl = new AccessControlList(invoice, this.Session.GetUser()());
        ////    Assert.False(acl.CanExecute(Invoices.ReadyForPostingId));
        ////    Assert.False(acl.CanExecute(Invoices.ApproveId));
        ////    Assert.False(acl.CanExecute(Invoices.SendId));
        ////    Assert.False(acl.CanExecute(Invoices.WriteOffId));
        ////    Assert.False(acl.CanExecute(Invoices.CancelId));
        ////}

        [Fact]
        public void GivenSalesInvoice_WhenObjectStateIsPaid_ThenCheckTransitions()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            this.Session.Derive();
            this.Session.Commit();

            User user = this.Administrator;
            this.Session.SetUser(user);

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            invoice.Send();

            this.Session.Derive();

            var invoiceItem = invoice.SalesInvoiceItems[0];
            var value = invoiceItem.TotalIncVat;

            new ReceiptBuilder(this.Session)
                .WithAmount(value)
                .WithPaymentApplication(new PaymentApplicationBuilder(this.Session).WithInvoiceItem(invoiceItem).WithAmountApplied(value).Build())
                .Build();

            this.Session.Derive();

            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[invoice];

            Assert.Equal(new SalesInvoiceStates(this.Session).Paid, invoice.SalesInvoiceState);
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Send));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.WriteOff));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.CancelInvoice));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Delete));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.SetPaid));
        }

        [Fact]
        public void GivenSalesInvoice_WhenObjectStateIsPartiallyPaid_ThenCheckTransitions()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            var good = new Goods(this.Session).FindBy(this.M.Good.Name, "good1");

            this.Session.Derive();
            this.Session.Commit();

            User user = this.Administrator;
            this.Session.SetUser(user);

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithAssignedUnitPrice(100M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            new ReceiptBuilder(this.Session)
                .WithAmount(90)
                .WithPaymentApplication(new PaymentApplicationBuilder(this.Session).WithInvoiceItem(invoice.SalesInvoiceItems[0]).WithAmountApplied(90).Build())
                .Build();

            this.Session.Derive();
            this.Session.Commit();

            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[invoice];
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Send));
            Assert.True(acl.CanExecute(this.M.SalesInvoice.WriteOff));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.CancelInvoice));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Delete));
            Assert.True(acl.CanExecute(this.M.SalesInvoice.SetPaid));
        }

        [Fact]
        public void GivenSalesInvoice_WhenObjectStateIsWrittenOff_ThenCheckTransitions()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            this.Session.Derive();
            this.Session.Commit();

            User user = this.Administrator;
            this.Session.SetUser(user);

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            this.Session.Derive();

            invoice.Send();
            invoice.WriteOff();

            this.Session.Derive();

            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[invoice];
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Send));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.WriteOff));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.CancelInvoice));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Delete));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.SetPaid));
        }

        [Fact]
        public void GivenSalesInvoice_WhenObjectStateIsCancelled_ThenCheckTransitions()
        {
            var customer = new OrganisationBuilder(this.Session).WithName("customer").Build();
            var contactMechanism = new PostalAddressBuilder(this.Session)
                .WithAddress1("Haverwerf 15")
                .WithLocality("Mechelen")
                .WithCountry(new Countries(this.Session).FindBy(this.M.Country.IsoCode, "BE"))
                .Build();

            this.Session.Derive();
            this.Session.Commit();

            User user = this.Administrator;
            this.Session.SetUser(user);

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .Build();

            new CustomerRelationshipBuilder(this.Session).WithFromDate(this.Session.Now()).WithCustomer(customer).Build();

            invoice.CancelInvoice();

            this.Session.Derive();

            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[invoice];
            Assert.Equal(new SalesInvoiceStates(this.Session).Cancelled, invoice.SalesInvoiceState);
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Send));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.WriteOff));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.CancelInvoice));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.Delete));
            Assert.False(acl.CanExecute(this.M.SalesInvoice.SetPaid));
        }
    }
}