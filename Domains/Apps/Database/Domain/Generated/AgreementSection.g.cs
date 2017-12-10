// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class AgreementSection : Allors.IObject , AgreementItem
	{
		private readonly IStrategy strategy;

		public AgreementSection(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaAgreementSection Meta
		{
			get
			{
				return Allors.Meta.MetaAgreementSection.Instance;
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

		public static AgreementSection Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (AgreementSection) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public global::Allors.Extent<AgreementItem> Children
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Children.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Children.RelationType, value);
			}
		}

		virtual public void AddChild (AgreementItem value)
		{
			Strategy.AddCompositeRole(Meta.Children.RelationType, value);
		}

		virtual public void RemoveChild (AgreementItem value)
		{
			Strategy.RemoveCompositeRole(Meta.Children.RelationType, value);
		}

		virtual public bool ExistChildren
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Children.RelationType);
			}
		}

		virtual public void RemoveChildren()
		{
			Strategy.RemoveCompositeRoles(Meta.Children.RelationType);
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



		virtual public Agreement AgreementWhereAgreementItem
		{ 
			get
			{
				return (Agreement) Strategy.GetCompositeAssociation(Meta.AgreementWhereAgreementItem.RelationType);
			}
		} 

		virtual public bool ExistAgreementWhereAgreementItem
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.AgreementWhereAgreementItem.RelationType);
			}
		}


		virtual public AgreementItem AgreementItemWhereChild
		{ 
			get
			{
				return (AgreementItem) Strategy.GetCompositeAssociation(Meta.AgreementItemWhereChild.RelationType);
			}
		} 

		virtual public bool ExistAgreementItemWhereChild
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.AgreementItemWhereChild.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new AgreementSectionOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new AgreementSectionOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new AgreementSectionOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new AgreementSectionOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new AgreementSectionOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new AgreementSectionOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new AgreementSectionOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new AgreementSectionOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new AgreementSectionOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new AgreementSectionOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class AgreementSectionBuilder : Allors.ObjectBuilder<AgreementSection> , AgreementItemBuilder, global::System.IDisposable
	{		
		public AgreementSectionBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(AgreementSection instance)
		{

			instance.Text = this.Text;
		
		

			instance.Description = this.Description;
		
		
			if(this.Addenda!=null)
			{
				instance.Addenda = this.Addenda.ToArray();
			}
		
			if(this.Children!=null)
			{
				instance.Children = this.Children.ToArray();
			}
		
			if(this.AgreementTerms!=null)
			{
				instance.AgreementTerms = this.AgreementTerms.ToArray();
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


				public global::System.String Text {get; set;}

				/// <exclude/>
				public AgreementSectionBuilder WithText(global::System.String value)
		        {
				    if(this.Text!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Text = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Addendum> Addenda {get; set;}	

				/// <exclude/>
				public AgreementSectionBuilder WithAddenda(Addendum value)
		        {
					if(this.Addenda == null)
					{
						this.Addenda = new global::System.Collections.Generic.List<Addendum>(); 
					}
		            this.Addenda.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<AgreementItem> Children {get; set;}	

				/// <exclude/>
				public AgreementSectionBuilder WithChild(AgreementItem value)
		        {
					if(this.Children == null)
					{
						this.Children = new global::System.Collections.Generic.List<AgreementItem>(); 
					}
		            this.Children.Add(value);
		            return this;
		        }		

				
				public global::System.String Description {get; set;}

				/// <exclude/>
				public AgreementSectionBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<AgreementTerm> AgreementTerms {get; set;}	

				/// <exclude/>
				public AgreementSectionBuilder WithAgreementTerm(AgreementTerm value)
		        {
					if(this.AgreementTerms == null)
					{
						this.AgreementTerms = new global::System.Collections.Generic.List<AgreementTerm>(); 
					}
		            this.AgreementTerms.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public AgreementSectionBuilder WithDeniedPermission(Permission value)
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
				public AgreementSectionBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class AgreementSections : global::Allors.ObjectsBase<AgreementSection>
	{
		public AgreementSections(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaAgreementSection Meta
		{
			get
			{
				return Allors.Meta.MetaAgreementSection.Instance;
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