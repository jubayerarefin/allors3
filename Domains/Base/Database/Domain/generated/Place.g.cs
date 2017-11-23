// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Place : Allors.IObject , Object
	{
		private readonly IStrategy strategy;

		public Place(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPlace Meta
		{
			get
			{
				return Allors.Meta.MetaPlace.Instance;
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

		public static Place Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Place) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Country Country
		{ 
			get
			{
				return (Country) Strategy.GetCompositeRole(Meta.Country.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Country.RelationType, value);
			}
		}

		virtual public bool ExistCountry
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Country.RelationType);
			}
		}

		virtual public void RemoveCountry()
		{
			Strategy.RemoveCompositeRole(Meta.Country.RelationType);
		}


		virtual public global::System.String City 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.City.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.City.RelationType, value);
			}
		}

		virtual public bool ExistCity{
			get
			{
				return Strategy.ExistUnitRole(Meta.City.RelationType);
			}
		}

		virtual public void RemoveCity()
		{
			Strategy.RemoveUnitRole(Meta.City.RelationType);
		}


		virtual public global::System.String PostalCode 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.PostalCode.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.PostalCode.RelationType, value);
			}
		}

		virtual public bool ExistPostalCode{
			get
			{
				return Strategy.ExistUnitRole(Meta.PostalCode.RelationType);
			}
		}

		virtual public void RemovePostalCode()
		{
			Strategy.RemoveUnitRole(Meta.PostalCode.RelationType);
		}



		virtual public global::Allors.Extent<Address> AddressesWherePlace
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.AddressesWherePlace.RelationType);
			}
		}

		virtual public bool ExistAddressesWherePlace
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.AddressesWherePlace.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new PlaceOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PlaceOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PlaceOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PlaceOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PlaceOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PlaceOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PlaceOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PlaceOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PlaceOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PlaceOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PlaceBuilder : Allors.ObjectBuilder<Place> , ObjectBuilder, global::System.IDisposable
	{		
		public PlaceBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Place instance)
		{

			instance.City = this.City;
		
		

			instance.PostalCode = this.PostalCode;
		
		

			instance.Country = this.Country;

		
		}


				public Country Country {get; set;}

				/// <exclude/>
				public PlaceBuilder WithCountry(Country value)
		        {
		            if(this.Country!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Country = value;
		            return this;
		        }		

				
				public global::System.String City {get; set;}

				/// <exclude/>
				public PlaceBuilder WithCity(global::System.String value)
		        {
				    if(this.City!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.City = value;
		            return this;
		        }	

				public global::System.String PostalCode {get; set;}

				/// <exclude/>
				public PlaceBuilder WithPostalCode(global::System.String value)
		        {
				    if(this.PostalCode!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.PostalCode = value;
		            return this;
		        }	


	}

	public partial class Places : global::Allors.ObjectsBase<Place>
	{
		public Places(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPlace Meta
		{
			get
			{
				return Allors.Meta.MetaPlace.Instance;
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