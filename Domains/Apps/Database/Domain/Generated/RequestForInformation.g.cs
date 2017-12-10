// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class RequestForInformation : Allors.IObject , Request, Versioned
	{
		private readonly IStrategy strategy;

		public RequestForInformation(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaRequestForInformation Meta
		{
			get
			{
				return Allors.Meta.MetaRequestForInformation.Instance;
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

		public static RequestForInformation Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (RequestForInformation) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public RequestForInformationVersion CurrentVersion
		{ 
			get
			{
				return (RequestForInformationVersion) Strategy.GetCompositeRole(Meta.CurrentVersion.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CurrentVersion.RelationType, value);
			}
		}

		virtual public bool ExistCurrentVersion
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CurrentVersion.RelationType);
			}
		}

		virtual public void RemoveCurrentVersion()
		{
			Strategy.RemoveCompositeRole(Meta.CurrentVersion.RelationType);
		}


		virtual public global::Allors.Extent<RequestForInformationVersion> AllVersions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.AllVersions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.AllVersions.RelationType, value);
			}
		}

		virtual public void AddAllVersion (RequestForInformationVersion value)
		{
			Strategy.AddCompositeRole(Meta.AllVersions.RelationType, value);
		}

		virtual public void RemoveAllVersion (RequestForInformationVersion value)
		{
			Strategy.RemoveCompositeRole(Meta.AllVersions.RelationType, value);
		}

		virtual public bool ExistAllVersions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.AllVersions.RelationType);
			}
		}

		virtual public void RemoveAllVersions()
		{
			Strategy.RemoveCompositeRoles(Meta.AllVersions.RelationType);
		}


		virtual public RequestState PreviousRequestState
		{ 
			get
			{
				return (RequestState) Strategy.GetCompositeRole(Meta.PreviousRequestState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PreviousRequestState.RelationType, value);
			}
		}

		virtual public bool ExistPreviousRequestState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PreviousRequestState.RelationType);
			}
		}

		virtual public void RemovePreviousRequestState()
		{
			Strategy.RemoveCompositeRole(Meta.PreviousRequestState.RelationType);
		}


		virtual public RequestState LastRequestState
		{ 
			get
			{
				return (RequestState) Strategy.GetCompositeRole(Meta.LastRequestState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.LastRequestState.RelationType, value);
			}
		}

		virtual public bool ExistLastRequestState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.LastRequestState.RelationType);
			}
		}

		virtual public void RemoveLastRequestState()
		{
			Strategy.RemoveCompositeRole(Meta.LastRequestState.RelationType);
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


		virtual public Person ContactPerson
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.ContactPerson.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ContactPerson.RelationType, value);
			}
		}

		virtual public bool ExistContactPerson
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ContactPerson.RelationType);
			}
		}

		virtual public void RemoveContactPerson()
		{
			Strategy.RemoveCompositeRole(Meta.ContactPerson.RelationType);
		}


		virtual public global::Allors.Extent<ObjectState> PreviousObjectStates
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.PreviousObjectStates.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PreviousObjectStates.RelationType, value);
			}
		}

		virtual public void AddPreviousObjectState (ObjectState value)
		{
			Strategy.AddCompositeRole(Meta.PreviousObjectStates.RelationType, value);
		}

		virtual public void RemovePreviousObjectState (ObjectState value)
		{
			Strategy.RemoveCompositeRole(Meta.PreviousObjectStates.RelationType, value);
		}

		virtual public bool ExistPreviousObjectStates
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PreviousObjectStates.RelationType);
			}
		}

		virtual public void RemovePreviousObjectStates()
		{
			Strategy.RemoveCompositeRoles(Meta.PreviousObjectStates.RelationType);
		}


		virtual public global::Allors.Extent<ObjectState> LastObjectStates
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.LastObjectStates.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.LastObjectStates.RelationType, value);
			}
		}

		virtual public void AddLastObjectState (ObjectState value)
		{
			Strategy.AddCompositeRole(Meta.LastObjectStates.RelationType, value);
		}

		virtual public void RemoveLastObjectState (ObjectState value)
		{
			Strategy.RemoveCompositeRole(Meta.LastObjectStates.RelationType, value);
		}

		virtual public bool ExistLastObjectStates
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.LastObjectStates.RelationType);
			}
		}

		virtual public void RemoveLastObjectStates()
		{
			Strategy.RemoveCompositeRoles(Meta.LastObjectStates.RelationType);
		}


		virtual public global::Allors.Extent<ObjectState> ObjectStates
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.ObjectStates.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.ObjectStates.RelationType, value);
			}
		}

		virtual public void AddObjectState (ObjectState value)
		{
			Strategy.AddCompositeRole(Meta.ObjectStates.RelationType, value);
		}

		virtual public void RemoveObjectState (ObjectState value)
		{
			Strategy.RemoveCompositeRole(Meta.ObjectStates.RelationType, value);
		}

		virtual public bool ExistObjectStates
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.ObjectStates.RelationType);
			}
		}

		virtual public void RemoveObjectStates()
		{
			Strategy.RemoveCompositeRoles(Meta.ObjectStates.RelationType);
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


		virtual public User CreatedBy
		{ 
			get
			{
				return (User) Strategy.GetCompositeRole(Meta.CreatedBy.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CreatedBy.RelationType, value);
			}
		}

		virtual public bool ExistCreatedBy
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CreatedBy.RelationType);
			}
		}

		virtual public void RemoveCreatedBy()
		{
			Strategy.RemoveCompositeRole(Meta.CreatedBy.RelationType);
		}


		virtual public User LastModifiedBy
		{ 
			get
			{
				return (User) Strategy.GetCompositeRole(Meta.LastModifiedBy.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.LastModifiedBy.RelationType, value);
			}
		}

		virtual public bool ExistLastModifiedBy
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.LastModifiedBy.RelationType);
			}
		}

		virtual public void RemoveLastModifiedBy()
		{
			Strategy.RemoveCompositeRole(Meta.LastModifiedBy.RelationType);
		}


		virtual public global::System.DateTime? CreationDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.CreationDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.CreationDate.RelationType, value);
			}
		}

		virtual public bool ExistCreationDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.CreationDate.RelationType);
			}
		}

		virtual public void RemoveCreationDate()
		{
			Strategy.RemoveUnitRole(Meta.CreationDate.RelationType);
		}


		virtual public global::System.DateTime? LastModifiedDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.LastModifiedDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.LastModifiedDate.RelationType, value);
			}
		}

		virtual public bool ExistLastModifiedDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.LastModifiedDate.RelationType);
			}
		}

		virtual public void RemoveLastModifiedDate()
		{
			Strategy.RemoveUnitRole(Meta.LastModifiedDate.RelationType);
		}


		virtual public global::System.String PrintContent 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.PrintContent.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.PrintContent.RelationType, value);
			}
		}

		virtual public bool ExistPrintContent{
			get
			{
				return Strategy.ExistUnitRole(Meta.PrintContent.RelationType);
			}
		}

		virtual public void RemovePrintContent()
		{
			Strategy.RemoveUnitRole(Meta.PrintContent.RelationType);
		}



		virtual public global::Allors.Extent<QuoteVersion> QuoteVersionsWhereRequest
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.QuoteVersionsWhereRequest.RelationType);
			}
		}

		virtual public bool ExistQuoteVersionsWhereRequest
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.QuoteVersionsWhereRequest.RelationType);
			}
		}


		virtual public Quote QuoteWhereRequest
		{ 
			get
			{
				return (Quote) Strategy.GetCompositeAssociation(Meta.QuoteWhereRequest.RelationType);
			}
		} 

		virtual public bool ExistQuoteWhereRequest
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.QuoteWhereRequest.RelationType);
			}
		}



		public RequestCancel Cancel()
		{ 
			var method = new RequestForInformationCancel(this);
            method.Execute();
            return method;
		}

		public RequestCancel Cancel(System.Action<RequestCancel> action)
		{ 
			var method = new RequestForInformationCancel(this);
            action(method);
            method.Execute();
            return method;
		}

		public RequestReject Reject()
		{ 
			var method = new RequestForInformationReject(this);
            method.Execute();
            return method;
		}

		public RequestReject Reject(System.Action<RequestReject> action)
		{ 
			var method = new RequestForInformationReject(this);
            action(method);
            method.Execute();
            return method;
		}

		public RequestSubmit Submit()
		{ 
			var method = new RequestForInformationSubmit(this);
            method.Execute();
            return method;
		}

		public RequestSubmit Submit(System.Action<RequestSubmit> action)
		{ 
			var method = new RequestForInformationSubmit(this);
            action(method);
            method.Execute();
            return method;
		}

		public RequestHold Hold()
		{ 
			var method = new RequestForInformationHold(this);
            method.Execute();
            return method;
		}

		public RequestHold Hold(System.Action<RequestHold> action)
		{ 
			var method = new RequestForInformationHold(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild()
		{ 
			var method = new RequestForInformationOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new RequestForInformationOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new RequestForInformationOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new RequestForInformationOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new RequestForInformationOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new RequestForInformationOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new RequestForInformationOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new RequestForInformationOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new RequestForInformationOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new RequestForInformationOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class RequestForInformationBuilder : Allors.ObjectBuilder<RequestForInformation> , RequestBuilder, VersionedBuilder, global::System.IDisposable
	{		
		public RequestForInformationBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(RequestForInformation instance)
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
		
		

			instance.Comment = this.Comment;
		
		
			

			if(this.CreationDate.HasValue)
			{
				instance.CreationDate = this.CreationDate.Value;
			}			
		
		
			

			if(this.LastModifiedDate.HasValue)
			{
				instance.LastModifiedDate = this.LastModifiedDate.Value;
			}			
		
		

			instance.PrintContent = this.PrintContent;
		
		

			instance.CurrentVersion = this.CurrentVersion;

		
			if(this.AllVersions!=null)
			{
				instance.AllVersions = this.AllVersions.ToArray();
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

		

			instance.ContactPerson = this.ContactPerson;

								
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		

			instance.CreatedBy = this.CreatedBy;

		

			instance.LastModifiedBy = this.LastModifiedBy;

		
		}


				public RequestForInformationVersion CurrentVersion {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithCurrentVersion(RequestForInformationVersion value)
		        {
		            if(this.CurrentVersion!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CurrentVersion = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<RequestForInformationVersion> AllVersions {get; set;}	

				/// <exclude/>
				public RequestForInformationBuilder WithAllVersion(RequestForInformationVersion value)
		        {
					if(this.AllVersions == null)
					{
						this.AllVersions = new global::System.Collections.Generic.List<RequestForInformationVersion>(); 
					}
		            this.AllVersions.Add(value);
		            return this;
		        }		

				
				public RequestState RequestState {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithRequestState(RequestState value)
		        {
		            if(this.RequestState!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.RequestState = value;
		            return this;
		        }		

				
				public global::System.String InternalComment {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithInternalComment(global::System.String value)
		        {
				    if(this.InternalComment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.InternalComment = value;
		            return this;
		        }	

				public global::System.String Description {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.DateTime? RequestDate {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithRequestDate(global::System.DateTime? value)
		        {
				    if(this.RequestDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RequestDate = value;
		            return this;
		        }	

				public global::System.DateTime? RequiredResponseDate {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithRequiredResponseDate(global::System.DateTime? value)
		        {
				    if(this.RequiredResponseDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RequiredResponseDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<RequestItem> RequestItems {get; set;}	

				/// <exclude/>
				public RequestForInformationBuilder WithRequestItem(RequestItem value)
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
				public RequestForInformationBuilder WithRequestNumber(global::System.String value)
		        {
				    if(this.RequestNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RequestNumber = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<RespondingParty> RespondingParties {get; set;}	

				/// <exclude/>
				public RequestForInformationBuilder WithRespondingParty(RespondingParty value)
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
				public RequestForInformationBuilder WithOriginator(Party value)
		        {
		            if(this.Originator!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Originator = value;
		            return this;
		        }		

				
				public Currency Currency {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithCurrency(Currency value)
		        {
		            if(this.Currency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Currency = value;
		            return this;
		        }		

				
				public ContactMechanism FullfillContactMechanism {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithFullfillContactMechanism(ContactMechanism value)
		        {
		            if(this.FullfillContactMechanism!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.FullfillContactMechanism = value;
		            return this;
		        }		

				
				public global::System.String EmailAddress {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithEmailAddress(global::System.String value)
		        {
				    if(this.EmailAddress!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EmailAddress = value;
		            return this;
		        }	

				public global::System.String TelephoneNumber {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithTelephoneNumber(global::System.String value)
		        {
				    if(this.TelephoneNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.TelephoneNumber = value;
		            return this;
		        }	

				public global::System.String TelephoneCountryCode {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithTelephoneCountryCode(global::System.String value)
		        {
				    if(this.TelephoneCountryCode!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.TelephoneCountryCode = value;
		            return this;
		        }	

				public Person ContactPerson {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithContactPerson(Person value)
		        {
		            if(this.ContactPerson!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ContactPerson = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public RequestForInformationBuilder WithDeniedPermission(Permission value)
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
				public RequestForInformationBuilder WithSecurityToken(SecurityToken value)
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
				public RequestForInformationBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	

				public User CreatedBy {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithCreatedBy(User value)
		        {
		            if(this.CreatedBy!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CreatedBy = value;
		            return this;
		        }		

				
				public User LastModifiedBy {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithLastModifiedBy(User value)
		        {
		            if(this.LastModifiedBy!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.LastModifiedBy = value;
		            return this;
		        }		

				
				public global::System.DateTime? CreationDate {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithCreationDate(global::System.DateTime? value)
		        {
				    if(this.CreationDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.CreationDate = value;
		            return this;
		        }	

				public global::System.DateTime? LastModifiedDate {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithLastModifiedDate(global::System.DateTime? value)
		        {
				    if(this.LastModifiedDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.LastModifiedDate = value;
		            return this;
		        }	

				public global::System.String PrintContent {get; set;}

				/// <exclude/>
				public RequestForInformationBuilder WithPrintContent(global::System.String value)
		        {
				    if(this.PrintContent!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.PrintContent = value;
		            return this;
		        }	


	}

	public partial class RequestsForInformation : global::Allors.ObjectsBase<RequestForInformation>
	{
		public RequestsForInformation(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaRequestForInformation Meta
		{
			get
			{
				return Allors.Meta.MetaRequestForInformation.Instance;
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