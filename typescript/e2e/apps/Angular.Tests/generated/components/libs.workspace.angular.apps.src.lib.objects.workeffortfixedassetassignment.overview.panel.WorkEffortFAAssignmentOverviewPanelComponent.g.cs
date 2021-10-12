// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.workeffortfixedassetassignment.overview.panel
{
    using OpenQA.Selenium;
    using Components;

    public partial class WorkEffortFAAssignmentOverviewPanelComponent : Components.SelectorComponent
    {
        public WorkEffortFAAssignmentOverviewPanelComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m, By selector) : base(driver, m)
        {
			this.Selector = selector;
        }

        public override By Selector { get; }

        public WorkEffortFAAssignmentOverviewPanelComponent Click()
        {
            if(this.Selector != null){
                new Element(this.Driver, this.Selector).Click();
            }

            return this;
        }

        public Components.MatFactoryFab Factory => new Components.MatFactoryFab(this.Driver, this.M, Allors.Meta.M.Allors.Workspace.Meta.Lazy.LazyWorkEffortFixedAssetAssignment.ObjectType, By.XPath(@".//a-mat-factory-fab[ancestor::*[@data-test-scope][1]/@data-test-scope='WorkEffortFAAssignmentOverviewPanelComponent']"));


        public Components.MatTable Table => new Components.MatTable(this.Driver, this.M, By.XPath(@".//a-mat-table[ancestor::*[@data-test-scope][1]/@data-test-scope='WorkEffortFAAssignmentOverviewPanelComponent']"));

    }
}