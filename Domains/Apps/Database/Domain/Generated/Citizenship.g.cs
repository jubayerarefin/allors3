// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Citizenship : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public Citizenship(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaCitizenship Meta
		{
			get
			{
				return Allors.Meta.MetaCitizenship.Instance;
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

		public static Citizenship Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Citizenship) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::Allors.Extent<Passport> Passports
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Passports.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Passports.RelationType, value);
			}
		}

		virtual public void AddPassport (Passport value)
		{
			Strategy.AddCompositeRole(Meta.Passports.RelationType, value);
		}

		virtual public void RemovePassport (Passport value)
		{
			Strategy.RemoveCompositeRole(Meta.Passports.RelationType, value);
		}

		virtual public bool ExistPassports
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Passports.RelationType);
			}
		}

		virtual public void RemovePassports()
		{
			Strategy.RemoveCompositeRoles(Meta.Passports.RelationType);
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



		virtual public Person PersonWhereCitizenship
		{ 
			get
			{
				return (Person) Strategy.GetCompositeAssociation(Meta.PersonWhereCitizenship.RelationType);
			}
		} 

		virtual public bool ExistPersonWhereCitizenship
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PersonWhereCitizenship.RelationType);
			}
		}


		virtual public PersonVersion PersonVersionWhereCitizenship
		{ 
			get
			{
				return (PersonVersion) Strategy.GetCompositeAssociation(Meta.PersonVersionWhereCitizenship.RelationType);
			}
		} 

		virtual public bool ExistPersonVersionWhereCitizenship
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PersonVersionWhereCitizenship.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new CitizenshipOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new CitizenshipOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new CitizenshipOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new CitizenshipOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new CitizenshipOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new CitizenshipOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new CitizenshipOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new CitizenshipOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new CitizenshipOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new CitizenshipOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class CitizenshipBuilder : Allors.ObjectBuilder<Citizenship> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public CitizenshipBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Citizenship instance)
		{
			if(this.Passports!=null)
			{
				instance.Passports = this.Passports.ToArray();
			}
		

			instance.Country = this.Country;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Collections.Generic.List<Passport> Passports {get; set;}	

				/// <exclude/>
				public CitizenshipBuilder WithPassport(Passport value)
		        {
					if(this.Passports == null)
					{
						this.Passports = new global::System.Collections.Generic.List<Passport>(); 
					}
		            this.Passports.Add(value);
		            return this;
		        }		

				
				public Country Country {get; set;}

				/// <exclude/>
				public CitizenshipBuilder WithCountry(Country value)
		        {
		            if(this.Country!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Country = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public CitizenshipBuilder WithDeniedPermission(Permission value)
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
				public CitizenshipBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Citizenships : global::Allors.ObjectsBase<Citizenship>
	{
		public Citizenships(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaCitizenship Meta
		{
			get
			{
				return Allors.Meta.MetaCitizenship.Instance;
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