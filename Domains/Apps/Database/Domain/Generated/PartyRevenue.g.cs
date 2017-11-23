// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class PartyRevenue : Allors.IObject , AccessControlledObject, Deletable
	{
		private readonly IStrategy strategy;

		public PartyRevenue(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPartyRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaPartyRevenue.Instance;
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

		public static PartyRevenue Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (PartyRevenue) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Currency Currency
		{ 
			get
			{
				return (Currency) Strategy.GetCompositeRole(Meta.Currency.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Currency.RelationType, value);
			}
		}

		virtual public bool ExistCurrency
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Currency.RelationType);
			}
		}

		virtual public void RemoveCurrency()
		{
			Strategy.RemoveCompositeRole(Meta.Currency.RelationType);
		}


		virtual public global::System.Int32 Month 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.Month.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Month.RelationType, value);
			}
		}

		virtual public bool ExistMonth{
			get
			{
				return Strategy.ExistUnitRole(Meta.Month.RelationType);
			}
		}

		virtual public void RemoveMonth()
		{
			Strategy.RemoveUnitRole(Meta.Month.RelationType);
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


		virtual public global::System.Int32 Year 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.Year.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Year.RelationType, value);
			}
		}

		virtual public bool ExistYear{
			get
			{
				return Strategy.ExistUnitRole(Meta.Year.RelationType);
			}
		}

		virtual public void RemoveYear()
		{
			Strategy.RemoveUnitRole(Meta.Year.RelationType);
		}


		virtual public global::System.Decimal Revenue 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Revenue.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Revenue.RelationType, value);
			}
		}

		virtual public bool ExistRevenue{
			get
			{
				return Strategy.ExistUnitRole(Meta.Revenue.RelationType);
			}
		}

		virtual public void RemoveRevenue()
		{
			Strategy.RemoveUnitRole(Meta.Revenue.RelationType);
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
			var method = new PartyRevenueOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PartyRevenueOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PartyRevenueOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PartyRevenueOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PartyRevenueOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PartyRevenueOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PartyRevenueOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PartyRevenueOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PartyRevenueOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PartyRevenueOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new PartyRevenueDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new PartyRevenueDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PartyRevenueBuilder : Allors.ObjectBuilder<PartyRevenue> , AccessControlledObjectBuilder, DeletableBuilder, global::System.IDisposable
	{		
		public PartyRevenueBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(PartyRevenue instance)
		{
			

			if(this.Month.HasValue)
			{
				instance.Month = this.Month.Value;
			}			
		
		
			

			if(this.Year.HasValue)
			{
				instance.Year = this.Year.Value;
			}			
		
		
			

			if(this.Revenue.HasValue)
			{
				instance.Revenue = this.Revenue.Value;
			}			
		
		

			instance.Currency = this.Currency;

		

			instance.Party = this.Party;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Currency Currency {get; set;}

				/// <exclude/>
				public PartyRevenueBuilder WithCurrency(Currency value)
		        {
		            if(this.Currency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Currency = value;
		            return this;
		        }		

				
				public global::System.Int32? Month {get; set;}

				/// <exclude/>
				public PartyRevenueBuilder WithMonth(global::System.Int32? value)
		        {
				    if(this.Month!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Month = value;
		            return this;
		        }	

				public Party Party {get; set;}

				/// <exclude/>
				public PartyRevenueBuilder WithParty(Party value)
		        {
		            if(this.Party!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Party = value;
		            return this;
		        }		

				
				public global::System.Int32? Year {get; set;}

				/// <exclude/>
				public PartyRevenueBuilder WithYear(global::System.Int32? value)
		        {
				    if(this.Year!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Year = value;
		            return this;
		        }	

				public global::System.Decimal? Revenue {get; set;}

				/// <exclude/>
				public PartyRevenueBuilder WithRevenue(global::System.Decimal? value)
		        {
				    if(this.Revenue!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Revenue = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PartyRevenueBuilder WithDeniedPermission(Permission value)
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
				public PartyRevenueBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class PartyRevenues : global::Allors.ObjectsBase<PartyRevenue>
	{
		public PartyRevenues(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPartyRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaPartyRevenue.Instance;
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