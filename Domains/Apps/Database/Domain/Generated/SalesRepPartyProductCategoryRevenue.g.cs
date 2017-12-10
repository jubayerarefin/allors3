// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class SalesRepPartyProductCategoryRevenue : Allors.IObject , AccessControlledObject, Deletable
	{
		private readonly IStrategy strategy;

		public SalesRepPartyProductCategoryRevenue(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSalesRepPartyProductCategoryRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaSalesRepPartyProductCategoryRevenue.Instance;
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

		public static SalesRepPartyProductCategoryRevenue Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (SalesRepPartyProductCategoryRevenue) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public Person SalesRep
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.SalesRep.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.SalesRep.RelationType, value);
			}
		}

		virtual public bool ExistSalesRep
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.SalesRep.RelationType);
			}
		}

		virtual public void RemoveSalesRep()
		{
			Strategy.RemoveCompositeRole(Meta.SalesRep.RelationType);
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


		virtual public global::System.String SalesRepName 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.SalesRepName.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.SalesRepName.RelationType, value);
			}
		}

		virtual public bool ExistSalesRepName{
			get
			{
				return Strategy.ExistUnitRole(Meta.SalesRepName.RelationType);
			}
		}

		virtual public void RemoveSalesRepName()
		{
			Strategy.RemoveUnitRole(Meta.SalesRepName.RelationType);
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
			var method = new SalesRepPartyProductCategoryRevenueOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SalesRepPartyProductCategoryRevenueOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new SalesRepPartyProductCategoryRevenueDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new SalesRepPartyProductCategoryRevenueDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SalesRepPartyProductCategoryRevenueBuilder : Allors.ObjectBuilder<SalesRepPartyProductCategoryRevenue> , AccessControlledObjectBuilder, DeletableBuilder, global::System.IDisposable
	{		
		public SalesRepPartyProductCategoryRevenueBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(SalesRepPartyProductCategoryRevenue instance)
		{
			

			if(this.Year.HasValue)
			{
				instance.Year = this.Year.Value;
			}			
		
		
			

			if(this.Month.HasValue)
			{
				instance.Month = this.Month.Value;
			}			
		
		
			

			if(this.Revenue.HasValue)
			{
				instance.Revenue = this.Revenue.Value;
			}			
		
		

			instance.SalesRepName = this.SalesRepName;
		
		

			instance.SalesRep = this.SalesRep;

		

			instance.ProductCategory = this.ProductCategory;

		

			instance.Party = this.Party;

		

			instance.Currency = this.Currency;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Int32? Year {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithYear(global::System.Int32? value)
		        {
				    if(this.Year!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Year = value;
		            return this;
		        }	

				public Person SalesRep {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithSalesRep(Person value)
		        {
		            if(this.SalesRep!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.SalesRep = value;
		            return this;
		        }		

				
				public ProductCategory ProductCategory {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithProductCategory(ProductCategory value)
		        {
		            if(this.ProductCategory!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ProductCategory = value;
		            return this;
		        }		

				
				public global::System.Int32? Month {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithMonth(global::System.Int32? value)
		        {
				    if(this.Month!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Month = value;
		            return this;
		        }	

				public Party Party {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithParty(Party value)
		        {
		            if(this.Party!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Party = value;
		            return this;
		        }		

				
				public global::System.Decimal? Revenue {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithRevenue(global::System.Decimal? value)
		        {
				    if(this.Revenue!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Revenue = value;
		            return this;
		        }	

				public Currency Currency {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithCurrency(Currency value)
		        {
		            if(this.Currency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Currency = value;
		            return this;
		        }		

				
				public global::System.String SalesRepName {get; set;}

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithSalesRepName(global::System.String value)
		        {
				    if(this.SalesRepName!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.SalesRepName = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SalesRepPartyProductCategoryRevenueBuilder WithDeniedPermission(Permission value)
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
				public SalesRepPartyProductCategoryRevenueBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class SalesRepPartyProductCategoryRevenues : global::Allors.ObjectsBase<SalesRepPartyProductCategoryRevenue>
	{
		public SalesRepPartyProductCategoryRevenues(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSalesRepPartyProductCategoryRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaSalesRepPartyProductCategoryRevenue.Instance;
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