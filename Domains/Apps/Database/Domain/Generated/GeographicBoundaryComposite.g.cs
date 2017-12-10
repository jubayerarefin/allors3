// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface GeographicBoundaryComposite :  GeographicBoundary, Allors.IObject
	{


		global::Allors.Extent<GeographicBoundary> Associations
		{ 
			get;
			set;
		}

		void AddAssociation (GeographicBoundary value);

		void RemoveAssociation (GeographicBoundary value);

		bool ExistAssociations
		{
			get;
		}

		void RemoveAssociations();

	}

	public partial interface GeographicBoundaryCompositeBuilder : GeographicBoundaryBuilder , global::System.IDisposable
	{	

		global::System.Collections.Generic.List<GeographicBoundary> Associations {get;}		

		

	}

	public partial class GeographicBoundaryComposites : global::Allors.ObjectsBase<GeographicBoundaryComposite>
	{
		public GeographicBoundaryComposites(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaGeographicBoundaryComposite Meta
		{
			get
			{
				return Allors.Meta.MetaGeographicBoundaryComposite.Instance;
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