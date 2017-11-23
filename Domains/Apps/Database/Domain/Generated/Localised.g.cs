// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface Localised :  Object, Allors.IObject
	{


		Locale Locale
		{ 
			get;
			set;
		}

		bool ExistLocale
		{
			get;
		}

		void RemoveLocale();

	}

	public partial interface LocalisedBuilder : ObjectBuilder , global::System.IDisposable
	{	
		Locale Locale {get;}

		

	}

	public partial class Localiseds : global::Allors.ObjectsBase<Localised>
	{
		public Localiseds(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaLocalised Meta
		{
			get
			{
				return Allors.Meta.MetaLocalised.Instance;
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