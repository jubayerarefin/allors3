import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';
import { formatDistance } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import { Person, Organisation, InternalOrganisation, PurchaseOrder } from '@allors/workspace/domain/default';
import { Action, DeleteService, Filter, MediaService, MethodService, NavigationService, RefreshService, Table, TableRow, TestScope, UserId, OverviewService } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { PrintService } from '../../../actions/print/print.service';
import { FetcherService } from '../../../services/fetcher/fetcher-service';

interface Row extends TableRow {
  object: PurchaseOrder;
  number: string;
  supplier: string;
  state: string;
  shipmentState: string;
  customerReference: string;
  invoice: string;
  currency: string;
  totalExVat: string;
  totalIncVat: string;
  lastModifiedDate: string;
}

@Component({
  templateUrl: './purchaseorder-list.component.html',
  providers: [SessionService],
})
export class PurchaseOrderListComponent extends TestScope implements OnInit, OnDestroy {
  public title = 'Purchase Orders';

  m: M;

  table: Table<Row>;

  delete: Action;
  print: Action;
  ship: Action;
  invoice: Action;

  user: Person;
  internalOrganisation: Organisation;
  canCreate: boolean;

  private subscription: Subscription;
  filter: Filter;

  constructor(
    @Self() public allors: SessionService,

    public refreshService: RefreshService,
    public overviewService: OverviewService,
    public printService: PrintService,
    public methodService: MethodService,
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

    this.print = printService.print();
    this.delete = deleteService.delete(allors.client, allors.session);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'number', sort: true },
        { name: 'supplier' },
        { name: 'state' },
        { name: 'shipmentState' },
        { name: 'customerReference', sort: true },
        { name: 'invoice' },
        { name: 'currency' },
        { name: 'totalExVat', sort: true },
        { name: 'totalIncVat', sort: true },
        { name: 'lastModifiedDate', sort: true },
      ],
      actions: [overviewService.overview(), this.delete, this.print],
      defaultAction: overviewService.overview(),
      pageSize: 50,
      initialSort: 'number',
      initialSortDirection: 'desc',
    });
  }

  ngOnInit(): void {
    const m = this.allors.workspace.configuration.metaPopulation as M;
    const { pullBuilder: pull } = m;
    const x = {};
    this.filter = m.PurchaseOrder.filter = m.PurchaseOrder.filter ?? new Filter(m.PurchaseOrder.filterDefinition);

    const internalOrganisationPredicate = new Equals({ propertyType: m.PurchaseOrder.OrderedBy });

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
            this.fetcher.internalOrganisation,
            pull.Person({
              object: this.userId.value,
            }),
            pull.PurchaseOrder({
              predicate,
              sorting: sort ? m.PurchaseOrder.sorter.create(sort) : null,
              include: {
                PrintDocument: {
                  Media: x,
                },
                TakenViaSupplier: x,
                PurchaseOrderState: x,
                PurchaseOrderShipmentState: x,
                PurchaseInvoicesWherePurchaseOrder: x,
                DerivedCurrency: x,
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

        this.internalOrganisation = loaded.object<Organisation>(m.InternalOrganisation);
        this.user = loaded.object<Person>(m.Person);

        this.canCreate = this.internalOrganisation.canExecuteCreatePurchaseOrder;

        const orders = loaded.collection<PurchaseOrder>(m.PurchaseOrder);
        this.table.total = loaded.value('PurchaseOrders_total') as number;
        this.table.data = orders
          .filter((v) => v.canReadOrderNumber)
          .map((v) => {
            return {
              object: v,
              number: `${v.OrderNumber}`,
              supplier: v.TakenViaSupplier && v.TakenViaSupplier.displayName,
              state: `${v.PurchaseOrderState && v.PurchaseOrderState.Name}`,
              shipmentState: `${v.PurchaseOrderShipmentState && v.PurchaseOrderShipmentState.Name}`,
              customerReference: `${v.Description || ''}`,
              invoice: v.PurchaseInvoicesWherePurchaseOrder.map((w) => w.InvoiceNumber).join(', '),
              currency: `${v.DerivedCurrency && v.DerivedCurrency.IsoCode}`,
              totalExVat: v.TotalExVat,
              totalIncVat: v.TotalIncVat,
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
