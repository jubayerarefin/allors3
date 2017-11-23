// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class DeliverableTurnover : Allors.IObject , ServiceEntry
	{
		private readonly IStrategy strategy;

		public DeliverableTurnover(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaDeliverableTurnover Meta
		{
			get
			{
				return Allors.Meta.MetaDeliverableTurnover.Instance;
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

		public static DeliverableTurnover Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (DeliverableTurnover) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Decimal Amount 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Amount.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Amount.RelationType, value);
			}
		}

		virtual public bool ExistAmount{
			get
			{
				return Strategy.ExistUnitRole(Meta.Amount.RelationType);
			}
		}

		virtual public void RemoveAmount()
		{
			Strategy.RemoveUnitRole(Meta.Amount.RelationType);
		}


		virtual public global::System.DateTime? ThroughDateTime 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.ThroughDateTime.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ThroughDateTime.RelationType, value);
			}
		}

		virtual public bool ExistThroughDateTime{
			get
			{
				return Strategy.ExistUnitRole(Meta.ThroughDateTime.RelationType);
			}
		}

		virtual public void RemoveThroughDateTime()
		{
			Strategy.RemoveUnitRole(Meta.ThroughDateTime.RelationType);
		}


		virtual public EngagementItem EngagementItem
		{ 
			get
			{
				return (EngagementItem) Strategy.GetCompositeRole(Meta.EngagementItem.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.EngagementItem.RelationType, value);
			}
		}

		virtual public bool ExistEngagementItem
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.EngagementItem.RelationType);
			}
		}

		virtual public void RemoveEngagementItem()
		{
			Strategy.RemoveCompositeRole(Meta.EngagementItem.RelationType);
		}


		virtual public global::System.Boolean? IsBillable 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.IsBillable.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.IsBillable.RelationType, value);
			}
		}

		virtual public bool ExistIsBillable{
			get
			{
				return Strategy.ExistUnitRole(Meta.IsBillable.RelationType);
			}
		}

		virtual public void RemoveIsBillable()
		{
			Strategy.RemoveUnitRole(Meta.IsBillable.RelationType);
		}


		virtual public global::System.DateTime? FromDateTime 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.FromDateTime.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.FromDateTime.RelationType, value);
			}
		}

		virtual public bool ExistFromDateTime{
			get
			{
				return Strategy.ExistUnitRole(Meta.FromDateTime.RelationType);
			}
		}

		virtual public void RemoveFromDateTime()
		{
			Strategy.RemoveUnitRole(Meta.FromDateTime.RelationType);
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


		virtual public WorkEffort WorkEffort
		{ 
			get
			{
				return (WorkEffort) Strategy.GetCompositeRole(Meta.WorkEffort.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.WorkEffort.RelationType, value);
			}
		}

		virtual public bool ExistWorkEffort
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.WorkEffort.RelationType);
			}
		}

		virtual public void RemoveWorkEffort()
		{
			Strategy.RemoveCompositeRole(Meta.WorkEffort.RelationType);
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



		virtual public global::Allors.Extent<ServiceEntryBilling> ServiceEntryBillingsWhereServiceEntry
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ServiceEntryBillingsWhereServiceEntry.RelationType);
			}
		}

		virtual public bool ExistServiceEntryBillingsWhereServiceEntry
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ServiceEntryBillingsWhereServiceEntry.RelationType);
			}
		}


		virtual public ServiceEntryHeader ServiceEntryHeaderWhereServiceEntry
		{ 
			get
			{
				return (ServiceEntryHeader) Strategy.GetCompositeAssociation(Meta.ServiceEntryHeaderWhereServiceEntry.RelationType);
			}
		} 

		virtual public bool ExistServiceEntryHeaderWhereServiceEntry
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.ServiceEntryHeaderWhereServiceEntry.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new DeliverableTurnoverOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new DeliverableTurnoverOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new DeliverableTurnoverOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new DeliverableTurnoverOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new DeliverableTurnoverOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new DeliverableTurnoverOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new DeliverableTurnoverOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new DeliverableTurnoverOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new DeliverableTurnoverOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new DeliverableTurnoverOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class DeliverableTurnoverBuilder : Allors.ObjectBuilder<DeliverableTurnover> , ServiceEntryBuilder, global::System.IDisposable
	{		
		public DeliverableTurnoverBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(DeliverableTurnover instance)
		{
			

			if(this.Amount.HasValue)
			{
				instance.Amount = this.Amount.Value;
			}			
		
		
			

			if(this.ThroughDateTime.HasValue)
			{
				instance.ThroughDateTime = this.ThroughDateTime.Value;
			}			
		
		
			

			if(this.IsBillable.HasValue)
			{
				instance.IsBillable = this.IsBillable.Value;
			}			
		
		
			

			if(this.FromDateTime.HasValue)
			{
				instance.FromDateTime = this.FromDateTime.Value;
			}			
		
		

			instance.Description = this.Description;
		
		

			instance.Comment = this.Comment;
		
		

			instance.EngagementItem = this.EngagementItem;

		

			instance.WorkEffort = this.WorkEffort;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Decimal? Amount {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithAmount(global::System.Decimal? value)
		        {
				    if(this.Amount!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Amount = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDateTime {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithThroughDateTime(global::System.DateTime? value)
		        {
				    if(this.ThroughDateTime!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDateTime = value;
		            return this;
		        }	

				public EngagementItem EngagementItem {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithEngagementItem(EngagementItem value)
		        {
		            if(this.EngagementItem!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.EngagementItem = value;
		            return this;
		        }		

				
				public global::System.Boolean? IsBillable {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithIsBillable(global::System.Boolean? value)
		        {
				    if(this.IsBillable!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IsBillable = value;
		            return this;
		        }	

				public global::System.DateTime? FromDateTime {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithFromDateTime(global::System.DateTime? value)
		        {
				    if(this.FromDateTime!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDateTime = value;
		            return this;
		        }	

				public global::System.String Description {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public WorkEffort WorkEffort {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithWorkEffort(WorkEffort value)
		        {
		            if(this.WorkEffort!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.WorkEffort = value;
		            return this;
		        }		

				
				public global::System.String Comment {get; set;}

				/// <exclude/>
				public DeliverableTurnoverBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public DeliverableTurnoverBuilder WithDeniedPermission(Permission value)
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
				public DeliverableTurnoverBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class DeliverableTurnovers : global::Allors.ObjectsBase<DeliverableTurnover>
	{
		public DeliverableTurnovers(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaDeliverableTurnover Meta
		{
			get
			{
				return Allors.Meta.MetaDeliverableTurnover.Instance;
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