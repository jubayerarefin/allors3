// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace src.app.error
{
    using OpenQA.Selenium;
    using Components;

    public partial class ErrorComponent : Components.RoutedComponent
    {
        public ErrorComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.Button Restart => new Components.Button(this.Driver, this.M, "InnerText", @"Restart", "ErrorComponent");

    }
}