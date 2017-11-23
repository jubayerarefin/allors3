// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface ServiceEntry :  Commentable,AccessControlledObject, Allors.IObject
	{


		global::System.DateTime? ThroughDateTime 
		{
			get;
			set;
		}

		bool ExistThroughDateTime{get;}

		void RemoveThroughDateTime();


		EngagementItem EngagementItem
		{ 
			get;
			set;
		}

		bool ExistEngagementItem
		{
			get;
		}

		void RemoveEngagementItem();


		global::System.Boolean? IsBillable 
		{
			get;
			set;
		}

		bool ExistIsBillable{get;}

		void RemoveIsBillable();


		global::System.DateTime? FromDateTime 
		{
			get;
			set;
		}

		bool ExistFromDateTime{get;}

		void RemoveFromDateTime();


		global::System.String Description 
		{
			get;
			set;
		}

		bool ExistDescription{get;}

		void RemoveDescription();


		WorkEffort WorkEffort
		{ 
			get;
			set;
		}

		bool ExistWorkEffort
		{
			get;
		}

		void RemoveWorkEffort();



		global::Allors.Extent<ServiceEntryBilling> ServiceEntryBillingsWhereServiceEntry
		{ 
			get;
		}

		bool ExistServiceEntryBillingsWhereServiceEntry
		{
			get;
		}


		ServiceEntryHeader ServiceEntryHeaderWhereServiceEntry
		{
			get;
		}

		bool ExistServiceEntryHeaderWhereServiceEntry
		{
			get;
		}

	}

	public partial interface ServiceEntryBuilder : CommentableBuilder ,AccessControlledObjectBuilder , global::System.IDisposable
	{	
		global::System.DateTime? ThroughDateTime {get;}
		

		EngagementItem EngagementItem {get;}

		

		global::System.Boolean? IsBillable {get;}
		

		global::System.DateTime? FromDateTime {get;}
		

		global::System.String Description {get;}
		

		WorkEffort WorkEffort {get;}

		

	}

	public partial class ServiceEntries : global::Allors.ObjectsBase<ServiceEntry>
	{
		public ServiceEntries(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaServiceEntry Meta
		{
			get
			{
				return Allors.Meta.MetaServiceEntry.Instance;
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