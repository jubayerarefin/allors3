// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class WorkEffortType : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public WorkEffortType(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaWorkEffortType Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortType.Instance;
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

		public static WorkEffortType Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (WorkEffortType) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::Allors.Extent<WorkEffortFixedAssetStandard> WorkEffortFixedAssetStandards
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.WorkEffortFixedAssetStandards.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.WorkEffortFixedAssetStandards.RelationType, value);
			}
		}

		virtual public void AddWorkEffortFixedAssetStandard (WorkEffortFixedAssetStandard value)
		{
			Strategy.AddCompositeRole(Meta.WorkEffortFixedAssetStandards.RelationType, value);
		}

		virtual public void RemoveWorkEffortFixedAssetStandard (WorkEffortFixedAssetStandard value)
		{
			Strategy.RemoveCompositeRole(Meta.WorkEffortFixedAssetStandards.RelationType, value);
		}

		virtual public bool ExistWorkEffortFixedAssetStandards
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.WorkEffortFixedAssetStandards.RelationType);
			}
		}

		virtual public void RemoveWorkEffortFixedAssetStandards()
		{
			Strategy.RemoveCompositeRoles(Meta.WorkEffortFixedAssetStandards.RelationType);
		}


		virtual public global::Allors.Extent<WorkEffortGoodStandard> WorkEffortGoodStandards
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.WorkEffortGoodStandards.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.WorkEffortGoodStandards.RelationType, value);
			}
		}

		virtual public void AddWorkEffortGoodStandard (WorkEffortGoodStandard value)
		{
			Strategy.AddCompositeRole(Meta.WorkEffortGoodStandards.RelationType, value);
		}

		virtual public void RemoveWorkEffortGoodStandard (WorkEffortGoodStandard value)
		{
			Strategy.RemoveCompositeRole(Meta.WorkEffortGoodStandards.RelationType, value);
		}

		virtual public bool ExistWorkEffortGoodStandards
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.WorkEffortGoodStandards.RelationType);
			}
		}

		virtual public void RemoveWorkEffortGoodStandards()
		{
			Strategy.RemoveCompositeRoles(Meta.WorkEffortGoodStandards.RelationType);
		}


		virtual public global::Allors.Extent<WorkEffortType> Children
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Children.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Children.RelationType, value);
			}
		}

		virtual public void AddChild (WorkEffortType value)
		{
			Strategy.AddCompositeRole(Meta.Children.RelationType, value);
		}

		virtual public void RemoveChild (WorkEffortType value)
		{
			Strategy.RemoveCompositeRole(Meta.Children.RelationType, value);
		}

		virtual public bool ExistChildren
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Children.RelationType);
			}
		}

		virtual public void RemoveChildren()
		{
			Strategy.RemoveCompositeRoles(Meta.Children.RelationType);
		}


		virtual public FixedAsset FixedAssetToRepair
		{ 
			get
			{
				return (FixedAsset) Strategy.GetCompositeRole(Meta.FixedAssetToRepair.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.FixedAssetToRepair.RelationType, value);
			}
		}

		virtual public bool ExistFixedAssetToRepair
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.FixedAssetToRepair.RelationType);
			}
		}

		virtual public void RemoveFixedAssetToRepair()
		{
			Strategy.RemoveCompositeRole(Meta.FixedAssetToRepair.RelationType);
		}


		virtual public global::System.String Description 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Description.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Description.RelationType, value);
			}
		}

		virtual public bool ExistDescription{
			get
			{
				return Strategy.ExistUnitRole(Meta.Description.RelationType);
			}
		}

		virtual public void RemoveDescription()
		{
			Strategy.RemoveUnitRole(Meta.Description.RelationType);
		}


		virtual public global::Allors.Extent<WorkEffortType> Dependencies
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Dependencies.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Dependencies.RelationType, value);
			}
		}

		virtual public void AddDependency (WorkEffortType value)
		{
			Strategy.AddCompositeRole(Meta.Dependencies.RelationType, value);
		}

		virtual public void RemoveDependency (WorkEffortType value)
		{
			Strategy.RemoveCompositeRole(Meta.Dependencies.RelationType, value);
		}

		virtual public bool ExistDependencies
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Dependencies.RelationType);
			}
		}

		virtual public void RemoveDependencies()
		{
			Strategy.RemoveCompositeRoles(Meta.Dependencies.RelationType);
		}


		virtual public WorkEffortTypeKind WorkEffortTypeKind
		{ 
			get
			{
				return (WorkEffortTypeKind) Strategy.GetCompositeRole(Meta.WorkEffortTypeKind.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.WorkEffortTypeKind.RelationType, value);
			}
		}

		virtual public bool ExistWorkEffortTypeKind
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.WorkEffortTypeKind.RelationType);
			}
		}

		virtual public void RemoveWorkEffortTypeKind()
		{
			Strategy.RemoveCompositeRole(Meta.WorkEffortTypeKind.RelationType);
		}


		virtual public global::Allors.Extent<WorkEffortPartStandard> WorkEffortPartStandards
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.WorkEffortPartStandards.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.WorkEffortPartStandards.RelationType, value);
			}
		}

		virtual public void AddWorkEffortPartStandard (WorkEffortPartStandard value)
		{
			Strategy.AddCompositeRole(Meta.WorkEffortPartStandards.RelationType, value);
		}

		virtual public void RemoveWorkEffortPartStandard (WorkEffortPartStandard value)
		{
			Strategy.RemoveCompositeRole(Meta.WorkEffortPartStandards.RelationType, value);
		}

		virtual public bool ExistWorkEffortPartStandards
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.WorkEffortPartStandards.RelationType);
			}
		}

		virtual public void RemoveWorkEffortPartStandards()
		{
			Strategy.RemoveCompositeRoles(Meta.WorkEffortPartStandards.RelationType);
		}


		virtual public global::Allors.Extent<WorkEffortSkillStandard> WorkEffortSkillStandards
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.WorkEffortSkillStandards.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.WorkEffortSkillStandards.RelationType, value);
			}
		}

		virtual public void AddWorkEffortSkillStandard (WorkEffortSkillStandard value)
		{
			Strategy.AddCompositeRole(Meta.WorkEffortSkillStandards.RelationType, value);
		}

		virtual public void RemoveWorkEffortSkillStandard (WorkEffortSkillStandard value)
		{
			Strategy.RemoveCompositeRole(Meta.WorkEffortSkillStandards.RelationType, value);
		}

		virtual public bool ExistWorkEffortSkillStandards
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.WorkEffortSkillStandards.RelationType);
			}
		}

		virtual public void RemoveWorkEffortSkillStandards()
		{
			Strategy.RemoveCompositeRoles(Meta.WorkEffortSkillStandards.RelationType);
		}


		virtual public global::System.Decimal? StandardWorkHours 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.StandardWorkHours.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.StandardWorkHours.RelationType, value);
			}
		}

		virtual public bool ExistStandardWorkHours{
			get
			{
				return Strategy.ExistUnitRole(Meta.StandardWorkHours.RelationType);
			}
		}

		virtual public void RemoveStandardWorkHours()
		{
			Strategy.RemoveUnitRole(Meta.StandardWorkHours.RelationType);
		}


		virtual public Product ProductToProduce
		{ 
			get
			{
				return (Product) Strategy.GetCompositeRole(Meta.ProductToProduce.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ProductToProduce.RelationType, value);
			}
		}

		virtual public bool ExistProductToProduce
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ProductToProduce.RelationType);
			}
		}

		virtual public void RemoveProductToProduce()
		{
			Strategy.RemoveCompositeRole(Meta.ProductToProduce.RelationType);
		}


		virtual public Deliverable DeliverableToProduce
		{ 
			get
			{
				return (Deliverable) Strategy.GetCompositeRole(Meta.DeliverableToProduce.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.DeliverableToProduce.RelationType, value);
			}
		}

		virtual public bool ExistDeliverableToProduce
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.DeliverableToProduce.RelationType);
			}
		}

		virtual public void RemoveDeliverableToProduce()
		{
			Strategy.RemoveCompositeRole(Meta.DeliverableToProduce.RelationType);
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



		virtual public global::Allors.Extent<WorkEffortType> WorkEffortTypesWhereChild
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortTypesWhereChild.RelationType);
			}
		}

		virtual public bool ExistWorkEffortTypesWhereChild
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortTypesWhereChild.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortType> WorkEffortTypesWhereDependency
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortTypesWhereDependency.RelationType);
			}
		}

		virtual public bool ExistWorkEffortTypesWhereDependency
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortTypesWhereDependency.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortVersion> WorkEffortVersionsWhereWorkEffortType
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortVersionsWhereWorkEffortType.RelationType);
			}
		}

		virtual public bool ExistWorkEffortVersionsWhereWorkEffortType
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortVersionsWhereWorkEffortType.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffort> WorkEffortsWhereWorkEffortType
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortsWhereWorkEffortType.RelationType);
			}
		}

		virtual public bool ExistWorkEffortsWhereWorkEffortType
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortsWhereWorkEffortType.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new WorkEffortTypeOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new WorkEffortTypeOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new WorkEffortTypeOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new WorkEffortTypeOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new WorkEffortTypeOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new WorkEffortTypeOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new WorkEffortTypeOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new WorkEffortTypeOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new WorkEffortTypeOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new WorkEffortTypeOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class WorkEffortTypeBuilder : Allors.ObjectBuilder<WorkEffortType> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public WorkEffortTypeBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(WorkEffortType instance)
		{

			instance.Description = this.Description;
		
		
			

			if(this.StandardWorkHours.HasValue)
			{
				instance.StandardWorkHours = this.StandardWorkHours.Value;
			}			
		
		
			if(this.WorkEffortFixedAssetStandards!=null)
			{
				instance.WorkEffortFixedAssetStandards = this.WorkEffortFixedAssetStandards.ToArray();
			}
		
			if(this.WorkEffortGoodStandards!=null)
			{
				instance.WorkEffortGoodStandards = this.WorkEffortGoodStandards.ToArray();
			}
		
			if(this.Children!=null)
			{
				instance.Children = this.Children.ToArray();
			}
		

			instance.FixedAssetToRepair = this.FixedAssetToRepair;

		
			if(this.Dependencies!=null)
			{
				instance.Dependencies = this.Dependencies.ToArray();
			}
		

			instance.WorkEffortTypeKind = this.WorkEffortTypeKind;

		
			if(this.WorkEffortPartStandards!=null)
			{
				instance.WorkEffortPartStandards = this.WorkEffortPartStandards.ToArray();
			}
		
			if(this.WorkEffortSkillStandards!=null)
			{
				instance.WorkEffortSkillStandards = this.WorkEffortSkillStandards.ToArray();
			}
		

			instance.ProductToProduce = this.ProductToProduce;

		

			instance.DeliverableToProduce = this.DeliverableToProduce;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Collections.Generic.List<WorkEffortFixedAssetStandard> WorkEffortFixedAssetStandards {get; set;}	

				/// <exclude/>
				public WorkEffortTypeBuilder WithWorkEffortFixedAssetStandard(WorkEffortFixedAssetStandard value)
		        {
					if(this.WorkEffortFixedAssetStandards == null)
					{
						this.WorkEffortFixedAssetStandards = new global::System.Collections.Generic.List<WorkEffortFixedAssetStandard>(); 
					}
		            this.WorkEffortFixedAssetStandards.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<WorkEffortGoodStandard> WorkEffortGoodStandards {get; set;}	

				/// <exclude/>
				public WorkEffortTypeBuilder WithWorkEffortGoodStandard(WorkEffortGoodStandard value)
		        {
					if(this.WorkEffortGoodStandards == null)
					{
						this.WorkEffortGoodStandards = new global::System.Collections.Generic.List<WorkEffortGoodStandard>(); 
					}
		            this.WorkEffortGoodStandards.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<WorkEffortType> Children {get; set;}	

				/// <exclude/>
				public WorkEffortTypeBuilder WithChild(WorkEffortType value)
		        {
					if(this.Children == null)
					{
						this.Children = new global::System.Collections.Generic.List<WorkEffortType>(); 
					}
		            this.Children.Add(value);
		            return this;
		        }		

				
				public FixedAsset FixedAssetToRepair {get; set;}

				/// <exclude/>
				public WorkEffortTypeBuilder WithFixedAssetToRepair(FixedAsset value)
		        {
		            if(this.FixedAssetToRepair!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.FixedAssetToRepair = value;
		            return this;
		        }		

				
				public global::System.String Description {get; set;}

				/// <exclude/>
				public WorkEffortTypeBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<WorkEffortType> Dependencies {get; set;}	

				/// <exclude/>
				public WorkEffortTypeBuilder WithDependency(WorkEffortType value)
		        {
					if(this.Dependencies == null)
					{
						this.Dependencies = new global::System.Collections.Generic.List<WorkEffortType>(); 
					}
		            this.Dependencies.Add(value);
		            return this;
		        }		

				
				public WorkEffortTypeKind WorkEffortTypeKind {get; set;}

				/// <exclude/>
				public WorkEffortTypeBuilder WithWorkEffortTypeKind(WorkEffortTypeKind value)
		        {
		            if(this.WorkEffortTypeKind!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.WorkEffortTypeKind = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<WorkEffortPartStandard> WorkEffortPartStandards {get; set;}	

				/// <exclude/>
				public WorkEffortTypeBuilder WithWorkEffortPartStandard(WorkEffortPartStandard value)
		        {
					if(this.WorkEffortPartStandards == null)
					{
						this.WorkEffortPartStandards = new global::System.Collections.Generic.List<WorkEffortPartStandard>(); 
					}
		            this.WorkEffortPartStandards.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<WorkEffortSkillStandard> WorkEffortSkillStandards {get; set;}	

				/// <exclude/>
				public WorkEffortTypeBuilder WithWorkEffortSkillStandard(WorkEffortSkillStandard value)
		        {
					if(this.WorkEffortSkillStandards == null)
					{
						this.WorkEffortSkillStandards = new global::System.Collections.Generic.List<WorkEffortSkillStandard>(); 
					}
		            this.WorkEffortSkillStandards.Add(value);
		            return this;
		        }		

				
				public global::System.Decimal? StandardWorkHours {get; set;}

				/// <exclude/>
				public WorkEffortTypeBuilder WithStandardWorkHours(global::System.Decimal? value)
		        {
				    if(this.StandardWorkHours!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.StandardWorkHours = value;
		            return this;
		        }	

				public Product ProductToProduce {get; set;}

				/// <exclude/>
				public WorkEffortTypeBuilder WithProductToProduce(Product value)
		        {
		            if(this.ProductToProduce!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ProductToProduce = value;
		            return this;
		        }		

				
				public Deliverable DeliverableToProduce {get; set;}

				/// <exclude/>
				public WorkEffortTypeBuilder WithDeliverableToProduce(Deliverable value)
		        {
		            if(this.DeliverableToProduce!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.DeliverableToProduce = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public WorkEffortTypeBuilder WithDeniedPermission(Permission value)
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
				public WorkEffortTypeBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class WorkEffortTypes : global::Allors.ObjectsBase<WorkEffortType>
	{
		public WorkEffortTypes(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaWorkEffortType Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortType.Instance;
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