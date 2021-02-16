// <copyright file="PurchaseOrderItemBuilderExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>

namespace Allors.Database.Domain.TestPopulation
{
    public static partial class PurchaseOrderItemBuilderExtensions
    {
        public static PurchaseOrderItemBuilder WithSerializedPartDefaults(this PurchaseOrderItemBuilder @this, Part unifiedGood, SerialisedItem serialisedItem)
        {
            var faker = @this.Transaction.Faker();

            @this.WithDescription(faker.Lorem.Sentences(2));
            @this.WithComment(faker.Lorem.Sentence());
            @this.WithInternalComment(faker.Lorem.Sentence());
            @this.WithInvoiceItemType(new InvoiceItemTypes(@this.Transaction).ProductItem);
            @this.WithPart(unifiedGood);
            @this.WithAssignedUnitPrice(faker.Random.UInt(5, 10));
            @this.WithSerialisedItem(serialisedItem);
            @this.WithQuantityOrdered(1);
            @this.WithAssignedDeliveryDate(@this.Transaction.Now().AddDays(5));
            @this.WithShippingInstruction(faker.Lorem.Sentences(3));
            @this.WithMessage(faker.Lorem.Sentence());

            return @this;
        }

        public static PurchaseOrderItemBuilder WithNonSerializedPartDefaults(this PurchaseOrderItemBuilder @this, Part nonUnifiedPart)
        {
            var faker = @this.Transaction.Faker();

            @this.WithDescription(faker.Lorem.Sentences(2));
            @this.WithInvoiceItemType(new InvoiceItemTypes(@this.Transaction).PartItem);
            @this.WithPart(nonUnifiedPart);
            @this.WithAssignedUnitPrice(faker.Random.UInt(5, 10));
            @this.WithQuantityOrdered(faker.Random.UInt(5, 15));
            @this.WithAssignedDeliveryDate(@this.Transaction.Now().AddDays(5));
            @this.WithShippingInstruction(faker.Lorem.Sentences(3));
            @this.WithComment(faker.Lorem.Sentence());
            @this.WithInternalComment(faker.Lorem.Sentence());
            @this.WithMessage(faker.Lorem.Sentence());

            return @this;
        }
    }
}
