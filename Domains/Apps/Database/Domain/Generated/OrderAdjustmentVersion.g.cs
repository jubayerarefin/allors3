// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface OrderAdjustmentVersion :  Version, Allors.IObject
	{


		global::System.Decimal? Amount 
		{
			get;
			set;
		}

		bool ExistAmount{get;}

		void RemoveAmount();


		VatRate VatRate
		{ 
			get;
			set;
		}

		bool ExistVatRate
		{
			get;
		}

		void RemoveVatRate();


		global::System.Decimal? Percentage 
		{
			get;
			set;
		}

		bool ExistPercentage{get;}

		void RemovePercentage();

	}

	public partial interface OrderAdjustmentVersionBuilder : VersionBuilder , global::System.IDisposable
	{	
		global::System.Decimal? Amount {get;}
		

		VatRate VatRate {get;}

		

		global::System.Decimal? Percentage {get;}
		

	}

	public partial class OrderAdjustmentVersions : global::Allors.ObjectsBase<OrderAdjustmentVersion>
	{
		public OrderAdjustmentVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaOrderAdjustmentVersion Meta
		{
			get
			{
				return Allors.Meta.MetaOrderAdjustmentVersion.Instance;
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