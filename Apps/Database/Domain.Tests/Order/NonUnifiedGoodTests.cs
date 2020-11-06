// <copyright file="OrderTermTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Domain
{
    using System.Linq;
    using Allors.Domain.TestPopulation;
    using Xunit;

    [Trait("Category", "Security")]
    public class NonUnifiedGoodSecurityTests : DomainTest, IClassFixture<Fixture>
    {
        public NonUnifiedGoodSecurityTests(Fixture fixture) : base(fixture) => this.deletePermission = new Permissions(this.Session).Get(this.M.NonUnifiedGood.ObjectType, this.M.NonUnifiedGood.Delete);
        public override Config Config => new Config { SetupSecurity = true };

        private readonly Permission deletePermission;

        [Fact]
        public void OnChangedNonUnifiedGoodDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();

            this.Session.Derive(false);

            Assert.DoesNotContain(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithPartDeriveDeletePermission()
        {
            var nonUnifiedPart = new NonUnifiedPartBuilder(this.Session).Build();
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).WithPart(nonUnifiedPart).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithDeploymentsWhereProductOfferingDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var deployment = new DeploymentBuilder(this.Session).WithProductOffering(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithEngagementItemsWhereProductDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var GoodOrderItem = new GoodOrderItemBuilder(this.Session).WithProduct(nonUnifiedGood).Build();
            this.Session.Derive(false);
            
            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithGeneralLedgerAccountsWhereCostUnitsAllowedDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var generalLedgerAccounts = new GeneralLedgerAccountBuilder(this.Session).Build();
            generalLedgerAccounts.AddCostUnitsAllowed(nonUnifiedGood);
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithGeneralLedgerAccountsWhereDefaultCostUnitDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var generalLedgerAccounts = new GeneralLedgerAccountBuilder(this.Session).WithDefaultCostUnit(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithQuoteItemsWhereProductDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var quoteItem = new QuoteItemBuilder(this.Session)
                .WithProduct(nonUnifiedGood)
                .WithInvoiceItemType(new InvoiceItemTypeBuilder(this.Session).Build())
                .WithUnitBasePrice(1)
                .WithAssignedUnitPrice(1)
                .Build();
            var quotes = new ProductQuoteBuilder(this.Session).WithQuoteItem(quoteItem).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithShipmentItemsWhereGoodDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var shipmentItem = new ShipmentItemBuilder(this.Session).WithGood(nonUnifiedGood).Build();
            var shipment = new PurchaseShipmentBuilder(this.Session).WithShipmentItem(shipmentItem).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithWorkEffortGoodStandardsWhereUnifiedProductDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var workEffortGoodStandard = new WorkEffortGoodStandardBuilder(this.Session).WithUnifiedProduct(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithMarketingPackageWhereProductsUsedInDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var marketingPackage = new MarketingPackageBuilder(this.Session).WithProductsUsedIn(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }
        
        [Fact]
        public void OnChangedNonUnifiedGoodWithMarketingPackagesWhereProductDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var marketingPackage = new MarketingPackageBuilder(this.Session).WithProduct(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithOrganisationGlAccountsWhereProductDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var organisationGlAccount = new OrganisationGlAccountBuilder(this.Session).WithProduct(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithProductConfigurationsWhereProductsUsedInDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var productConfiguration = new ProductConfigurationBuilder(this.Session).WithProductsUsedIn(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithProductConfigurationsWhereProductInDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var productConfiguration = new ProductConfigurationBuilder(this.Session).WithProduct(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithRequestItemsWhereProductDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var requestItem = new RequestItemBuilder(this.Session).WithProduct(nonUnifiedGood).Build();
            var request = new RequestForQuoteBuilder(this.Session).Build();
            request.AddRequestItem(requestItem);
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithSalesInvoiceItemsWhereProductDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var salesInvoiceItem = new SalesInvoiceItemBuilder(this.Session).WithProduct(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }
        
        [Fact]
        public void OnChangedNonUnifiedGoodWithSalesOrderItemsWhereProductDeriveDeletePermission()
        {
            var salesOrder = new SalesOrderBuilder(this.Session).WithOrganisationExternalDefaults(this.InternalOrganisation).Build();
            this.Session.Derive(false);

            var product = salesOrder.SalesOrderItems.Where(v => v.Product.GetType().Name == typeof(NonUnifiedGood).Name).Select(v => v.Product).First();

            Assert.Contains(this.deletePermission, product.DeniedPermissions);
        }

        [Fact]
        public void OnChangedNonUnifiedGoodWithWorkEffortTypesWhereProductToProduceDeriveDeletePermission()
        {
            var nonUnifiedGood = new NonUnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            var workEffortType = new WorkEffortTypeBuilder(this.Session).WithProductToProduce(nonUnifiedGood).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, nonUnifiedGood.DeniedPermissions);
        }
    }
}
