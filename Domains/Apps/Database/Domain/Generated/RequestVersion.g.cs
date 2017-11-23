// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface RequestVersion :  Version, Allors.IObject
	{


		RequestState RequestState
		{ 
			get;
			set;
		}

		bool ExistRequestState
		{
			get;
		}

		void RemoveRequestState();


		global::System.String InternalComment 
		{
			get;
			set;
		}

		bool ExistInternalComment{get;}

		void RemoveInternalComment();


		global::System.String Description 
		{
			get;
			set;
		}

		bool ExistDescription{get;}

		void RemoveDescription();


		global::System.DateTime RequestDate 
		{
			get;
			set;
		}

		bool ExistRequestDate{get;}

		void RemoveRequestDate();


		global::System.DateTime? RequiredResponseDate 
		{
			get;
			set;
		}

		bool ExistRequiredResponseDate{get;}

		void RemoveRequiredResponseDate();


		global::Allors.Extent<RequestItem> RequestItems
		{ 
			get;
			set;
		}

		void AddRequestItem (RequestItem value);

		void RemoveRequestItem (RequestItem value);

		bool ExistRequestItems
		{
			get;
		}

		void RemoveRequestItems();


		global::System.String RequestNumber 
		{
			get;
			set;
		}

		bool ExistRequestNumber{get;}

		void RemoveRequestNumber();


		global::Allors.Extent<RespondingParty> RespondingParties
		{ 
			get;
			set;
		}

		void AddRespondingParty (RespondingParty value);

		void RemoveRespondingParty (RespondingParty value);

		bool ExistRespondingParties
		{
			get;
		}

		void RemoveRespondingParties();


		Party Originator
		{ 
			get;
			set;
		}

		bool ExistOriginator
		{
			get;
		}

		void RemoveOriginator();


		Currency Currency
		{ 
			get;
			set;
		}

		bool ExistCurrency
		{
			get;
		}

		void RemoveCurrency();


		ContactMechanism FullfillContactMechanism
		{ 
			get;
			set;
		}

		bool ExistFullfillContactMechanism
		{
			get;
		}

		void RemoveFullfillContactMechanism();


		global::System.String EmailAddress 
		{
			get;
			set;
		}

		bool ExistEmailAddress{get;}

		void RemoveEmailAddress();


		global::System.String TelephoneNumber 
		{
			get;
			set;
		}

		bool ExistTelephoneNumber{get;}

		void RemoveTelephoneNumber();


		global::System.String TelephoneCountryCode 
		{
			get;
			set;
		}

		bool ExistTelephoneCountryCode{get;}

		void RemoveTelephoneCountryCode();

	}

	public partial interface RequestVersionBuilder : VersionBuilder , global::System.IDisposable
	{	
		RequestState RequestState {get;}

		

		global::System.String InternalComment {get;}
		

		global::System.String Description {get;}
		

		global::System.DateTime? RequestDate {get;}
		

		global::System.DateTime? RequiredResponseDate {get;}
		


		global::System.Collections.Generic.List<RequestItem> RequestItems {get;}		

		

		global::System.String RequestNumber {get;}
		


		global::System.Collections.Generic.List<RespondingParty> RespondingParties {get;}		

		

		Party Originator {get;}

		

		Currency Currency {get;}

		

		ContactMechanism FullfillContactMechanism {get;}

		

		global::System.String EmailAddress {get;}
		

		global::System.String TelephoneNumber {get;}
		

		global::System.String TelephoneCountryCode {get;}
		

	}

	public partial class RequestVersions : global::Allors.ObjectsBase<RequestVersion>
	{
		public RequestVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaRequestVersion Meta
		{
			get
			{
				return Allors.Meta.MetaRequestVersion.Instance;
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