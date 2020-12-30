// <copyright file="Settings.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    public partial class Settings
    {
        public void AppsOnBuild(ObjectOnBuild method)
        {
            if (!this.ExistNoImageAvailableImage)
            {
                this.NoImageAvailableImage = new MediaBuilder(this.Strategy.Session)
                    .WithInFileName("No_image_available.svg")
                    .WithInData(this.Session().GetSingleton().GetResourceBytes("No_image_available.svg"))
                    .Build();
            }

            if (!this.ExistSkuCounter)
            {
                this.SkuCounter = new CounterBuilder(this.Strategy.Session).Build();
            }

            if (!this.ExistSerialisedItemCounter)
            {
                this.SerialisedItemCounter = new CounterBuilder(this.Strategy.Session).Build();
            }

            if (!this.ExistProductNumberCounter)
            {
                this.ProductNumberCounter = new CounterBuilder(this.Strategy.Session).Build();
            }
        }

        public string NextSkuNumber()
        {
            var skuNumber = this.SkuCounter.NextValue();
            return string.Concat(this.SkuPrefix, skuNumber);
        }

        public string NextSerialisedItemNumber()
        {
            var serialisedItemNumber = this.SerialisedItemCounter.NextValue();
            return string.Concat(this.SerialisedItemPrefix, serialisedItemNumber);
        }

        public string NextProductNumber()
        {
            var productNumber = this.ProductNumberCounter.NextValue();
            return string.Concat(this.ProductNumberPrefix, productNumber);
        }

        public string NextPartNumber()
        {
            var partNumber = this.PartNumberCounter.NextValue();
            return string.Concat(this.ExistPartNumberPrefix ? this.PartNumberPrefix : string.Empty, partNumber);
        }
    }
}
