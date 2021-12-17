// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Derivations;
    using Meta;
    using Derivations.Rules;

    public class SerialisedItemSearchStringRule : Rule
    {
        public SerialisedItemSearchStringRule(MetaPopulation m) : base(m, new Guid("9d4316ae-3abf-4b6a-839e-1acbcea8995f")) =>
            this.Patterns = new Pattern[]
            {
                m.FixedAsset.RolePattern(v => v.Name, m.SerialisedItem),
                m.FixedAsset.RolePattern(v => v.LocalisedNames, m.SerialisedItem),
                m.LocalisedText.RolePattern(v => v.Text, v => v.FixedAssetWhereLocalisedName.FixedAsset, m.SerialisedItem),
                m.FixedAsset.RolePattern(v => v.LocalisedDescriptions, m.SerialisedItem),
                m.LocalisedText.RolePattern(v => v.Text, v => v.FixedAssetWhereLocalisedDescription.FixedAsset, m.SerialisedItem),
                m.FixedAsset.RolePattern(v => v.Keywords, m.SerialisedItem),
                m.FixedAsset.RolePattern(v => v.LocalisedKeywords, m.SerialisedItem),
                m.LocalisedText.RolePattern(v => v.Text, v => v.FixedAssetWhereLocalisedKeyword.FixedAsset, m.SerialisedItem),
                m.SerialisedItem.RolePattern(v => v.ItemNumber),
                m.SerialisedItem.RolePattern(v => v.SerialNumber),
                m.SerialisedItem.RolePattern(v => v.OwnedBy),
                m.SerialisedItem.RolePattern(v => v.ProductCategoriesDisplayName),
                m.Party.RolePattern(v => v.DisplayName, v => v.SerialisedItemsWhereOwnedBy.SerialisedItem),
                m.SerialisedItem.RolePattern(v => v.RentedBy),
                m.Party.RolePattern(v => v.DisplayName, v => v.SerialisedItemsWhereRentedBy.SerialisedItem),
                m.SerialisedItem.RolePattern(v => v.Buyer),
                m.SerialisedItem.RolePattern(v => v.Seller),
                m.Brand.RolePattern(v => v.Name, v => v.PartsWhereBrand.Part.SerialisedItems.SerialisedItem),
                m.Model.RolePattern(v => v.Name, v => v.PartsWhereModel.Part.SerialisedItems.SerialisedItem),

                m.FixedAsset.AssociationPattern(v => v.PartyFixedAssetAssignmentsWhereFixedAsset, m.SerialisedItem),
                m.Party.RolePattern(v => v.DisplayName, v => v.PartyFixedAssetAssignmentsWhereParty.PartyFixedAssetAssignment.FixedAsset.FixedAsset, m.SerialisedItem),
                m.AssetAssignmentStatus.RolePattern(v => v.Name, v => v.PartyFixedAssetAssignmentsWhereAssetAssignmentStatus.PartyFixedAssetAssignment.FixedAsset.FixedAsset, m.SerialisedItem),
                m.FixedAsset.AssociationPattern(v => v.WorkEffortFixedAssetAssignmentsWhereFixedAsset, m.SerialisedItem),
                m.FixedAsset.AssociationPattern(v => v.WorkRequirementsWhereFixedAsset, m.SerialisedItem),
                m.SerialisedItem.AssociationPattern(v => v.PartWhereSerialisedItem),
                m.SerialisedItem.AssociationPattern(v => v.PurchaseInvoiceItemsWhereSerialisedItem),
                m.SerialisedItem.AssociationPattern(v => v.PurchaseOrderItemsWhereSerialisedItem),
                m.SerialisedItem.AssociationPattern(v => v.QuoteItemsWhereSerialisedItem),
                m.SerialisedItem.AssociationPattern(v => v.RequestItemsWhereSerialisedItem),
                m.SerialisedItem.AssociationPattern(v => v.SerialisedInventoryItemsWhereSerialisedItem),
                m.SerialisedItem.AssociationPattern(v => v.ShipmentItemsWhereSerialisedItem),
            };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<SerialisedItem>())
            {
                var array = new string[] {
                    @this.Name,
                    @this.ExistLocalisedNames ? string.Join(" ", @this.LocalisedNames?.Select(v => v.Text)) : null,
                    @this.Description,
                    @this.ExistLocalisedDescriptions ? string.Join(" ", @this.LocalisedDescriptions?.Select(v => v.Text)) : null,
                    @this.Keywords,
                    @this.ExistLocalisedKeywords ? string.Join(" ", @this.LocalisedKeywords?.Select(v => v.Text)) : null,
                    @this.ItemNumber,
                    @this.SerialNumber,
                    @this.ProductCategoriesDisplayName,
                    @this.OwnedBy?.DisplayName,
                    @this.RentedBy?.DisplayName,
                    @this.Buyer?.DisplayName,
                    @this.Seller?.DisplayName,
                    @this.ExistPartWhereSerialisedItem ? string.Join(" ", @this.PartWhereSerialisedItem?.DisplayName) : null,
                    @this.ExistPartWhereSerialisedItem ? string.Join(" ", @this.PartWhereSerialisedItem?.Brand?.Name) : null,
                    @this.ExistPartWhereSerialisedItem ? string.Join(" ", @this.PartWhereSerialisedItem?.Model?.Name) : null,
                    @this.ExistPartyFixedAssetAssignmentsWhereFixedAsset ? string.Join(" ", @this.PartyFixedAssetAssignmentsWhereFixedAsset?.Select(v => v.Party?.DisplayName)) : null,
                    @this.ExistPartyFixedAssetAssignmentsWhereFixedAsset ? string.Join(" ", @this.PartyFixedAssetAssignmentsWhereFixedAsset?.Select(v => v.AssetAssignmentStatus?.Name)) : null,
                    @this.ExistWorkEffortFixedAssetAssignmentsWhereFixedAsset ? string.Join(" ", @this.WorkEffortFixedAssetAssignmentsWhereFixedAsset?.Select(v => v.Assignment?.WorkEffortNumber)) : null,
                    @this.ExistWorkRequirementsWhereFixedAsset ? string.Join(" ", @this.WorkRequirementsWhereFixedAsset?.Select(v => v.RequirementNumber)) : null,
                    @this.ExistPurchaseInvoiceItemsWhereSerialisedItem ? string.Join(" ", @this.PurchaseInvoiceItemsWhereSerialisedItem?.Select(v => v.PurchaseInvoiceWherePurchaseInvoiceItem?.InvoiceNumber)) : null,
                    @this.ExistPurchaseOrderItemsWhereSerialisedItem ? string.Join(" ", @this.PurchaseOrderItemsWhereSerialisedItem?.Select(v => v.PurchaseOrderWherePurchaseOrderItem?.OrderNumber)) : null,
                    @this.ExistQuoteItemsWhereSerialisedItem ? string.Join(" ", @this.QuoteItemsWhereSerialisedItem?.Select(v => v.QuoteWhereQuoteItem?.QuoteNumber)) : null,
                    @this.ExistRequestItemsWhereSerialisedItem ? string.Join(" ", @this.RequestItemsWhereSerialisedItem?.Select(v => v.RequestWhereRequestItem?.RequestNumber)) : null,
                    @this.ExistSalesInvoiceItemsWhereSerialisedItem ? string.Join(" ", @this.SalesInvoiceItemsWhereSerialisedItem?.Select(v => v.SalesInvoiceWhereSalesInvoiceItem?.InvoiceNumber)) : null,
                    @this.ExistSerialisedInventoryItemsWhereSerialisedItem ? string.Join(" ", @this.SerialisedInventoryItemsWhereSerialisedItem?.Select(v => v.Name)) : null,
                    @this.ExistSerialisedInventoryItemsWhereSerialisedItem ? string.Join(" ", @this.SerialisedInventoryItemsWhereSerialisedItem?.Select(v => v.SerialisedInventoryItemState?.Name)) : null,
                    @this.ExistShipmentItemsWhereSerialisedItem ? string.Join(" ", @this.ShipmentItemsWhereSerialisedItem?.Select(v => v.ShipmentWhereShipmentItem?.ShipmentNumber)) : null,
                };

                if (array.Any(s => !string.IsNullOrEmpty(s)))
                {
                    @this.SearchString = string.Join(" ", array.Where(s => !string.IsNullOrEmpty(s)));
                }
            }
        }
    }
}
