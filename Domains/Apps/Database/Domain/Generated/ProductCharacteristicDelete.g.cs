// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class ProductCharacteristicDelete : Allors.Meta.Method
	{
	    private static readonly Allors.Meta.MethodInvocation ProductCharacteristicDeleteInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.ProductCharacteristic.ObjectType, Allors.Meta.M.ProductCharacteristic.Delete); 

		public ProductCharacteristicDelete(ProductCharacteristic @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return ProductCharacteristicDeleteInvocation;
			}
		}
	}
}