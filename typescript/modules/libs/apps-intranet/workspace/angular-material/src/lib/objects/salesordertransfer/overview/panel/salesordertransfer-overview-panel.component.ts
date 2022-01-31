import { Component, Self, HostBinding } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

import { M } from '@allors/default/workspace/meta';
import {
  SalesOrder,
  SalesInvoice,
  SalesTerm,
} from '@allors/default/workspace/domain';
import {
  Action,
  DeleteService,
  EditService,
  NavigationService,
  ObjectData,
  ObjectService,
  OldPanelService,
  RefreshService,
  Table,
  TableRow,
} from '@allors/base/workspace/angular/foundation';
import { WorkspaceService } from '@allors/base/workspace/angular/foundation';

interface Row extends TableRow {
  object: SalesTerm;
  name: string;
  value: string;
}

@Component({
  selector: 'salesordertransfer-overview-panel',
  templateUrl: './salesordertransfer-overview-panel.component.html',
  providers: [OldPanelService],
})
export class SalesOrderTransferOverviewPanelComponent {
  container: SalesOrder | SalesInvoice;

  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  objects: SalesTerm[];
  table: Table<Row>;

  delete: Action;
  edit: Action;

  get createData(): ObjectData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
      associationRoleType: this.containerRoleType,
    };
  }

  get containerRoleType(): any {
    if (this.container.strategy.cls === this.m.SalesOrder) {
      return this.m.SalesOrder.SalesTerms;
    } else {
      return this.m.SalesInvoice.SalesTerms;
    }
  }

  constructor(
    @Self() public panel: OldPanelService,
    public objectService: ObjectService,
    public workspaceService: WorkspaceService,
    public refreshService: RefreshService,
    public navigation: NavigationService,
    public editService: EditService,
    public deleteService: DeleteService,
    public snackBar: MatSnackBar
  ) {
    this.m = this.workspaceService.workspace.configuration.metaPopulation as M;

    panel.name = 'salesterm';
    panel.title = 'Sales Terms';
    panel.icon = 'contacts';
    panel.expandable = true;

    this.delete = deleteService.delete(panel.manager.context);
    this.edit = this.editService.edit();

    const sort = true;
    this.table = new Table({
      selection: true,
      columns: [
        { name: 'name', sort },
        { name: 'value', sort },
      ],
      actions: [this.edit, this.delete],
      defaultAction: this.edit,
      autoSort: true,
      autoFilter: true,
    });

    const salesOrderTermsPullName = `${panel.name}_${this.m.SalesOrder.tag}_terms`;
    const salesInvoiceTermsPullName = `${panel.name}_${this.m.SalesInvoice.tag}_terms`;
    const salesOrderPullName = `${panel.name}_${this.m.SalesOrder.tag}`;
    const salesInvoicePullName = `${panel.name}_${this.m.SalesInvoice.tag}`;

    panel.onPull = (pulls) => {
      const m = this.m;
      const { pullBuilder: pull } = m;
      const x = {};

      const id = this.panel.manager.id;

      pulls.push(
        pull.SalesOrder({
          name: salesOrderTermsPullName,
          objectId: id,
          select: {
            SalesTerms: {
              include: {
                TermType: x,
              },
            },
          },
        }),
        pull.SalesInvoice({
          name: salesInvoiceTermsPullName,
          objectId: id,
          select: {
            SalesTerms: {
              include: {
                TermType: x,
              },
            },
          },
        }),
        pull.SalesOrder({
          name: salesOrderPullName,
          objectId: id,
        }),
        pull.SalesInvoice({
          name: salesInvoicePullName,
          objectId: id,
        })
      );
    };

    panel.onPulled = (loaded) => {
      this.container =
        loaded.object<SalesOrder>(salesOrderPullName) ||
        loaded.object<SalesInvoice>(salesInvoicePullName);
      this.objects =
        loaded.collection<SalesTerm>(salesOrderTermsPullName) ||
        loaded.collection<SalesTerm>(salesInvoiceTermsPullName) ||
        [];
      this.table.total =
        (loaded.value(`${salesOrderTermsPullName}_total`) as number) ??
        (loaded.value(`${salesInvoiceTermsPullName}_total`) as number) ??
        this.objects?.length ??
        0;
      this.table.data = this.objects?.map((v) => {
        return {
          object: v,
          name: v.TermType && v.TermType.Name,
          value: v.TermValue,
        } as Row;
      });
    };
  }
}