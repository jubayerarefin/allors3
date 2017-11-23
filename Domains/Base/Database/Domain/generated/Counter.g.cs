// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Counter : Allors.IObject , UniquelyIdentifiable
	{
		private readonly IStrategy strategy;

		public Counter(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaCounter Meta
		{
			get
			{
				return Allors.Meta.MetaCounter.Instance;
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

		public static Counter Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Counter) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Int32 Value 
		{
			get
			{
				return (global::System.Int32) Strategy.GetUnitRole(Meta.Value.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Value.RelationType, value);
			}
		}

		virtual public bool ExistValue{
			get
			{
				return Strategy.ExistUnitRole(Meta.Value.RelationType);
			}
		}

		virtual public void RemoveValue()
		{
			Strategy.RemoveUnitRole(Meta.Value.RelationType);
		}


		virtual public global::System.Guid UniqueId 
		{
			get
			{
				return (global::System.Guid) Strategy.GetUnitRole(Meta.UniqueId.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.UniqueId.RelationType, value);
			}
		}

		virtual public bool ExistUniqueId{
			get
			{
				return Strategy.ExistUnitRole(Meta.UniqueId.RelationType);
			}
		}

		virtual public void RemoveUniqueId()
		{
			Strategy.RemoveUnitRole(Meta.UniqueId.RelationType);
		}



		virtual public global::Allors.Extent<Notification> NotificationsWhereTarget
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}

		virtual public bool ExistNotificationsWhereTarget
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new CounterOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new CounterOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new CounterOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new CounterOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new CounterOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new CounterOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new CounterOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new CounterOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new CounterOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new CounterOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class CounterBuilder : Allors.ObjectBuilder<Counter> , UniquelyIdentifiableBuilder, global::System.IDisposable
	{		
		public CounterBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Counter instance)
		{
			

			if(this.Value.HasValue)
			{
				instance.Value = this.Value.Value;
			}			
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
		}


				public global::System.Int32? Value {get; set;}

				/// <exclude/>
				public CounterBuilder WithValue(global::System.Int32? value)
		        {
				    if(this.Value!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Value = value;
		            return this;
		        }	

				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public CounterBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	


	}

	public partial class Counters : global::Allors.ObjectsBase<Counter>
	{
		public Counters(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaCounter Meta
		{
			get
			{
				return Allors.Meta.MetaCounter.Instance;
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