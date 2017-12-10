// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class CapitalBudgetVersion : Allors.IObject , BudgetVersion
	{
		private readonly IStrategy strategy;

		public CapitalBudgetVersion(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaCapitalBudgetVersion Meta
		{
			get
			{
				return Allors.Meta.MetaCapitalBudgetVersion.Instance;
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

		public static CapitalBudgetVersion Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (CapitalBudgetVersion) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public BudgetState BudgetState
		{ 
			get
			{
				return (BudgetState) Strategy.GetCompositeRole(Meta.BudgetState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.BudgetState.RelationType, value);
			}
		}

		virtual public bool ExistBudgetState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.BudgetState.RelationType);
			}
		}

		virtual public void RemoveBudgetState()
		{
			Strategy.RemoveCompositeRole(Meta.BudgetState.RelationType);
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


		virtual public global::Allors.Extent<BudgetRevision> BudgetRevisions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.BudgetRevisions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.BudgetRevisions.RelationType, value);
			}
		}

		virtual public void AddBudgetRevision (BudgetRevision value)
		{
			Strategy.AddCompositeRole(Meta.BudgetRevisions.RelationType, value);
		}

		virtual public void RemoveBudgetRevision (BudgetRevision value)
		{
			Strategy.RemoveCompositeRole(Meta.BudgetRevisions.RelationType, value);
		}

		virtual public bool ExistBudgetRevisions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.BudgetRevisions.RelationType);
			}
		}

		virtual public void RemoveBudgetRevisions()
		{
			Strategy.RemoveCompositeRoles(Meta.BudgetRevisions.RelationType);
		}


		virtual public global::System.String BudgetNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.BudgetNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.BudgetNumber.RelationType, value);
			}
		}

		virtual public bool ExistBudgetNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.BudgetNumber.RelationType);
			}
		}

		virtual public void RemoveBudgetNumber()
		{
			Strategy.RemoveUnitRole(Meta.BudgetNumber.RelationType);
		}


		virtual public global::Allors.Extent<BudgetReview> BudgetReviews
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.BudgetReviews.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.BudgetReviews.RelationType, value);
			}
		}

		virtual public void AddBudgetReview (BudgetReview value)
		{
			Strategy.AddCompositeRole(Meta.BudgetReviews.RelationType, value);
		}

		virtual public void RemoveBudgetReview (BudgetReview value)
		{
			Strategy.RemoveCompositeRole(Meta.BudgetReviews.RelationType, value);
		}

		virtual public bool ExistBudgetReviews
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.BudgetReviews.RelationType);
			}
		}

		virtual public void RemoveBudgetReviews()
		{
			Strategy.RemoveCompositeRoles(Meta.BudgetReviews.RelationType);
		}


		virtual public global::Allors.Extent<BudgetItem> BudgetItems
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.BudgetItems.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.BudgetItems.RelationType, value);
			}
		}

		virtual public void AddBudgetItem (BudgetItem value)
		{
			Strategy.AddCompositeRole(Meta.BudgetItems.RelationType, value);
		}

		virtual public void RemoveBudgetItem (BudgetItem value)
		{
			Strategy.RemoveCompositeRole(Meta.BudgetItems.RelationType, value);
		}

		virtual public bool ExistBudgetItems
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.BudgetItems.RelationType);
			}
		}

		virtual public void RemoveBudgetItems()
		{
			Strategy.RemoveCompositeRoles(Meta.BudgetItems.RelationType);
		}


		virtual public global::System.Guid? DerivationId 
		{
			get
			{
				return (global::System.Guid?) Strategy.GetUnitRole(Meta.DerivationId.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.DerivationId.RelationType, value);
			}
		}

		virtual public bool ExistDerivationId{
			get
			{
				return Strategy.ExistUnitRole(Meta.DerivationId.RelationType);
			}
		}

		virtual public void RemoveDerivationId()
		{
			Strategy.RemoveUnitRole(Meta.DerivationId.RelationType);
		}


		virtual public global::System.DateTime? DerivationTimeStamp 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.DerivationTimeStamp.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.DerivationTimeStamp.RelationType, value);
			}
		}

		virtual public bool ExistDerivationTimeStamp{
			get
			{
				return Strategy.ExistUnitRole(Meta.DerivationTimeStamp.RelationType);
			}
		}

		virtual public void RemoveDerivationTimeStamp()
		{
			Strategy.RemoveUnitRole(Meta.DerivationTimeStamp.RelationType);
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
			var method = new CapitalBudgetVersionOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new CapitalBudgetVersionOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new CapitalBudgetVersionOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new CapitalBudgetVersionOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new CapitalBudgetVersionOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new CapitalBudgetVersionOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new CapitalBudgetVersionOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new CapitalBudgetVersionOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new CapitalBudgetVersionOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new CapitalBudgetVersionOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class CapitalBudgetVersionBuilder : Allors.ObjectBuilder<CapitalBudgetVersion> , BudgetVersionBuilder, global::System.IDisposable
	{		
		public CapitalBudgetVersionBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(CapitalBudgetVersion instance)
		{
			

			if(this.FromDate.HasValue)
			{
				instance.FromDate = this.FromDate.Value;
			}			
		
		
			

			if(this.ThroughDate.HasValue)
			{
				instance.ThroughDate = this.ThroughDate.Value;
			}			
		
		

			instance.Comment = this.Comment;
		
		

			instance.Description = this.Description;
		
		

			instance.BudgetNumber = this.BudgetNumber;
		
		
			

			if(this.DerivationId.HasValue)
			{
				instance.DerivationId = this.DerivationId.Value;
			}			
		
		
			

			if(this.DerivationTimeStamp.HasValue)
			{
				instance.DerivationTimeStamp = this.DerivationTimeStamp.Value;
			}			
		
		

			instance.BudgetState = this.BudgetState;

		
			if(this.BudgetRevisions!=null)
			{
				instance.BudgetRevisions = this.BudgetRevisions.ToArray();
			}
		
			if(this.BudgetReviews!=null)
			{
				instance.BudgetReviews = this.BudgetReviews.ToArray();
			}
		
			if(this.BudgetItems!=null)
			{
				instance.BudgetItems = this.BudgetItems.ToArray();
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


				public BudgetState BudgetState {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithBudgetState(BudgetState value)
		        {
		            if(this.BudgetState!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.BudgetState = value;
		            return this;
		        }		

				
				public global::System.DateTime? FromDate {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithFromDate(global::System.DateTime? value)
		        {
				    if(this.FromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDate {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithThroughDate(global::System.DateTime? value)
		        {
				    if(this.ThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDate = value;
		            return this;
		        }	

				public global::System.String Comment {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	

				public global::System.String Description {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<BudgetRevision> BudgetRevisions {get; set;}	

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithBudgetRevision(BudgetRevision value)
		        {
					if(this.BudgetRevisions == null)
					{
						this.BudgetRevisions = new global::System.Collections.Generic.List<BudgetRevision>(); 
					}
		            this.BudgetRevisions.Add(value);
		            return this;
		        }		

				
				public global::System.String BudgetNumber {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithBudgetNumber(global::System.String value)
		        {
				    if(this.BudgetNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.BudgetNumber = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<BudgetReview> BudgetReviews {get; set;}	

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithBudgetReview(BudgetReview value)
		        {
					if(this.BudgetReviews == null)
					{
						this.BudgetReviews = new global::System.Collections.Generic.List<BudgetReview>(); 
					}
		            this.BudgetReviews.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<BudgetItem> BudgetItems {get; set;}	

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithBudgetItem(BudgetItem value)
		        {
					if(this.BudgetItems == null)
					{
						this.BudgetItems = new global::System.Collections.Generic.List<BudgetItem>(); 
					}
		            this.BudgetItems.Add(value);
		            return this;
		        }		

				
				public global::System.Guid? DerivationId {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithDerivationId(global::System.Guid? value)
		        {
				    if(this.DerivationId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationId = value;
		            return this;
		        }	

				public global::System.DateTime? DerivationTimeStamp {get; set;}

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithDerivationTimeStamp(global::System.DateTime? value)
		        {
				    if(this.DerivationTimeStamp!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationTimeStamp = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public CapitalBudgetVersionBuilder WithDeniedPermission(Permission value)
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
				public CapitalBudgetVersionBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class CapitalBudgetVersions : global::Allors.ObjectsBase<CapitalBudgetVersion>
	{
		public CapitalBudgetVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaCapitalBudgetVersion Meta
		{
			get
			{
				return Allors.Meta.MetaCapitalBudgetVersion.Instance;
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