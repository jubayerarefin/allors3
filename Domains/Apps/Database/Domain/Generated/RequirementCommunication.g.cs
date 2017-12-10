// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class RequirementCommunication : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public RequirementCommunication(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaRequirementCommunication Meta
		{
			get
			{
				return Allors.Meta.MetaRequirementCommunication.Instance;
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

		public static RequirementCommunication Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (RequirementCommunication) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public CommunicationEvent CommunicationEvent
		{ 
			get
			{
				return (CommunicationEvent) Strategy.GetCompositeRole(Meta.CommunicationEvent.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CommunicationEvent.RelationType, value);
			}
		}

		virtual public bool ExistCommunicationEvent
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CommunicationEvent.RelationType);
			}
		}

		virtual public void RemoveCommunicationEvent()
		{
			Strategy.RemoveCompositeRole(Meta.CommunicationEvent.RelationType);
		}


		virtual public Requirement Requirement
		{ 
			get
			{
				return (Requirement) Strategy.GetCompositeRole(Meta.Requirement.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Requirement.RelationType, value);
			}
		}

		virtual public bool ExistRequirement
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Requirement.RelationType);
			}
		}

		virtual public void RemoveRequirement()
		{
			Strategy.RemoveCompositeRole(Meta.Requirement.RelationType);
		}


		virtual public Person AssociatedProfessional
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.AssociatedProfessional.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.AssociatedProfessional.RelationType, value);
			}
		}

		virtual public bool ExistAssociatedProfessional
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.AssociatedProfessional.RelationType);
			}
		}

		virtual public void RemoveAssociatedProfessional()
		{
			Strategy.RemoveCompositeRole(Meta.AssociatedProfessional.RelationType);
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
			var method = new RequirementCommunicationOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new RequirementCommunicationOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new RequirementCommunicationOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new RequirementCommunicationOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new RequirementCommunicationOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new RequirementCommunicationOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new RequirementCommunicationOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new RequirementCommunicationOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new RequirementCommunicationOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new RequirementCommunicationOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class RequirementCommunicationBuilder : Allors.ObjectBuilder<RequirementCommunication> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public RequirementCommunicationBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(RequirementCommunication instance)
		{

			instance.CommunicationEvent = this.CommunicationEvent;

		

			instance.Requirement = this.Requirement;

		

			instance.AssociatedProfessional = this.AssociatedProfessional;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public CommunicationEvent CommunicationEvent {get; set;}

				/// <exclude/>
				public RequirementCommunicationBuilder WithCommunicationEvent(CommunicationEvent value)
		        {
		            if(this.CommunicationEvent!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CommunicationEvent = value;
		            return this;
		        }		

				
				public Requirement Requirement {get; set;}

				/// <exclude/>
				public RequirementCommunicationBuilder WithRequirement(Requirement value)
		        {
		            if(this.Requirement!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Requirement = value;
		            return this;
		        }		

				
				public Person AssociatedProfessional {get; set;}

				/// <exclude/>
				public RequirementCommunicationBuilder WithAssociatedProfessional(Person value)
		        {
		            if(this.AssociatedProfessional!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.AssociatedProfessional = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public RequirementCommunicationBuilder WithDeniedPermission(Permission value)
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
				public RequirementCommunicationBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class RequirementCommunications : global::Allors.ObjectsBase<RequirementCommunication>
	{
		public RequirementCommunications(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaRequirementCommunication Meta
		{
			get
			{
				return Allors.Meta.MetaRequirementCommunication.Instance;
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