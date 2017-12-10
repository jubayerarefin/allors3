// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class WorkEffortFixedAssetAssignment : Allors.IObject , Commentable, AccessControlledObject, Period
	{
		private readonly IStrategy strategy;

		public WorkEffortFixedAssetAssignment(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaWorkEffortFixedAssetAssignment Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortFixedAssetAssignment.Instance;
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

		public static WorkEffortFixedAssetAssignment Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (WorkEffortFixedAssetAssignment) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public AssetAssignmentStatus AssetAssignmentStatus
		{ 
			get
			{
				return (AssetAssignmentStatus) Strategy.GetCompositeRole(Meta.AssetAssignmentStatus.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.AssetAssignmentStatus.RelationType, value);
			}
		}

		virtual public bool ExistAssetAssignmentStatus
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.AssetAssignmentStatus.RelationType);
			}
		}

		virtual public void RemoveAssetAssignmentStatus()
		{
			Strategy.RemoveCompositeRole(Meta.AssetAssignmentStatus.RelationType);
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


		virtual public global::System.Decimal? AllocatedCost 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.AllocatedCost.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AllocatedCost.RelationType, value);
			}
		}

		virtual public bool ExistAllocatedCost{
			get
			{
				return Strategy.ExistUnitRole(Meta.AllocatedCost.RelationType);
			}
		}

		virtual public void RemoveAllocatedCost()
		{
			Strategy.RemoveUnitRole(Meta.AllocatedCost.RelationType);
		}


		virtual public FixedAsset FixedAsset
		{ 
			get
			{
				return (FixedAsset) Strategy.GetCompositeRole(Meta.FixedAsset.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.FixedAsset.RelationType, value);
			}
		}

		virtual public bool ExistFixedAsset
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.FixedAsset.RelationType);
			}
		}

		virtual public void RemoveFixedAsset()
		{
			Strategy.RemoveCompositeRole(Meta.FixedAsset.RelationType);
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


		virtual public global::System.DateTime FromDate 
		{
			get
			{
				return (global::System.DateTime) Strategy.GetUnitRole(Meta.FromDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.FromDate.RelationType, value);
			}
		}

		virtual public bool ExistFromDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.FromDate.RelationType);
			}
		}

		virtual public void RemoveFromDate()
		{
			Strategy.RemoveUnitRole(Meta.FromDate.RelationType);
		}


		virtual public global::System.DateTime? ThroughDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.ThroughDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ThroughDate.RelationType, value);
			}
		}

		virtual public bool ExistThroughDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.ThroughDate.RelationType);
			}
		}

		virtual public void RemoveThroughDate()
		{
			Strategy.RemoveUnitRole(Meta.ThroughDate.RelationType);
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new WorkEffortFixedAssetAssignmentOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class WorkEffortFixedAssetAssignmentBuilder : Allors.ObjectBuilder<WorkEffortFixedAssetAssignment> , CommentableBuilder, AccessControlledObjectBuilder, PeriodBuilder, global::System.IDisposable
	{		
		public WorkEffortFixedAssetAssignmentBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(WorkEffortFixedAssetAssignment instance)
		{
			

			if(this.AllocatedCost.HasValue)
			{
				instance.AllocatedCost = this.AllocatedCost.Value;
			}			
		
		

			instance.Comment = this.Comment;
		
		
			

			if(this.FromDate.HasValue)
			{
				instance.FromDate = this.FromDate.Value;
			}			
		
		
			

			if(this.ThroughDate.HasValue)
			{
				instance.ThroughDate = this.ThroughDate.Value;
			}			
		
		

			instance.AssetAssignmentStatus = this.AssetAssignmentStatus;

		

			instance.Assignment = this.Assignment;

		

			instance.FixedAsset = this.FixedAsset;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public AssetAssignmentStatus AssetAssignmentStatus {get; set;}

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithAssetAssignmentStatus(AssetAssignmentStatus value)
		        {
		            if(this.AssetAssignmentStatus!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.AssetAssignmentStatus = value;
		            return this;
		        }		

				
				public WorkEffort Assignment {get; set;}

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithAssignment(WorkEffort value)
		        {
		            if(this.Assignment!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Assignment = value;
		            return this;
		        }		

				
				public global::System.Decimal? AllocatedCost {get; set;}

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithAllocatedCost(global::System.Decimal? value)
		        {
				    if(this.AllocatedCost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AllocatedCost = value;
		            return this;
		        }	

				public FixedAsset FixedAsset {get; set;}

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithFixedAsset(FixedAsset value)
		        {
		            if(this.FixedAsset!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.FixedAsset = value;
		            return this;
		        }		

				
				public global::System.String Comment {get; set;}

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithDeniedPermission(Permission value)
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
				public WorkEffortFixedAssetAssignmentBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				
				public global::System.DateTime? FromDate {get; set;}

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithFromDate(global::System.DateTime? value)
		        {
				    if(this.FromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDate {get; set;}

				/// <exclude/>
				public WorkEffortFixedAssetAssignmentBuilder WithThroughDate(global::System.DateTime? value)
		        {
				    if(this.ThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDate = value;
		            return this;
		        }	


	}

	public partial class WorkEffortFixedAssetAssignments : global::Allors.ObjectsBase<WorkEffortFixedAssetAssignment>
	{
		public WorkEffortFixedAssetAssignments(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaWorkEffortFixedAssetAssignment Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortFixedAssetAssignment.Instance;
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