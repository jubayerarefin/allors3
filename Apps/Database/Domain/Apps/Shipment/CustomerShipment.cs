// <copyright file="CustomerShipment.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public partial class CustomerShipment
    {
        // TODO: Cache
        public TransitionalConfiguration[] TransitionalConfigurations => new[] {
            new TransitionalConfiguration(this.M.CustomerShipment, this.M.CustomerShipment.ShipmentState),
        };

        public bool CanShip
        {
            get
            {
                if (!this.ShipmentState.Equals(new ShipmentStates(this.Strategy.Transaction).Packed))
                {
                    return false;
                }

                var picklists = this.ShipToParty?.PickListsWhereShipToParty;
                picklists?.Filter.AddEquals(this.M.PickList.Store, this.Store);
                picklists?.Filter.AddNot().AddEquals(this.M.PickList.PickListState, new PickListStates(this.Strategy.Transaction).Picked);
                if (picklists?.First != null)
                {
                    return false;
                }

                foreach (ShipmentItem shipmentItem in this.ShipmentItems)
                {
                    foreach (OrderShipment orderShipment in shipmentItem.OrderShipmentsWhereShipmentItem)
                    {
                        if (orderShipment.OrderItem is SalesOrderItem salesOrderItem
                            && salesOrderItem.SalesOrderWhereSalesOrderItem.SalesOrderState.Equals(new SalesOrderStates(this.Strategy.Transaction).OnHold))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        public string ShortShipDateString => this.EstimatedShipDate?.ToString("d");

        public PickList PendingPickList
        {
            get
            {
                var pickLists = this.ShipToParty.PickListsWhereShipToParty;
                pickLists.Filter.AddEquals(this.M.PickList.Store, this.Store);
                pickLists.Filter.AddNot().AddEquals(this.M.PickList.PickListState, new PickListStates(this.Transaction()).Picked);

                return pickLists.FirstOrDefault();
            }
        }

        public void AppsOnBuild(ObjectOnBuild method)
        {
            if (!this.ExistShipmentState)
            {
                this.ShipmentState = new ShipmentStates(this.Strategy.Transaction).Created;
            }

            if (!this.ExistReleasedManually)
            {
                this.ReleasedManually = false;
            }

            if (!this.ExistHeldManually)
            {
                this.HeldManually = false;
            }

            if (!this.ExistWithoutCharges)
            {
                this.WithoutCharges = false;
            }
        }

        public void AppsOnInit(ObjectOnInit method)
        {

            if (!this.ExistShipFromParty)
            {
                var internalOrganisations = new Organisations(this.Strategy.Transaction).InternalOrganisations();
                if (internalOrganisations.Count() == 1)
                {
                    this.ShipFromParty = internalOrganisations.First();
                }
            }

            if (!this.ExistStore && this.ExistShipFromParty)
            {
                var stores = new Stores(this.Strategy.Transaction).Extent();
                stores.Filter.AddEquals(this.M.Store.InternalOrganisation, this.ShipFromParty);

                if (stores.Any())
                {
                    this.Store = stores.First;
                }
            }

            if (!this.ExistShipFromFacility && this.ExistShipFromParty)
            {
                this.ShipFromFacility = ((InternalOrganisation)this.ShipFromParty).FacilitiesWhereOwner.FirstOrDefault();
            }

            if (!this.ExistEstimatedShipDate)
            {
                this.EstimatedShipDate = this.Transaction().Now().Date;
            }

            if (!this.ExistCarrier && this.ExistStore)
            {
                this.Carrier = this.Store.DefaultCarrier;
            }
        }

        public void AppsOnPostDerive(ObjectOnPostDerive method) => method.Derivation.Validation.AssertExists(this, this.M.CustomerShipment.ShipToParty);

        public void AppsCancel(CustomerShipmentCancel method) => this.ShipmentState = new ShipmentStates(this.Strategy.Transaction).Cancelled;

        public void AppsPick(CustomerShipmentPick method)
        {
            if (!method.Overridden)
            {
                this.CreatePickList();

                foreach (ShipmentItem shipmentItem in this.ShipmentItems)
                {
                    shipmentItem.ShipmentItemState = new ShipmentItemStates(this.Transaction()).Picking;
                }

                this.ShipmentState = new ShipmentStates(this.Strategy.Transaction).Picking;
            }
        }

        public void AppsHold(CustomerShipmentHold method)
        {
            this.HeldManually = true;
            this.PutOnHold();
        }

        public void AppsPutOnHold(CustomerShipmentPutOnHold method) => this.ShipmentState = new ShipmentStates(this.Strategy.Transaction).OnHold;

        public void AppsContinue(CustomerShipmentContinue method)
        {
            this.ReleasedManually = true;
            this.ProcessOnContinue();
        }

        public void AppsProcessOnContinue(CustomerShipmentProcessOnContinue method) => this.ShipmentState = this.ExistPreviousShipmentState ? this.PreviousShipmentState : new ShipmentStates(this.Strategy.Transaction).Created;

        public void AppsSetPicked(CustomerShipmentSetPicked method) => this.ShipmentState = new ShipmentStates(this.Strategy.Transaction).Picked;

        public void AppsSetPacked(CustomerShipmentSetPacked method) => this.ShipmentState = new ShipmentStates(this.Strategy.Transaction).Packed;

        public void AppsShip(CustomerShipmentShip method)
        {
            if (this.CanShip)
            {
                this.ShipmentState = new ShipmentStates(this.Strategy.Transaction).Shipped;
                this.EstimatedShipDate = this.Transaction().Now().Date;

                foreach (ShipmentItem shipmentItem in this.ShipmentItems)
                {
                    shipmentItem.ShipmentItemState = new ShipmentItemStates(this.Transaction()).Shipped;

                    foreach (OrderShipment orderShipment in shipmentItem.OrderShipmentsWhereShipmentItem)
                    {
                        foreach (SalesOrderItemInventoryAssignment salesOrderItemInventoryAssignment in ((SalesOrderItem)orderShipment.OrderItem).SalesOrderItemInventoryAssignments)
                        {
                            // Quantity is used to calculate QuantityReserved (via inventoryItemTransactions)
                            salesOrderItemInventoryAssignment.Quantity -= orderShipment.Quantity;
                        }
                    }

                    foreach (InventoryItem inventoryItem in shipmentItem.ReservedFromInventoryItems)
                    {
                        if (inventoryItem.Part.InventoryItemKind.IsSerialised)
                        {
                            new InventoryItemTransactionBuilder(this.Transaction())
                                .WithPart(shipmentItem.Part)
                                .WithSerialisedItem(shipmentItem.SerialisedItem)
                                .WithUnitOfMeasure(inventoryItem.Part.UnitOfMeasure)
                                .WithFacility(inventoryItem.Facility)
                                .WithReason(new InventoryTransactionReasons(this.Strategy.Transaction).OutgoingShipment)
                                .WithSerialisedInventoryItemState(new SerialisedInventoryItemStates(this.Transaction()).Good)
                                .WithQuantity(1)
                                .Build();
                        }
                        else
                        {
                            new InventoryItemTransactionBuilder(this.Transaction())
                                .WithPart(inventoryItem.Part)
                                .WithUnitOfMeasure(inventoryItem.Part.UnitOfMeasure)
                                .WithFacility(inventoryItem.Facility)
                                .WithReason(new InventoryTransactionReasons(this.Strategy.Transaction).OutgoingShipment)
                                .WithQuantity(shipmentItem.Quantity)
                                .WithCost(inventoryItem.Part.PartWeightedAverage.AverageCost)
                                .Build();
                        }
                    }
                }
            }
        }

        public void AppsInvoice(CustomerShipmentInvoice method)
        {
            if (this.ShipmentState.Equals(new ShipmentStates(this.Strategy.Transaction).Shipped) &&
                   Equals(this.Store.BillingProcess, new BillingProcesses(this.Strategy.Transaction).BillingForShipmentItems))
            {
                var invoiceByOrder = new Dictionary<SalesOrder, SalesInvoice>();
                var costsInvoiced = false;

                foreach (ShipmentItem shipmentItem in this.ShipmentItems)
                {
                    foreach (OrderShipment orderShipment in shipmentItem.OrderShipmentsWhereShipmentItem)
                    {
                        var salesOrder = orderShipment.OrderItem.OrderWhereValidOrderItem as SalesOrder;

                        if (!invoiceByOrder.TryGetValue(salesOrder, out var salesInvoice))
                        {
                            salesInvoice = new SalesInvoiceBuilder(this.Strategy.Transaction)
                                .WithStore(salesOrder.Store)
                                .WithBilledFrom(salesOrder.TakenBy)
                                .WithAssignedBilledFromContactMechanism(salesOrder.DerivedTakenByContactMechanism)
                                .WithBilledFromContactPerson(salesOrder.TakenByContactPerson)
                                .WithBillToCustomer(salesOrder.BillToCustomer)
                                .WithAssignedBillToContactMechanism(salesOrder.DerivedBillToContactMechanism)
                                .WithBillToContactPerson(salesOrder.BillToContactPerson)
                                .WithBillToEndCustomer(salesOrder.BillToEndCustomer)
                                .WithAssignedBillToEndCustomerContactMechanism(salesOrder.DerivedBillToEndCustomerContactMechanism)
                                .WithBillToEndCustomerContactPerson(salesOrder.BillToEndCustomerContactPerson)
                                .WithShipToCustomer(salesOrder.ShipToCustomer)
                                .WithAssignedShipToAddress(salesOrder.DerivedShipToAddress)
                                .WithShipToContactPerson(salesOrder.ShipToContactPerson)
                                .WithShipToEndCustomer(salesOrder.ShipToEndCustomer)
                                .WithAssignedShipToEndCustomerAddress(salesOrder.DerivedShipToEndCustomerAddress)
                                .WithShipToEndCustomerContactPerson(salesOrder.ShipToEndCustomerContactPerson)
                                .WithInvoiceDate(this.Transaction().Now())
                                .WithSalesChannel(salesOrder.SalesChannel)
                                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Strategy.Transaction).SalesInvoice)
                                .WithAssignedVatRegime(salesOrder.DerivedVatRegime)
                                .WithAssignedIrpfRegime(salesOrder.DerivedIrpfRegime)
                                .WithCustomerReference(salesOrder.CustomerReference)
                                .WithAssignedPaymentMethod(this.PaymentMethod)
                                .Build();

                            invoiceByOrder.Add(salesOrder, salesInvoice);

                            foreach (OrderAdjustment orderAdjustment in salesOrder.OrderAdjustments)
                            {
                                OrderAdjustment newAdjustment = null;
                                if (orderAdjustment.GetType().Name.Equals(typeof(DiscountAdjustment).Name))
                                {
                                    newAdjustment = new DiscountAdjustmentBuilder(this.Transaction()).Build();
                                }

                                if (orderAdjustment.GetType().Name.Equals(typeof(SurchargeAdjustment).Name))
                                {
                                    newAdjustment = new SurchargeAdjustmentBuilder(this.Transaction()).Build();
                                }

                                if (orderAdjustment.GetType().Name.Equals(typeof(Fee).Name))
                                {
                                    newAdjustment = new FeeBuilder(this.Transaction()).Build();
                                }

                                if (orderAdjustment.GetType().Name.Equals(typeof(ShippingAndHandlingCharge).Name))
                                {
                                    newAdjustment = new ShippingAndHandlingChargeBuilder(this.Transaction()).Build();
                                }

                                if (orderAdjustment.GetType().Name.Equals(typeof(MiscellaneousCharge).Name))
                                {
                                    newAdjustment = new MiscellaneousChargeBuilder(this.Transaction()).Build();
                                }

                                newAdjustment.Amount ??= orderAdjustment.Amount;
                                newAdjustment.Percentage ??= orderAdjustment.Percentage;
                                salesInvoice.AddOrderAdjustment(newAdjustment);
                            }

                            if (!costsInvoiced)
                            {
                                var costs = this.AppsOnDeriveShippingAndHandlingCharges();
                                if (costs > 0)
                                {
                                    salesInvoice.AddOrderAdjustment(new ShippingAndHandlingChargeBuilder(this.Strategy.Transaction).WithAmount(costs).Build());
                                    costsInvoiced = true;
                                }
                            }

                            foreach (SalesTerm salesTerm in salesOrder.SalesTerms)
                            {
                                if (salesTerm.GetType().Name == typeof(IncoTerm).Name)
                                {
                                    salesInvoice.AddSalesTerm(new IncoTermBuilder(this.Strategy.Transaction)
                                        .WithTermType(salesTerm.TermType)
                                        .WithTermValue(salesTerm.TermValue)
                                        .WithDescription(salesTerm.Description)
                                        .Build());
                                }

                                if (salesTerm.GetType().Name == typeof(InvoiceTerm).Name)
                                {
                                    salesInvoice.AddSalesTerm(new InvoiceTermBuilder(this.Strategy.Transaction)
                                        .WithTermType(salesTerm.TermType)
                                        .WithTermValue(salesTerm.TermValue)
                                        .WithDescription(salesTerm.Description)
                                        .Build());
                                }

                                if (salesTerm.GetType().Name == typeof(OrderTerm).Name)
                                {
                                    salesInvoice.AddSalesTerm(new OrderTermBuilder(this.Strategy.Transaction)
                                        .WithTermType(salesTerm.TermType)
                                        .WithTermValue(salesTerm.TermValue)
                                        .WithDescription(salesTerm.Description)
                                        .Build());
                                }
                            }
                        }

                        var amountAlreadyInvoiced = shipmentItem.ShipmentItemBillingsWhereShipmentItem.Sum(v => v.Amount);
                        var leftToInvoice = (orderShipment.OrderItem.QuantityOrdered * orderShipment.OrderItem.AssignedUnitPrice) - amountAlreadyInvoiced;

                        if (leftToInvoice > 0)
                        {
                            if (orderShipment.OrderItem is SalesOrderItem salesOrderItem)
                            {
                                var invoiceItem = new SalesInvoiceItemBuilder(this.Strategy.Transaction)
                                    .WithInvoiceItemType(new InvoiceItemTypes(this.Strategy.Transaction).ProductItem)
                                    .WithProduct(salesOrderItem.Product)
                                    .WithQuantity(orderShipment.Quantity)
                                    .WithAssignedUnitPrice(salesOrderItem.UnitPrice)
                                    .WithAssignedVatRegime(salesOrderItem.AssignedVatRegime)
                                    .WithDescription(salesOrderItem.Description)
                                    .WithInternalComment(salesOrderItem.InternalComment)
                                    .WithMessage(salesOrderItem.Message)
                                    .Build();

                                salesInvoice.AddSalesInvoiceItem(invoiceItem);

                                new ShipmentItemBillingBuilder(this.Strategy.Transaction)
                                    .WithQuantity(shipmentItem.Quantity)
                                    .WithAmount(leftToInvoice)
                                    .WithShipmentItem(shipmentItem)
                                    .WithInvoiceItem(invoiceItem)
                                    .Build();
                            }
                        }
                    }
                }
            }
        }

        public void AppsOnDeriveShipmentValue(IDerivation derivation)
        {
            //var shipmentValue = 0M;
            //foreach (ShipmentItem shipmentItem in this.ShipmentItems)
            //{
            //    foreach (OrderShipment orderShipment in shipmentItem.OrderShipmentsWhereShipmentItem)
            //    {
            //        shipmentValue += orderShipment.Quantity * orderShipment.OrderItem.UnitPrice;
            //    }
            //}

            //this.ShipmentValue = shipmentValue;
        }

        public void AppsOnDeriveCurrentObjectState(IDerivation derivation)
        {
            //if (this.ExistShipmentState && !this.ShipmentState.Equals(this.LastShipmentState) &&
            //    this.ShipmentState.Equals(new ShipmentStates(this.Strategy.Transaction).Shipped))
            //{
            //    if (Equals(this.Store.BillingProcess, new BillingProcesses(this.Strategy.Transaction).BillingForShipmentItems))
            //    {
            //        this.Invoice();
            //    }
            //}
        }

        public void AppsOnDeriveQuantityDecreased(ShipmentItem shipmentItem, SalesOrderItem orderItem, decimal correction)
        {
            var remainingCorrection = correction;

            var inventoryAssignment = orderItem.SalesOrderItemInventoryAssignments.FirstOrDefault();
            if (inventoryAssignment != null)
            {
                inventoryAssignment.Quantity = orderItem.QuantityCommittedOut - correction;
            }

            foreach (OrderShipment orderShipment in shipmentItem.OrderShipmentsWhereShipmentItem)
            {
                if (orderShipment.OrderItem.Equals(orderItem) && remainingCorrection > 0)
                {
                    decimal quantity;
                    if (orderShipment.Quantity < remainingCorrection)
                    {
                        quantity = orderShipment.Quantity;
                        remainingCorrection -= quantity;
                    }
                    else
                    {
                        quantity = remainingCorrection;
                        remainingCorrection = 0;
                    }

                    shipmentItem.Quantity -= quantity;

                    var itemIssuanceCorrection = quantity;
                    foreach (ItemIssuance itemIssuance in shipmentItem.ItemIssuancesWhereShipmentItem)
                    {
                        decimal subQuantity;
                        if (itemIssuance.Quantity < itemIssuanceCorrection)
                        {
                            subQuantity = itemIssuance.Quantity;
                            itemIssuanceCorrection -= quantity;
                        }
                        else
                        {
                            subQuantity = itemIssuanceCorrection;
                            itemIssuanceCorrection = 0;
                        }

                        itemIssuance.Quantity -= subQuantity;

                        if (itemIssuanceCorrection == 0)
                        {
                            break;
                        }
                    }
                }
            }

            if (shipmentItem.Quantity == 0)
            {
                foreach (OrderShipment orderShipment in shipmentItem.OrderShipmentsWhereShipmentItem)
                {
                    foreach (ItemIssuance itemIssuance in orderShipment.ShipmentItem.ItemIssuancesWhereShipmentItem)
                    {
                        if (!itemIssuance.PickListItem.PickListWherePickListItem.ExistPicker && itemIssuance.Quantity == 0)
                        {
                            itemIssuance.Delete();
                        }
                    }

                    orderShipment.Delete();
                }

                shipmentItem.Delete();
            }

            if (!this.ExistShipmentItems)
            {
                this.Cancel();

                if (this.PendingPickList != null)
                {
                    this.PendingPickList.Cancel();
                }
            }
        }

        private void CreatePickList()
        {
            if (this.ExistShipmentItems && this.ExistShipToParty)
            {
                var pickList = new PickListBuilder(this.Strategy.Transaction).WithShipToParty(this.ShipToParty).WithStore(this.Store).Build();

                foreach (var shipmentItem in this.ShipmentItems
                    .Where(v => v.ShipmentItemState.Equals(new ShipmentItemStates(this.Transaction()).Created)
                                || v.ShipmentItemState.Equals(new ShipmentItemStates(this.Transaction()).Picking)))
                {
                    var quantityIssued = 0M;
                    foreach (ItemIssuance itemIssuance in shipmentItem.ItemIssuancesWhereShipmentItem)
                    {
                        quantityIssued += itemIssuance.Quantity;
                    }

                    var quantityToIssue = shipmentItem.Quantity - quantityIssued;
                    if (quantityToIssue == 0)
                    {
                        return;
                    }

                    var unifiedGood = shipmentItem.Good as UnifiedGood;
                    var nonUnifiedGood = shipmentItem.Good as NonUnifiedGood;
                    var serialized = unifiedGood?.InventoryItemKind.Equals(new InventoryItemKinds(this.Transaction()).Serialised);
                    var part = unifiedGood ?? nonUnifiedGood?.Part;

                    var facilities = ((InternalOrganisation)this.ShipFromParty).FacilitiesWhereOwner;
                    var inventoryItems = part.InventoryItemsWherePart.Where(v => facilities.Contains(v.Facility));
                    SerialisedInventoryItem issuedFromSerializedInventoryItem = null;

                    foreach (InventoryItem inventoryItem in shipmentItem.ReservedFromInventoryItems)
                    {
                        // shipment item originates from sales order. Sales order item has only 1 ReservedFromInventoryItem.
                        // Foreach loop wil execute once.
                        var pickListItem = new PickListItemBuilder(this.Strategy.Transaction)
                            .WithInventoryItem(inventoryItem)
                            .WithQuantity(quantityToIssue)
                            .Build();

                        new ItemIssuanceBuilder(this.Strategy.Transaction)
                            .WithInventoryItem(pickListItem.InventoryItem)
                            .WithShipmentItem(shipmentItem)
                            .WithQuantity(pickListItem.Quantity)
                            .WithPickListItem(pickListItem)
                            .Build();

                        pickList.AddPickListItem(pickListItem);

                        if (serialized.HasValue && serialized.Value)
                        {
                            issuedFromSerializedInventoryItem = (SerialisedInventoryItem)inventoryItem;
                        }
                    }

                    // shipment item is not linked to sales order item
                    if (!shipmentItem.ExistReservedFromInventoryItems)
                    {
                        var quantityLeftToIssue = quantityToIssue;
                        foreach (var inventoryItem in inventoryItems)
                        {
                            if (serialized.HasValue && serialized.Value && quantityLeftToIssue > 0)
                            {
                                var serializedInventoryItem = (SerialisedInventoryItem)inventoryItem;
                                if (serializedInventoryItem.AvailableToPromise == 1)
                                {
                                    var pickListItem = new PickListItemBuilder(this.Strategy.Transaction)
                                        .WithInventoryItem(inventoryItem)
                                        .WithQuantity(quantityLeftToIssue)
                                        .Build();

                                    new ItemIssuanceBuilder(this.Strategy.Transaction)
                                        .WithInventoryItem(inventoryItem)
                                        .WithShipmentItem(shipmentItem)
                                        .WithQuantity(pickListItem.Quantity)
                                        .WithPickListItem(pickListItem)
                                        .Build();

                                    pickList.AddPickListItem(pickListItem);
                                    quantityLeftToIssue = 0;
                                    issuedFromSerializedInventoryItem = serializedInventoryItem;
                                }
                            }
                            else if (quantityLeftToIssue > 0)
                            {
                                var nonSerializedInventoryItem = (NonSerialisedInventoryItem)inventoryItem;
                                var quantity = quantityLeftToIssue > nonSerializedInventoryItem.AvailableToPromise
                                    ? nonSerializedInventoryItem.AvailableToPromise
                                    : quantityLeftToIssue;

                                if (quantity > 0)
                                {
                                    var pickListItem = new PickListItemBuilder(this.Strategy.Transaction)
                                        .WithInventoryItem(inventoryItem)
                                        .WithQuantity(quantity)
                                        .Build();

                                    new ItemIssuanceBuilder(this.Strategy.Transaction)
                                        .WithInventoryItem(inventoryItem)
                                        .WithShipmentItem(shipmentItem)
                                        .WithQuantity(pickListItem.Quantity)
                                        .WithPickListItem(pickListItem)
                                        .Build();

                                    shipmentItem.AddReservedFromInventoryItem(inventoryItem);

                                    pickList.AddPickListItem(pickListItem);
                                    quantityLeftToIssue -= pickListItem.Quantity;
                                }
                            }
                        }
                    }
                }
            }
        }

        private decimal AppsOnDeriveShippingAndHandlingCharges()
        {
            var charges = 0M;

            if (!this.WithoutCharges)
            {
                foreach (ShippingAndHandlingComponent shippingAndHandlingComponent in new ShippingAndHandlingComponents(this.Strategy.Transaction).Extent())
                {
                    if (shippingAndHandlingComponent.FromDate <= this.Transaction().Now() &&
                        (!shippingAndHandlingComponent.ExistThroughDate || shippingAndHandlingComponent.ThroughDate >= this.Transaction().Now()))
                    {
                        if (ShippingAndHandlingComponents.AppsIsEligible(shippingAndHandlingComponent, this))
                        {
                            if (shippingAndHandlingComponent.Cost.HasValue)
                            {
                                if (charges == 0 || shippingAndHandlingComponent.Cost < charges)
                                {
                                    charges = shippingAndHandlingComponent.Cost.Value;
                                }
                            }
                        }
                    }
                }
            }

            return charges;
        }
    }
}
