// <copyright file="RequestItemBuilderExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.TestPopulation
{
    public static partial class RequestItemBuilderExtensions
    {
        public static RequestItemBuilder WithSerializedDefaults(this RequestItemBuilder @this, Organisation internalOrganisation)
        {
            var faker = @this.Transaction.Faker();

            var finishedGood = new UnifiedGoodBuilder(@this.Transaction).WithSerialisedDefaults(internalOrganisation).Build();

            @this.WithComment(faker.Lorem.Sentence());
            @this.WithInternalComment(faker.Lorem.Sentence());
            @this.WithMaximumAllowedPrice(faker.Random.UInt());
            @this.WithQuantity(1);
            @this.WithProduct(finishedGood);
            @this.WithRequiredByDate(@this.Transaction.Now().AddDays(7));
            @this.WithSerialisedItem(finishedGood.SerialisedItems.First);

            return @this;
        }

        public static RequestItemBuilder WithNonSerializedDefaults(this RequestItemBuilder @this, Organisation internalOrganisation)
        {
            var faker = @this.Transaction.Faker();

            var finishedGood = new UnifiedGoodBuilder(@this.Transaction).WithNonSerialisedDefaults(internalOrganisation).Build();

            @this.WithComment(faker.Lorem.Sentence());
            @this.WithInternalComment(faker.Lorem.Sentence());
            @this.WithMaximumAllowedPrice(faker.Random.UInt());
            @this.WithQuantity(faker.Random.UShort());
            @this.WithProduct(finishedGood);
            @this.WithRequiredByDate(@this.Transaction.Now().AddDays(7));

            return @this;
        }
    }
}
