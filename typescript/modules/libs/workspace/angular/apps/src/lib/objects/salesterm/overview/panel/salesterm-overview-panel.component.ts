import { Component, Self, HostBinding } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

import { M } from '@allors/workspace/meta/default';
import { SalesOrder, SalesInvoice, SalesTerm } from '@allors/workspace/domain/default';
import { Action, DeleteService, EditService, NavigationService, ObjectData, ObjectService, PanelService, RefreshService, Table, TableRow, TestScope } from '@allors/workspace/angular/base';

interface Row extends TableRow {
  object: SalesTerm;
  name: string;
  value: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'salesterm-overview-panel',
  templateUrl: './salesterm-overview-panel.component.html',
  providers: [PanelService],
})
export class SalesTermOverviewPanelComponent extends TestScope {
  container: any;

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
    if (this.container.objectType.name === this.m.SalesOrder.name) {
      return this.m.SalesOrder.SalesTerms;
    } else {
      return this.m.SalesInvoice.SalesTerms;
    }
  }

  constructor(
    @Self() public panel: PanelService,
    public objectService: ObjectService,

    public refreshService: RefreshService,
    public navigation: NavigationService,
    public editService: EditService,
    public deleteService: DeleteService,
    public snackBar: MatSnackBar
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;

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

    const salesOrderTermsPullName = `${panel.name}_${this.m.SalesOrder.name}_terms`;
    const salesInvoiceTermsPullName = `${panel.name}_${this.m.SalesInvoice.name}_terms`;
    const salesOrderPullName = `${panel.name}_${this.m.SalesOrder.name}`;
    const salesInvoicePullName = `${panel.name}_${this.m.SalesInvoice.name}`;

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
      this.container = (loaded.objects[salesOrderPullName] as SalesOrder) || (loaded.objects[salesInvoicePullName] as SalesInvoice);
      this.objects = (loaded.collections[salesOrderTermsPullName] as SalesTerm[]) || (loaded.collections[salesInvoiceTermsPullName] as SalesTerm[]);
      this.table.total = loaded.values[`${salesOrderTermsPullName}_total`] || loaded.values[`${salesInvoiceTermsPullName}_total`] || this.objects.length;
      this.table.data = this.objects.map((v) => {
        return {
          object: v,
          name: v.TermType && v.TermType.Name,
          value: v.TermValue,
        } as Row;
      });
    };
  }
}
