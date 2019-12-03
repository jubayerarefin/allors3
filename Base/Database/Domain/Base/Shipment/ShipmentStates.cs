// <copyright file="ShipmentStates.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;

    public partial class ShipmentStates
    {
        private static readonly Guid CreatedId = new Guid("854AD6A0-B2D1-4b92-8C3D-E9E72DD19AFD");
        private static readonly Guid PickedId = new Guid("C63C5D25-F139-490f-86D1-2E9E51F5C0A5");
        private static readonly Guid PackedId = new Guid("DCABE845-A6F2-49d9-BBAE-06FB47012A21");
        private static readonly Guid PartiallyShippedId = new Guid("A3B59706-53FE-4DD6-8D10-1762B6352C37");
        private static readonly Guid ShippedId = new Guid("B8B115A4-6E5D-4400-BCA7-4224AE1708AA");
        private static readonly Guid DeliveredId = new Guid("B30666C1-9954-4ae1-8F94-A1591B7E35ED");
        private static readonly Guid ReceivedId = new Guid("28EBB252-4DDB-4B14-80F5-765AE59254A0");
        private static readonly Guid CancelledId = new Guid("1F50B912-C778-4c99-84F9-12DACA1E54C1");
        private static readonly Guid OnHoldId = new Guid("268CB9A7-6965-47E8-AF89-8F915242C23D");

        private UniquelyIdentifiableSticky<ShipmentState> stateCache;

        public ShipmentState Created => this.StateCache[CreatedId];

        public ShipmentState Picked => this.StateCache[PickedId];

        public ShipmentState Packed => this.StateCache[PackedId];

        public ShipmentState PartiallyShipped => this.StateCache[PartiallyShippedId];

        public ShipmentState Shipped => this.StateCache[ShippedId];

        public ShipmentState Delivered => this.StateCache[DeliveredId];

        public ShipmentState Received => this.StateCache[ReceivedId];

        public ShipmentState Cancelled => this.StateCache[CancelledId];

        public ShipmentState OnHold => this.StateCache[OnHoldId];

        private UniquelyIdentifiableSticky<ShipmentState> StateCache => this.stateCache
                                    ?? (this.stateCache = new UniquelyIdentifiableSticky<ShipmentState>(this.Session));

        protected override void BaseSetup(Setup setup)
        {
            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(CreatedId)
                .WithName("Created")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(PickedId)
                .WithName("Picked")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(PackedId)
                .WithName("Packed")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(PartiallyShippedId)
                .WithName("Partially Shipped")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(ShippedId)
                .WithName("Shipped")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(DeliveredId)
                .WithName("Delivered")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(ReceivedId)
                .WithName("Received")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(CancelledId)
                .WithName("Cancelled")
                .Build();

            new ShipmentStateBuilder(this.Session)
                .WithUniqueId(OnHoldId)
                .WithName("On hold")
                .Build();
        }
    }
}
