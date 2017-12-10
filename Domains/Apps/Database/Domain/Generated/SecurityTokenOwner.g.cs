// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface SecurityTokenOwner :  Object, Allors.IObject
	{


		SecurityToken OwnerSecurityToken
		{ 
			get;
			set;
		}

		bool ExistOwnerSecurityToken
		{
			get;
		}

		void RemoveOwnerSecurityToken();


		AccessControl OwnerAccessControl
		{ 
			get;
			set;
		}

		bool ExistOwnerAccessControl
		{
			get;
		}

		void RemoveOwnerAccessControl();

	}

	public partial interface SecurityTokenOwnerBuilder : ObjectBuilder , global::System.IDisposable
	{	
	}

	public partial class SecurityTokenOwners : global::Allors.ObjectsBase<SecurityTokenOwner>
	{
		public SecurityTokenOwners(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSecurityTokenOwner Meta
		{
			get
			{
				return Allors.Meta.MetaSecurityTokenOwner.Instance;
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