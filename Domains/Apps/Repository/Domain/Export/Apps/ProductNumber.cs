namespace Allors.Repository
{
    using Attributes;

    #region Allors
    [Id("8E475003-78C3-4E97-B565-1B2E864380EC")]
    #endregion
    public partial class ProductNumber : IGoodIdentification
    {
        #region inherited properties

        public string Identification { get; set; }

        public GoodIdentificationType GoodIdentificationType { get; set; }

        #endregion

        #region inherited methods

        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        public void Delete() { }

        #endregion
    }
}