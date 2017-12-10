// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Size : Allors.IObject , Enumeration, ProductFeature
	{
		private readonly IStrategy strategy;

		public Size(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSize Meta
		{
			get
			{
				return Allors.Meta.MetaSize.Instance;
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

		public static Size Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Size) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::Allors.Extent<LocalisedText> LocalisedNames
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.LocalisedNames.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.LocalisedNames.RelationType, value);
			}
		}

		virtual public void AddLocalisedName (LocalisedText value)
		{
			Strategy.AddCompositeRole(Meta.LocalisedNames.RelationType, value);
		}

		virtual public void RemoveLocalisedName (LocalisedText value)
		{
			Strategy.RemoveCompositeRole(Meta.LocalisedNames.RelationType, value);
		}

		virtual public bool ExistLocalisedNames
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.LocalisedNames.RelationType);
			}
		}

		virtual public void RemoveLocalisedNames()
		{
			Strategy.RemoveCompositeRoles(Meta.LocalisedNames.RelationType);
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


		virtual public global::System.Boolean IsActive 
		{
			get
			{
				return (global::System.Boolean) Strategy.GetUnitRole(Meta.IsActive.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.IsActive.RelationType, value);
			}
		}

		virtual public bool ExistIsActive{
			get
			{
				return Strategy.ExistUnitRole(Meta.IsActive.RelationType);
			}
		}

		virtual public void RemoveIsActive()
		{
			Strategy.RemoveUnitRole(Meta.IsActive.RelationType);
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


		virtual public global::System.Guid UniqueId 
		{
			get
			{
				return (global::System.Guid) Strategy.GetUnitRole(Meta.UniqueId.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.UniqueId.RelationType, value);
			}
		}

		virtual public bool ExistUniqueId{
			get
			{
				return Strategy.ExistUnitRole(Meta.UniqueId.RelationType);
			}
		}

		virtual public void RemoveUniqueId()
		{
			Strategy.RemoveUnitRole(Meta.UniqueId.RelationType);
		}


		virtual public global::Allors.Extent<EstimatedProductCost> EstimatedProductCosts
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.EstimatedProductCosts.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.EstimatedProductCosts.RelationType, value);
			}
		}

		virtual public void AddEstimatedProductCost (EstimatedProductCost value)
		{
			Strategy.AddCompositeRole(Meta.EstimatedProductCosts.RelationType, value);
		}

		virtual public void RemoveEstimatedProductCost (EstimatedProductCost value)
		{
			Strategy.RemoveCompositeRole(Meta.EstimatedProductCosts.RelationType, value);
		}

		virtual public bool ExistEstimatedProductCosts
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.EstimatedProductCosts.RelationType);
			}
		}

		virtual public void RemoveEstimatedProductCosts()
		{
			Strategy.RemoveCompositeRoles(Meta.EstimatedProductCosts.RelationType);
		}


		virtual public global::Allors.Extent<PriceComponent> BasePrices
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.BasePrices.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.BasePrices.RelationType, value);
			}
		}

		virtual public void AddBasePrice (PriceComponent value)
		{
			Strategy.AddCompositeRole(Meta.BasePrices.RelationType, value);
		}

		virtual public void RemoveBasePrice (PriceComponent value)
		{
			Strategy.RemoveCompositeRole(Meta.BasePrices.RelationType, value);
		}

		virtual public bool ExistBasePrices
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.BasePrices.RelationType);
			}
		}

		virtual public void RemoveBasePrices()
		{
			Strategy.RemoveCompositeRoles(Meta.BasePrices.RelationType);
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


		virtual public global::Allors.Extent<ProductFeature> DependentFeatures
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.DependentFeatures.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.DependentFeatures.RelationType, value);
			}
		}

		virtual public void AddDependentFeature (ProductFeature value)
		{
			Strategy.AddCompositeRole(Meta.DependentFeatures.RelationType, value);
		}

		virtual public void RemoveDependentFeature (ProductFeature value)
		{
			Strategy.RemoveCompositeRole(Meta.DependentFeatures.RelationType, value);
		}

		virtual public bool ExistDependentFeatures
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.DependentFeatures.RelationType);
			}
		}

		virtual public void RemoveDependentFeatures()
		{
			Strategy.RemoveCompositeRoles(Meta.DependentFeatures.RelationType);
		}


		virtual public global::Allors.Extent<ProductFeature> IncompatibleFeatures
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.IncompatibleFeatures.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.IncompatibleFeatures.RelationType, value);
			}
		}

		virtual public void AddIncompatibleFeature (ProductFeature value)
		{
			Strategy.AddCompositeRole(Meta.IncompatibleFeatures.RelationType, value);
		}

		virtual public void RemoveIncompatibleFeature (ProductFeature value)
		{
			Strategy.RemoveCompositeRole(Meta.IncompatibleFeatures.RelationType, value);
		}

		virtual public bool ExistIncompatibleFeatures
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.IncompatibleFeatures.RelationType);
			}
		}

		virtual public void RemoveIncompatibleFeatures()
		{
			Strategy.RemoveCompositeRoles(Meta.IncompatibleFeatures.RelationType);
		}


		virtual public VatRate VatRate
		{ 
			get
			{
				return (VatRate) Strategy.GetCompositeRole(Meta.VatRate.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.VatRate.RelationType, value);
			}
		}

		virtual public bool ExistVatRate
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.VatRate.RelationType);
			}
		}

		virtual public void RemoveVatRate()
		{
			Strategy.RemoveCompositeRole(Meta.VatRate.RelationType);
		}



		virtual public global::Allors.Extent<Notification> NotificationsWhereTarget
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}

		virtual public bool ExistNotificationsWhereTarget
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}


		virtual public global::Allors.Extent<DesiredProductFeature> DesiredProductFeaturesWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.DesiredProductFeaturesWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistDesiredProductFeaturesWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.DesiredProductFeaturesWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<QuoteItemVersion> QuoteItemVersionsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.QuoteItemVersionsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistQuoteItemVersionsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.QuoteItemVersionsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<RequestItemVersion> RequestItemVersionsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestItemVersionsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistRequestItemVersionsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestItemVersionsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesInvoiceItemVersion> SalesInvoiceItemVersionsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesInvoiceItemVersionsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistSalesInvoiceItemVersionsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesInvoiceItemVersionsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesOrderItemVersion> SalesOrderItemVersionsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesOrderItemVersionsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistSalesOrderItemVersionsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesOrderItemVersionsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<ProductFeatureApplicabilityRelationship> ProductFeatureApplicabilityRelationshipsWhereUsedToDefine
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductFeatureApplicabilityRelationshipsWhereUsedToDefine.RelationType);
			}
		}

		virtual public bool ExistProductFeatureApplicabilityRelationshipsWhereUsedToDefine
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductFeatureApplicabilityRelationshipsWhereUsedToDefine.RelationType);
			}
		}


		virtual public global::Allors.Extent<QuoteItem> QuoteItemsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.QuoteItemsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistQuoteItemsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.QuoteItemsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<RequestItem> RequestItemsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestItemsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistRequestItemsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestItemsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesInvoiceItem> SalesInvoiceItemsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesInvoiceItemsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistSalesInvoiceItemsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesInvoiceItemsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesOrderItem> SalesOrderItemsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesOrderItemsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistSalesOrderItemsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesOrderItemsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<ShipmentItem> ShipmentItemsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ShipmentItemsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistShipmentItemsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ShipmentItemsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<EngagementItem> EngagementItemsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EngagementItemsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistEngagementItemsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EngagementItemsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<PriceComponent> PriceComponentsWhereProductFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PriceComponentsWhereProductFeature.RelationType);
			}
		}

		virtual public bool ExistPriceComponentsWhereProductFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PriceComponentsWhereProductFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<Product> ProductsWhereOptionalFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductsWhereOptionalFeature.RelationType);
			}
		}

		virtual public bool ExistProductsWhereOptionalFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductsWhereOptionalFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<Product> ProductsWhereStandardFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductsWhereStandardFeature.RelationType);
			}
		}

		virtual public bool ExistProductsWhereStandardFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductsWhereStandardFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<Product> ProductsWhereSelectableFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductsWhereSelectableFeature.RelationType);
			}
		}

		virtual public bool ExistProductsWhereSelectableFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductsWhereSelectableFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<ProductFeature> ProductFeaturesWhereDependentFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductFeaturesWhereDependentFeature.RelationType);
			}
		}

		virtual public bool ExistProductFeaturesWhereDependentFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductFeaturesWhereDependentFeature.RelationType);
			}
		}


		virtual public global::Allors.Extent<ProductFeature> ProductFeaturesWhereIncompatibleFeature
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductFeaturesWhereIncompatibleFeature.RelationType);
			}
		}

		virtual public bool ExistProductFeaturesWhereIncompatibleFeature
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductFeaturesWhereIncompatibleFeature.RelationType);
			}
		}



		public SizeDelete Delete()
		{ 
			var method = new SizeDelete(this);
            method.Execute();
            return method;
		}

		public SizeDelete Delete(System.Action<SizeDelete> action)
		{ 
			var method = new SizeDelete(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild()
		{ 
			var method = new SizeOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SizeOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SizeOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SizeOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SizeOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SizeOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SizeOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SizeOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SizeOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SizeOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SizeBuilder : Allors.ObjectBuilder<Size> , EnumerationBuilder, ProductFeatureBuilder, global::System.IDisposable
	{		
		public SizeBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Size instance)
		{

			instance.Name = this.Name;
		
		
			

			if(this.IsActive.HasValue)
			{
				instance.IsActive = this.IsActive.Value;
			}			
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		

			instance.Description = this.Description;
		
		
			if(this.LocalisedNames!=null)
			{
				instance.LocalisedNames = this.LocalisedNames.ToArray();
			}
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
			if(this.EstimatedProductCosts!=null)
			{
				instance.EstimatedProductCosts = this.EstimatedProductCosts.ToArray();
			}
				
			if(this.DependentFeatures!=null)
			{
				instance.DependentFeatures = this.DependentFeatures.ToArray();
			}
		
			if(this.IncompatibleFeatures!=null)
			{
				instance.IncompatibleFeatures = this.IncompatibleFeatures.ToArray();
			}
		

			instance.VatRate = this.VatRate;

		
		}


				public global::System.Collections.Generic.List<LocalisedText> LocalisedNames {get; set;}	

				/// <exclude/>
				public SizeBuilder WithLocalisedName(LocalisedText value)
		        {
					if(this.LocalisedNames == null)
					{
						this.LocalisedNames = new global::System.Collections.Generic.List<LocalisedText>(); 
					}
		            this.LocalisedNames.Add(value);
		            return this;
		        }		

				
				public global::System.String Name {get; set;}

				/// <exclude/>
				public SizeBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.Boolean? IsActive {get; set;}

				/// <exclude/>
				public SizeBuilder WithIsActive(global::System.Boolean? value)
		        {
				    if(this.IsActive!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IsActive = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SizeBuilder WithDeniedPermission(Permission value)
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
				public SizeBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				
				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public SizeBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<EstimatedProductCost> EstimatedProductCosts {get; set;}	

				/// <exclude/>
				public SizeBuilder WithEstimatedProductCost(EstimatedProductCost value)
		        {
					if(this.EstimatedProductCosts == null)
					{
						this.EstimatedProductCosts = new global::System.Collections.Generic.List<EstimatedProductCost>(); 
					}
		            this.EstimatedProductCosts.Add(value);
		            return this;
		        }		

				
				public global::System.String Description {get; set;}

				/// <exclude/>
				public SizeBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<ProductFeature> DependentFeatures {get; set;}	

				/// <exclude/>
				public SizeBuilder WithDependentFeature(ProductFeature value)
		        {
					if(this.DependentFeatures == null)
					{
						this.DependentFeatures = new global::System.Collections.Generic.List<ProductFeature>(); 
					}
		            this.DependentFeatures.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<ProductFeature> IncompatibleFeatures {get; set;}	

				/// <exclude/>
				public SizeBuilder WithIncompatibleFeature(ProductFeature value)
		        {
					if(this.IncompatibleFeatures == null)
					{
						this.IncompatibleFeatures = new global::System.Collections.Generic.List<ProductFeature>(); 
					}
		            this.IncompatibleFeatures.Add(value);
		            return this;
		        }		

				
				public VatRate VatRate {get; set;}

				/// <exclude/>
				public SizeBuilder WithVatRate(VatRate value)
		        {
		            if(this.VatRate!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.VatRate = value;
		            return this;
		        }		

				

	}

	public partial class Sizes : global::Allors.ObjectsBase<Size>
	{
		public Sizes(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSize Meta
		{
			get
			{
				return Allors.Meta.MetaSize.Instance;
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