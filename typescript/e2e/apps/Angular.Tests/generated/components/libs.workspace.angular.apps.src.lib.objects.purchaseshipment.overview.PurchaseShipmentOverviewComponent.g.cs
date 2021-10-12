// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.purchaseshipment.overview
{
    using OpenQA.Selenium;
    using Components;

    public partial class PurchaseShipmentOverviewComponent : Components.RoutedComponent
    {
        public PurchaseShipmentOverviewComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.Anchor Shipments => new Components.Anchor(this.Driver, this.M, "InnerText", @"Shipments", "PurchaseShipmentOverviewComponent");



        public libs.workspace.angular.apps.src.lib.objects.purchaseshipment.overview.detail.PurchaseShipmentOverviewDetailComponent PurchaseshipmentOverviewDetail => new libs.workspace.angular.apps.src.lib.objects.purchaseshipment.overview.detail.PurchaseShipmentOverviewDetailComponent(this.Driver, this.M, By.XPath(@".//purchaseshipment-overview-detail[ancestor::*[@data-test-scope][1]/@data-test-scope='PurchaseShipmentOverviewComponent']"));


        public libs.workspace.angular.apps.src.lib.objects.shipmentitem.overview.panel.ShipmentItemOverviewPanelComponent ShipmentitemOverviewPanel => new libs.workspace.angular.apps.src.lib.objects.shipmentitem.overview.panel.ShipmentItemOverviewPanelComponent(this.Driver, this.M, By.XPath(@".//shipmentitem-overview-panel[ancestor::*[@data-test-scope][1]/@data-test-scope='PurchaseShipmentOverviewComponent']"));

    }
}