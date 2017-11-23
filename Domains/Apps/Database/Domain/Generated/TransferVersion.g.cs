// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class TransferVersion : Allors.IObject , ShipmentVersion
	{
		private readonly IStrategy strategy;

		public TransferVersion(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaTransferVersion Meta
		{
			get
			{
				return Allors.Meta.MetaTransferVersion.Instance;
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

		public static TransferVersion Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (TransferVersion) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public TransferState TransferState
		{ 
			get
			{
				return (TransferState) Strategy.GetCompositeRole(Meta.TransferState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.TransferState.RelationType, value);
			}
		}

		virtual public bool ExistTransferState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.TransferState.RelationType);
			}
		}

		virtual public void RemoveTransferState()
		{
			Strategy.RemoveCompositeRole(Meta.TransferState.RelationType);
		}


		virtual public ShipmentMethod ShipmentMethod
		{ 
			get
			{
				return (ShipmentMethod) Strategy.GetCompositeRole(Meta.ShipmentMethod.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ShipmentMethod.RelationType, value);
			}
		}

		virtual public bool ExistShipmentMethod
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ShipmentMethod.RelationType);
			}
		}

		virtual public void RemoveShipmentMethod()
		{
			Strategy.RemoveCompositeRole(Meta.ShipmentMethod.RelationType);
		}


		virtual public ContactMechanism BillToContactMechanism
		{ 
			get
			{
				return (ContactMechanism) Strategy.GetCompositeRole(Meta.BillToContactMechanism.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.BillToContactMechanism.RelationType, value);
			}
		}

		virtual public bool ExistBillToContactMechanism
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.BillToContactMechanism.RelationType);
			}
		}

		virtual public void RemoveBillToContactMechanism()
		{
			Strategy.RemoveCompositeRole(Meta.BillToContactMechanism.RelationType);
		}


		virtual public global::Allors.Extent<ShipmentPackage> ShipmentPackages
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.ShipmentPackages.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.ShipmentPackages.RelationType, value);
			}
		}

		virtual public void AddShipmentPackage (ShipmentPackage value)
		{
			Strategy.AddCompositeRole(Meta.ShipmentPackages.RelationType, value);
		}

		virtual public void RemoveShipmentPackage (ShipmentPackage value)
		{
			Strategy.RemoveCompositeRole(Meta.ShipmentPackages.RelationType, value);
		}

		virtual public bool ExistShipmentPackages
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.ShipmentPackages.RelationType);
			}
		}

		virtual public void RemoveShipmentPackages()
		{
			Strategy.RemoveCompositeRoles(Meta.ShipmentPackages.RelationType);
		}


		virtual public global::System.String ShipmentNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.ShipmentNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ShipmentNumber.RelationType, value);
			}
		}

		virtual public bool ExistShipmentNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.ShipmentNumber.RelationType);
			}
		}

		virtual public void RemoveShipmentNumber()
		{
			Strategy.RemoveUnitRole(Meta.ShipmentNumber.RelationType);
		}


		virtual public global::Allors.Extent<Document> Documents
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Documents.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Documents.RelationType, value);
			}
		}

		virtual public void AddDocument (Document value)
		{
			Strategy.AddCompositeRole(Meta.Documents.RelationType, value);
		}

		virtual public void RemoveDocument (Document value)
		{
			Strategy.RemoveCompositeRole(Meta.Documents.RelationType, value);
		}

		virtual public bool ExistDocuments
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Documents.RelationType);
			}
		}

		virtual public void RemoveDocuments()
		{
			Strategy.RemoveCompositeRoles(Meta.Documents.RelationType);
		}


		virtual public Party BillToParty
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.BillToParty.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.BillToParty.RelationType, value);
			}
		}

		virtual public bool ExistBillToParty
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.BillToParty.RelationType);
			}
		}

		virtual public void RemoveBillToParty()
		{
			Strategy.RemoveCompositeRole(Meta.BillToParty.RelationType);
		}


		virtual public Party ShipToParty
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.ShipToParty.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ShipToParty.RelationType, value);
			}
		}

		virtual public bool ExistShipToParty
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ShipToParty.RelationType);
			}
		}

		virtual public void RemoveShipToParty()
		{
			Strategy.RemoveCompositeRole(Meta.ShipToParty.RelationType);
		}


		virtual public global::Allors.Extent<ShipmentItem> ShipmentItems
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.ShipmentItems.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.ShipmentItems.RelationType, value);
			}
		}

		virtual public void AddShipmentItem (ShipmentItem value)
		{
			Strategy.AddCompositeRole(Meta.ShipmentItems.RelationType, value);
		}

		virtual public void RemoveShipmentItem (ShipmentItem value)
		{
			Strategy.RemoveCompositeRole(Meta.ShipmentItems.RelationType, value);
		}

		virtual public bool ExistShipmentItems
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.ShipmentItems.RelationType);
			}
		}

		virtual public void RemoveShipmentItems()
		{
			Strategy.RemoveCompositeRoles(Meta.ShipmentItems.RelationType);
		}


		virtual public ContactMechanism ReceiverContactMechanism
		{ 
			get
			{
				return (ContactMechanism) Strategy.GetCompositeRole(Meta.ReceiverContactMechanism.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ReceiverContactMechanism.RelationType, value);
			}
		}

		virtual public bool ExistReceiverContactMechanism
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ReceiverContactMechanism.RelationType);
			}
		}

		virtual public void RemoveReceiverContactMechanism()
		{
			Strategy.RemoveCompositeRole(Meta.ReceiverContactMechanism.RelationType);
		}


		virtual public PostalAddress ShipToAddress
		{ 
			get
			{
				return (PostalAddress) Strategy.GetCompositeRole(Meta.ShipToAddress.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ShipToAddress.RelationType, value);
			}
		}

		virtual public bool ExistShipToAddress
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ShipToAddress.RelationType);
			}
		}

		virtual public void RemoveShipToAddress()
		{
			Strategy.RemoveCompositeRole(Meta.ShipToAddress.RelationType);
		}


		virtual public global::System.Decimal? EstimatedShipCost 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.EstimatedShipCost.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedShipCost.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedShipCost{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedShipCost.RelationType);
			}
		}

		virtual public void RemoveEstimatedShipCost()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedShipCost.RelationType);
		}


		virtual public global::System.DateTime? EstimatedShipDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.EstimatedShipDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedShipDate.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedShipDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedShipDate.RelationType);
			}
		}

		virtual public void RemoveEstimatedShipDate()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedShipDate.RelationType);
		}


		virtual public global::System.DateTime? LatestCancelDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.LatestCancelDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.LatestCancelDate.RelationType, value);
			}
		}

		virtual public bool ExistLatestCancelDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.LatestCancelDate.RelationType);
			}
		}

		virtual public void RemoveLatestCancelDate()
		{
			Strategy.RemoveUnitRole(Meta.LatestCancelDate.RelationType);
		}


		virtual public Carrier Carrier
		{ 
			get
			{
				return (Carrier) Strategy.GetCompositeRole(Meta.Carrier.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Carrier.RelationType, value);
			}
		}

		virtual public bool ExistCarrier
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Carrier.RelationType);
			}
		}

		virtual public void RemoveCarrier()
		{
			Strategy.RemoveCompositeRole(Meta.Carrier.RelationType);
		}


		virtual public ContactMechanism InquireAboutContactMechanism
		{ 
			get
			{
				return (ContactMechanism) Strategy.GetCompositeRole(Meta.InquireAboutContactMechanism.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.InquireAboutContactMechanism.RelationType, value);
			}
		}

		virtual public bool ExistInquireAboutContactMechanism
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.InquireAboutContactMechanism.RelationType);
			}
		}

		virtual public void RemoveInquireAboutContactMechanism()
		{
			Strategy.RemoveCompositeRole(Meta.InquireAboutContactMechanism.RelationType);
		}


		virtual public global::System.DateTime? EstimatedReadyDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.EstimatedReadyDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedReadyDate.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedReadyDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedReadyDate.RelationType);
			}
		}

		virtual public void RemoveEstimatedReadyDate()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedReadyDate.RelationType);
		}


		virtual public PostalAddress ShipFromAddress
		{ 
			get
			{
				return (PostalAddress) Strategy.GetCompositeRole(Meta.ShipFromAddress.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ShipFromAddress.RelationType, value);
			}
		}

		virtual public bool ExistShipFromAddress
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ShipFromAddress.RelationType);
			}
		}

		virtual public void RemoveShipFromAddress()
		{
			Strategy.RemoveCompositeRole(Meta.ShipFromAddress.RelationType);
		}


		virtual public ContactMechanism BillFromContactMechanism
		{ 
			get
			{
				return (ContactMechanism) Strategy.GetCompositeRole(Meta.BillFromContactMechanism.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.BillFromContactMechanism.RelationType, value);
			}
		}

		virtual public bool ExistBillFromContactMechanism
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.BillFromContactMechanism.RelationType);
			}
		}

		virtual public void RemoveBillFromContactMechanism()
		{
			Strategy.RemoveCompositeRole(Meta.BillFromContactMechanism.RelationType);
		}


		virtual public global::System.String HandlingInstruction 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.HandlingInstruction.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.HandlingInstruction.RelationType, value);
			}
		}

		virtual public bool ExistHandlingInstruction{
			get
			{
				return Strategy.ExistUnitRole(Meta.HandlingInstruction.RelationType);
			}
		}

		virtual public void RemoveHandlingInstruction()
		{
			Strategy.RemoveUnitRole(Meta.HandlingInstruction.RelationType);
		}


		virtual public Store Store
		{ 
			get
			{
				return (Store) Strategy.GetCompositeRole(Meta.Store.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Store.RelationType, value);
			}
		}

		virtual public bool ExistStore
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Store.RelationType);
			}
		}

		virtual public void RemoveStore()
		{
			Strategy.RemoveCompositeRole(Meta.Store.RelationType);
		}


		virtual public Party ShipFromParty
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.ShipFromParty.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.ShipFromParty.RelationType, value);
			}
		}

		virtual public bool ExistShipFromParty
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.ShipFromParty.RelationType);
			}
		}

		virtual public void RemoveShipFromParty()
		{
			Strategy.RemoveCompositeRole(Meta.ShipFromParty.RelationType);
		}


		virtual public global::Allors.Extent<ShipmentRouteSegment> ShipmentRouteSegments
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.ShipmentRouteSegments.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.ShipmentRouteSegments.RelationType, value);
			}
		}

		virtual public void AddShipmentRouteSegment (ShipmentRouteSegment value)
		{
			Strategy.AddCompositeRole(Meta.ShipmentRouteSegments.RelationType, value);
		}

		virtual public void RemoveShipmentRouteSegment (ShipmentRouteSegment value)
		{
			Strategy.RemoveCompositeRole(Meta.ShipmentRouteSegments.RelationType, value);
		}

		virtual public bool ExistShipmentRouteSegments
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.ShipmentRouteSegments.RelationType);
			}
		}

		virtual public void RemoveShipmentRouteSegments()
		{
			Strategy.RemoveCompositeRoles(Meta.ShipmentRouteSegments.RelationType);
		}


		virtual public global::System.DateTime? EstimatedArrivalDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.EstimatedArrivalDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedArrivalDate.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedArrivalDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedArrivalDate.RelationType);
			}
		}

		virtual public void RemoveEstimatedArrivalDate()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedArrivalDate.RelationType);
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



		virtual public Transfer TransferWhereCurrentVersion
		{ 
			get
			{
				return (Transfer) Strategy.GetCompositeAssociation(Meta.TransferWhereCurrentVersion.RelationType);
			}
		} 

		virtual public bool ExistTransferWhereCurrentVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.TransferWhereCurrentVersion.RelationType);
			}
		}


		virtual public Transfer TransferWhereAllVersion
		{ 
			get
			{
				return (Transfer) Strategy.GetCompositeAssociation(Meta.TransferWhereAllVersion.RelationType);
			}
		} 

		virtual public bool ExistTransferWhereAllVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.TransferWhereAllVersion.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new TransferVersionOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new TransferVersionOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new TransferVersionOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new TransferVersionOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new TransferVersionOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new TransferVersionOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new TransferVersionOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new TransferVersionOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new TransferVersionOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new TransferVersionOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class TransferVersionBuilder : Allors.ObjectBuilder<TransferVersion> , ShipmentVersionBuilder, global::System.IDisposable
	{		
		public TransferVersionBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(TransferVersion instance)
		{

			instance.ShipmentNumber = this.ShipmentNumber;
		
		
			

			if(this.EstimatedShipCost.HasValue)
			{
				instance.EstimatedShipCost = this.EstimatedShipCost.Value;
			}			
		
		
			

			if(this.EstimatedShipDate.HasValue)
			{
				instance.EstimatedShipDate = this.EstimatedShipDate.Value;
			}			
		
		
			

			if(this.LatestCancelDate.HasValue)
			{
				instance.LatestCancelDate = this.LatestCancelDate.Value;
			}			
		
		
			

			if(this.EstimatedReadyDate.HasValue)
			{
				instance.EstimatedReadyDate = this.EstimatedReadyDate.Value;
			}			
		
		

			instance.HandlingInstruction = this.HandlingInstruction;
		
		
			

			if(this.EstimatedArrivalDate.HasValue)
			{
				instance.EstimatedArrivalDate = this.EstimatedArrivalDate.Value;
			}			
		
		
			

			if(this.DerivationId.HasValue)
			{
				instance.DerivationId = this.DerivationId.Value;
			}			
		
		
			

			if(this.DerivationTimeStamp.HasValue)
			{
				instance.DerivationTimeStamp = this.DerivationTimeStamp.Value;
			}			
		
		

			instance.TransferState = this.TransferState;

		

			instance.ShipmentMethod = this.ShipmentMethod;

		

			instance.BillToContactMechanism = this.BillToContactMechanism;

		
			if(this.ShipmentPackages!=null)
			{
				instance.ShipmentPackages = this.ShipmentPackages.ToArray();
			}
		
			if(this.Documents!=null)
			{
				instance.Documents = this.Documents.ToArray();
			}
		

			instance.BillToParty = this.BillToParty;

		

			instance.ShipToParty = this.ShipToParty;

		
			if(this.ShipmentItems!=null)
			{
				instance.ShipmentItems = this.ShipmentItems.ToArray();
			}
		

			instance.ReceiverContactMechanism = this.ReceiverContactMechanism;

		

			instance.ShipToAddress = this.ShipToAddress;

		

			instance.Carrier = this.Carrier;

		

			instance.InquireAboutContactMechanism = this.InquireAboutContactMechanism;

		

			instance.ShipFromAddress = this.ShipFromAddress;

				

			instance.Store = this.Store;

		

			instance.ShipFromParty = this.ShipFromParty;

		
			if(this.ShipmentRouteSegments!=null)
			{
				instance.ShipmentRouteSegments = this.ShipmentRouteSegments.ToArray();
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


				public TransferState TransferState {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithTransferState(TransferState value)
		        {
		            if(this.TransferState!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.TransferState = value;
		            return this;
		        }		

				
				public ShipmentMethod ShipmentMethod {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithShipmentMethod(ShipmentMethod value)
		        {
		            if(this.ShipmentMethod!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ShipmentMethod = value;
		            return this;
		        }		

				
				public ContactMechanism BillToContactMechanism {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithBillToContactMechanism(ContactMechanism value)
		        {
		            if(this.BillToContactMechanism!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.BillToContactMechanism = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<ShipmentPackage> ShipmentPackages {get; set;}	

				/// <exclude/>
				public TransferVersionBuilder WithShipmentPackage(ShipmentPackage value)
		        {
					if(this.ShipmentPackages == null)
					{
						this.ShipmentPackages = new global::System.Collections.Generic.List<ShipmentPackage>(); 
					}
		            this.ShipmentPackages.Add(value);
		            return this;
		        }		

				
				public global::System.String ShipmentNumber {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithShipmentNumber(global::System.String value)
		        {
				    if(this.ShipmentNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ShipmentNumber = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Document> Documents {get; set;}	

				/// <exclude/>
				public TransferVersionBuilder WithDocument(Document value)
		        {
					if(this.Documents == null)
					{
						this.Documents = new global::System.Collections.Generic.List<Document>(); 
					}
		            this.Documents.Add(value);
		            return this;
		        }		

				
				public Party BillToParty {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithBillToParty(Party value)
		        {
		            if(this.BillToParty!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.BillToParty = value;
		            return this;
		        }		

				
				public Party ShipToParty {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithShipToParty(Party value)
		        {
		            if(this.ShipToParty!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ShipToParty = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<ShipmentItem> ShipmentItems {get; set;}	

				/// <exclude/>
				public TransferVersionBuilder WithShipmentItem(ShipmentItem value)
		        {
					if(this.ShipmentItems == null)
					{
						this.ShipmentItems = new global::System.Collections.Generic.List<ShipmentItem>(); 
					}
		            this.ShipmentItems.Add(value);
		            return this;
		        }		

				
				public ContactMechanism ReceiverContactMechanism {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithReceiverContactMechanism(ContactMechanism value)
		        {
		            if(this.ReceiverContactMechanism!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ReceiverContactMechanism = value;
		            return this;
		        }		

				
				public PostalAddress ShipToAddress {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithShipToAddress(PostalAddress value)
		        {
		            if(this.ShipToAddress!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ShipToAddress = value;
		            return this;
		        }		

				
				public global::System.Decimal? EstimatedShipCost {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithEstimatedShipCost(global::System.Decimal? value)
		        {
				    if(this.EstimatedShipCost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedShipCost = value;
		            return this;
		        }	

				public global::System.DateTime? EstimatedShipDate {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithEstimatedShipDate(global::System.DateTime? value)
		        {
				    if(this.EstimatedShipDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedShipDate = value;
		            return this;
		        }	

				public global::System.DateTime? LatestCancelDate {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithLatestCancelDate(global::System.DateTime? value)
		        {
				    if(this.LatestCancelDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.LatestCancelDate = value;
		            return this;
		        }	

				public Carrier Carrier {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithCarrier(Carrier value)
		        {
		            if(this.Carrier!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Carrier = value;
		            return this;
		        }		

				
				public ContactMechanism InquireAboutContactMechanism {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithInquireAboutContactMechanism(ContactMechanism value)
		        {
		            if(this.InquireAboutContactMechanism!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.InquireAboutContactMechanism = value;
		            return this;
		        }		

				
				public global::System.DateTime? EstimatedReadyDate {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithEstimatedReadyDate(global::System.DateTime? value)
		        {
				    if(this.EstimatedReadyDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedReadyDate = value;
		            return this;
		        }	

				public PostalAddress ShipFromAddress {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithShipFromAddress(PostalAddress value)
		        {
		            if(this.ShipFromAddress!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ShipFromAddress = value;
		            return this;
		        }		

				
				public global::System.String HandlingInstruction {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithHandlingInstruction(global::System.String value)
		        {
				    if(this.HandlingInstruction!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.HandlingInstruction = value;
		            return this;
		        }	

				public Store Store {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithStore(Store value)
		        {
		            if(this.Store!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Store = value;
		            return this;
		        }		

				
				public Party ShipFromParty {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithShipFromParty(Party value)
		        {
		            if(this.ShipFromParty!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ShipFromParty = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<ShipmentRouteSegment> ShipmentRouteSegments {get; set;}	

				/// <exclude/>
				public TransferVersionBuilder WithShipmentRouteSegment(ShipmentRouteSegment value)
		        {
					if(this.ShipmentRouteSegments == null)
					{
						this.ShipmentRouteSegments = new global::System.Collections.Generic.List<ShipmentRouteSegment>(); 
					}
		            this.ShipmentRouteSegments.Add(value);
		            return this;
		        }		

				
				public global::System.DateTime? EstimatedArrivalDate {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithEstimatedArrivalDate(global::System.DateTime? value)
		        {
				    if(this.EstimatedArrivalDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedArrivalDate = value;
		            return this;
		        }	

				public global::System.Guid? DerivationId {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithDerivationId(global::System.Guid? value)
		        {
				    if(this.DerivationId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationId = value;
		            return this;
		        }	

				public global::System.DateTime? DerivationTimeStamp {get; set;}

				/// <exclude/>
				public TransferVersionBuilder WithDerivationTimeStamp(global::System.DateTime? value)
		        {
				    if(this.DerivationTimeStamp!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationTimeStamp = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public TransferVersionBuilder WithDeniedPermission(Permission value)
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
				public TransferVersionBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class TransferVersions : global::Allors.ObjectsBase<TransferVersion>
	{
		public TransferVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaTransferVersion Meta
		{
			get
			{
				return Allors.Meta.MetaTransferVersion.Instance;
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