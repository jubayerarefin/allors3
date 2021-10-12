// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.nonunifiedpart.overview.detail
{
    using OpenQA.Selenium;
    using Components;

    public partial class NonUnifiedPartOverviewDetailComponent : Components.SelectorComponent
    {
        public NonUnifiedPartOverviewDetailComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m, By selector) : base(driver, m)
        {
			this.Selector = selector;
        }

        public override By Selector { get; }

        public NonUnifiedPartOverviewDetailComponent Click()
        {
            if(this.Selector != null){
                new Element(this.Driver, this.Selector).Click();
            }

            return this;
        }

        public Components.MatStatic<NonUnifiedPartOverviewDetailComponent> Identification => this.MatStatic(this.M.ProductIdentification.Identification, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatInput<NonUnifiedPartOverviewDetailComponent> Name => this.MatInput(this.M.UnifiedProduct.Name, "NonUnifiedPartOverviewDetailComponent");




        public Components.Button Addclose_1 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                  close", "NonUnifiedPartOverviewDetailComponent");









        public Components.Button Addclose_2 => new Components.Button(this.Driver, this.M, "InnerText", @"add
                  close", "NonUnifiedPartOverviewDetailComponent");







        public Components.MatSelect<NonUnifiedPartOverviewDetailComponent> DefaultFacility => this.MatSelect(this.M.Part.DefaultFacility, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatSelect<NonUnifiedPartOverviewDetailComponent> UnitOfMeasure => this.MatSelect(this.M.UnifiedProduct.UnitOfMeasure, "NonUnifiedPartOverviewDetailComponent");



        public Components.Input Suppliers => new Components.Input(this.Driver, this.M, "Name", @"suppliers", "NonUnifiedPartOverviewDetailComponent");


        public Components.MatSelect<NonUnifiedPartOverviewDetailComponent> ManufacturedBy => this.MatSelect(this.M.Part.ManufacturedBy, "NonUnifiedPartOverviewDetailComponent");




        public Components.MatInput<NonUnifiedPartOverviewDetailComponent> HsCode => this.MatInput(this.M.Part.HsCode, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatSelect<NonUnifiedPartOverviewDetailComponent> InventoryItemKind => this.MatSelect(this.M.Part.InventoryItemKind, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatStatic<NonUnifiedPartOverviewDetailComponent> AverageCost => this.MatStatic(this.M.PartWeightedAverage.AverageCost, "NonUnifiedPartOverviewDetailComponent");





        public Components.MatLocalisedText<NonUnifiedPartOverviewDetailComponent> LocalisedNames => this.MatLocalisedText(this.M.UnifiedProduct.LocalisedNames, "NonUnifiedPartOverviewDetailComponent");



        public Components.MatInput<NonUnifiedPartOverviewDetailComponent> SerialisedItemCharacteristicValue_1 => this.MatInput(this.M.SerialisedItemCharacteristic.Value, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatTextarea<NonUnifiedPartOverviewDetailComponent> SerialisedItemCharacteristicValue_2 => this.MatTextarea(this.M.SerialisedItemCharacteristic.Value, "NonUnifiedPartOverviewDetailComponent");





        public Components.MatLocalisedText<NonUnifiedPartOverviewDetailComponent> LocalisedValues => this.MatLocalisedText(this.M.SerialisedItemCharacteristic.LocalisedValues, "NonUnifiedPartOverviewDetailComponent");



        public Components.MatTextarea<NonUnifiedPartOverviewDetailComponent> InternalComment => this.MatTextarea(this.M.UnifiedProduct.InternalComment, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatTextarea<NonUnifiedPartOverviewDetailComponent> Keywords => this.MatTextarea(this.M.UnifiedProduct.Keywords, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatTextarea<NonUnifiedPartOverviewDetailComponent> Comment => this.MatTextarea(this.M.Commentable.Comment, "NonUnifiedPartOverviewDetailComponent");





        public Components.MatLocalisedText<NonUnifiedPartOverviewDetailComponent> LocalisedComments => this.MatLocalisedText(this.M.Commentable.LocalisedComments, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatLocalisedText<NonUnifiedPartOverviewDetailComponent> LocalisedKeywords => this.MatLocalisedText(this.M.UnifiedProduct.LocalisedKeywords, "NonUnifiedPartOverviewDetailComponent");



        public Components.MatFile<NonUnifiedPartOverviewDetailComponent> PrimaryPhoto => this.MatFile(this.M.UnifiedProduct.PrimaryPhoto, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatFiles<NonUnifiedPartOverviewDetailComponent> Photos => this.MatFiles(this.M.UnifiedProduct.Photos, "NonUnifiedPartOverviewDetailComponent");



        public Components.MatFiles<NonUnifiedPartOverviewDetailComponent> PublicElectronicDocuments => this.MatFiles(this.M.UnifiedProduct.PublicElectronicDocuments, "NonUnifiedPartOverviewDetailComponent");


        public Components.MatFiles<NonUnifiedPartOverviewDetailComponent> PrivateElectronicDocuments => this.MatFiles(this.M.UnifiedProduct.PrivateElectronicDocuments, "NonUnifiedPartOverviewDetailComponent");



        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "NonUnifiedPartOverviewDetailComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "NonUnifiedPartOverviewDetailComponent");

    }
}