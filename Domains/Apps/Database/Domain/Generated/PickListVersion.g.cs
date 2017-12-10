// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class PickListVersion : Allors.IObject , Version
	{
		private readonly IStrategy strategy;

		public PickListVersion(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPickListVersion Meta
		{
			get
			{
				return Allors.Meta.MetaPickListVersion.Instance;
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

		public static PickListVersion Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (PickListVersion) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public PickListState PickListState
		{ 
			get
			{
				return (PickListState) Strategy.GetCompositeRole(Meta.PickListState.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.PickListState.RelationType, value);
			}
		}

		virtual public bool ExistPickListState
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.PickListState.RelationType);
			}
		}

		virtual public void RemovePickListState()
		{
			Strategy.RemoveCompositeRole(Meta.PickListState.RelationType);
		}


		virtual public CustomerShipment CustomerShipmentCorrection
		{ 
			get
			{
				return (CustomerShipment) Strategy.GetCompositeRole(Meta.CustomerShipmentCorrection.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CustomerShipmentCorrection.RelationType, value);
			}
		}

		virtual public bool ExistCustomerShipmentCorrection
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CustomerShipmentCorrection.RelationType);
			}
		}

		virtual public void RemoveCustomerShipmentCorrection()
		{
			Strategy.RemoveCompositeRole(Meta.CustomerShipmentCorrection.RelationType);
		}


		virtual public global::System.DateTime CreationDate 
		{
			get
			{
				return (global::System.DateTime) Strategy.GetUnitRole(Meta.CreationDate.RelationType);
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


		virtual public global::Allors.Extent<PickListItem> PickListItems
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.PickListItems.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.PickListItems.RelationType, value);
			}
		}

		virtual public void AddPickListItem (PickListItem value)
		{
			Strategy.AddCompositeRole(Meta.PickListItems.RelationType, value);
		}

		virtual public void RemovePickListItem (PickListItem value)
		{
			Strategy.RemoveCompositeRole(Meta.PickListItems.RelationType, value);
		}

		virtual public bool ExistPickListItems
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.PickListItems.RelationType);
			}
		}

		virtual public void RemovePickListItems()
		{
			Strategy.RemoveCompositeRoles(Meta.PickListItems.RelationType);
		}


		virtual public Person Picker
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.Picker.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Picker.RelationType, value);
			}
		}

		virtual public bool ExistPicker
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Picker.RelationType);
			}
		}

		virtual public void RemovePicker()
		{
			Strategy.RemoveCompositeRole(Meta.Picker.RelationType);
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



		virtual public PickList PickListWhereCurrentVersion
		{ 
			get
			{
				return (PickList) Strategy.GetCompositeAssociation(Meta.PickListWhereCurrentVersion.RelationType);
			}
		} 

		virtual public bool ExistPickListWhereCurrentVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PickListWhereCurrentVersion.RelationType);
			}
		}


		virtual public PickList PickListWhereAllVersion
		{ 
			get
			{
				return (PickList) Strategy.GetCompositeAssociation(Meta.PickListWhereAllVersion.RelationType);
			}
		} 

		virtual public bool ExistPickListWhereAllVersion
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PickListWhereAllVersion.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new PickListVersionOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PickListVersionOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PickListVersionOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PickListVersionOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PickListVersionOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PickListVersionOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PickListVersionOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PickListVersionOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PickListVersionOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PickListVersionOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PickListVersionBuilder : Allors.ObjectBuilder<PickListVersion> , VersionBuilder, global::System.IDisposable
	{		
		public PickListVersionBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(PickListVersion instance)
		{
			

			if(this.CreationDate.HasValue)
			{
				instance.CreationDate = this.CreationDate.Value;
			}			
		
		
			

			if(this.DerivationId.HasValue)
			{
				instance.DerivationId = this.DerivationId.Value;
			}			
		
		
			

			if(this.DerivationTimeStamp.HasValue)
			{
				instance.DerivationTimeStamp = this.DerivationTimeStamp.Value;
			}			
		
		
		

			instance.CustomerShipmentCorrection = this.CustomerShipmentCorrection;

		
			if(this.PickListItems!=null)
			{
				instance.PickListItems = this.PickListItems.ToArray();
			}
		

			instance.Picker = this.Picker;

		

			instance.ShipToParty = this.ShipToParty;

		

			instance.Store = this.Store;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public CustomerShipment CustomerShipmentCorrection {get; set;}

				/// <exclude/>
				public PickListVersionBuilder WithCustomerShipmentCorrection(CustomerShipment value)
		        {
		            if(this.CustomerShipmentCorrection!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CustomerShipmentCorrection = value;
		            return this;
		        }		

				
				public global::System.DateTime? CreationDate {get; set;}

				/// <exclude/>
				public PickListVersionBuilder WithCreationDate(global::System.DateTime? value)
		        {
				    if(this.CreationDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.CreationDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<PickListItem> PickListItems {get; set;}	

				/// <exclude/>
				public PickListVersionBuilder WithPickListItem(PickListItem value)
		        {
					if(this.PickListItems == null)
					{
						this.PickListItems = new global::System.Collections.Generic.List<PickListItem>(); 
					}
		            this.PickListItems.Add(value);
		            return this;
		        }		

				
				public Person Picker {get; set;}

				/// <exclude/>
				public PickListVersionBuilder WithPicker(Person value)
		        {
		            if(this.Picker!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Picker = value;
		            return this;
		        }		

				
				public Party ShipToParty {get; set;}

				/// <exclude/>
				public PickListVersionBuilder WithShipToParty(Party value)
		        {
		            if(this.ShipToParty!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.ShipToParty = value;
		            return this;
		        }		

				
				public Store Store {get; set;}

				/// <exclude/>
				public PickListVersionBuilder WithStore(Store value)
		        {
		            if(this.Store!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Store = value;
		            return this;
		        }		

				
				public global::System.Guid? DerivationId {get; set;}

				/// <exclude/>
				public PickListVersionBuilder WithDerivationId(global::System.Guid? value)
		        {
				    if(this.DerivationId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationId = value;
		            return this;
		        }	

				public global::System.DateTime? DerivationTimeStamp {get; set;}

				/// <exclude/>
				public PickListVersionBuilder WithDerivationTimeStamp(global::System.DateTime? value)
		        {
				    if(this.DerivationTimeStamp!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DerivationTimeStamp = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PickListVersionBuilder WithDeniedPermission(Permission value)
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
				public PickListVersionBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class PickListVersions : global::Allors.ObjectsBase<PickListVersion>
	{
		public PickListVersions(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPickListVersion Meta
		{
			get
			{
				return Allors.Meta.MetaPickListVersion.Instance;
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