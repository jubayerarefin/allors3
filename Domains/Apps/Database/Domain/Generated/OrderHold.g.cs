// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public abstract partial class OrderHold : Allors.Meta.Method
	{
		protected OrderHold(Order @object) : base(@object)
		{
		}
	}

	public partial class PurchaseOrderHold : OrderHold
	{
	    private static readonly Allors.Meta.MethodInvocation PurchaseOrderHoldMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.PurchaseOrder.ObjectType, Allors.Meta.M.PurchaseOrder.Hold); 

		public PurchaseOrderHold(Order @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return PurchaseOrderHoldMethodInvocation;
			}
		}
	}public partial class SalesOrderHold : OrderHold
	{
	    private static readonly Allors.Meta.MethodInvocation SalesOrderHoldMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.SalesOrder.ObjectType, Allors.Meta.M.SalesOrder.Hold); 

		public SalesOrderHold(Order @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return SalesOrderHoldMethodInvocation;
			}
		}
	}
}