import { Component, Self, HostBinding } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

import { M } from '@allors/workspace/meta/default';
import { OrderAdjustment } from '@allors/workspace/domain/default';
import { Action, DeleteService, EditService, NavigationService, ObjectData, ObjectService, PanelService, RefreshService, Table, TableRow, TestScope } from '@allors/workspace/angular/base';
import { WorkspaceService } from '@allors/workspace/angular/core';

interface Row extends TableRow {
  object: OrderAdjustment;
  adjustment: string;
  amount: string;
  percentage: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'orderadjustment-overview-panel',
  templateUrl: './orderadjustment-overview-panel.component.html',
  providers: [PanelService]
})
export class OrderAdjustmentOverviewPanelComponent extends TestScope {
  container: any;

  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  objects: OrderAdjustment[];
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
    if (this.container.objectType.name === this.m.ProductQuote.name
      || this.container.objectType.name === this.m.Proposal.name
      || this.container.objectType.name === this.m.StatementOfWork.name) {
      return this.m.Quote.OrderAdjustments;
    } else if (this.container.objectType.name === this.m.SalesOrder.name) {
      return this.m.SalesOrder.OrderAdjustments;
    } else if (this.container.objectType.name === this.m.SalesInvoice.name
      || this.container.objectType.name === this.m.PurchaseInvoice.name) {
      return this.m.Invoice.OrderAdjustments;
    }
  }

  constructor(
    @Self() public panel: PanelService,
    public workspaceService: WorkspaceService,
    public objectService: ObjectService,
    public refreshService: RefreshService,
    public navigation: NavigationService,
    public editService: EditService,
    public deleteService: DeleteService,
    public snackBar: MatSnackBar
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    panel.name = 'orderadjustment';
    panel.title = 'Order/Invoice Adjustments';
    panel.icon = 'money';
    panel.expandable = true;

    this.delete = deleteService.delete(panel.manager.context);
    this.edit = this.editService.edit();

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'adjustment' },
        { name: 'amount' },
        { name: 'percentage' },
      ],
      actions: [
        this.edit,
        this.delete,
      ],
      defaultAction: this.edit,
      autoSort: true,
      autoFilter: true,
    });

    const quoteOrderAdjustmentsPullName = `${panel.name}_${this.m.Quote.name}_adjustments`;
    const orderOrderAdjustmentsPullName = `${panel.name}_${this.m.Order.name}_adjustments`;
    const invoiceOrderAdjustmentsPullName = `${panel.name}_${this.m.Invoice.name}_adjustments`;
    const quotePullName = `${panel.name}_${this.m.Quote.tag}`;
    const orderPullName = `${panel.name}_${this.m.Order.tag}`;
    const invoicePullName = `${panel.name}_${this.m.Invoice.tag}`;

    panel.onPull = (pulls) => {
      const m = this.m; const { pullBuilder: pull } = m; const x = {};

      const id = this.panel.manager.id;

      pulls.push(
        pull.Quote({
          name: quoteOrderAdjustmentsPullName,
          objectId: id,
          select: {
            OrderAdjustments: x,
          }
        }),
        pull.Order({
          name: orderOrderAdjustmentsPullName,
          objectId: id,
          select: {
            OrderAdjustments: x,
          }
        }),
        pull.Invoice({
          name: invoiceOrderAdjustmentsPullName,
          objectId: id,
          select: {
            OrderAdjustments: x,
          }
        }),
        pull.Quote({
          name: quotePullName,
          objectId: id,
        }),
        pull.Order({
          name: orderPullName,
          objectId: id,
        }),
        pull.Invoice({
          name: invoicePullName,
          objectId: id,
        }),
      );
    };

    panel.onPulled = (loaded) => {

      this.container = loaded.objects[quotePullName] as Quote
        || loaded.objects[orderPullName] as Order
        || loaded.objects[invoicePullName] as Invoice;

      this.objects = loaded.collections[quoteOrderAdjustmentsPullName] as OrderAdjustment[]
        || loaded.collections[orderOrderAdjustmentsPullName] as OrderAdjustment[]
        || loaded.collections[invoiceOrderAdjustmentsPullName] as OrderAdjustment[];

      this.table.total = loaded.values[`${quoteOrderAdjustmentsPullName}_total`]
        || loaded.values[`${orderOrderAdjustmentsPullName}_total`] || this.objects.length
        || loaded.values[`${invoiceOrderAdjustmentsPullName}_total`] || this.objects.length;

      this.table.data = this.objects.map((v) => {
        return {
          object: v,
          adjustment: v.objectType.name,
          amount: v.Amount,
          percentage: v.Percentage,
        } as Row;
      });
    };
  }
}
