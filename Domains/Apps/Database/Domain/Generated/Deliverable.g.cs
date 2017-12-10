// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Deliverable : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public Deliverable(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaDeliverable Meta
		{
			get
			{
				return Allors.Meta.MetaDeliverable.Instance;
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

		public static Deliverable Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Deliverable) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public DeliverableType DeliverableType
		{ 
			get
			{
				return (DeliverableType) Strategy.GetCompositeRole(Meta.DeliverableType.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.DeliverableType.RelationType, value);
			}
		}

		virtual public bool ExistDeliverableType
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.DeliverableType.RelationType);
			}
		}

		virtual public void RemoveDeliverableType()
		{
			Strategy.RemoveCompositeRole(Meta.DeliverableType.RelationType);
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



		virtual public global::Allors.Extent<QuoteItemVersion> QuoteItemVersionsWhereDeliverable
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.QuoteItemVersionsWhereDeliverable.RelationType);
			}
		}

		virtual public bool ExistQuoteItemVersionsWhereDeliverable
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.QuoteItemVersionsWhereDeliverable.RelationType);
			}
		}


		virtual public global::Allors.Extent<RequestItemVersion> RequestItemVersionsWhereDeliverable
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestItemVersionsWhereDeliverable.RelationType);
			}
		}

		virtual public bool ExistRequestItemVersionsWhereDeliverable
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestItemVersionsWhereDeliverable.RelationType);
			}
		}


		virtual public global::Allors.Extent<QuoteItem> QuoteItemsWhereDeliverable
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.QuoteItemsWhereDeliverable.RelationType);
			}
		}

		virtual public bool ExistQuoteItemsWhereDeliverable
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.QuoteItemsWhereDeliverable.RelationType);
			}
		}


		virtual public global::Allors.Extent<RequestItem> RequestItemsWhereDeliverable
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestItemsWhereDeliverable.RelationType);
			}
		}

		virtual public bool ExistRequestItemsWhereDeliverable
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestItemsWhereDeliverable.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortType> WorkEffortTypesWhereDeliverableToProduce
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortTypesWhereDeliverableToProduce.RelationType);
			}
		}

		virtual public bool ExistWorkEffortTypesWhereDeliverableToProduce
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortTypesWhereDeliverableToProduce.RelationType);
			}
		}


		virtual public global::Allors.Extent<WorkEffortVersion> WorkEffortVersionsWhereDeliverablesProduced
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.WorkEffortVersionsWhereDeliverablesProduced.RelationType);
			}
		}

		virtual public bool ExistWorkEffortVersionsWhereDeliverablesProduced
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.WorkEffortVersionsWhereDeliverablesProduced.RelationType);
			}
		}


		virtual public WorkEffort WorkEffortWhereDeliverablesProduced
		{ 
			get
			{
				return (WorkEffort) Strategy.GetCompositeAssociation(Meta.WorkEffortWhereDeliverablesProduced.RelationType);
			}
		} 

		virtual public bool ExistWorkEffortWhereDeliverablesProduced
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.WorkEffortWhereDeliverablesProduced.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new DeliverableOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new DeliverableOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new DeliverableOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new DeliverableOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new DeliverableOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new DeliverableOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new DeliverableOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new DeliverableOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new DeliverableOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new DeliverableOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class DeliverableBuilder : Allors.ObjectBuilder<Deliverable> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public DeliverableBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Deliverable instance)
		{

			instance.Name = this.Name;
		
		

			instance.DeliverableType = this.DeliverableType;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.String Name {get; set;}

				/// <exclude/>
				public DeliverableBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public DeliverableType DeliverableType {get; set;}

				/// <exclude/>
				public DeliverableBuilder WithDeliverableType(DeliverableType value)
		        {
		            if(this.DeliverableType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.DeliverableType = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public DeliverableBuilder WithDeniedPermission(Permission value)
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
				public DeliverableBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Deliverables : global::Allors.ObjectsBase<Deliverable>
	{
		public Deliverables(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaDeliverable Meta
		{
			get
			{
				return Allors.Meta.MetaDeliverable.Instance;
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