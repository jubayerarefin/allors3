// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Linq;
    using Allors.Domain.Derivations;
    using Allors.Meta;
    using Resources;

    public static partial class DabaseExtensions
    {
        public class OrderShipmentCreationDerivation : IDomainDerivation
        {
            public void Derive(ISession session, IChangeSet changeSet, IDomainValidation validation)
            {
                var createdOrderShipments = changeSet.Created.Select(session.Instantiate).OfType<OrderShipment>();

                foreach(var orderShipment in createdOrderShipments)
                {
                    if (orderShipment.ShipmentItem.ShipmentWhereShipmentItem is CustomerShipment customerShipment && orderShipment.OrderItem is SalesOrderItem salesOrderItem)
                    {
                        var quantityPendingShipment = orderShipment.OrderItem?.OrderShipmentsWhereOrderItem?
                            .Where(v => v.ExistShipmentItem
                                        && !((CustomerShipment)v.ShipmentItem.ShipmentWhereShipmentItem).ShipmentState.Equals(new ShipmentStates(orderShipment.Session()).Shipped))
                            .Sum(v => v.Quantity);

                        if (salesOrderItem.QuantityPendingShipment > quantityPendingShipment)
                        {
                            var diff = orderShipment.Quantity * -1;

                            // HACK: DerivedRoles
                            (salesOrderItem).QuantityPendingShipment -= diff;
                            customerShipment.BaseOnDeriveQuantityDecreased(orderShipment.ShipmentItem, salesOrderItem, diff);
                        }

                        if (orderShipment.Strategy.IsNewInSession)
                        {
                            var quantityPicked = orderShipment.OrderItem.OrderShipmentsWhereOrderItem.Select(v => v.ShipmentItem?.ItemIssuancesWhereShipmentItem.Sum(z => z.PickListItem.Quantity)).Sum();
                            var pendingFromOthers = salesOrderItem.QuantityPendingShipment - orderShipment.Quantity;

                            if (salesOrderItem.QuantityRequestsShipping > 0)
                            {
                                // HACK: DerivedRoles
                                (salesOrderItem).QuantityRequestsShipping -= orderShipment.Quantity;
                            }

                            if (salesOrderItem.ExistReservedFromNonSerialisedInventoryItem && orderShipment.Quantity > salesOrderItem.ReservedFromNonSerialisedInventoryItem.QuantityOnHand + quantityPicked)
                            {
                               validation.AddError($"{orderShipment} {M.OrderShipment.Quantity} {ErrorMessages.SalesOrderItemQuantityToShipNowNotAvailable}");
                            }
                            else if (orderShipment.Quantity > salesOrderItem.QuantityOrdered)
                            {
                                validation.AddError($"{orderShipment} {M.OrderShipment.Quantity} {ErrorMessages.SalesOrderItemQuantityToShipNowIsLargerThanQuantityOrdered}");
                            }
                            else
                            {
                                if (orderShipment.Quantity > salesOrderItem.QuantityOrdered - salesOrderItem.QuantityShipped - pendingFromOthers + salesOrderItem.QuantityReturned + quantityPicked)
                                {
                                    validation.AddError($"{orderShipment} {M.OrderShipment.Quantity} {ErrorMessages.SalesOrderItemQuantityToShipNowIsLargerThanQuantityRemaining}");
                                }
                            }
                        }
                    }
                }

            }
        }

        public static void OrderShipmentRegisterDerivations(this IDatabase @this)
        {
            @this.DomainDerivationById[new Guid("caaa5d25-c0d3-4b45-8785-9b6a12753087")] = new OrderShipmentCreationDerivation();
        }
    }
}
