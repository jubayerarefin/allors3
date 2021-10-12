// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.salesorderitem.edit
{
    using OpenQA.Selenium;
    using Components;

    public partial class SalesOrderItemEditComponent : Components.EntryComponent
    {
        public SalesOrderItemEditComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.MatStatic<SalesOrderItemEditComponent> SalesOrderItemState => this.MatStatic(this.M.SalesOrderItem.SalesOrderItemState, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> SalesOrderItemShipmentState => this.MatStatic(this.M.SalesOrderItem.SalesOrderItemShipmentState, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> SalesOrderItemInvoiceState => this.MatStatic(this.M.SalesOrderItem.SalesOrderItemInvoiceState, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> SalesOrderItemPaymentState => this.MatStatic(this.M.SalesOrderItem.SalesOrderItemPaymentState, "SalesOrderItemEditComponent");


        public Components.MatSelect<SalesOrderItemEditComponent> SalesOrderItemInvoiceItemType_1 => this.MatSelect(this.M.SalesOrderItem.InvoiceItemType, "SalesOrderItemEditComponent");


        public Components.MatSelect<SalesOrderItemEditComponent> SalesOrderItemInvoiceItemType_2 => this.MatSelect(this.M.SalesOrderItem.InvoiceItemType, "SalesOrderItemEditComponent");


        public Components.MatInput<SalesOrderItemEditComponent> PriceableAssignedUnitPrice_1 => this.MatInput(this.M.Priceable.AssignedUnitPrice, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> UnitVat_1 => this.MatStatic(this.M.Priceable.UnitVat, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> TotalIncVat_1 => this.MatStatic(this.M.Priceable.TotalIncVat, "SalesOrderItemEditComponent");


        public Components.MatAutocomplete<SalesOrderItemEditComponent> Product => this.MatAutocomplete(this.M.SalesOrderItem.Product, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> ProductStatic => this.MatStatic(this.M.SalesOrderItem.Product, "SalesOrderItemEditComponent");


        public Components.MatSelect<SalesOrderItemEditComponent> SerialisedItem => this.MatSelect(this.M.SalesOrderItem.SerialisedItem, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> SerialisedItemStatic => this.MatStatic(this.M.SalesOrderItem.SerialisedItem, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> ExpectedSalesPrice => this.MatStatic(this.M.SerialisedItem.ExpectedSalesPrice, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> CostOfGoodsSold => this.MatStatic(this.M.SalesOrderItem.CostOfGoodsSold, "SalesOrderItemEditComponent");


        public Components.MatInput<SalesOrderItemEditComponent> QuantityOrdered => this.MatInput(this.M.OrderItem.QuantityOrdered, "SalesOrderItemEditComponent");


        public Components.MatInput<SalesOrderItemEditComponent> PriceableAssignedUnitPrice_2 => this.MatInput(this.M.Priceable.AssignedUnitPrice, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> UnitVat_2 => this.MatStatic(this.M.Priceable.UnitVat, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> TotalIncVat_2 => this.MatStatic(this.M.Priceable.TotalIncVat, "SalesOrderItemEditComponent");


        public Components.MatSelect<SalesOrderItemEditComponent> DerivedVatRegime => this.MatSelect(this.M.Priceable.DerivedVatRegime, "SalesOrderItemEditComponent");


        public Components.MatSelect<SalesOrderItemEditComponent> DerivedIrpfRegime => this.MatSelect(this.M.OrderItem.DerivedIrpfRegime, "SalesOrderItemEditComponent");


        public Components.MatSelect<SalesOrderItemEditComponent> NextSerialisedItemAvailability => this.MatSelect(this.M.SalesOrderItem.NextSerialisedItemAvailability, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> QuantityReserved => this.MatStatic(this.M.SalesOrderItem.QuantityReserved, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> QuantityRequestsShipping => this.MatStatic(this.M.SalesOrderItem.QuantityRequestsShipping, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> QuantityShipped => this.MatStatic(this.M.SalesOrderItem.QuantityShipped, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> QuantityShortFalled => this.MatStatic(this.M.SalesOrderItem.QuantityShortFalled, "SalesOrderItemEditComponent");


        public Components.MatTextarea<SalesOrderItemEditComponent> Description => this.MatTextarea(this.M.OrderItem.Description, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> CommentStatic => this.MatStatic(this.M.Commentable.Comment, "SalesOrderItemEditComponent");


        public Components.MatTextarea<SalesOrderItemEditComponent> Comment => this.MatTextarea(this.M.Commentable.Comment, "SalesOrderItemEditComponent");


        public Components.MatStatic<SalesOrderItemEditComponent> InternalCommentStatic => this.MatStatic(this.M.QuoteItem.InternalComment, "SalesOrderItemEditComponent");


        public Components.MatTextarea<SalesOrderItemEditComponent> InternalComment => this.MatTextarea(this.M.OrderItem.InternalComment, "SalesOrderItemEditComponent");


        public Components.Button SAVECLOSE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE & CLOSE", "SalesOrderItemEditComponent");


        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "SalesOrderItemEditComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "SalesOrderItemEditComponent");

    }
}