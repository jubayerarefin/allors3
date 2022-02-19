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
  BillingProcess,
  FixedAsset,
  Organisation,
  OrganisationContactKind,
  OrganisationContactRelationship,
  Person,
  ProductQuote,
  PurchaseInvoice,
  PurchaseOrder,
  RequestForQuote,
  SalesInvoice,
  SalesOrder,
  SalesOrderItem,
  SerialisedInventoryItemState,
  Shipment,
  User,
  WorkTask,
} from '@allors/default/workspace/domain';
import { PrintService } from '../../../actions/print/print.service';

@Component({
  selector: 'worktask-overview-summary',
  templateUrl: './worktask-overview-summary.component.html',
  providers: [
    ScopedService,
    {
      provide: PanelService,
      useClass: AllorsMaterialPanelService,
    },
  ],
})
export class WorkTaskOverviewSummaryComponent extends AllorsViewSummaryPanelComponent {
  m: M;

  workTask: WorkTask;
  parent: WorkTask;

  print: Action;
  printForWorker: Action;
  salesInvoices: Set<SalesInvoice>;
  assets: FixedAsset[];

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
    const { m } = this;
    const { pullBuilder: p } = m;

    const id = this.scoped.id;

    pulls.push(
      p.WorkTask({
        name: prefix,
        objectId: id,
        include: {
          Customer: {},
          WorkEffortState: {},
          LastModifiedBy: {},
          PrintDocument: {
            Media: {},
          },
        },
      }),
      p.WorkTask({
        name: `${prefix}_parent`,
        objectId: id,
        select: {
          WorkEffortWhereChild: {},
        },
      }),
      p.WorkEffort({
        name: `${prefix}_workEffortBilling`,
        objectId: id,
        select: {
          WorkEffortBillingsWhereWorkEffort: {
            InvoiceItem: {
              SalesInvoiceItem_SalesInvoiceWhereSalesInvoiceItem: {},
            },
          },
        },
      }),
      p.WorkEffort({
        name: `${prefix}_fixedAsset`,
        objectId: id,
        select: {
          WorkEffortFixedAssetAssignmentsWhereAssignment: {
            FixedAsset: {},
          },
        },
      }),
      p.TimeEntryBilling({
        name: `${prefix}_serviceEntry`,
        predicate: {
          kind: 'ContainedIn',
          propertyType: m.TimeEntryBilling.TimeEntry,
          extent: {
            kind: 'Filter',
            objectType: m.ServiceEntry,
            predicate: {
              kind: 'Equals',
              propertyType: m.ServiceEntry.WorkEffort,
              value: id,
            },
          },
        },
        select: {
          InvoiceItem: {
            SalesInvoiceItem_SalesInvoiceWhereSalesInvoiceItem: {},
          },
        },
      })
    );
  }

  onPostSharedPull(loaded: IPullResult, prefix?: string) {
    this.workTask = loaded.object<WorkTask>(prefix);
    this.parent = loaded.object<WorkTask>(`${prefix}_parent`);

    this.assets = loaded.collection<FixedAsset>(`${prefix}_fixedAsset`);

    const salesInvoices1 =
      loaded.collection<SalesInvoice>(`${prefix}_workEffortBilling`) ?? [];
    const salesInvoices2 =
      loaded.collection<SalesInvoice>(`${prefix}_serviceEntry`) ?? [];
    this.salesInvoices = new Set([...salesInvoices1, ...salesInvoices2]);
  }

  public cancel(): void {
    this.invokeService.invoke(this.workTask.Cancel).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully cancelled.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public reopen(): void {
    this.invokeService.invoke(this.workTask.Reopen).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully reopened.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }

  public revise(): void {
    this.invokeService.invoke(this.workTask.Revise).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Revise successfully executed.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public complete(): void {
    this.invokeService.invoke(this.workTask.Complete).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully completed.', 'close', {
        duration: 5000,
      });
    }, this.errorService.errorHandler);
  }

  public invoice(): void {
    this.invokeService.invoke(this.workTask.Invoice).subscribe(() => {
      this.refreshService.refresh();
      this.snackBar.open('Successfully invoiced.', 'close', { duration: 5000 });
    }, this.errorService.errorHandler);
  }
}