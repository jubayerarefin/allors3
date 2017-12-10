// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public abstract partial class OrderItemCancel : Allors.Meta.Method
	{
		protected OrderItemCancel(OrderItem @object) : base(@object)
		{
		}
	}

	public partial class PurchaseOrderItemCancel : OrderItemCancel
	{
	    private static readonly Allors.Meta.MethodInvocation PurchaseOrderItemCancelMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.PurchaseOrderItem.ObjectType, Allors.Meta.M.PurchaseOrderItem.Cancel); 

		public PurchaseOrderItemCancel(OrderItem @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return PurchaseOrderItemCancelMethodInvocation;
			}
		}
	}public partial class SalesOrderItemCancel : OrderItemCancel
	{
	    private static readonly Allors.Meta.MethodInvocation SalesOrderItemCancelMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.SalesOrderItem.ObjectType, Allors.Meta.M.SalesOrderItem.Cancel); 

		public SalesOrderItemCancel(OrderItem @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return SalesOrderItemCancelMethodInvocation;
			}
		}
	}
}