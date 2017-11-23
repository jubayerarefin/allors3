// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class EstimatedLaborCost : Allors.IObject , EstimatedProductCost
	{
		private readonly IStrategy strategy;

		public EstimatedLaborCost(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaEstimatedLaborCost Meta
		{
			get
			{
				return Allors.Meta.MetaEstimatedLaborCost.Instance;
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

		public static EstimatedLaborCost Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (EstimatedLaborCost) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Decimal Cost 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Cost.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Cost.RelationType, value);
			}
		}

		virtual public bool ExistCost{
			get
			{
				return Strategy.ExistUnitRole(Meta.Cost.RelationType);
			}
		}

		virtual public void RemoveCost()
		{
			Strategy.RemoveUnitRole(Meta.Cost.RelationType);
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


		virtual public Organisation Organisation
		{ 
			get
			{
				return (Organisation) Strategy.GetCompositeRole(Meta.Organisation.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Organisation.RelationType, value);
			}
		}

		virtual public bool ExistOrganisation
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Organisation.RelationType);
			}
		}

		virtual public void RemoveOrganisation()
		{
			Strategy.RemoveCompositeRole(Meta.Organisation.RelationType);
		}


		virtual public global::System.String Description 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Description.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Description.RelationType, value);
			}
		}

		virtual public bool ExistDescription{
			get
			{
				return Strategy.ExistUnitRole(Meta.Description.RelationType);
			}
		}

		virtual public void RemoveDescription()
		{
			Strategy.RemoveUnitRole(Meta.Description.RelationType);
		}


		virtual public GeographicBoundary GeographicBoundary
		{ 
			get
			{
				return (GeographicBoundary) Strategy.GetCompositeRole(Meta.GeographicBoundary.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.GeographicBoundary.RelationType, value);
			}
		}

		virtual public bool ExistGeographicBoundary
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.GeographicBoundary.RelationType);
			}
		}

		virtual public void RemoveGeographicBoundary()
		{
			Strategy.RemoveCompositeRole(Meta.GeographicBoundary.RelationType);
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



		virtual public Product ProductWhereEstimatedProductCost
		{ 
			get
			{
				return (Product) Strategy.GetCompositeAssociation(Meta.ProductWhereEstimatedProductCost.RelationType);
			}
		} 

		virtual public bool ExistProductWhereEstimatedProductCost
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.ProductWhereEstimatedProductCost.RelationType);
			}
		}


		virtual public ProductFeature ProductFeatureWhereEstimatedProductCost
		{ 
			get
			{
				return (ProductFeature) Strategy.GetCompositeAssociation(Meta.ProductFeatureWhereEstimatedProductCost.RelationType);
			}
		} 

		virtual public bool ExistProductFeatureWhereEstimatedProductCost
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.ProductFeatureWhereEstimatedProductCost.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new EstimatedLaborCostOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new EstimatedLaborCostOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new EstimatedLaborCostOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new EstimatedLaborCostOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new EstimatedLaborCostOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new EstimatedLaborCostOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new EstimatedLaborCostOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new EstimatedLaborCostOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new EstimatedLaborCostOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new EstimatedLaborCostOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class EstimatedLaborCostBuilder : Allors.ObjectBuilder<EstimatedLaborCost> , EstimatedProductCostBuilder, global::System.IDisposable
	{		
		public EstimatedLaborCostBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(EstimatedLaborCost instance)
		{
			

			if(this.Cost.HasValue)
			{
				instance.Cost = this.Cost.Value;
			}			
		
		

			instance.Description = this.Description;
		
		
			

			if(this.FromDate.HasValue)
			{
				instance.FromDate = this.FromDate.Value;
			}			
		
		
			

			if(this.ThroughDate.HasValue)
			{
				instance.ThroughDate = this.ThroughDate.Value;
			}			
		
		

			instance.Currency = this.Currency;

		

			instance.Organisation = this.Organisation;

		

			instance.GeographicBoundary = this.GeographicBoundary;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Decimal? Cost {get; set;}

				/// <exclude/>
				public EstimatedLaborCostBuilder WithCost(global::System.Decimal? value)
		        {
				    if(this.Cost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Cost = value;
		            return this;
		        }	

				public Currency Currency {get; set;}

				/// <exclude/>
				public EstimatedLaborCostBuilder WithCurrency(Currency value)
		        {
		            if(this.Currency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Currency = value;
		            return this;
		        }		

				
				public Organisation Organisation {get; set;}

				/// <exclude/>
				public EstimatedLaborCostBuilder WithOrganisation(Organisation value)
		        {
		            if(this.Organisation!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Organisation = value;
		            return this;
		        }		

				
				public global::System.String Description {get; set;}

				/// <exclude/>
				public EstimatedLaborCostBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public GeographicBoundary GeographicBoundary {get; set;}

				/// <exclude/>
				public EstimatedLaborCostBuilder WithGeographicBoundary(GeographicBoundary value)
		        {
		            if(this.GeographicBoundary!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.GeographicBoundary = value;
		            return this;
		        }		

				
				public global::System.DateTime? FromDate {get; set;}

				/// <exclude/>
				public EstimatedLaborCostBuilder WithFromDate(global::System.DateTime? value)
		        {
				    if(this.FromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDate {get; set;}

				/// <exclude/>
				public EstimatedLaborCostBuilder WithThroughDate(global::System.DateTime? value)
		        {
				    if(this.ThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public EstimatedLaborCostBuilder WithDeniedPermission(Permission value)
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
				public EstimatedLaborCostBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class EstimatedLaborCosts : global::Allors.ObjectsBase<EstimatedLaborCost>
	{
		public EstimatedLaborCosts(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaEstimatedLaborCost Meta
		{
			get
			{
				return Allors.Meta.MetaEstimatedLaborCost.Instance;
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