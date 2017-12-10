// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class JournalEntryNumber : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public JournalEntryNumber(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaJournalEntryNumber Meta
		{
			get
			{
				return Allors.Meta.MetaJournalEntryNumber.Instance;
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

		public static JournalEntryNumber Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (JournalEntryNumber) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public JournalType JournalType
		{ 
			get
			{
				return (JournalType) Strategy.GetCompositeRole(Meta.JournalType.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.JournalType.RelationType, value);
			}
		}

		virtual public bool ExistJournalType
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.JournalType.RelationType);
			}
		}

		virtual public void RemoveJournalType()
		{
			Strategy.RemoveCompositeRole(Meta.JournalType.RelationType);
		}


		virtual public global::System.Int32? Number 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.Number.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Number.RelationType, value);
			}
		}

		virtual public bool ExistNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.Number.RelationType);
			}
		}

		virtual public void RemoveNumber()
		{
			Strategy.RemoveUnitRole(Meta.Number.RelationType);
		}


		virtual public global::System.Int32? Year 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.Year.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Year.RelationType, value);
			}
		}

		virtual public bool ExistYear{
			get
			{
				return Strategy.ExistUnitRole(Meta.Year.RelationType);
			}
		}

		virtual public void RemoveYear()
		{
			Strategy.RemoveUnitRole(Meta.Year.RelationType);
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



		virtual public InternalOrganisation InternalOrganisationWhereJournalEntryNumber
		{ 
			get
			{
				return (InternalOrganisation) Strategy.GetCompositeAssociation(Meta.InternalOrganisationWhereJournalEntryNumber.RelationType);
			}
		} 

		virtual public bool ExistInternalOrganisationWhereJournalEntryNumber
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.InternalOrganisationWhereJournalEntryNumber.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new JournalEntryNumberOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new JournalEntryNumberOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new JournalEntryNumberOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new JournalEntryNumberOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new JournalEntryNumberOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new JournalEntryNumberOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new JournalEntryNumberOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new JournalEntryNumberOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new JournalEntryNumberOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new JournalEntryNumberOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class JournalEntryNumberBuilder : Allors.ObjectBuilder<JournalEntryNumber> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public JournalEntryNumberBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(JournalEntryNumber instance)
		{
			

			if(this.Number.HasValue)
			{
				instance.Number = this.Number.Value;
			}			
		
		
			

			if(this.Year.HasValue)
			{
				instance.Year = this.Year.Value;
			}			
		
		

			instance.JournalType = this.JournalType;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public JournalType JournalType {get; set;}

				/// <exclude/>
				public JournalEntryNumberBuilder WithJournalType(JournalType value)
		        {
		            if(this.JournalType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.JournalType = value;
		            return this;
		        }		

				
				public global::System.Int32? Number {get; set;}

				/// <exclude/>
				public JournalEntryNumberBuilder WithNumber(global::System.Int32? value)
		        {
				    if(this.Number!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Number = value;
		            return this;
		        }	

				public global::System.Int32? Year {get; set;}

				/// <exclude/>
				public JournalEntryNumberBuilder WithYear(global::System.Int32? value)
		        {
				    if(this.Year!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Year = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public JournalEntryNumberBuilder WithDeniedPermission(Permission value)
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
				public JournalEntryNumberBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class JournalEntryNumbers : global::Allors.ObjectsBase<JournalEntryNumber>
	{
		public JournalEntryNumbers(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaJournalEntryNumber Meta
		{
			get
			{
				return Allors.Meta.MetaJournalEntryNumber.Instance;
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