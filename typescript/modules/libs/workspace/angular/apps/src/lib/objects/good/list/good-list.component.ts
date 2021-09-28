import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { NonUnifiedGood, Good, ProductCategory } from '@allors/workspace/domain/default';
import { Action, DeleteService, Filter, MediaService, NavigationService, ObjectService, RefreshService, Table, TableRow, TestScope, OverviewService } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';


interface Row extends TableRow {
  object: Good;
  name: string;
  id: string;
  categories: string;
  qoh: string;
}

@Component({
  templateUrl: './good-list.component.html',
  providers: [SessionService],
})
export class GoodListComponent extends TestScope implements OnInit, OnDestroy {
  public title = 'Goods';

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
    titleService: Title,
  ) {
    super();

    titleService.setTitle(this.title);

    this.delete = deleteService.delete(allors);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [{ name: 'name', sort: true }, { name: 'id' }, { name: 'categories' }, { name: 'qoh' }],
      actions: [overviewService.overview(), this.delete],
      defaultAction: overviewService.overview(),
      pageSize: 50,
    });
  }

  public ngOnInit(): void {
    const m = this.allors.workspace.configuration.metaPopulation as M; const { pullBuilder: pull } = m; const x = {};
    this.filter = m.Good.filter = m.Good.filter ?? new Filter(m.Good.filterDefinition);

    this.subscription = combineLatest([this.refreshService.refresh$, this.filter.fields$, this.table.sort$, this.table.pager$])
      .pipe(
        scan(
          ([previousRefresh, previousFilterFields], [refresh, filterFields, sort, pageEvent]) => {
            return [
              refresh,
              filterFields,
              sort,
              previousRefresh !== refresh || filterFields !== previousFilterFields ? Object.assign({ pageIndex: 0 }, pageEvent) : pageEvent,
            ];
          },
          [, , , , ,],
        ),
        switchMap(([, filterFields, sort, pageEvent]) => {
          const pulls = [
            pull.Good({
              predicate: this.filter.definition.predicate,
              sorting: sort ? m.Good.sorter.create(sort) : null,
              include: {
                NonUnifiedGood_Part: x,
                ProductIdentifications: {
                  ProductIdentificationType: x,
                },
              },
              arguments: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            }),
            pull.Good({
              predicate: this.filter.definition.predicate,
              sorting: sort ? m.Good.sorter.create(sort) : null,
              select: {
                ProductCategoriesWhereProduct: {
                  include: {
                    Products: x,
                    PrimaryAncestors: x,
                  },
                },
              },
            }),
          ];

          return this.allors.client.pullReactive(this.allors.session, pulls);
        }),
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        const goods = loaded.collection<Good>(m.Good);
        const productCategories = loaded.collection<ProductCategory>(m.ProductCategory);

        this.table.total = loaded.value('NonUnifiedGoods_total') as number;
        this.table.data = goods.map((v) => {
          return {
            object: v,
            name: v.Name,
            id: v.ProductIdentifications.find((p) => p.ProductIdentificationType.UniqueId === 'b640630d-a556-4526-a2e5-60a84ab0db3f')
              .Identification,
            categories: productCategories
              .filter((w) => w.Products.includes(v))
              .map((w) => w.displayName)
              .join(', '),
            // qoh: v.Part && v.Part.QuantityOnHand
            qoh: ((v as NonUnifiedGood).Part && (v as NonUnifiedGood).Part.QuantityOnHand) || (v as UnifiedGood).QuantityOnHand,
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
