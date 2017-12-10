// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface ExternalAccountingTransaction :  AccountingTransaction, Allors.IObject
	{


		Party FromParty
		{ 
			get;
			set;
		}

		bool ExistFromParty
		{
			get;
		}

		void RemoveFromParty();


		Party ToParty
		{ 
			get;
			set;
		}

		bool ExistToParty
		{
			get;
		}

		void RemoveToParty();

	}

	public partial interface ExternalAccountingTransactionBuilder : AccountingTransactionBuilder , global::System.IDisposable
	{	
		Party FromParty {get;}

		

		Party ToParty {get;}

		

	}

	public partial class ExternalAccountingTransactions : global::Allors.ObjectsBase<ExternalAccountingTransaction>
	{
		public ExternalAccountingTransactions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaExternalAccountingTransaction Meta
		{
			get
			{
				return Allors.Meta.MetaExternalAccountingTransaction.Instance;
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