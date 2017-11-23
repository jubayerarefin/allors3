// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Workspace.Domain
{
	public partial class OrderLineVersion : SessionObject , Version
	{
		public OrderLineVersion(Session session)
		: base(session)
		{
		}

		public Allors.Workspace.Meta.MetaOrderLineVersion Meta
		{
			get
			{
				return Allors.Workspace.Meta.MetaOrderLineVersion.Instance;
			}
		}

		public static OrderLineVersion Instantiate (Session allorsSession, long allorsObjectId)
		{
			return (OrderLineVersion) allorsSession.Get(allorsObjectId);		
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


		public bool CanReadDerivationTimeStamp 
		{
			get
			{
				return this.CanRead(this.Meta.DerivationTimeStamp);
			}
		}

		public bool CanWriteDerivationTimeStamp 
		{
			get
			{
				return this.CanWrite(this.Meta.DerivationTimeStamp);
			}
		}



		virtual public global::System.DateTime? DerivationTimeStamp 
		{
			get
			{
				return (global::System.DateTime?) this.Get(Meta.DerivationTimeStamp);
			}
			set
			{
				this.Set(Meta.DerivationTimeStamp, value);
			}
		}

		virtual public bool ExistDerivationTimeStamp{
			get
			{
				return this.Exist(Meta.DerivationTimeStamp);
			}
		}

		virtual public void RemoveDerivationTimeStamp()
		{
			this.Set(Meta.DerivationTimeStamp, null);
		}


	}
}