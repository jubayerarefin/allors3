// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Good.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Allors.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    using Meta;

    public partial class Good
    {

        public void AppsOnPreDerive(ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            // TODO:
            if (this.ExistInventoryItemsWhereGood)
            {
                foreach (InventoryItem inventoryItem in this.InventoryItemsWhereGood)
                {
                    derivation.AddDependency(inventoryItem, this);
                }
            }
        }

        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;
            var defaultLocale = this.strategy.Session.GetSingleton().DefaultLocale;

            derivation.Validation.AssertExistsAtMostOne(this, M.Good.FinishedGood, M.Good.InventoryItemKind);

            if (this.LocalisedNames.Any(x => x.Locale.Equals(defaultLocale)))
            {
                this.Name = this.LocalisedNames.First(x => x.Locale.Equals(defaultLocale)).Text;
            }

            if (this.LocalisedDescriptions.Any(x => x.Locale.Equals(defaultLocale)))
            {
                this.Description = this.LocalisedDescriptions.First(x => x.Locale.Equals(defaultLocale)).Text;
            }

            if (this.ProductCategories.Count == 1 && !this.ExistPrimaryProductCategory)
            {
                this.PrimaryProductCategory = this.ProductCategories.First;
            }

            if (this.ExistPrimaryProductCategory && !this.ExistProductCategories)
            {
                this.AddProductCategory(this.PrimaryProductCategory);
            }

            this.DeriveVirtualProductPriceComponent();
            this.DeriveProductCategoriesExpanded(derivation);
            this.DeriveQuantityOnHand();
            this.DeriveAvailableToPromise();
        }

        public void DeriveVirtualProductPriceComponent()
        {
            if (!this.ExistProductWhereVariant)
            {
                this.RemoveVirtualProductPriceComponents();
            }

            if (this.ExistVariants)
            {
                this.RemoveVirtualProductPriceComponents();

                var priceComponents = this.PriceComponentsWhereProduct;

                foreach (Good product in this.Variants)
                {
                    foreach (PriceComponent priceComponent in priceComponents)
                    {
                        product.AddVirtualProductPriceComponent(priceComponent);

                        var basePrice = priceComponent as BasePrice;
                        if (basePrice != null && !priceComponent.ExistProductFeature)
                        {
                            product.AddToBasePrice(basePrice);
                        }
                    }
                }
            }
        }

        public void DeriveProductCategoriesExpanded(IDerivation derivation)
        {
            this.RemoveProductCategoriesExpanded();

            if (this.ExistPrimaryProductCategory)
            {
                this.AddProductCategoriesExpanded(this.PrimaryProductCategory);
                foreach (ProductCategory superJacent in this.PrimaryProductCategory.SuperJacent)
                {
                    this.AddProductCategoriesExpanded(superJacent);
                    superJacent.AppsOnDeriveAllProducts(derivation);
                }
            }

            foreach (ProductCategory productCategory in this.ProductCategories)
            {
                this.AddProductCategoriesExpanded(productCategory);
                foreach (ProductCategory superJacent in productCategory.SuperJacent)
                {
                    this.AddProductCategoriesExpanded(superJacent);
                    superJacent.AppsOnDeriveAllProducts(derivation);
                }
            }
        }

        public void DeriveQuantityOnHand()
        {
            this.QuantityOnHand = 0;

            foreach (InventoryItem inventoryItem in this.InventoryItemsWhereGood)
            {
                if (inventoryItem is NonSerialisedInventoryItem)
                {
                    var nonSerialised = (NonSerialisedInventoryItem)inventoryItem;
                    this.QuantityOnHand += nonSerialised.QuantityOnHand;
                }
            }
        }

        public void DeriveAvailableToPromise()
        {
            this.AvailableToPromise = 0;

            foreach (InventoryItem inventoryItem in this.InventoryItemsWhereGood)
            {
                if (inventoryItem is NonSerialisedInventoryItem)
                {
                    var nonSerialised = (NonSerialisedInventoryItem)inventoryItem;
                    this.AvailableToPromise += nonSerialised.AvailableToPromise;
                }
            }
        }
    }
}