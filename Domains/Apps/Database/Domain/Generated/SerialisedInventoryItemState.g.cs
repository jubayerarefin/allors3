// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class SerialisedInventoryItemState : Allors.IObject , ObjectState
	{
		private readonly IStrategy strategy;

		public SerialisedInventoryItemState(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSerialisedInventoryItemState Meta
		{
			get
			{
				return Allors.Meta.MetaSerialisedInventoryItemState.Instance;
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

		public static SerialisedInventoryItemState Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (SerialisedInventoryItemState) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::Allors.Extent<SerialisedInventoryItemVersion> SerialisedInventoryItemVersionsWhereSerialisedInventoryItemState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SerialisedInventoryItemVersionsWhereSerialisedInventoryItemState.RelationType);
			}
		}

		virtual public bool ExistSerialisedInventoryItemVersionsWhereSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SerialisedInventoryItemVersionsWhereSerialisedInventoryItemState.RelationType);
			}
		}


		virtual public global::Allors.Extent<SerialisedInventoryItem> SerialisedInventoryItemsWherePreviousSerialisedInventoryItemState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SerialisedInventoryItemsWherePreviousSerialisedInventoryItemState.RelationType);
			}
		}

		virtual public bool ExistSerialisedInventoryItemsWherePreviousSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SerialisedInventoryItemsWherePreviousSerialisedInventoryItemState.RelationType);
			}
		}


		virtual public global::Allors.Extent<SerialisedInventoryItem> SerialisedInventoryItemsWhereLastSerialisedInventoryItemState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SerialisedInventoryItemsWhereLastSerialisedInventoryItemState.RelationType);
			}
		}

		virtual public bool ExistSerialisedInventoryItemsWhereLastSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SerialisedInventoryItemsWhereLastSerialisedInventoryItemState.RelationType);
			}
		}


		virtual public global::Allors.Extent<SerialisedInventoryItem> SerialisedInventoryItemsWhereSerialisedInventoryItemState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SerialisedInventoryItemsWhereSerialisedInventoryItemState.RelationType);
			}
		}

		virtual public bool ExistSerialisedInventoryItemsWhereSerialisedInventoryItemState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SerialisedInventoryItemsWhereSerialisedInventoryItemState.RelationType);
			}
		}


		virtual public global::Allors.Extent<Transition> TransitionsWhereFromState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionsWhereFromState.RelationType);
			}
		}

		virtual public bool ExistTransitionsWhereFromState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionsWhereFromState.RelationType);
			}
		}


		virtual public global::Allors.Extent<Transition> TransitionsWhereToState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionsWhereToState.RelationType);
			}
		}

		virtual public bool ExistTransitionsWhereToState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionsWhereToState.RelationType);
			}
		}


		virtual public global::Allors.Extent<Transitional> TransitionalsWherePreviousObjectState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionalsWherePreviousObjectState.RelationType);
			}
		}

		virtual public bool ExistTransitionalsWherePreviousObjectState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionalsWherePreviousObjectState.RelationType);
			}
		}


		virtual public global::Allors.Extent<Transitional> TransitionalsWhereLastObjectState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionalsWhereLastObjectState.RelationType);
			}
		}

		virtual public bool ExistTransitionalsWhereLastObjectState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionalsWhereLastObjectState.RelationType);
			}
		}


		virtual public global::Allors.Extent<Transitional> TransitionalsWhereObjectState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionalsWhereObjectState.RelationType);
			}
		}

		virtual public bool ExistTransitionalsWhereObjectState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionalsWhereObjectState.RelationType);
			}
		}


		virtual public global::Allors.Extent<TransitionalVersion> TransitionalVersionsWherePreviousObjectState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionalVersionsWherePreviousObjectState.RelationType);
			}
		}

		virtual public bool ExistTransitionalVersionsWherePreviousObjectState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionalVersionsWherePreviousObjectState.RelationType);
			}
		}


		virtual public global::Allors.Extent<TransitionalVersion> TransitionalVersionsWhereLastObjectState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionalVersionsWhereLastObjectState.RelationType);
			}
		}

		virtual public bool ExistTransitionalVersionsWhereLastObjectState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionalVersionsWhereLastObjectState.RelationType);
			}
		}


		virtual public global::Allors.Extent<TransitionalVersion> TransitionalVersionsWhereObjectState
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.TransitionalVersionsWhereObjectState.RelationType);
			}
		}

		virtual public bool ExistTransitionalVersionsWhereObjectState
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.TransitionalVersionsWhereObjectState.RelationType);
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



		public ObjectOnBuild OnBuild()
		{ 
			var method = new SerialisedInventoryItemStateOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SerialisedInventoryItemStateOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SerialisedInventoryItemStateOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SerialisedInventoryItemStateOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SerialisedInventoryItemStateOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SerialisedInventoryItemStateOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SerialisedInventoryItemStateOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SerialisedInventoryItemStateOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SerialisedInventoryItemStateOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SerialisedInventoryItemStateOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SerialisedInventoryItemStateBuilder : Allors.ObjectBuilder<SerialisedInventoryItemState> , ObjectStateBuilder, global::System.IDisposable
	{		
		public SerialisedInventoryItemStateBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(SerialisedInventoryItemState instance)
		{

			instance.Name = this.Name;
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
		}


				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SerialisedInventoryItemStateBuilder WithDeniedPermission(Permission value)
		        {
					if(this.DeniedPermissions == null)
					{
						this.DeniedPermissions = new global::System.Collections.Generic.List<Permission>(); 
					}
		            this.DeniedPermissions.Add(value);
		            return this;
		        }		

				
				public global::System.String Name {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemStateBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public SerialisedInventoryItemStateBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	


	}

	public partial class SerialisedInventoryItemStates : global::Allors.ObjectsBase<SerialisedInventoryItemState>
	{
		public SerialisedInventoryItemStates(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSerialisedInventoryItemState Meta
		{
			get
			{
				return Allors.Meta.MetaSerialisedInventoryItemState.Instance;
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