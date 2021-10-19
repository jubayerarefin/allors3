import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';
import { format, formatDistance } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import { Request, Person, Organisation, InternalOrganisation } from '@allors/workspace/domain/default';
import { Action, DeleteService, Filter, MediaService, NavigationService, RefreshService, Table, TableRow, TestScope, UserId, OverviewService } from '@allors/workspace/angular/base';
import { ContextService } from '@allors/workspace/angular/core';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { FetcherService } from '../../../services/fetcher/fetcher-service';
import { And, Equals } from '@allors/workspace/domain/system';

interface Row extends TableRow {
  object: Request;
  number: string;
  from: string;
  state: string;
  description: string;
  responseRequired: string;
  lastModifiedDate: string;
}

@Component({
  templateUrl: './requestforquote-list.component.html',
  providers: [ContextService],
})
export class RequestForQuoteListComponent extends TestScope implements OnInit, OnDestroy {
  public title = 'Requests';

  delete: Action;

  table: Table<Row>;

  user: Person;
  internalOrganisation: InternalOrganisation;
  canCreate: boolean;

  private subscription: Subscription;
  filter: Filter;
  m: M;

  constructor(
    @Self() public allors: ContextService,
    public refreshService: RefreshService,
    public overviewService: OverviewService,
    public deleteService: DeleteService,
    public navigation: NavigationService,
    public mediaService: MediaService,
    private internalOrganisationId: InternalOrganisationId,
    private userId: UserId,
    private fetcher: FetcherService,
    titleService: Title
  ) {
    super();

    titleService.setTitle(this.title);

    this.m = this.allors.context.configuration.metaPopulation as M;

    this.delete = deleteService.delete(allors.context);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [{ name: 'number', sort: true }, { name: 'from' }, { name: 'state' }, { name: 'description', sort: true }, { name: 'responseRequired', sort: true }, { name: 'lastModifiedDate', sort: true }],
      actions: [overviewService.overview(), this.delete],
      defaultAction: overviewService.overview(),
      pageSize: 50,
      initialSort: 'number',
      initialSortDirection: 'desc',
    });
  }

  ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.filter = m.RequestForQuote._.filter ??= new Filter(m.RequestForQuote._.filterDefinition);

    const internalOrganisationPredicate: Equals = { kind: 'Equals', propertyType: m.Request.Recipient };
    const predicate: And = { kind: 'And', operands: [internalOrganisationPredicate, this.filter.definition.predicate] };

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
          internalOrganisationPredicate.value = internalOrganisationId;

          const pulls = [
            this.fetcher.internalOrganisation,
            pull.Person({
              objectId: this.userId.value,
            }),
            pull.Request({
              predicate,
              sorting: sort ? m.RequestForQuote._.sorter?.create(sort) : null,
              include: {
                Originator: x,
                RequestState: x,
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

         this.internalOrganisation = this.fetcher.getInternalOrganisation(loaded);
        this.user = loaded.object<Person>(m.Person);

        this.canCreate = this.internalOrganisation.canExecuteCreateRequest;

        const requests = loaded.collection<Request>(m.Request);
        this.table.total = loaded.value('Requests_total') as number;
        this.table.data = requests
          .filter((v) => v.canReadRequestNumber)
          .map((v) => {
            return {
              object: v,
              number: `${v.RequestNumber}`,
              from: v.Originator && v.Originator.DisplayName,
              state: `${v.RequestState && v.RequestState.Name}`,
              description: `${v.Description || ''}`,
              responseRequired: v.RequiredResponseDate && format(new Date(v.RequiredResponseDate), 'dd-MM-yyyy'),
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
