namespace Scaffold
{
    using AngleSharp.Dom;

    public class DefaultComponentModel : ComponentModel
    {
        public static readonly Dictionary<string, string> TypeByTag = new()
        {
            { "a-mat-barcode-entry", "Allors.E2E.Angular.Material.BarcodeEntryComponent" },
            { "a-mat-dyn-edit-detail-panel", "Allors.E2E.Angular.Material.DynamicEditDetailPanelComponent" },
            { "a-mat-dyn-view-detail-panel", "Allors.E2E.Angular.Material.DynamicViewDetailPanelComponent" },
            { "a-mat-factory-fab", "Allors.E2E.Angular.Material.FactoryFabComponent" },
            { "a-mat-filter", "Allors.E2E.Angular.Material.FilterComponent" },
        };

        public override string Type { get; }

        public override string Property { get; }

        public override string Init { get; }

        public DefaultComponentModel(IElement element)
        {
            var tag = element.TagName.ToLowerInvariant();
            var fullType = TypeByTag[tag];
            var type = fullType.Split('.').Last();

            this.Type = fullType;
            this.Property = type;
            this.Init = "new " + fullType + "(this, );";
        }

        public class Builder : ComponentModelBuilder
        {
            public Builder(ComponentModelBuilder? next = null) : base(next)
            {
            }

            public override ComponentModel? Build(IElement element) =>
                TypeByTag.ContainsKey(element.TagName.ToLowerInvariant())
                    ? new RoleComponentModel(element)
                    : base.Build(element);
        }
    }
}
