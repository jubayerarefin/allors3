// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Media : Allors.IObject , UniquelyIdentifiable, AccessControlledObject, Deletable
	{
		private readonly IStrategy strategy;

		public Media(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaMedia Meta
		{
			get
			{
				return Allors.Meta.MetaMedia.Instance;
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

		public static Media Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Media) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Guid? Revision 
		{
			get
			{
				return (global::System.Guid?) Strategy.GetUnitRole(Meta.Revision.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Revision.RelationType, value);
			}
		}

		virtual public bool ExistRevision{
			get
			{
				return Strategy.ExistUnitRole(Meta.Revision.RelationType);
			}
		}

		virtual public void RemoveRevision()
		{
			Strategy.RemoveUnitRole(Meta.Revision.RelationType);
		}


		virtual public MediaContent MediaContent
		{ 
			get
			{
				return (MediaContent) Strategy.GetCompositeRole(Meta.MediaContent.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.MediaContent.RelationType, value);
			}
		}

		virtual public bool ExistMediaContent
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.MediaContent.RelationType);
			}
		}

		virtual public void RemoveMediaContent()
		{
			Strategy.RemoveCompositeRole(Meta.MediaContent.RelationType);
		}


		virtual public global::System.Byte[] InData 
		{
			get
			{
				return (global::System.Byte[]) Strategy.GetUnitRole(Meta.InData.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.InData.RelationType, value);
			}
		}

		virtual public bool ExistInData{
			get
			{
				return Strategy.ExistUnitRole(Meta.InData.RelationType);
			}
		}

		virtual public void RemoveInData()
		{
			Strategy.RemoveUnitRole(Meta.InData.RelationType);
		}


		virtual public global::System.String InDataUri 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.InDataUri.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.InDataUri.RelationType, value);
			}
		}

		virtual public bool ExistInDataUri{
			get
			{
				return Strategy.ExistUnitRole(Meta.InDataUri.RelationType);
			}
		}

		virtual public void RemoveInDataUri()
		{
			Strategy.RemoveUnitRole(Meta.InDataUri.RelationType);
		}


		virtual public global::System.String FileName 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.FileName.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.FileName.RelationType, value);
			}
		}

		virtual public bool ExistFileName{
			get
			{
				return Strategy.ExistUnitRole(Meta.FileName.RelationType);
			}
		}

		virtual public void RemoveFileName()
		{
			Strategy.RemoveUnitRole(Meta.FileName.RelationType);
		}


		virtual public global::System.String Type 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Type.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Type.RelationType, value);
			}
		}

		virtual public bool ExistType{
			get
			{
				return Strategy.ExistUnitRole(Meta.Type.RelationType);
			}
		}

		virtual public void RemoveType()
		{
			Strategy.RemoveUnitRole(Meta.Type.RelationType);
		}


		virtual public global::System.Guid UniqueId 
		{
			get
			{
				return (global::System.Guid) Strategy.GetUnitRole(Meta.UniqueId.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.UniqueId.RelationType, value);
			}
		}

		virtual public bool ExistUniqueId{
			get
			{
				return Strategy.ExistUnitRole(Meta.UniqueId.RelationType);
			}
		}

		virtual public void RemoveUniqueId()
		{
			Strategy.RemoveUnitRole(Meta.UniqueId.RelationType);
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



		virtual public global::Allors.Extent<Person> PeopleWherePhoto
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PeopleWherePhoto.RelationType);
			}
		}

		virtual public bool ExistPeopleWherePhoto
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PeopleWherePhoto.RelationType);
			}
		}


		virtual public Organisation OrganisationWhereImage
		{ 
			get
			{
				return (Organisation) Strategy.GetCompositeAssociation(Meta.OrganisationWhereImage.RelationType);
			}
		} 

		virtual public bool ExistOrganisationWhereImage
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.OrganisationWhereImage.RelationType);
			}
		}


		virtual public global::Allors.Extent<Organisation> OrganisationsWhereLogo
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.OrganisationsWhereLogo.RelationType);
			}
		}

		virtual public bool ExistOrganisationsWhereLogo
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.OrganisationsWhereLogo.RelationType);
			}
		}


		virtual public global::Allors.Extent<Notification> NotificationsWhereTarget
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}

		virtual public bool ExistNotificationsWhereTarget
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new MediaOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new MediaOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new MediaOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new MediaOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new MediaOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new MediaOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new MediaOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new MediaOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new MediaOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new MediaOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new MediaDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new MediaDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class MediaBuilder : Allors.ObjectBuilder<Media> , UniquelyIdentifiableBuilder, AccessControlledObjectBuilder, DeletableBuilder, global::System.IDisposable
	{		
		public MediaBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Media instance)
		{
		

			instance.InData = this.InData;
		
		

			instance.InDataUri = this.InDataUri;
		
		

			instance.FileName = this.FileName;
		
				
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		

			instance.MediaContent = this.MediaContent;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public MediaContent MediaContent {get; set;}

				/// <exclude/>
				public MediaBuilder WithMediaContent(MediaContent value)
		        {
		            if(this.MediaContent!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.MediaContent = value;
		            return this;
		        }		

				
				public global::System.Byte[] InData {get; set;}

				/// <exclude/>
				public MediaBuilder WithInData(global::System.Byte[] value)
		        {
				    if(this.InData!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.InData = value;
		            return this;
		        }	

				public global::System.String InDataUri {get; set;}

				/// <exclude/>
				public MediaBuilder WithInDataUri(global::System.String value)
		        {
				    if(this.InDataUri!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.InDataUri = value;
		            return this;
		        }	

				public global::System.String FileName {get; set;}

				/// <exclude/>
				public MediaBuilder WithFileName(global::System.String value)
		        {
				    if(this.FileName!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FileName = value;
		            return this;
		        }	

				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public MediaBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public MediaBuilder WithDeniedPermission(Permission value)
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
				public MediaBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Medias : global::Allors.ObjectsBase<Media>
	{
		public Medias(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaMedia Meta
		{
			get
			{
				return Allors.Meta.MetaMedia.Instance;
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