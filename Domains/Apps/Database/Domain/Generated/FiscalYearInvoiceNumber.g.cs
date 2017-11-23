// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class FiscalYearInvoiceNumber : Allors.IObject , Object
	{
		private readonly IStrategy strategy;

		public FiscalYearInvoiceNumber(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaFiscalYearInvoiceNumber Meta
		{
			get
			{
				return Allors.Meta.MetaFiscalYearInvoiceNumber.Instance;
			}
		}

		public long Id
		{
			get { return this.strategy.ObjectId; }
		}

		public IStrategy Strategy
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this.strategy; }
        }

		public static FiscalYearInvoiceNumber Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (FiscalYearInvoiceNumber) allorsSession.Instantiate(allorsObjectId);		
		}

		public override bool Equals(object obj)
        {
            var typedObj = obj as IObject;
            return typedObj != null &&
                   typedObj.Strategy.ObjectId.Equals(this.Strategy.ObjectId) &&
                   typedObj.Strategy.Session.Database.Id.Equals(this.Strategy.Session.Database.Id);
        }

		public override int GetHashCode()
        {
            return this.Strategy.ObjectId.GetHashCode();
        }



		virtual public global::System.Int32 NextSalesInvoiceNumber 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.NextSalesInvoiceNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.NextSalesInvoiceNumber.RelationType, value);
			}
		}

		virtual public bool ExistNextSalesInvoiceNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.NextSalesInvoiceNumber.RelationType);
			}
		}

		virtual public void RemoveNextSalesInvoiceNumber()
		{
			Strategy.RemoveUnitRole(Meta.NextSalesInvoiceNumber.RelationType);
		}


		virtual public global::System.Int32 FiscalYear 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.FiscalYear.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.FiscalYear.RelationType, value);
			}
		}

		virtual public bool ExistFiscalYear{
			get
			{
				return Strategy.ExistUnitRole(Meta.FiscalYear.RelationType);
			}
		}

		virtual public void RemoveFiscalYear()
		{
			Strategy.RemoveUnitRole(Meta.FiscalYear.RelationType);
		}



		virtual public Store StoreWhereFiscalYearInvoiceNumber
		{ 
			get
			{
				return (Store) Strategy.GetCompositeAssociation(Meta.StoreWhereFiscalYearInvoiceNumber.RelationType);
			}
		} 

		virtual public bool ExistStoreWhereFiscalYearInvoiceNumber
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.StoreWhereFiscalYearInvoiceNumber.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new FiscalYearInvoiceNumberOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new FiscalYearInvoiceNumberOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new FiscalYearInvoiceNumberOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new FiscalYearInvoiceNumberOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new FiscalYearInvoiceNumberOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new FiscalYearInvoiceNumberOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new FiscalYearInvoiceNumberOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new FiscalYearInvoiceNumberOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new FiscalYearInvoiceNumberOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new FiscalYearInvoiceNumberOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class FiscalYearInvoiceNumberBuilder : Allors.ObjectBuilder<FiscalYearInvoiceNumber> , ObjectBuilder, global::System.IDisposable
	{		
		public FiscalYearInvoiceNumberBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(FiscalYearInvoiceNumber instance)
		{
		
			

			if(this.FiscalYear.HasValue)
			{
				instance.FiscalYear = this.FiscalYear.Value;
			}			
		
		
		}


				public global::System.Int32? FiscalYear {get; set;}

				/// <exclude/>
				public FiscalYearInvoiceNumberBuilder WithFiscalYear(global::System.Int32? value)
		        {
				    if(this.FiscalYear!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FiscalYear = value;
		            return this;
		        }	


	}

	public partial class FiscalYearInvoiceNumbers : global::Allors.ObjectsBase<FiscalYearInvoiceNumber>
	{
		public FiscalYearInvoiceNumbers(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaFiscalYearInvoiceNumber Meta
		{
			get
			{
				return Allors.Meta.MetaFiscalYearInvoiceNumber.Instance;
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