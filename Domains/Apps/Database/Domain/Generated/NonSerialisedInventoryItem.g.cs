// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class NonSerialisedInventoryItem : Allors.IObject , InventoryItem, Versioned
	{
		private readonly IStrategy strategy;

		public NonSerialisedInventoryItem(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaNonSerialisedInventoryItem Meta
		{
			get
			{
				return Allors.Meta.MetaNonSerialisedInventoryItem.Instance;
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

		public static NonSerialisedInventoryItem Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (NonSerialisedInventoryItem) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public NonSerialisedInventoryItemState PreviousNonSerialisedInventoryItemState
		{ 
			get
			{
				return (NonSerialisedInventoryItemState) Strategy.GetCompositeRole(Meta.PreviousNonSerialisedInventoryItemState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PreviousNonSerialisedInventoryItemState.RelationType, value);
			}
		}

		virtual public bool ExistPreviousNonSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PreviousNonSerialisedInventoryItemState.RelationType);
			}
		}

		virtual public void RemovePreviousNonSerialisedInventoryItemState()
		{
			Strategy.RemoveCompositeRole(Meta.PreviousNonSerialisedInventoryItemState.RelationType);
		}


		virtual public NonSerialisedInventoryItemState LastNonSerialisedInventoryItemState
		{ 
			get
			{
				return (NonSerialisedInventoryItemState) Strategy.GetCompositeRole(Meta.LastNonSerialisedInventoryItemState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.LastNonSerialisedInventoryItemState.RelationType, value);
			}
		}

		virtual public bool ExistLastNonSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.LastNonSerialisedInventoryItemState.RelationType);
			}
		}

		virtual public void RemoveLastNonSerialisedInventoryItemState()
		{
			Strategy.RemoveCompositeRole(Meta.LastNonSerialisedInventoryItemState.RelationType);
		}


		virtual public NonSerialisedInventoryItemState NonSerialisedInventoryItemState
		{ 
			get
			{
				return (NonSerialisedInventoryItemState) Strategy.GetCompositeRole(Meta.NonSerialisedInventoryItemState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.NonSerialisedInventoryItemState.RelationType, value);
			}
		}

		virtual public bool ExistNonSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.NonSerialisedInventoryItemState.RelationType);
			}
		}

		virtual public void RemoveNonSerialisedInventoryItemState()
		{
			Strategy.RemoveCompositeRole(Meta.NonSerialisedInventoryItemState.RelationType);
		}


		virtual public NonSerialisedInventoryItemVersion CurrentVersion
		{ 
			get
			{
				return (NonSerialisedInventoryItemVersion) Strategy.GetCompositeRole(Meta.CurrentVersion.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CurrentVersion.RelationType, value);
			}
		}

		virtual public bool ExistCurrentVersion
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CurrentVersion.RelationType);
			}
		}

		virtual public void RemoveCurrentVersion()
		{
			Strategy.RemoveCompositeRole(Meta.CurrentVersion.RelationType);
		}


		virtual public global::Allors.Extent<NonSerialisedInventoryItemVersion> AllVersions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.AllVersions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.AllVersions.RelationType, value);
			}
		}

		virtual public void AddAllVersion (NonSerialisedInventoryItemVersion value)
		{
			Strategy.AddCompositeRole(Meta.AllVersions.RelationType, value);
		}

		virtual public void RemoveAllVersion (NonSerialisedInventoryItemVersion value)
		{
			Strategy.RemoveCompositeRole(Meta.AllVersions.RelationType, value);
		}

		virtual public bool ExistAllVersions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.AllVersions.RelationType);
			}
		}

		virtual public void RemoveAllVersions()
		{
			Strategy.RemoveCompositeRoles(Meta.AllVersions.RelationType);
		}


		virtual public global::System.Decimal QuantityCommittedOut 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.QuantityCommittedOut.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.QuantityCommittedOut.RelationType, value);
			}
		}

		virtual public bool ExistQuantityCommittedOut{
			get
			{
				return Strategy.ExistUnitRole(Meta.QuantityCommittedOut.RelationType);
			}
		}

		virtual public void RemoveQuantityCommittedOut()
		{
			Strategy.RemoveUnitRole(Meta.QuantityCommittedOut.RelationType);
		}


		virtual public global::System.Decimal QuantityOnHand 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.QuantityOnHand.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.QuantityOnHand.RelationType, value);
			}
		}

		virtual public bool ExistQuantityOnHand{
			get
			{
				return Strategy.ExistUnitRole(Meta.QuantityOnHand.RelationType);
			}
		}

		virtual public void RemoveQuantityOnHand()
		{
			Strategy.RemoveUnitRole(Meta.QuantityOnHand.RelationType);
		}


		virtual public global::System.Decimal PreviousQuantityOnHand 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.PreviousQuantityOnHand.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.PreviousQuantityOnHand.RelationType, value);
			}
		}

		virtual public bool ExistPreviousQuantityOnHand{
			get
			{
				return Strategy.ExistUnitRole(Meta.PreviousQuantityOnHand.RelationType);
			}
		}

		virtual public void RemovePreviousQuantityOnHand()
		{
			Strategy.RemoveUnitRole(Meta.PreviousQuantityOnHand.RelationType);
		}


		virtual public global::System.Decimal AvailableToPromise 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.AvailableToPromise.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AvailableToPromise.RelationType, value);
			}
		}

		virtual public bool ExistAvailableToPromise{
			get
			{
				return Strategy.ExistUnitRole(Meta.AvailableToPromise.RelationType);
			}
		}

		virtual public void RemoveAvailableToPromise()
		{
			Strategy.RemoveUnitRole(Meta.AvailableToPromise.RelationType);
		}


		virtual public global::System.Decimal QuantityExpectedIn 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.QuantityExpectedIn.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.QuantityExpectedIn.RelationType, value);
			}
		}

		virtual public bool ExistQuantityExpectedIn{
			get
			{
				return Strategy.ExistUnitRole(Meta.QuantityExpectedIn.RelationType);
			}
		}

		virtual public void RemoveQuantityExpectedIn()
		{
			Strategy.RemoveUnitRole(Meta.QuantityExpectedIn.RelationType);
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


		virtual public global::Allors.Extent<ObjectState> PreviousObjectStates
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.PreviousObjectStates.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PreviousObjectStates.RelationType, value);
			}
		}

		virtual public void AddPreviousObjectState (ObjectState value)
		{
			Strategy.AddCompositeRole(Meta.PreviousObjectStates.RelationType, value);
		}

		virtual public void RemovePreviousObjectState (ObjectState value)
		{
			Strategy.RemoveCompositeRole(Meta.PreviousObjectStates.RelationType, value);
		}

		virtual public bool ExistPreviousObjectStates
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PreviousObjectStates.RelationType);
			}
		}

		virtual public void RemovePreviousObjectStates()
		{
			Strategy.RemoveCompositeRoles(Meta.PreviousObjectStates.RelationType);
		}


		virtual public global::Allors.Extent<ObjectState> LastObjectStates
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.LastObjectStates.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.LastObjectStates.RelationType, value);
			}
		}

		virtual public void AddLastObjectState (ObjectState value)
		{
			Strategy.AddCompositeRole(Meta.LastObjectStates.RelationType, value);
		}

		virtual public void RemoveLastObjectState (ObjectState value)
		{
			Strategy.RemoveCompositeRole(Meta.LastObjectStates.RelationType, value);
		}

		virtual public bool ExistLastObjectStates
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.LastObjectStates.RelationType);
			}
		}

		virtual public void RemoveLastObjectStates()
		{
			Strategy.RemoveCompositeRoles(Meta.LastObjectStates.RelationType);
		}


		virtual public global::Allors.Extent<ObjectState> ObjectStates
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.ObjectStates.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.ObjectStates.RelationType, value);
			}
		}

		virtual public void AddObjectState (ObjectState value)
		{
			Strategy.AddCompositeRole(Meta.ObjectStates.RelationType, value);
		}

		virtual public void RemoveObjectState (ObjectState value)
		{
			Strategy.RemoveCompositeRole(Meta.ObjectStates.RelationType, value);
		}

		virtual public bool ExistObjectStates
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.ObjectStates.RelationType);
			}
		}

		virtual public void RemoveObjectStates()
		{
			Strategy.RemoveCompositeRoles(Meta.ObjectStates.RelationType);
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



		virtual public global::Allors.Extent<SalesOrderItemVersion> SalesOrderItemVersionsWherePreviousReservedFromInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesOrderItemVersionsWherePreviousReservedFromInventoryItem.RelationType);
			}
		}

		virtual public bool ExistSalesOrderItemVersionsWherePreviousReservedFromInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesOrderItemVersionsWherePreviousReservedFromInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesOrderItemVersion> SalesOrderItemVersionsWhereReservedFromInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesOrderItemVersionsWhereReservedFromInventoryItem.RelationType);
			}
		}

		virtual public bool ExistSalesOrderItemVersionsWhereReservedFromInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesOrderItemVersionsWhereReservedFromInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesOrderItem> SalesOrderItemsWherePreviousReservedFromInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesOrderItemsWherePreviousReservedFromInventoryItem.RelationType);
			}
		}

		virtual public bool ExistSalesOrderItemsWherePreviousReservedFromInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesOrderItemsWherePreviousReservedFromInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesOrderItem> SalesOrderItemsWhereReservedFromInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesOrderItemsWhereReservedFromInventoryItem.RelationType);
			}
		}

		virtual public bool ExistSalesOrderItemsWhereReservedFromInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesOrderItemsWhereReservedFromInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<ShipmentReceipt> ShipmentReceiptsWhereInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ShipmentReceiptsWhereInventoryItem.RelationType);
			}
		}

		virtual public bool ExistShipmentReceiptsWhereInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ShipmentReceiptsWhereInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<ItemIssuance> ItemIssuancesWhereInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ItemIssuancesWhereInventoryItem.RelationType);
			}
		}

		virtual public bool ExistItemIssuancesWhereInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ItemIssuancesWhereInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<PickListItem> PickListItemsWhereInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PickListItemsWhereInventoryItem.RelationType);
			}
		}

		virtual public bool ExistPickListItemsWhereInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PickListItemsWhereInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<ShipmentItem> ShipmentItemsWhereInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ShipmentItemsWhereInventoryItem.RelationType);
			}
		}

		virtual public bool ExistShipmentItemsWhereInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ShipmentItemsWhereInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortInventoryAssignment> WorkEffortInventoryAssignmentsWhereInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortInventoryAssignmentsWhereInventoryItem.RelationType);
			}
		}

		virtual public bool ExistWorkEffortInventoryAssignmentsWhereInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortInventoryAssignmentsWhereInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<InventoryItemConfiguration> InventoryItemConfigurationsWhereInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InventoryItemConfigurationsWhereInventoryItem.RelationType);
			}
		}

		virtual public bool ExistInventoryItemConfigurationsWhereInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InventoryItemConfigurationsWhereInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<InventoryItemConfiguration> InventoryItemConfigurationsWhereComponentInventoryItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InventoryItemConfigurationsWhereComponentInventoryItem.RelationType);
			}
		}

		virtual public bool ExistInventoryItemConfigurationsWhereComponentInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InventoryItemConfigurationsWhereComponentInventoryItem.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortVersion> WorkEffortVersionsWhereInventoryItemsProduced
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortVersionsWhereInventoryItemsProduced.RelationType);
			}
		}

		virtual public bool ExistWorkEffortVersionsWhereInventoryItemsProduced
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortVersionsWhereInventoryItemsProduced.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffort> WorkEffortsWhereInventoryItemsProduced
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortsWhereInventoryItemsProduced.RelationType);
			}
		}

		virtual public bool ExistWorkEffortsWhereInventoryItemsProduced
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortsWhereInventoryItemsProduced.RelationType);
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
			var method = new NonSerialisedInventoryItemOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new NonSerialisedInventoryItemOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new NonSerialisedInventoryItemOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new NonSerialisedInventoryItemOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new NonSerialisedInventoryItemOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new NonSerialisedInventoryItemOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new NonSerialisedInventoryItemOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new NonSerialisedInventoryItemOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new NonSerialisedInventoryItemOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new NonSerialisedInventoryItemOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new NonSerialisedInventoryItemDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new NonSerialisedInventoryItemDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class NonSerialisedInventoryItemBuilder : Allors.ObjectBuilder<NonSerialisedInventoryItem> , InventoryItemBuilder, VersionedBuilder, global::System.IDisposable
	{		
		public NonSerialisedInventoryItemBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(NonSerialisedInventoryItem instance)
		{
						
			

			if(this.AvailableToPromise.HasValue)
			{
				instance.AvailableToPromise = this.AvailableToPromise.Value;
			}			
		
								
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
				

			instance.NonSerialisedInventoryItemState = this.NonSerialisedInventoryItemState;

		

			instance.CurrentVersion = this.CurrentVersion;

		
			if(this.AllVersions!=null)
			{
				instance.AllVersions = this.AllVersions.ToArray();
			}
		
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


				public NonSerialisedInventoryItemState NonSerialisedInventoryItemState {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithNonSerialisedInventoryItemState(NonSerialisedInventoryItemState value)
		        {
		            if(this.NonSerialisedInventoryItemState!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.NonSerialisedInventoryItemState = value;
		            return this;
		        }		

				
				public NonSerialisedInventoryItemVersion CurrentVersion {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithCurrentVersion(NonSerialisedInventoryItemVersion value)
		        {
		            if(this.CurrentVersion!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CurrentVersion = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<NonSerialisedInventoryItemVersion> AllVersions {get; set;}	

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithAllVersion(NonSerialisedInventoryItemVersion value)
		        {
					if(this.AllVersions == null)
					{
						this.AllVersions = new global::System.Collections.Generic.List<NonSerialisedInventoryItemVersion>(); 
					}
		            this.AllVersions.Add(value);
		            return this;
		        }		

				
				public global::System.Decimal? AvailableToPromise {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithAvailableToPromise(global::System.Decimal? value)
		        {
				    if(this.AvailableToPromise!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AvailableToPromise = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<ProductCharacteristicValue> ProductCharacteristicValues {get; set;}	

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithProductCharacteristicValue(ProductCharacteristicValue value)
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
				public NonSerialisedInventoryItemBuilder WithInventoryItemVariance(InventoryItemVariance value)
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
				public NonSerialisedInventoryItemBuilder WithPart(Part value)
		        {
		            if(this.Part!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Part = value;
		            return this;
		        }		

				
				public Lot Lot {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithLot(Lot value)
		        {
		            if(this.Lot!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Lot = value;
		            return this;
		        }		

				
				public Good Good {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithGood(Good value)
		        {
		            if(this.Good!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Good = value;
		            return this;
		        }		

				
				public ProductType ProductType {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithProductType(ProductType value)
		        {
		            if(this.ProductType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ProductType = value;
		            return this;
		        }		

				
				public Facility Facility {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithFacility(Facility value)
		        {
		            if(this.Facility!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Facility = value;
		            return this;
		        }		

				
				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public NonSerialisedInventoryItemBuilder WithDeniedPermission(Permission value)
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
				public NonSerialisedInventoryItemBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class NonSerialisedInventoryItems : global::Allors.ObjectsBase<NonSerialisedInventoryItem>
	{
		public NonSerialisedInventoryItems(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaNonSerialisedInventoryItem Meta
		{
			get
			{
				return Allors.Meta.MetaNonSerialisedInventoryItem.Instance;
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