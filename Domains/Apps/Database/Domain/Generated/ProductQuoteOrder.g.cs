// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class ProductQuoteOrder : Allors.Meta.Method
	{
	    private static readonly Allors.Meta.MethodInvocation ProductQuoteOrderInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.ProductQuote.ObjectType, Allors.Meta.M.ProductQuote.Order); 

		public ProductQuoteOrder(ProductQuote @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return ProductQuoteOrderInvocation;
			}
		}
	}
}