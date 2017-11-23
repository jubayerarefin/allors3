// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Locale : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public Locale(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaLocale Meta
		{
			get
			{
				return Allors.Meta.MetaLocale.Instance;
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

		public static Locale Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Locale) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public Language Language
		{ 
			get
			{
				return (Language) Strategy.GetCompositeRole(Meta.Language.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Language.RelationType, value);
			}
		}

		virtual public bool ExistLanguage
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Language.RelationType);
			}
		}

		virtual public void RemoveLanguage()
		{
			Strategy.RemoveCompositeRole(Meta.Language.RelationType);
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



		virtual public global::Allors.Extent<Singleton> SingletonsWhereDefaultLocale
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SingletonsWhereDefaultLocale.RelationType);
			}
		}

		virtual public bool ExistSingletonsWhereDefaultLocale
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SingletonsWhereDefaultLocale.RelationType);
			}
		}


		virtual public Singleton SingletonWhereLocale
		{ 
			get
			{
				return (Singleton) Strategy.GetCompositeAssociation(Meta.SingletonWhereLocale.RelationType);
			}
		} 

		virtual public bool ExistSingletonWhereLocale
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.SingletonWhereLocale.RelationType);
			}
		}


		virtual public global::Allors.Extent<Event> EventsWhereLocale
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EventsWhereLocale.RelationType);
			}
		}

		virtual public bool ExistEventsWhereLocale
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EventsWhereLocale.RelationType);
			}
		}


		virtual public global::Allors.Extent<NewsItem> NewsItemsWhereLocale
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.NewsItemsWhereLocale.RelationType);
			}
		}

		virtual public bool ExistNewsItemsWhereLocale
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.NewsItemsWhereLocale.RelationType);
			}
		}


		virtual public global::Allors.Extent<Localised> LocalisedsWhereLocale
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.LocalisedsWhereLocale.RelationType);
			}
		}

		virtual public bool ExistLocalisedsWhereLocale
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.LocalisedsWhereLocale.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new LocaleOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new LocaleOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new LocaleOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new LocaleOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new LocaleOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new LocaleOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new LocaleOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new LocaleOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new LocaleOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new LocaleOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class LocaleBuilder : Allors.ObjectBuilder<Locale> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public LocaleBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Locale instance)
		{

			instance.Name = this.Name;
		
		

			instance.Language = this.Language;

		

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


				public global::System.String Name {get; set;}

				/// <exclude/>
				public LocaleBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public Language Language {get; set;}

				/// <exclude/>
				public LocaleBuilder WithLanguage(Language value)
		        {
		            if(this.Language!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Language = value;
		            return this;
		        }		

				
				public Country Country {get; set;}

				/// <exclude/>
				public LocaleBuilder WithCountry(Country value)
		        {
		            if(this.Country!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Country = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public LocaleBuilder WithDeniedPermission(Permission value)
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
				public LocaleBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Locales : global::Allors.ObjectsBase<Locale>
	{
		public Locales(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaLocale Meta
		{
			get
			{
				return Allors.Meta.MetaLocale.Instance;
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