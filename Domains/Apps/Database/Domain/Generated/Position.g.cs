// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Position : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public Position(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPosition Meta
		{
			get
			{
				return Allors.Meta.MetaPosition.Instance;
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

		public static Position Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Position) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Organisation Organisation
		{ 
			get
			{
				return (Organisation) Strategy.GetCompositeRole(Meta.Organisation.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Organisation.RelationType, value);
			}
		}

		virtual public bool ExistOrganisation
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Organisation.RelationType);
			}
		}

		virtual public void RemoveOrganisation()
		{
			Strategy.RemoveCompositeRole(Meta.Organisation.RelationType);
		}


		virtual public global::System.Boolean? Temporary 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.Temporary.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Temporary.RelationType, value);
			}
		}

		virtual public bool ExistTemporary{
			get
			{
				return Strategy.ExistUnitRole(Meta.Temporary.RelationType);
			}
		}

		virtual public void RemoveTemporary()
		{
			Strategy.RemoveUnitRole(Meta.Temporary.RelationType);
		}


		virtual public global::System.DateTime? EstimatedThroughDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.EstimatedThroughDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedThroughDate.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedThroughDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedThroughDate.RelationType);
			}
		}

		virtual public void RemoveEstimatedThroughDate()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedThroughDate.RelationType);
		}


		virtual public global::System.DateTime? EstimatedFromDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.EstimatedFromDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedFromDate.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedFromDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedFromDate.RelationType);
			}
		}

		virtual public void RemoveEstimatedFromDate()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedFromDate.RelationType);
		}


		virtual public PositionType PositionType
		{ 
			get
			{
				return (PositionType) Strategy.GetCompositeRole(Meta.PositionType.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PositionType.RelationType, value);
			}
		}

		virtual public bool ExistPositionType
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PositionType.RelationType);
			}
		}

		virtual public void RemovePositionType()
		{
			Strategy.RemoveCompositeRole(Meta.PositionType.RelationType);
		}


		virtual public global::System.Boolean? Fulltime 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.Fulltime.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Fulltime.RelationType, value);
			}
		}

		virtual public bool ExistFulltime{
			get
			{
				return Strategy.ExistUnitRole(Meta.Fulltime.RelationType);
			}
		}

		virtual public void RemoveFulltime()
		{
			Strategy.RemoveUnitRole(Meta.Fulltime.RelationType);
		}


		virtual public global::System.Boolean? Salary 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.Salary.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Salary.RelationType, value);
			}
		}

		virtual public bool ExistSalary{
			get
			{
				return Strategy.ExistUnitRole(Meta.Salary.RelationType);
			}
		}

		virtual public void RemoveSalary()
		{
			Strategy.RemoveUnitRole(Meta.Salary.RelationType);
		}


		virtual public PositionStatus PositionStatus
		{ 
			get
			{
				return (PositionStatus) Strategy.GetCompositeRole(Meta.PositionStatus.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PositionStatus.RelationType, value);
			}
		}

		virtual public bool ExistPositionStatus
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PositionStatus.RelationType);
			}
		}

		virtual public void RemovePositionStatus()
		{
			Strategy.RemoveCompositeRole(Meta.PositionStatus.RelationType);
		}


		virtual public BudgetItem ApprovedBudgetItem
		{ 
			get
			{
				return (BudgetItem) Strategy.GetCompositeRole(Meta.ApprovedBudgetItem.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ApprovedBudgetItem.RelationType, value);
			}
		}

		virtual public bool ExistApprovedBudgetItem
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ApprovedBudgetItem.RelationType);
			}
		}

		virtual public void RemoveApprovedBudgetItem()
		{
			Strategy.RemoveCompositeRole(Meta.ApprovedBudgetItem.RelationType);
		}


		virtual public global::System.DateTime ActualFromDate 
		{
			get
			{
				return (global::System.DateTime) Strategy.GetUnitRole(Meta.ActualFromDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ActualFromDate.RelationType, value);
			}
		}

		virtual public bool ExistActualFromDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.ActualFromDate.RelationType);
			}
		}

		virtual public void RemoveActualFromDate()
		{
			Strategy.RemoveUnitRole(Meta.ActualFromDate.RelationType);
		}


		virtual public global::System.DateTime? ActualThroughDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.ActualThroughDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ActualThroughDate.RelationType, value);
			}
		}

		virtual public bool ExistActualThroughDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.ActualThroughDate.RelationType);
			}
		}

		virtual public void RemoveActualThroughDate()
		{
			Strategy.RemoveUnitRole(Meta.ActualThroughDate.RelationType);
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



		virtual public global::Allors.Extent<EmploymentApplication> EmploymentApplicationsWherePosition
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EmploymentApplicationsWherePosition.RelationType);
			}
		}

		virtual public bool ExistEmploymentApplicationsWherePosition
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EmploymentApplicationsWherePosition.RelationType);
			}
		}


		virtual public global::Allors.Extent<PerformanceReview> PerformanceReviewsWhereResultingPosition
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PerformanceReviewsWhereResultingPosition.RelationType);
			}
		}

		virtual public bool ExistPerformanceReviewsWhereResultingPosition
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PerformanceReviewsWhereResultingPosition.RelationType);
			}
		}


		virtual public global::Allors.Extent<PositionFulfillment> PositionFulfillmentsWherePosition
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PositionFulfillmentsWherePosition.RelationType);
			}
		}

		virtual public bool ExistPositionFulfillmentsWherePosition
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PositionFulfillmentsWherePosition.RelationType);
			}
		}


		virtual public global::Allors.Extent<PositionReportingStructure> PositionReportingStructuresWhereManagedByPosition
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PositionReportingStructuresWhereManagedByPosition.RelationType);
			}
		}

		virtual public bool ExistPositionReportingStructuresWhereManagedByPosition
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PositionReportingStructuresWhereManagedByPosition.RelationType);
			}
		}


		virtual public global::Allors.Extent<PositionReportingStructure> PositionReportingStructuresWherePosition
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PositionReportingStructuresWherePosition.RelationType);
			}
		}

		virtual public bool ExistPositionReportingStructuresWherePosition
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PositionReportingStructuresWherePosition.RelationType);
			}
		}


		virtual public global::Allors.Extent<PositionResponsibility> PositionResponsibilitiesWherePosition
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PositionResponsibilitiesWherePosition.RelationType);
			}
		}

		virtual public bool ExistPositionResponsibilitiesWherePosition
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PositionResponsibilitiesWherePosition.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new PositionOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PositionOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PositionOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PositionOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PositionOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PositionOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PositionOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PositionOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PositionOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PositionOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PositionBuilder : Allors.ObjectBuilder<Position> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public PositionBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Position instance)
		{
			

			if(this.Temporary.HasValue)
			{
				instance.Temporary = this.Temporary.Value;
			}			
		
		
			

			if(this.EstimatedThroughDate.HasValue)
			{
				instance.EstimatedThroughDate = this.EstimatedThroughDate.Value;
			}			
		
		
			

			if(this.EstimatedFromDate.HasValue)
			{
				instance.EstimatedFromDate = this.EstimatedFromDate.Value;
			}			
		
		
			

			if(this.Fulltime.HasValue)
			{
				instance.Fulltime = this.Fulltime.Value;
			}			
		
		
			

			if(this.Salary.HasValue)
			{
				instance.Salary = this.Salary.Value;
			}			
		
		
			

			if(this.ActualFromDate.HasValue)
			{
				instance.ActualFromDate = this.ActualFromDate.Value;
			}			
		
		
			

			if(this.ActualThroughDate.HasValue)
			{
				instance.ActualThroughDate = this.ActualThroughDate.Value;
			}			
		
		

			instance.Organisation = this.Organisation;

		

			instance.PositionType = this.PositionType;

		

			instance.PositionStatus = this.PositionStatus;

		

			instance.ApprovedBudgetItem = this.ApprovedBudgetItem;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Organisation Organisation {get; set;}

				/// <exclude/>
				public PositionBuilder WithOrganisation(Organisation value)
		        {
		            if(this.Organisation!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Organisation = value;
		            return this;
		        }		

				
				public global::System.Boolean? Temporary {get; set;}

				/// <exclude/>
				public PositionBuilder WithTemporary(global::System.Boolean? value)
		        {
				    if(this.Temporary!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Temporary = value;
		            return this;
		        }	

				public global::System.DateTime? EstimatedThroughDate {get; set;}

				/// <exclude/>
				public PositionBuilder WithEstimatedThroughDate(global::System.DateTime? value)
		        {
				    if(this.EstimatedThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedThroughDate = value;
		            return this;
		        }	

				public global::System.DateTime? EstimatedFromDate {get; set;}

				/// <exclude/>
				public PositionBuilder WithEstimatedFromDate(global::System.DateTime? value)
		        {
				    if(this.EstimatedFromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedFromDate = value;
		            return this;
		        }	

				public PositionType PositionType {get; set;}

				/// <exclude/>
				public PositionBuilder WithPositionType(PositionType value)
		        {
		            if(this.PositionType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.PositionType = value;
		            return this;
		        }		

				
				public global::System.Boolean? Fulltime {get; set;}

				/// <exclude/>
				public PositionBuilder WithFulltime(global::System.Boolean? value)
		        {
				    if(this.Fulltime!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Fulltime = value;
		            return this;
		        }	

				public global::System.Boolean? Salary {get; set;}

				/// <exclude/>
				public PositionBuilder WithSalary(global::System.Boolean? value)
		        {
				    if(this.Salary!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Salary = value;
		            return this;
		        }	

				public PositionStatus PositionStatus {get; set;}

				/// <exclude/>
				public PositionBuilder WithPositionStatus(PositionStatus value)
		        {
		            if(this.PositionStatus!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.PositionStatus = value;
		            return this;
		        }		

				
				public BudgetItem ApprovedBudgetItem {get; set;}

				/// <exclude/>
				public PositionBuilder WithApprovedBudgetItem(BudgetItem value)
		        {
		            if(this.ApprovedBudgetItem!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ApprovedBudgetItem = value;
		            return this;
		        }		

				
				public global::System.DateTime? ActualFromDate {get; set;}

				/// <exclude/>
				public PositionBuilder WithActualFromDate(global::System.DateTime? value)
		        {
				    if(this.ActualFromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ActualFromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ActualThroughDate {get; set;}

				/// <exclude/>
				public PositionBuilder WithActualThroughDate(global::System.DateTime? value)
		        {
				    if(this.ActualThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ActualThroughDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PositionBuilder WithDeniedPermission(Permission value)
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
				public PositionBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Positions : global::Allors.ObjectsBase<Position>
	{
		public Positions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPosition Meta
		{
			get
			{
				return Allors.Meta.MetaPosition.Instance;
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