// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Workspace.Domain
{
	public partial class UserGroup : SessionObject , UniquelyIdentifiable
	{
		public UserGroup(Session session)
		: base(session)
		{
		}

		public Allors.Workspace.Meta.MetaUserGroup Meta
		{
			get
			{
				return Allors.Workspace.Meta.MetaUserGroup.Instance;
			}
		}

		public static UserGroup Instantiate (Session allorsSession, long allorsObjectId)
		{
			return (UserGroup) allorsSession.Get(allorsObjectId);		
		}

		public override bool Equals(object obj)
        {
            var that = obj as SessionObject;
		    if (that == null)
		    {
		        return false;
		    }

		    return this.Id.Equals(that.Id);
        }

		public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


		public bool CanReadUniqueId 
		{
			get
			{
				return this.CanRead(this.Meta.UniqueId);
			}
		}

		public bool CanWriteUniqueId 
		{
			get
			{
				return this.CanWrite(this.Meta.UniqueId);
			}
		}



		virtual public global::System.Guid UniqueId 
		{
			get
			{
				return (global::System.Guid) this.Get(Meta.UniqueId);
			}
			set
			{
				this.Set(Meta.UniqueId, value);
			}
		}

		virtual public bool ExistUniqueId{
			get
			{
				return this.Exist(Meta.UniqueId);
			}
		}

		virtual public void RemoveUniqueId()
		{
			this.Set(Meta.UniqueId, null);
		}


	}
}