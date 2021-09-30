import { Component, OnDestroy, OnInit, Self, Optional, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { NonUnifiedGood, Organisation, ProductIdentificationType, ProductType, Settings, Good, ProductCategory, Ownership, ProductNumber, Locale } from '@allors/workspace/domain/default';
import { NavigationService, ObjectData, RefreshService, SaveService, SearchFactory, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';

import { FetcherService } from '../../../services/fetcher/fetcher-service';
import { Filters } from '../../../filters/filters';

@Component({
  templateUrl: './nonunifiedgood-create.component.html',
  providers: [SessionService],
})
export class NonUnifiedGoodCreateComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;
  good: Good;

  public title = 'Add Good';

  locales: Locale[];
  categories: ProductCategory[];
  productTypes: ProductType[];
  manufacturers: Organisation[];
  ownerships: Ownership[];
  organisations: Organisation[];
  goodIdentificationTypes: ProductIdentificationType[];
  productNumber: ProductNumber;
  selectedCategories: ProductCategory[] = [];
  settings: Settings;
  goodNumberType: ProductIdentificationType;

  private subscription: Subscription;

  nonUnifiedPartsFilter: SearchFactory;

  constructor(
    @Self() public allors: SessionService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<NonUnifiedGoodCreateComponent>,

    private refreshService: RefreshService,
    public navigationService: NavigationService,
    private saveService: SaveService,
    private fetcher: FetcherService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(() => {
          const pulls = [this.fetcher.locales, this.fetcher.internalOrganisation, this.fetcher.Settings, pull.ProductIdentificationType({}), pull.ProductCategory({ sorting: [{ roleType: m.ProductCategory.Name }] })];

          this.nonUnifiedPartsFilter = Filters.nonUnifiedPartsFilter(m);

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        this.categories = loaded.collection<ProductCategory>(m.ProductCategory);
        this.goodIdentificationTypes = loaded.collection<ProductIdentificationType>(m.ProductIdentificationType);
        this.locales = loaded.collection<Locale>(m.Locale);
        this.settings = loaded.object<Settings>(m.Settings);

        this.goodNumberType = this.goodIdentificationTypes.find((v) => v.UniqueId === 'b640630d-a556-4526-a2e5-60a84ab0db3f');

        this.good = this.allors.session.create<NonUnifiedGood>(m.NonUnifiedGood);

        if (!this.settings.UseProductNumberCounter) {
          this.productNumber = this.allors.session.create<ProductNumber>(m.ProductNumber);
          this.productNumber.ProductIdentificationType = this.goodNumberType;

          this.good.addProductIdentification(this.productNumber);
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.selectedCategories.forEach((category: ProductCategory) => {
      category.addProduct(this.good);
    });

    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      this.dialogRef.close(this.good);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }
}
