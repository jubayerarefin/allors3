// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class InvoiceTerm : Allors.IObject , AgreementTerm
	{
		private readonly IStrategy strategy;

		public InvoiceTerm(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaInvoiceTerm Meta
		{
			get
			{
				return Allors.Meta.MetaInvoiceTerm.Instance;
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

		public static InvoiceTerm Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (InvoiceTerm) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.String TermValue 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.TermValue.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.TermValue.RelationType, value);
			}
		}

		virtual public bool ExistTermValue{
			get
			{
				return Strategy.ExistUnitRole(Meta.TermValue.RelationType);
			}
		}

		virtual public void RemoveTermValue()
		{
			Strategy.RemoveUnitRole(Meta.TermValue.RelationType);
		}


		virtual public TermType TermType
		{ 
			get
			{
				return (TermType) Strategy.GetCompositeRole(Meta.TermType.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.TermType.RelationType, value);
			}
		}

		virtual public bool ExistTermType
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.TermType.RelationType);
			}
		}

		virtual public void RemoveTermType()
		{
			Strategy.RemoveCompositeRole(Meta.TermType.RelationType);
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



		virtual public global::Allors.Extent<InvoiceVersion> InvoiceVersionsWhereInvoiceTerm
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InvoiceVersionsWhereInvoiceTerm.RelationType);
			}
		}

		virtual public bool ExistInvoiceVersionsWhereInvoiceTerm
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InvoiceVersionsWhereInvoiceTerm.RelationType);
			}
		}


		virtual public Invoice InvoiceWhereInvoiceTerm
		{ 
			get
			{
				return (Invoice) Strategy.GetCompositeAssociation(Meta.InvoiceWhereInvoiceTerm.RelationType);
			}
		} 

		virtual public bool ExistInvoiceWhereInvoiceTerm
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.InvoiceWhereInvoiceTerm.RelationType);
			}
		}


		virtual public Agreement AgreementWhereAgreementTerm
		{ 
			get
			{
				return (Agreement) Strategy.GetCompositeAssociation(Meta.AgreementWhereAgreementTerm.RelationType);
			}
		} 

		virtual public bool ExistAgreementWhereAgreementTerm
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.AgreementWhereAgreementTerm.RelationType);
			}
		}


		virtual public AgreementItem AgreementItemWhereAgreementTerm
		{ 
			get
			{
				return (AgreementItem) Strategy.GetCompositeAssociation(Meta.AgreementItemWhereAgreementTerm.RelationType);
			}
		} 

		virtual public bool ExistAgreementItemWhereAgreementTerm
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.AgreementItemWhereAgreementTerm.RelationType);
			}
		}


		virtual public global::Allors.Extent<InvoiceItemVersion> InvoiceItemVersionsWhereInvoiceTerm
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InvoiceItemVersionsWhereInvoiceTerm.RelationType);
			}
		}

		virtual public bool ExistInvoiceItemVersionsWhereInvoiceTerm
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InvoiceItemVersionsWhereInvoiceTerm.RelationType);
			}
		}


		virtual public InvoiceItem InvoiceItemWhereInvoiceTerm
		{ 
			get
			{
				return (InvoiceItem) Strategy.GetCompositeAssociation(Meta.InvoiceItemWhereInvoiceTerm.RelationType);
			}
		} 

		virtual public bool ExistInvoiceItemWhereInvoiceTerm
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.InvoiceItemWhereInvoiceTerm.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new InvoiceTermOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new InvoiceTermOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new InvoiceTermOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new InvoiceTermOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new InvoiceTermOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new InvoiceTermOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new InvoiceTermOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new InvoiceTermOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new InvoiceTermOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new InvoiceTermOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class InvoiceTermBuilder : Allors.ObjectBuilder<InvoiceTerm> , AgreementTermBuilder, global::System.IDisposable
	{		
		public InvoiceTermBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(InvoiceTerm instance)
		{

			instance.TermValue = this.TermValue;
		
		

			instance.Description = this.Description;
		
		

			instance.TermType = this.TermType;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.String TermValue {get; set;}

				/// <exclude/>
				public InvoiceTermBuilder WithTermValue(global::System.String value)
		        {
				    if(this.TermValue!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.TermValue = value;
		            return this;
		        }	

				public TermType TermType {get; set;}

				/// <exclude/>
				public InvoiceTermBuilder WithTermType(TermType value)
		        {
		            if(this.TermType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.TermType = value;
		            return this;
		        }		

				
				public global::System.String Description {get; set;}

				/// <exclude/>
				public InvoiceTermBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public InvoiceTermBuilder WithDeniedPermission(Permission value)
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
				public InvoiceTermBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class InvoiceTerms : global::Allors.ObjectsBase<InvoiceTerm>
	{
		public InvoiceTerms(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaInvoiceTerm Meta
		{
			get
			{
				return Allors.Meta.MetaInvoiceTerm.Instance;
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