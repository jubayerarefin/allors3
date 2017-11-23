// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Event : Allors.IObject , Object
	{
		private readonly IStrategy strategy;

		public Event(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaEvent Meta
		{
			get
			{
				return Allors.Meta.MetaEvent.Instance;
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

		public static Event Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Event) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Boolean? RegistrationRequired 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.RegistrationRequired.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.RegistrationRequired.RelationType, value);
			}
		}

		virtual public bool ExistRegistrationRequired{
			get
			{
				return Strategy.ExistUnitRole(Meta.RegistrationRequired.RelationType);
			}
		}

		virtual public void RemoveRegistrationRequired()
		{
			Strategy.RemoveUnitRole(Meta.RegistrationRequired.RelationType);
		}


		virtual public global::System.String Link 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Link.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Link.RelationType, value);
			}
		}

		virtual public bool ExistLink{
			get
			{
				return Strategy.ExistUnitRole(Meta.Link.RelationType);
			}
		}

		virtual public void RemoveLink()
		{
			Strategy.RemoveUnitRole(Meta.Link.RelationType);
		}


		virtual public global::System.String Location 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Location.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Location.RelationType, value);
			}
		}

		virtual public bool ExistLocation{
			get
			{
				return Strategy.ExistUnitRole(Meta.Location.RelationType);
			}
		}

		virtual public void RemoveLocation()
		{
			Strategy.RemoveUnitRole(Meta.Location.RelationType);
		}


		virtual public global::System.String Text 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Text.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Text.RelationType, value);
			}
		}

		virtual public bool ExistText{
			get
			{
				return Strategy.ExistUnitRole(Meta.Text.RelationType);
			}
		}

		virtual public void RemoveText()
		{
			Strategy.RemoveUnitRole(Meta.Text.RelationType);
		}


		virtual public global::System.String AnnouncementText 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.AnnouncementText.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AnnouncementText.RelationType, value);
			}
		}

		virtual public bool ExistAnnouncementText{
			get
			{
				return Strategy.ExistUnitRole(Meta.AnnouncementText.RelationType);
			}
		}

		virtual public void RemoveAnnouncementText()
		{
			Strategy.RemoveUnitRole(Meta.AnnouncementText.RelationType);
		}


		virtual public global::System.DateTime? From 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.From.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.From.RelationType, value);
			}
		}

		virtual public bool ExistFrom{
			get
			{
				return Strategy.ExistUnitRole(Meta.From.RelationType);
			}
		}

		virtual public void RemoveFrom()
		{
			Strategy.RemoveUnitRole(Meta.From.RelationType);
		}


		virtual public Locale Locale
		{ 
			get
			{
				return (Locale) Strategy.GetCompositeRole(Meta.Locale.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Locale.RelationType, value);
			}
		}

		virtual public bool ExistLocale
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Locale.RelationType);
			}
		}

		virtual public void RemoveLocale()
		{
			Strategy.RemoveCompositeRole(Meta.Locale.RelationType);
		}


		virtual public global::System.String Title 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Title.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Title.RelationType, value);
			}
		}

		virtual public bool ExistTitle{
			get
			{
				return Strategy.ExistUnitRole(Meta.Title.RelationType);
			}
		}

		virtual public void RemoveTitle()
		{
			Strategy.RemoveUnitRole(Meta.Title.RelationType);
		}


		virtual public Media Photo
		{ 
			get
			{
				return (Media) Strategy.GetCompositeRole(Meta.Photo.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Photo.RelationType, value);
			}
		}

		virtual public bool ExistPhoto
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Photo.RelationType);
			}
		}

		virtual public void RemovePhoto()
		{
			Strategy.RemoveCompositeRole(Meta.Photo.RelationType);
		}


		virtual public global::System.Boolean? Announce 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.Announce.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Announce.RelationType, value);
			}
		}

		virtual public bool ExistAnnounce{
			get
			{
				return Strategy.ExistUnitRole(Meta.Announce.RelationType);
			}
		}

		virtual public void RemoveAnnounce()
		{
			Strategy.RemoveUnitRole(Meta.Announce.RelationType);
		}


		virtual public global::System.DateTime? To 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.To.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.To.RelationType, value);
			}
		}

		virtual public bool ExistTo{
			get
			{
				return Strategy.ExistUnitRole(Meta.To.RelationType);
			}
		}

		virtual public void RemoveTo()
		{
			Strategy.RemoveUnitRole(Meta.To.RelationType);
		}



		virtual public global::Allors.Extent<EventRegistration> EventRegistrationsWhereEvent
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.EventRegistrationsWhereEvent.RelationType);
			}
		}

		virtual public bool ExistEventRegistrationsWhereEvent
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.EventRegistrationsWhereEvent.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new EventOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new EventOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new EventOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new EventOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new EventOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new EventOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new EventOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new EventOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new EventOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new EventOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class EventBuilder : Allors.ObjectBuilder<Event> , ObjectBuilder, global::System.IDisposable
	{		
		public EventBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Event instance)
		{
			

			if(this.RegistrationRequired.HasValue)
			{
				instance.RegistrationRequired = this.RegistrationRequired.Value;
			}			
		
		

			instance.Link = this.Link;
		
		

			instance.Location = this.Location;
		
		

			instance.Text = this.Text;
		
		

			instance.AnnouncementText = this.AnnouncementText;
		
		
			

			if(this.From.HasValue)
			{
				instance.From = this.From.Value;
			}			
		
		

			instance.Title = this.Title;
		
		
			

			if(this.Announce.HasValue)
			{
				instance.Announce = this.Announce.Value;
			}			
		
		
			

			if(this.To.HasValue)
			{
				instance.To = this.To.Value;
			}			
		
		

			instance.Locale = this.Locale;

		

			instance.Photo = this.Photo;

		
		}


				public global::System.Boolean? RegistrationRequired {get; set;}

				/// <exclude/>
				public EventBuilder WithRegistrationRequired(global::System.Boolean? value)
		        {
				    if(this.RegistrationRequired!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.RegistrationRequired = value;
		            return this;
		        }	

				public global::System.String Link {get; set;}

				/// <exclude/>
				public EventBuilder WithLink(global::System.String value)
		        {
				    if(this.Link!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Link = value;
		            return this;
		        }	

				public global::System.String Location {get; set;}

				/// <exclude/>
				public EventBuilder WithLocation(global::System.String value)
		        {
				    if(this.Location!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Location = value;
		            return this;
		        }	

				public global::System.String Text {get; set;}

				/// <exclude/>
				public EventBuilder WithText(global::System.String value)
		        {
				    if(this.Text!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Text = value;
		            return this;
		        }	

				public global::System.String AnnouncementText {get; set;}

				/// <exclude/>
				public EventBuilder WithAnnouncementText(global::System.String value)
		        {
				    if(this.AnnouncementText!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AnnouncementText = value;
		            return this;
		        }	

				public global::System.DateTime? From {get; set;}

				/// <exclude/>
				public EventBuilder WithFrom(global::System.DateTime? value)
		        {
				    if(this.From!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.From = value;
		            return this;
		        }	

				public Locale Locale {get; set;}

				/// <exclude/>
				public EventBuilder WithLocale(Locale value)
		        {
		            if(this.Locale!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Locale = value;
		            return this;
		        }		

				
				public global::System.String Title {get; set;}

				/// <exclude/>
				public EventBuilder WithTitle(global::System.String value)
		        {
				    if(this.Title!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Title = value;
		            return this;
		        }	

				public Media Photo {get; set;}

				/// <exclude/>
				public EventBuilder WithPhoto(Media value)
		        {
		            if(this.Photo!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Photo = value;
		            return this;
		        }		

				
				public global::System.Boolean? Announce {get; set;}

				/// <exclude/>
				public EventBuilder WithAnnounce(global::System.Boolean? value)
		        {
				    if(this.Announce!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Announce = value;
		            return this;
		        }	

				public global::System.DateTime? To {get; set;}

				/// <exclude/>
				public EventBuilder WithTo(global::System.DateTime? value)
		        {
				    if(this.To!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.To = value;
		            return this;
		        }	


	}

	public partial class Events : global::Allors.ObjectsBase<Event>
	{
		public Events(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaEvent Meta
		{
			get
			{
				return Allors.Meta.MetaEvent.Instance;
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