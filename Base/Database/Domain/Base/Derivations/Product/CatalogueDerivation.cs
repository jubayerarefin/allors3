// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Meta;

    public class CatalogueDerivation : DomainDerivation
    {
        public CatalogueDerivation(M m) : base(m, new Guid("7B3BA380-A703-4E29-8D2D-0D2F74C6E7D8")) =>
            this.Patterns = new[]
            {
                new CreatedPattern(M.Catalogue.Class)
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var catalogue in matches.Cast<Catalogue>())
            {
                var defaultLocale = catalogue.Strategy.Session.GetSingleton().DefaultLocale;

                if (catalogue.LocalisedNames.Any(x => x.Locale.Equals(defaultLocale)))
                {
                    catalogue.Name = catalogue.LocalisedNames.First(x => x.Locale.Equals(defaultLocale)).Text;
                }

                if (catalogue.LocalisedDescriptions.Any(x => x.Locale.Equals(defaultLocale)))
                {
                    catalogue.Description = catalogue.LocalisedDescriptions.First(x => x.Locale.Equals(defaultLocale)).Text;
                }

                if (!catalogue.ExistCatalogueImage)
                {
                    catalogue.CatalogueImage = catalogue.Strategy.Session.GetSingleton().Settings.NoImageAvailableImage;
                }
            }
        }
    }
}
