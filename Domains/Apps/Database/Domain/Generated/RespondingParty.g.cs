// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class RespondingParty : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public RespondingParty(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaRespondingParty Meta
		{
			get
			{
				return Allors.Meta.MetaRespondingParty.Instance;
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

		public static RespondingParty Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (RespondingParty) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.DateTime? SendingDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.SendingDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.SendingDate.RelationType, value);
			}
		}

		virtual public bool ExistSendingDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.SendingDate.RelationType);
			}
		}

		virtual public void RemoveSendingDate()
		{
			Strategy.RemoveUnitRole(Meta.SendingDate.RelationType);
		}


		virtual public ContactMechanism ContactMechanism
		{ 
			get
			{
				return (ContactMechanism) Strategy.GetCompositeRole(Meta.ContactMechanism.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ContactMechanism.RelationType, value);
			}
		}

		virtual public bool ExistContactMechanism
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ContactMechanism.RelationType);
			}
		}

		virtual public void RemoveContactMechanism()
		{
			Strategy.RemoveCompositeRole(Meta.ContactMechanism.RelationType);
		}


		virtual public Party Party
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.Party.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Party.RelationType, value);
			}
		}

		virtual public bool ExistParty
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Party.RelationType);
			}
		}

		virtual public void RemoveParty()
		{
			Strategy.RemoveCompositeRole(Meta.Party.RelationType);
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



		virtual public global::Allors.Extent<RequestVersion> RequestVersionsWhereRespondingParty
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestVersionsWhereRespondingParty.RelationType);
			}
		}

		virtual public bool ExistRequestVersionsWhereRespondingParty
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestVersionsWhereRespondingParty.RelationType);
			}
		}


		virtual public global::Allors.Extent<Request> RequestsWhereRespondingParty
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.RequestsWhereRespondingParty.RelationType);
			}
		}

		virtual public bool ExistRequestsWhereRespondingParty
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.RequestsWhereRespondingParty.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new RespondingPartyOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new RespondingPartyOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new RespondingPartyOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new RespondingPartyOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new RespondingPartyOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new RespondingPartyOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new RespondingPartyOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new RespondingPartyOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new RespondingPartyOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new RespondingPartyOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class RespondingPartyBuilder : Allors.ObjectBuilder<RespondingParty> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public RespondingPartyBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(RespondingParty instance)
		{
			

			if(this.SendingDate.HasValue)
			{
				instance.SendingDate = this.SendingDate.Value;
			}			
		
		

			instance.ContactMechanism = this.ContactMechanism;

		

			instance.Party = this.Party;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.DateTime? SendingDate {get; set;}

				/// <exclude/>
				public RespondingPartyBuilder WithSendingDate(global::System.DateTime? value)
		        {
				    if(this.SendingDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.SendingDate = value;
		            return this;
		        }	

				public ContactMechanism ContactMechanism {get; set;}

				/// <exclude/>
				public RespondingPartyBuilder WithContactMechanism(ContactMechanism value)
		        {
		            if(this.ContactMechanism!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ContactMechanism = value;
		            return this;
		        }		

				
				public Party Party {get; set;}

				/// <exclude/>
				public RespondingPartyBuilder WithParty(Party value)
		        {
		            if(this.Party!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Party = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public RespondingPartyBuilder WithDeniedPermission(Permission value)
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
				public RespondingPartyBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class RespondingParties : global::Allors.ObjectsBase<RespondingParty>
	{
		public RespondingParties(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaRespondingParty Meta
		{
			get
			{
				return Allors.Meta.MetaRespondingParty.Instance;
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