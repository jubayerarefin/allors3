// <auto-generated />
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public abstract partial class NamedInheritedDoIt : Allors.Meta.Method
	{
		protected NamedInheritedDoIt(Named @object) : base(@object)
		{
		}
	}

	public partial class CompanyInheritedDoIt : NamedInheritedDoIt
	{
		public CompanyInheritedDoIt(Named @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
			    var m = this.Object.Strategy.Session.Database.State().M;
				return new Allors.Meta.MethodInvocation(m.Company.InheritedDoIt);
			}
		}
	}public partial class PersonInheritedDoIt : NamedInheritedDoIt
	{
		public PersonInheritedDoIt(Named @object) : base(@object)
		{
		}

		public override Allors.Meta.MethodInvocation MethodInvocation
		{
			get
			{
			    var m = this.Object.Strategy.Session.Database.State().M;
				return new Allors.Meta.MethodInvocation(m.Person.InheritedDoIt);
			}
		}
	}
}