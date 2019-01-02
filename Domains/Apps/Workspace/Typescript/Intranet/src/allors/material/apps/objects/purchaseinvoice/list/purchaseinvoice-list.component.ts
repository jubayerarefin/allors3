import { Component, OnDestroy, Self, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Location } from '@angular/common';
import { MatTableDataSource, PageEvent, MatSnackBar } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

import { BehaviorSubject, Subscription, combineLatest } from 'rxjs';
import { scan, switchMap } from 'rxjs/operators';

import { AllorsFilterService, ErrorService, ContextService, MediaService, MetaService, RefreshService } from '../../../../../angular';
import { PurchaseInvoice } from '../../../../../domain';
import { And, Like, PullRequest, Sort } from '../../../../../framework';
import { OverviewService, AllorsMaterialDialogService, Sorter } from '../../../../../material';


interface Row {
  purchaseInvoice: PurchaseInvoice;
  number: string;
  billedFrom: string;
  billedTo: string;
  reference: string;
  lastModifiedDate: Date;
}

@Component({
  templateUrl: './purchaseinvoice-list.component.html',
  providers: [ContextService, AllorsFilterService]
})
export class PurchaseInvoiceListComponent implements OnInit, OnDestroy {

  public searchForm: FormGroup; public advancedSearch: boolean;

  public title = 'Purchase Invoices';

  public displayedColumns = ['select', 'number', 'billedFrom', 'billedTo', 'reference', 'lastModifiedDate', 'menu'];
  public selection = new SelectionModel<Row>(true, []);

  public total: number;
  public dataSource = new MatTableDataSource<Row>();

  private sort$: BehaviorSubject<Sort>;
  private refresh$: BehaviorSubject<Date>;
  private pager$: BehaviorSubject<PageEvent>;

  private subscription: Subscription;

  constructor(
    @Self() public allors: ContextService,
    @Self() private filterService: AllorsFilterService,
    public metaService: MetaService,
    public refreshService: RefreshService,
    public overviewService: OverviewService,
    public mediaService: MediaService,
    private errorService: ErrorService,
    private snackBar: MatSnackBar,
    private dialogService: AllorsMaterialDialogService,
    private location: Location,
    titleService: Title) {

    titleService.setTitle(this.title);

    this.sort$ = new BehaviorSubject<Sort>(undefined);
    this.refresh$ = new BehaviorSubject<Date>(undefined);
    this.pager$ = new BehaviorSubject<PageEvent>(Object.assign(new PageEvent(), { pageIndex: 0, pageSize: 50 }));
  }

  public ngOnInit(): void {

    const { m, pull, x } = this.metaService;

    const predicate = new And([
      new Like({ roleType: m.PurchaseInvoice.InvoiceNumber, parameter: 'number' }),
    ]);

    this.filterService.init(predicate);

    const sorter = new Sorter(
      {
        number: m.PurchaseInvoice.InvoiceNumber,
        lastModifiedDate: m.Person.LastModifiedDate,
      }
    );

    this.subscription = combineLatest(this.refresh$, this.filterService.filterFields$, this.sort$, this.pager$)
      .pipe(
        scan(([previousRefresh, previousFilterFields], [refresh, filterFields, sort, pageEvent]) => {
          return [
            refresh,
            filterFields,
            sort,
            (previousRefresh !== refresh || filterFields !== previousFilterFields) ? Object.assign({ pageIndex: 0 }, pageEvent) : pageEvent,
          ];
        }, []),
        switchMap(([, filterFields, sort, pageEvent]) => {

          const pulls = [
            pull.PurchaseInvoice({
              predicate,
              sort: sorter.create(sort),
              include: {
                BilledFrom: x,
                BilledTo: x,
                PurchaseInvoiceState: x,
              },
              arguments: this.filterService.arguments(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            })];

          return this.allors.context.load('Pull', new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();
        this.total = loaded.values.People_total;
        const purchaseInvoices = loaded.collections.PurchaseInvoices as PurchaseInvoice[];

        this.dataSource.data = purchaseInvoices.map((v) => {
          return {
            purchaseInvoice: v,
            number: v.InvoiceNumber,
            billedFrom: v.BilledFrom.displayName,
            billedTo: v.BilledTo.displayName,
            reference: `${v.CustomerReference} - ${v.PurchaseInvoiceState.Name}`,
            lastModifiedDate: v.LastModifiedDate,
          } as Row;
        });
      }, this.errorService.handler);
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public get hasSelection() {
    return !this.selection.isEmpty();
  }

  public get selectedPeople() {
    return this.selection.selected.map(v => v.purchaseInvoice);
  }

  public isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  public masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

  public goBack(): void {
    this.location.back();
  }

  public refresh(): void {
    this.refresh$.next(new Date());
  }

  public sort(event: Sort): void {
    this.sort$.next(event);
  }

  public page(event: PageEvent): void {
    this.pager$.next(event);
  }
}
