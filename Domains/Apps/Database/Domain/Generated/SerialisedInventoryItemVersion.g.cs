// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class SerialisedInventoryItemVersion : Allors.IObject , InventoryItemVersion
	{
		private readonly IStrategy strategy;

		public SerialisedInventoryItemVersion(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSerialisedInventoryItemVersion Meta
		{
			get
			{
				return Allors.Meta.MetaSerialisedInventoryItemVersion.Instance;
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

		public static SerialisedInventoryItemVersion Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (SerialisedInventoryItemVersion) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public SerialisedInventoryItemState SerialisedInventoryItemState
		{ 
			get
			{
				return (SerialisedInventoryItemState) Strategy.GetCompositeRole(Meta.SerialisedInventoryItemState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.SerialisedInventoryItemState.RelationType, value);
			}
		}

		virtual public bool ExistSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.SerialisedInventoryItemState.RelationType);
			}
		}

		virtual public void RemoveSerialisedInventoryItemState()
		{
			Strategy.RemoveCompositeRole(Meta.SerialisedInventoryItemState.RelationType);
		}


		virtual public global::System.String SerialNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.SerialNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.SerialNumber.RelationType, value);
			}
		}

		virtual public bool ExistSerialNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.SerialNumber.RelationType);
			}
		}

		virtual public void RemoveSerialNumber()
		{
			Strategy.RemoveUnitRole(Meta.SerialNumber.RelationType);
		}


		virtual public Ownership Ownership
		{ 
			get
			{
				return (Ownership) Strategy.GetCompositeRole(Meta.Ownership.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Ownership.RelationType, value);
			}
		}

		virtual public bool ExistOwnership
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Ownership.RelationType);
			}
		}

		virtual public void RemoveOwnership()
		{
			Strategy.RemoveCompositeRole(Meta.Ownership.RelationType);
		}


		virtual public global::System.String Owner 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Owner.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Owner.RelationType, value);
			}
		}

		virtual public bool ExistOwner{
			get
			{
				return Strategy.ExistUnitRole(Meta.Owner.RelationType);
			}
		}

		virtual public void RemoveOwner()
		{
			Strategy.RemoveUnitRole(Meta.Owner.RelationType);
		}


		virtual public global::System.Int32? AcquisitionYear 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.AcquisitionYear.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AcquisitionYear.RelationType, value);
			}
		}

		virtual public bool ExistAcquisitionYear{
			get
			{
				return Strategy.ExistUnitRole(Meta.AcquisitionYear.RelationType);
			}
		}

		virtual public void RemoveAcquisitionYear()
		{
			Strategy.RemoveUnitRole(Meta.AcquisitionYear.RelationType);
		}


		virtual public global::System.Int32? ManufacturingYear 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.ManufacturingYear.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ManufacturingYear.RelationType, value);
			}
		}

		virtual public bool ExistManufacturingYear{
			get
			{
				return Strategy.ExistUnitRole(Meta.ManufacturingYear.RelationType);
			}
		}

		virtual public void RemoveManufacturingYear()
		{
			Strategy.RemoveUnitRole(Meta.ManufacturingYear.RelationType);
		}


		virtual public global::System.Decimal? ReplacementValue 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.ReplacementValue.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ReplacementValue.RelationType, value);
			}
		}

		virtual public bool ExistReplacementValue{
			get
			{
				return Strategy.ExistUnitRole(Meta.ReplacementValue.RelationType);
			}
		}

		virtual public void RemoveReplacementValue()
		{
			Strategy.RemoveUnitRole(Meta.ReplacementValue.RelationType);
		}


		virtual public global::System.Int32? LifeTime 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.LifeTime.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.LifeTime.RelationType, value);
			}
		}

		virtual public bool ExistLifeTime{
			get
			{
				return Strategy.ExistUnitRole(Meta.LifeTime.RelationType);
			}
		}

		virtual public void RemoveLifeTime()
		{
			Strategy.RemoveUnitRole(Meta.LifeTime.RelationType);
		}


		virtual public global::System.Int32? DepreciationYears 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.DepreciationYears.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.DepreciationYears.RelationType, value);
			}
		}

		virtual public bool ExistDepreciationYears{
			get
			{
				return Strategy.ExistUnitRole(Meta.DepreciationYears.RelationType);
			}
		}

		virtual public void RemoveDepreciationYears()
		{
			Strategy.RemoveUnitRole(Meta.DepreciationYears.RelationType);
		}


		virtual public global::System.Decimal? PurchasePrice 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.PurchasePrice.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.PurchasePrice.RelationType, value);
			}
		}

		virtual public bool ExistPurchasePrice{
			get
			{
				return Strategy.ExistUnitRole(Meta.PurchasePrice.RelationType);
			}
		}

		virtual public void RemovePurchasePrice()
		{
			Strategy.RemoveUnitRole(Meta.PurchasePrice.RelationType);
		}


		virtual public global::System.Decimal? ExpectedSalesPrice 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.ExpectedSalesPrice.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ExpectedSalesPrice.RelationType, value);
			}
		}

		virtual public bool ExistExpectedSalesPrice{
			get
			{
				return Strategy.ExistUnitRole(Meta.ExpectedSalesPrice.RelationType);
			}
		}

		virtual public void RemoveExpectedSalesPrice()
		{
			Strategy.RemoveUnitRole(Meta.ExpectedSalesPrice.RelationType);
		}


		virtual public global::System.Decimal? RefurbishCost 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.RefurbishCost.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.RefurbishCost.RelationType, value);
			}
		}

		virtual public bool ExistRefurbishCost{
			get
			{
				return Strategy.ExistUnitRole(Meta.RefurbishCost.RelationType);
			}
		}

		virtual public void RemoveRefurbishCost()
		{
			Strategy.RemoveUnitRole(Meta.RefurbishCost.RelationType);
		}


		virtual public global::System.Decimal? TransportCost 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.TransportCost.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.TransportCost.RelationType, value);
			}
		}

		virtual public bool ExistTransportCost{
			get
			{
				return Strategy.ExistUnitRole(Meta.TransportCost.RelationType);
			}
		}

		virtual public void RemoveTransportCost()
		{
			Strategy.RemoveUnitRole(Meta.TransportCost.RelationType);
		}


		virtual public global::Allors.Extent<ProductCharacteristicValue> ProductCharacteristicValues
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.ProductCharacteristicValues.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.ProductCharacteristicValues.RelationType, value);
			}
		}

		virtual public void AddProductCharacteristicValue (ProductCharacteristicValue value)
		{
			Strategy.AddCompositeRole(Meta.ProductCharacteristicValues.RelationType, value);
		}

		virtual public void RemoveProductCharacteristicValue (ProductCharacteristicValue value)
		{
			Strategy.RemoveCompositeRole(Meta.ProductCharacteristicValues.RelationType, value);
		}

		virtual public bool ExistProductCharacteristicValues
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.ProductCharacteristicValues.RelationType);
			}
		}

		virtual public void RemoveProductCharacteristicValues()
		{
			Strategy.RemoveCompositeRoles(Meta.ProductCharacteristicValues.RelationType);
		}


		virtual public global::Allors.Extent<InventoryItemVariance> InventoryItemVariances
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.InventoryItemVariances.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.InventoryItemVariances.RelationType, value);
			}
		}

		virtual public void AddInventoryItemVariance (InventoryItemVariance value)
		{
			Strategy.AddCompositeRole(Meta.InventoryItemVariances.RelationType, value);
		}

		virtual public void RemoveInventoryItemVariance (InventoryItemVariance value)
		{
			Strategy.RemoveCompositeRole(Meta.InventoryItemVariances.RelationType, value);
		}

		virtual public bool ExistInventoryItemVariances
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.InventoryItemVariances.RelationType);
			}
		}

		virtual public void RemoveInventoryItemVariances()
		{
			Strategy.RemoveCompositeRoles(Meta.InventoryItemVariances.RelationType);
		}


		virtual public Part Part
		{ 
			get
			{
				return (Part) Strategy.GetCompositeRole(Meta.Part.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Part.RelationType, value);
			}
		}

		virtual public bool ExistPart
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Part.RelationType);
			}
		}

		virtual public void RemovePart()
		{
			Strategy.RemoveCompositeRole(Meta.Part.RelationType);
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


		virtual public Lot Lot
		{ 
			get
			{
				return (Lot) Strategy.GetCompositeRole(Meta.Lot.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Lot.RelationType, value);
			}
		}

		virtual public bool ExistLot
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Lot.RelationType);
			}
		}

		virtual public void RemoveLot()
		{
			Strategy.RemoveCompositeRole(Meta.Lot.RelationType);
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


		virtual public global::Allors.Extent<ProductCategory> DerivedProductCategories
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.DerivedProductCategories.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.DerivedProductCategories.RelationType, value);
			}
		}

		virtual public void AddDerivedProductCategory (ProductCategory value)
		{
			Strategy.AddCompositeRole(Meta.DerivedProductCategories.RelationType, value);
		}

		virtual public void RemoveDerivedProductCategory (ProductCategory value)
		{
			Strategy.RemoveCompositeRole(Meta.DerivedProductCategories.RelationType, value);
		}

		virtual public bool ExistDerivedProductCategories
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.DerivedProductCategories.RelationType);
			}
		}

		virtual public void RemoveDerivedProductCategories()
		{
			Strategy.RemoveCompositeRoles(Meta.DerivedProductCategories.RelationType);
		}


		virtual public Good Good
		{ 
			get
			{
				return (Good) Strategy.GetCompositeRole(Meta.Good.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Good.RelationType, value);
			}
		}

		virtual public bool ExistGood
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Good.RelationType);
			}
		}

		virtual public void RemoveGood()
		{
			Strategy.RemoveCompositeRole(Meta.Good.RelationType);
		}


		virtual public ProductType ProductType
		{ 
			get
			{
				return (ProductType) Strategy.GetCompositeRole(Meta.ProductType.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ProductType.RelationType, value);
			}
		}

		virtual public bool ExistProductType
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ProductType.RelationType);
			}
		}

		virtual public void RemoveProductType()
		{
			Strategy.RemoveCompositeRole(Meta.ProductType.RelationType);
		}


		virtual public Facility Facility
		{ 
			get
			{
				return (Facility) Strategy.GetCompositeRole(Meta.Facility.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Facility.RelationType, value);
			}
		}

		virtual public bool ExistFacility
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Facility.RelationType);
			}
		}

		virtual public void RemoveFacility()
		{
			Strategy.RemoveCompositeRole(Meta.Facility.RelationType);
		}


		virtual public global::System.Guid? DerivationId 
		{
			get
			{
				return (global::System.Guid?) Strategy.GetUnitRole(Meta.DerivationId.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.DerivationId.RelationType, value);
			}
		}

		virtual public bool ExistDerivationId{
			get
			{
				return Strategy.ExistUnitRole(Meta.DerivationId.RelationType);
			}
		}

		virtual public void RemoveDerivationId()
		{
			Strategy.RemoveUnitRole(Meta.DerivationId.RelationType);
		}


		virtual public global::System.DateTime? DerivationTimeStamp 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.DerivationTimeStamp.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.DerivationTimeStamp.RelationType, value);
			}
		}

		virtual public bool ExistDerivationTimeStamp{
			get
			{
				return Strategy.ExistUnitRole(Meta.DerivationTimeStamp.RelationType);
			}
		}

		virtual public void RemoveDerivationTimeStamp()
		{
			Strategy.RemoveUnitRole(Meta.DerivationTimeStamp.RelationType);
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



		virtual public SerialisedInventoryItem SerialisedInventoryItemWhereCurrentVersion
		{ 
			get
			{
				return (SerialisedInventoryItem) Strategy.GetCompositeAssociation(Meta.SerialisedInventoryItemWhereCurrentVersion.RelationType);
			}
		} 

		virtual public bool ExistSerialisedInventoryItemWhereCurrentVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.SerialisedInventoryItemWhereCurrentVersion.RelationType);
			}
		}


		virtual public SerialisedInventoryItem SerialisedInventoryItemWhereAllVersion
		{ 
			get
			{
				return (SerialisedInventoryItem) Strategy.GetCompositeAssociation(Meta.SerialisedInventoryItemWhereAllVersion.RelationType);
			}
		} 

		virtual public bool ExistSerialisedInventoryItemWhereAllVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.SerialisedInventoryItemWhereAllVersion.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new SerialisedInventoryItemVersionOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SerialisedInventoryItemVersionOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SerialisedInventoryItemVersionOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SerialisedInventoryItemVersionOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SerialisedInventoryItemVersionOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SerialisedInventoryItemVersionOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SerialisedInventoryItemVersionOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SerialisedInventoryItemVersionOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SerialisedInventoryItemVersionOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SerialisedInventoryItemVersionOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new SerialisedInventoryItemVersionDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new SerialisedInventoryItemVersionDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SerialisedInventoryItemVersionBuilder : Allors.ObjectBuilder<SerialisedInventoryItemVersion> , InventoryItemVersionBuilder, global::System.IDisposable
	{		
		public SerialisedInventoryItemVersionBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(SerialisedInventoryItemVersion instance)
		{

			instance.SerialNumber = this.SerialNumber;
		
		

			instance.Owner = this.Owner;
		
		
			

			if(this.AcquisitionYear.HasValue)
			{
				instance.AcquisitionYear = this.AcquisitionYear.Value;
			}			
		
		
			

			if(this.ManufacturingYear.HasValue)
			{
				instance.ManufacturingYear = this.ManufacturingYear.Value;
			}			
		
		
			

			if(this.ReplacementValue.HasValue)
			{
				instance.ReplacementValue = this.ReplacementValue.Value;
			}			
		
		
			

			if(this.LifeTime.HasValue)
			{
				instance.LifeTime = this.LifeTime.Value;
			}			
		
		
			

			if(this.DepreciationYears.HasValue)
			{
				instance.DepreciationYears = this.DepreciationYears.Value;
			}			
		
		
			

			if(this.PurchasePrice.HasValue)
			{
				instance.PurchasePrice = this.PurchasePrice.Value;
			}			
		
		
			

			if(this.ExpectedSalesPrice.HasValue)
			{
				instance.ExpectedSalesPrice = this.ExpectedSalesPrice.Value;
			}			
		
		
			

			if(this.RefurbishCost.HasValue)
			{
				instance.RefurbishCost = this.RefurbishCost.Value;
			}			
		
		
			

			if(this.TransportCost.HasValue)
			{
				instance.TransportCost = this.TransportCost.Value;
			}			
		
						
			

			if(this.DerivationId.HasValue)
			{
				instance.DerivationId = this.DerivationId.Value;
			}			
		
		
			

			if(this.DerivationTimeStamp.HasValue)
			{
				instance.DerivationTimeStamp = this.DerivationTimeStamp.Value;
			}			
		
		

			instance.SerialisedInventoryItemState = this.SerialisedInventoryItemState;

		

			instance.Ownership = this.Ownership;

		
			if(this.ProductCharacteristicValues!=null)
			{
				instance.ProductCharacteristicValues = this.ProductCharacteristicValues.ToArray();
			}
		
			if(this.InventoryItemVariances!=null)
			{
				instance.InventoryItemVariances = this.InventoryItemVariances.ToArray();
			}
		

			instance.Part = this.Part;

		

			instance.Lot = this.Lot;

						

			instance.Good = this.Good;

		

			instance.ProductType = this.ProductType;

		

			instance.Facility = this.Facility;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public SerialisedInventoryItemState SerialisedInventoryItemState {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithSerialisedInventoryItemState(SerialisedInventoryItemState value)
		        {
		            if(this.SerialisedInventoryItemState!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.SerialisedInventoryItemState = value;
		            return this;
		        }		

				
				public global::System.String SerialNumber {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithSerialNumber(global::System.String value)
		        {
				    if(this.SerialNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.SerialNumber = value;
		            return this;
		        }	

				public Ownership Ownership {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithOwnership(Ownership value)
		        {
		            if(this.Ownership!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Ownership = value;
		            return this;
		        }		

				
				public global::System.String Owner {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithOwner(global::System.String value)
		        {
				    if(this.Owner!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Owner = value;
		            return this;
		        }	

				public global::System.Int32? AcquisitionYear {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithAcquisitionYear(global::System.Int32? value)
		        {
				    if(this.AcquisitionYear!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AcquisitionYear = value;
		            return this;
		        }	

				public global::System.Int32? ManufacturingYear {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithManufacturingYear(global::System.Int32? value)
		        {
				    if(this.ManufacturingYear!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ManufacturingYear = value;
		            return this;
		        }	

				public global::System.Decimal? ReplacementValue {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithReplacementValue(global::System.Decimal? value)
		        {
				    if(this.ReplacementValue!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ReplacementValue = value;
		            return this;
		        }	

				public global::System.Int32? LifeTime {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithLifeTime(global::System.Int32? value)
		        {
				    if(this.LifeTime!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.LifeTime = value;
		            return this;
		        }	

				public global::System.Int32? DepreciationYears {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithDepreciationYears(global::System.Int32? value)
		        {
				    if(this.DepreciationYears!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DepreciationYears = value;
		            return this;
		        }	

				public global::System.Decimal? PurchasePrice {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithPurchasePrice(global::System.Decimal? value)
		        {
				    if(this.PurchasePrice!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.PurchasePrice = value;
		            return this;
		        }	

				public global::System.Decimal? ExpectedSalesPrice {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithExpectedSalesPrice(global::System.Decimal? value)
		        {
				    if(this.ExpectedSalesPrice!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ExpectedSalesPrice = value;
		            return this;
		        }	

				public global::System.Decimal? RefurbishCost {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithRefurbishCost(global::System.Decimal? value)
		        {
				    if(this.RefurbishCost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RefurbishCost = value;
		            return this;
		        }	

				public global::System.Decimal? TransportCost {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithTransportCost(global::System.Decimal? value)
		        {
				    if(this.TransportCost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.TransportCost = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<ProductCharacteristicValue> ProductCharacteristicValues {get; set;}	

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithProductCharacteristicValue(ProductCharacteristicValue value)
		        {
					if(this.ProductCharacteristicValues == null)
					{
						this.ProductCharacteristicValues = new global::System.Collections.Generic.List<ProductCharacteristicValue>(); 
					}
		            this.ProductCharacteristicValues.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<InventoryItemVariance> InventoryItemVariances {get; set;}	

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithInventoryItemVariance(InventoryItemVariance value)
		        {
					if(this.InventoryItemVariances == null)
					{
						this.InventoryItemVariances = new global::System.Collections.Generic.List<InventoryItemVariance>(); 
					}
		            this.InventoryItemVariances.Add(value);
		            return this;
		        }		

				
				public Part Part {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithPart(Part value)
		        {
		            if(this.Part!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Part = value;
		            return this;
		        }		

				
				public Lot Lot {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithLot(Lot value)
		        {
		            if(this.Lot!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Lot = value;
		            return this;
		        }		

				
				public Good Good {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithGood(Good value)
		        {
		            if(this.Good!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Good = value;
		            return this;
		        }		

				
				public ProductType ProductType {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithProductType(ProductType value)
		        {
		            if(this.ProductType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ProductType = value;
		            return this;
		        }		

				
				public Facility Facility {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithFacility(Facility value)
		        {
		            if(this.Facility!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Facility = value;
		            return this;
		        }		

				
				public global::System.Guid? DerivationId {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithDerivationId(global::System.Guid? value)
		        {
				    if(this.DerivationId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationId = value;
		            return this;
		        }	

				public global::System.DateTime? DerivationTimeStamp {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithDerivationTimeStamp(global::System.DateTime? value)
		        {
				    if(this.DerivationTimeStamp!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationTimeStamp = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SerialisedInventoryItemVersionBuilder WithDeniedPermission(Permission value)
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
				public SerialisedInventoryItemVersionBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class SerialisedInventoryItemVersions : global::Allors.ObjectsBase<SerialisedInventoryItemVersion>
	{
		public SerialisedInventoryItemVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSerialisedInventoryItemVersion Meta
		{
			get
			{
				return Allors.Meta.MetaSerialisedInventoryItemVersion.Instance;
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