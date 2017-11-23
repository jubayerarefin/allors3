// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class RequestForQuoteVersion : Allors.IObject , RequestVersion
	{
		private readonly IStrategy strategy;

		public RequestForQuoteVersion(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaRequestForQuoteVersion Meta
		{
			get
			{
				return Allors.Meta.MetaRequestForQuoteVersion.Instance;
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

		public static RequestForQuoteVersion Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (RequestForQuoteVersion) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public RequestState RequestState
		{ 
			get
			{
				return (RequestState) Strategy.GetCompositeRole(Meta.RequestState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.RequestState.RelationType, value);
			}
		}

		virtual public bool ExistRequestState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.RequestState.RelationType);
			}
		}

		virtual public void RemoveRequestState()
		{
			Strategy.RemoveCompositeRole(Meta.RequestState.RelationType);
		}


		virtual public global::System.String InternalComment 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.InternalComment.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.InternalComment.RelationType, value);
			}
		}

		virtual public bool ExistInternalComment{
			get
			{
				return Strategy.ExistUnitRole(Meta.InternalComment.RelationType);
			}
		}

		virtual public void RemoveInternalComment()
		{
			Strategy.RemoveUnitRole(Meta.InternalComment.RelationType);
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


		virtual public global::System.DateTime RequestDate 
		{
			get
			{
				return (global::System.DateTime) Strategy.GetUnitRole(Meta.RequestDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.RequestDate.RelationType, value);
			}
		}

		virtual public bool ExistRequestDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.RequestDate.RelationType);
			}
		}

		virtual public void RemoveRequestDate()
		{
			Strategy.RemoveUnitRole(Meta.RequestDate.RelationType);
		}


		virtual public global::System.DateTime? RequiredResponseDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.RequiredResponseDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.RequiredResponseDate.RelationType, value);
			}
		}

		virtual public bool ExistRequiredResponseDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.RequiredResponseDate.RelationType);
			}
		}

		virtual public void RemoveRequiredResponseDate()
		{
			Strategy.RemoveUnitRole(Meta.RequiredResponseDate.RelationType);
		}


		virtual public global::Allors.Extent<RequestItem> RequestItems
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.RequestItems.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.RequestItems.RelationType, value);
			}
		}

		virtual public void AddRequestItem (RequestItem value)
		{
			Strategy.AddCompositeRole(Meta.RequestItems.RelationType, value);
		}

		virtual public void RemoveRequestItem (RequestItem value)
		{
			Strategy.RemoveCompositeRole(Meta.RequestItems.RelationType, value);
		}

		virtual public bool ExistRequestItems
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.RequestItems.RelationType);
			}
		}

		virtual public void RemoveRequestItems()
		{
			Strategy.RemoveCompositeRoles(Meta.RequestItems.RelationType);
		}


		virtual public global::System.String RequestNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.RequestNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.RequestNumber.RelationType, value);
			}
		}

		virtual public bool ExistRequestNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.RequestNumber.RelationType);
			}
		}

		virtual public void RemoveRequestNumber()
		{
			Strategy.RemoveUnitRole(Meta.RequestNumber.RelationType);
		}


		virtual public global::Allors.Extent<RespondingParty> RespondingParties
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.RespondingParties.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.RespondingParties.RelationType, value);
			}
		}

		virtual public void AddRespondingParty (RespondingParty value)
		{
			Strategy.AddCompositeRole(Meta.RespondingParties.RelationType, value);
		}

		virtual public void RemoveRespondingParty (RespondingParty value)
		{
			Strategy.RemoveCompositeRole(Meta.RespondingParties.RelationType, value);
		}

		virtual public bool ExistRespondingParties
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.RespondingParties.RelationType);
			}
		}

		virtual public void RemoveRespondingParties()
		{
			Strategy.RemoveCompositeRoles(Meta.RespondingParties.RelationType);
		}


		virtual public Party Originator
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.Originator.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Originator.RelationType, value);
			}
		}

		virtual public bool ExistOriginator
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Originator.RelationType);
			}
		}

		virtual public void RemoveOriginator()
		{
			Strategy.RemoveCompositeRole(Meta.Originator.RelationType);
		}


		virtual public Currency Currency
		{ 
			get
			{
				return (Currency) Strategy.GetCompositeRole(Meta.Currency.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Currency.RelationType, value);
			}
		}

		virtual public bool ExistCurrency
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Currency.RelationType);
			}
		}

		virtual public void RemoveCurrency()
		{
			Strategy.RemoveCompositeRole(Meta.Currency.RelationType);
		}


		virtual public ContactMechanism FullfillContactMechanism
		{ 
			get
			{
				return (ContactMechanism) Strategy.GetCompositeRole(Meta.FullfillContactMechanism.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.FullfillContactMechanism.RelationType, value);
			}
		}

		virtual public bool ExistFullfillContactMechanism
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.FullfillContactMechanism.RelationType);
			}
		}

		virtual public void RemoveFullfillContactMechanism()
		{
			Strategy.RemoveCompositeRole(Meta.FullfillContactMechanism.RelationType);
		}


		virtual public global::System.String EmailAddress 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.EmailAddress.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EmailAddress.RelationType, value);
			}
		}

		virtual public bool ExistEmailAddress{
			get
			{
				return Strategy.ExistUnitRole(Meta.EmailAddress.RelationType);
			}
		}

		virtual public void RemoveEmailAddress()
		{
			Strategy.RemoveUnitRole(Meta.EmailAddress.RelationType);
		}


		virtual public global::System.String TelephoneNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.TelephoneNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.TelephoneNumber.RelationType, value);
			}
		}

		virtual public bool ExistTelephoneNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.TelephoneNumber.RelationType);
			}
		}

		virtual public void RemoveTelephoneNumber()
		{
			Strategy.RemoveUnitRole(Meta.TelephoneNumber.RelationType);
		}


		virtual public global::System.String TelephoneCountryCode 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.TelephoneCountryCode.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.TelephoneCountryCode.RelationType, value);
			}
		}

		virtual public bool ExistTelephoneCountryCode{
			get
			{
				return Strategy.ExistUnitRole(Meta.TelephoneCountryCode.RelationType);
			}
		}

		virtual public void RemoveTelephoneCountryCode()
		{
			Strategy.RemoveUnitRole(Meta.TelephoneCountryCode.RelationType);
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



		virtual public RequestForQuote RequestForQuoteWhereCurrentVersion
		{ 
			get
			{
				return (RequestForQuote) Strategy.GetCompositeAssociation(Meta.RequestForQuoteWhereCurrentVersion.RelationType);
			}
		} 

		virtual public bool ExistRequestForQuoteWhereCurrentVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.RequestForQuoteWhereCurrentVersion.RelationType);
			}
		}


		virtual public RequestForQuote RequestForQuoteWhereAllVersion
		{ 
			get
			{
				return (RequestForQuote) Strategy.GetCompositeAssociation(Meta.RequestForQuoteWhereAllVersion.RelationType);
			}
		} 

		virtual public bool ExistRequestForQuoteWhereAllVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.RequestForQuoteWhereAllVersion.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new RequestForQuoteVersionOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new RequestForQuoteVersionOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new RequestForQuoteVersionOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new RequestForQuoteVersionOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new RequestForQuoteVersionOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new RequestForQuoteVersionOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new RequestForQuoteVersionOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new RequestForQuoteVersionOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new RequestForQuoteVersionOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new RequestForQuoteVersionOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class RequestForQuoteVersionBuilder : Allors.ObjectBuilder<RequestForQuoteVersion> , RequestVersionBuilder, global::System.IDisposable
	{		
		public RequestForQuoteVersionBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(RequestForQuoteVersion instance)
		{

			instance.InternalComment = this.InternalComment;
		
		

			instance.Description = this.Description;
		
		
			

			if(this.RequestDate.HasValue)
			{
				instance.RequestDate = this.RequestDate.Value;
			}			
		
		
			

			if(this.RequiredResponseDate.HasValue)
			{
				instance.RequiredResponseDate = this.RequiredResponseDate.Value;
			}			
		
		

			instance.RequestNumber = this.RequestNumber;
		
		

			instance.EmailAddress = this.EmailAddress;
		
		

			instance.TelephoneNumber = this.TelephoneNumber;
		
		

			instance.TelephoneCountryCode = this.TelephoneCountryCode;
		
		
			

			if(this.DerivationId.HasValue)
			{
				instance.DerivationId = this.DerivationId.Value;
			}			
		
		
			

			if(this.DerivationTimeStamp.HasValue)
			{
				instance.DerivationTimeStamp = this.DerivationTimeStamp.Value;
			}			
		
		

			instance.RequestState = this.RequestState;

		
			if(this.RequestItems!=null)
			{
				instance.RequestItems = this.RequestItems.ToArray();
			}
		
			if(this.RespondingParties!=null)
			{
				instance.RespondingParties = this.RespondingParties.ToArray();
			}
		

			instance.Originator = this.Originator;

		

			instance.Currency = this.Currency;

		

			instance.FullfillContactMechanism = this.FullfillContactMechanism;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public RequestState RequestState {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithRequestState(RequestState value)
		        {
		            if(this.RequestState!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.RequestState = value;
		            return this;
		        }		

				
				public global::System.String InternalComment {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithInternalComment(global::System.String value)
		        {
				    if(this.InternalComment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.InternalComment = value;
		            return this;
		        }	

				public global::System.String Description {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.DateTime? RequestDate {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithRequestDate(global::System.DateTime? value)
		        {
				    if(this.RequestDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RequestDate = value;
		            return this;
		        }	

				public global::System.DateTime? RequiredResponseDate {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithRequiredResponseDate(global::System.DateTime? value)
		        {
				    if(this.RequiredResponseDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RequiredResponseDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<RequestItem> RequestItems {get; set;}	

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithRequestItem(RequestItem value)
		        {
					if(this.RequestItems == null)
					{
						this.RequestItems = new global::System.Collections.Generic.List<RequestItem>(); 
					}
		            this.RequestItems.Add(value);
		            return this;
		        }		

				
				public global::System.String RequestNumber {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithRequestNumber(global::System.String value)
		        {
				    if(this.RequestNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RequestNumber = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<RespondingParty> RespondingParties {get; set;}	

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithRespondingParty(RespondingParty value)
		        {
					if(this.RespondingParties == null)
					{
						this.RespondingParties = new global::System.Collections.Generic.List<RespondingParty>(); 
					}
		            this.RespondingParties.Add(value);
		            return this;
		        }		

				
				public Party Originator {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithOriginator(Party value)
		        {
		            if(this.Originator!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Originator = value;
		            return this;
		        }		

				
				public Currency Currency {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithCurrency(Currency value)
		        {
		            if(this.Currency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Currency = value;
		            return this;
		        }		

				
				public ContactMechanism FullfillContactMechanism {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithFullfillContactMechanism(ContactMechanism value)
		        {
		            if(this.FullfillContactMechanism!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.FullfillContactMechanism = value;
		            return this;
		        }		

				
				public global::System.String EmailAddress {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithEmailAddress(global::System.String value)
		        {
				    if(this.EmailAddress!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EmailAddress = value;
		            return this;
		        }	

				public global::System.String TelephoneNumber {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithTelephoneNumber(global::System.String value)
		        {
				    if(this.TelephoneNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.TelephoneNumber = value;
		            return this;
		        }	

				public global::System.String TelephoneCountryCode {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithTelephoneCountryCode(global::System.String value)
		        {
				    if(this.TelephoneCountryCode!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.TelephoneCountryCode = value;
		            return this;
		        }	

				public global::System.Guid? DerivationId {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithDerivationId(global::System.Guid? value)
		        {
				    if(this.DerivationId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationId = value;
		            return this;
		        }	

				public global::System.DateTime? DerivationTimeStamp {get; set;}

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithDerivationTimeStamp(global::System.DateTime? value)
		        {
				    if(this.DerivationTimeStamp!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationTimeStamp = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public RequestForQuoteVersionBuilder WithDeniedPermission(Permission value)
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
				public RequestForQuoteVersionBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class RequestForQuoteVersions : global::Allors.ObjectsBase<RequestForQuoteVersion>
	{
		public RequestForQuoteVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaRequestForQuoteVersion Meta
		{
			get
			{
				return Allors.Meta.MetaRequestForQuoteVersion.Instance;
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