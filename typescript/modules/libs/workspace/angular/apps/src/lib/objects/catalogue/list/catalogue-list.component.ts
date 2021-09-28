import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Good, InternalOrganisation, NonUnifiedGood, Part, PriceComponent, Brand, Model, Locale, Carrier, SerialisedItemCharacteristicType, WorkTask, ContactMechanism, Person, Organisation, PartyContactMechanism, OrganisationContactRelationship, Catalogue, Singleton, ProductCategory, Scope } from '@allors/workspace/domain/default';
import { Action, DeleteService, EditService, Filter, FilterDefinition, MediaService, NavigationService, ObjectData, OverviewService, RefreshService, SaveService, SearchFactory, Sorter, Table, TableRow, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';
import { And } from '@allors/workspace/domain/system';

import { FetcherService } from '../../../services/fetcher/fetcher-service';
import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

interface Row extends TableRow {
  object: Catalogue;
  name: string;
  description: string;
  scope: string;
}

@Component({
  templateUrl: './catalogue-list.component.html',
  providers: [SessionService]
})
export class CataloguesListComponent extends TestScope implements OnInit, OnDestroy {

  public title = 'Catalogues';

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

    this.delete = deleteService.delete(allors);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'name', sort: true },
        { name: 'description', sort: true },
        { name: 'scope', sort: true }
      ],
      actions: [
        this.edit,
        this.delete
      ],
      defaultAction: this.edit,
      pageSize: 50,
    });
  }

  ngOnInit(): void {

    const m = this.allors.workspace.configuration.metaPopulation as M; const { pullBuilder: pull } = m; const x = {};
    this.filter = m.Catalogue.filter = m.Catalogue.filter ?? new Filter(m.Catalogue.filterDefinition);

    const internalOrganisationPredicate = new Equals({ propertyType: m.Catalogue.InternalOrganisation });
    const predicate = new And([
      internalOrganisationPredicate,
      this.filter.definition.predicate
    ]);

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
            pull.Catalogue({
              predicate: predicate,
              sorting: sort ? m.Catalogue.sorter.create(sort) : null,
              include: {
                CatalogueImage: x,
                ProductCategories: x,
                CatScope: x
              },
              arguments: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            })];

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        const objects = loaded.collection<Catalogue>(m.Catalogue);
        this.table.total = loaded.value('Catalogues_total') as number;
        this.table.data = objects.map((v) => {
          return {
            object: v,
            name: `${v.Name}`,
            description: `${v.Description || ''}`,
            scope: v.CatScope.Name
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
