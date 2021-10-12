// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.person.overview.summary
{
    using OpenQA.Selenium;
    using Components;

    public partial class PersonOverviewSummaryComponent : Components.SelectorComponent
    {
        public PersonOverviewSummaryComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m, By selector) : base(driver, m)
        {
			this.Selector = selector;
        }

        public override By Selector { get; }

        public PersonOverviewSummaryComponent Click()
        {
            if(this.Selector != null){
                new Element(this.Driver, this.Selector).Click();
            }

            return this;
        }

    }
}