// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Disbursement : Allors.IObject , Payment
	{
		private readonly IStrategy strategy;

		public Disbursement(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaDisbursement Meta
		{
			get
			{
				return Allors.Meta.MetaDisbursement.Instance;
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

		public static Disbursement Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Disbursement) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public PaymentMethod PaymentMethod
		{ 
			get
			{
				return (PaymentMethod) Strategy.GetCompositeRole(Meta.PaymentMethod.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PaymentMethod.RelationType, value);
			}
		}

		virtual public bool ExistPaymentMethod
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PaymentMethod.RelationType);
			}
		}

		virtual public void RemovePaymentMethod()
		{
			Strategy.RemoveCompositeRole(Meta.PaymentMethod.RelationType);
		}


		virtual public global::System.DateTime EffectiveDate 
		{
			get
			{
				return (global::System.DateTime) Strategy.GetUnitRole(Meta.EffectiveDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EffectiveDate.RelationType, value);
			}
		}

		virtual public bool ExistEffectiveDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.EffectiveDate.RelationType);
			}
		}

		virtual public void RemoveEffectiveDate()
		{
			Strategy.RemoveUnitRole(Meta.EffectiveDate.RelationType);
		}


		virtual public Party SendingParty
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.SendingParty.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.SendingParty.RelationType, value);
			}
		}

		virtual public bool ExistSendingParty
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.SendingParty.RelationType);
			}
		}

		virtual public void RemoveSendingParty()
		{
			Strategy.RemoveCompositeRole(Meta.SendingParty.RelationType);
		}


		virtual public global::Allors.Extent<PaymentApplication> PaymentApplications
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.PaymentApplications.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PaymentApplications.RelationType, value);
			}
		}

		virtual public void AddPaymentApplication (PaymentApplication value)
		{
			Strategy.AddCompositeRole(Meta.PaymentApplications.RelationType, value);
		}

		virtual public void RemovePaymentApplication (PaymentApplication value)
		{
			Strategy.RemoveCompositeRole(Meta.PaymentApplications.RelationType, value);
		}

		virtual public bool ExistPaymentApplications
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PaymentApplications.RelationType);
			}
		}

		virtual public void RemovePaymentApplications()
		{
			Strategy.RemoveCompositeRoles(Meta.PaymentApplications.RelationType);
		}


		virtual public global::System.String ReferenceNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.ReferenceNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ReferenceNumber.RelationType, value);
			}
		}

		virtual public bool ExistReferenceNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.ReferenceNumber.RelationType);
			}
		}

		virtual public void RemoveReferenceNumber()
		{
			Strategy.RemoveUnitRole(Meta.ReferenceNumber.RelationType);
		}


		virtual public Party ReceivingParty
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.ReceivingParty.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ReceivingParty.RelationType, value);
			}
		}

		virtual public bool ExistReceivingParty
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ReceivingParty.RelationType);
			}
		}

		virtual public void RemoveReceivingParty()
		{
			Strategy.RemoveCompositeRole(Meta.ReceivingParty.RelationType);
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



		virtual public DisbursementAccountingTransaction DisbursementAccountingTransactionWhereDisbursement
		{ 
			get
			{
				return (DisbursementAccountingTransaction) Strategy.GetCompositeAssociation(Meta.DisbursementAccountingTransactionWhereDisbursement.RelationType);
			}
		} 

		virtual public bool ExistDisbursementAccountingTransactionWhereDisbursement
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.DisbursementAccountingTransactionWhereDisbursement.RelationType);
			}
		}


		virtual public Withdrawal WithdrawalWhereDisbursement
		{ 
			get
			{
				return (Withdrawal) Strategy.GetCompositeAssociation(Meta.WithdrawalWhereDisbursement.RelationType);
			}
		} 

		virtual public bool ExistWithdrawalWhereDisbursement
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.WithdrawalWhereDisbursement.RelationType);
			}
		}


		virtual public global::Allors.Extent<PaymentBudgetAllocation> PaymentBudgetAllocationsWherePayment
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PaymentBudgetAllocationsWherePayment.RelationType);
			}
		}

		virtual public bool ExistPaymentBudgetAllocationsWherePayment
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PaymentBudgetAllocationsWherePayment.RelationType);
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
			var method = new DisbursementOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new DisbursementOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new DisbursementOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new DisbursementOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new DisbursementOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new DisbursementOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new DisbursementOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new DisbursementOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new DisbursementOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new DisbursementOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class DisbursementBuilder : Allors.ObjectBuilder<Disbursement> , PaymentBuilder, global::System.IDisposable
	{		
		public DisbursementBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Disbursement instance)
		{
			

			if(this.Amount.HasValue)
			{
				instance.Amount = this.Amount.Value;
			}			
		
		
			

			if(this.EffectiveDate.HasValue)
			{
				instance.EffectiveDate = this.EffectiveDate.Value;
			}			
		
		

			instance.ReferenceNumber = this.ReferenceNumber;
		
		

			instance.Comment = this.Comment;
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		

			instance.PaymentMethod = this.PaymentMethod;

		

			instance.SendingParty = this.SendingParty;

		
			if(this.PaymentApplications!=null)
			{
				instance.PaymentApplications = this.PaymentApplications.ToArray();
			}
		

			instance.ReceivingParty = this.ReceivingParty;

		
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
				public DisbursementBuilder WithAmount(global::System.Decimal? value)
		        {
				    if(this.Amount!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Amount = value;
		            return this;
		        }	

				public PaymentMethod PaymentMethod {get; set;}

				/// <exclude/>
				public DisbursementBuilder WithPaymentMethod(PaymentMethod value)
		        {
		            if(this.PaymentMethod!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.PaymentMethod = value;
		            return this;
		        }		

				
				public global::System.DateTime? EffectiveDate {get; set;}

				/// <exclude/>
				public DisbursementBuilder WithEffectiveDate(global::System.DateTime? value)
		        {
				    if(this.EffectiveDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EffectiveDate = value;
		            return this;
		        }	

				public Party SendingParty {get; set;}

				/// <exclude/>
				public DisbursementBuilder WithSendingParty(Party value)
		        {
		            if(this.SendingParty!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.SendingParty = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<PaymentApplication> PaymentApplications {get; set;}	

				/// <exclude/>
				public DisbursementBuilder WithPaymentApplication(PaymentApplication value)
		        {
					if(this.PaymentApplications == null)
					{
						this.PaymentApplications = new global::System.Collections.Generic.List<PaymentApplication>(); 
					}
		            this.PaymentApplications.Add(value);
		            return this;
		        }		

				
				public global::System.String ReferenceNumber {get; set;}

				/// <exclude/>
				public DisbursementBuilder WithReferenceNumber(global::System.String value)
		        {
				    if(this.ReferenceNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ReferenceNumber = value;
		            return this;
		        }	

				public Party ReceivingParty {get; set;}

				/// <exclude/>
				public DisbursementBuilder WithReceivingParty(Party value)
		        {
		            if(this.ReceivingParty!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ReceivingParty = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public DisbursementBuilder WithDeniedPermission(Permission value)
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
				public DisbursementBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				
				public global::System.String Comment {get; set;}

				/// <exclude/>
				public DisbursementBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	

				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public DisbursementBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	


	}

	public partial class Disbursements : global::Allors.ObjectsBase<Disbursement>
	{
		public Disbursements(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaDisbursement Meta
		{
			get
			{
				return Allors.Meta.MetaDisbursement.Instance;
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