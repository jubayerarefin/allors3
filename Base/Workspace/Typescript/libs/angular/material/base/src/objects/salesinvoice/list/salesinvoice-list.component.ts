import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';
import { format, formatDistance } from 'date-fns';

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
  SearchFactory,
  UserId,
  ActionTarget,
} from '@allors/angular/core';
import { PullRequest } from '@allors/protocol/system';
import { TableRow, Table, OverviewService, DeleteService, Sorter, MethodService, AllorsMaterialDialogService } from '@allors/angular/material/core';
import { Person, Organisation, Quote, QuoteState, Party, SalesInvoice, PaymentApplication, Receipt, Disbursement, SalesInvoiceType, SalesInvoiceState, Product, SerialisedItem } from '@allors/domain/generated';
import { And, Equals, ContainedIn, Extent } from '@allors/data/system';
import { InternalOrganisationId, FetcherService, PrintService } from '@allors/angular/base';

import { MatSnackBar } from '@angular/material/snack-bar';
import { Meta } from '@allors/meta/generated';


interface Row extends TableRow {
  object: SalesInvoice;
  number: string;
  type: string;
  billedTo: string;
  state: string;
  invoiceDate: string;
  description: string;
  totalExVat: string;
  totalIncVat: string;
  lastModifiedDate: string;
}

@Component({
  templateUrl: './salesinvoice-list.component.html',
  providers: [ContextService]
})
export class SalesInvoiceListComponent extends TestScope implements OnInit, OnDestroy {

  readonly m: Meta;

  public title = 'Sales Invoices';

  table: Table<Row>;

  delete: Action;
  print: Action;
  send: Action;
  cancel: Action;
  writeOff: Action;
  copy: Action;
  credit: Action;
  reopen: Action;
  setPaid: Action;

  user: Person;
  internalOrganisation: Organisation;
  canCreate: boolean;

  private subscription: Subscription;
  filter: Filter;

  constructor(
    @Self() public allors: ContextService,
    
    public metaService: MetaService,
    public methodService: MethodService,
    public printService: PrintService,
    public overviewService: OverviewService,
    public deleteService: DeleteService,
    public navigation: NavigationService,
    public mediaService: MediaService,
    public refreshService: RefreshService,
    public dialogService: AllorsMaterialDialogService,
    public snackBar: MatSnackBar,
    private internalOrganisationId: InternalOrganisationId,
    private userId: UserId,
    private fetcher: FetcherService,
    titleService: Title
  ) {
    super();

    titleService.setTitle(this.title);
    this.m = this.metaService.m;

    this.print = printService.print();
    this.send = methodService.create(allors.context, this.m.SalesInvoice.Send, { name: 'Send' });
    this.cancel = methodService.create(allors.context, this.m.SalesInvoice.CancelInvoice, { name: 'Cancel' });
    this.writeOff = methodService.create(allors.context, this.m.SalesInvoice.WriteOff, { name: 'WriteOff' });
    this.copy = methodService.create(allors.context, this.m.SalesInvoice.Copy, { name: 'Copy' });
    this.credit = methodService.create(allors.context, this.m.SalesInvoice.Credit, { name: 'Credit' });
    this.reopen = methodService.create(allors.context, this.m.SalesInvoice.Reopen, { name: 'Reopen' });

    this.delete = deleteService.delete(allors.context);
    this.delete.result.subscribe((v) => {
      this.table.selection.clear();
    });

    this.setPaid = {
      name: 'setaspaid',
      displayName: () => 'Set as Paid',
      description: () => '',
      disabled: (target: ActionTarget) => {
        if (Array.isArray(target)) {
          const anyDisabled = (target as SalesInvoice[]).filter(v => !v.CanExecuteSetPaid);
          return target.length > 0 ? anyDisabled.length > 0 : true;
        } else {
          return !(target as SalesInvoice).CanExecuteSetPaid;
        }
      },
      execute: (target: SalesInvoice) => {

        const invoices = Array.isArray(target) ? target as SalesInvoice[] : [target as SalesInvoice];
        const targets = invoices.filter((v) => v.CanExecuteSetPaid);

        if (targets.length > 0) {
          dialogService
            .prompt({ title: `Set Payment Date`, placeholder: `Payment date`, promptType: `date` })
            .subscribe((paymentDate: string) => {
              if (paymentDate) {
                targets.forEach((salesinvoice) => {
                  const amountToPay = parseFloat(salesinvoice.TotalIncVat) - parseFloat(salesinvoice.AmountPaid);

                  if (salesinvoice.SalesInvoiceType.UniqueId === '92411bf1-835e-41f8-80af-6611efce5b32' ||
                    salesinvoice.SalesInvoiceType.UniqueId === 'ef5b7c52-e782-416d-b46f-89c8c7a5c24d') {

                    const paymentApplication = this.allors.context.create('PaymentApplication') as PaymentApplication;
                    paymentApplication.Invoice = salesinvoice;
                    paymentApplication.AmountApplied = amountToPay.toString();

                    // sales invoice
                    if (salesinvoice.SalesInvoiceType.UniqueId === '92411bf1-835e-41f8-80af-6611efce5b32') {
                      const receipt = this.allors.context.create('Receipt') as Receipt;
                      receipt.Amount = amountToPay.toString();
                      receipt.EffectiveDate = paymentDate;
                      receipt.Sender = salesinvoice.BilledFrom;
                      receipt.AddPaymentApplication(paymentApplication);
                    }

                    // credit note
                    if (salesinvoice.SalesInvoiceType.UniqueId === 'ef5b7c52-e782-416d-b46f-89c8c7a5c24d') {
                      const disbursement = this.allors.context.create('Disbursement') as Disbursement;
                      disbursement.Amount = amountToPay.toString();
                      disbursement.EffectiveDate = paymentDate;
                      disbursement.Sender = salesinvoice.BilledFrom;
                      disbursement.AddPaymentApplication(paymentApplication);
                    }
                  }
                });

                this.allors.context.save()
                  .subscribe(() => {
                    snackBar.open('Successfully set to fully paid.', 'close', { duration: 5000 });
                    refreshService.refresh();
                  });
              }
            });
        }
      },
      result: null
    };

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'number', sort: true },
        { name: 'type', sort: true },
        { name: 'billedTo' },
        { name: 'invoiceDate', sort: true },
        { name: 'state' },
        { name: 'description', sort: true },
        { name: 'totalExVat', sort: true },
        { name: 'totalIncVat', sort: true },
        { name: 'lastModifiedDate', sort: true },
      ],
      actions: [
        overviewService.overview(),
        this.delete,
        this.print,
        this.cancel,
        this.writeOff,
        this.copy,
        this.credit,
        this.reopen,
        this.setPaid
      ],
      defaultAction: overviewService.overview(),
      pageSize: 50,
      initialSort: 'number',
      initialSortDirection: 'desc',
    });
  }

  public ngOnInit(): void {

    const { m, pull, x } = this.metaService;

    const internalOrganisationPredicate = new Equals({ propertyType: m.SalesInvoice.BilledFrom });
    const predicate = new And([
      internalOrganisationPredicate,
      new Equals({ propertyType: m.SalesInvoice.SalesInvoiceType, parameter: 'type' }),
      new Equals({ propertyType: m.SalesInvoice.InvoiceNumber, parameter: 'number' }),
      new Equals({ propertyType: m.SalesInvoice.CustomerReference, parameter: 'customerReference' }),
      new Equals({ propertyType: m.SalesInvoice.SalesInvoiceState, parameter: 'state' }),
      new Equals({ propertyType: m.SalesInvoice.ShipToCustomer, parameter: 'shipTo' }),
      new Equals({ propertyType: m.SalesInvoice.BillToCustomer, parameter: 'billTo' }),
      new Equals({ propertyType: m.SalesInvoice.ShipToEndCustomer, parameter: 'shipToEndCustomer' }),
      new Equals({ propertyType: m.SalesInvoice.BillToEndCustomer, parameter: 'billToEndCustomer' }),
      new Equals({ propertyType: m.SalesInvoice.IsRepeating, parameter: 'repeating' }),
      new ContainedIn({
        propertyType: m.SalesInvoice.SalesInvoiceItems,
        extent: new Extent({
          objectType: m.SalesInvoiceItem,
          predicate: new ContainedIn({
            propertyType: m.SalesInvoiceItem.Product,
            parameter: 'product'
          })
        })
      }),
      new ContainedIn({
        propertyType: m.SalesInvoice.SalesInvoiceItems,
        extent: new Extent({
          objectType: m.SalesInvoiceItem,
          predicate: new ContainedIn({
            propertyType: m.SalesInvoiceItem.SerialisedItem,
            parameter: 'serialisedItem'
          })
        })
      })
    ]);

    const typeSearch = new SearchFactory({
      objectType: m.SalesInvoiceType,
      roleTypes: [m.SalesInvoiceType.Name],
    });

    const stateSearch = new SearchFactory({
      objectType: m.SalesInvoiceState,
      roleTypes: [m.SalesInvoiceState.Name],
    });

    const partySearch = new SearchFactory({
      objectType: m.Party,
      roleTypes: [m.Party.PartyName],
    });

    const productSearch = new SearchFactory({
      objectType: m.Product,
      roleTypes: [m.Product.Name],
    });

    const serialisedItemSearch = new SearchFactory({
      objectType: m.SerialisedItem,
      roleTypes: [m.SerialisedItem.ItemNumber],
    });

    const filterDefinition = new FilterDefinition(predicate, {
      repeating: { initialValue: true },
      active: { initialValue: true },
      type: { search: typeSearch, display: (v: SalesInvoiceType) => v && v.Name },
      state: { search: stateSearch, display: (v: SalesInvoiceState) => v && v.Name },
      shipTo: { search: partySearch, display: (v: Party) => v && v.PartyName },
      billTo: { search: partySearch, display: (v: Party) => v && v.PartyName },
      shipToEndCustomer: { search: partySearch, display: (v: Party) => v && v.PartyName },
      billToEndCustomer: { search: partySearch, display: (v: Party) => v && v.PartyName },
      product: { search: productSearch, display: (v: Product) => v && v.Name },
      serialisedItem: { search: serialisedItemSearch, display: (v: SerialisedItem) => v && v.ItemNumber },
    });
    this.filter = new Filter(filterDefinition);
    
    const sorter = new Sorter(
      {
        number: m.SalesInvoice.SortableInvoiceNumber,
        type: m.SalesInvoice.SalesInvoiceType,
        invoiceDate: m.SalesInvoice.InvoiceDate,
        description: m.SalesInvoice.Description,
        lastModifiedDate: m.SalesInvoice.LastModifiedDate,
      }
    );

    this.subscription = combineLatest(this.refreshService.refresh$, this.filter.fields$, this.table.sort$, this.table.pager$, this.internalOrganisationId.observable$)
      .pipe(
        scan(([previousRefresh, previousFilterFields], [refresh, filterFields, sort, pageEvent, internalOrganisationId]) => {
          return [
            refresh,
            filterFields,
            sort,
            (previousRefresh !== refresh || filterFields !== previousFilterFields) ? Object.assign({ pageIndex: 0 }, pageEvent) : pageEvent,
            internalOrganisationId
          ];
        }, [, , , , ,]),
        switchMap(([, filterFields, sort, pageEvent, internalOrganisationId]) => {

          internalOrganisationPredicate.object = internalOrganisationId;

          const pulls = [
            this.fetcher.internalOrganisation,
            pull.Person({
              object: this.userId.value
            }),
            pull.SalesInvoice({
              predicate,
              sort: sorter.create(sort),
              include: {
                PrintDocument: {
                  Media: x
                },
                BillToCustomer: x,
                SalesInvoiceState: x,
                SalesInvoiceType: x,
              },
              parameters: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            })];

          return this.allors.context.load(new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        this.internalOrganisation = loaded.objects.InternalOrganisation as Organisation;
        this.user = loaded.objects.Person as Person;

        this.canCreate = this.internalOrganisation.CanExecuteCreateSalesInvoice;

        const salesInvoices = loaded.collections.SalesInvoices as SalesInvoice[];
        this.table.total = loaded.values.SalesInvoices_total;
        this.table.data = salesInvoices.filter(v => v.CanReadInvoiceNumber).map((v) => {
          return {
            object: v,
            number: v.InvoiceNumber,
            type: `${v.SalesInvoiceType && v.SalesInvoiceType.Name}`,
            billedTo: v.BillToCustomer && v.BillToCustomer.displayName,
            state: `${v.SalesInvoiceState && v.SalesInvoiceState.Name}`,
            invoiceDate: format(new Date(v.InvoiceDate), 'DD-MM-YYYY'),
            description: v.Description,
            totalExVat: v.TotalExVat,
            totalIncVat: v.TotalIncVat,
            lastModifiedDate: formatDistance(new Date(v.LastModifiedDate), new Date())
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
