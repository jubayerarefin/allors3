// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Singleton : Allors.IObject , Auditable
	{
		private readonly IStrategy strategy;

		public Singleton(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSingleton Meta
		{
			get
			{
				return Allors.Meta.MetaSingleton.Instance;
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

		public static Singleton Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Singleton) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Locale DefaultLocale
		{ 
			get
			{
				return (Locale) Strategy.GetCompositeRole(Meta.DefaultLocale.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.DefaultLocale.RelationType, value);
			}
		}

		virtual public bool ExistDefaultLocale
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.DefaultLocale.RelationType);
			}
		}

		virtual public void RemoveDefaultLocale()
		{
			Strategy.RemoveCompositeRole(Meta.DefaultLocale.RelationType);
		}


		virtual public global::Allors.Extent<Locale> Locales
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Locales.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Locales.RelationType, value);
			}
		}

		virtual public void AddLocale (Locale value)
		{
			Strategy.AddCompositeRole(Meta.Locales.RelationType, value);
		}

		virtual public void RemoveLocale (Locale value)
		{
			Strategy.RemoveCompositeRole(Meta.Locales.RelationType, value);
		}

		virtual public bool ExistLocales
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Locales.RelationType);
			}
		}

		virtual public void RemoveLocales()
		{
			Strategy.RemoveCompositeRoles(Meta.Locales.RelationType);
		}


		virtual public User Guest
		{ 
			get
			{
				return (User) Strategy.GetCompositeRole(Meta.Guest.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Guest.RelationType, value);
			}
		}

		virtual public bool ExistGuest
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Guest.RelationType);
			}
		}

		virtual public void RemoveGuest()
		{
			Strategy.RemoveCompositeRole(Meta.Guest.RelationType);
		}


		virtual public SecurityToken InitialSecurityToken
		{ 
			get
			{
				return (SecurityToken) Strategy.GetCompositeRole(Meta.InitialSecurityToken.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.InitialSecurityToken.RelationType, value);
			}
		}

		virtual public bool ExistInitialSecurityToken
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.InitialSecurityToken.RelationType);
			}
		}

		virtual public void RemoveInitialSecurityToken()
		{
			Strategy.RemoveCompositeRole(Meta.InitialSecurityToken.RelationType);
		}


		virtual public SecurityToken DefaultSecurityToken
		{ 
			get
			{
				return (SecurityToken) Strategy.GetCompositeRole(Meta.DefaultSecurityToken.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.DefaultSecurityToken.RelationType, value);
			}
		}

		virtual public bool ExistDefaultSecurityToken
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.DefaultSecurityToken.RelationType);
			}
		}

		virtual public void RemoveDefaultSecurityToken()
		{
			Strategy.RemoveCompositeRole(Meta.DefaultSecurityToken.RelationType);
		}


		virtual public AccessControl CreatorsAccessControl
		{ 
			get
			{
				return (AccessControl) Strategy.GetCompositeRole(Meta.CreatorsAccessControl.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CreatorsAccessControl.RelationType, value);
			}
		}

		virtual public bool ExistCreatorsAccessControl
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CreatorsAccessControl.RelationType);
			}
		}

		virtual public void RemoveCreatorsAccessControl()
		{
			Strategy.RemoveCompositeRole(Meta.CreatorsAccessControl.RelationType);
		}


		virtual public AccessControl GuestAccessControl
		{ 
			get
			{
				return (AccessControl) Strategy.GetCompositeRole(Meta.GuestAccessControl.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.GuestAccessControl.RelationType, value);
			}
		}

		virtual public bool ExistGuestAccessControl
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.GuestAccessControl.RelationType);
			}
		}

		virtual public void RemoveGuestAccessControl()
		{
			Strategy.RemoveCompositeRole(Meta.GuestAccessControl.RelationType);
		}


		virtual public AccessControl AdministratorsAccessControl
		{ 
			get
			{
				return (AccessControl) Strategy.GetCompositeRole(Meta.AdministratorsAccessControl.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.AdministratorsAccessControl.RelationType, value);
			}
		}

		virtual public bool ExistAdministratorsAccessControl
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.AdministratorsAccessControl.RelationType);
			}
		}

		virtual public void RemoveAdministratorsAccessControl()
		{
			Strategy.RemoveCompositeRole(Meta.AdministratorsAccessControl.RelationType);
		}


		virtual public SecurityToken AdministratorSecurityToken
		{ 
			get
			{
				return (SecurityToken) Strategy.GetCompositeRole(Meta.AdministratorSecurityToken.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.AdministratorSecurityToken.RelationType, value);
			}
		}

		virtual public bool ExistAdministratorSecurityToken
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.AdministratorSecurityToken.RelationType);
			}
		}

		virtual public void RemoveAdministratorSecurityToken()
		{
			Strategy.RemoveCompositeRole(Meta.AdministratorSecurityToken.RelationType);
		}


		virtual public Currency PreviousCurrency
		{ 
			get
			{
				return (Currency) Strategy.GetCompositeRole(Meta.PreviousCurrency.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PreviousCurrency.RelationType, value);
			}
		}

		virtual public bool ExistPreviousCurrency
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PreviousCurrency.RelationType);
			}
		}

		virtual public void RemovePreviousCurrency()
		{
			Strategy.RemoveCompositeRole(Meta.PreviousCurrency.RelationType);
		}


		virtual public Currency PreferredCurrency
		{ 
			get
			{
				return (Currency) Strategy.GetCompositeRole(Meta.PreferredCurrency.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PreferredCurrency.RelationType, value);
			}
		}

		virtual public bool ExistPreferredCurrency
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PreferredCurrency.RelationType);
			}
		}

		virtual public void RemovePreferredCurrency()
		{
			Strategy.RemoveCompositeRole(Meta.PreferredCurrency.RelationType);
		}


		virtual public Media NoImageAvailableImage
		{ 
			get
			{
				return (Media) Strategy.GetCompositeRole(Meta.NoImageAvailableImage.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.NoImageAvailableImage.RelationType, value);
			}
		}

		virtual public bool ExistNoImageAvailableImage
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.NoImageAvailableImage.RelationType);
			}
		}

		virtual public void RemoveNoImageAvailableImage()
		{
			Strategy.RemoveCompositeRole(Meta.NoImageAvailableImage.RelationType);
		}


		virtual public InternalOrganisation InternalOrganisation
		{ 
			get
			{
				return (InternalOrganisation) Strategy.GetCompositeRole(Meta.InternalOrganisation.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.InternalOrganisation.RelationType, value);
			}
		}

		virtual public bool ExistInternalOrganisation
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.InternalOrganisation.RelationType);
			}
		}

		virtual public void RemoveInternalOrganisation()
		{
			Strategy.RemoveCompositeRole(Meta.InternalOrganisation.RelationType);
		}


		virtual public User CreatedBy
		{ 
			get
			{
				return (User) Strategy.GetCompositeRole(Meta.CreatedBy.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CreatedBy.RelationType, value);
			}
		}

		virtual public bool ExistCreatedBy
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CreatedBy.RelationType);
			}
		}

		virtual public void RemoveCreatedBy()
		{
			Strategy.RemoveCompositeRole(Meta.CreatedBy.RelationType);
		}


		virtual public User LastModifiedBy
		{ 
			get
			{
				return (User) Strategy.GetCompositeRole(Meta.LastModifiedBy.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.LastModifiedBy.RelationType, value);
			}
		}

		virtual public bool ExistLastModifiedBy
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.LastModifiedBy.RelationType);
			}
		}

		virtual public void RemoveLastModifiedBy()
		{
			Strategy.RemoveCompositeRole(Meta.LastModifiedBy.RelationType);
		}


		virtual public global::System.DateTime? CreationDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.CreationDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.CreationDate.RelationType, value);
			}
		}

		virtual public bool ExistCreationDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.CreationDate.RelationType);
			}
		}

		virtual public void RemoveCreationDate()
		{
			Strategy.RemoveUnitRole(Meta.CreationDate.RelationType);
		}


		virtual public global::System.DateTime? LastModifiedDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.LastModifiedDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.LastModifiedDate.RelationType, value);
			}
		}

		virtual public bool ExistLastModifiedDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.LastModifiedDate.RelationType);
			}
		}

		virtual public void RemoveLastModifiedDate()
		{
			Strategy.RemoveUnitRole(Meta.LastModifiedDate.RelationType);
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



		public ObjectOnBuild OnBuild()
		{ 
			var method = new SingletonOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SingletonOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SingletonOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SingletonOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SingletonOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SingletonOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SingletonOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SingletonOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SingletonOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SingletonOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SingletonBuilder : Allors.ObjectBuilder<Singleton> , AuditableBuilder, global::System.IDisposable
	{		
		public SingletonBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Singleton instance)
		{
			

			if(this.CreationDate.HasValue)
			{
				instance.CreationDate = this.CreationDate.Value;
			}			
		
		
			

			if(this.LastModifiedDate.HasValue)
			{
				instance.LastModifiedDate = this.LastModifiedDate.Value;
			}			
		
		

			instance.DefaultLocale = this.DefaultLocale;

		
			if(this.Locales!=null)
			{
				instance.Locales = this.Locales.ToArray();
			}
		

			instance.Guest = this.Guest;

		

			instance.InitialSecurityToken = this.InitialSecurityToken;

		

			instance.DefaultSecurityToken = this.DefaultSecurityToken;

		

			instance.CreatorsAccessControl = this.CreatorsAccessControl;

		

			instance.GuestAccessControl = this.GuestAccessControl;

		

			instance.AdministratorsAccessControl = this.AdministratorsAccessControl;

		

			instance.AdministratorSecurityToken = this.AdministratorSecurityToken;

		

			instance.PreviousCurrency = this.PreviousCurrency;

		

			instance.PreferredCurrency = this.PreferredCurrency;

		

			instance.NoImageAvailableImage = this.NoImageAvailableImage;

		

			instance.InternalOrganisation = this.InternalOrganisation;

		

			instance.CreatedBy = this.CreatedBy;

		

			instance.LastModifiedBy = this.LastModifiedBy;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Locale DefaultLocale {get; set;}

				/// <exclude/>
				public SingletonBuilder WithDefaultLocale(Locale value)
		        {
		            if(this.DefaultLocale!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.DefaultLocale = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Locale> Locales {get; set;}	

				/// <exclude/>
				public SingletonBuilder WithLocale(Locale value)
		        {
					if(this.Locales == null)
					{
						this.Locales = new global::System.Collections.Generic.List<Locale>(); 
					}
		            this.Locales.Add(value);
		            return this;
		        }		

				
				public User Guest {get; set;}

				/// <exclude/>
				public SingletonBuilder WithGuest(User value)
		        {
		            if(this.Guest!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Guest = value;
		            return this;
		        }		

				
				public SecurityToken InitialSecurityToken {get; set;}

				/// <exclude/>
				public SingletonBuilder WithInitialSecurityToken(SecurityToken value)
		        {
		            if(this.InitialSecurityToken!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.InitialSecurityToken = value;
		            return this;
		        }		

				
				public SecurityToken DefaultSecurityToken {get; set;}

				/// <exclude/>
				public SingletonBuilder WithDefaultSecurityToken(SecurityToken value)
		        {
		            if(this.DefaultSecurityToken!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.DefaultSecurityToken = value;
		            return this;
		        }		

				
				public AccessControl CreatorsAccessControl {get; set;}

				/// <exclude/>
				public SingletonBuilder WithCreatorsAccessControl(AccessControl value)
		        {
		            if(this.CreatorsAccessControl!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CreatorsAccessControl = value;
		            return this;
		        }		

				
				public AccessControl GuestAccessControl {get; set;}

				/// <exclude/>
				public SingletonBuilder WithGuestAccessControl(AccessControl value)
		        {
		            if(this.GuestAccessControl!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.GuestAccessControl = value;
		            return this;
		        }		

				
				public AccessControl AdministratorsAccessControl {get; set;}

				/// <exclude/>
				public SingletonBuilder WithAdministratorsAccessControl(AccessControl value)
		        {
		            if(this.AdministratorsAccessControl!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.AdministratorsAccessControl = value;
		            return this;
		        }		

				
				public SecurityToken AdministratorSecurityToken {get; set;}

				/// <exclude/>
				public SingletonBuilder WithAdministratorSecurityToken(SecurityToken value)
		        {
		            if(this.AdministratorSecurityToken!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.AdministratorSecurityToken = value;
		            return this;
		        }		

				
				public Currency PreviousCurrency {get; set;}

				/// <exclude/>
				public SingletonBuilder WithPreviousCurrency(Currency value)
		        {
		            if(this.PreviousCurrency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.PreviousCurrency = value;
		            return this;
		        }		

				
				public Currency PreferredCurrency {get; set;}

				/// <exclude/>
				public SingletonBuilder WithPreferredCurrency(Currency value)
		        {
		            if(this.PreferredCurrency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.PreferredCurrency = value;
		            return this;
		        }		

				
				public Media NoImageAvailableImage {get; set;}

				/// <exclude/>
				public SingletonBuilder WithNoImageAvailableImage(Media value)
		        {
		            if(this.NoImageAvailableImage!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.NoImageAvailableImage = value;
		            return this;
		        }		

				
				public InternalOrganisation InternalOrganisation {get; set;}

				/// <exclude/>
				public SingletonBuilder WithInternalOrganisation(InternalOrganisation value)
		        {
		            if(this.InternalOrganisation!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.InternalOrganisation = value;
		            return this;
		        }		

				
				public User CreatedBy {get; set;}

				/// <exclude/>
				public SingletonBuilder WithCreatedBy(User value)
		        {
		            if(this.CreatedBy!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CreatedBy = value;
		            return this;
		        }		

				
				public User LastModifiedBy {get; set;}

				/// <exclude/>
				public SingletonBuilder WithLastModifiedBy(User value)
		        {
		            if(this.LastModifiedBy!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.LastModifiedBy = value;
		            return this;
		        }		

				
				public global::System.DateTime? CreationDate {get; set;}

				/// <exclude/>
				public SingletonBuilder WithCreationDate(global::System.DateTime? value)
		        {
				    if(this.CreationDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.CreationDate = value;
		            return this;
		        }	

				public global::System.DateTime? LastModifiedDate {get; set;}

				/// <exclude/>
				public SingletonBuilder WithLastModifiedDate(global::System.DateTime? value)
		        {
				    if(this.LastModifiedDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.LastModifiedDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SingletonBuilder WithDeniedPermission(Permission value)
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
				public SingletonBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Singletons : global::Allors.ObjectsBase<Singleton>
	{
		public Singletons(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSingleton Meta
		{
			get
			{
				return Allors.Meta.MetaSingleton.Instance;
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