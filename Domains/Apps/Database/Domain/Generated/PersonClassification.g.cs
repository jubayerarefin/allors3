// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface PersonClassification :  PartyClassification, Allors.IObject
	{


		global::Allors.Extent<Person> PeopleWherePersonClassification
		{ 
			get;
		}

		bool ExistPeopleWherePersonClassification
		{
			get;
		}


		global::Allors.Extent<PersonVersion> PersonVersionsWherePersonClassification
		{ 
			get;
		}

		bool ExistPersonVersionsWherePersonClassification
		{
			get;
		}

	}

	public partial interface PersonClassificationBuilder : PartyClassificationBuilder , global::System.IDisposable
	{	
	}

	public partial class PersonClassifications : global::Allors.ObjectsBase<PersonClassification>
	{
		public PersonClassifications(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPersonClassification Meta
		{
			get
			{
				return Allors.Meta.MetaPersonClassification.Instance;
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