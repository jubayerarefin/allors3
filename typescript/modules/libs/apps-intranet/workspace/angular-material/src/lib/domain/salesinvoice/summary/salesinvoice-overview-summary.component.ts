import { Component, Self } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  Action,
  ErrorService,
  InvokeService,
  MediaService,
  RefreshService,
  SharedPullService,
} from '@allors/base/workspace/angular/foundation';

import { WorkspaceService } from '@allors/base/workspace/angular/foundation';
import {
  AllorsViewSummaryPanelComponent,
  PanelService,
  ScopedService,
} from '@allors/base/workspace/angular/application';
import { AllorsMaterialPanelService } from '@allors/base/workspace/angular-material/application';
import { IPullResult, Pull } from '@allors/system/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  Organisation,
  OrganisationContactKind,
  OrganisationContactRelationship,
  Person,
  ProductQuote,
  PurchaseInvoice,
  PurchaseOrder,
  Quote,
  RepeatingSalesInvoice,
  RequestForQuote,
  SalesInvoice,
  SalesOrder,
  User,
  WorkEffort,
} from '@allors/default/workspace/domain';

@Component({
  selector: 'salesinvoice-overview-summary',
  templateUrl: './salesinvoice-overview-summary.component.html',
  providers: [
    ScopedService,
    {
      provide: PanelService,
      useClass: AllorsMaterialPanelService,
    },
  ],
})
export class SalesInvoiceOverviewSummaryComponent extends AllorsViewSummaryPanelComponent {
  m: M;

  invoice: SalesInvoice;
  orders: SalesOrder[];
  repeatingInvoices: RepeatingSalesInvoice[];
  repeatingInvoice: RepeatingSalesInvoice;
  print: Action;
  workEfforts: WorkEffort[];
  public hasIrpf: boolean;
  creditNote: SalesInvoice;

  get totalIrpfIsPositive(): boolean {
    return +this.invoice.TotalIrpf > 0;
  }

  constructor(
    @Self() scopedService: ScopedService,
    @Self() panelService: PanelService,
    refreshService: RefreshService,
    sharedPullService: SharedPullService,
    workspaceService: WorkspaceService,
    private snackBar: MatSnackBar,
    private invokeService: InvokeService,
    private errorService: ErrorService
  ) {
    super(scopedService, panelService, sharedPullService, refreshService);
    this.m = workspaceService.workspace.configuration.metaPopulation as M;
  }

  onPreSharedPull(pulls: Pull[], prefix?: string) {
    const { m } = this;
    const { pullBuilder: p } = m;

    const id = this.scoped.id;

    pulls.push(
      p.SalesInvoice({
        name: prefix,
        objectId: id,
        include: {
          SalesInvoiceItems: {
            Product: {},
            InvoiceItemType: {},
          },
          SalesTerms: {
            TermType: {},
          },
          PrintDocument: {
            Media: {},
          },
          CreditedFromInvoice: {},
          BillToCustomer: {},
          BillToContactPerson: {},
          ShipToCustomer: {},
          ShipToContactPerson: {},
          ShipToEndCustomer: {},
          ShipToEndCustomerContactPerson: {},
          SalesInvoiceState: {},
          CreatedBy: {},
          LastModifiedBy: {},
          DerivedBillToContactMechanism: {
            PostalAddress_Country: {},
          },
          DerivedShipToAddress: {
            Country: {},
          },
          DerivedBillToEndCustomerContactMechanism: {
            PostalAddress_Country: {},
          },
          DerivedShipToEndCustomerAddress: {
            Country: {},
          },
        },
      }),
      p.SalesInvoice({
        name: `${prefix}_salesOrder`,
        objectId: id,
        select: {
          SalesOrders: {},
        },
      }),
      p.SalesInvoice({
        name: `${prefix}_workEffort`,
        objectId: id,
        select: {
          WorkEfforts: {},
        },
      }),
      p.SalesInvoice({
        name: `${prefix}_creditNote`,
        objectId: id,
        select: {
          SalesInvoiceWhereCreditedFromInvoice: {},
        },
      }),
      p.RepeatingSalesInvoice({
        name: `${prefix}_repeatingSalesInvoice`,
        predicate: {
          kind: 'Equals',
          propertyType: m.RepeatingSalesInvoice.Source,
          value: id,
        },
        include: {
          Frequency: {},
          DayOfWeek: {},
        },
      })
    );
  }

  onPostSharedPull(loaded: IPullResult, prefix?: string) {
    this.invoice = loaded.object<SalesInvoice>(prefix);
    this.orders = loaded.collection<SalesOrder>(`${prefix}_salesOrder`);
    this.workEfforts = loaded.collection<WorkEffort>(`${prefix}_workEffort`);
    this.repeatingInvoices = loaded.collection<RepeatingSalesInvoice>(
      `${prefix}_repeatingSalesInvoice`
    );
    this.hasIrpf = Number(this.invoice.TotalIrpf) !== 0;
    this.creditNote = loaded.object<SalesInvoice>(`${prefix}_creditNote`);

    if (this.repeatingInvoices) {
      this.repeatingInvoice = this.repeatingInvoices[0];
    } else {
      this.repeatingInvoice = undefined;
    }
  }

  send() {
    this.invokeService.invoke(this.invoice.Send).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully sent.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public cancel(): void {
    this.invokeService.invoke(this.invoice.CancelInvoice).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully cancelled.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public writeOff(): void {
    this.invokeService.invoke(this.invoice.WriteOff).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully written off.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public reopen(): void {
    this.invokeService.invoke(this.invoice.Reopen).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully Reopened.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public credit(): void {
    this.invokeService.invoke(this.invoice.Credit).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully Credited.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public revise(): void {
    this.invokeService.invoke(this.invoice.Revise).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully Reopened.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public copy(): void {
    this.invokeService.invoke(this.invoice.Copy).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully copied.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }
}