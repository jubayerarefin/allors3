// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class PositionTypeRate : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public PositionTypeRate(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPositionTypeRate Meta
		{
			get
			{
				return Allors.Meta.MetaPositionTypeRate.Instance;
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

		public static PositionTypeRate Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (PositionTypeRate) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Decimal Rate 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Rate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Rate.RelationType, value);
			}
		}

		virtual public bool ExistRate{
			get
			{
				return Strategy.ExistUnitRole(Meta.Rate.RelationType);
			}
		}

		virtual public void RemoveRate()
		{
			Strategy.RemoveUnitRole(Meta.Rate.RelationType);
		}


		virtual public RateType RateType
		{ 
			get
			{
				return (RateType) Strategy.GetCompositeRole(Meta.RateType.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.RateType.RelationType, value);
			}
		}

		virtual public bool ExistRateType
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.RateType.RelationType);
			}
		}

		virtual public void RemoveRateType()
		{
			Strategy.RemoveCompositeRole(Meta.RateType.RelationType);
		}


		virtual public TimeFrequency TimeFrequency
		{ 
			get
			{
				return (TimeFrequency) Strategy.GetCompositeRole(Meta.TimeFrequency.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.TimeFrequency.RelationType, value);
			}
		}

		virtual public bool ExistTimeFrequency
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.TimeFrequency.RelationType);
			}
		}

		virtual public void RemoveTimeFrequency()
		{
			Strategy.RemoveCompositeRole(Meta.TimeFrequency.RelationType);
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



		virtual public global::Allors.Extent<PositionType> PositionTypesWherePositionTypeRate
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PositionTypesWherePositionTypeRate.RelationType);
			}
		}

		virtual public bool ExistPositionTypesWherePositionTypeRate
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PositionTypesWherePositionTypeRate.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new PositionTypeRateOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PositionTypeRateOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PositionTypeRateOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PositionTypeRateOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PositionTypeRateOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PositionTypeRateOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PositionTypeRateOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PositionTypeRateOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PositionTypeRateOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PositionTypeRateOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PositionTypeRateBuilder : Allors.ObjectBuilder<PositionTypeRate> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public PositionTypeRateBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(PositionTypeRate instance)
		{
			

			if(this.Rate.HasValue)
			{
				instance.Rate = this.Rate.Value;
			}			
		
		

			instance.RateType = this.RateType;

		

			instance.TimeFrequency = this.TimeFrequency;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Decimal? Rate {get; set;}

				/// <exclude/>
				public PositionTypeRateBuilder WithRate(global::System.Decimal? value)
		        {
				    if(this.Rate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Rate = value;
		            return this;
		        }	

				public RateType RateType {get; set;}

				/// <exclude/>
				public PositionTypeRateBuilder WithRateType(RateType value)
		        {
		            if(this.RateType!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.RateType = value;
		            return this;
		        }		

				
				public TimeFrequency TimeFrequency {get; set;}

				/// <exclude/>
				public PositionTypeRateBuilder WithTimeFrequency(TimeFrequency value)
		        {
		            if(this.TimeFrequency!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.TimeFrequency = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PositionTypeRateBuilder WithDeniedPermission(Permission value)
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
				public PositionTypeRateBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class PositionTypeRates : global::Allors.ObjectsBase<PositionTypeRate>
	{
		public PositionTypeRates(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPositionTypeRate Meta
		{
			get
			{
				return Allors.Meta.MetaPositionTypeRate.Instance;
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