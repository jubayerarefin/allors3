// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class SubContractorAgreement : Allors.IObject , Agreement
	{
		private readonly IStrategy strategy;

		public SubContractorAgreement(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSubContractorAgreement Meta
		{
			get
			{
				return Allors.Meta.MetaSubContractorAgreement.Instance;
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

		public static SubContractorAgreement Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (SubContractorAgreement) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.DateTime? AgreementDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.AgreementDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AgreementDate.RelationType, value);
			}
		}

		virtual public bool ExistAgreementDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.AgreementDate.RelationType);
			}
		}

		virtual public void RemoveAgreementDate()
		{
			Strategy.RemoveUnitRole(Meta.AgreementDate.RelationType);
		}


		virtual public global::Allors.Extent<Addendum> Addenda
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Addenda.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Addenda.RelationType, value);
			}
		}

		virtual public void AddAddenda (Addendum value)
		{
			Strategy.AddCompositeRole(Meta.Addenda.RelationType, value);
		}

		virtual public void RemoveAddenda (Addendum value)
		{
			Strategy.RemoveCompositeRole(Meta.Addenda.RelationType, value);
		}

		virtual public bool ExistAddenda
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Addenda.RelationType);
			}
		}

		virtual public void RemoveAddenda()
		{
			Strategy.RemoveCompositeRoles(Meta.Addenda.RelationType);
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


		virtual public global::Allors.Extent<AgreementTerm> AgreementTerms
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.AgreementTerms.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.AgreementTerms.RelationType, value);
			}
		}

		virtual public void AddAgreementTerm (AgreementTerm value)
		{
			Strategy.AddCompositeRole(Meta.AgreementTerms.RelationType, value);
		}

		virtual public void RemoveAgreementTerm (AgreementTerm value)
		{
			Strategy.RemoveCompositeRole(Meta.AgreementTerms.RelationType, value);
		}

		virtual public bool ExistAgreementTerms
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.AgreementTerms.RelationType);
			}
		}

		virtual public void RemoveAgreementTerms()
		{
			Strategy.RemoveCompositeRoles(Meta.AgreementTerms.RelationType);
		}


		virtual public global::System.String Text 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Text.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Text.RelationType, value);
			}
		}

		virtual public bool ExistText{
			get
			{
				return Strategy.ExistUnitRole(Meta.Text.RelationType);
			}
		}

		virtual public void RemoveText()
		{
			Strategy.RemoveUnitRole(Meta.Text.RelationType);
		}


		virtual public global::Allors.Extent<AgreementItem> AgreementItems
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.AgreementItems.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.AgreementItems.RelationType, value);
			}
		}

		virtual public void AddAgreementItem (AgreementItem value)
		{
			Strategy.AddCompositeRole(Meta.AgreementItems.RelationType, value);
		}

		virtual public void RemoveAgreementItem (AgreementItem value)
		{
			Strategy.RemoveCompositeRole(Meta.AgreementItems.RelationType, value);
		}

		virtual public bool ExistAgreementItems
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.AgreementItems.RelationType);
			}
		}

		virtual public void RemoveAgreementItems()
		{
			Strategy.RemoveCompositeRoles(Meta.AgreementItems.RelationType);
		}


		virtual public global::System.String AgreementNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.AgreementNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AgreementNumber.RelationType, value);
			}
		}

		virtual public bool ExistAgreementNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.AgreementNumber.RelationType);
			}
		}

		virtual public void RemoveAgreementNumber()
		{
			Strategy.RemoveUnitRole(Meta.AgreementNumber.RelationType);
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



		virtual public global::Allors.Extent<Engagement> EngagementsWhereAgreement
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EngagementsWhereAgreement.RelationType);
			}
		}

		virtual public bool ExistEngagementsWhereAgreement
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EngagementsWhereAgreement.RelationType);
			}
		}


		virtual public PartyVersion PartyVersionWhereAgreement
		{ 
			get
			{
				return (PartyVersion) Strategy.GetCompositeAssociation(Meta.PartyVersionWhereAgreement.RelationType);
			}
		} 

		virtual public bool ExistPartyVersionWhereAgreement
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PartyVersionWhereAgreement.RelationType);
			}
		}


		virtual public Party PartyWhereAgreement
		{ 
			get
			{
				return (Party) Strategy.GetCompositeAssociation(Meta.PartyWhereAgreement.RelationType);
			}
		} 

		virtual public bool ExistPartyWhereAgreement
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PartyWhereAgreement.RelationType);
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
			var method = new SubContractorAgreementOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SubContractorAgreementOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SubContractorAgreementOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SubContractorAgreementOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SubContractorAgreementOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SubContractorAgreementOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SubContractorAgreementOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SubContractorAgreementOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SubContractorAgreementOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SubContractorAgreementOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SubContractorAgreementBuilder : Allors.ObjectBuilder<SubContractorAgreement> , AgreementBuilder, global::System.IDisposable
	{		
		public SubContractorAgreementBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(SubContractorAgreement instance)
		{
			

			if(this.AgreementDate.HasValue)
			{
				instance.AgreementDate = this.AgreementDate.Value;
			}			
		
		

			instance.Description = this.Description;
		
		

			instance.Text = this.Text;
		
		

			instance.AgreementNumber = this.AgreementNumber;
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
			

			if(this.FromDate.HasValue)
			{
				instance.FromDate = this.FromDate.Value;
			}			
		
		
			

			if(this.ThroughDate.HasValue)
			{
				instance.ThroughDate = this.ThroughDate.Value;
			}			
		
		
			if(this.Addenda!=null)
			{
				instance.Addenda = this.Addenda.ToArray();
			}
		
			if(this.AgreementTerms!=null)
			{
				instance.AgreementTerms = this.AgreementTerms.ToArray();
			}
		
			if(this.AgreementItems!=null)
			{
				instance.AgreementItems = this.AgreementItems.ToArray();
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


				public global::System.DateTime? AgreementDate {get; set;}

				/// <exclude/>
				public SubContractorAgreementBuilder WithAgreementDate(global::System.DateTime? value)
		        {
				    if(this.AgreementDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AgreementDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Addendum> Addenda {get; set;}	

				/// <exclude/>
				public SubContractorAgreementBuilder WithAddenda(Addendum value)
		        {
					if(this.Addenda == null)
					{
						this.Addenda = new global::System.Collections.Generic.List<Addendum>(); 
					}
		            this.Addenda.Add(value);
		            return this;
		        }		

				
				public global::System.String Description {get; set;}

				/// <exclude/>
				public SubContractorAgreementBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<AgreementTerm> AgreementTerms {get; set;}	

				/// <exclude/>
				public SubContractorAgreementBuilder WithAgreementTerm(AgreementTerm value)
		        {
					if(this.AgreementTerms == null)
					{
						this.AgreementTerms = new global::System.Collections.Generic.List<AgreementTerm>(); 
					}
		            this.AgreementTerms.Add(value);
		            return this;
		        }		

				
				public global::System.String Text {get; set;}

				/// <exclude/>
				public SubContractorAgreementBuilder WithText(global::System.String value)
		        {
				    if(this.Text!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Text = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<AgreementItem> AgreementItems {get; set;}	

				/// <exclude/>
				public SubContractorAgreementBuilder WithAgreementItem(AgreementItem value)
		        {
					if(this.AgreementItems == null)
					{
						this.AgreementItems = new global::System.Collections.Generic.List<AgreementItem>(); 
					}
		            this.AgreementItems.Add(value);
		            return this;
		        }		

				
				public global::System.String AgreementNumber {get; set;}

				/// <exclude/>
				public SubContractorAgreementBuilder WithAgreementNumber(global::System.String value)
		        {
				    if(this.AgreementNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AgreementNumber = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SubContractorAgreementBuilder WithDeniedPermission(Permission value)
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
				public SubContractorAgreementBuilder WithSecurityToken(SecurityToken value)
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
				public SubContractorAgreementBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	

				public global::System.DateTime? FromDate {get; set;}

				/// <exclude/>
				public SubContractorAgreementBuilder WithFromDate(global::System.DateTime? value)
		        {
				    if(this.FromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDate {get; set;}

				/// <exclude/>
				public SubContractorAgreementBuilder WithThroughDate(global::System.DateTime? value)
		        {
				    if(this.ThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDate = value;
		            return this;
		        }	


	}

	public partial class SubContractorAgreements : global::Allors.ObjectsBase<SubContractorAgreement>
	{
		public SubContractorAgreements(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSubContractorAgreement Meta
		{
			get
			{
				return Allors.Meta.MetaSubContractorAgreement.Instance;
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