// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface InventoryItemConfiguration :  Commentable,AccessControlledObject, Allors.IObject
	{


		InventoryItem InventoryItem
		{ 
			get;
			set;
		}

		bool ExistInventoryItem
		{
			get;
		}

		void RemoveInventoryItem();


		global::System.Int32 Quantity 
		{
			get;
			set;
		}

		bool ExistQuantity{get;}

		void RemoveQuantity();


		InventoryItem ComponentInventoryItem
		{ 
			get;
			set;
		}

		bool ExistComponentInventoryItem
		{
			get;
		}

		void RemoveComponentInventoryItem();

	}

	public partial interface InventoryItemConfigurationBuilder : CommentableBuilder ,AccessControlledObjectBuilder , global::System.IDisposable
	{	
		InventoryItem InventoryItem {get;}

		

		global::System.Int32? Quantity {get;}
		

		InventoryItem ComponentInventoryItem {get;}

		

	}

	public partial class InventoryItemConfigurations : global::Allors.ObjectsBase<InventoryItemConfiguration>
	{
		public InventoryItemConfigurations(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaInventoryItemConfiguration Meta
		{
			get
			{
				return Allors.Meta.MetaInventoryItemConfiguration.Instance;
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