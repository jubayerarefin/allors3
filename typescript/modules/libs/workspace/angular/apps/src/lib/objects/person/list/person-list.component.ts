import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';
import { formatDistance } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import { Person } from '@allors/workspace/domain/default';
import { Action, DeleteService, Filter, MediaService, NavigationService, ObjectService, OverviewService, RefreshService, Table, TableRow, TestScope } from '@allors/workspace/angular/base';
import { ContextService } from '@allors/workspace/angular/core';

interface Row extends TableRow {
  object: Person;
  name: string;
  email: string;
  phone: string;
  isCustomer: string;
  lastModifiedDate: string;
}

@Component({
  templateUrl: './person-list.component.html',
  providers: [{ provide: 'dependencies', useValue: 'person-list' }, ContextService],
})
export class PersonListComponent extends TestScope implements OnInit, OnDestroy {
  public title = 'People';

  table: Table<Row>;

  delete: Action;

  private subscription: Subscription;
  filter: Filter;
  m: M;

  constructor(
    @Self() public allors: ContextService,
    public factoryService: ObjectService,
    public refreshService: RefreshService,
    public overviewService: OverviewService,
    public deleteService: DeleteService,
    public navigation: NavigationService,
    public mediaService: MediaService,
    titleService: Title
  ) {
    super();

    const { session, workspace } = this.allors.context;
    session.dependencies = 'person-list';
    session.activate([workspace.rules.find((v) => v.id === '93d61e576fb14e898abcf0b06b8fcd34')]);

    titleService.setTitle(this.title);

    this.m = this.allors.context.configuration.metaPopulation as M;

    this.delete = deleteService.delete(allors.context);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [{ name: 'name', sort: true }, { name: 'email' }, { name: 'phone' }, 'isCustomer', { name: 'lastModifiedDate', sort: true }],
      actions: [overviewService.overview(), this.delete],
      defaultAction: overviewService.overview(),
      pageSize: 50,
      initialSort: 'name',
    });
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.filter = m.Person._.filter ??= new Filter(m.Person._.filterDefinition);

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
            pull.Person({
              predicate: this.filter.definition.predicate,
              sorting: sort ? m.Person._.sorter?.create(sort) : null,
              include: {
                Salutation: x,
                Picture: x,
                PartyContactMechanisms: {
                  ContactMechanism: {
                    PostalAddress_Country: x,
                  },
                },
              },
              arguments: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            }),
          ];

          return this.allors.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        const people = loaded.collection<Person>(m.Person);
        this.table.total = loaded.value('People_total') as number;
        this.table.data = people.map((v) => {
          return {
            object: v,
            name: v.DisplayName,
            email: v.DisplayEmail,
            phone: v.DisplayPhone,
            isCustomer: v.CustomerRelationshipsWhereCustomer.length > 0 ? 'Yes' : 'No',
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
