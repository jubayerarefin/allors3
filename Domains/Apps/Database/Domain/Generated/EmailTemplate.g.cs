// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class EmailTemplate : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public EmailTemplate(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaEmailTemplate Meta
		{
			get
			{
				return Allors.Meta.MetaEmailTemplate.Instance;
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

		public static EmailTemplate Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (EmailTemplate) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public global::System.String BodyTemplate 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.BodyTemplate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.BodyTemplate.RelationType, value);
			}
		}

		virtual public bool ExistBodyTemplate{
			get
			{
				return Strategy.ExistUnitRole(Meta.BodyTemplate.RelationType);
			}
		}

		virtual public void RemoveBodyTemplate()
		{
			Strategy.RemoveUnitRole(Meta.BodyTemplate.RelationType);
		}


		virtual public global::System.String SubjectTemplate 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.SubjectTemplate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.SubjectTemplate.RelationType, value);
			}
		}

		virtual public bool ExistSubjectTemplate{
			get
			{
				return Strategy.ExistUnitRole(Meta.SubjectTemplate.RelationType);
			}
		}

		virtual public void RemoveSubjectTemplate()
		{
			Strategy.RemoveUnitRole(Meta.SubjectTemplate.RelationType);
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



		virtual public global::Allors.Extent<EmailCommunication> EmailCommunicationsWhereEmailTemplate
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EmailCommunicationsWhereEmailTemplate.RelationType);
			}
		}

		virtual public bool ExistEmailCommunicationsWhereEmailTemplate
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EmailCommunicationsWhereEmailTemplate.RelationType);
			}
		}


		virtual public global::Allors.Extent<EmailCommunicationVersion> EmailCommunicationVersionsWhereEmailTemplate
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EmailCommunicationVersionsWhereEmailTemplate.RelationType);
			}
		}

		virtual public bool ExistEmailCommunicationVersionsWhereEmailTemplate
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EmailCommunicationVersionsWhereEmailTemplate.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new EmailTemplateOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new EmailTemplateOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new EmailTemplateOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new EmailTemplateOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new EmailTemplateOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new EmailTemplateOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new EmailTemplateOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new EmailTemplateOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new EmailTemplateOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new EmailTemplateOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class EmailTemplateBuilder : Allors.ObjectBuilder<EmailTemplate> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public EmailTemplateBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(EmailTemplate instance)
		{

			instance.Description = this.Description;
		
		

			instance.BodyTemplate = this.BodyTemplate;
		
		

			instance.SubjectTemplate = this.SubjectTemplate;
		
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.String Description {get; set;}

				/// <exclude/>
				public EmailTemplateBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.String BodyTemplate {get; set;}

				/// <exclude/>
				public EmailTemplateBuilder WithBodyTemplate(global::System.String value)
		        {
				    if(this.BodyTemplate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.BodyTemplate = value;
		            return this;
		        }	

				public global::System.String SubjectTemplate {get; set;}

				/// <exclude/>
				public EmailTemplateBuilder WithSubjectTemplate(global::System.String value)
		        {
				    if(this.SubjectTemplate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.SubjectTemplate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public EmailTemplateBuilder WithDeniedPermission(Permission value)
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
				public EmailTemplateBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class EmailTemplates : global::Allors.ObjectsBase<EmailTemplate>
	{
		public EmailTemplates(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaEmailTemplate Meta
		{
			get
			{
				return Allors.Meta.MetaEmailTemplate.Instance;
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