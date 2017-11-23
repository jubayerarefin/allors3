// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface Deletable :  Object, Allors.IObject
	{


		DeletableDelete Delete();

		DeletableDelete Delete(System.Action<DeletableDelete> action);
	}

	public partial interface DeletableBuilder : ObjectBuilder , global::System.IDisposable
	{	
	}

	public partial class Deletables : global::Allors.ObjectsBase<Deletable>
	{
		public Deletables(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaDeletable Meta
		{
			get
			{
				return Allors.Meta.MetaDeletable.Instance;
			}
		}

		public override Allors.Meta.Composite ObjectType
		{
			get
			{
				return Meta.ObjectType;
			}
		}
	}

}