// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class PositionResponsibility : Allors.IObject , Commentable, AccessControlledObject
	{
		private readonly IStrategy strategy;

		public PositionResponsibility(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPositionResponsibility Meta
		{
			get
			{
				return Allors.Meta.MetaPositionResponsibility.Instance;
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

		public static PositionResponsibility Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (PositionResponsibility) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Position Position
		{ 
			get
			{
				return (Position) Strategy.GetCompositeRole(Meta.Position.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Position.RelationType, value);
			}
		}

		virtual public bool ExistPosition
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Position.RelationType);
			}
		}

		virtual public void RemovePosition()
		{
			Strategy.RemoveCompositeRole(Meta.Position.RelationType);
		}


		virtual public Responsibility Responsibility
		{ 
			get
			{
				return (Responsibility) Strategy.GetCompositeRole(Meta.Responsibility.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Responsibility.RelationType, value);
			}
		}

		virtual public bool ExistResponsibility
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Responsibility.RelationType);
			}
		}

		virtual public void RemoveResponsibility()
		{
			Strategy.RemoveCompositeRole(Meta.Responsibility.RelationType);
		}


		virtual public global::System.String Comment 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Comment.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Comment.RelationType, value);
			}
		}

		virtual public bool ExistComment{
			get
			{
				return Strategy.ExistUnitRole(Meta.Comment.RelationType);
			}
		}

		virtual public void RemoveComment()
		{
			Strategy.RemoveUnitRole(Meta.Comment.RelationType);
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
			var method = new PositionResponsibilityOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PositionResponsibilityOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PositionResponsibilityOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PositionResponsibilityOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PositionResponsibilityOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PositionResponsibilityOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PositionResponsibilityOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PositionResponsibilityOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PositionResponsibilityOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PositionResponsibilityOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PositionResponsibilityBuilder : Allors.ObjectBuilder<PositionResponsibility> , CommentableBuilder, AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public PositionResponsibilityBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(PositionResponsibility instance)
		{

			instance.Comment = this.Comment;
		
		

			instance.Position = this.Position;

		

			instance.Responsibility = this.Responsibility;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Position Position {get; set;}

				/// <exclude/>
				public PositionResponsibilityBuilder WithPosition(Position value)
		        {
		            if(this.Position!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Position = value;
		            return this;
		        }		

				
				public Responsibility Responsibility {get; set;}

				/// <exclude/>
				public PositionResponsibilityBuilder WithResponsibility(Responsibility value)
		        {
		            if(this.Responsibility!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Responsibility = value;
		            return this;
		        }		

				
				public global::System.String Comment {get; set;}

				/// <exclude/>
				public PositionResponsibilityBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PositionResponsibilityBuilder WithDeniedPermission(Permission value)
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
				public PositionResponsibilityBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class PositionResponsibilities : global::Allors.ObjectsBase<PositionResponsibility>
	{
		public PositionResponsibilities(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPositionResponsibility Meta
		{
			get
			{
				return Allors.Meta.MetaPositionResponsibility.Instance;
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