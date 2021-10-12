// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.salesorder.overview
{
    using OpenQA.Selenium;
    using Components;

    public partial class SalesOrderOverviewComponent : Components.RoutedComponent
    {
        public SalesOrderOverviewComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.Anchor SalesOrders => new Components.Anchor(this.Driver, this.M, "InnerText", @"SalesOrders", "SalesOrderOverviewComponent");



        public libs.workspace.angular.apps.src.lib.objects.salesorder.overview.detail.SalesOrderOverviewDetailComponent SalesorderOverviewDetail => new libs.workspace.angular.apps.src.lib.objects.salesorder.overview.detail.SalesOrderOverviewDetailComponent(this.Driver, this.M, By.XPath(@".//salesorder-overview-detail[ancestor::*[@data-test-scope][1]/@data-test-scope='SalesOrderOverviewComponent']"));


        public libs.workspace.angular.apps.src.lib.objects.salesorderitem.overview.panel.SalesOrderItemOverviewPanelComponent SalesorderitemOverviewPanel => new libs.workspace.angular.apps.src.lib.objects.salesorderitem.overview.panel.SalesOrderItemOverviewPanelComponent(this.Driver, this.M, By.XPath(@".//salesorderitem-overview-panel[ancestor::*[@data-test-scope][1]/@data-test-scope='SalesOrderOverviewComponent']"));


        public libs.workspace.angular.apps.src.lib.objects.orderadjustment.overview.panel.OrderAdjustmentOverviewPanelComponent OrderadjustmentOverviewPanel => new libs.workspace.angular.apps.src.lib.objects.orderadjustment.overview.panel.OrderAdjustmentOverviewPanelComponent(this.Driver, this.M, By.XPath(@".//orderadjustment-overview-panel[ancestor::*[@data-test-scope][1]/@data-test-scope='SalesOrderOverviewComponent']"));


        public libs.workspace.angular.apps.src.lib.objects.salesterm.overview.panel.SalesTermOverviewPanelComponent SalestermOverviewPanel => new libs.workspace.angular.apps.src.lib.objects.salesterm.overview.panel.SalesTermOverviewPanelComponent(this.Driver, this.M, By.XPath(@".//salesterm-overview-panel[ancestor::*[@data-test-scope][1]/@data-test-scope='SalesOrderOverviewComponent']"));

    }
}