// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface Shared :  Object, Allors.IObject
	{


		global::Allors.Extent<Two> TwosWhereShared
		{ 
			get;
		}

		bool ExistTwosWhereShared
		{
			get;
		}

	}

	public partial interface SharedBuilder : ObjectBuilder , global::System.IDisposable
	{	
	}

	public partial class Shareds : global::Allors.ObjectsBase<Shared>
	{
		public Shareds(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaShared Meta
		{
			get
			{
				return Allors.Meta.MetaShared.Instance;
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