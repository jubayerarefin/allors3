// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class WorkEffortAssignmentRate : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public WorkEffortAssignmentRate(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaWorkEffortAssignmentRate Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortAssignmentRate.Instance;
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

		public static WorkEffortAssignmentRate Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (WorkEffortAssignmentRate) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public RateType RateType
		{ 
			get
			{
				return (RateType) Strategy.GetCompositeRole(Meta.RateType.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.RateType.RelationType, value);
			}
		}

		virtual public bool ExistRateType
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.RateType.RelationType);
			}
		}

		virtual public void RemoveRateType()
		{
			Strategy.RemoveCompositeRole(Meta.RateType.RelationType);
		}


		virtual public WorkEffortPartyAssignment WorkEffortPartyAssignment
		{ 
			get
			{
				return (WorkEffortPartyAssignment) Strategy.GetCompositeRole(Meta.WorkEffortPartyAssignment.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.WorkEffortPartyAssignment.RelationType, value);
			}
		}

		virtual public bool ExistWorkEffortPartyAssignment
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.WorkEffortPartyAssignment.RelationType);
			}
		}

		virtual public void RemoveWorkEffortPartyAssignment()
		{
			Strategy.RemoveCompositeRole(Meta.WorkEffortPartyAssignment.RelationType);
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
			var method = new WorkEffortAssignmentRateOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new WorkEffortAssignmentRateOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new WorkEffortAssignmentRateOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new WorkEffortAssignmentRateOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new WorkEffortAssignmentRateOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new WorkEffortAssignmentRateOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new WorkEffortAssignmentRateOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new WorkEffortAssignmentRateOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new WorkEffortAssignmentRateOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new WorkEffortAssignmentRateOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class WorkEffortAssignmentRateBuilder : Allors.ObjectBuilder<WorkEffortAssignmentRate> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public WorkEffortAssignmentRateBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(WorkEffortAssignmentRate instance)
		{

			instance.RateType = this.RateType;

		

			instance.WorkEffortPartyAssignment = this.WorkEffortPartyAssignment;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public RateType RateType {get; set;}

				/// <exclude/>
				public WorkEffortAssignmentRateBuilder WithRateType(RateType value)
		        {
		            if(this.RateType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.RateType = value;
		            return this;
		        }		

				
				public WorkEffortPartyAssignment WorkEffortPartyAssignment {get; set;}

				/// <exclude/>
				public WorkEffortAssignmentRateBuilder WithWorkEffortPartyAssignment(WorkEffortPartyAssignment value)
		        {
		            if(this.WorkEffortPartyAssignment!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.WorkEffortPartyAssignment = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public WorkEffortAssignmentRateBuilder WithDeniedPermission(Permission value)
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
				public WorkEffortAssignmentRateBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class WorkEffortAssignmentRates : global::Allors.ObjectsBase<WorkEffortAssignmentRate>
	{
		public WorkEffortAssignmentRates(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaWorkEffortAssignmentRate Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortAssignmentRate.Instance;
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