// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class InvestmentAccount : Allors.IObject , FinancialAccount
	{
		private readonly IStrategy strategy;

		public InvestmentAccount(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaInvestmentAccount Meta
		{
			get
			{
				return Allors.Meta.MetaInvestmentAccount.Instance;
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

		public static InvestmentAccount Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (InvestmentAccount) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.String Name 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Name.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Name.RelationType, value);
			}
		}

		virtual public bool ExistName{
			get
			{
				return Strategy.ExistUnitRole(Meta.Name.RelationType);
			}
		}

		virtual public void RemoveName()
		{
			Strategy.RemoveUnitRole(Meta.Name.RelationType);
		}


		virtual public global::Allors.Extent<FinancialAccountTransaction> FinancialAccountTransactions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.FinancialAccountTransactions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.FinancialAccountTransactions.RelationType, value);
			}
		}

		virtual public void AddFinancialAccountTransaction (FinancialAccountTransaction value)
		{
			Strategy.AddCompositeRole(Meta.FinancialAccountTransactions.RelationType, value);
		}

		virtual public void RemoveFinancialAccountTransaction (FinancialAccountTransaction value)
		{
			Strategy.RemoveCompositeRole(Meta.FinancialAccountTransactions.RelationType, value);
		}

		virtual public bool ExistFinancialAccountTransactions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.FinancialAccountTransactions.RelationType);
			}
		}

		virtual public void RemoveFinancialAccountTransactions()
		{
			Strategy.RemoveCompositeRoles(Meta.FinancialAccountTransactions.RelationType);
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



		public ObjectOnBuild OnBuild()
		{ 
			var method = new InvestmentAccountOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new InvestmentAccountOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new InvestmentAccountOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new InvestmentAccountOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new InvestmentAccountOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new InvestmentAccountOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new InvestmentAccountOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new InvestmentAccountOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new InvestmentAccountOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new InvestmentAccountOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class InvestmentAccountBuilder : Allors.ObjectBuilder<InvestmentAccount> , FinancialAccountBuilder, global::System.IDisposable
	{		
		public InvestmentAccountBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(InvestmentAccount instance)
		{

			instance.Name = this.Name;
		
		
			if(this.FinancialAccountTransactions!=null)
			{
				instance.FinancialAccountTransactions = this.FinancialAccountTransactions.ToArray();
			}
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.String Name {get; set;}

				/// <exclude/>
				public InvestmentAccountBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<FinancialAccountTransaction> FinancialAccountTransactions {get; set;}	

				/// <exclude/>
				public InvestmentAccountBuilder WithFinancialAccountTransaction(FinancialAccountTransaction value)
		        {
					if(this.FinancialAccountTransactions == null)
					{
						this.FinancialAccountTransactions = new global::System.Collections.Generic.List<FinancialAccountTransaction>(); 
					}
		            this.FinancialAccountTransactions.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public InvestmentAccountBuilder WithDeniedPermission(Permission value)
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
				public InvestmentAccountBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class InvestmentAccounts : global::Allors.ObjectsBase<InvestmentAccount>
	{
		public InvestmentAccounts(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaInvestmentAccount Meta
		{
			get
			{
				return Allors.Meta.MetaInvestmentAccount.Instance;
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