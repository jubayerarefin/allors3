// <copyright file="QuoteItemTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Database.Derivations;
    using Resources;
    using TestPopulation;
    using Xunit;

    public class QuoteItemTests : DomainTest, IClassFixture<Fixture>
    {
        public QuoteItemTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void GivenSerialisedItem_WhenDerived_ThenSerialisedItemAvailabilityIsChanged()
        {
            var quote = this.InternalOrganisation.CreateB2BProductQuoteWithSerialisedItem(this.Transaction.Faker());

            this.Transaction.Derive();

            var serialisedItem = quote.QuoteItems.First().SerialisedItem;

            Assert.True(serialisedItem.OnQuote);
        }
    }

    public class QuoteItemCreatedDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public QuoteItemCreatedDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedAssignedVatRegimeDeriveDerivedVatRegime()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithAssignedVatRegime(new VatRegimes(this.Transaction).Assessable10).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(quoteItem.DerivedVatRegime, quoteItem.AssignedVatRegime);
        }

        [Fact]
        public void ChangedsalesOrderDerivedVatRegimeDeriveDerivedVatRegime()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quote.AssignedVatRegime = new VatRegimes(this.Transaction).Assessable10;
            this.Transaction.Derive(false);

            Assert.Equal(quoteItem.DerivedVatRegime, quote.AssignedVatRegime);
        }

        [Fact]
        public void ChangedDerivedVatRegimeDeriveVatRate()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quote.AssignedVatRegime = new VatRegimes(this.Transaction).Assessable10;
            this.Transaction.Derive(false);

            Assert.Equal(quoteItem.VatRate, quote.AssignedVatRegime.VatRate);
        }

        [Fact]
        public void ChangedAssignedIrpfRegimeDeriveDerivedIrpfRegime()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithAssignedIrpfRegime(new IrpfRegimes(this.Transaction).Assessable15).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(quoteItem.DerivedIrpfRegime, quoteItem.AssignedIrpfRegime);
        }

        [Fact]
        public void ChangedsalesOrderDerivedIrpfRegimeDeriveDerivedIrpfRegime()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quote.AssignedIrpfRegime = new IrpfRegimes(this.Transaction).Assessable15;
            this.Transaction.Derive(false);

            Assert.Equal(quoteItem.DerivedIrpfRegime, quote.AssignedIrpfRegime);
        }

        [Fact]
        public void ChangedDerivedIrpfRegimeDeriveIrpfRate()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quote.AssignedIrpfRegime = new IrpfRegimes(this.Transaction).Assessable15;
            this.Transaction.Derive(false);

            Assert.Equal(quoteItem.IrpfRate, quote.AssignedIrpfRegime.IrpfRate);
        }

    }

    public class QuoteItemDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public QuoteItemDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedInvoiceItemTypeThrowValidationError()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.InvoiceItemType = new InvoiceItemTypes(this.Transaction).ProductItem;

            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("AssertAtLeastOne: QuoteItem.Product\nQuoteItem.ProductFeature"));
        }

        [Fact]
        public void ChangedProductThrowValidationError()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();
            var productFeature = new ColourBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem)
                .WithProductFeature(productFeature)
                .Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.Product = product;

            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("AssertExistsAtMostOne: QuoteItem.Product\nQuoteItem.ProductFeature"));
        }

        [Fact]
        public void ChangedProductFeatureThrowValidationError()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();
            var productFeature = new ColourBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem)
                .WithProduct(product)
                .Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.ProductFeature = productFeature;

            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("AssertExistsAtMostOne: QuoteItem.Product\nQuoteItem.ProductFeature"));
        }

        [Fact]
        public void ChangedDeliverableThrowValidationError()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();
            var deliverable = new DeliverableBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem)
                .WithProduct(product)
                .Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.Deliverable = deliverable;

            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("AssertExistsAtMostOne: QuoteItem.Product\nQuoteItem.ProductFeature"));
        }

        [Fact]
        public void ChangedWorkEffortThrowValidationError()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();
            var workTask = new WorkTaskBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem)
                .WithProduct(product)
                .Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.WorkEffort = workTask;

            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("AssertExistsAtMostOne: QuoteItem.Product\nQuoteItem.ProductFeature"));
        }

        [Fact]
        public void ChangedSerialisedItemThrowValidationError()
        {
            var serialisedItem = new SerialisedItemBuilder(this.Transaction).Build();
            var workTask = new WorkTaskBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem)
                .WithWorkEffort(workTask)
                .Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.SerialisedItem = serialisedItem;

            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("AssertExistsAtMostOne: QuoteItem.SerialisedItem\nQuoteItem.ProductFeature"));
        }

        [Fact]
        public void ChangedQuantityThrowValidationError()
        {
            var serialisedItem = new SerialisedItemBuilder(this.Transaction).Build();
            var workTask = new WorkTaskBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem)
                .WithSerialisedItem(serialisedItem)
                .Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.Quantity = 2;

            var expectedMessage = $"{quoteItem}, { this.M.QuoteItem.Quantity}, { ErrorMessages.SerializedItemQuantity}";
            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Single(errors.FindAll(e => e.Message.Equals(expectedMessage)));
        }

        [Fact]
        public void ChangedRequestItemDeriveRequiredByDate()
        {
            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            var request = new RequestForQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var requestItem = new RequestItemBuilder(this.Transaction).WithRequiredByDate(this.Transaction.Now().Date).Build();
            request.AddRequestItem(requestItem);
            this.Transaction.Derive(false);

            quoteItem.RequestItem = requestItem;
            this.Transaction.Derive(false);

            Assert.Equal(this.Transaction.Now().Date, quoteItem.RequiredByDate);
        }

        [Fact]
        public void ChangedUnitOfMeasureDeriveUnitOfMeasure()
        {
            var uom = new UnitsOfMeasure(this.Transaction).SquareMeter;

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithUnitOfMeasure(uom).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            quoteItem.RemoveUnitOfMeasure();
            this.Transaction.Derive(false);

            Assert.Equal(new UnitsOfMeasure(this.Transaction).Piece, quoteItem.UnitOfMeasure);
        }
    }

    public class QuoteItemDetailsDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public QuoteItemDetailsDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedSerialisedItemDeriveDetails()
        {
            var serialisedItem = new SerialisedItemBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithSerialisedItem(serialisedItem).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.True(quoteItem.ExistDetails);
        }

        [Fact]
        public void ChangedProductDeriveDetails()
        {
            var product = new UnifiedGoodBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithProduct(product).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.True(quoteItem.ExistDetails);
        }
    }

    public class QuoteItemPriceDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public QuoteItemPriceDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedQuantityOrderedCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithProduct(product).WithQuantity(1).WithAssignedUnitPrice(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            quoteItem.Quantity = 2;
            this.Transaction.Derive(false);

            Assert.Equal(2, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedAssignedUnitPriceCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithProduct(product).WithQuantity(1).WithAssignedUnitPrice(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            quoteItem.AssignedUnitPrice = 3;
            this.Transaction.Derive(false);

            Assert.Equal(3, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedProductCalculatePrice()
        {
            var product1 = new NonUnifiedGoodBuilder(this.Transaction).Build();
            var product2 = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product1)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product2)
                .WithPrice(2)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product1).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            quoteItem.Product = product2;
            this.Transaction.Derive(false);

            Assert.Equal(2, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedProductFeatureCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithPricedBy(this.InternalOrganisation)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            var productFeature = new ColourBuilder(this.Transaction)
                .WithName("a colour")
                .Build();

            new BasePriceBuilder(this.Transaction)
                .WithPricedBy(this.InternalOrganisation)
                .WithProduct(product)
                .WithProductFeature(productFeature)
                .WithPrice(0.1M)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            this.Transaction.Derive(false);

            var orderFeatureItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductFeatureItem).WithProductFeature(productFeature).WithQuantity(1).Build();
            quoteItem.AddQuotedWithFeature(orderFeatureItem);
            quote.AddQuoteItem(orderFeatureItem);
            this.Transaction.Derive(false);

            Assert.Equal(1.1M, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedDiscountAdjustmentsCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            var discount = new DiscountAdjustmentBuilder(this.Transaction).WithPercentage(10).Build();
            quoteItem.AddDiscountAdjustment(discount);
            this.Transaction.Derive(false);

            Assert.Equal(0.9M, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedDiscountAdjustmentPercentageCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            var discount = new DiscountAdjustmentBuilder(this.Transaction).WithPercentage(10).Build();
            quoteItem.AddDiscountAdjustment(discount);
            this.Transaction.Derive(false);

            Assert.Equal(0.9M, quote.TotalIncVat);

            discount.Percentage = 20M;
            this.Transaction.Derive(false);

            Assert.Equal(0.8M, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedDiscountAdjustmentAmountCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            var discount = new DiscountAdjustmentBuilder(this.Transaction).WithAmount(0.5M).Build();
            quoteItem.AddDiscountAdjustment(discount);
            this.Transaction.Derive(false);

            Assert.Equal(0.5M, quote.TotalIncVat);

            discount.Amount = 0.4M;
            this.Transaction.Derive(false);

            Assert.Equal(0.6M, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedSurchargeAdjustmentsCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            var surcharge = new SurchargeAdjustmentBuilder(this.Transaction).WithPercentage(10).Build();
            quoteItem.AddSurchargeAdjustment(surcharge);
            this.Transaction.Derive(false);

            Assert.Equal(1.1M, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedSurchargeAdjustmentPercentageCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            var surcharge = new SurchargeAdjustmentBuilder(this.Transaction).WithPercentage(10).Build();
            quoteItem.AddSurchargeAdjustment(surcharge);
            this.Transaction.Derive(false);

            Assert.Equal(1.1M, quote.TotalIncVat);

            surcharge.Percentage = 20M;
            this.Transaction.Derive(false);

            Assert.Equal(1.2M, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedSurchargeAdjustmentAmountCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            var surcharge = new SurchargeAdjustmentBuilder(this.Transaction).WithAmount(0.5M).Build();
            quoteItem.AddSurchargeAdjustment(surcharge);
            this.Transaction.Derive(false);

            Assert.Equal(1.5M, quote.TotalIncVat);

            surcharge.Amount = 0.4M;
            this.Transaction.Derive(false);

            Assert.Equal(1.4M, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedSalesOrderBillToCustomerCalculatePrice()
        {
            var theGood = new CustomOrganisationClassificationBuilder(this.Transaction).WithName("good customer").Build();
            var theBad = new CustomOrganisationClassificationBuilder(this.Transaction).WithName("bad customer").Build();
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            var customer1 = this.InternalOrganisation.ActiveCustomers.First;
            customer1.AddPartyClassification(theGood);

            var customer2 = this.InternalOrganisation.ActiveCustomers.Last();
            customer2.AddPartyClassification(theBad);

            this.Transaction.Derive(false);

            new BasePriceBuilder(this.Transaction)
                .WithPartyClassification(theGood)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPartyClassification(theBad)
                .WithPrice(2)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithReceiver(customer1).WithIssueDate(this.Transaction.Now()).WithAssignedVatRegime(new VatRegimes(this.Transaction).Exempt).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            quote.Receiver = customer2;
            this.Transaction.Derive(false);

            Assert.Equal(2, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedSalesOrderOrderDateCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();
            var baseprice = new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddDays(-2))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now().AddDays(-1)).WithAssignedVatRegime(new VatRegimes(this.Transaction).Exempt).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithInvoiceItemType(new InvoiceItemTypes(this.Transaction).ProductItem).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.Equal(1, quote.TotalIncVat);

            baseprice.ThroughDate = this.Transaction.Now().AddDays(-2);

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(2)
                .WithFromDate(this.Transaction.Now().AddSeconds(-1))
                .Build();
            this.Transaction.Derive(false);

            quote.IssueDate = this.Transaction.Now();
            this.Transaction.Derive(false);

            Assert.Equal(2, quote.TotalIncVat);
        }

        [Fact]
        public void ChangedSalesOrderDerivationTriggerCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();

            var basePrice = new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddDays(1))
                .Build();

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(quoteItem);

            var expectedMessage = $"{quoteItem}, {this.M.SalesOrderItem.UnitBasePrice} No BasePrice with a Price";
            var errors = new List<IDerivationError>(this.Transaction.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Contains(expectedMessage));

            Assert.Equal(0, quote.TotalExVat);

            basePrice.FromDate = this.Transaction.Now().AddMinutes(-1);
            this.Transaction.Derive(false);

            Assert.Equal(basePrice.Price, quote.TotalExVat);
        }

        [Fact]
        public void ChangedDerivationTriggerCalculatePrice()
        {
            var product = new NonUnifiedGoodBuilder(this.Transaction).Build();
            var break1 = new OrderQuantityBreakBuilder(this.Transaction).WithFromAmount(50).WithThroughAmount(99).Build();

            new BasePriceBuilder(this.Transaction)
                .WithProduct(product)
                .WithPrice(10)
                .WithFromDate(this.Transaction.Now().AddDays(-1))
                .Build();

            new DiscountComponentBuilder(this.Transaction)
                .WithDescription("discount good for quantity break 1")
                .WithOrderQuantityBreak(break1)
                .WithProduct(product)
                .WithPrice(1)
                .WithFromDate(this.Transaction.Now().AddMinutes(-1))
                .Build();

            this.Transaction.Derive(false);

            var quote = new ProductQuoteBuilder(this.Transaction).WithIssueDate(this.Transaction.Now()).Build();
            this.Transaction.Derive(false);

            var item1 = new QuoteItemBuilder(this.Transaction).WithProduct(product).WithQuantity(1).Build();
            quote.AddQuoteItem(item1);
            this.Transaction.Derive(false);

            Assert.Equal(0, item1.UnitDiscount);

            var item2 = new QuoteItemBuilder(this.Transaction).WithProduct(product).WithQuantity(49).Build();
            quote.AddQuoteItem(item2);
            this.Transaction.Derive(false);

            Assert.Equal(1, item1.UnitDiscount);
        }
    }

    [Trait("Category", "Security")]
    public class QuoteItemDeniedPermissonDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public QuoteItemDeniedPermissonDerivationTests(Fixture fixture) : base(fixture) => this.deletePermission = new Permissions(this.Transaction).Get(this.M.QuoteItem.ObjectType, this.M.QuoteItem.Delete);

        public override Config Config => new Config { SetupSecurity = true };

        private readonly Permission deletePermission;

        [Fact]
        public void OnChangedQuoteItemStateCreatedDeriveDeletePermission()
        {
            var purchaseQuote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithAssignedUnitPrice(1)
                .WithInvoiceItemType(new InvoiceItemTypeBuilder(this.Transaction).Build())
                .Build();

            purchaseQuote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            Assert.DoesNotContain(this.deletePermission, quoteItem.DeniedPermissions);
        }

        [Fact]
        public void OnChangedQuoteItemStateCreatedWithNonDeletableQuoteDeriveDeletePermission()
        {
            var purchaseQuote = new ProductQuoteBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Transaction)
                .WithAssignedUnitPrice(1)
                .WithInvoiceItemType(new InvoiceItemTypeBuilder(this.Transaction).Build())
                .Build();

            purchaseQuote.AddQuoteItem(quoteItem);
            this.Transaction.Derive(false);

            purchaseQuote.Send();
            this.Transaction.Derive(false);

            Assert.Contains(this.deletePermission, quoteItem.DeniedPermissions);
        }
    }
}
