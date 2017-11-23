// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class UnitOfMeasure : Allors.IObject , IUnitOfMeasure, Enumeration
	{
		private readonly IStrategy strategy;

		public UnitOfMeasure(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaUnitOfMeasure Meta
		{
			get
			{
				return Allors.Meta.MetaUnitOfMeasure.Instance;
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

		public static UnitOfMeasure Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (UnitOfMeasure) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public global::Allors.Extent<UnitOfMeasureConversion> UnitOfMeasureConversions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.UnitOfMeasureConversions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.UnitOfMeasureConversions.RelationType, value);
			}
		}

		virtual public void AddUnitOfMeasureConversion (UnitOfMeasureConversion value)
		{
			Strategy.AddCompositeRole(Meta.UnitOfMeasureConversions.RelationType, value);
		}

		virtual public void RemoveUnitOfMeasureConversion (UnitOfMeasureConversion value)
		{
			Strategy.RemoveCompositeRole(Meta.UnitOfMeasureConversions.RelationType, value);
		}

		virtual public bool ExistUnitOfMeasureConversions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.UnitOfMeasureConversions.RelationType);
			}
		}

		virtual public void RemoveUnitOfMeasureConversions()
		{
			Strategy.RemoveCompositeRoles(Meta.UnitOfMeasureConversions.RelationType);
		}


		virtual public global::System.String Abbreviation 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Abbreviation.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Abbreviation.RelationType, value);
			}
		}

		virtual public bool ExistAbbreviation{
			get
			{
				return Strategy.ExistUnitRole(Meta.Abbreviation.RelationType);
			}
		}

		virtual public void RemoveAbbreviation()
		{
			Strategy.RemoveUnitRole(Meta.Abbreviation.RelationType);
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



		virtual public global::Allors.Extent<ActivityUsage> ActivityUsagesWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ActivityUsagesWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistActivityUsagesWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ActivityUsagesWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<Dimension> DimensionsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.DimensionsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistDimensionsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.DimensionsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<EngagementRate> EngagementRatesWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EngagementRatesWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistEngagementRatesWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EngagementRatesWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<QuoteItemVersion> QuoteItemVersionsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.QuoteItemVersionsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistQuoteItemVersionsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.QuoteItemVersionsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<RequestItemVersion> RequestItemVersionsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestItemVersionsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistRequestItemVersionsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestItemVersionsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<ProductPurchasePrice> ProductPurchasePricesWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductPurchasePricesWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistProductPurchasePricesWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductPurchasePricesWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<QuoteItem> QuoteItemsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.QuoteItemsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistQuoteItemsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.QuoteItemsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<RequestItem> RequestItemsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestItemsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistRequestItemsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestItemsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<TimeEntry> TimeEntriesWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TimeEntriesWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistTimeEntriesWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TimeEntriesWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<UtilizationCharge> UtilizationChargesWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.UtilizationChargesWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistUtilizationChargesWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.UtilizationChargesWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<VolumeUsage> VolumeUsagesWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.VolumeUsagesWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistVolumeUsagesWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.VolumeUsagesWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<InventoryItemVersion> InventoryItemVersionsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InventoryItemVersionsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistInventoryItemVersionsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InventoryItemVersionsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<InventoryItem> InventoryItemsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InventoryItemsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistInventoryItemsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InventoryItemsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<Part> PartsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistPartsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<Product> ProductsWhereUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductsWhereUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistProductsWhereUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductsWhereUnitOfMeasure.RelationType);
			}
		}


		virtual public global::Allors.Extent<UnitOfMeasureConversion> UnitOfMeasureConversionsWhereToUnitOfMeasure
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.UnitOfMeasureConversionsWhereToUnitOfMeasure.RelationType);
			}
		}

		virtual public bool ExistUnitOfMeasureConversionsWhereToUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.UnitOfMeasureConversionsWhereToUnitOfMeasure.RelationType);
			}
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



		public UnitOfMeasureDelete Delete()
		{ 
			var method = new UnitOfMeasureDelete(this);
            method.Execute();
            return method;
		}

		public UnitOfMeasureDelete Delete(System.Action<UnitOfMeasureDelete> action)
		{ 
			var method = new UnitOfMeasureDelete(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild()
		{ 
			var method = new UnitOfMeasureOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new UnitOfMeasureOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new UnitOfMeasureOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new UnitOfMeasureOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new UnitOfMeasureOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new UnitOfMeasureOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new UnitOfMeasureOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new UnitOfMeasureOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new UnitOfMeasureOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new UnitOfMeasureOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class UnitOfMeasureBuilder : Allors.ObjectBuilder<UnitOfMeasure> , IUnitOfMeasureBuilder, EnumerationBuilder, global::System.IDisposable
	{		
		public UnitOfMeasureBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(UnitOfMeasure instance)
		{

			instance.Description = this.Description;
		
		

			instance.Abbreviation = this.Abbreviation;
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		

			instance.Name = this.Name;
		
		
			

			if(this.IsActive.HasValue)
			{
				instance.IsActive = this.IsActive.Value;
			}			
		
		
			if(this.UnitOfMeasureConversions!=null)
			{
				instance.UnitOfMeasureConversions = this.UnitOfMeasureConversions.ToArray();
			}
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
			if(this.LocalisedNames!=null)
			{
				instance.LocalisedNames = this.LocalisedNames.ToArray();
			}
		
		}


				public global::System.String Description {get; set;}

				/// <exclude/>
				public UnitOfMeasureBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<UnitOfMeasureConversion> UnitOfMeasureConversions {get; set;}	

				/// <exclude/>
				public UnitOfMeasureBuilder WithUnitOfMeasureConversion(UnitOfMeasureConversion value)
		        {
					if(this.UnitOfMeasureConversions == null)
					{
						this.UnitOfMeasureConversions = new global::System.Collections.Generic.List<UnitOfMeasureConversion>(); 
					}
		            this.UnitOfMeasureConversions.Add(value);
		            return this;
		        }		

				
				public global::System.String Abbreviation {get; set;}

				/// <exclude/>
				public UnitOfMeasureBuilder WithAbbreviation(global::System.String value)
		        {
				    if(this.Abbreviation!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Abbreviation = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public UnitOfMeasureBuilder WithDeniedPermission(Permission value)
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
				public UnitOfMeasureBuilder WithSecurityToken(SecurityToken value)
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
				public UnitOfMeasureBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<LocalisedText> LocalisedNames {get; set;}	

				/// <exclude/>
				public UnitOfMeasureBuilder WithLocalisedName(LocalisedText value)
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
				public UnitOfMeasureBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.Boolean? IsActive {get; set;}

				/// <exclude/>
				public UnitOfMeasureBuilder WithIsActive(global::System.Boolean? value)
		        {
				    if(this.IsActive!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IsActive = value;
		            return this;
		        }	


	}

	public partial class UnitsOfMeasure : global::Allors.ObjectsBase<UnitOfMeasure>
	{
		public UnitsOfMeasure(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaUnitOfMeasure Meta
		{
			get
			{
				return Allors.Meta.MetaUnitOfMeasure.Instance;
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