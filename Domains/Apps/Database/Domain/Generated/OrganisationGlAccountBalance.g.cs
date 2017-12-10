// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class OrganisationGlAccountBalance : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public OrganisationGlAccountBalance(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaOrganisationGlAccountBalance Meta
		{
			get
			{
				return Allors.Meta.MetaOrganisationGlAccountBalance.Instance;
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

		public static OrganisationGlAccountBalance Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (OrganisationGlAccountBalance) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public OrganisationGlAccount OrganisationGlAccount
		{ 
			get
			{
				return (OrganisationGlAccount) Strategy.GetCompositeRole(Meta.OrganisationGlAccount.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.OrganisationGlAccount.RelationType, value);
			}
		}

		virtual public bool ExistOrganisationGlAccount
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.OrganisationGlAccount.RelationType);
			}
		}

		virtual public void RemoveOrganisationGlAccount()
		{
			Strategy.RemoveCompositeRole(Meta.OrganisationGlAccount.RelationType);
		}


		virtual public global::System.Decimal Amount 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Amount.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Amount.RelationType, value);
			}
		}

		virtual public bool ExistAmount{
			get
			{
				return Strategy.ExistUnitRole(Meta.Amount.RelationType);
			}
		}

		virtual public void RemoveAmount()
		{
			Strategy.RemoveUnitRole(Meta.Amount.RelationType);
		}


		virtual public AccountingPeriod AccountingPeriod
		{ 
			get
			{
				return (AccountingPeriod) Strategy.GetCompositeRole(Meta.AccountingPeriod.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.AccountingPeriod.RelationType, value);
			}
		}

		virtual public bool ExistAccountingPeriod
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.AccountingPeriod.RelationType);
			}
		}

		virtual public void RemoveAccountingPeriod()
		{
			Strategy.RemoveCompositeRole(Meta.AccountingPeriod.RelationType);
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



		virtual public global::Allors.Extent<AccountingTransactionDetail> AccountingTransactionDetailsWhereOrganisationGlAccountBalance
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.AccountingTransactionDetailsWhereOrganisationGlAccountBalance.RelationType);
			}
		}

		virtual public bool ExistAccountingTransactionDetailsWhereOrganisationGlAccountBalance
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.AccountingTransactionDetailsWhereOrganisationGlAccountBalance.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new OrganisationGlAccountBalanceOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new OrganisationGlAccountBalanceOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new OrganisationGlAccountBalanceOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new OrganisationGlAccountBalanceOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new OrganisationGlAccountBalanceOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new OrganisationGlAccountBalanceOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new OrganisationGlAccountBalanceOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new OrganisationGlAccountBalanceOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new OrganisationGlAccountBalanceOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new OrganisationGlAccountBalanceOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class OrganisationGlAccountBalanceBuilder : Allors.ObjectBuilder<OrganisationGlAccountBalance> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public OrganisationGlAccountBalanceBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(OrganisationGlAccountBalance instance)
		{
			

			if(this.Amount.HasValue)
			{
				instance.Amount = this.Amount.Value;
			}			
		
		

			instance.OrganisationGlAccount = this.OrganisationGlAccount;

		

			instance.AccountingPeriod = this.AccountingPeriod;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public OrganisationGlAccount OrganisationGlAccount {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBalanceBuilder WithOrganisationGlAccount(OrganisationGlAccount value)
		        {
		            if(this.OrganisationGlAccount!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.OrganisationGlAccount = value;
		            return this;
		        }		

				
				public global::System.Decimal? Amount {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBalanceBuilder WithAmount(global::System.Decimal? value)
		        {
				    if(this.Amount!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Amount = value;
		            return this;
		        }	

				public AccountingPeriod AccountingPeriod {get; set;}

				/// <exclude/>
				public OrganisationGlAccountBalanceBuilder WithAccountingPeriod(AccountingPeriod value)
		        {
		            if(this.AccountingPeriod!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.AccountingPeriod = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public OrganisationGlAccountBalanceBuilder WithDeniedPermission(Permission value)
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
				public OrganisationGlAccountBalanceBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class OrganisationGlAccountBalances : global::Allors.ObjectsBase<OrganisationGlAccountBalance>
	{
		public OrganisationGlAccountBalances(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaOrganisationGlAccountBalance Meta
		{
			get
			{
				return Allors.Meta.MetaOrganisationGlAccountBalance.Instance;
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