// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.organisation.overview.summary
{
    using OpenQA.Selenium;
    using Components;

    public partial class OrganisationOverviewSummaryComponent : Components.SelectorComponent
    {
        public OrganisationOverviewSummaryComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m, By selector) : base(driver, m)
        {
			this.Selector = selector;
        }

        public override By Selector { get; }

        public OrganisationOverviewSummaryComponent Click()
        {
            if(this.Selector != null){
                new Element(this.Driver, this.Selector).Click();
            }

            return this;
        }

    }
}