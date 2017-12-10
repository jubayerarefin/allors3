// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Employment : Allors.IObject , Period, Deletable, AccessControlledObject
	{
		private readonly IStrategy strategy;

		public Employment(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaEmployment Meta
		{
			get
			{
				return Allors.Meta.MetaEmployment.Instance;
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

		public static Employment Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Employment) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Person Employee
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.Employee.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Employee.RelationType, value);
			}
		}

		virtual public bool ExistEmployee
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Employee.RelationType);
			}
		}

		virtual public void RemoveEmployee()
		{
			Strategy.RemoveCompositeRole(Meta.Employee.RelationType);
		}


		virtual public global::Allors.Extent<PayrollPreference> PayrollPreferences
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.PayrollPreferences.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PayrollPreferences.RelationType, value);
			}
		}

		virtual public void AddPayrollPreference (PayrollPreference value)
		{
			Strategy.AddCompositeRole(Meta.PayrollPreferences.RelationType, value);
		}

		virtual public void RemovePayrollPreference (PayrollPreference value)
		{
			Strategy.RemoveCompositeRole(Meta.PayrollPreferences.RelationType, value);
		}

		virtual public bool ExistPayrollPreferences
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PayrollPreferences.RelationType);
			}
		}

		virtual public void RemovePayrollPreferences()
		{
			Strategy.RemoveCompositeRoles(Meta.PayrollPreferences.RelationType);
		}


		virtual public EmploymentTerminationReason EmploymentTerminationReason
		{ 
			get
			{
				return (EmploymentTerminationReason) Strategy.GetCompositeRole(Meta.EmploymentTerminationReason.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.EmploymentTerminationReason.RelationType, value);
			}
		}

		virtual public bool ExistEmploymentTerminationReason
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.EmploymentTerminationReason.RelationType);
			}
		}

		virtual public void RemoveEmploymentTerminationReason()
		{
			Strategy.RemoveCompositeRole(Meta.EmploymentTerminationReason.RelationType);
		}


		virtual public EmploymentTermination EmploymentTermination
		{ 
			get
			{
				return (EmploymentTermination) Strategy.GetCompositeRole(Meta.EmploymentTermination.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.EmploymentTermination.RelationType, value);
			}
		}

		virtual public bool ExistEmploymentTermination
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.EmploymentTermination.RelationType);
			}
		}

		virtual public void RemoveEmploymentTermination()
		{
			Strategy.RemoveCompositeRole(Meta.EmploymentTermination.RelationType);
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
			var method = new EmploymentOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new EmploymentOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new EmploymentOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new EmploymentOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new EmploymentOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new EmploymentOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new EmploymentOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new EmploymentOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new EmploymentOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new EmploymentOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new EmploymentDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new EmploymentDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class EmploymentBuilder : Allors.ObjectBuilder<Employment> , PeriodBuilder, DeletableBuilder, AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public EmploymentBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Employment instance)
		{
			

			if(this.FromDate.HasValue)
			{
				instance.FromDate = this.FromDate.Value;
			}			
		
		
			

			if(this.ThroughDate.HasValue)
			{
				instance.ThroughDate = this.ThroughDate.Value;
			}			
		
		

			instance.Employee = this.Employee;

		
			if(this.PayrollPreferences!=null)
			{
				instance.PayrollPreferences = this.PayrollPreferences.ToArray();
			}
		

			instance.EmploymentTerminationReason = this.EmploymentTerminationReason;

		

			instance.EmploymentTermination = this.EmploymentTermination;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Person Employee {get; set;}

				/// <exclude/>
				public EmploymentBuilder WithEmployee(Person value)
		        {
		            if(this.Employee!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Employee = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<PayrollPreference> PayrollPreferences {get; set;}	

				/// <exclude/>
				public EmploymentBuilder WithPayrollPreference(PayrollPreference value)
		        {
					if(this.PayrollPreferences == null)
					{
						this.PayrollPreferences = new global::System.Collections.Generic.List<PayrollPreference>(); 
					}
		            this.PayrollPreferences.Add(value);
		            return this;
		        }		

				
				public EmploymentTerminationReason EmploymentTerminationReason {get; set;}

				/// <exclude/>
				public EmploymentBuilder WithEmploymentTerminationReason(EmploymentTerminationReason value)
		        {
		            if(this.EmploymentTerminationReason!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.EmploymentTerminationReason = value;
		            return this;
		        }		

				
				public EmploymentTermination EmploymentTermination {get; set;}

				/// <exclude/>
				public EmploymentBuilder WithEmploymentTermination(EmploymentTermination value)
		        {
		            if(this.EmploymentTermination!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.EmploymentTermination = value;
		            return this;
		        }		

				
				public global::System.DateTime? FromDate {get; set;}

				/// <exclude/>
				public EmploymentBuilder WithFromDate(global::System.DateTime? value)
		        {
				    if(this.FromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDate {get; set;}

				/// <exclude/>
				public EmploymentBuilder WithThroughDate(global::System.DateTime? value)
		        {
				    if(this.ThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public EmploymentBuilder WithDeniedPermission(Permission value)
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
				public EmploymentBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Employments : global::Allors.ObjectsBase<Employment>
	{
		public Employments(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaEmployment Meta
		{
			get
			{
				return Allors.Meta.MetaEmployment.Instance;
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