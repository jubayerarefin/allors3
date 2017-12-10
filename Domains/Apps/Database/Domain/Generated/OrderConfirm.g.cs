// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public abstract partial class OrderConfirm : Allors.Meta.Method
	{
		protected OrderConfirm(Order @object) : base(@object)
		{
		}
	}

	public partial class PurchaseOrderConfirm : OrderConfirm
	{
	    private static readonly Allors.Meta.MethodInvocation PurchaseOrderConfirmMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.PurchaseOrder.ObjectType, Allors.Meta.M.PurchaseOrder.Confirm); 

		public PurchaseOrderConfirm(Order @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return PurchaseOrderConfirmMethodInvocation;
			}
		}
	}public partial class SalesOrderConfirm : OrderConfirm
	{
	    private static readonly Allors.Meta.MethodInvocation SalesOrderConfirmMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.SalesOrder.ObjectType, Allors.Meta.M.SalesOrder.Confirm); 

		public SalesOrderConfirm(Order @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return SalesOrderConfirmMethodInvocation;
			}
		}
	}
}