// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Role : Allors.IObject , AccessControlledObject, UniquelyIdentifiable
	{
		private readonly IStrategy strategy;

		public Role(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaRole Meta
		{
			get
			{
				return Allors.Meta.MetaRole.Instance;
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

		public static Role Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Role) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::Allors.Extent<Permission> Permissions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Permissions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Permissions.RelationType, value);
			}
		}

		virtual public void AddPermission (Permission value)
		{
			Strategy.AddCompositeRole(Meta.Permissions.RelationType, value);
		}

		virtual public void RemovePermission (Permission value)
		{
			Strategy.RemoveCompositeRole(Meta.Permissions.RelationType, value);
		}

		virtual public bool ExistPermissions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Permissions.RelationType);
			}
		}

		virtual public void RemovePermissions()
		{
			Strategy.RemoveCompositeRoles(Meta.Permissions.RelationType);
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



		virtual public global::Allors.Extent<AccessControl> AccessControlsWhereRole
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.AccessControlsWhereRole.RelationType);
			}
		}

		virtual public bool ExistAccessControlsWhereRole
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.AccessControlsWhereRole.RelationType);
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
			var method = new RoleOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new RoleOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new RoleOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new RoleOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new RoleOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new RoleOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new RoleOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new RoleOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new RoleOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new RoleOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class RoleBuilder : Allors.ObjectBuilder<Role> , AccessControlledObjectBuilder, UniquelyIdentifiableBuilder, global::System.IDisposable
	{		
		public RoleBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Role instance)
		{

			instance.Name = this.Name;
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
			if(this.Permissions!=null)
			{
				instance.Permissions = this.Permissions.ToArray();
			}
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Collections.Generic.List<Permission> Permissions {get; set;}	

				/// <exclude/>
				public RoleBuilder WithPermission(Permission value)
		        {
					if(this.Permissions == null)
					{
						this.Permissions = new global::System.Collections.Generic.List<Permission>(); 
					}
		            this.Permissions.Add(value);
		            return this;
		        }		

				
				public global::System.String Name {get; set;}

				/// <exclude/>
				public RoleBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public RoleBuilder WithDeniedPermission(Permission value)
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
				public RoleBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				
				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public RoleBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	


	}

	public partial class Roles : global::Allors.ObjectsBase<Role>
	{
		public Roles(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaRole Meta
		{
			get
			{
				return Allors.Meta.MetaRole.Instance;
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