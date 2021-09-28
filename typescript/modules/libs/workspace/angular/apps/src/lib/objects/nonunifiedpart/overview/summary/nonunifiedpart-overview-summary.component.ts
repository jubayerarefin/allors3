import { Component, Self } from '@angular/core';
import { isBefore, isAfter } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import { Part, BasePrice, PriceComponent, SupplierOffering, ProductIdentificationType } from '@allors/workspace/domain/default';
import { NavigationService, PanelService } from '@allors/workspace/angular/base';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'nonunifiedpart-overview-summary',
  templateUrl: './nonunifiedpart-overview-summary.component.html',
  providers: [PanelService]
})
export class NonUnifiedPartOverviewSummaryComponent {

  m: M;

  part: Part;
  serialised: boolean;
  suppliers: string;
  sellingPrice: BasePrice;
  currentPricecomponents: PriceComponent[] = [];
  inactivePricecomponents: PriceComponent[] = [];
  allPricecomponents: PriceComponent[] = [];
  allSupplierOfferings: SupplierOffering[];
  currentSupplierOfferings: SupplierOffering[];
  inactiveSupplierOfferings: SupplierOffering[];
  partnumber: string[];

  constructor(
    @Self() public panel: PanelService,
    
    public navigation: NavigationService,
    ) {

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    panel.name = 'summary';

    const partPullName = `${panel.name}_${this.m.Part.name}`;
    const priceComponentPullName = `${panel.name}_${this.m.PriceComponent.name}`;
    const supplierOfferingsPullName = `${panel.name}_${this.m.SupplierOffering.name}`;

    panel.onPull = (pulls) => {
      const m = this.allors.workspace.configuration.metaPopulation as M; const { pullBuilder: pull } = m; const x = {};

      const id = this.panel.manager.id;

      pulls.push(
        pull.PriceComponent({
          name: priceComponentPullName,
          predicate: { kind: 'Equals', propertyType: m.PriceComponent.Part, objectId: id },
          include: {
            Part: x,
            Currency: x
          },
          sorting: [{ roleType: { roleType: m.PriceComponent.FromDate, descending: true } }]
        }),
        pull.Part({
          name: partPullName,
          objectId: id,
          include: {
            ProductIdentifications: {
              ProductIdentificationType: x
            },
            ProductType: x,
            InventoryItemKind: x,
            ManufacturedBy: x,
            SuppliedBy: x,
            SerialisedItems: {
              PrimaryPhoto: x,
              SerialisedItemState: x,
              OwnedBy: x
            },
            Brand: x,
            Model: x
          }
        }),
        pull.Part({
          name: supplierOfferingsPullName,
          objectId: id,
          select: {
            SupplierOfferingsWherePart: {
              include: {
                Currency: x
              }
            }
          }
        }),
        pull.ProductIdentificationType(),
        );
    };

    panel.onPulled = (loaded) => {
      

      this.part = loaded.objects[partPullName] as Part;
      this.serialised = this.part.InventoryItemKind.UniqueId === '2596e2dd-3f5d-4588-a4a2-167d6fbe3fae';

      this.allPricecomponents = loaded.collections[priceComponentPullName] as PriceComponent[];
      this.currentPricecomponents = this.allPricecomponents.filter(v => isBefore(new Date(v.FromDate), new Date()) && (v.ThroughDate === null || isAfter(new Date(v.ThroughDate), new Date())));
      this.inactivePricecomponents = this.allPricecomponents.filter(v => isAfter(new Date(v.FromDate), new Date()) || (v.ThroughDate !== null && isBefore(new Date(v.ThroughDate), new Date())));

      this.allSupplierOfferings = loaded.collections[supplierOfferingsPullName] as SupplierOffering[];
      this.currentSupplierOfferings = this.allSupplierOfferings.filter(v => isBefore(new Date(v.FromDate), new Date()) && (v.ThroughDate === null || isAfter(new Date(v.ThroughDate), new Date())));
      this.inactiveSupplierOfferings = this.allSupplierOfferings.filter(v => isAfter(new Date(v.FromDate), new Date()) || (v.ThroughDate !== null && isBefore(new Date(v.ThroughDate), new Date())));

      const goodIdentificationTypes = loaded.collection<ProductIdentificationType>(m.ProductIdentificationType);
      const partNumberType = goodIdentificationTypes.find((v) => v.UniqueId === '5735191a-cdc4-4563-96ef-dddc7b969ca6');
      this.partnumber = this.part.ProductIdentifications.filter(v => v.ProductIdentificationType === partNumberType).map(w => w.Identification);

      if (this.part.SuppliedBy.length > 0) {
        this.suppliers = this.part.SuppliedBy
          .map(v => v.displayName)
          .reduce((acc: string, cur: string) => acc + ', ' + cur);
      }
    };
  }
}
