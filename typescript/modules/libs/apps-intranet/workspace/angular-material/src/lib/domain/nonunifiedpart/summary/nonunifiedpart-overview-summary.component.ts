import { isBefore, isAfter } from 'date-fns';
import { Component, Self } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  ErrorService,
  InvokeService,
  RefreshService,
  SharedPullService,
} from '@allors/base/workspace/angular/foundation';

import { WorkspaceService } from '@allors/base/workspace/angular/foundation';
import {
  AllorsViewSummaryPanelComponent,
  PanelService,
  ScopedService,
} from '@allors/base/workspace/angular/application';
import { AllorsMaterialPanelService } from '@allors/base/workspace/angular-material/application';
import {
  IPullResult,
  Pull,
  SortDirection,
} from '@allors/system/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  BasePrice,
  NonUnifiedGood,
  Part,
  PriceComponent,
  ProductIdentificationType,
  SupplierOffering,
} from '@allors/default/workspace/domain';

@Component({
  selector: 'nonunifiedpart-overview-summary',
  templateUrl: './nonunifiedpart-overview-summary.component.html',
  providers: [
    ScopedService,
    {
      provide: PanelService,
      useClass: AllorsMaterialPanelService,
    },
  ],
})
export class NonUnifiedPartOverviewSummaryComponent extends AllorsViewSummaryPanelComponent {
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
    @Self() scopedService: ScopedService,
    @Self() panelService: PanelService,
    refreshService: RefreshService,
    sharedPullService: SharedPullService,
    workspaceService: WorkspaceService,
    private snackBar: MatSnackBar,
    private invokeService: InvokeService,
    private errorService: ErrorService
  ) {
    super(scopedService, panelService, sharedPullService, refreshService);
    this.m = workspaceService.workspace.configuration.metaPopulation as M;
  }

  onPreSharedPull(pulls: Pull[], prefix?: string) {
    const { m } = this;
    const { pullBuilder: p } = m;

    const id = this.scoped.id;

    pulls.push(
      // TODO: Martien
      // p.PriceComponent({
      //   name: `${prefix}_priceComponent`,
      //   predicate: {
      //     kind: 'Equals',
      //     propertyType: this.m.PriceComponent.Part,
      //     value: id,
      //   },
      //   include: {
      //     Part: {},
      //     Currency: {},
      //   },
      //   sorting: [
      //     {
      //       roleType: m.PriceComponent.FromDate,
      //       sortDirection: SortDirection.Descending,
      //     },
      //   ],
      // }),
      p.Part({
        name: `${prefix}_part`,
        objectId: id,
        include: {
          ProductIdentifications: {
            ProductIdentificationType: {},
          },
          ProductType: {},
          InventoryItemKind: {},
          ManufacturedBy: {},
          SuppliedBy: {},
          SerialisedItems: {
            PrimaryPhoto: {},
            SerialisedItemState: {},
            OwnedBy: {},
          },
          Brand: {},
          Model: {},
        },
      }),
      p.Part({
        name: `${prefix}_supplierOfferings`,
        objectId: id,
        select: {
          SupplierOfferingsWherePart: {
            include: {
              Currency: {},
            },
          },
        },
      }),
      p.ProductIdentificationType({})
    );
  }

  onPostSharedPull(loaded: IPullResult, prefix?: string) {
    this.part = loaded.object<Part>(prefix);
    this.serialised =
      this.part.InventoryItemKind.UniqueId ===
      '2596e2dd-3f5d-4588-a4a2-167d6fbe3fae';

    this.allPricecomponents = loaded.collection<PriceComponent>(
      `${prefix}_priceComponent`
    );
    this.currentPricecomponents = this.allPricecomponents?.filter(
      (v) =>
        isBefore(new Date(v.FromDate), new Date()) &&
        (v.ThroughDate == null || isAfter(new Date(v.ThroughDate), new Date()))
    );
    this.inactivePricecomponents = this.allPricecomponents?.filter(
      (v) =>
        isAfter(new Date(v.FromDate), new Date()) ||
        (v.ThroughDate != null && isBefore(new Date(v.ThroughDate), new Date()))
    );

    this.allSupplierOfferings = loaded.collection<SupplierOffering>(
      `${prefix}_supplierOfferings`
    );
    this.currentSupplierOfferings = this.allSupplierOfferings?.filter(
      (v) =>
        isBefore(new Date(v.FromDate), new Date()) &&
        (v.ThroughDate == null || isAfter(new Date(v.ThroughDate), new Date()))
    );
    this.inactiveSupplierOfferings = this.allSupplierOfferings?.filter(
      (v) =>
        isAfter(new Date(v.FromDate), new Date()) ||
        (v.ThroughDate != null && isBefore(new Date(v.ThroughDate), new Date()))
    );

    const goodIdentificationTypes =
      loaded.collection<ProductIdentificationType>(
        this.m.ProductIdentificationType
      );
    const partNumberType = goodIdentificationTypes?.find(
      (v) => v.UniqueId === '5735191a-cdc4-4563-96ef-dddc7b969ca6'
    );
    this.partnumber = this.part.ProductIdentifications?.filter(
      (v) => v.ProductIdentificationType === partNumberType
    )?.map((w) => w.Identification);

    if (this.part.SuppliedBy.length > 0) {
      this.suppliers = this.part.SuppliedBy?.map((v) => v.DisplayName)?.reduce(
        (acc: string, cur: string) => acc + ', ' + cur
      );
    }
  }
}