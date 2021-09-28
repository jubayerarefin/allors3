import { Component, OnInit, Self, OnDestroy } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, filter } from 'rxjs/operators';

import { MetaService, RefreshService, NavigationService, PanelService, SessionService } from '@allors/angular/services/core';
import {
  Organisation,
  Facility,
  InventoryItemKind,
  ProductType,
  Brand,
  Model,
  ProductIdentificationType,
  UnitOfMeasure,
  PriceComponent,
  Settings,
  Part,
  PartNumber,
  PartCategory,
  Locale,
} from '@allors/domain/generated';
import { SaveService } from '@allors/angular/material/services/core';
import { Meta } from '@allors/meta/generated';
import { FetcherService } from '@allors/angular/base';
import { PullRequest } from '@allors/protocol/system';
import { Sort, Equals } from '@allors/data/system';
import { TestScope } from '@allors/angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'nonunifiedpart-overview-detail',
  templateUrl: './nonunifiedpart-overview-detail.component.html',
  providers: [PanelService, SessionService],
})
export class NonUnifiedPartOverviewDetailComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  part: Part;

  facility: Facility;
  facilities: Facility[];
  locales: Locale[];
  inventoryItemKinds: InventoryItemKind[];
  productTypes: ProductType[];
  manufacturers: Organisation[];
  brands: Brand[];
  selectedBrand: Brand;
  models: Model[];
  selectedModel: Model;
  organisations: Organisation[];
  addBrand = false;
  addModel = false;
  goodIdentificationTypes: ProductIdentificationType[];
  partNumber: PartNumber;
  unitsOfMeasure: UnitOfMeasure[];
  currentSellingPrice: PriceComponent;
  internalOrganisation: Organisation;
  settings: Settings;
  suppliers: string;
  categories: PartCategory[];
  originalCategories: PartCategory[] = [];
  selectedCategories: PartCategory[] = [];

  private subscription: Subscription;

  constructor(
    @Self() public allors: SessionService,
    @Self() public panel: PanelService,
    
    public refreshService: RefreshService,
    public navigationService: NavigationService,
    private saveService: SaveService,
    private snackBar: MatSnackBar,
    private fetcher: FetcherService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    panel.name = 'detail';
    panel.title = 'Part Details';
    panel.icon = 'business';
    panel.expandable = true;

    // Collapsed
    const pullName = `${this.panel.name}_${this.m.Part.name}`;

    panel.onPull = (pulls) => {
      this.part = undefined;
      if (this.panel.isCollapsed) {
        const { pull } = this.metaService;
        const id = this.panel.manager.id;

        pulls.push(
          pull.Part({
            name: pullName,
            objectId: id,
          })
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.part = loaded.objects[pullName] as Part;
      }
    };
  }

  public ngOnInit(): void {
    // Maximized
    this.subscription = combineLatest(this.refreshService.refresh$, this.panel.manager.on$)
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {
          this.part = undefined;

          const { m, pull, x } = this.metaService;
          const id = this.panel.manager.id;

          const pulls = [
            this.fetcher.locales,
            this.fetcher.Settings,
            this.fetcher.warehouses,
            pull.Part({
              objectId: id,
              include: {
                PrimaryPhoto: x,
                Photos: x,
                Documents: x,
                PublicElectronicDocuments: x,
                PrivateElectronicDocuments: x,
                PublicLocalisedElectronicDocuments: x,
                PrivateLocalisedElectronicDocuments: x,
                ManufacturedBy: x,
                SuppliedBy: x,
                DefaultFacility: x,
                PartWeightedAverage: x,
                SerialisedItemCharacteristics: {
                  LocalisedValues: x,
                  SerialisedItemCharacteristicType: {
                    UnitOfMeasure: x,
                    LocalisedNames: x,
                  },
                },
                Brand: {
                  Models: x,
                },
                ProductIdentifications: {
                  ProductIdentificationType: x,
                },
                LocalisedNames: {
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
            pull.Part({
              objectId: id,
              select: {
                PriceComponentsWherePart: x,
              },
            }),
            pull.UnitOfMeasure(),
            pull.InventoryItemKind(),
            pull.ProductIdentificationType(),
            pull.Ownership({ sorting: [{ roleType: m.Ownership.Name }] }),
            pull.ProductType({ sorting: [{ roleType: m.ProductType.Name }] }),
            pull.PartCategory({ sorting: [{ roleType: m.PartCategory.Name }] }),
            pull.Brand({
              include: {
                Models: x,
              },
              sorting: [{ roleType: m.Brand.Name }],
            }),
            pull.Organisation({
              predicate: { kind: 'Equals', propertyType: m.Organisation.IsManufacturer, value: true },
            }),
            pull.NonUnifiedPart({
              name: 'OriginalCategories',
              objectId: id,
              select: { PartCategoriesWherePart: x },
            }),
          ];

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        this.part = loaded.object<Part>(m.Part);
        this.originalCategories = loaded.collection<PartCategory>(m.PartCategory);
        this.selectedCategories = this.originalCategories;

        this.suppliers = this.part.SuppliedBy.map((w) => w.PartyName).join(', ');
        this.inventoryItemKinds = loaded.collection<InventoryItemKind>(m.InventoryItemKind);
        this.productTypes = loaded.collection<ProductType>(m.ProductType);
        this.brands = loaded.collection<Brand>(m.Brand);
        this.locales = loaded.collection<Locale>(m.Locale);
        this.facilities = loaded.collection<Facility>(m.Facility);
        this.unitsOfMeasure = loaded.collection<UnitOfMeasure>(m.UnitOfMeasure);
        this.manufacturers = loaded.collection<Organisation>(m.Organisation);
        this.categories = loaded.collection<PartCategory>(m.PartCategory);
        this.settings = loaded.object<Settings>(m.Settings);

        this.goodIdentificationTypes = loaded.collection<ProductIdentificationType>(m.ProductIdentificationType);
        const partNumberType = this.goodIdentificationTypes.find((v) => v.UniqueId === '5735191a-cdc4-4563-96ef-dddc7b969ca6');

        this.manufacturers = loaded.collection<Organisation>(m.Organisation);

        this.partNumber = this.part.ProductIdentifications.find((v) => v.ProductIdentificationType === partNumberType);

        this.selectedBrand = this.part.Brand;
        this.selectedModel = this.part.Model;

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

  public setDirty(): void {
    this.allors.session.hasChanges = true;
  }

  public brandAdded(brand: Brand): void {
    this.brands.push(brand);
    this.selectedBrand = brand;
    this.models = [];
    this.selectedModel = undefined;
    this.allors.session.hasChanges = true;
    this.setDirty();
  }

  public modelAdded(model: Model): void {
    this.selectedBrand.AddModel(model);
    this.models = this.selectedBrand.Models.sort((a, b) => (a.Name > b.Name ? 1 : b.Name > a.Name ? -1 : 0));
    this.selectedModel = model;
    this.allors.session.hasChanges = true;
    this.setDirty();
  }

  public brandSelected(brand: Brand): void {
    const m = this.m; const { pullBuilder: pull } = m; const x = {};

    const pulls = [
      pull.Brand({
        object: brand,
        include: {
          Models: x,
        },
      }),
    ];

    this.allors.client.pullReactive(this.allors.session, pulls).subscribe(() => {
      this.models = this.selectedBrand?.Models.sort((a, b) => (a.Name > b.Name ? 1 : b.Name > a.Name ? -1 : 0));
    });

    this.setDirty();
  }

  public save(): void {
    this.onSave();

    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      this.panel.toggle();
    }, this.saveService.errorHandler);
  }

  public update(): void {
    const { context } = this.allors;

    this.onSave();

    context.save().subscribe(() => {
      this.snackBar.open('Successfully saved.', 'close', { duration: 5000 });
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  private onSave() {
    this.selectedCategories.forEach((category: PartCategory) => {
      category.AddPart(this.part);

      const index = this.originalCategories.indexOf(category);
      if (index > -1) {
        this.originalCategories.splice(index, 1);
      }
    });

    this.originalCategories.forEach((category: PartCategory) => {
      category.RemovePart(this.part);
    });

    this.part.Brand = this.selectedBrand;
    this.part.Model = this.selectedModel;
  }
}
