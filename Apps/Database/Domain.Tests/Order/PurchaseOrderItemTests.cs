// <copyright file="PurchaseOrderItemTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using System.Collections.Generic;
    using TestPopulation;
    using Database.Derivations;
    using Resources;
    using Xunit;

    public class PurchaseOrderItemTests : DomainTest, IClassFixture<Fixture>
    {
        private Part finishedGood;
        private SupplierOffering currentPurchasePrice;
        private PurchaseOrder order;
        private Organisation supplier;

        public PurchaseOrderItemTests(Fixture fixture) : base(fixture)
        {
            var euro = new Currencies(this.Session).FindBy(this.M.Currency.IsoCode, "EUR");

            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            ContactMechanism takenViaContactMechanism = new PostalAddressBuilder(this.Session).WithPostalAddressBoundary(mechelen).WithAddress1("Haverwerf 15").Build();

            var supplierContactMechanism = new PartyContactMechanismBuilder(this.Session)
                .WithContactMechanism(takenViaContactMechanism)
                .WithUseAsDefault(true)
                .WithContactPurpose(new ContactMechanismPurposes(this.Session).BillingAddress)
                .Build();

            this.supplier = new OrganisationBuilder(this.Session).WithName("supplier").Build();
            this.supplier.AddPartyContactMechanism(supplierContactMechanism);

            new SupplierRelationshipBuilder(this.Session).WithSupplier(this.supplier).Build();

            var good1 = new NonUnifiedGoods(this.Session).FindBy(this.M.Good.Name, "good1");
            this.finishedGood = good1.Part;

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now().AddYears(-1))
                .WithThroughDate(this.Session.Now().AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            this.currentPurchasePrice = new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now())
                .WithThroughDate(this.Session.Now().AddYears(1).AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(10)
                .Build();

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now().AddYears(1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            this.order = new PurchaseOrderBuilder(this.Session)
                .WithTakenViaSupplier(this.supplier)
                .WithAssignedBillToContactMechanism(takenViaContactMechanism)
                .WithDeliveryDate(this.Session.Now())
                .WithAssignedVatRegime(new VatRegimes(this.Session).Exempt)
                .WithAssignedIrpfRegime(new IrpfRegimes(this.Session).Assessable19)
                .Build();

            this.Session.Derive();
            this.Session.Commit();
        }

        [Fact]
        public void GivenOrderItemForSubcontractingWork_WhenDerived_ThenOrderQuantityMustBeEqualTo1()
        {
            this.InstantiateObjects(this.Session);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithDescription("Do Something")
                .WithQuantityOrdered(0)
                .WithAssignedUnitPrice(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            var expectedErrorMessage = ErrorMessages.InvalidQuantity;

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Single(errors.FindAll(e => e.Message.Equals(expectedErrorMessage)));

            this.Session.Rollback();

            item = new PurchaseOrderItemBuilder(this.Session)
                .WithDescription("Do Something")
                .WithQuantityOrdered(2)
                .WithAssignedUnitPrice(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Single(errors.FindAll(e => e.Message.Equals(expectedErrorMessage)));

            this.Session.Rollback();

            item = new PurchaseOrderItemBuilder(this.Session)
                .WithDescription("Do Something")
                .WithInvoiceItemType(new InvoiceItemTypes(this.Session).Service)
                .WithQuantityOrdered(1)
                .WithAssignedUnitPrice(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenOrderItemForSerialisedPart_WhenDerived_ThenOrderQuantityMustBeEqualTo1()
        {
            this.InstantiateObjects(this.Session);

            var serialisedPart = new UnifiedGoodBuilder(this.Session).WithSerialisedDefaults(this.InternalOrganisation).Build();

            this.Session.Derive();
            this.Session.Commit();

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(serialisedPart)
                .WithSerialNumber("1")
                .WithQuantityOrdered(0)
                .WithAssignedUnitPrice(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            var expectedErrorMessage = ErrorMessages.InvalidQuantity;

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Single(errors.FindAll(e => e.Message.Equals(expectedErrorMessage)));

            this.Session.Rollback();

            item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(serialisedPart)
                .WithSerialNumber("1")
                .WithQuantityOrdered(2)
                .WithAssignedUnitPrice(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Single(errors.FindAll(e => e.Message.Equals(expectedErrorMessage)));

            this.Session.Rollback();

            item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(serialisedPart)
                .WithAssignedUnitPrice(1)
                .WithQuantityOrdered(1)
                .WithSerialNumber("1")
                .Build();

            this.order.AddPurchaseOrderItem(item);

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenOrderItemForNonSerialisedPart_WhenDerived_ThenOrderQuantityMustBeGreaterEqual1()
        {
            this.InstantiateObjects(this.Session);

            var nonSerialisedPart = new UnifiedGoodBuilder(this.Session).WithNonSerialisedDefaults(this.InternalOrganisation).Build();

            this.Session.Derive();
            this.Session.Commit();

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(nonSerialisedPart)
                .WithQuantityOrdered(0)
                .WithAssignedUnitPrice(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            var expectedErrorMessage = ErrorMessages.InvalidQuantity;

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Single(errors.FindAll(e => e.Message.Equals(expectedErrorMessage)));

            this.Session.Rollback();

            item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(nonSerialisedPart)
                .WithQuantityOrdered(2)
                .WithAssignedUnitPrice(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            Assert.False(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(nonSerialisedPart)
                .WithAssignedUnitPrice(1)
                .WithQuantityOrdered(2)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenConfirmedOrderItemForGood_WhenOrderItemIsRemoved_ThenItemIsRemovedFromValidOrderItems()
        {
            this.InstantiateObjects(this.Session);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            this.order.SetReadyForProcessing();
            this.Session.Derive();

            Assert.Single(this.order.ValidOrderItems);

            item.Cancel();

            this.Session.Derive();

            Assert.Empty(this.order.ValidOrderItems);
        }

        [Fact]
        public void GivenOrderItemForPart_WhenDerivingPrices_ThenUsePartCurrentPurchasePrice()
        {
            this.InstantiateObjects(this.Session);

            const decimal QuantityOrdered = 3;
            var item1 = new PurchaseOrderItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantityOrdered(QuantityOrdered).Build();
            this.order.AddPurchaseOrderItem(item1);

            this.Session.Derive();

            Assert.Equal(this.currentPurchasePrice.Price, item1.UnitBasePrice);
            Assert.Equal(0, item1.UnitDiscount);
            Assert.Equal(0, item1.UnitSurcharge);
            Assert.Equal(this.currentPurchasePrice.Price, item1.UnitPrice);

            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, item1.TotalBasePrice);
            Assert.Equal(0, item1.TotalDiscount);
            Assert.Equal(0, item1.TotalSurcharge);
            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, item1.TotalExVat);

            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, this.order.TotalBasePrice);
            Assert.Equal(0, this.order.TotalDiscount);
            Assert.Equal(0, this.order.TotalSurcharge);
            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, this.order.TotalExVat);
        }

        [Fact]
        public void GivenOrderItemForProduct_WhenDerivingPrices_ThenUseProductCurrentPurchasePrice()
        {
            var euro = new Currencies(this.Session).FindBy(this.M.Currency.IsoCode, "EUR");

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now().AddYears(-1))
                .WithThroughDate(this.Session.Now().AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            var currentOffer = new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now().AddMinutes(-1))
                .WithThroughDate(this.Session.Now().AddYears(1).AddDays(-1))
                .WithPrice(10)
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .Build();

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now().AddYears(1))
                .WithPrice(8)
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .Build();

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            const decimal QuantityOrdered = 3;
            var item1 = new PurchaseOrderItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantityOrdered(QuantityOrdered).Build();
            this.order.AddPurchaseOrderItem(item1);

            this.Session.Derive();

            Assert.Equal(currentOffer.Price, item1.UnitBasePrice);
            Assert.Equal(0, item1.UnitDiscount);
            Assert.Equal(0, item1.UnitSurcharge);
            Assert.Equal(currentOffer.Price, item1.UnitPrice);

            Assert.Equal(currentOffer.Price * QuantityOrdered, item1.TotalBasePrice);
            Assert.Equal(0, item1.TotalDiscount);
            Assert.Equal(0, item1.TotalSurcharge);
            Assert.Equal(currentOffer.Price * QuantityOrdered, item1.TotalExVat);

            Assert.Equal(currentOffer.Price * QuantityOrdered, this.order.TotalBasePrice);
            Assert.Equal(0, this.order.TotalDiscount);
            Assert.Equal(0, this.order.TotalSurcharge);
            Assert.Equal(currentOffer.Price * QuantityOrdered, this.order.TotalExVat);
        }

        [Fact]
        public void GivenOrderItemForPartWithActualPrice_WhenDerivingPrices_ThenUseActualPrice()
        {
            this.InstantiateObjects(this.Session);

            var item1 = new PurchaseOrderItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantityOrdered(3).WithAssignedUnitPrice(15).Build();
            this.order.AddPurchaseOrderItem(item1);

            this.Session.Derive();

            Assert.Equal(15, item1.UnitBasePrice);
            Assert.Equal(0, item1.UnitDiscount);
            Assert.Equal(0, item1.UnitSurcharge);
            Assert.Equal(15, item1.UnitPrice);
            Assert.Equal(0, item1.UnitVat);
            Assert.Equal(45, item1.TotalBasePrice);
            Assert.Equal(0, item1.TotalDiscount);
            Assert.Equal(0, item1.TotalSurcharge);
            Assert.Equal(45, item1.TotalExVat);
            Assert.Equal(0, item1.TotalVat);
            Assert.Equal(45, item1.TotalIncVat);
            Assert.Equal(2.85M, item1.UnitIrpf);

            Assert.Equal(45, this.order.TotalBasePrice);
            Assert.Equal(0, this.order.TotalDiscount);
            Assert.Equal(0, this.order.TotalSurcharge);
            Assert.Equal(45, this.order.TotalExVat);
            Assert.Equal(0, this.order.TotalVat);
            Assert.Equal(45, this.order.TotalIncVat);
            Assert.Equal(8.55M, this.order.TotalIrpf);
            Assert.Equal(36.45M, this.order.GrandTotal);
        }

        [Fact]
        public void GivenOrderItemWithAssignedDeliveryDate_WhenDeriving_ThenDeliveryDateIsOrderItemAssignedDeliveryDate()
        {
            this.InstantiateObjects(this.Session);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(1)
                .WithAssignedDeliveryDate(this.Session.Now().AddMonths(1))
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            Assert.Equal(item.DerivedDeliveryDate, item.AssignedDeliveryDate);
        }

        [Fact]
        public void GivenOrderItemWithoutDeliveryDate_WhenDeriving_ThenDerivedDeliveryDateIsOrderDeliveryDate()
        {
            this.InstantiateObjects(this.Session);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            Assert.Equal(item.DerivedDeliveryDate, this.order.DeliveryDate);
        }

        private void InstantiateObjects(ISession session)
        {
            this.finishedGood = (Part)session.Instantiate(this.finishedGood);
            this.currentPurchasePrice = (SupplierOffering)session.Instantiate(this.currentPurchasePrice);
            this.order = (PurchaseOrder)session.Instantiate(this.order);
            this.supplier = (Organisation)session.Instantiate(this.supplier);
        }
    }

    public class PurchaseOrderItemOnBuildTests : DomainTest, IClassFixture<Fixture>
    {
        public PurchaseOrderItemOnBuildTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void DerivePurchaseOrderItemState()
        {
            var orderItem = new PurchaseOrderItemBuilder(this.Session).Build();
            this.Session.Derive(false);

            Assert.True(orderItem.ExistPurchaseOrderItemState);
        }

        [Fact]
        public void DerivePurchaseOrderItemPaymentState()
        {
            var orderItem = new PurchaseOrderItemBuilder(this.Session).Build();
            this.Session.Derive(false);

            Assert.True(orderItem.ExistPurchaseOrderItemPaymentState);
        }

        [Fact]
        public void DeriveInvoiceItemType()
        {
            var orderItem = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(new UnifiedGoodBuilder(this.Session).Build())
                .Build();

            this.Session.Derive(false);

            Assert.True(orderItem.ExistInvoiceItemType);
        }
    }

    public class PurchaseOrderItemCreatedDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public PurchaseOrderItemCreatedDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedAssignedDeliveryDateDeriveDerivedDeliveryDate()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).WithAssignedDeliveryDate(this.Session.Now().Date).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            Assert.Equal(orderItem.DerivedDeliveryDate, orderItem.AssignedDeliveryDate);
        }

        [Fact]
        public void ChangedsalesOrderDerivedDeliveryDateDeriveDerivedDeliveryDate()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            order.DeliveryDate = this.Session.Now().Date;
            this.Session.Derive(false);

            Assert.Equal(orderItem.DerivedDeliveryDate, order.DeliveryDate);
        }

        [Fact]
        public void ChangedAssignedVatRegimeDeriveDerivedVatRegime()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).WithAssignedVatRegime(new VatRegimes(this.Session).Assessable10).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            Assert.Equal(orderItem.DerivedVatRegime, orderItem.AssignedVatRegime);
        }

        [Fact]
        public void ChangedsalesOrderDerivedVatRegimeDeriveDerivedVatRegime()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            order.AssignedVatRegime = new VatRegimes(this.Session).Assessable10;
            this.Session.Derive(false);

            Assert.Equal(orderItem.DerivedVatRegime, order.AssignedVatRegime);
        }

        [Fact]
        public void ChangedDerivedVatRegimeDeriveVatRate()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            order.AssignedVatRegime = new VatRegimes(this.Session).Assessable10;
            this.Session.Derive(false);

            Assert.Equal(orderItem.VatRate, order.AssignedVatRegime.VatRate);
        }

        [Fact]
        public void ChangedAssignedIrpfRegimeDeriveDerivedIrpfRegime()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).WithAssignedIrpfRegime(new IrpfRegimes(this.Session).Assessable15).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            Assert.Equal(orderItem.DerivedIrpfRegime, orderItem.AssignedIrpfRegime);
        }

        [Fact]
        public void ChangedsalesOrderDerivedIrpfRegimeDeriveDerivedIrpfRegime()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            order.AssignedIrpfRegime = new IrpfRegimes(this.Session).Assessable15;
            this.Session.Derive(false);

            Assert.Equal(orderItem.DerivedIrpfRegime, order.AssignedIrpfRegime);
        }

        [Fact]
        public void ChangedDerivedIrpfRegimeDeriveIrpfRate()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            order.AssignedIrpfRegime = new IrpfRegimes(this.Session).Assessable15;
            this.Session.Derive(false);

            Assert.Equal(orderItem.IrpfRate, order.AssignedIrpfRegime.IrpfRate);
        }
    }

    public class PurchaseOrderItemDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public PurchaseOrderItemDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedAssignedDeliveryDateDeriveDerivedDeliveryDate()
        {
            var order = new PurchaseOrderBuilder(this.Session).Build();
            this.Session.Derive(false);

            var orderItem = new PurchaseOrderItemBuilder(this.Session).WithAssignedDeliveryDate(this.Session.Now().Date).Build();
            order.AddPurchaseOrderItem(orderItem);
            this.Session.Derive(false);

            Assert.Equal(orderItem.DerivedDeliveryDate, orderItem.AssignedDeliveryDate);
        }
    }

    [Trait("Category", "Security")]
    public class PurchaseOrderItemSecurityTests : DomainTest, IClassFixture<Fixture>
    {
        private Part finishedGood;
        private SupplierOffering currentPurchasePrice;
        private PurchaseOrder order;
        private Organisation supplier;

        public PurchaseOrderItemSecurityTests(Fixture fixture) : base(fixture)
        {
            var euro = new Currencies(this.Session).FindBy(this.M.Currency.IsoCode, "EUR");

            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            ContactMechanism takenViaContactMechanism = new PostalAddressBuilder(this.Session).WithPostalAddressBoundary(mechelen).WithAddress1("Haverwerf 15").Build();

            var supplierContactMechanism = new PartyContactMechanismBuilder(this.Session)
                .WithContactMechanism(takenViaContactMechanism)
                .WithUseAsDefault(true)
                .WithContactPurpose(new ContactMechanismPurposes(this.Session).BillingAddress)
                .Build();

            this.supplier = new OrganisationBuilder(this.Session).WithName("supplier").Build();
            this.supplier.AddPartyContactMechanism(supplierContactMechanism);

            new SupplierRelationshipBuilder(this.Session).WithSupplier(this.supplier).Build();

            var good1 = new NonUnifiedGoods(this.Session).FindBy(this.M.Good.Name, "good1");
            this.finishedGood = good1.Part;

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now().AddYears(-1))
                .WithThroughDate(this.Session.Now().AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            this.currentPurchasePrice = new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now())
                .WithThroughDate(this.Session.Now().AddYears(1).AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(10)
                .Build();

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(this.Session.Now().AddYears(1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            this.order = new PurchaseOrderBuilder(this.Session)
                .WithTakenViaSupplier(this.supplier)
                .WithAssignedBillToContactMechanism(takenViaContactMechanism)
                .WithDeliveryDate(this.Session.Now())
                .WithAssignedVatRegime(new VatRegimes(this.Session).Exempt)
                .Build();

            this.Session.Derive();
            this.Session.Commit();
        }

        public override Config Config => new Config { SetupSecurity = true };

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsCreated_ThenItemMayBeDeletedButNotCancelledOrRejected()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();
            this.Session.Commit();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Created, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];

            Assert.True(acl.CanExecute(this.M.PurchaseOrderItem.Delete));
            Assert.True(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.True(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsSetReadyForProcessing_ThenItemMayBeCancelledOrRejected()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.SetReadyForProcessing();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).InProcess, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsPartiallyReceived_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(20)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.SetReadyForProcessing();

            this.Session.Derive();

            var shipment = new PurchaseShipmentBuilder(this.Session).WithShipmentMethod(new ShipmentMethods(this.Session).Ground).WithShipFromParty(this.order.TakenViaSupplier).Build();
            this.Session.Derive();

            var shipmentItem = new ShipmentItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantity(10).WithUnitPurchasePrice(1).Build();
            shipment.AddShipmentItem(shipmentItem);
            this.Session.Derive();

            new ShipmentReceiptBuilder(this.Session)
                .WithQuantityAccepted(3)
                .WithShipmentItem(shipmentItem)
                .WithOrderItem(item)
                .WithFacility(shipmentItem.StoredInFacility)
                .Build();

            this.Session.Derive();

            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];

            Assert.Equal(new PurchaseOrderItemShipmentStates(this.Session).PartiallyReceived, item.PurchaseOrderItemShipmentState);
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsCancelled_ThenItemMayNotBeCancelledOrRejected()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();
            this.Session.Commit();

            item.Cancel();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Cancelled, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsCancelled_ThenItemCanBeDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();
            this.Session.Commit();

            item.Cancel();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Cancelled, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.True(acl.CanExecute(this.M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsRejected_ThenItemMayNotBeCancelledOrRejected()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            item.Reject();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Rejected, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsRejected_ThenItemCanBeDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            item.Reject();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Rejected, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.True(acl.CanExecute(this.M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsCompleted_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.SetReadyForProcessing();
            this.Session.Derive();

            this.order.QuickReceive();
            this.Session.Derive();

            var shipment = (PurchaseShipment)item.OrderShipmentsWhereOrderItem.First.ShipmentItem.ShipmentWhereShipmentItem;
            shipment.Receive();
            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Completed, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectShipmentStateIsReceived_ThenReceiveIsNotAllowed()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.SetReadyForProcessing();
            this.Session.Derive();

            this.order.QuickReceive();
            this.Session.Derive();

            var shipment = (PurchaseShipment)item.OrderShipmentsWhereOrderItem.First.ShipmentItem.ShipmentWhereShipmentItem;
            shipment.Receive();
            this.Session.Derive();

            Assert.True(item.PurchaseOrderItemShipmentState.IsReceived);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.QuickReceive));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsFinished_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            this.order.PurchaseOrderState = new PurchaseOrderStates(this.Session).Finished;

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Finished, item.PurchaseOrderItemState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(this.M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsPartiallyReceived_ThenProductChangeIsNotAllowed()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            User user = this.Administrator;
            this.Session.SetUser(user);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(10)
                .WithAssignedUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.SetReadyForProcessing();
            this.Session.Derive();

            var shipment = new PurchaseShipmentBuilder(this.Session).WithShipmentMethod(new ShipmentMethods(this.Session).Ground).WithShipFromParty(this.order.TakenViaSupplier).Build();
            this.Session.Derive();

            var shipmentItem = new ShipmentItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantity(10).WithUnitPurchasePrice(1).Build();
            shipment.AddShipmentItem(shipmentItem);
            this.Session.Derive();

            new ShipmentReceiptBuilder(this.Session)
                .WithQuantityAccepted(3)
                .WithShipmentItem(shipmentItem)
                .WithOrderItem(item)
                .WithFacility(shipmentItem.StoredInFacility)
                .Build();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemShipmentStates(this.Session).PartiallyReceived, item.PurchaseOrderItemShipmentState);
            var acl = new DatabaseAccessControlLists(this.Session.GetUser())[item];
            Assert.False(acl.CanWrite(this.M.PurchaseOrderItem.Part));
        }

        private void InstantiateObjects(ISession session)
        {
            this.finishedGood = (Part)session.Instantiate(this.finishedGood);
            this.currentPurchasePrice = (SupplierOffering)session.Instantiate(this.currentPurchasePrice);
            this.order = (PurchaseOrder)session.Instantiate(this.order);
            this.supplier = (Organisation)session.Instantiate(this.supplier);
        }
    }

    [Trait("Category", "Security")]
    public class PurchaseOrderItemDeniedPermissonDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public PurchaseOrderItemDeniedPermissonDerivationTests(Fixture fixture) : base(fixture) => this.deletePermission = new Permissions(this.Session).Get(this.M.PurchaseOrderItem.ObjectType, this.M.PurchaseOrderItem.Delete);

        public override Config Config => new Config { SetupSecurity = true };

        private readonly Permission deletePermission;

        [Fact]
        public void OnChangedPurchaseOrderItemStateCreatedDeriveDeletePermission()
        {
            //TODO Is order nodig?
            var purchaseOrder = new PurchaseOrderBuilder(this.Session).WithTakenViaSupplier(this.InternalOrganisation).Build();
            this.Session.Derive(false);

            var purchaseOrderItem = new PurchaseOrderItemBuilder(this.Session).Build();

            purchaseOrder.AddPurchaseOrderItem(purchaseOrderItem);
            this.Session.Derive(false);

            Assert.DoesNotContain(this.deletePermission, purchaseOrderItem.DeniedPermissions);
        }

        [Fact]
        public void OnChangedPurchaseOrderItemStateApprovedDeriveDeletePermission()
        {
            //TODO Is order nodig?
            var purchaseOrder = new PurchaseOrderBuilder(this.Session).WithTakenViaSupplier(this.InternalOrganisation).Build();
            this.Session.Derive(false);

            var purchaseOrderItem = new PurchaseOrderItemBuilder(this.Session).Build();

            purchaseOrder.AddPurchaseOrderItem(purchaseOrderItem);
            this.Session.Derive(false);

            purchaseOrderItem.Approve();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, purchaseOrderItem.DeniedPermissions);
        }

        [Fact]
        public void OnChangedPurchaseOrderItemStateCreatedWithOrderItemBillingDeriveDeletePermission()
        {
            var purchaseOrder = new PurchaseOrderBuilder(this.Session).WithTakenViaSupplier(this.InternalOrganisation).Build();
            this.Session.Derive(false);

            var purchaseOrderItem = new PurchaseOrderItemBuilder(this.Session).Build();

            purchaseOrder.AddPurchaseOrderItem(purchaseOrderItem);
            this.Session.Derive(false);

            new OrderItemBillingBuilder(this.Session).WithOrderItem(purchaseOrderItem).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, purchaseOrderItem.DeniedPermissions);
        }

        [Fact]
        public void OnChangedPurchaseOrderItemStateCreatedWithOrderShipmentDeriveDeletePermission()
        {
            var purchaseOrder = new PurchaseOrderBuilder(this.Session)
                .WithDefaults(this.InternalOrganisation)
                .Build();
            this.Session.Derive(false);

            var part = new NonUnifiedPartBuilder(this.Session).WithNonSerialisedDefaults(this.InternalOrganisation).Build();

            var purchaseOrderItem = new PurchaseOrderItemBuilder(this.Session)
                .WithNonSerializedPartDefaults(part)
                .Build();

            purchaseOrder.AddPurchaseOrderItem(purchaseOrderItem);
            this.Session.Derive(false);

            purchaseOrder.Send();

            this.Session.Derive(false);

            purchaseOrder.QuickReceive();

            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, purchaseOrderItem.DeniedPermissions);
        }

        [Fact]
        public void OnChangedPurchaseOrderItemStateCreatedWithOrderRequirementCommitmentDeriveDeletePermission()
        {
            //TODO Is order nodig?
            var purchaseOrder = new PurchaseOrderBuilder(this.Session).WithTakenViaSupplier(this.InternalOrganisation).Build();
            this.Session.Derive(false);

            var purchaseOrderItem = new PurchaseOrderItemBuilder(this.Session).Build();

            purchaseOrder.AddPurchaseOrderItem(purchaseOrderItem);
            this.Session.Derive(false);

            var orderRequirementCommitment = new OrderRequirementCommitmentBuilder(this.Session)
                .WithOrderItem(purchaseOrderItem).Build();

            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, purchaseOrderItem.DeniedPermissions);
        }

        [Fact]
        public void OnChangedPurchaseOrderItemStateCreatedWithWorkEffortDeriveDeletePermission()
        {
            //TODO Is order nodig?
            var purchaseOrder = new PurchaseOrderBuilder(this.Session).WithTakenViaSupplier(this.InternalOrganisation).Build();
            this.Session.Derive(false);

            var purchaseOrderItem = new PurchaseOrderItemBuilder(this.Session).Build();

            purchaseOrder.AddPurchaseOrderItem(purchaseOrderItem);
            this.Session.Derive(false);

            var workTask = new WorkTaskBuilder(this.Session).WithOrderItemFulfillment(purchaseOrderItem).Build();

            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, purchaseOrderItem.DeniedPermissions);
        }
    }
}
