// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public abstract partial class S1SuperinterfaceMethod : Allors.Meta.Method
	{
		protected S1SuperinterfaceMethod(S1 @object) : base(@object)
		{
		}
	}

	public partial class C1SuperinterfaceMethod : S1SuperinterfaceMethod
	{
	    private static readonly Allors.Meta.MethodInvocation C1SuperinterfaceMethodMethodInvocation = new Allors.Meta.MethodInvocation(Allors.Meta.M.C1.ObjectType, Allors.Meta.M.C1.SuperinterfaceMethod); 

		public C1SuperinterfaceMethod(S1 @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
				return C1SuperinterfaceMethodMethodInvocation;
			}
		}
	}
}