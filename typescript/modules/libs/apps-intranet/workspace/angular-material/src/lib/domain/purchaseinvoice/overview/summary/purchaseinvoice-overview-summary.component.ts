import { Component, Self } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

import { M } from '@allors/default/workspace/meta';
import {
  PurchaseOrder,
  PurchaseInvoice,
} from '@allors/default/workspace/domain';
import {
  Action,
  NavigationService,
  OldPanelService,
  RefreshService,
  ErrorService,
} from '@allors/base/workspace/angular/foundation';

import { PrintService } from '../../../../actions/print/print.service';
import { WorkspaceService } from '@allors/base/workspace/angular/foundation';

@Component({
  selector: 'purchaseinvoice-overview-summary',
  templateUrl: './purchaseinvoice-overview-summary.component.html',
  providers: [OldPanelService],
})
export class PurchasInvoiceOverviewSummaryComponent {
  m: M;

  orders: PurchaseOrder[];
  invoice: PurchaseInvoice;

  print: Action;
  orderTotalExVat: number;
  hasIrpf: boolean;
  get totalIrpfIsPositive(): boolean {
    return +this.invoice.TotalIrpf > 0;
  }

  constructor(
    @Self() public panel: OldPanelService,
    public workspaceService: WorkspaceService,

    public navigation: NavigationService,
    public printService: PrintService,
    private errorService: ErrorService,

    public refreshService: RefreshService,
    public snackBar: MatSnackBar
  ) {
    this.m = this.workspaceService.workspace.configuration.metaPopulation as M;
    const m = this.m;

    this.print = printService.print();

    panel.name = 'summary';

    const purchaseInvoicePullName = `${panel.name}_${this.m.PurchaseInvoice.tag}`;
    const purchaseOrderPullName = `${panel.name}_${this.m.PurchaseOrder.tag}`;

    panel.onPull = (pulls) => {
      const { pullBuilder: pull } = m;
      const x = {};

      const { id } = this.panel.manager;

      pulls.push(
        pull.PurchaseInvoice({
          name: purchaseInvoicePullName,
          objectId: id,
          include: {
            PurchaseInvoiceItems: {
              InvoiceItemType: x,
            },
            BilledFrom: x,
            BilledFromContactPerson: x,
            ShipToCustomer: x,
            BillToEndCustomer: x,
            BillToEndCustomerContactPerson: x,
            ShipToEndCustomer: x,
            ShipToEndCustomerContactPerson: x,
            PurchaseInvoiceState: x,
            CreatedBy: x,
            LastModifiedBy: x,
            DerivedBillToEndCustomerContactMechanism: {
              PostalAddress_Country: {},
            },
            DerivedShipToEndCustomerAddress: {
              Country: x,
            },
            PrintDocument: {
              Media: x,
            },
          },
        }),
        pull.PurchaseInvoice({
          name: purchaseOrderPullName,
          objectId: id,
          select: {
            PurchaseOrders: x,
          },
        })
      );
    };

    panel.onPulled = (loaded) => {
      this.invoice = loaded.object<PurchaseInvoice>(purchaseInvoicePullName);
      this.orders = loaded.collection<PurchaseOrder>(purchaseOrderPullName);

      this.orderTotalExVat = this.orders?.reduce(
        (partialOrderTotal, order) =>
          partialOrderTotal +
          order.ValidOrderItems?.reduce(
            (partialItemTotal, item) =>
              partialItemTotal + parseFloat(item.TotalExVat),
            0
          ),
        0
      );

      this.hasIrpf = Number(this.invoice.TotalIrpf) !== 0;
    };
  }

  public confirm(): void {
    this.panel.manager.context.invoke(this.invoice.Confirm).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully confirmed.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public cancel(): void {
    this.panel.manager.context.invoke(this.invoice.Cancel).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully cancelled.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public reopen(): void {
    this.panel.manager.context.invoke(this.invoice.Reopen).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully reopened.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public revise(): void {
    this.panel.manager.context.invoke(this.invoice.Revise).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully reopened.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public finishRevising(): void {
    this.panel.manager.context
      .invoke(this.invoice.FinishRevising)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully finished revising.', 'close', {
          duration: 5000,
        });
      }, this.errorService.errorHandler);
  }

  public approve(): void {
    this.panel.manager.context.invoke(this.invoice.Approve).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully approved.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public reject(): void {
    this.panel.manager.context.invoke(this.invoice.Reject).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully rejected.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public createSalesInvoice(invoice: PurchaseInvoice): void {
    this.panel.manager.context
      .invoke(invoice.CreateSalesInvoice)
      .subscribe(() => {
        this.snackBar.open('Successfully created a sales invoice.', 'close', {
          duration: 5000,
        });
        this.refreshService.refresh();
      }, this.errorService.errorHandler);
  }
}