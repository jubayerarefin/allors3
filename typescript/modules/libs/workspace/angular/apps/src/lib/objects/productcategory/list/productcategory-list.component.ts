import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { displayName, ProductCategory } from '@allors/workspace/domain/default';
import { Action, DeleteService, EditService, Filter, MediaService, NavigationService, RefreshService, Table, TableRow, TestScope, OverviewService } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

interface Row extends TableRow {
  object: ProductCategory;
  name: string;
  primaryParent: string;
  secondaryParents: string;
  scope: string;
}

@Component({
  templateUrl: './productcategory-list.component.html',
  providers: [SessionService],
})
export class ProductCategoryListComponent extends TestScope implements OnInit, OnDestroy {
  public title = 'Categories';

  table: Table<Row>;

  edit: Action;
  delete: Action;

  private subscription: Subscription;
  filter: Filter;

  constructor(
    @Self() public allors: SessionService,

    public refreshService: RefreshService,
    public overviewService: OverviewService,
    public editService: EditService,
    public deleteService: DeleteService,
    public navigation: NavigationService,
    public mediaService: MediaService,
    private internalOrganisationId: InternalOrganisationId,
    titleService: Title
  ) {
    super();

    titleService.setTitle(this.title);

    this.edit = editService.edit();
    this.edit.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.delete = deleteService.delete(allors.client, allors.session);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'name', sort: true },
        { name: 'primaryParent', sort: true },
        { name: 'secondaryParents', sort: true },
        { name: 'scope', sort: true },
      ],
      actions: [this.edit, this.delete],
      defaultAction: this.edit,
      pageSize: 50,
    });
  }

  ngOnInit(): void {
    const m = this.allors.workspace.configuration.metaPopulation as M;
    const { pullBuilder: pull } = m;
    const x = {};
    this.filter = m.ProductCategory.filter = m.ProductCategory.filter ?? new Filter(m.ProductCategory.filterDefinition);

    const internalOrganisationPredicate = new Equals({ propertyType: m.ProductCategory.InternalOrganisation });
    const predicate = new And([internalOrganisationPredicate, this.filter.definition.predicate]);

    this.subscription = combineLatest([this.refreshService.refresh$, this.filter.fields$, this.table.sort$, this.table.pager$, this.internalOrganisationId.observable$])
      .pipe(
        scan(([previousRefresh, previousFilterFields], [refresh, filterFields, sort, pageEvent, internalOrganisationId]) => {
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

          return [refresh, filterFields, sort, pageEvent, internalOrganisationId];
        }),
        switchMap(([, filterFields, sort, pageEvent, internalOrganisationId]) => {
          internalOrganisationPredicate.object = internalOrganisationId;

          const pulls = [
            pull.ProductCategory({
              predicate: predicate,
              sorting: sort ? m.ProductCategory.sorter.create(sort) : null,
              include: {
                CategoryImage: x,
                LocalisedNames: x,
                LocalisedDescriptions: x,
                CatScope: x,
                PrimaryParent: {
                  PrimaryAncestors: x,
                },
                SecondaryParents: {
                  PrimaryAncestors: x,
                },
              },
              arguments: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            }),
          ];

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        const objects = loaded.collection<ProductCategory>(m.ProductCategory);
        this.table.total = loaded.value('ProductCategories_total') as number;
        this.table.data = objects.map((v) => {
          return {
            object: v,
            name: v.Name,
            primaryParent: v.PrimaryParent && displayName(v.PrimaryParent),
            secondaryParents: v.SecondaryParents.map((w) => displayName(w)).join(', '),
            scope: v.CatScope.Name,
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
