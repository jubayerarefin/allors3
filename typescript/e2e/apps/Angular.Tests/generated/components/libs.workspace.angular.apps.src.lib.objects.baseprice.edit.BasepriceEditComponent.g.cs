// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.baseprice.edit
{
    using OpenQA.Selenium;
    using Components;

    public partial class BasepriceEditComponent : Components.EntryComponent
    {
        public BasepriceEditComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.MatDatepicker<BasepriceEditComponent> FromDate => this.MatDatepicker(this.M.Period.FromDate, "BasepriceEditComponent");


        public Components.MatDatepicker<BasepriceEditComponent> ThroughDate => this.MatDatepicker(this.M.Period.ThroughDate, "BasepriceEditComponent");


        public Components.MatInput<BasepriceEditComponent> Price => this.MatInput(this.M.PriceComponent.Price, "BasepriceEditComponent");


        public Components.MatInput<BasepriceEditComponent> Description => this.MatInput(this.M.PriceComponent.Description, "BasepriceEditComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "BasepriceEditComponent");


        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "BasepriceEditComponent");

    }
}