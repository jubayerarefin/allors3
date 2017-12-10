// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class VatReturnBox : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public VatReturnBox(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaVatReturnBox Meta
		{
			get
			{
				return Allors.Meta.MetaVatReturnBox.Instance;
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

		public static VatReturnBox Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (VatReturnBox) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.String HeaderNumber 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.HeaderNumber.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.HeaderNumber.RelationType, value);
			}
		}

		virtual public bool ExistHeaderNumber{
			get
			{
				return Strategy.ExistUnitRole(Meta.HeaderNumber.RelationType);
			}
		}

		virtual public void RemoveHeaderNumber()
		{
			Strategy.RemoveUnitRole(Meta.HeaderNumber.RelationType);
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



		virtual public VatForm VatFormWhereVatReturnBox
		{ 
			get
			{
				return (VatForm) Strategy.GetCompositeAssociation(Meta.VatFormWhereVatReturnBox.RelationType);
			}
		} 

		virtual public bool ExistVatFormWhereVatReturnBox
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.VatFormWhereVatReturnBox.RelationType);
			}
		}


		virtual public global::Allors.Extent<VatRate> VatRatesWhereVatReturnBox
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.VatRatesWhereVatReturnBox.RelationType);
			}
		}

		virtual public bool ExistVatRatesWhereVatReturnBox
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.VatRatesWhereVatReturnBox.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new VatReturnBoxOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new VatReturnBoxOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new VatReturnBoxOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new VatReturnBoxOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new VatReturnBoxOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new VatReturnBoxOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new VatReturnBoxOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new VatReturnBoxOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new VatReturnBoxOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new VatReturnBoxOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class VatReturnBoxBuilder : Allors.ObjectBuilder<VatReturnBox> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public VatReturnBoxBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(VatReturnBox instance)
		{

			instance.HeaderNumber = this.HeaderNumber;
		
		

			instance.Description = this.Description;
		
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.String HeaderNumber {get; set;}

				/// <exclude/>
				public VatReturnBoxBuilder WithHeaderNumber(global::System.String value)
		        {
				    if(this.HeaderNumber!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.HeaderNumber = value;
		            return this;
		        }	

				public global::System.String Description {get; set;}

				/// <exclude/>
				public VatReturnBoxBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public VatReturnBoxBuilder WithDeniedPermission(Permission value)
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
				public VatReturnBoxBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class VatReturnBoxes : global::Allors.ObjectsBase<VatReturnBox>
	{
		public VatReturnBoxes(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaVatReturnBox Meta
		{
			get
			{
				return Allors.Meta.MetaVatReturnBox.Instance;
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