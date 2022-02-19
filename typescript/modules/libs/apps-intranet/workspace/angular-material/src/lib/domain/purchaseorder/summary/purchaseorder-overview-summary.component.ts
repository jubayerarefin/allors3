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
  RequestForQuote,
  SalesOrder,
  Shipment,
  User,
} from '@allors/default/workspace/domain';
import { PrintService } from '../../../actions/print/print.service';

@Component({
  selector: 'purchaseorder-overview-summary',
  templateUrl: './purchaseorder-overview-summary.component.html',
  providers: [
    ScopedService,
    {
      provide: PanelService,
      useClass: AllorsMaterialPanelService,
    },
  ],
})
export class PurchaseOrderOverviewSummaryComponent extends AllorsViewSummaryPanelComponent {
  m: M;

  order: PurchaseOrder;
  purchaseInvoices: PurchaseInvoice[] = [];

  print: Action;
  shipments: Shipment[];

  constructor(
    @Self() scopedService: ScopedService,
    @Self() panelService: PanelService,
    refreshService: RefreshService,
    sharedPullService: SharedPullService,
    workspaceService: WorkspaceService,
    private snackBar: MatSnackBar,
    private invokeService: InvokeService,
    private errorService: ErrorService,
    public printService: PrintService
  ) {
    super(scopedService, panelService, sharedPullService, refreshService);
    this.m = workspaceService.workspace.configuration.metaPopulation as M;
    this.print = printService.print();
  }

  onPreSharedPull(pulls: Pull[], prefix?: string) {
    const {
      m: { pullBuilder: p },
    } = this;

    const id = this.scoped.id;

    pulls.push(
      p.PurchaseOrder({
        name: prefix,
        objectId: id,
        include: {
          TakenViaSupplier: {},
          PurchaseOrderState: {},
          PurchaseOrderShipmentState: {},
          PurchaseOrderPaymentState: {},
          CreatedBy: {},
          LastModifiedBy: {},
          PrintDocument: {
            Media: {},
          },
        },
      }),
      p.PurchaseOrder({
        name: `${prefix}_shipment`,
        objectId: id,
        select: {
          PurchaseOrderItems: {
            OrderShipmentsWhereOrderItem: {
              ShipmentItem: {
                ShipmentWhereShipmentItem: {},
              },
            },
          },
        },
      }),
      p.PurchaseOrder({
        name: `${prefix}_purchaseInvoice`,
        objectId: id,
        select: { PurchaseInvoicesWherePurchaseOrder: {} },
      })
    );
  }

  onPostSharedPull(loaded: IPullResult, prefix?: string) {
    this.order = loaded.object<PurchaseOrder>(prefix);
    this.purchaseInvoices = loaded.collection<PurchaseInvoice>(
      `${prefix}_purchaseInvoice`
    );
    this.shipments = loaded.collection<Shipment>(`${prefix}_shipment`);
  }

  public approve(): void {
    this.invokeService.invoke(this.order.Approve).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully approved.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public cancel(): void {
    this.invokeService.invoke(this.order.Cancel).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully cancelled.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public reject(): void {
    this.invokeService.invoke(this.order.Reject).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully rejected.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public hold(): void {
    this.invokeService.invoke(this.order.Hold).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully put on hold.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public continue(): void {
    this.invokeService.invoke(this.order.Continue).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully removed from hold.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public setReadyForProcessing(): void {
    this.invokeService
      .invoke(this.order.SetReadyForProcessing)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully set ready for processing.', 'close', {
          duration: 5000,
        });
      }, this.errorService.errorHandler);
  }

  public reopen(): void {
    this.invokeService.invoke(this.order.Reopen).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully reopened.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public revise(): void {
    this.invokeService.invoke(this.order.Revise).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully revised.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public send(): void {
    this.invokeService.invoke(this.order.Send).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully send.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public invoice(): void {
    this.invokeService.invoke(this.order.Invoice).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully created purchase invoice', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public quickReceive(): void {
    this.invokeService.invoke(this.order.QuickReceive).subscribe(() => {
      this.snackBar.open('inventory created for appropriate items', 'close', {
        duration: 5000,
      });
      this.refreshService.refresh();
    }, this.errorService.errorHandler);
  }
}