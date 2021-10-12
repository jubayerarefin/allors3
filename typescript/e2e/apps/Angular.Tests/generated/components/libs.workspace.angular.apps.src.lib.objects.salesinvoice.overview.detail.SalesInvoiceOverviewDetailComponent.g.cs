// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.salesinvoice.overview.detail
{
    using OpenQA.Selenium;
    using Components;

    public partial class SalesInvoiceOverviewDetailComponent : Components.SelectorComponent
    {
        public SalesInvoiceOverviewDetailComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m, By selector) : base(driver, m)
        {
			this.Selector = selector;
        }

        public override By Selector { get; }

        public SalesInvoiceOverviewDetailComponent Click()
        {
            if(this.Selector != null){
                new Element(this.Driver, this.Selector).Click();
            }

            return this;
        }

        public Components.MatStatic<SalesInvoiceOverviewDetailComponent> SalesInvoiceState => this.MatStatic(this.M.SalesInvoice.SalesInvoiceState, "SalesInvoiceOverviewDetailComponent");


        public Components.MatAutocomplete<SalesInvoiceOverviewDetailComponent> BillToCustomer => this.MatAutocomplete(this.M.SalesInvoice.BillToCustomer, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_1 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> DerivedBillToContactMechanism => this.MatSelect(this.M.SalesInvoice.DerivedBillToContactMechanism, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_2 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> BillToContactPerson => this.MatSelect(this.M.SalesInvoice.BillToContactPerson, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_3 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatAutocomplete<SalesInvoiceOverviewDetailComponent> ShipToCustomer => this.MatAutocomplete(this.M.SalesInvoice.ShipToCustomer, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_4 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> DerivedShipToAddress => this.MatSelect(this.M.SalesInvoice.DerivedShipToAddress, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_5 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> ShipToContactPerson => this.MatSelect(this.M.SalesInvoice.ShipToContactPerson, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_6 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatAutocomplete<SalesInvoiceOverviewDetailComponent> ShipToEndCustomer => this.MatAutocomplete(this.M.SalesInvoice.ShipToEndCustomer, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_7 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> DerivedShipToEndCustomerAddress => this.MatSelect(this.M.SalesInvoice.DerivedShipToEndCustomerAddress, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_8 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> ShipToEndCustomerContactPerson => this.MatSelect(this.M.SalesInvoice.ShipToEndCustomerContactPerson, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_9 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatAutocomplete<SalesInvoiceOverviewDetailComponent> BillToEndCustomer => this.MatAutocomplete(this.M.SalesInvoice.BillToEndCustomer, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_10 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> DerivedBillToEndCustomerContactMechanism => this.MatSelect(this.M.SalesInvoice.DerivedBillToEndCustomerContactMechanism, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_11 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> BillToEndCustomerContactPerson => this.MatSelect(this.M.SalesInvoice.BillToEndCustomerContactPerson, "SalesInvoiceOverviewDetailComponent");


        public Components.Button Addclose_12 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                    close", "SalesInvoiceOverviewDetailComponent");







        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> DerivedCurrency => this.MatSelect(this.M.Invoice.DerivedCurrency, "SalesInvoiceOverviewDetailComponent");


        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> InvoiceDerivedVatRegime_1 => this.MatSelect(this.M.Invoice.DerivedVatRegime, "SalesInvoiceOverviewDetailComponent");


        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> InvoiceDerivedVatRegime_2 => this.MatSelect(this.M.Invoice.DerivedVatRegime, "SalesInvoiceOverviewDetailComponent");


        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> DerivedIrpfRegime => this.MatSelect(this.M.Invoice.DerivedIrpfRegime, "SalesInvoiceOverviewDetailComponent");


        public Components.MatSelect<SalesInvoiceOverviewDetailComponent> DerivedVatClause => this.MatSelect(this.M.SalesInvoice.DerivedVatClause, "SalesInvoiceOverviewDetailComponent");


        public Components.MatDatepicker<SalesInvoiceOverviewDetailComponent> InvoiceDate => this.MatDatepicker(this.M.Invoice.InvoiceDate, "SalesInvoiceOverviewDetailComponent");


        public Components.MatDatepicker<SalesInvoiceOverviewDetailComponent> DueDate => this.MatDatepicker(this.M.SalesInvoice.DueDate, "SalesInvoiceOverviewDetailComponent");


        public Components.MatInput<SalesInvoiceOverviewDetailComponent> AdvancePayment => this.MatInput(this.M.SalesInvoice.AdvancePayment, "SalesInvoiceOverviewDetailComponent");


        public Components.MatStatic<SalesInvoiceOverviewDetailComponent> AmountPaid => this.MatStatic(this.M.Invoice.AmountPaid, "SalesInvoiceOverviewDetailComponent");


        public Components.MatInput<SalesInvoiceOverviewDetailComponent> CustomerReference => this.MatInput(this.M.Invoice.CustomerReference, "SalesInvoiceOverviewDetailComponent");


        public Components.MatTextarea<SalesInvoiceOverviewDetailComponent> Description => this.MatTextarea(this.M.Invoice.Description, "SalesInvoiceOverviewDetailComponent");


        public Components.MatTextarea<SalesInvoiceOverviewDetailComponent> Comment => this.MatTextarea(this.M.Commentable.Comment, "SalesInvoiceOverviewDetailComponent");


        public Components.MatTextarea<SalesInvoiceOverviewDetailComponent> InternalComment => this.MatTextarea(this.M.Invoice.InternalComment, "SalesInvoiceOverviewDetailComponent");



        public Components.MatFiles<SalesInvoiceOverviewDetailComponent> ElectronicDocuments => this.MatFiles(this.M.Invoice.ElectronicDocuments, "SalesInvoiceOverviewDetailComponent");



        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "SalesInvoiceOverviewDetailComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "SalesInvoiceOverviewDetailComponent");

    }
}