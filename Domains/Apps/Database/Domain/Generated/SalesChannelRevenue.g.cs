// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class SalesChannelRevenue : Allors.IObject , AccessControlledObject, Deletable
	{
		private readonly IStrategy strategy;

		public SalesChannelRevenue(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaSalesChannelRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaSalesChannelRevenue.Instance;
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

		public static SalesChannelRevenue Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (SalesChannelRevenue) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Int32 Year 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.Year.RelationType);
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


		virtual public global::System.Int32 Month 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.Month.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Month.RelationType, value);
			}
		}

		virtual public bool ExistMonth{
			get
			{
				return Strategy.ExistUnitRole(Meta.Month.RelationType);
			}
		}

		virtual public void RemoveMonth()
		{
			Strategy.RemoveUnitRole(Meta.Month.RelationType);
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


		virtual public SalesChannel SalesChannel
		{ 
			get
			{
				return (SalesChannel) Strategy.GetCompositeRole(Meta.SalesChannel.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.SalesChannel.RelationType, value);
			}
		}

		virtual public bool ExistSalesChannel
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.SalesChannel.RelationType);
			}
		}

		virtual public void RemoveSalesChannel()
		{
			Strategy.RemoveCompositeRole(Meta.SalesChannel.RelationType);
		}


		virtual public global::System.String SalesChannelName 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.SalesChannelName.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.SalesChannelName.RelationType, value);
			}
		}

		virtual public bool ExistSalesChannelName{
			get
			{
				return Strategy.ExistUnitRole(Meta.SalesChannelName.RelationType);
			}
		}

		virtual public void RemoveSalesChannelName()
		{
			Strategy.RemoveUnitRole(Meta.SalesChannelName.RelationType);
		}


		virtual public global::System.Decimal Revenue 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Revenue.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Revenue.RelationType, value);
			}
		}

		virtual public bool ExistRevenue{
			get
			{
				return Strategy.ExistUnitRole(Meta.Revenue.RelationType);
			}
		}

		virtual public void RemoveRevenue()
		{
			Strategy.RemoveUnitRole(Meta.Revenue.RelationType);
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



		public ObjectOnBuild OnBuild()
		{ 
			var method = new SalesChannelRevenueOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new SalesChannelRevenueOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new SalesChannelRevenueOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new SalesChannelRevenueOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new SalesChannelRevenueOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new SalesChannelRevenueOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new SalesChannelRevenueOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new SalesChannelRevenueOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new SalesChannelRevenueOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new SalesChannelRevenueOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new SalesChannelRevenueDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new SalesChannelRevenueDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class SalesChannelRevenueBuilder : Allors.ObjectBuilder<SalesChannelRevenue> , AccessControlledObjectBuilder, DeletableBuilder, global::System.IDisposable
	{		
		public SalesChannelRevenueBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(SalesChannelRevenue instance)
		{
			

			if(this.Year.HasValue)
			{
				instance.Year = this.Year.Value;
			}			
		
		
			

			if(this.Month.HasValue)
			{
				instance.Month = this.Month.Value;
			}			
		
		

			instance.SalesChannelName = this.SalesChannelName;
		
		
			

			if(this.Revenue.HasValue)
			{
				instance.Revenue = this.Revenue.Value;
			}			
		
		

			instance.Currency = this.Currency;

		

			instance.SalesChannel = this.SalesChannel;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Int32? Year {get; set;}

				/// <exclude/>
				public SalesChannelRevenueBuilder WithYear(global::System.Int32? value)
		        {
				    if(this.Year!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Year = value;
		            return this;
		        }	

				public global::System.Int32? Month {get; set;}

				/// <exclude/>
				public SalesChannelRevenueBuilder WithMonth(global::System.Int32? value)
		        {
				    if(this.Month!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Month = value;
		            return this;
		        }	

				public Currency Currency {get; set;}

				/// <exclude/>
				public SalesChannelRevenueBuilder WithCurrency(Currency value)
		        {
		            if(this.Currency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Currency = value;
		            return this;
		        }		

				
				public SalesChannel SalesChannel {get; set;}

				/// <exclude/>
				public SalesChannelRevenueBuilder WithSalesChannel(SalesChannel value)
		        {
		            if(this.SalesChannel!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.SalesChannel = value;
		            return this;
		        }		

				
				public global::System.String SalesChannelName {get; set;}

				/// <exclude/>
				public SalesChannelRevenueBuilder WithSalesChannelName(global::System.String value)
		        {
				    if(this.SalesChannelName!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.SalesChannelName = value;
		            return this;
		        }	

				public global::System.Decimal? Revenue {get; set;}

				/// <exclude/>
				public SalesChannelRevenueBuilder WithRevenue(global::System.Decimal? value)
		        {
				    if(this.Revenue!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Revenue = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public SalesChannelRevenueBuilder WithDeniedPermission(Permission value)
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
				public SalesChannelRevenueBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class SalesChannelRevenues : global::Allors.ObjectsBase<SalesChannelRevenue>
	{
		public SalesChannelRevenues(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaSalesChannelRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaSalesChannelRevenue.Instance;
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