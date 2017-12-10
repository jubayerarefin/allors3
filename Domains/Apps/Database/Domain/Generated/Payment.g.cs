// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface Payment :  AccessControlledObject,Commentable,UniquelyIdentifiable, Allors.IObject
	{


		global::System.Decimal Amount 
		{
			get;
			set;
		}

		bool ExistAmount{get;}

		void RemoveAmount();


		PaymentMethod PaymentMethod
		{ 
			get;
			set;
		}

		bool ExistPaymentMethod
		{
			get;
		}

		void RemovePaymentMethod();


		global::System.DateTime EffectiveDate 
		{
			get;
			set;
		}

		bool ExistEffectiveDate{get;}

		void RemoveEffectiveDate();


		Party SendingParty
		{ 
			get;
			set;
		}

		bool ExistSendingParty
		{
			get;
		}

		void RemoveSendingParty();


		global::Allors.Extent<PaymentApplication> PaymentApplications
		{ 
			get;
			set;
		}

		void AddPaymentApplication (PaymentApplication value);

		void RemovePaymentApplication (PaymentApplication value);

		bool ExistPaymentApplications
		{
			get;
		}

		void RemovePaymentApplications();


		global::System.String ReferenceNumber 
		{
			get;
			set;
		}

		bool ExistReferenceNumber{get;}

		void RemoveReferenceNumber();


		Party ReceivingParty
		{ 
			get;
			set;
		}

		bool ExistReceivingParty
		{
			get;
		}

		void RemoveReceivingParty();



		global::Allors.Extent<PaymentBudgetAllocation> PaymentBudgetAllocationsWherePayment
		{ 
			get;
		}

		bool ExistPaymentBudgetAllocationsWherePayment
		{
			get;
		}

	}

	public partial interface PaymentBuilder : AccessControlledObjectBuilder ,CommentableBuilder ,UniquelyIdentifiableBuilder , global::System.IDisposable
	{	
		global::System.Decimal? Amount {get;}
		

		PaymentMethod PaymentMethod {get;}

		

		global::System.DateTime? EffectiveDate {get;}
		

		Party SendingParty {get;}

		


		global::System.Collections.Generic.List<PaymentApplication> PaymentApplications {get;}		

		

		global::System.String ReferenceNumber {get;}
		

		Party ReceivingParty {get;}

		

	}

	public partial class Payments : global::Allors.ObjectsBase<Payment>
	{
		public Payments(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPayment Meta
		{
			get
			{
				return Allors.Meta.MetaPayment.Instance;
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