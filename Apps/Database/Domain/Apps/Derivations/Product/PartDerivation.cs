// <copyright file="PartDerivation.cs" company="Allors bvba">
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

    public class PartDerivation : DomainDerivation
    {
        public PartDerivation(M m) : base(m, new Guid("4F894B49-4922-4FC8-9172-DC600CCDB1CA")) =>
            this.Patterns = new Pattern[]
            {
                new AssociationPattern(m.Part.Name),
                new AssociationPattern(m.Part.DefaultFacility),
                new AssociationPattern(m.Part.UnitOfMeasure),
                new AssociationPattern(m.Part.ProductType),
                new RolePattern(m.InventoryItem.Part),
                new AssociationPattern(m.ProductType.SerialisedItemCharacteristicTypes) { Steps = new IPropertyType[]{ this.M.ProductType.PartsWhereProductType } },
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var m = cycle.Transaction.Database.Context().M;

            foreach (var @this in matches.Cast<Part>())
            {
                if (cycle.ChangeSet.HasChangedRoles(@this, new RoleType[] { m.Part.UnitOfMeasure, m.Part.DefaultFacility }))
                {
                    if (@this.InventoryItemKind.IsNonSerialised)
                    {
                        var inventoryItems = @this.InventoryItemsWherePart;

                        if (!inventoryItems.Any(i => i.ExistFacility && i.Facility.Equals(@this.DefaultFacility)
                                                    && i.ExistUnitOfMeasure && i.UnitOfMeasure.Equals(@this.UnitOfMeasure)))
                        {
                            var inventoryItem = (InventoryItem)new NonSerialisedInventoryItemBuilder(@this.Strategy.Transaction)
                              .WithFacility(@this.DefaultFacility)
                              .WithUnitOfMeasure(@this.UnitOfMeasure)
                              .WithPart(@this)
                              .Build();
                        }
                    }
                }

                var characteristicsToDelete = @this.SerialisedItemCharacteristics.ToList();

                if (@this.ExistProductType)
                {
                    foreach (SerialisedItemCharacteristicType characteristicType in @this.ProductType.SerialisedItemCharacteristicTypes)
                    {
                        var characteristic = @this.SerialisedItemCharacteristics.FirstOrDefault(v => Equals(v.SerialisedItemCharacteristicType, characteristicType));
                        if (characteristic == null)
                        {
                            @this.AddSerialisedItemCharacteristic(
                                                        new SerialisedItemCharacteristicBuilder(@this.Strategy.Transaction)
                                                            .WithSerialisedItemCharacteristicType(characteristicType)
                                                            .Build());
                        }
                        else
                        {
                            characteristicsToDelete.Remove(characteristic);
                        }
                    }
                }

                foreach (var characteristic in characteristicsToDelete)
                {
                    @this.RemoveSerialisedItemCharacteristic(characteristic);
                }

                @this.SetDisplayName();

                foreach (InventoryItem inventoryItem in @this.InventoryItemsWherePart)
                {
                    inventoryItem.Sync(@this);
                }
            }
        }
    }
}
