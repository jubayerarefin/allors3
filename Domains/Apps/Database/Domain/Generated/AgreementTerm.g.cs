// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface AgreementTerm :  AccessControlledObject, Allors.IObject
	{


		global::System.String TermValue 
		{
			get;
			set;
		}

		bool ExistTermValue{get;}

		void RemoveTermValue();


		TermType TermType
		{ 
			get;
			set;
		}

		bool ExistTermType
		{
			get;
		}

		void RemoveTermType();


		global::System.String Description 
		{
			get;
			set;
		}

		bool ExistDescription{get;}

		void RemoveDescription();



		Agreement AgreementWhereAgreementTerm
		{
			get;
		}

		bool ExistAgreementWhereAgreementTerm
		{
			get;
		}


		AgreementItem AgreementItemWhereAgreementTerm
		{
			get;
		}

		bool ExistAgreementItemWhereAgreementTerm
		{
			get;
		}


		global::Allors.Extent<InvoiceItemVersion> InvoiceItemVersionsWhereInvoiceTerm
		{ 
			get;
		}

		bool ExistInvoiceItemVersionsWhereInvoiceTerm
		{
			get;
		}


		InvoiceItem InvoiceItemWhereInvoiceTerm
		{
			get;
		}

		bool ExistInvoiceItemWhereInvoiceTerm
		{
			get;
		}

	}

	public partial interface AgreementTermBuilder : AccessControlledObjectBuilder , global::System.IDisposable
	{	
		global::System.String TermValue {get;}
		

		TermType TermType {get;}

		

		global::System.String Description {get;}
		

	}

	public partial class AgreementTerms : global::Allors.ObjectsBase<AgreementTerm>
	{
		public AgreementTerms(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaAgreementTerm Meta
		{
			get
			{
				return Allors.Meta.MetaAgreementTerm.Instance;
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