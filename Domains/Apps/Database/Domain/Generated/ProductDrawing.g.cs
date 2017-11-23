// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class ProductDrawing : Allors.IObject , Document
	{
		private readonly IStrategy strategy;

		public ProductDrawing(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaProductDrawing Meta
		{
			get
			{
				return Allors.Meta.MetaProductDrawing.Instance;
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

		public static ProductDrawing Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (ProductDrawing) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.String Name 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Name.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Name.RelationType, value);
			}
		}

		virtual public bool ExistName{
			get
			{
				return Strategy.ExistUnitRole(Meta.Name.RelationType);
			}
		}

		virtual public void RemoveName()
		{
			Strategy.RemoveUnitRole(Meta.Name.RelationType);
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


		virtual public global::System.String DocumentLocation 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.DocumentLocation.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.DocumentLocation.RelationType, value);
			}
		}

		virtual public bool ExistDocumentLocation{
			get
			{
				return Strategy.ExistUnitRole(Meta.DocumentLocation.RelationType);
			}
		}

		virtual public void RemoveDocumentLocation()
		{
			Strategy.RemoveUnitRole(Meta.DocumentLocation.RelationType);
		}


		virtual public global::System.String PrintContent 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.PrintContent.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.PrintContent.RelationType, value);
			}
		}

		virtual public bool ExistPrintContent{
			get
			{
				return Strategy.ExistUnitRole(Meta.PrintContent.RelationType);
			}
		}

		virtual public void RemovePrintContent()
		{
			Strategy.RemoveUnitRole(Meta.PrintContent.RelationType);
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


		virtual public global::System.String Comment 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Comment.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Comment.RelationType, value);
			}
		}

		virtual public bool ExistComment{
			get
			{
				return Strategy.ExistUnitRole(Meta.Comment.RelationType);
			}
		}

		virtual public void RemoveComment()
		{
			Strategy.RemoveUnitRole(Meta.Comment.RelationType);
		}



		virtual public ShipmentItem ShipmentItemWhereDocument
		{ 
			get
			{
				return (ShipmentItem) Strategy.GetCompositeAssociation(Meta.ShipmentItemWhereDocument.RelationType);
			}
		} 

		virtual public bool ExistShipmentItemWhereDocument
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.ShipmentItemWhereDocument.RelationType);
			}
		}


		virtual public ShipmentPackage ShipmentPackageWhereDocument
		{ 
			get
			{
				return (ShipmentPackage) Strategy.GetCompositeAssociation(Meta.ShipmentPackageWhereDocument.RelationType);
			}
		} 

		virtual public bool ExistShipmentPackageWhereDocument
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.ShipmentPackageWhereDocument.RelationType);
			}
		}


		virtual public global::Allors.Extent<Part> PartsWhereDocument
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PartsWhereDocument.RelationType);
			}
		}

		virtual public bool ExistPartsWhereDocument
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PartsWhereDocument.RelationType);
			}
		}


		virtual public global::Allors.Extent<Product> ProductsWhereDocument
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.ProductsWhereDocument.RelationType);
			}
		}

		virtual public bool ExistProductsWhereDocument
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.ProductsWhereDocument.RelationType);
			}
		}


		virtual public ShipmentVersion ShipmentVersionWhereDocument
		{ 
			get
			{
				return (ShipmentVersion) Strategy.GetCompositeAssociation(Meta.ShipmentVersionWhereDocument.RelationType);
			}
		} 

		virtual public bool ExistShipmentVersionWhereDocument
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.ShipmentVersionWhereDocument.RelationType);
			}
		}


		virtual public Shipment ShipmentWhereDocument
		{ 
			get
			{
				return (Shipment) Strategy.GetCompositeAssociation(Meta.ShipmentWhereDocument.RelationType);
			}
		} 

		virtual public bool ExistShipmentWhereDocument
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.ShipmentWhereDocument.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new ProductDrawingOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new ProductDrawingOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new ProductDrawingOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new ProductDrawingOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new ProductDrawingOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new ProductDrawingOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new ProductDrawingOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new ProductDrawingOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new ProductDrawingOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new ProductDrawingOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class ProductDrawingBuilder : Allors.ObjectBuilder<ProductDrawing> , DocumentBuilder, global::System.IDisposable
	{		
		public ProductDrawingBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(ProductDrawing instance)
		{

			instance.Name = this.Name;
		
		

			instance.Description = this.Description;
		
		

			instance.Text = this.Text;
		
		

			instance.DocumentLocation = this.DocumentLocation;
		
		

			instance.PrintContent = this.PrintContent;
		
		

			instance.Comment = this.Comment;
		
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.String Name {get; set;}

				/// <exclude/>
				public ProductDrawingBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public global::System.String Description {get; set;}

				/// <exclude/>
				public ProductDrawingBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.String Text {get; set;}

				/// <exclude/>
				public ProductDrawingBuilder WithText(global::System.String value)
		        {
				    if(this.Text!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Text = value;
		            return this;
		        }	

				public global::System.String DocumentLocation {get; set;}

				/// <exclude/>
				public ProductDrawingBuilder WithDocumentLocation(global::System.String value)
		        {
				    if(this.DocumentLocation!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.DocumentLocation = value;
		            return this;
		        }	

				public global::System.String PrintContent {get; set;}

				/// <exclude/>
				public ProductDrawingBuilder WithPrintContent(global::System.String value)
		        {
				    if(this.PrintContent!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.PrintContent = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public ProductDrawingBuilder WithDeniedPermission(Permission value)
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
				public ProductDrawingBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				
				public global::System.String Comment {get; set;}

				/// <exclude/>
				public ProductDrawingBuilder WithComment(global::System.String value)
		        {
				    if(this.Comment!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Comment = value;
		            return this;
		        }	


	}

	public partial class ProductDrawings : global::Allors.ObjectsBase<ProductDrawing>
	{
		public ProductDrawings(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaProductDrawing Meta
		{
			get
			{
				return Allors.Meta.MetaProductDrawing.Instance;
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