// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.worktask.overview.panel
{
    using OpenQA.Selenium;
    using Components;

    public partial class WorkTaskOverviewPanelComponent : Components.SelectorComponent
    {
        public WorkTaskOverviewPanelComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m, By selector) : base(driver, m)
        {
			this.Selector = selector;
        }

        public override By Selector { get; }

        public WorkTaskOverviewPanelComponent Click()
        {
            if(this.Selector != null){
                new Element(this.Driver, this.Selector).Click();
            }

            return this;
        }

        public Components.MatFactoryFab Factory => new Components.MatFactoryFab(this.Driver, this.M, Allors.Meta.M.Allors.Workspace.Meta.Lazy.LazyWorkEffort.ObjectType, By.XPath(@".//a-mat-factory-fab[ancestor::*[@data-test-scope][1]/@data-test-scope='WorkTaskOverviewPanelComponent']"));


        public Components.MatTable Table => new Components.MatTable(this.Driver, this.M, By.XPath(@".//a-mat-table[ancestor::*[@data-test-scope][1]/@data-test-scope='WorkTaskOverviewPanelComponent']"));

    }
}