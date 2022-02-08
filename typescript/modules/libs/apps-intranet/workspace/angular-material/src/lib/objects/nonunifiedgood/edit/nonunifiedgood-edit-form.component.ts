import { Component, Self } from '@angular/core';
import { NgForm } from '@angular/forms';

import {
  EditIncludeHandler,
  Node,
  CreateOrEditPullHandler,
  Pull,
  IPullResult,
  PostCreatePullHandler,
} from '@allors/system/workspace/domain';
import {
  BasePrice,
  InternalOrganisation,
  NonUnifiedGood,
} from '@allors/default/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  ErrorService,
  AllorsFormComponent,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { FetcherService } from '../../../../services/fetcher/fetcher-service';
import { Filters } from '../../../../filters/filters';

@Component({
  selector: 'nonunifiedgood-edit-form',
  templateUrl: './nonunifiedgood-edit-form.component.html',
  providers: [OldPanelService, ContextService],
})
export class NonUnifiedGoodEditFormComponent
  extends AllorsFormComponent<NonUnifiedGood>
  implements CreateOrEditPullHandler, EditIncludeHandler, PostCreatePullHandler
{
  readonly m: M;

  good: NonUnifiedGood;

  locales: Locale[];
  categories: ProductCategory[];
  productTypes: ProductType[];
  manufacturers: Organisation[];
  brands: Brand[];
  selectedBrand: Brand;
  models: Model[];
  selectedModel: Model;
  ownerships: Ownership[];
  organisations: Organisation[];
  addBrand = false;
  addModel = false;
  goodIdentificationTypes: ProductIdentificationType[];
  productNumber: ProductNumber;
  originalCategories: ProductCategory[] = [];
  selectedCategories: ProductCategory[] = [];
  productFeatureApplicabilities: ProductFeatureApplicability[];
  productDimensions: ProductDimension[];

  private subscription: Subscription;
  private refresh$: BehaviorSubject<Date>;

  nonUnifiedPartsFilter: SearchFactory;

  constructor(
    @Self() public allors: ContextService,
    errorService: ErrorService,
    form: NgForm,
    private fetcher: FetcherService
  ) {
    super(allors, errorService, form);

    panel.onPull = (pulls) => {
      this.good = undefined;

      if (this.panel.isCollapsed) {
        const m = this.m;
        const { pullBuilder: pull } = m;
        const x = {};
        const id = this.panel.manager.id;

        pulls.push(
          pull.NonUnifiedGood({
            name: pullName,
            objectId: id,
            include: {
              ProductIdentifications: {
                ProductIdentificationType: x,
              },
              Part: {
                Brand: x,
                Model: x,
              },
            },
          }),
          pull.ProductCategory({
            sorting: [{ roleType: m.ProductCategory.Name }],
          })
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.good = loaded.object<NonUnifiedGood>(pullName);
      }
    };
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    // Maximized
    this.subscription = combineLatest([this.refresh$, this.panel.manager.on$])
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {
          this.good = undefined;

          const id = this.panel.manager.id;

          const pulls = [
            this.fetcher.locales,
            pull.ProductIdentificationType({}),
            pull.ProductCategory({
              include: { Products: x },
              sorting: [{ roleType: m.ProductCategory.Name }],
            }),
            pull.NonUnifiedGood({
              objectId: id,
              include: {
                Part: {
                  Brand: x,
                  Model: x,
                },
                PrimaryPhoto: x,
                ProductIdentifications: x,
                Photos: x,
                PublicElectronicDocuments: x,
                PrivateElectronicDocuments: x,
                PublicLocalisedElectronicDocuments: x,
                PrivateLocalisedElectronicDocuments: x,
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
            pull.NonUnifiedGood({
              name: 'OriginalCategories',
              objectId: id,
              select: { ProductCategoriesWhereProduct: x },
            }),
            pull.NonUnifiedGood({
              objectId: id,
              select: {
                ProductFeatureApplicabilitiesWhereAvailableFor: {
                  include: {
                    ProductFeature: {
                      ProductDimension_Dimension: {
                        UnitOfMeasure: x,
                      },
                    },
                  },
                },
              },
            }),
          ];

          this.nonUnifiedPartsFilter = Filters.nonUnifiedPartsFilter(m);

          return this.allors.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        this.good = loaded.object<NonUnifiedGood>(m.NonUnifiedGood);
        this.originalCategories =
          loaded.collection<ProductCategory>('OriginalCategories');
        this.selectedCategories = this.originalCategories;

        this.categories = loaded.collection<ProductCategory>(m.ProductCategory);
        this.goodIdentificationTypes =
          loaded.collection<ProductIdentificationType>(
            m.ProductIdentificationType
          );
        this.locales = this.fetcher.getAdditionalLocales(loaded);
        this.productFeatureApplicabilities =
          loaded.collection<ProductFeatureApplicability>(
            m.NonUnifiedGood.ProductFeatureApplicabilitiesWhereAvailableFor
          );
        this.productDimensions = this.productFeatureApplicabilities
          ?.map((v) => v.ProductFeature)
          .filter(
            (v) => v.strategy.cls === this.m.ProductDimension
          ) as ProductDimension[];

        const goodNumberType = this.goodIdentificationTypes?.find(
          (v) => v.UniqueId === 'b640630d-a556-4526-a2e5-60a84ab0db3f'
        );

        this.productNumber = this.good.ProductIdentifications?.find(
          (v) => v.ProductIdentificationType === goodNumberType
        );
      });
  }

  public save(): void {
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

    super.save();
  }
}
