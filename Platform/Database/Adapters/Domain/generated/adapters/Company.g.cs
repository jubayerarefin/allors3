// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Company : Allors.IObject , Named
	{
		private readonly IStrategy strategy;
		private readonly Allors.Meta.M m;

		public Company(Allors.IStrategy strategy)
		{
			this.strategy = strategy;
			this.m = this.DatabaseState().M;
		}

		public Allors.Meta.M M => m;

		public Allors.Meta.MetaCompany Meta => m.Company;

		public long Id
		{
			get { return this.strategy.ObjectId; }
		}

		public IStrategy Strategy
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this.strategy; }
        }

		public static Company Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Company) allorsSession.Instantiate(allorsObjectId);
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



		virtual public Person Manager
		{
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.Manager.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Manager.RelationType, value);
			}
		}

		virtual public bool ExistManager
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Manager.RelationType);
			}
		}

		virtual public void RemoveManager()
		{
			Strategy.RemoveCompositeRole(Meta.Manager.RelationType);
		}


		virtual public global::Allors.Extent<Person> Employees
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.Employees.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Employees.RelationType, value);
			}
		}

		virtual public void AddEmployee (Person value)
		{
			Strategy.AddCompositeRole(Meta.Employees.RelationType, value);
		}

		virtual public void RemoveEmployee (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.Employees.RelationType, value);
		}

		virtual public bool ExistEmployees
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Employees.RelationType);
			}
		}

		virtual public void RemoveEmployees()
		{
			Strategy.RemoveCompositeRoles(Meta.Employees.RelationType);
		}


		virtual public Person FirstPerson
		{
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.FirstPerson.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.FirstPerson.RelationType, value);
			}
		}

		virtual public bool ExistFirstPerson
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.FirstPerson.RelationType);
			}
		}

		virtual public void RemoveFirstPerson()
		{
			Strategy.RemoveCompositeRole(Meta.FirstPerson.RelationType);
		}


		virtual public global::Allors.Extent<Named> NamedsOneSort2
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.NamedsOneSort2.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.NamedsOneSort2.RelationType, value);
			}
		}

		virtual public void AddNamedsOneSort2 (Named value)
		{
			Strategy.AddCompositeRole(Meta.NamedsOneSort2.RelationType, value);
		}

		virtual public void RemoveNamedsOneSort2 (Named value)
		{
			Strategy.RemoveCompositeRole(Meta.NamedsOneSort2.RelationType, value);
		}

		virtual public bool ExistNamedsOneSort2
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.NamedsOneSort2.RelationType);
			}
		}

		virtual public void RemoveNamedsOneSort2()
		{
			Strategy.RemoveCompositeRoles(Meta.NamedsOneSort2.RelationType);
		}


		virtual public global::Allors.Extent<Person> Owners
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.Owners.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Owners.RelationType, value);
			}
		}

		virtual public void AddOwner (Person value)
		{
			Strategy.AddCompositeRole(Meta.Owners.RelationType, value);
		}

		virtual public void RemoveOwner (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.Owners.RelationType, value);
		}

		virtual public bool ExistOwners
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Owners.RelationType);
			}
		}

		virtual public void RemoveOwners()
		{
			Strategy.RemoveCompositeRoles(Meta.Owners.RelationType);
		}


		virtual public global::Allors.Extent<Person> IndexedMany2ManyPersons
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.IndexedMany2ManyPersons.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.IndexedMany2ManyPersons.RelationType, value);
			}
		}

		virtual public void AddIndexedMany2ManyPerson (Person value)
		{
			Strategy.AddCompositeRole(Meta.IndexedMany2ManyPersons.RelationType, value);
		}

		virtual public void RemoveIndexedMany2ManyPerson (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.IndexedMany2ManyPersons.RelationType, value);
		}

		virtual public bool ExistIndexedMany2ManyPersons
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.IndexedMany2ManyPersons.RelationType);
			}
		}

		virtual public void RemoveIndexedMany2ManyPersons()
		{
			Strategy.RemoveCompositeRoles(Meta.IndexedMany2ManyPersons.RelationType);
		}


		virtual public global::Allors.Extent<Person> PersonsOneSort1
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.PersonsOneSort1.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PersonsOneSort1.RelationType, value);
			}
		}

		virtual public void AddPersonsOneSort1 (Person value)
		{
			Strategy.AddCompositeRole(Meta.PersonsOneSort1.RelationType, value);
		}

		virtual public void RemovePersonsOneSort1 (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.PersonsOneSort1.RelationType, value);
		}

		virtual public bool ExistPersonsOneSort1
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PersonsOneSort1.RelationType);
			}
		}

		virtual public void RemovePersonsOneSort1()
		{
			Strategy.RemoveCompositeRoles(Meta.PersonsOneSort1.RelationType);
		}


		virtual public global::Allors.Extent<Person> PersonsManySort1
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.PersonsManySort1.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PersonsManySort1.RelationType, value);
			}
		}

		virtual public void AddPersonsManySort1 (Person value)
		{
			Strategy.AddCompositeRole(Meta.PersonsManySort1.RelationType, value);
		}

		virtual public void RemovePersonsManySort1 (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.PersonsManySort1.RelationType, value);
		}

		virtual public bool ExistPersonsManySort1
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PersonsManySort1.RelationType);
			}
		}

		virtual public void RemovePersonsManySort1()
		{
			Strategy.RemoveCompositeRoles(Meta.PersonsManySort1.RelationType);
		}


		virtual public global::Allors.Extent<Named> NamedsManySort1
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.NamedsManySort1.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.NamedsManySort1.RelationType, value);
			}
		}

		virtual public void AddNamedsManySort1 (Named value)
		{
			Strategy.AddCompositeRole(Meta.NamedsManySort1.RelationType, value);
		}

		virtual public void RemoveNamedsManySort1 (Named value)
		{
			Strategy.RemoveCompositeRole(Meta.NamedsManySort1.RelationType, value);
		}

		virtual public bool ExistNamedsManySort1
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.NamedsManySort1.RelationType);
			}
		}

		virtual public void RemoveNamedsManySort1()
		{
			Strategy.RemoveCompositeRoles(Meta.NamedsManySort1.RelationType);
		}


		virtual public global::Allors.Extent<Person> PersonsManySort2
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.PersonsManySort2.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PersonsManySort2.RelationType, value);
			}
		}

		virtual public void AddPersonsManySort2 (Person value)
		{
			Strategy.AddCompositeRole(Meta.PersonsManySort2.RelationType, value);
		}

		virtual public void RemovePersonsManySort2 (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.PersonsManySort2.RelationType, value);
		}

		virtual public bool ExistPersonsManySort2
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PersonsManySort2.RelationType);
			}
		}

		virtual public void RemovePersonsManySort2()
		{
			Strategy.RemoveCompositeRoles(Meta.PersonsManySort2.RelationType);
		}


		virtual public global::Allors.Extent<Person> PersonsOneSort2
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.PersonsOneSort2.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PersonsOneSort2.RelationType, value);
			}
		}

		virtual public void AddPersonsOneSort2 (Person value)
		{
			Strategy.AddCompositeRole(Meta.PersonsOneSort2.RelationType, value);
		}

		virtual public void RemovePersonsOneSort2 (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.PersonsOneSort2.RelationType, value);
		}

		virtual public bool ExistPersonsOneSort2
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PersonsOneSort2.RelationType);
			}
		}

		virtual public void RemovePersonsOneSort2()
		{
			Strategy.RemoveCompositeRoles(Meta.PersonsOneSort2.RelationType);
		}


		virtual public Named NamedManySort2
		{
			get
			{
				return (Named) Strategy.GetCompositeRole(Meta.NamedManySort2.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.NamedManySort2.RelationType, value);
			}
		}

		virtual public bool ExistNamedManySort2
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.NamedManySort2.RelationType);
			}
		}

		virtual public void RemoveNamedManySort2()
		{
			Strategy.RemoveCompositeRole(Meta.NamedManySort2.RelationType);
		}


		virtual public global::Allors.Extent<Person> Many2ManyPersons
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.Many2ManyPersons.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Many2ManyPersons.RelationType, value);
			}
		}

		virtual public void AddMany2ManyPerson (Person value)
		{
			Strategy.AddCompositeRole(Meta.Many2ManyPersons.RelationType, value);
		}

		virtual public void RemoveMany2ManyPerson (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.Many2ManyPersons.RelationType, value);
		}

		virtual public bool ExistMany2ManyPersons
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Many2ManyPersons.RelationType);
			}
		}

		virtual public void RemoveMany2ManyPersons()
		{
			Strategy.RemoveCompositeRoles(Meta.Many2ManyPersons.RelationType);
		}


		virtual public global::Allors.Extent<Company> Children
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.Children.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Children.RelationType, value);
			}
		}

		virtual public void AddChild (Company value)
		{
			Strategy.AddCompositeRole(Meta.Children.RelationType, value);
		}

		virtual public void RemoveChild (Company value)
		{
			Strategy.RemoveCompositeRole(Meta.Children.RelationType, value);
		}

		virtual public bool ExistChildren
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Children.RelationType);
			}
		}

		virtual public void RemoveChildren()
		{
			Strategy.RemoveCompositeRoles(Meta.Children.RelationType);
		}


		virtual public global::Allors.Extent<Named> NamedsOneSort1
		{
			get
			{
				return Strategy.GetCompositeRoles(Meta.NamedsOneSort1.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.NamedsOneSort1.RelationType, value);
			}
		}

		virtual public void AddNamedsOneSort1 (Named value)
		{
			Strategy.AddCompositeRole(Meta.NamedsOneSort1.RelationType, value);
		}

		virtual public void RemoveNamedsOneSort1 (Named value)
		{
			Strategy.RemoveCompositeRole(Meta.NamedsOneSort1.RelationType, value);
		}

		virtual public bool ExistNamedsOneSort1
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.NamedsOneSort1.RelationType);
			}
		}

		virtual public void RemoveNamedsOneSort1()
		{
			Strategy.RemoveCompositeRoles(Meta.NamedsOneSort1.RelationType);
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


		virtual public global::System.Int32? Index
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.Index.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Index.RelationType, value);
			}
		}

		virtual public bool ExistIndex{
			get
			{
				return Strategy.ExistUnitRole(Meta.Index.RelationType);
			}
		}

		virtual public void RemoveIndex()
		{
			Strategy.RemoveUnitRole(Meta.Index.RelationType);
		}



		virtual public Company CompanyWhereChild
		{
			get
			{
				return (Company) Strategy.GetCompositeAssociation(Meta.CompanyWhereChild.RelationType);
			}
		}

		virtual public bool ExistCompanyWhereChild
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.CompanyWhereChild.RelationType);
			}
		}


		virtual public global::Allors.Extent<Person> PeopleWhereCompany
		{
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PeopleWhereCompany.RelationType);
			}
		}

		virtual public bool ExistPeopleWhereCompany
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PeopleWhereCompany.RelationType);
			}
		}


		virtual public Company CompanyWhereNamedsOneSort2
		{
			get
			{
				return (Company) Strategy.GetCompositeAssociation(Meta.CompanyWhereNamedsOneSort2.RelationType);
			}
		}

		virtual public bool ExistCompanyWhereNamedsOneSort2
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.CompanyWhereNamedsOneSort2.RelationType);
			}
		}


		virtual public global::Allors.Extent<Company> CompaniesWhereNamedsManySort1
		{
			get
			{
				return Strategy.GetCompositeAssociations(Meta.CompaniesWhereNamedsManySort1.RelationType);
			}
		}

		virtual public bool ExistCompaniesWhereNamedsManySort1
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.CompaniesWhereNamedsManySort1.RelationType);
			}
		}


		virtual public global::Allors.Extent<Company> CompaniesWhereNamedManySort2
		{
			get
			{
				return Strategy.GetCompositeAssociations(Meta.CompaniesWhereNamedManySort2.RelationType);
			}
		}

		virtual public bool ExistCompaniesWhereNamedManySort2
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.CompaniesWhereNamedManySort2.RelationType);
			}
		}


		virtual public Company CompanyWhereNamedsOneSort1
		{
			get
			{
				return (Company) Strategy.GetCompositeAssociation(Meta.CompanyWhereNamedsOneSort1.RelationType);
			}
		}

		virtual public bool ExistCompanyWhereNamedsOneSort1
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.CompanyWhereNamedsOneSort1.RelationType);
			}
		}



		public NamedInheritedDoIt InheritedDoIt()
		{
			return new CompanyInheritedDoIt(this);
		}

        #region Test Helpers
        public static Company Create(ISession session) => (Company)session.Create(session.Database.State().M.Company.ObjectType);

        public static Company[] Create(ISession session, int count) => (Company[])session.Create(session.Database.State().M.Company.ObjectType, count);

        public static Company Instantiate(ISession session, long id) => (Company)session.Instantiate(id);

        public static Company[] Instantiate(ISession session, string[] ids) => (Company[])session.Instantiate(ids);

        public static Company[] Extent(ISession session) => (Company[])session.Extent(session.Database.State().M.Company.ObjectType).ToArray();
        #endregion
	}
}