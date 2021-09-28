import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';
import { formatDistance } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import { ProductCategory, UnifiedGood } from '@allors/workspace/domain/default';
import { Action, DeleteService, Filter, MediaService, NavigationService, ObjectService, RefreshService, Table, TableRow, TestScope, OverviewService } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';

interface Row extends TableRow {
  object: UnifiedGood;
  name: string;
  id: string;
  categories: string;
  qoh: string;
  photos: string;
  lastModifiedDate: string;
}

@Component({
  templateUrl: './unifiedgood-list.component.html',
  providers: [SessionService],
})
export class UnifiedGoodListComponent extends TestScope implements OnInit, OnDestroy {
  public title = 'Unified Goods';

  table: Table<Row>;

  delete: Action;

  private subscription: Subscription;
  filter: Filter;

  constructor(
    @Self() public allors: SessionService,

    public factoryService: ObjectService,
    public refreshService: RefreshService,
    public overviewService: OverviewService,
    public deleteService: DeleteService,
    public navigation: NavigationService,
    public mediaService: MediaService,
    titleService: Title
  ) {
    super();

    titleService.setTitle(this.title);

    this.delete = deleteService.delete(allors.client, allors.session);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [{ name: 'name', sort: true }, { name: 'id', sort: true }, { name: 'photos' }, { name: 'categories' }, { name: 'qoh' }, { name: 'lastModifiedDate', sort: true }],
      actions: [overviewService.overview(), this.delete],
      defaultAction: overviewService.overview(),
      pageSize: 50,
    });
  }

  public ngOnInit(): void {
    const m = this.allors.workspace.configuration.metaPopulation as M;
    const { pullBuilder: pull } = m;
    const { angularMetaService: a } = this.allors.workspace.services;
    const angularUnifiedGood = a.for(m.UnifiedGood);

    this.filter = angularUnifiedGood.filter ??= new Filter(angularUnifiedGood.filterDefinition);

    this.subscription = combineLatest([this.refreshService.refresh$, this.filter.fields$, this.table.sort$, this.table.pager$])
      .pipe(
        scan(([previousRefresh, previousFilterFields], [refresh, filterFields, sort, pageEvent]) => {
          pageEvent =
            previousRefresh !== refresh || filterFields !== previousFilterFields
              ? {
                  ...pageEvent,
                  pageIndex: 0,
                }
              : pageEvent;

          if (pageEvent.pageIndex === 0) {
            this.table.pageIndex = 0;
          }

          return [refresh, filterFields, sort, pageEvent];
        }),
        switchMap(([, filterFields, sort, pageEvent]) => {
          const pulls = [
            pull.UnifiedGood({
              predicate: this.filter.definition.predicate,
              sorting: sort ? a.for(m.UnifiedGood).sorter?.create(sort) : null,
              include: {
                Photos: {},
                PrimaryPhoto: {},
                ProductIdentifications: {
                  ProductIdentificationType: {},
                },
              },
              arguments: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            }),
            pull.UnifiedGood({
              predicate: this.filter.definition.predicate,
              sorting: sort ? a.for(m.UnifiedGood).sorter?.create(sort) : null,
              select: {
                ProductCategoriesWhereProduct: {
                  include: {
                    Products: {},
                    PrimaryAncestors: {},
                  },
                },
              },
            }),
          ];

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        const goods = loaded.collection<UnifiedGood>(m.UnifiedGood);
        const productCategories = loaded.collection<ProductCategory>(m.ProductCategory);

        this.table.total = loaded.value('UnifiedGoods_total') as number;
        this.table.data = goods.map((v) => {
          return {
            object: v,
            name: v.Name,
            id: v.ProductNumber,
            categories: productCategories
              .filter((w) => w.Products.includes(v))
              .map((w) => w.DisplayName)
              .join(', '),
            qoh: v.QuantityOnHand,
            photos: v.Photos.length.toString(),
            lastModifiedDate: formatDistance(new Date(v.LastModifiedDate), new Date()),
          } as Row;
        });
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
