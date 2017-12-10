// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface ShipmentVersion :  Version, Allors.IObject
	{


		ShipmentMethod ShipmentMethod
		{ 
			get;
			set;
		}

		bool ExistShipmentMethod
		{
			get;
		}

		void RemoveShipmentMethod();


		ContactMechanism BillToContactMechanism
		{ 
			get;
			set;
		}

		bool ExistBillToContactMechanism
		{
			get;
		}

		void RemoveBillToContactMechanism();


		global::Allors.Extent<ShipmentPackage> ShipmentPackages
		{ 
			get;
			set;
		}

		void AddShipmentPackage (ShipmentPackage value);

		void RemoveShipmentPackage (ShipmentPackage value);

		bool ExistShipmentPackages
		{
			get;
		}

		void RemoveShipmentPackages();


		global::System.String ShipmentNumber 
		{
			get;
			set;
		}

		bool ExistShipmentNumber{get;}

		void RemoveShipmentNumber();


		global::Allors.Extent<Document> Documents
		{ 
			get;
			set;
		}

		void AddDocument (Document value);

		void RemoveDocument (Document value);

		bool ExistDocuments
		{
			get;
		}

		void RemoveDocuments();


		Party BillToParty
		{ 
			get;
			set;
		}

		bool ExistBillToParty
		{
			get;
		}

		void RemoveBillToParty();


		Party ShipToParty
		{ 
			get;
			set;
		}

		bool ExistShipToParty
		{
			get;
		}

		void RemoveShipToParty();


		global::Allors.Extent<ShipmentItem> ShipmentItems
		{ 
			get;
			set;
		}

		void AddShipmentItem (ShipmentItem value);

		void RemoveShipmentItem (ShipmentItem value);

		bool ExistShipmentItems
		{
			get;
		}

		void RemoveShipmentItems();


		ContactMechanism ReceiverContactMechanism
		{ 
			get;
			set;
		}

		bool ExistReceiverContactMechanism
		{
			get;
		}

		void RemoveReceiverContactMechanism();


		PostalAddress ShipToAddress
		{ 
			get;
			set;
		}

		bool ExistShipToAddress
		{
			get;
		}

		void RemoveShipToAddress();


		global::System.Decimal? EstimatedShipCost 
		{
			get;
			set;
		}

		bool ExistEstimatedShipCost{get;}

		void RemoveEstimatedShipCost();


		global::System.DateTime? EstimatedShipDate 
		{
			get;
			set;
		}

		bool ExistEstimatedShipDate{get;}

		void RemoveEstimatedShipDate();


		global::System.DateTime? LatestCancelDate 
		{
			get;
			set;
		}

		bool ExistLatestCancelDate{get;}

		void RemoveLatestCancelDate();


		Carrier Carrier
		{ 
			get;
			set;
		}

		bool ExistCarrier
		{
			get;
		}

		void RemoveCarrier();


		ContactMechanism InquireAboutContactMechanism
		{ 
			get;
			set;
		}

		bool ExistInquireAboutContactMechanism
		{
			get;
		}

		void RemoveInquireAboutContactMechanism();


		global::System.DateTime? EstimatedReadyDate 
		{
			get;
			set;
		}

		bool ExistEstimatedReadyDate{get;}

		void RemoveEstimatedReadyDate();


		PostalAddress ShipFromAddress
		{ 
			get;
			set;
		}

		bool ExistShipFromAddress
		{
			get;
		}

		void RemoveShipFromAddress();


		ContactMechanism BillFromContactMechanism
		{ 
			get;
			set;
		}

		bool ExistBillFromContactMechanism
		{
			get;
		}

		void RemoveBillFromContactMechanism();


		global::System.String HandlingInstruction 
		{
			get;
			set;
		}

		bool ExistHandlingInstruction{get;}

		void RemoveHandlingInstruction();


		Store Store
		{ 
			get;
			set;
		}

		bool ExistStore
		{
			get;
		}

		void RemoveStore();


		Party ShipFromParty
		{ 
			get;
			set;
		}

		bool ExistShipFromParty
		{
			get;
		}

		void RemoveShipFromParty();


		global::Allors.Extent<ShipmentRouteSegment> ShipmentRouteSegments
		{ 
			get;
			set;
		}

		void AddShipmentRouteSegment (ShipmentRouteSegment value);

		void RemoveShipmentRouteSegment (ShipmentRouteSegment value);

		bool ExistShipmentRouteSegments
		{
			get;
		}

		void RemoveShipmentRouteSegments();


		global::System.DateTime? EstimatedArrivalDate 
		{
			get;
			set;
		}

		bool ExistEstimatedArrivalDate{get;}

		void RemoveEstimatedArrivalDate();

	}

	public partial interface ShipmentVersionBuilder : VersionBuilder , global::System.IDisposable
	{	
		ShipmentMethod ShipmentMethod {get;}

		

		ContactMechanism BillToContactMechanism {get;}

		


		global::System.Collections.Generic.List<ShipmentPackage> ShipmentPackages {get;}		

		

		global::System.String ShipmentNumber {get;}
		


		global::System.Collections.Generic.List<Document> Documents {get;}		

		

		Party BillToParty {get;}

		

		Party ShipToParty {get;}

		


		global::System.Collections.Generic.List<ShipmentItem> ShipmentItems {get;}		

		

		ContactMechanism ReceiverContactMechanism {get;}

		

		PostalAddress ShipToAddress {get;}

		

		global::System.Decimal? EstimatedShipCost {get;}
		

		global::System.DateTime? EstimatedShipDate {get;}
		

		global::System.DateTime? LatestCancelDate {get;}
		

		Carrier Carrier {get;}

		

		ContactMechanism InquireAboutContactMechanism {get;}

		

		global::System.DateTime? EstimatedReadyDate {get;}
		

		PostalAddress ShipFromAddress {get;}

		

		global::System.String HandlingInstruction {get;}
		

		Store Store {get;}

		

		Party ShipFromParty {get;}

		


		global::System.Collections.Generic.List<ShipmentRouteSegment> ShipmentRouteSegments {get;}		

		

		global::System.DateTime? EstimatedArrivalDate {get;}
		

	}

	public partial class ShipmentVersions : global::Allors.ObjectsBase<ShipmentVersion>
	{
		public ShipmentVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaShipmentVersion Meta
		{
			get
			{
				return Allors.Meta.MetaShipmentVersion.Instance;
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