// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class PriorityDelete : Allors.Meta.Method
	{
	    private static readonly Allors.Meta.MethodInvocation PriorityDeleteInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.Priority.ObjectType, Allors.Meta.M.Priority.Delete); 

		public PriorityDelete(Priority @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return PriorityDeleteInvocation;
			}
		}
	}
}