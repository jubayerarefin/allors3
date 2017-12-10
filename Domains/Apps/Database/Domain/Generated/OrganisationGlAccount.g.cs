// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class OrganisationGlAccount : Allors.IObject , AccessControlledObject, Period
	{
		private readonly IStrategy strategy;

		public OrganisationGlAccount(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaOrganisationGlAccount Meta
		{
			get
			{
				return Allors.Meta.MetaOrganisationGlAccount.Instance;
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

		public static OrganisationGlAccount Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (OrganisationGlAccount) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Product Product
		{ 
			get
			{
				return (Product) Strategy.GetCompositeRole(Meta.Product.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Product.RelationType, value);
			}
		}

		virtual public bool ExistProduct
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Product.RelationType);
			}
		}

		virtual public void RemoveProduct()
		{
			Strategy.RemoveCompositeRole(Meta.Product.RelationType);
		}


		virtual public OrganisationGlAccount Parent
		{ 
			get
			{
				return (OrganisationGlAccount) Strategy.GetCompositeRole(Meta.Parent.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Parent.RelationType, value);
			}
		}

		virtual public bool ExistParent
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Parent.RelationType);
			}
		}

		virtual public void RemoveParent()
		{
			Strategy.RemoveCompositeRole(Meta.Parent.RelationType);
		}


		virtual public Party Party
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.Party.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Party.RelationType, value);
			}
		}

		virtual public bool ExistParty
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Party.RelationType);
			}
		}

		virtual public void RemoveParty()
		{
			Strategy.RemoveCompositeRole(Meta.Party.RelationType);
		}


		virtual public global::System.Boolean HasBankStatementTransactions 
		{
			get
			{
				return (global::System.Boolean) Strategy.GetUnitRole(Meta.HasBankStatementTransactions.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.HasBankStatementTransactions.RelationType, value);
			}
		}

		virtual public bool ExistHasBankStatementTransactions{
			get
			{
				return Strategy.ExistUnitRole(Meta.HasBankStatementTransactions.RelationType);
			}
		}

		virtual public void RemoveHasBankStatementTransactions()
		{
			Strategy.RemoveUnitRole(Meta.HasBankStatementTransactions.RelationType);
		}


		virtual public ProductCategory ProductCategory
		{ 
			get
			{
				return (ProductCategory) Strategy.GetCompositeRole(Meta.ProductCategory.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ProductCategory.RelationType, value);
			}
		}

		virtual public bool ExistProductCategory
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ProductCategory.RelationType);
			}
		}

		virtual public void RemoveProductCategory()
		{
			Strategy.RemoveCompositeRole(Meta.ProductCategory.RelationType);
		}


		virtual public GeneralLedgerAccount GeneralLedgerAccount
		{ 
			get
			{
				return (GeneralLedgerAccount) Strategy.GetCompositeRole(Meta.GeneralLedgerAccount.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.GeneralLedgerAccount.RelationType, value);
			}
		}

		virtual public bool ExistGeneralLedgerAccount
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.GeneralLedgerAccount.RelationType);
			}
		}

		virtual public void RemoveGeneralLedgerAccount()
		{
			Strategy.RemoveCompositeRole(Meta.GeneralLedgerAccount.RelationType);
		}


		virtual public global::Allors.Extent<Permission> DeniedPermissions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.DeniedPermissions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.DeniedPermissions.RelationType, value);
			}
		}

		virtual public void AddDeniedPermission (Permission value)
		{
			Strategy.AddCompositeRole(Meta.DeniedPermissions.RelationType, value);
		}

		virtual public void RemoveDeniedPermission (Permission value)
		{
			Strategy.RemoveCompositeRole(Meta.DeniedPermissions.RelationType, value);
		}

		virtual public bool ExistDeniedPermissions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.DeniedPermissions.RelationType);
			}
		}

		virtual public void RemoveDeniedPermissions()
		{
			Strategy.RemoveCompositeRoles(Meta.DeniedPermissions.RelationType);
		}


		virtual public global::Allors.Extent<SecurityToken> SecurityTokens
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.SecurityTokens.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.SecurityTokens.RelationType, value);
			}
		}

		virtual public void AddSecurityToken (SecurityToken value)
		{
			Strategy.AddCompositeRole(Meta.SecurityTokens.RelationType, value);
		}

		virtual public void RemoveSecurityToken (SecurityToken value)
		{
			Strategy.RemoveCompositeRole(Meta.SecurityTokens.RelationType, value);
		}

		virtual public bool ExistSecurityTokens
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.SecurityTokens.RelationType);
			}
		}

		virtual public void RemoveSecurityTokens()
		{
			Strategy.RemoveCompositeRoles(Meta.SecurityTokens.RelationType);
		}


		virtual public global::System.DateTime FromDate 
		{
			get
			{
				return (global::System.DateTime) Strategy.GetUnitRole(Meta.FromDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.FromDate.RelationType, value);
			}
		}

		virtual public bool ExistFromDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.FromDate.RelationType);
			}
		}

		virtual public void RemoveFromDate()
		{
			Strategy.RemoveUnitRole(Meta.FromDate.RelationType);
		}


		virtual public global::System.DateTime? ThroughDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.ThroughDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ThroughDate.RelationType, value);
			}
		}

		virtual public bool ExistThroughDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.ThroughDate.RelationType);
			}
		}

		virtual public void RemoveThroughDate()
		{
			Strategy.RemoveUnitRole(Meta.ThroughDate.RelationType);
		}



		virtual public global::Allors.Extent<CostCenter> CostCentersWhereInternalTransferGlAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.CostCentersWhereInternalTransferGlAccount.RelationType);
			}
		}

		virtual public bool ExistCostCentersWhereInternalTransferGlAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.CostCentersWhereInternalTransferGlAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<CostCenter> CostCentersWhereRedistributedCostsGlAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.CostCentersWhereRedistributedCostsGlAccount.RelationType);
			}
		}

		virtual public bool ExistCostCentersWhereRedistributedCostsGlAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.CostCentersWhereRedistributedCostsGlAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<Journal> JournalsWhereGlPaymentInTransit
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.JournalsWhereGlPaymentInTransit.RelationType);
			}
		}

		virtual public bool ExistJournalsWhereGlPaymentInTransit
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.JournalsWhereGlPaymentInTransit.RelationType);
			}
		}


		virtual public Journal JournalWhereContraAccount
		{ 
			get
			{
				return (Journal) Strategy.GetCompositeAssociation(Meta.JournalWhereContraAccount.RelationType);
			}
		} 

		virtual public bool ExistJournalWhereContraAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.JournalWhereContraAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<Journal> JournalsWherePreviousContraAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.JournalsWherePreviousContraAccount.RelationType);
			}
		}

		virtual public bool ExistJournalsWherePreviousContraAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.JournalsWherePreviousContraAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<JournalEntryDetail> JournalEntryDetailsWhereGeneralLedgerAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.JournalEntryDetailsWhereGeneralLedgerAccount.RelationType);
			}
		}

		virtual public bool ExistJournalEntryDetailsWhereGeneralLedgerAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.JournalEntryDetailsWhereGeneralLedgerAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<OrganisationGlAccount> OrganisationGlAccountsWhereParent
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.OrganisationGlAccountsWhereParent.RelationType);
			}
		}

		virtual public bool ExistOrganisationGlAccountsWhereParent
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.OrganisationGlAccountsWhereParent.RelationType);
			}
		}


		virtual public global::Allors.Extent<OrganisationGlAccountBalance> OrganisationGlAccountBalancesWhereOrganisationGlAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.OrganisationGlAccountBalancesWhereOrganisationGlAccount.RelationType);
			}
		}

		virtual public bool ExistOrganisationGlAccountBalancesWhereOrganisationGlAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.OrganisationGlAccountBalancesWhereOrganisationGlAccount.RelationType);
			}
		}


		virtual public VatRate VatRateWhereVatPayableAccount
		{ 
			get
			{
				return (VatRate) Strategy.GetCompositeAssociation(Meta.VatRateWhereVatPayableAccount.RelationType);
			}
		} 

		virtual public bool ExistVatRateWhereVatPayableAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.VatRateWhereVatPayableAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<VatRate> VatRatesWhereVatToPayAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.VatRatesWhereVatToPayAccount.RelationType);
			}
		}

		virtual public bool ExistVatRatesWhereVatToPayAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.VatRatesWhereVatToPayAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<VatRate> VatRatesWhereVatToReceiveAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.VatRatesWhereVatToReceiveAccount.RelationType);
			}
		}

		virtual public bool ExistVatRatesWhereVatToReceiveAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.VatRatesWhereVatToReceiveAccount.RelationType);
			}
		}


		virtual public VatRate VatRateWhereVatReceivableAccount
		{ 
			get
			{
				return (VatRate) Strategy.GetCompositeAssociation(Meta.VatRateWhereVatReceivableAccount.RelationType);
			}
		} 

		virtual public bool ExistVatRateWhereVatReceivableAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.VatRateWhereVatReceivableAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<VatRegime> VatRegimesWhereGeneralLedgerAccount
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.VatRegimesWhereGeneralLedgerAccount.RelationType);
			}
		}

		virtual public bool ExistVatRegimesWhereGeneralLedgerAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.VatRegimesWhereGeneralLedgerAccount.RelationType);
			}
		}


		virtual public global::Allors.Extent<PaymentMethod> PaymentMethodsWhereGlPaymentInTransit
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PaymentMethodsWhereGlPaymentInTransit.RelationType);
			}
		}

		virtual public bool ExistPaymentMethodsWhereGlPaymentInTransit
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PaymentMethodsWhereGlPaymentInTransit.RelationType);
			}
		}


		virtual public PaymentMethod PaymentMethodWhereGeneralLedgerAccount
		{ 
			get
			{
				return (PaymentMethod) Strategy.GetCompositeAssociation(Meta.PaymentMethodWhereGeneralLedgerAccount.RelationType);
			}
		} 

		virtual public bool ExistPaymentMethodWhereGeneralLedgerAccount
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PaymentMethodWhereGeneralLedgerAccount.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new OrganisationGlAccountOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new OrganisationGlAccountOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new OrganisationGlAccountOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new OrganisationGlAccountOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new OrganisationGlAccountOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new OrganisationGlAccountOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new OrganisationGlAccountOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new OrganisationGlAccountOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new OrganisationGlAccountOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new OrganisationGlAccountOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class OrganisationGlAccountBuilder : Allors.ObjectBuilder<OrganisationGlAccount> , AccessControlledObjectBuilder, PeriodBuilder, global::System.IDisposable
	{		
		public OrganisationGlAccountBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(OrganisationGlAccount instance)
		{
		
			

			if(this.FromDate.HasValue)
			{
				instance.FromDate = this.FromDate.Value;
			}			
		
		
			

			if(this.ThroughDate.HasValue)
			{
				instance.ThroughDate = this.ThroughDate.Value;
			}			
		
		

			instance.Product = this.Product;

		

			instance.Parent = this.Parent;

		

			instance.Party = this.Party;

		

			instance.ProductCategory = this.ProductCategory;

		

			instance.GeneralLedgerAccount = this.GeneralLedgerAccount;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Product Product {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBuilder WithProduct(Product value)
		        {
		            if(this.Product!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Product = value;
		            return this;
		        }		

				
				public OrganisationGlAccount Parent {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBuilder WithParent(OrganisationGlAccount value)
		        {
		            if(this.Parent!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Parent = value;
		            return this;
		        }		

				
				public Party Party {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBuilder WithParty(Party value)
		        {
		            if(this.Party!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Party = value;
		            return this;
		        }		

				
				public ProductCategory ProductCategory {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBuilder WithProductCategory(ProductCategory value)
		        {
		            if(this.ProductCategory!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ProductCategory = value;
		            return this;
		        }		

				
				public GeneralLedgerAccount GeneralLedgerAccount {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBuilder WithGeneralLedgerAccount(GeneralLedgerAccount value)
		        {
		            if(this.GeneralLedgerAccount!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.GeneralLedgerAccount = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public OrganisationGlAccountBuilder WithDeniedPermission(Permission value)
		        {
					if(this.DeniedPermissions == null)
					{
						this.DeniedPermissions = new global::System.Collections.Generic.List<Permission>(); 
					}
		            this.DeniedPermissions.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<SecurityToken> SecurityTokens {get; set;}	

				/// <exclude/>
				public OrganisationGlAccountBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				
				public global::System.DateTime? FromDate {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBuilder WithFromDate(global::System.DateTime? value)
		        {
				    if(this.FromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDate {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBuilder WithThroughDate(global::System.DateTime? value)
		        {
				    if(this.ThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDate = value;
		            return this;
		        }	


	}

	public partial class OrganisationGlAccounts : global::Allors.ObjectsBase<OrganisationGlAccount>
	{
		public OrganisationGlAccounts(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaOrganisationGlAccount Meta
		{
			get
			{
				return Allors.Meta.MetaOrganisationGlAccount.Instance;
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