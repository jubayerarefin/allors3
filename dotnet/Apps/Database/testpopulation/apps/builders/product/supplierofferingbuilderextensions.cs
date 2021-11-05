// <copyright file="UnifiedGoodBuilderExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.TestPopulation
{
    using System;

    public static partial class SupplierOfferingBuilderExtensions
    {
        public static SupplierOfferingBuilder WithDefaults(this SupplierOfferingBuilder @this, Party supplier)
        {
            var faker = @this.Transaction.Faker();

            var unitsOfMeasure = new UnitsOfMeasure(@this.Transaction).Extent().ToArray();
            var currencies = new Currencies(@this.Transaction).Extent().ToArray();

            @this.WithSupplier(supplier)
                 .WithFromDate(faker.Date.Recent().Date)
                 .WithUnitOfMeasure(faker.PickRandom(unitsOfMeasure))
                 .WithPrice(Math.Round(faker.Random.Decimal(1M, 100M), 2))
                 .WithCurrency(faker.PickRandom(currencies));

            return @this;
        }
    }
}
