// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Priority : Allors.IObject , Enumeration
	{
		private readonly IStrategy strategy;

		public Priority(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPriority Meta
		{
			get
			{
				return Allors.Meta.MetaPriority.Instance;
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

		public static Priority Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Priority) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::Allors.Extent<LocalisedText> LocalisedNames
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.LocalisedNames.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.LocalisedNames.RelationType, value);
			}
		}

		virtual public void AddLocalisedName (LocalisedText value)
		{
			Strategy.AddCompositeRole(Meta.LocalisedNames.RelationType, value);
		}

		virtual public void RemoveLocalisedName (LocalisedText value)
		{
			Strategy.RemoveCompositeRole(Meta.LocalisedNames.RelationType, value);
		}

		virtual public bool ExistLocalisedNames
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.LocalisedNames.RelationType);
			}
		}

		virtual public void RemoveLocalisedNames()
		{
			Strategy.RemoveCompositeRoles(Meta.LocalisedNames.RelationType);
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


		virtual public global::System.Boolean IsActive 
		{
			get
			{
				return (global::System.Boolean) Strategy.GetUnitRole(Meta.IsActive.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.IsActive.RelationType, value);
			}
		}

		virtual public bool ExistIsActive{
			get
			{
				return Strategy.ExistUnitRole(Meta.IsActive.RelationType);
			}
		}

		virtual public void RemoveIsActive()
		{
			Strategy.RemoveUnitRole(Meta.IsActive.RelationType);
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



		virtual public global::Allors.Extent<CommunicationEventVersion> CommunicationEventVersionsWherePriority
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.CommunicationEventVersionsWherePriority.RelationType);
			}
		}

		virtual public bool ExistCommunicationEventVersionsWherePriority
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.CommunicationEventVersionsWherePriority.RelationType);
			}
		}


		virtual public global::Allors.Extent<CommunicationEvent> CommunicationEventsWherePriority
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.CommunicationEventsWherePriority.RelationType);
			}
		}

		virtual public bool ExistCommunicationEventsWherePriority
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.CommunicationEventsWherePriority.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortVersion> WorkEffortVersionsWherePriority
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortVersionsWherePriority.RelationType);
			}
		}

		virtual public bool ExistWorkEffortVersionsWherePriority
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortVersionsWherePriority.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffort> WorkEffortsWherePriority
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortsWherePriority.RelationType);
			}
		}

		virtual public bool ExistWorkEffortsWherePriority
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortsWherePriority.RelationType);
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



		public PriorityDelete Delete()
		{ 
			var method = new PriorityDelete(this);
            method.Execute();
            return method;
		}

		public PriorityDelete Delete(System.Action<PriorityDelete> action)
		{ 
			var method = new PriorityDelete(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild()
		{ 
			var method = new PriorityOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PriorityOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PriorityOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PriorityOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PriorityOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PriorityOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PriorityOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PriorityOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PriorityOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PriorityOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PriorityBuilder : Allors.ObjectBuilder<Priority> , EnumerationBuilder, global::System.IDisposable
	{		
		public PriorityBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Priority instance)
		{

			instance.Name = this.Name;
		
		
			

			if(this.IsActive.HasValue)
			{
				instance.IsActive = this.IsActive.Value;
			}			
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
			if(this.LocalisedNames!=null)
			{
				instance.LocalisedNames = this.LocalisedNames.ToArray();
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


				public global::System.Collections.Generic.List<LocalisedText> LocalisedNames {get; set;}	

				/// <exclude/>
				public PriorityBuilder WithLocalisedName(LocalisedText value)
		        {
					if(this.LocalisedNames == null)
					{
						this.LocalisedNames = new global::System.Collections.Generic.List<LocalisedText>(); 
					}
		            this.LocalisedNames.Add(value);
		            return this;
		        }		

				
				public global::System.String Name {get; set;}

				/// <exclude/>
				public PriorityBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.Boolean? IsActive {get; set;}

				/// <exclude/>
				public PriorityBuilder WithIsActive(global::System.Boolean? value)
		        {
				    if(this.IsActive!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IsActive = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PriorityBuilder WithDeniedPermission(Permission value)
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
				public PriorityBuilder WithSecurityToken(SecurityToken value)
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
				public PriorityBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	


	}

	public partial class Priorities : global::Allors.ObjectsBase<Priority>
	{
		public Priorities(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPriority Meta
		{
			get
			{
				return Allors.Meta.MetaPriority.Instance;
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