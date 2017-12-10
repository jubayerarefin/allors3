// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class PackageRevenue : Allors.IObject , Deletable, AccessControlledObject
	{
		private readonly IStrategy strategy;

		public PackageRevenue(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPackageRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaPackageRevenue.Instance;
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

		public static PackageRevenue Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (PackageRevenue) allorsSession.Instantiate(allorsObjectId);		
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


		virtual public global::System.String PackageName 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.PackageName.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.PackageName.RelationType, value);
			}
		}

		virtual public bool ExistPackageName{
			get
			{
				return Strategy.ExistUnitRole(Meta.PackageName.RelationType);
			}
		}

		virtual public void RemovePackageName()
		{
			Strategy.RemoveUnitRole(Meta.PackageName.RelationType);
		}


		virtual public Package Package
		{ 
			get
			{
				return (Package) Strategy.GetCompositeRole(Meta.Package.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Package.RelationType, value);
			}
		}

		virtual public bool ExistPackage
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Package.RelationType);
			}
		}

		virtual public void RemovePackage()
		{
			Strategy.RemoveCompositeRole(Meta.Package.RelationType);
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



		public DeletableDelete Delete()
		{ 
			var method = new PackageRevenueDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new PackageRevenueDelete(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild()
		{ 
			var method = new PackageRevenueOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PackageRevenueOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PackageRevenueOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PackageRevenueOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PackageRevenueOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PackageRevenueOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PackageRevenueOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PackageRevenueOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PackageRevenueOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PackageRevenueOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PackageRevenueBuilder : Allors.ObjectBuilder<PackageRevenue> , DeletableBuilder, AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public PackageRevenueBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(PackageRevenue instance)
		{
			

			if(this.Revenue.HasValue)
			{
				instance.Revenue = this.Revenue.Value;
			}			
		
		
			

			if(this.Year.HasValue)
			{
				instance.Year = this.Year.Value;
			}			
		
		
			

			if(this.Month.HasValue)
			{
				instance.Month = this.Month.Value;
			}			
		
		

			instance.PackageName = this.PackageName;
		
		

			instance.Currency = this.Currency;

		

			instance.Package = this.Package;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Decimal? Revenue {get; set;}

				/// <exclude/>
				public PackageRevenueBuilder WithRevenue(global::System.Decimal? value)
		        {
				    if(this.Revenue!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Revenue = value;
		            return this;
		        }	

				public global::System.Int32? Year {get; set;}

				/// <exclude/>
				public PackageRevenueBuilder WithYear(global::System.Int32? value)
		        {
				    if(this.Year!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Year = value;
		            return this;
		        }	

				public global::System.Int32? Month {get; set;}

				/// <exclude/>
				public PackageRevenueBuilder WithMonth(global::System.Int32? value)
		        {
				    if(this.Month!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Month = value;
		            return this;
		        }	

				public Currency Currency {get; set;}

				/// <exclude/>
				public PackageRevenueBuilder WithCurrency(Currency value)
		        {
		            if(this.Currency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Currency = value;
		            return this;
		        }		

				
				public global::System.String PackageName {get; set;}

				/// <exclude/>
				public PackageRevenueBuilder WithPackageName(global::System.String value)
		        {
				    if(this.PackageName!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.PackageName = value;
		            return this;
		        }	

				public Package Package {get; set;}

				/// <exclude/>
				public PackageRevenueBuilder WithPackage(Package value)
		        {
		            if(this.Package!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Package = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PackageRevenueBuilder WithDeniedPermission(Permission value)
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
				public PackageRevenueBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class PackageRevenues : global::Allors.ObjectsBase<PackageRevenue>
	{
		public PackageRevenues(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPackageRevenue Meta
		{
			get
			{
				return Allors.Meta.MetaPackageRevenue.Instance;
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