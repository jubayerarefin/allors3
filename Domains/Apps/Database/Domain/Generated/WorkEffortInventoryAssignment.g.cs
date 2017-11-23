// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class WorkEffortInventoryAssignment : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public WorkEffortInventoryAssignment(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaWorkEffortInventoryAssignment Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortInventoryAssignment.Instance;
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

		public static WorkEffortInventoryAssignment Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (WorkEffortInventoryAssignment) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public WorkEffort Assignment
		{ 
			get
			{
				return (WorkEffort) Strategy.GetCompositeRole(Meta.Assignment.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Assignment.RelationType, value);
			}
		}

		virtual public bool ExistAssignment
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Assignment.RelationType);
			}
		}

		virtual public void RemoveAssignment()
		{
			Strategy.RemoveCompositeRole(Meta.Assignment.RelationType);
		}


		virtual public InventoryItem InventoryItem
		{ 
			get
			{
				return (InventoryItem) Strategy.GetCompositeRole(Meta.InventoryItem.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.InventoryItem.RelationType, value);
			}
		}

		virtual public bool ExistInventoryItem
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.InventoryItem.RelationType);
			}
		}

		virtual public void RemoveInventoryItem()
		{
			Strategy.RemoveCompositeRole(Meta.InventoryItem.RelationType);
		}


		virtual public global::System.Int32? Quantity 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.Quantity.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Quantity.RelationType, value);
			}
		}

		virtual public bool ExistQuantity{
			get
			{
				return Strategy.ExistUnitRole(Meta.Quantity.RelationType);
			}
		}

		virtual public void RemoveQuantity()
		{
			Strategy.RemoveUnitRole(Meta.Quantity.RelationType);
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



		virtual public global::Allors.Extent<WorkEffortVersion> WorkEffortVersionsWhereInventoryItemsNeeded
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortVersionsWhereInventoryItemsNeeded.RelationType);
			}
		}

		virtual public bool ExistWorkEffortVersionsWhereInventoryItemsNeeded
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortVersionsWhereInventoryItemsNeeded.RelationType);
			}
		}


		virtual public WorkEffort WorkEffortWhereInventoryItemsNeeded
		{ 
			get
			{
				return (WorkEffort) Strategy.GetCompositeAssociation(Meta.WorkEffortWhereInventoryItemsNeeded.RelationType);
			}
		} 

		virtual public bool ExistWorkEffortWhereInventoryItemsNeeded
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.WorkEffortWhereInventoryItemsNeeded.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new WorkEffortInventoryAssignmentOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new WorkEffortInventoryAssignmentOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new WorkEffortInventoryAssignmentOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new WorkEffortInventoryAssignmentOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new WorkEffortInventoryAssignmentOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new WorkEffortInventoryAssignmentOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new WorkEffortInventoryAssignmentOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new WorkEffortInventoryAssignmentOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new WorkEffortInventoryAssignmentOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new WorkEffortInventoryAssignmentOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class WorkEffortInventoryAssignmentBuilder : Allors.ObjectBuilder<WorkEffortInventoryAssignment> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public WorkEffortInventoryAssignmentBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(WorkEffortInventoryAssignment instance)
		{
			

			if(this.Quantity.HasValue)
			{
				instance.Quantity = this.Quantity.Value;
			}			
		
		

			instance.Assignment = this.Assignment;

		

			instance.InventoryItem = this.InventoryItem;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public WorkEffort Assignment {get; set;}

				/// <exclude/>
				public WorkEffortInventoryAssignmentBuilder WithAssignment(WorkEffort value)
		        {
		            if(this.Assignment!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Assignment = value;
		            return this;
		        }		

				
				public InventoryItem InventoryItem {get; set;}

				/// <exclude/>
				public WorkEffortInventoryAssignmentBuilder WithInventoryItem(InventoryItem value)
		        {
		            if(this.InventoryItem!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.InventoryItem = value;
		            return this;
		        }		

				
				public global::System.Int32? Quantity {get; set;}

				/// <exclude/>
				public WorkEffortInventoryAssignmentBuilder WithQuantity(global::System.Int32? value)
		        {
				    if(this.Quantity!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Quantity = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public WorkEffortInventoryAssignmentBuilder WithDeniedPermission(Permission value)
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
				public WorkEffortInventoryAssignmentBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class WorkEffortInventoryAssignments : global::Allors.ObjectsBase<WorkEffortInventoryAssignment>
	{
		public WorkEffortInventoryAssignments(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaWorkEffortInventoryAssignment Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortInventoryAssignment.Instance;
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