// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class SubAssembly : Allors.IObject , Part
	{
		private readonly IStrategy strategy;

		public SubAssembly(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSubAssembly Meta
		{
			get
			{
				return Allors.Meta.MetaSubAssembly.Instance;
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

		public static SubAssembly Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (SubAssembly) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public global::Allors.Extent<PartSpecification> PartSpecifications
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.PartSpecifications.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PartSpecifications.RelationType, value);
			}
		}

		virtual public void AddPartSpecification (PartSpecification value)
		{
			Strategy.AddCompositeRole(Meta.PartSpecifications.RelationType, value);
		}

		virtual public void RemovePartSpecification (PartSpecification value)
		{
			Strategy.RemoveCompositeRole(Meta.PartSpecifications.RelationType, value);
		}

		virtual public bool ExistPartSpecifications
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PartSpecifications.RelationType);
			}
		}

		virtual public void RemovePartSpecifications()
		{
			Strategy.RemoveCompositeRoles(Meta.PartSpecifications.RelationType);
		}


		virtual public UnitOfMeasure UnitOfMeasure
		{ 
			get
			{
				return (UnitOfMeasure) Strategy.GetCompositeRole(Meta.UnitOfMeasure.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.UnitOfMeasure.RelationType, value);
			}
		}

		virtual public bool ExistUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.UnitOfMeasure.RelationType);
			}
		}

		virtual public void RemoveUnitOfMeasure()
		{
			Strategy.RemoveCompositeRole(Meta.UnitOfMeasure.RelationType);
		}


		virtual public global::Allors.Extent<Document> Documents
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Documents.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Documents.RelationType, value);
			}
		}

		virtual public void AddDocument (Document value)
		{
			Strategy.AddCompositeRole(Meta.Documents.RelationType, value);
		}

		virtual public void RemoveDocument (Document value)
		{
			Strategy.RemoveCompositeRole(Meta.Documents.RelationType, value);
		}

		virtual public bool ExistDocuments
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Documents.RelationType);
			}
		}

		virtual public void RemoveDocuments()
		{
			Strategy.RemoveCompositeRoles(Meta.Documents.RelationType);
		}


		virtual public global::System.String ManufacturerId 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.ManufacturerId.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ManufacturerId.RelationType, value);
			}
		}

		virtual public bool ExistManufacturerId{
			get
			{
				return Strategy.ExistUnitRole(Meta.ManufacturerId.RelationType);
			}
		}

		virtual public void RemoveManufacturerId()
		{
			Strategy.RemoveUnitRole(Meta.ManufacturerId.RelationType);
		}


		virtual public global::System.Int32? ReorderLevel 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.ReorderLevel.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ReorderLevel.RelationType, value);
			}
		}

		virtual public bool ExistReorderLevel{
			get
			{
				return Strategy.ExistUnitRole(Meta.ReorderLevel.RelationType);
			}
		}

		virtual public void RemoveReorderLevel()
		{
			Strategy.RemoveUnitRole(Meta.ReorderLevel.RelationType);
		}


		virtual public global::System.Int32? ReorderQuantity 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.ReorderQuantity.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ReorderQuantity.RelationType, value);
			}
		}

		virtual public bool ExistReorderQuantity{
			get
			{
				return Strategy.ExistUnitRole(Meta.ReorderQuantity.RelationType);
			}
		}

		virtual public void RemoveReorderQuantity()
		{
			Strategy.RemoveUnitRole(Meta.ReorderQuantity.RelationType);
		}


		virtual public global::Allors.Extent<PriceComponent> PriceComponents
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.PriceComponents.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PriceComponents.RelationType, value);
			}
		}

		virtual public void AddPriceComponent (PriceComponent value)
		{
			Strategy.AddCompositeRole(Meta.PriceComponents.RelationType, value);
		}

		virtual public void RemovePriceComponent (PriceComponent value)
		{
			Strategy.RemoveCompositeRole(Meta.PriceComponents.RelationType, value);
		}

		virtual public bool ExistPriceComponents
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PriceComponents.RelationType);
			}
		}

		virtual public void RemovePriceComponents()
		{
			Strategy.RemoveCompositeRoles(Meta.PriceComponents.RelationType);
		}


		virtual public InventoryItemKind InventoryItemKind
		{ 
			get
			{
				return (InventoryItemKind) Strategy.GetCompositeRole(Meta.InventoryItemKind.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.InventoryItemKind.RelationType, value);
			}
		}

		virtual public bool ExistInventoryItemKind
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.InventoryItemKind.RelationType);
			}
		}

		virtual public void RemoveInventoryItemKind()
		{
			Strategy.RemoveCompositeRole(Meta.InventoryItemKind.RelationType);
		}


		virtual public global::System.String Sku 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Sku.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Sku.RelationType, value);
			}
		}

		virtual public bool ExistSku{
			get
			{
				return Strategy.ExistUnitRole(Meta.Sku.RelationType);
			}
		}

		virtual public void RemoveSku()
		{
			Strategy.RemoveUnitRole(Meta.Sku.RelationType);
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



		virtual public global::Allors.Extent<PurchaseInvoiceItemVersion> PurchaseInvoiceItemVersionsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PurchaseInvoiceItemVersionsWherePart.RelationType);
			}
		}

		virtual public bool ExistPurchaseInvoiceItemVersionsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PurchaseInvoiceItemVersionsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PurchaseOrderItemVersion> PurchaseOrderItemVersionsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PurchaseOrderItemVersionsWherePart.RelationType);
			}
		}

		virtual public bool ExistPurchaseOrderItemVersionsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PurchaseOrderItemVersionsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PartRevision> PartRevisionsWhereSupersededByPart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartRevisionsWhereSupersededByPart.RelationType);
			}
		}

		virtual public bool ExistPartRevisionsWhereSupersededByPart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartRevisionsWhereSupersededByPart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PartRevision> PartRevisionsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartRevisionsWherePart.RelationType);
			}
		}

		virtual public bool ExistPartRevisionsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartRevisionsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PartSubstitute> PartSubstitutesWhereSubstitutionPart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartSubstitutesWhereSubstitutionPart.RelationType);
			}
		}

		virtual public bool ExistPartSubstitutesWhereSubstitutionPart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartSubstitutesWhereSubstitutionPart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PartSubstitute> PartSubstitutesWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartSubstitutesWherePart.RelationType);
			}
		}

		virtual public bool ExistPartSubstitutesWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartSubstitutesWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PurchaseInvoiceItem> PurchaseInvoiceItemsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PurchaseInvoiceItemsWherePart.RelationType);
			}
		}

		virtual public bool ExistPurchaseInvoiceItemsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PurchaseInvoiceItemsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PurchaseOrderItem> PurchaseOrderItemsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PurchaseOrderItemsWherePart.RelationType);
			}
		}

		virtual public bool ExistPurchaseOrderItemsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PurchaseOrderItemsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<ShipmentItem> ShipmentItemsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ShipmentItemsWherePart.RelationType);
			}
		}

		virtual public bool ExistShipmentItemsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ShipmentItemsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<SupplierOffering> SupplierOfferingsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SupplierOfferingsWherePart.RelationType);
			}
		}

		virtual public bool ExistSupplierOfferingsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SupplierOfferingsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortPartStandard> WorkEffortPartStandardsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortPartStandardsWherePart.RelationType);
			}
		}

		virtual public bool ExistWorkEffortPartStandardsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortPartStandardsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<InventoryItemVersion> InventoryItemVersionsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InventoryItemVersionsWherePart.RelationType);
			}
		}

		virtual public bool ExistInventoryItemVersionsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InventoryItemVersionsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<InventoryItem> InventoryItemsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InventoryItemsWherePart.RelationType);
			}
		}

		virtual public bool ExistInventoryItemsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InventoryItemsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PartBillOfMaterial> PartBillOfMaterialsWherePart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartBillOfMaterialsWherePart.RelationType);
			}
		}

		virtual public bool ExistPartBillOfMaterialsWherePart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartBillOfMaterialsWherePart.RelationType);
			}
		}


		virtual public global::Allors.Extent<PartBillOfMaterial> PartBillOfMaterialsWhereComponentPart
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartBillOfMaterialsWhereComponentPart.RelationType);
			}
		}

		virtual public bool ExistPartBillOfMaterialsWhereComponentPart
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartBillOfMaterialsWhereComponentPart.RelationType);
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



		public ObjectOnBuild OnBuild()
		{ 
			var method = new SubAssemblyOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SubAssemblyOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SubAssemblyOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SubAssemblyOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SubAssemblyOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SubAssemblyOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SubAssemblyOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SubAssemblyOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SubAssemblyOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SubAssemblyOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SubAssemblyBuilder : Allors.ObjectBuilder<SubAssembly> , PartBuilder, global::System.IDisposable
	{		
		public SubAssemblyBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(SubAssembly instance)
		{

			instance.Name = this.Name;
		
		

			instance.ManufacturerId = this.ManufacturerId;
		
		
			

			if(this.ReorderLevel.HasValue)
			{
				instance.ReorderLevel = this.ReorderLevel.Value;
			}			
		
		
			

			if(this.ReorderQuantity.HasValue)
			{
				instance.ReorderQuantity = this.ReorderQuantity.Value;
			}			
		
		

			instance.Sku = this.Sku;
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
			if(this.PartSpecifications!=null)
			{
				instance.PartSpecifications = this.PartSpecifications.ToArray();
			}
		

			instance.UnitOfMeasure = this.UnitOfMeasure;

		
			if(this.Documents!=null)
			{
				instance.Documents = this.Documents.ToArray();
			}
		
			if(this.PriceComponents!=null)
			{
				instance.PriceComponents = this.PriceComponents.ToArray();
			}
		

			instance.InventoryItemKind = this.InventoryItemKind;

		
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
				public SubAssemblyBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<PartSpecification> PartSpecifications {get; set;}	

				/// <exclude/>
				public SubAssemblyBuilder WithPartSpecification(PartSpecification value)
		        {
					if(this.PartSpecifications == null)
					{
						this.PartSpecifications = new global::System.Collections.Generic.List<PartSpecification>(); 
					}
		            this.PartSpecifications.Add(value);
		            return this;
		        }		

				
				public UnitOfMeasure UnitOfMeasure {get; set;}

				/// <exclude/>
				public SubAssemblyBuilder WithUnitOfMeasure(UnitOfMeasure value)
		        {
		            if(this.UnitOfMeasure!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.UnitOfMeasure = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Document> Documents {get; set;}	

				/// <exclude/>
				public SubAssemblyBuilder WithDocument(Document value)
		        {
					if(this.Documents == null)
					{
						this.Documents = new global::System.Collections.Generic.List<Document>(); 
					}
		            this.Documents.Add(value);
		            return this;
		        }		

				
				public global::System.String ManufacturerId {get; set;}

				/// <exclude/>
				public SubAssemblyBuilder WithManufacturerId(global::System.String value)
		        {
				    if(this.ManufacturerId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ManufacturerId = value;
		            return this;
		        }	

				public global::System.Int32? ReorderLevel {get; set;}

				/// <exclude/>
				public SubAssemblyBuilder WithReorderLevel(global::System.Int32? value)
		        {
				    if(this.ReorderLevel!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ReorderLevel = value;
		            return this;
		        }	

				public global::System.Int32? ReorderQuantity {get; set;}

				/// <exclude/>
				public SubAssemblyBuilder WithReorderQuantity(global::System.Int32? value)
		        {
				    if(this.ReorderQuantity!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ReorderQuantity = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<PriceComponent> PriceComponents {get; set;}	

				/// <exclude/>
				public SubAssemblyBuilder WithPriceComponent(PriceComponent value)
		        {
					if(this.PriceComponents == null)
					{
						this.PriceComponents = new global::System.Collections.Generic.List<PriceComponent>(); 
					}
		            this.PriceComponents.Add(value);
		            return this;
		        }		

				
				public InventoryItemKind InventoryItemKind {get; set;}

				/// <exclude/>
				public SubAssemblyBuilder WithInventoryItemKind(InventoryItemKind value)
		        {
		            if(this.InventoryItemKind!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.InventoryItemKind = value;
		            return this;
		        }		

				
				public global::System.String Sku {get; set;}

				/// <exclude/>
				public SubAssemblyBuilder WithSku(global::System.String value)
		        {
				    if(this.Sku!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Sku = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SubAssemblyBuilder WithDeniedPermission(Permission value)
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
				public SubAssemblyBuilder WithSecurityToken(SecurityToken value)
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
				public SubAssemblyBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	


	}

	public partial class SubAssemblies : global::Allors.ObjectsBase<SubAssembly>
	{
		public SubAssemblies(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSubAssembly Meta
		{
			get
			{
				return Allors.Meta.MetaSubAssembly.Instance;
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