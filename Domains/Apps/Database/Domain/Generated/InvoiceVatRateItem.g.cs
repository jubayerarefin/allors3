// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class InvoiceVatRateItem : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public InvoiceVatRateItem(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaInvoiceVatRateItem Meta
		{
			get
			{
				return Allors.Meta.MetaInvoiceVatRateItem.Instance;
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

		public static InvoiceVatRateItem Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (InvoiceVatRateItem) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Decimal? BaseAmount 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.BaseAmount.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.BaseAmount.RelationType, value);
			}
		}

		virtual public bool ExistBaseAmount{
			get
			{
				return Strategy.ExistUnitRole(Meta.BaseAmount.RelationType);
			}
		}

		virtual public void RemoveBaseAmount()
		{
			Strategy.RemoveUnitRole(Meta.BaseAmount.RelationType);
		}


		virtual public global::Allors.Extent<VatRate> VatRates
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.VatRates.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.VatRates.RelationType, value);
			}
		}

		virtual public void AddVatRate (VatRate value)
		{
			Strategy.AddCompositeRole(Meta.VatRates.RelationType, value);
		}

		virtual public void RemoveVatRate (VatRate value)
		{
			Strategy.RemoveCompositeRole(Meta.VatRates.RelationType, value);
		}

		virtual public bool ExistVatRates
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.VatRates.RelationType);
			}
		}

		virtual public void RemoveVatRates()
		{
			Strategy.RemoveCompositeRoles(Meta.VatRates.RelationType);
		}


		virtual public global::System.Decimal? VatAmount 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.VatAmount.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.VatAmount.RelationType, value);
			}
		}

		virtual public bool ExistVatAmount{
			get
			{
				return Strategy.ExistUnitRole(Meta.VatAmount.RelationType);
			}
		}

		virtual public void RemoveVatAmount()
		{
			Strategy.RemoveUnitRole(Meta.VatAmount.RelationType);
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



		virtual public global::Allors.Extent<InvoiceItemVersion> InvoiceItemVersionsWhereInvoiceVatRateItem
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.InvoiceItemVersionsWhereInvoiceVatRateItem.RelationType);
			}
		}

		virtual public bool ExistInvoiceItemVersionsWhereInvoiceVatRateItem
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.InvoiceItemVersionsWhereInvoiceVatRateItem.RelationType);
			}
		}


		virtual public InvoiceItem InvoiceItemWhereInvoiceVatRateItem
		{ 
			get
			{
				return (InvoiceItem) Strategy.GetCompositeAssociation(Meta.InvoiceItemWhereInvoiceVatRateItem.RelationType);
			}
		} 

		virtual public bool ExistInvoiceItemWhereInvoiceVatRateItem
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.InvoiceItemWhereInvoiceVatRateItem.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new InvoiceVatRateItemOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new InvoiceVatRateItemOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new InvoiceVatRateItemOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new InvoiceVatRateItemOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new InvoiceVatRateItemOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new InvoiceVatRateItemOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new InvoiceVatRateItemOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new InvoiceVatRateItemOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new InvoiceVatRateItemOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new InvoiceVatRateItemOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class InvoiceVatRateItemBuilder : Allors.ObjectBuilder<InvoiceVatRateItem> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public InvoiceVatRateItemBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(InvoiceVatRateItem instance)
		{
			

			if(this.BaseAmount.HasValue)
			{
				instance.BaseAmount = this.BaseAmount.Value;
			}			
		
		
			

			if(this.VatAmount.HasValue)
			{
				instance.VatAmount = this.VatAmount.Value;
			}			
		
		
			if(this.VatRates!=null)
			{
				instance.VatRates = this.VatRates.ToArray();
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


				public global::System.Decimal? BaseAmount {get; set;}

				/// <exclude/>
				public InvoiceVatRateItemBuilder WithBaseAmount(global::System.Decimal? value)
		        {
				    if(this.BaseAmount!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.BaseAmount = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<VatRate> VatRates {get; set;}	

				/// <exclude/>
				public InvoiceVatRateItemBuilder WithVatRate(VatRate value)
		        {
					if(this.VatRates == null)
					{
						this.VatRates = new global::System.Collections.Generic.List<VatRate>(); 
					}
		            this.VatRates.Add(value);
		            return this;
		        }		

				
				public global::System.Decimal? VatAmount {get; set;}

				/// <exclude/>
				public InvoiceVatRateItemBuilder WithVatAmount(global::System.Decimal? value)
		        {
				    if(this.VatAmount!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.VatAmount = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public InvoiceVatRateItemBuilder WithDeniedPermission(Permission value)
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
				public InvoiceVatRateItemBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class InvoiceVatRateItems : global::Allors.ObjectsBase<InvoiceVatRateItem>
	{
		public InvoiceVatRateItems(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaInvoiceVatRateItem Meta
		{
			get
			{
				return Allors.Meta.MetaInvoiceVatRateItem.Instance;
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