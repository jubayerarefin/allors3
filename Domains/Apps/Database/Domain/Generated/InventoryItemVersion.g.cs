// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface InventoryItemVersion :  Version,Deletable, Allors.IObject
	{


		global::Allors.Extent<ProductCharacteristicValue> ProductCharacteristicValues
		{ 
			get;
			set;
		}

		void AddProductCharacteristicValue (ProductCharacteristicValue value);

		void RemoveProductCharacteristicValue (ProductCharacteristicValue value);

		bool ExistProductCharacteristicValues
		{
			get;
		}

		void RemoveProductCharacteristicValues();


		global::Allors.Extent<InventoryItemVariance> InventoryItemVariances
		{ 
			get;
			set;
		}

		void AddInventoryItemVariance (InventoryItemVariance value);

		void RemoveInventoryItemVariance (InventoryItemVariance value);

		bool ExistInventoryItemVariances
		{
			get;
		}

		void RemoveInventoryItemVariances();


		Part Part
		{ 
			get;
			set;
		}

		bool ExistPart
		{
			get;
		}

		void RemovePart();


		global::System.String Name 
		{
			get;
			set;
		}

		bool ExistName{get;}

		void RemoveName();


		Lot Lot
		{ 
			get;
			set;
		}

		bool ExistLot
		{
			get;
		}

		void RemoveLot();


		global::System.String Sku 
		{
			get;
			set;
		}

		bool ExistSku{get;}

		void RemoveSku();


		UnitOfMeasure UnitOfMeasure
		{ 
			get;
			set;
		}

		bool ExistUnitOfMeasure
		{
			get;
		}

		void RemoveUnitOfMeasure();


		global::Allors.Extent<ProductCategory> DerivedProductCategories
		{ 
			get;
			set;
		}

		void AddDerivedProductCategory (ProductCategory value);

		void RemoveDerivedProductCategory (ProductCategory value);

		bool ExistDerivedProductCategories
		{
			get;
		}

		void RemoveDerivedProductCategories();


		Good Good
		{ 
			get;
			set;
		}

		bool ExistGood
		{
			get;
		}

		void RemoveGood();


		ProductType ProductType
		{ 
			get;
			set;
		}

		bool ExistProductType
		{
			get;
		}

		void RemoveProductType();


		Facility Facility
		{ 
			get;
			set;
		}

		bool ExistFacility
		{
			get;
		}

		void RemoveFacility();

	}

	public partial interface InventoryItemVersionBuilder : VersionBuilder ,DeletableBuilder , global::System.IDisposable
	{	

		global::System.Collections.Generic.List<ProductCharacteristicValue> ProductCharacteristicValues {get;}		

		


		global::System.Collections.Generic.List<InventoryItemVariance> InventoryItemVariances {get;}		

		

		Part Part {get;}

		

		Lot Lot {get;}

		

		Good Good {get;}

		

		ProductType ProductType {get;}

		

		Facility Facility {get;}

		

	}

	public partial class InventoryItemVersions : global::Allors.ObjectsBase<InventoryItemVersion>
	{
		public InventoryItemVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaInventoryItemVersion Meta
		{
			get
			{
				return Allors.Meta.MetaInventoryItemVersion.Instance;
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