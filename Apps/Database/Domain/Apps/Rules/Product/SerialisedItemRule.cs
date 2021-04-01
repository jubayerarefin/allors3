// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Derivations;
    using Meta;
    using Database.Derivations;
    using Resources;

    public class SerialisedItemRule : Rule
    {
        public SerialisedItemRule(M m) : base(m, new Guid("A871B4BB-3285-418F-9E10-5A786A6284DA")) =>
            this.Patterns = new Pattern[]
            {
                new RolePattern(m.SerialisedItem, m.SerialisedItem.Name),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.ItemNumber),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.AcquiredDate),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.AcquisitionYear),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.SerialNumber),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.AssignedSuppliedBy),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.PurchaseOrder),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.OwnedBy),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.RentedBy),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.Ownership),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.Buyer),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.Seller),
                new RolePattern(m.SerialisedItem, m.SerialisedItem.SerialisedItemAvailability),
                new AssociationPattern(m.Part.SerialisedItems),
                new AssociationPattern(m.SupplierOffering.Part) { Steps = new IPropertyType[] { m.Part.SerialisedItems } },
                new AssociationPattern(m.QuoteItem.SerialisedItem),
                new RolePattern(m.QuoteItem, m.QuoteItem.QuoteItemState) { Steps = new IPropertyType[] { m.QuoteItem.SerialisedItem } },
                new AssociationPattern(m.SalesOrderItem.SerialisedItem),
                new RolePattern(m.SalesOrderItem, m.SalesOrderItem.SalesOrderItemState) { Steps = new IPropertyType[] { m.SalesOrderItem.SerialisedItem } },
                new AssociationPattern(m.WorkEffortFixedAssetAssignment.FixedAsset),
                new RolePattern(m.WorkEffort, m.WorkEffort.WorkEffortState) { Steps = new IPropertyType[] { m.WorkEffort.WorkEffortFixedAssetAssignmentsWhereAssignment, m.WorkEffortFixedAssetAssignment.FixedAsset } },
                new RolePattern(m.Part, m.Part.ProductType) { Steps = new IPropertyType[] { m.Part.SerialisedItems } },
                new RolePattern(m.ProductType, m.ProductType.SerialisedItemCharacteristicTypes) { Steps = new IPropertyType[]{ this.M.ProductType.PartsWhereProductType, m.Part.SerialisedItems } },
                new RolePattern(m.Part, m.Part.Brand) { Steps = new IPropertyType[] { m.Part.SerialisedItems } },
                new RolePattern(m.Part, m.Part.Model) { Steps = new IPropertyType[] { m.Part.SerialisedItems } },
                new RolePattern(m.Brand, m.Brand.Name) { Steps = new IPropertyType[] { m.Brand.PartsWhereBrand, m.Part.SerialisedItems } },
                new RolePattern(m.Model, m.Model.Name) { Steps = new IPropertyType[] { m.Model.PartsWhereModel, m.Part.SerialisedItems } },
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<SerialisedItem>())
            {
                validation.AssertExistsAtMostOne(@this, @this.Meta.AcquiredDate, @this.Meta.AcquisitionYear);

                if (!@this.ExistName && @this.ExistPartWhereSerialisedItem)
                {
                    @this.Name = @this.PartWhereSerialisedItem.Name;
                }

                if (!@this.ExistName && @this.ExistSerialNumber)
                {
                    @this.Name = @this.SerialNumber;
                }

                @this.SuppliedBy = @this.AssignedSuppliedBy ??
                    @this.PurchaseOrder?.TakenViaSupplier ??
                    @this.PartWhereSerialisedItem?.SupplierOfferingsWherePart?.FirstOrDefault()?.Supplier;

                @this.SuppliedByPartyName = @this.ExistSuppliedBy ? @this.SuppliedBy.PartyName : string.Empty;
                @this.OwnedByPartyName = @this.ExistOwnedBy ? @this.OwnedBy.PartyName : string.Empty;
                @this.RentedByPartyName = @this.ExistRentedBy ? @this.RentedBy.PartyName : string.Empty;
                @this.OwnershipByOwnershipName = @this.ExistOwnership ? @this.Ownership.Name : string.Empty;
                @this.SerialisedItemAvailabilityName = @this.ExistSerialisedItemAvailability ? @this.SerialisedItemAvailability.Name : string.Empty;

                var doubles = @this.PartWhereSerialisedItem?.SerialisedItems.Where(v =>
                    !string.IsNullOrEmpty(v.SerialNumber)
                    && v.SerialNumber != "."
                    && v.SerialNumber.Equals(@this.SerialNumber)).ToArray();
                if (doubles?.Length > 1)
                {
                    validation.AddError($"{@this} {@this.Meta.SerialNumber} {ErrorMessages.SameSerialNumber}");
                }

                @this.OnQuote = @this.QuoteItemsWhereSerialisedItem.Any(v => v.QuoteItemState.IsDraft
                            || v.QuoteItemState.IsSubmitted || v.QuoteItemState.IsApproved
                            || v.QuoteItemState.IsAwaitingAcceptance || v.QuoteItemState.IsAccepted);

                @this.OnSalesOrder = @this.SalesOrderItemsWhereSerialisedItem.Any(v => v.SalesOrderItemState.IsProvisional
                            || v.SalesOrderItemState.IsReadyForPosting || v.SalesOrderItemState.IsRequestsApproval
                            || v.SalesOrderItemState.IsAwaitingAcceptance || v.SalesOrderItemState.IsOnHold || v.SalesOrderItemState.IsInProcess);

                @this.OnWorkEffort = @this.WorkEffortFixedAssetAssignmentsWhereFixedAsset.Any(v => v.ExistAssignment
                            && (v.Assignment.WorkEffortState.IsCreated || v.Assignment.WorkEffortState.IsInProgress));

                var characteristicsToDelete = @this.SerialisedItemCharacteristics.ToList();
                var part = @this.PartWhereSerialisedItem;

                if (@this.ExistPartWhereSerialisedItem && part.ExistProductType)
                {
                    foreach (SerialisedItemCharacteristicType characteristicType in part.ProductType.SerialisedItemCharacteristicTypes)
                    {
                        var characteristic = @this.SerialisedItemCharacteristics.FirstOrDefault(v2 => Equals(v2.SerialisedItemCharacteristicType, characteristicType));
                        if (characteristic == null)
                        {
                            var newCharacteristic = new SerialisedItemCharacteristicBuilder(@this.Strategy.Transaction)
                                .WithSerialisedItemCharacteristicType(characteristicType).Build();
                            @this.AddSerialisedItemCharacteristic(newCharacteristic);

                            var partCharacteristics = part.SerialisedItemCharacteristics;
                            partCharacteristics.Filter.AddEquals(this.M.SerialisedItemCharacteristic.SerialisedItemCharacteristicType, characteristicType);
                            var fromPart = partCharacteristics.FirstOrDefault();

                            if (fromPart != null)
                            {
                                newCharacteristic.Value = fromPart.Value;
                            }
                        }
                        else
                        {
                            characteristicsToDelete.Remove(characteristic);
                        }
                    }
                }

                foreach (var characteristic in characteristicsToDelete)
                {
                    @this.RemoveSerialisedItemCharacteristic(characteristic);
                }

                var builder = new StringBuilder();

                builder.Append(@this.ItemNumber);
                builder.Append(string.Join(" ", @this.SerialNumber));
                builder.Append(string.Join(" ", @this.Name));

                if (@this.ExistOwnedBy)
                {
                    builder.Append(string.Join(" ", @this.OwnedBy.PartyName));
                }

                if (@this.ExistBuyer)
                {
                    builder.Append(string.Join(" ", @this.Buyer.PartyName));
                }

                if (@this.ExistSeller)
                {
                    builder.Append(string.Join(" ", @this.Seller.PartyName));
                }

                if (@this.ExistPartWhereSerialisedItem)
                {
                    builder.Append(string.Join(" ", @this.PartWhereSerialisedItem?.Brand?.Name));
                    builder.Append(string.Join(" ", @this.PartWhereSerialisedItem?.Model?.Name));
                }

                builder.Append(string.Join(" ", @this.Keywords));
                @this.SearchString = builder.ToString();
            }
        }
    }
}