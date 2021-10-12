// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.salesinvoiceitem.edit
{
    using OpenQA.Selenium;
    using Components;

    public partial class SalesInvoiceItemEditComponent : Components.EntryComponent
    {
        public SalesInvoiceItemEditComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.MatStatic<SalesInvoiceItemEditComponent> SalesInvoiceItemState => this.MatStatic(this.M.SalesInvoiceItem.SalesInvoiceItemState, "SalesInvoiceItemEditComponent");


        public Components.MatSelect<SalesInvoiceItemEditComponent> SalesInvoiceItemInvoiceItemType_1 => this.MatSelect(this.M.SalesInvoiceItem.InvoiceItemType, "SalesInvoiceItemEditComponent");


        public Components.MatSelect<SalesInvoiceItemEditComponent> SalesInvoiceItemInvoiceItemType_2 => this.MatSelect(this.M.SalesInvoiceItem.InvoiceItemType, "SalesInvoiceItemEditComponent");


        public Components.MatAutocomplete<SalesInvoiceItemEditComponent> Product => this.MatAutocomplete(this.M.SalesInvoiceItem.Product, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> ProductStatic => this.MatStatic(this.M.SalesInvoiceItem.Product, "SalesInvoiceItemEditComponent");


        public Components.MatSelect<SalesInvoiceItemEditComponent> SerialisedItem => this.MatSelect(this.M.SalesInvoiceItem.SerialisedItem, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> SerialisedItemStatic => this.MatStatic(this.M.SalesInvoiceItem.SerialisedItem, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> ExpectedSalesPrice => this.MatStatic(this.M.SerialisedItem.ExpectedSalesPrice, "SalesInvoiceItemEditComponent");


        public Components.MatSelect<SalesInvoiceItemEditComponent> DerivedVatRegime => this.MatSelect(this.M.Priceable.DerivedVatRegime, "SalesInvoiceItemEditComponent");


        public Components.MatSelect<SalesInvoiceItemEditComponent> DerivedIrpfRegime => this.MatSelect(this.M.InvoiceItem.DerivedIrpfRegime, "SalesInvoiceItemEditComponent");


        public Components.MatSelect<SalesInvoiceItemEditComponent> NextSerialisedItemAvailability => this.MatSelect(this.M.SalesInvoiceItem.NextSerialisedItemAvailability, "SalesInvoiceItemEditComponent");


        public Components.MatInput<SalesInvoiceItemEditComponent> Quantity => this.MatInput(this.M.InvoiceItem.Quantity, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> UnitPrice => this.MatStatic(this.M.Priceable.UnitPrice, "SalesInvoiceItemEditComponent");


        public Components.MatInput<SalesInvoiceItemEditComponent> AssignedUnitPrice => this.MatInput(this.M.Priceable.AssignedUnitPrice, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> UnitVat => this.MatStatic(this.M.Priceable.UnitVat, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> TotalIncVat => this.MatStatic(this.M.Priceable.TotalIncVat, "SalesInvoiceItemEditComponent");


        public Components.MatTextarea<SalesInvoiceItemEditComponent> Description => this.MatTextarea(this.M.InvoiceItem.Description, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> CommentStatic => this.MatStatic(this.M.Commentable.Comment, "SalesInvoiceItemEditComponent");


        public Components.MatTextarea<SalesInvoiceItemEditComponent> Comment => this.MatTextarea(this.M.Commentable.Comment, "SalesInvoiceItemEditComponent");


        public Components.MatStatic<SalesInvoiceItemEditComponent> InternalCommentStatic => this.MatStatic(this.M.OrderItem.InternalComment, "SalesInvoiceItemEditComponent");


        public Components.MatTextarea<SalesInvoiceItemEditComponent> InternalComment => this.MatTextarea(this.M.InvoiceItem.InternalComment, "SalesInvoiceItemEditComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "SalesInvoiceItemEditComponent");


        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "SalesInvoiceItemEditComponent");

    }
}