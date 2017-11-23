// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class NewsItem : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public NewsItem(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaNewsItem Meta
		{
			get
			{
				return Allors.Meta.MetaNewsItem.Instance;
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

		public static NewsItem Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (NewsItem) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Boolean? IsPublished 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.IsPublished.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.IsPublished.RelationType, value);
			}
		}

		virtual public bool ExistIsPublished{
			get
			{
				return Strategy.ExistUnitRole(Meta.IsPublished.RelationType);
			}
		}

		virtual public void RemoveIsPublished()
		{
			Strategy.RemoveUnitRole(Meta.IsPublished.RelationType);
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


		virtual public global::System.Int32? DisplayOrder 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.DisplayOrder.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.DisplayOrder.RelationType, value);
			}
		}

		virtual public bool ExistDisplayOrder{
			get
			{
				return Strategy.ExistUnitRole(Meta.DisplayOrder.RelationType);
			}
		}

		virtual public void RemoveDisplayOrder()
		{
			Strategy.RemoveUnitRole(Meta.DisplayOrder.RelationType);
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


		virtual public global::System.String LongText 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.LongText.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.LongText.RelationType, value);
			}
		}

		virtual public bool ExistLongText{
			get
			{
				return Strategy.ExistUnitRole(Meta.LongText.RelationType);
			}
		}

		virtual public void RemoveLongText()
		{
			Strategy.RemoveUnitRole(Meta.LongText.RelationType);
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


		virtual public global::System.DateTime? Date 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.Date.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Date.RelationType, value);
			}
		}

		virtual public bool ExistDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.Date.RelationType);
			}
		}

		virtual public void RemoveDate()
		{
			Strategy.RemoveUnitRole(Meta.Date.RelationType);
		}


		virtual public global::System.Boolean? Announcement 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.Announcement.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Announcement.RelationType, value);
			}
		}

		virtual public bool ExistAnnouncement{
			get
			{
				return Strategy.ExistUnitRole(Meta.Announcement.RelationType);
			}
		}

		virtual public void RemoveAnnouncement()
		{
			Strategy.RemoveUnitRole(Meta.Announcement.RelationType);
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
			var method = new NewsItemOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new NewsItemOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new NewsItemOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new NewsItemOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new NewsItemOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new NewsItemOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new NewsItemOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new NewsItemOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new NewsItemOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new NewsItemOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class NewsItemBuilder : Allors.ObjectBuilder<NewsItem> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public NewsItemBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(NewsItem instance)
		{
			

			if(this.IsPublished.HasValue)
			{
				instance.IsPublished = this.IsPublished.Value;
			}			
		
		

			instance.Title = this.Title;
		
		
			

			if(this.DisplayOrder.HasValue)
			{
				instance.DisplayOrder = this.DisplayOrder.Value;
			}			
		
		

			instance.LongText = this.LongText;
		
		

			instance.Text = this.Text;
		
		
			

			if(this.Date.HasValue)
			{
				instance.Date = this.Date.Value;
			}			
		
		
			

			if(this.Announcement.HasValue)
			{
				instance.Announcement = this.Announcement.Value;
			}			
		
		

			instance.Locale = this.Locale;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Boolean? IsPublished {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithIsPublished(global::System.Boolean? value)
		        {
				    if(this.IsPublished!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IsPublished = value;
		            return this;
		        }	

				public global::System.String Title {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithTitle(global::System.String value)
		        {
				    if(this.Title!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Title = value;
		            return this;
		        }	

				public global::System.Int32? DisplayOrder {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithDisplayOrder(global::System.Int32? value)
		        {
				    if(this.DisplayOrder!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DisplayOrder = value;
		            return this;
		        }	

				public Locale Locale {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithLocale(Locale value)
		        {
		            if(this.Locale!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Locale = value;
		            return this;
		        }		

				
				public global::System.String LongText {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithLongText(global::System.String value)
		        {
				    if(this.LongText!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.LongText = value;
		            return this;
		        }	

				public global::System.String Text {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithText(global::System.String value)
		        {
				    if(this.Text!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Text = value;
		            return this;
		        }	

				public global::System.DateTime? Date {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithDate(global::System.DateTime? value)
		        {
				    if(this.Date!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Date = value;
		            return this;
		        }	

				public global::System.Boolean? Announcement {get; set;}

				/// <exclude/>
				public NewsItemBuilder WithAnnouncement(global::System.Boolean? value)
		        {
				    if(this.Announcement!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Announcement = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public NewsItemBuilder WithDeniedPermission(Permission value)
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
				public NewsItemBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class NewsItems : global::Allors.ObjectsBase<NewsItem>
	{
		public NewsItems(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaNewsItem Meta
		{
			get
			{
				return Allors.Meta.MetaNewsItem.Instance;
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