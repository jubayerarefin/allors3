// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class CreditCard : Allors.IObject , FinancialAccount
	{
		private readonly IStrategy strategy;

		public CreditCard(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaCreditCard Meta
		{
			get
			{
				return Allors.Meta.MetaCreditCard.Instance;
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

		public static CreditCard Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (CreditCard) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.String NameOnCard 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.NameOnCard.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.NameOnCard.RelationType, value);
			}
		}

		virtual public bool ExistNameOnCard{
			get
			{
				return Strategy.ExistUnitRole(Meta.NameOnCard.RelationType);
			}
		}

		virtual public void RemoveNameOnCard()
		{
			Strategy.RemoveUnitRole(Meta.NameOnCard.RelationType);
		}


		virtual public CreditCardCompany CreditCardCompany
		{ 
			get
			{
				return (CreditCardCompany) Strategy.GetCompositeRole(Meta.CreditCardCompany.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CreditCardCompany.RelationType, value);
			}
		}

		virtual public bool ExistCreditCardCompany
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CreditCardCompany.RelationType);
			}
		}

		virtual public void RemoveCreditCardCompany()
		{
			Strategy.RemoveCompositeRole(Meta.CreditCardCompany.RelationType);
		}


		virtual public global::System.Int32 ExpirationYear 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.ExpirationYear.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ExpirationYear.RelationType, value);
			}
		}

		virtual public bool ExistExpirationYear{
			get
			{
				return Strategy.ExistUnitRole(Meta.ExpirationYear.RelationType);
			}
		}

		virtual public void RemoveExpirationYear()
		{
			Strategy.RemoveUnitRole(Meta.ExpirationYear.RelationType);
		}


		virtual public global::System.Int32 ExpirationMonth 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.ExpirationMonth.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ExpirationMonth.RelationType, value);
			}
		}

		virtual public bool ExistExpirationMonth{
			get
			{
				return Strategy.ExistUnitRole(Meta.ExpirationMonth.RelationType);
			}
		}

		virtual public void RemoveExpirationMonth()
		{
			Strategy.RemoveUnitRole(Meta.ExpirationMonth.RelationType);
		}


		virtual public global::System.String CardNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.CardNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.CardNumber.RelationType, value);
			}
		}

		virtual public bool ExistCardNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.CardNumber.RelationType);
			}
		}

		virtual public void RemoveCardNumber()
		{
			Strategy.RemoveUnitRole(Meta.CardNumber.RelationType);
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



		virtual public global::Allors.Extent<OwnCreditCard> OwnCreditCardsWhereCreditCard
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.OwnCreditCardsWhereCreditCard.RelationType);
			}
		}

		virtual public bool ExistOwnCreditCardsWhereCreditCard
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.OwnCreditCardsWhereCreditCard.RelationType);
			}
		}


		virtual public PartyVersion PartyVersionWhereCreditCard
		{ 
			get
			{
				return (PartyVersion) Strategy.GetCompositeAssociation(Meta.PartyVersionWhereCreditCard.RelationType);
			}
		} 

		virtual public bool ExistPartyVersionWhereCreditCard
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PartyVersionWhereCreditCard.RelationType);
			}
		}


		virtual public Party PartyWhereCreditCard
		{ 
			get
			{
				return (Party) Strategy.GetCompositeAssociation(Meta.PartyWhereCreditCard.RelationType);
			}
		} 

		virtual public bool ExistPartyWhereCreditCard
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PartyWhereCreditCard.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new CreditCardOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new CreditCardOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new CreditCardOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new CreditCardOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new CreditCardOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new CreditCardOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new CreditCardOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new CreditCardOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new CreditCardOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new CreditCardOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class CreditCardBuilder : Allors.ObjectBuilder<CreditCard> , FinancialAccountBuilder, global::System.IDisposable
	{		
		public CreditCardBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(CreditCard instance)
		{

			instance.NameOnCard = this.NameOnCard;
		
		
			

			if(this.ExpirationYear.HasValue)
			{
				instance.ExpirationYear = this.ExpirationYear.Value;
			}			
		
		
			

			if(this.ExpirationMonth.HasValue)
			{
				instance.ExpirationMonth = this.ExpirationMonth.Value;
			}			
		
		

			instance.CardNumber = this.CardNumber;
		
		

			instance.CreditCardCompany = this.CreditCardCompany;

		
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


				public global::System.String NameOnCard {get; set;}

				/// <exclude/>
				public CreditCardBuilder WithNameOnCard(global::System.String value)
		        {
				    if(this.NameOnCard!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.NameOnCard = value;
		            return this;
		        }	

				public CreditCardCompany CreditCardCompany {get; set;}

				/// <exclude/>
				public CreditCardBuilder WithCreditCardCompany(CreditCardCompany value)
		        {
		            if(this.CreditCardCompany!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CreditCardCompany = value;
		            return this;
		        }		

				
				public global::System.Int32? ExpirationYear {get; set;}

				/// <exclude/>
				public CreditCardBuilder WithExpirationYear(global::System.Int32? value)
		        {
				    if(this.ExpirationYear!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ExpirationYear = value;
		            return this;
		        }	

				public global::System.Int32? ExpirationMonth {get; set;}

				/// <exclude/>
				public CreditCardBuilder WithExpirationMonth(global::System.Int32? value)
		        {
				    if(this.ExpirationMonth!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ExpirationMonth = value;
		            return this;
		        }	

				public global::System.String CardNumber {get; set;}

				/// <exclude/>
				public CreditCardBuilder WithCardNumber(global::System.String value)
		        {
				    if(this.CardNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.CardNumber = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<FinancialAccountTransaction> FinancialAccountTransactions {get; set;}	

				/// <exclude/>
				public CreditCardBuilder WithFinancialAccountTransaction(FinancialAccountTransaction value)
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
				public CreditCardBuilder WithDeniedPermission(Permission value)
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
				public CreditCardBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class CreditCards : global::Allors.ObjectsBase<CreditCard>
	{
		public CreditCards(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaCreditCard Meta
		{
			get
			{
				return Allors.Meta.MetaCreditCard.Instance;
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