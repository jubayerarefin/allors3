import { Component, OnInit, Self, OnDestroy } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription, combineLatest, BehaviorSubject } from 'rxjs';
import { switchMap, filter } from 'rxjs/operators';

import { M } from '@allors/default/workspace/meta';
import {
  Locale,
  Organisation,
  PriceComponent,
  ProductIdentificationType,
  Facility,
  InventoryItemKind,
  ProductType,
  Brand,
  Model,
  UnitOfMeasure,
  Settings,
  ProductCategory,
  ProductNumber,
  UnifiedGood,
} from '@allors/default/workspace/domain';
import {
  NavigationService,
  PanelService,
  RefreshService,
  ErrorService,
  SearchFactory,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { FetcherService } from '../../../../services/fetcher/fetcher-service';
import { Filters } from '../../../../filters/filters';

@Component({
  selector: 'unifiedgood-overview-detail',
  templateUrl: './unifiedgood-overview-detail.component.html',
  providers: [PanelService, ContextService],
})
export class UnifiedGoodOverviewDetailComponent implements OnInit, OnDestroy {
  readonly m: M;

  good: UnifiedGood;

  facility: Facility;
  facilities: Facility[];
  locales: Locale[];
  inventoryItemKinds: InventoryItemKind[];
  productTypes: ProductType[];
  categories: ProductCategory[];
  suppliers: Organisation[];
  brands: Brand[];
  selectedBrand: Brand;
  models: Model[];
  selectedModel: Model;
  organisations: Organisation[];
  addBrand = false;
  addModel = false;
  goodIdentificationTypes: ProductIdentificationType[];
  productNumber: ProductNumber;
  originalCategories: ProductCategory[] = [];
  selectedCategories: ProductCategory[] = [];
  unitsOfMeasure: UnitOfMeasure[];
  currentSellingPrice: PriceComponent;
  internalOrganisation: Organisation;
  settings: Settings;
  manufacturersFilter: SearchFactory;

  private subscription: Subscription;
  private refresh$: BehaviorSubject<Date>;

  constructor(
    @Self() public allors: ContextService,
    @Self() public panel: PanelService,
    public refreshService: RefreshService,
    public navigationService: NavigationService,
    private errorService: ErrorService,
    private fetcher: FetcherService,
    private snackBar: MatSnackBar
  ) {
    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;
    this.refresh$ = new BehaviorSubject(new Date());

    panel.name = 'detail';
    panel.title = 'Good Details';
    panel.icon = 'person';
    panel.expandable = true;

    // Collapsed
    const pullName = `${this.panel.name}_${this.m.UnifiedGood.tag}`;

    panel.onPull = (pulls) => {
      this.good = undefined;

      if (this.panel.isCollapsed) {
        const m = this.m;
        const { pullBuilder: pull } = m;
        const id = this.panel.manager.id;

        pulls.push(
          pull.UnifiedGood({
            name: pullName,
            objectId: id,
          })
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.good = loaded.object<UnifiedGood>(pullName);
      }
    };
  }

  public ngOnInit(): void {
    const m = this.m;

    // Maximized
    this.subscription = combineLatest(this.refresh$, this.panel.manager.on$)
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {
          this.good = undefined;

          const m = this.m;
          const { pullBuilder: pull } = m;
          const x = {};
          const id = this.panel.manager.id;

          const pulls = [
            this.fetcher.locales,
            this.fetcher.Settings,
            pull.UnifiedGood({
              objectId: id,
              include: {
                PrimaryPhoto: x,
                Photos: x,
                PublicElectronicDocuments: x,
                PrivateElectronicDocuments: x,
                PublicLocalisedElectronicDocuments: x,
                PrivateLocalisedElectronicDocuments: x,
                ManufacturedBy: x,
                SuppliedBy: x,
                DefaultFacility: x,
                SerialisedItemCharacteristics: {
                  LocalisedValues: x,
                  SerialisedItemCharacteristicType: {
                    UnitOfMeasure: x,
                    LocalisedNames: x,
                  },
                },
                ProductIdentifications: {
                  ProductIdentificationType: x,
                },
                Brand: {
                  Models: x,
                },
                Model: x,
                LocalisedNames: {
                  Locale: x,
                },
                LocalisedDescriptions: {
                  Locale: x,
                },
                LocalisedComments: {
                  Locale: x,
                },
                LocalisedKeywords: {
                  Locale: x,
                },
              },
            }),
            pull.UnitOfMeasure({}),
            pull.InventoryItemKind({}),
            pull.ProductIdentificationType({}),
            pull.Facility({}),
            pull.ProductIdentificationType({}),
            pull.ProductType({ sorting: [{ roleType: m.ProductType.Name }] }),
            pull.ProductCategory({
              sorting: [{ roleType: m.ProductCategory.Name }],
            }),
            pull.Brand({
              include: {
                Models: x,
              },
              sorting: [{ roleType: m.Brand.Name }],
            }),
            pull.UnifiedGood({
              name: 'OriginalCategories',
              objectId: id,
              select: {
                ProductCategoriesWhereProduct: {
                  include: {
                    Products: x,
                  },
                },
              },
            }),
          ];

          this.manufacturersFilter = Filters.manufacturersFilter(m);

          return this.allors.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        this.good = loaded.object<UnifiedGood>(m.UnifiedGood);
        this.originalCategories =
          loaded.collection<ProductCategory>('OriginalCategories') ?? [];
        this.selectedCategories = this.originalCategories;

        this.inventoryItemKinds = loaded.collection<InventoryItemKind>(
          m.InventoryItemKind
        );
        this.productTypes = loaded.collection<ProductType>(m.ProductType);
        this.brands = loaded.collection<Brand>(m.Brand);
        this.locales = this.fetcher.getAdditionalLocales(loaded);
        this.facilities = loaded.collection<Facility>(m.Facility);
        this.unitsOfMeasure = loaded.collection<UnitOfMeasure>(m.UnitOfMeasure);
        this.settings = this.fetcher.getSettings(loaded);
        this.goodIdentificationTypes =
          loaded.collection<ProductIdentificationType>(
            m.ProductIdentificationType
          );
        this.categories = loaded.collection<ProductCategory>(m.ProductCategory);

        const goodNumberType = this.goodIdentificationTypes?.find(
          (v) => v.UniqueId === 'b640630d-a556-4526-a2e5-60a84ab0db3f'
        );

        this.productNumber = this.good.ProductIdentifications?.find(
          (v) => v.ProductIdentificationType === goodNumberType
        );

        this.suppliers = this.good.SuppliedBy as Organisation[];

        this.selectedBrand = this.good.Brand;
        this.selectedModel = this.good.Model;

        if (this.selectedBrand) {
          this.brandSelected(this.selectedBrand);
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public brandAdded(brand: Brand): void {
    this.brands.push(brand);
    this.selectedBrand = brand;
    this.models = [];
    this.selectedModel = undefined;
  }

  public modelAdded(model: Model): void {
    this.selectedBrand.addModel(model);
    this.models = this.selectedBrand.Models.sort((a, b) =>
      a.Name > b.Name ? 1 : b.Name > a.Name ? -1 : 0
    );
    this.selectedModel = model;
  }

  public brandSelected(brand: Brand): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Brand({
        object: brand,
        include: {
          Models: x,
        },
      }),
    ];

    this.allors.context.pull(pulls).subscribe(() => {
      this.models = this.selectedBrand.Models.sort((a, b) =>
        a.Name > b.Name ? 1 : b.Name > a.Name ? -1 : 0
      );
    });
  }

  public save(): void {
    this.onSave();

    this.allors.context.push().subscribe(() => {
      this.refreshService.refresh();
      this.panel.toggle();
    });
  }

  public update(): void {
    this.onSave();

    this.allors.context.push().subscribe(() => {
      this.snackBar.open('Successfully saved.', 'close', { duration: 5000 });
      this.refreshService.refresh();
    }, this.errorService.errorHandler);
  }

  private onSave() {
    this.selectedCategories.forEach((category: ProductCategory) => {
      category.addProduct(this.good);

      const index = this.originalCategories.indexOf(category);
      if (index > -1) {
        this.originalCategories.splice(index, 1);
      }
    });

    this.originalCategories.forEach((category: ProductCategory) => {
      category.removeProduct(this.good);
    });

    this.good.Brand = this.selectedBrand;
    this.good.Model = this.selectedModel;
  }
}
