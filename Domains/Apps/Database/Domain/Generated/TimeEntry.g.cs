// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class TimeEntry : Allors.IObject , ServiceEntry
	{
		private readonly IStrategy strategy;

		public TimeEntry(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaTimeEntry Meta
		{
			get
			{
				return Allors.Meta.MetaTimeEntry.Instance;
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

		public static TimeEntry Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (TimeEntry) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Decimal Cost 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Cost.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Cost.RelationType, value);
			}
		}

		virtual public bool ExistCost{
			get
			{
				return Strategy.ExistUnitRole(Meta.Cost.RelationType);
			}
		}

		virtual public void RemoveCost()
		{
			Strategy.RemoveUnitRole(Meta.Cost.RelationType);
		}


		virtual public global::System.Decimal GrossMargin 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.GrossMargin.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.GrossMargin.RelationType, value);
			}
		}

		virtual public bool ExistGrossMargin{
			get
			{
				return Strategy.ExistUnitRole(Meta.GrossMargin.RelationType);
			}
		}

		virtual public void RemoveGrossMargin()
		{
			Strategy.RemoveUnitRole(Meta.GrossMargin.RelationType);
		}


		virtual public QuoteTerm QuoteTerm
		{ 
			get
			{
				return (QuoteTerm) Strategy.GetCompositeRole(Meta.QuoteTerm.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.QuoteTerm.RelationType, value);
			}
		}

		virtual public bool ExistQuoteTerm
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.QuoteTerm.RelationType);
			}
		}

		virtual public void RemoveQuoteTerm()
		{
			Strategy.RemoveCompositeRole(Meta.QuoteTerm.RelationType);
		}


		virtual public global::System.Decimal? BillingRate 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.BillingRate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.BillingRate.RelationType, value);
			}
		}

		virtual public bool ExistBillingRate{
			get
			{
				return Strategy.ExistUnitRole(Meta.BillingRate.RelationType);
			}
		}

		virtual public void RemoveBillingRate()
		{
			Strategy.RemoveUnitRole(Meta.BillingRate.RelationType);
		}


		virtual public UnitOfMeasure UnitOfMeasure
		{ 
			get
			{
				return (UnitOfMeasure) Strategy.GetCompositeRole(Meta.UnitOfMeasure.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.UnitOfMeasure.RelationType, value);
			}
		}

		virtual public bool ExistUnitOfMeasure
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.UnitOfMeasure.RelationType);
			}
		}

		virtual public void RemoveUnitOfMeasure()
		{
			Strategy.RemoveCompositeRole(Meta.UnitOfMeasure.RelationType);
		}


		virtual public global::System.Decimal? AmountOfTime 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.AmountOfTime.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AmountOfTime.RelationType, value);
			}
		}

		virtual public bool ExistAmountOfTime{
			get
			{
				return Strategy.ExistUnitRole(Meta.AmountOfTime.RelationType);
			}
		}

		virtual public void RemoveAmountOfTime()
		{
			Strategy.RemoveUnitRole(Meta.AmountOfTime.RelationType);
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



		virtual public global::Allors.Extent<SalesInvoiceItemVersion> SalesInvoiceItemVersionsWhereTimeEntry
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesInvoiceItemVersionsWhereTimeEntry.RelationType);
			}
		}

		virtual public bool ExistSalesInvoiceItemVersionsWhereTimeEntry
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesInvoiceItemVersionsWhereTimeEntry.RelationType);
			}
		}


		virtual public global::Allors.Extent<SalesInvoiceItem> SalesInvoiceItemsWhereTimeEntry
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.SalesInvoiceItemsWhereTimeEntry.RelationType);
			}
		}

		virtual public bool ExistSalesInvoiceItemsWhereTimeEntry
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.SalesInvoiceItemsWhereTimeEntry.RelationType);
			}
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
			var method = new TimeEntryOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new TimeEntryOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new TimeEntryOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new TimeEntryOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new TimeEntryOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new TimeEntryOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new TimeEntryOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new TimeEntryOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new TimeEntryOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new TimeEntryOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class TimeEntryBuilder : Allors.ObjectBuilder<TimeEntry> , ServiceEntryBuilder, global::System.IDisposable
	{		
		public TimeEntryBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(TimeEntry instance)
		{
			

			if(this.Cost.HasValue)
			{
				instance.Cost = this.Cost.Value;
			}			
		
				
			

			if(this.BillingRate.HasValue)
			{
				instance.BillingRate = this.BillingRate.Value;
			}			
		
		
			

			if(this.AmountOfTime.HasValue)
			{
				instance.AmountOfTime = this.AmountOfTime.Value;
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
		
		

			instance.QuoteTerm = this.QuoteTerm;

		

			instance.UnitOfMeasure = this.UnitOfMeasure;

		

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


				public global::System.Decimal? Cost {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithCost(global::System.Decimal? value)
		        {
				    if(this.Cost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Cost = value;
		            return this;
		        }	

				public QuoteTerm QuoteTerm {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithQuoteTerm(QuoteTerm value)
		        {
		            if(this.QuoteTerm!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.QuoteTerm = value;
		            return this;
		        }		

				
				public global::System.Decimal? BillingRate {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithBillingRate(global::System.Decimal? value)
		        {
				    if(this.BillingRate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.BillingRate = value;
		            return this;
		        }	

				public UnitOfMeasure UnitOfMeasure {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithUnitOfMeasure(UnitOfMeasure value)
		        {
		            if(this.UnitOfMeasure!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.UnitOfMeasure = value;
		            return this;
		        }		

				
				public global::System.Decimal? AmountOfTime {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithAmountOfTime(global::System.Decimal? value)
		        {
				    if(this.AmountOfTime!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AmountOfTime = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDateTime {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithThroughDateTime(global::System.DateTime? value)
		        {
				    if(this.ThroughDateTime!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDateTime = value;
		            return this;
		        }	

				public EngagementItem EngagementItem {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithEngagementItem(EngagementItem value)
		        {
		            if(this.EngagementItem!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.EngagementItem = value;
		            return this;
		        }		

				
				public global::System.Boolean? IsBillable {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithIsBillable(global::System.Boolean? value)
		        {
				    if(this.IsBillable!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IsBillable = value;
		            return this;
		        }	

				public global::System.DateTime? FromDateTime {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithFromDateTime(global::System.DateTime? value)
		        {
				    if(this.FromDateTime!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDateTime = value;
		            return this;
		        }	

				public global::System.String Description {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public WorkEffort WorkEffort {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithWorkEffort(WorkEffort value)
		        {
		            if(this.WorkEffort!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.WorkEffort = value;
		            return this;
		        }		

				
				public global::System.String Comment {get; set;}

				/// <exclude/>
				public TimeEntryBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public TimeEntryBuilder WithDeniedPermission(Permission value)
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
				public TimeEntryBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class TimeEntries : global::Allors.ObjectsBase<TimeEntry>
	{
		public TimeEntries(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaTimeEntry Meta
		{
			get
			{
				return Allors.Meta.MetaTimeEntry.Instance;
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