// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class SalesChannelDelete : Allors.Meta.Method
	{
	    private static readonly Allors.Meta.MethodInvocation SalesChannelDeleteInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.SalesChannel.ObjectType, Allors.Meta.M.SalesChannel.Delete); 

		public SalesChannelDelete(SalesChannel @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return SalesChannelDeleteInvocation;
			}
		}
	}
}