// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.orderadjustment.edit
{
    using OpenQA.Selenium;
    using Components;

    public partial class OrderAdjustmentEditComponent : Components.EntryComponent
    {
        public OrderAdjustmentEditComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.MatInput<OrderAdjustmentEditComponent> Amount => this.MatInput(this.M.OrderAdjustment.Amount, "OrderAdjustmentEditComponent");


        public Components.MatInput<OrderAdjustmentEditComponent> Percentage => this.MatInput(this.M.OrderAdjustment.Percentage, "OrderAdjustmentEditComponent");


        public Components.MatTextarea<OrderAdjustmentEditComponent> Description => this.MatTextarea(this.M.OrderAdjustment.Description, "OrderAdjustmentEditComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "OrderAdjustmentEditComponent");


        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "OrderAdjustmentEditComponent");

    }
}