// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public abstract partial class OrderItemApprove : Allors.Meta.Method
	{
		protected OrderItemApprove(OrderItem @object) : base(@object)
		{
		}
	}

	public partial class PurchaseOrderItemApprove : OrderItemApprove
	{
	    private static readonly Allors.Meta.MethodInvocation PurchaseOrderItemApproveMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.PurchaseOrderItem.ObjectType, Allors.Meta.M.PurchaseOrderItem.Approve); 

		public PurchaseOrderItemApprove(OrderItem @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return PurchaseOrderItemApproveMethodInvocation;
			}
		}
	}public partial class SalesOrderItemApprove : OrderItemApprove
	{
	    private static readonly Allors.Meta.MethodInvocation SalesOrderItemApproveMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.SalesOrderItem.ObjectType, Allors.Meta.M.SalesOrderItem.Approve); 

		public SalesOrderItemApprove(OrderItem @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return SalesOrderItemApproveMethodInvocation;
			}
		}
	}
}