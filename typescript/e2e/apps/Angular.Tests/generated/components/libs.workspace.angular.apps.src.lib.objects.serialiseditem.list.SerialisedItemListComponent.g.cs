// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.serialiseditem.list
{
    using OpenQA.Selenium;
    using Components;

    public partial class SerialisedItemListComponent : Components.RoutedComponent
    {
        public SerialisedItemListComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.Button Delete => new Components.Button(this.Driver, this.M, "InnerText", @"delete", "SerialisedItemListComponent");




        public Components.MatTable Table => new Components.MatTable(this.Driver, this.M, By.XPath(@".//a-mat-table[ancestor::*[@data-test-scope][1]/@data-test-scope='SerialisedItemListComponent']"));

    }
}