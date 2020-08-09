import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';

import {
  ContextService,
  TestScope,
  MetaService,
  RefreshService,
  Action,
  NavigationService,
  MediaService,
  Filter,
  FilterDefinition,
  UserId,
  SearchFactory,
} from '@allors/angular/core';
import { PullRequest } from '@allors/protocol/system';
import { TableRow, Table, OverviewService, DeleteService, Sorter } from '@allors/angular/material/core';
import { Person, Organisation, Request, RequestState, Party } from '@allors/domain/generated';
import { And, Equals } from '@allors/data/system';
import { InternalOrganisationId, FetcherService } from '@allors/angular/base';
import { format, formatDistance } from 'date-fns';

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
  internalOrganisation: Organisation;
  canCreate: boolean;

  private subscription: Subscription;
  filter: Filter;

  constructor(
    @Self() public allors: ContextService,

    public metaService: MetaService,
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

    this.delete = deleteService.delete(allors.context);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'number', sort: true },
        { name: 'from' },
        { name: 'state' },
        { name: 'description', sort: true },
        { name: 'responseRequired', sort: true },
        { name: 'lastModifiedDate', sort: true },
      ],
      actions: [overviewService.overview(), this.delete],
      defaultAction: overviewService.overview(),
      pageSize: 50,
      initialSort: 'number',
      initialSortDirection: 'desc',
    });
  }

  ngOnInit(): void {
    const { m, pull, x } = this.metaService;

    const internalOrganisationPredicate = new Equals({ propertyType: m.Request.Recipient });
    const predicate = new And([
      internalOrganisationPredicate,
      new Equals({ propertyType: m.Request.RequestState, parameter: 'state' }),
      new Equals({ propertyType: m.Request.Originator, parameter: 'from' }),
    ]);

    const stateSearch = new SearchFactory({
      objectType: m.RequestState,
      roleTypes: [m.RequestState.Name],
    });

    const originatorSearch = new SearchFactory({
      objectType: m.Party,
      roleTypes: [m.Party.PartyName],
    });

    const filterDefinition = new FilterDefinition(predicate, {
      active: { initialValue: true },
      state: { search: stateSearch, display: (v: RequestState) => v && v.Name },
      from: { search: originatorSearch, display: (v: Party) => v && v.PartyName },
    });
    this.filter = new Filter(filterDefinition);

    const sorter = new Sorter({
      number: m.Request.SortableRequestNumber,
      description: m.Request.Description,
      responseRequired: m.Request.RequiredResponseDate,
      lastModifiedDate: m.Request.LastModifiedDate,
    });

    this.subscription = combineLatest(
      this.refreshService.refresh$,
      this.filter.fields$,
      this.table.sort$,
      this.table.pager$,
      this.internalOrganisationId.observable$
    )
      .pipe(
        scan(
          ([previousRefresh, previousFilterFields], [refresh, filterFields, sort, pageEvent, internalOrganisationId]) => {
            return [
              refresh,
              filterFields,
              sort,
              previousRefresh !== refresh || filterFields !== previousFilterFields ? Object.assign({ pageIndex: 0 }, pageEvent) : pageEvent,
              internalOrganisationId,
            ];
          },
          [, , , , ,]
        ),
        switchMap(([, filterFields, sort, pageEvent, internalOrganisationId]) => {
          internalOrganisationPredicate.object = internalOrganisationId;

          const pulls = [
            this.fetcher.internalOrganisation,
            pull.Person({
              object: this.userId.value,
            }),
            pull.Request({
              predicate,
              sort: sorter.create(sort),
              include: {
                Originator: x,
                RequestState: x,
              },
              parameters: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            }),
          ];

          return this.allors.context.load(new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        this.internalOrganisation = loaded.objects.InternalOrganisation as Organisation;
        this.user = loaded.objects.Person as Person;

        this.canCreate = this.internalOrganisation.CanExecuteCreateRequest;

        const requests = loaded.collections.Requests as Request[];
        this.table.total = loaded.values.Requests_total;
        this.table.data = requests
          .filter((v) => v.CanReadRequestNumber)
          .map((v) => {
            return {
              object: v,
              number: `${v.RequestNumber}`,
              from: v.Originator && v.Originator.displayName,
              state: `${v.RequestState && v.RequestState.Name}`,
              description: `${v.Description || ''}`,
              responseRequired: v.RequiredResponseDate && format(new Date(v.RequiredResponseDate), 'MMM Do YY'),
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