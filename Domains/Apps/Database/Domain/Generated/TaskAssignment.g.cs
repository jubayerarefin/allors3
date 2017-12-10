// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class TaskAssignment : Allors.IObject , AccessControlledObject, Deletable
	{
		private readonly IStrategy strategy;

		public TaskAssignment(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaTaskAssignment Meta
		{
			get
			{
				return Allors.Meta.MetaTaskAssignment.Instance;
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

		public static TaskAssignment Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (TaskAssignment) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public User User
		{ 
			get
			{
				return (User) Strategy.GetCompositeRole(Meta.User.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.User.RelationType, value);
			}
		}

		virtual public bool ExistUser
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.User.RelationType);
			}
		}

		virtual public void RemoveUser()
		{
			Strategy.RemoveCompositeRole(Meta.User.RelationType);
		}


		virtual public Notification Notification
		{ 
			get
			{
				return (Notification) Strategy.GetCompositeRole(Meta.Notification.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Notification.RelationType, value);
			}
		}

		virtual public bool ExistNotification
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Notification.RelationType);
			}
		}

		virtual public void RemoveNotification()
		{
			Strategy.RemoveCompositeRole(Meta.Notification.RelationType);
		}


		virtual public Task Task
		{ 
			get
			{
				return (Task) Strategy.GetCompositeRole(Meta.Task.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Task.RelationType, value);
			}
		}

		virtual public bool ExistTask
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Task.RelationType);
			}
		}

		virtual public void RemoveTask()
		{
			Strategy.RemoveCompositeRole(Meta.Task.RelationType);
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



		virtual public TaskList TaskListWhereTaskAssignment
		{ 
			get
			{
				return (TaskList) Strategy.GetCompositeAssociation(Meta.TaskListWhereTaskAssignment.RelationType);
			}
		} 

		virtual public bool ExistTaskListWhereTaskAssignment
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.TaskListWhereTaskAssignment.RelationType);
			}
		}


		virtual public TaskList TaskListWhereOpenTaskAssignment
		{ 
			get
			{
				return (TaskList) Strategy.GetCompositeAssociation(Meta.TaskListWhereOpenTaskAssignment.RelationType);
			}
		} 

		virtual public bool ExistTaskListWhereOpenTaskAssignment
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.TaskListWhereOpenTaskAssignment.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new TaskAssignmentOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new TaskAssignmentOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new TaskAssignmentOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new TaskAssignmentOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new TaskAssignmentOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new TaskAssignmentOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new TaskAssignmentOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new TaskAssignmentOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new TaskAssignmentOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new TaskAssignmentOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new TaskAssignmentDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new TaskAssignmentDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class TaskAssignmentBuilder : Allors.ObjectBuilder<TaskAssignment> , AccessControlledObjectBuilder, DeletableBuilder, global::System.IDisposable
	{		
		public TaskAssignmentBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(TaskAssignment instance)
		{

			instance.User = this.User;

		

			instance.Notification = this.Notification;

		

			instance.Task = this.Task;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public User User {get; set;}

				/// <exclude/>
				public TaskAssignmentBuilder WithUser(User value)
		        {
		            if(this.User!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.User = value;
		            return this;
		        }		

				
				public Notification Notification {get; set;}

				/// <exclude/>
				public TaskAssignmentBuilder WithNotification(Notification value)
		        {
		            if(this.Notification!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Notification = value;
		            return this;
		        }		

				
				public Task Task {get; set;}

				/// <exclude/>
				public TaskAssignmentBuilder WithTask(Task value)
		        {
		            if(this.Task!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Task = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public TaskAssignmentBuilder WithDeniedPermission(Permission value)
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
				public TaskAssignmentBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class TaskAssignments : global::Allors.ObjectsBase<TaskAssignment>
	{
		public TaskAssignments(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaTaskAssignment Meta
		{
			get
			{
				return Allors.Meta.MetaTaskAssignment.Instance;
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