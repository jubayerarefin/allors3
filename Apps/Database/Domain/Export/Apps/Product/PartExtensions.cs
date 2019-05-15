// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartExtensions.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Allors.Domain
{
    public static class PartExtensions
    {
        public static string PartIdentification(this Part @this)
        {
            if (@this.ProductIdentifications.Count == 0)
            {
                return null;
            }

            var partId = @this.ProductIdentifications.FirstOrDefault(g => g.ExistProductIdentificationType
                                                                         && g.ProductIdentificationType.Equals(new ProductIdentificationTypes(@this.Strategy.Session).Part));

            var goodId = @this.ProductIdentifications.FirstOrDefault(g => g.ExistProductIdentificationType
                                                                          && g.ProductIdentificationType.Equals(new ProductIdentificationTypes(@this.Strategy.Session).Good));

            var id = partId ?? goodId;
            return id?.Identification;
        }

        public static PriceComponent[] GetPriceComponents(this Part @this, PriceComponent[] currentPriceComponents)
        {
            var genericPriceComponents = currentPriceComponents.Where(priceComponent => !priceComponent.ExistPart && !priceComponent.ExistProduct && !priceComponent.ExistProductFeature).ToArray();

            var exclusivePartPriceComponents = currentPriceComponents.Where(priceComponent => priceComponent.Part?.Equals(@this) == true).ToArray();

            if (exclusivePartPriceComponents.Length > 0)
            {
                return exclusivePartPriceComponents.Union(genericPriceComponents).ToArray();
            }

            return genericPriceComponents;
        }
    }
}