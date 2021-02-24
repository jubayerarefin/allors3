// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;
    using Database.Derivations;

    public class SalesOrderItemQuantatiesDerivation : DomainDerivation
    {
        public SalesOrderItemQuantatiesDerivation(M m) : base(m, new Guid("5790f640-2435-466e-8f34-6cb817008e3d")) =>
            this.Patterns = new Pattern[]
            {
                new AssociationPattern(m.SalesOrderItem.SalesOrderItemState),
                new AssociationPattern(m.SalesOrderItem.QuantityPendingShipment),
                new AssociationPattern(m.SalesOrderItem.QuantityShipped),
                new AssociationPattern(m.InventoryItemTransaction.InventoryItem) { Steps = new IPropertyType[] {m.InventoryItemTransaction.InventoryItem, m.NonSerialisedInventoryItem.SalesOrderItemInventoryAssignmentsWhereInventoryItem, m.SalesOrderItemInventoryAssignment.SalesOrderItemWhereSalesOrderItemInventoryAssignment } },
                new AssociationPattern(m.PickListItem.InventoryItem) { Steps = new IPropertyType[] {m.PickListItem.InventoryItem, m.NonSerialisedInventoryItem.SalesOrderItemInventoryAssignmentsWhereInventoryItem, m.SalesOrderItemInventoryAssignment.SalesOrderItemWhereSalesOrderItemInventoryAssignment } },
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var validation = cycle.Validation;
            var transaction = cycle.Transaction;

            foreach (var @this in matches.Cast<SalesOrderItem>().Where(v => v.SalesOrderItemState.IsInProcess && !v.SalesOrderItemShipmentState.IsShipped))
            {
                var salesOrder = @this.SalesOrderWhereSalesOrderItem;
                var settings = @this.Strategy.Transaction.GetSingleton().Settings;

                if (@this.ExistReservedFromNonSerialisedInventoryItem)
                {
                    if ((salesOrder.OrderKind?.ScheduleManually == true && @this.QuantityPendingShipment > 0)
                        || !salesOrder.ExistOrderKind || !salesOrder.OrderKind.ScheduleManually)
                    {
                        var committedOutSameProductOtherItem = @this.ExistProduct ?
                            @this.Product.SalesOrderItemsWhereProduct
                                .Where(v => !Equals(v, @this))
                                .Sum(v => v.QuantityRequestsShipping) :
                            0;

                        var qoh = @this.ReservedFromNonSerialisedInventoryItem.CalculateQuantityOnHand(settings);
                        var initialAtp = @this.ReservedFromNonSerialisedInventoryItem.CalculateAvailableToPromise(settings);

                        var atp = initialAtp - committedOutSameProductOtherItem > 0 ?
                            initialAtp - committedOutSameProductOtherItem :
                            0;

                        var quantityCommittedOut = @this.SalesOrderItemInventoryAssignments
                            .SelectMany(v => v.InventoryItemTransactions)
                            .Where(t => t.Reason.Equals(new InventoryTransactionReasons(transaction).Reservation))
                            .Sum(v => v.Quantity);

                        if (quantityCommittedOut < 0)
                        {
                            quantityCommittedOut = 0;
                        }

                        if (@this.QuantityCommittedOut != quantityCommittedOut)
                        {
                            @this.QuantityCommittedOut = quantityCommittedOut;
                        }

                        if (@this.QuantityCommittedOut > qoh)
                        {
                            @this.QuantityCommittedOut = qoh;
                        }

                        var wantToShip = @this.QuantityCommittedOut - @this.QuantityPendingShipment;

                        //if (salesOrderItem.ExistPreviousReservedFromNonSerialisedInventoryItem
                        //    && !Equals(salesOrderItem.ReservedFromNonSerialisedInventoryItem, salesOrderItem.PreviousReservedFromNonSerialisedInventoryItem))
                        //{
                        //    var previousInventoryAssignment = salesOrderItem.SalesOrderItemInventoryAssignments.FirstOrDefault(v => v.InventoryItem.Equals(salesOrderItem.PreviousReservedFromNonSerialisedInventoryItem));
                        //    previousInventoryAssignment.Quantity = 0;

                        //    foreach (OrderShipment orderShipment in salesOrderItem.OrderShipmentsWhereOrderItem)
                        //    {
                        //        orderShipment.Delete();
                        //    }

                        //    quantityCommittedOut = 0;
                        //    wantToShip = 0;
                        //}

                        var neededFromInventory = @this.QuantityOrdered - @this.QuantityShipped - @this.QuantityCommittedOut;
                        var availableFromInventory = neededFromInventory < atp ? neededFromInventory : atp;

                        var inventoryAssignment = @this.SalesOrderItemInventoryAssignments.FirstOrDefault(v => v.InventoryItem.Equals(@this.ReservedFromNonSerialisedInventoryItem));
                        if (neededFromInventory != 0 || @this.QuantityShortFalled > 0)
                        {
                            if (inventoryAssignment == null)
                            {
                                var salesOrderItemInventoryAssignment = new SalesOrderItemInventoryAssignmentBuilder(transaction)
                                    .WithInventoryItem(@this.ReservedFromNonSerialisedInventoryItem)
                                    .WithQuantity(wantToShip + availableFromInventory)
                                    .Build();

                                @this.AddSalesOrderItemInventoryAssignment(salesOrderItemInventoryAssignment);
                            }
                            else
                            {
                                inventoryAssignment.InventoryItem = @this.ReservedFromNonSerialisedInventoryItem;
                                if (@this.QuantityCommittedOut > qoh)
                                {
                                    inventoryAssignment.Quantity = qoh;
                                }
                                else
                                {
                                    inventoryAssignment.Quantity = @this.QuantityCommittedOut + availableFromInventory;
                                }
                            }

                            var quantityRequestsShipping = wantToShip + availableFromInventory;

                            if (quantityRequestsShipping > qoh)
                            {
                                quantityRequestsShipping = qoh;
                            }

                            if (salesOrder.OrderKind?.ScheduleManually == true)
                            {
                                quantityRequestsShipping = 0;
                            }

                            if (@this.QuantityRequestsShipping != quantityRequestsShipping)
                            {
                                @this.QuantityRequestsShipping = quantityRequestsShipping;
                            }

                            @this.QuantityReserved = @this.QuantityOrdered - @this.QuantityShipped;
                            @this.QuantityShortFalled = neededFromInventory - availableFromInventory > 0 ? neededFromInventory - availableFromInventory : 0;
                        }
                    }
                }

                if (@this.ExistReservedFromSerialisedInventoryItem)
                {
                    var inventoryAssignment = @this.SalesOrderItemInventoryAssignments.FirstOrDefault(v => v.InventoryItem.Equals(@this.ReservedFromSerialisedInventoryItem));
                    if (inventoryAssignment == null)
                    {
                        var salesOrderItemInventoryAssignment = new SalesOrderItemInventoryAssignmentBuilder(transaction)
                                .WithInventoryItem(@this.ReservedFromSerialisedInventoryItem)
                                .WithQuantity(1)
                                .Build();

                        @this.AddSalesOrderItemInventoryAssignment(salesOrderItemInventoryAssignment);

                        @this.QuantityRequestsShipping = 1;
                    }

                    @this.QuantityReserved = 1;
                }
            }
        }
    }
}
