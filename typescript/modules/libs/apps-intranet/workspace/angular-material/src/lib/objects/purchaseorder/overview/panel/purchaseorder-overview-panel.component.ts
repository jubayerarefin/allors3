import { Component, Self, HostBinding } from '@angular/core';

import { M } from '@allors/default/workspace/meta';
import {
  Organisation,
  InternalOrganisation,
  PurchaseOrder,
} from '@allors/default/workspace/domain';
import {
  Action,
  DeleteService,
  MethodService,
  NavigationService,
  ObjectData,
  ObjectService,
  OldPanelService,
  RefreshService,
  Table,
  TableRow,
  OverviewService,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { PrintService } from '../../../../actions/print/print.service';
import { FetcherService } from '../../../../services/fetcher/fetcher-service';

interface Row extends TableRow {
  object: PurchaseOrder;
  number: string;
  description: string;
  reference: string;
  totalExVat: string;
  state: string;
  shipmentState: string;
  paymentState: string;
}

@Component({
  selector: 'purchaseorder-overview-panel',
  templateUrl: './purchaseorder-overview-panel.component.html',
  providers: [ContextService, OldPanelService],
})
export class PurchaseOrderOverviewPanelComponent {
  internalOrganisation: InternalOrganisation;

  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  objects: PurchaseOrder[];
  table: Table<Row>;

  delete: Action;
  invoice: Action;
  edit: Action;

  get createData(): ObjectData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
    };
  }

  constructor(
    @Self() public allors: ContextService,
    @Self() public panel: OldPanelService,
    public objectService: ObjectService,
    public methodService: MethodService,
    public refreshService: RefreshService,
    public navigationService: NavigationService,
    public overviewService: OverviewService,
    public deleteService: DeleteService,
    public printService: PrintService,
    private fetcher: FetcherService
  ) {
    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;

    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.panel.name = 'purchaseorder';
    this.panel.title = 'Purchase Orders';
    this.panel.icon = 'message';
    this.panel.expandable = true;

    this.delete = this.deleteService.delete(this.panel.manager.context);
    this.invoice = methodService.create(
      allors.context,
      this.m.PurchaseOrder.Invoice,
      { name: 'Invoice' }
    );

    const sort = true;
    this.table = new Table({
      selection: true,
      columns: [
        { name: 'number', sort },
        { name: 'description', sort },
        { name: 'reference', sort },
        { name: 'totalExVat', sort },
        { name: 'state', sort },
        { name: 'shipmentState', sort },
        { name: 'paymentState', sort },
      ],
      actions: [
        this.overviewService.overview(),
        this.printService.print(),
        this.invoice,
      ],
      defaultAction: this.overviewService.overview(),
      autoSort: true,
      autoFilter: true,
    });

    if (this.panel.manager.objectType === this.m.PurchaseInvoice) {
      this.table.actions.push(this.delete);
    }

    const pullName = `${this.panel.name}_${this.m.PurchaseOrder.tag}`;

    this.panel.onPull = (pulls) => {
      const { id } = this.panel.manager;

      pulls.push(
        this.fetcher.internalOrganisation,
        pull.Organisation({
          name: pullName,
          objectId: id,
          select: {
            PurchaseOrdersWhereTakenViaSupplier: {
              include: {
                PurchaseOrderState: x,
                PurchaseOrderShipmentState: x,
                PurchaseOrderPaymentState: x,
                PrintDocument: {
                  Media: x,
                },
              },
            },
          },
        })
      );
    };

    this.panel.onPulled = (loaded) => {
      this.internalOrganisation = this.fetcher.getInternalOrganisation(loaded);

      const purchaseOrders = loaded.collection<PurchaseOrder>(pullName);
      this.objects = purchaseOrders?.filter(
        (v) => v.OrderedBy === this.internalOrganisation
      );
      this.objects.sort((a, b) =>
        a.OrderNumber > b.OrderNumber
          ? 1
          : b.OrderNumber > a.OrderNumber
          ? -1
          : 0
      );

      this.table.total =
        (loaded.value(`${pullName}_total`) as number) ??
        this.objects?.length ??
        0;
      this.table.data = this.objects?.map((v) => {
        return {
          object: v,
          number: v.OrderNumber,
          description: v.Description,
          reference: v.CustomerReference,
          totalExVat: v.TotalExVat.toString(),
          state: v.PurchaseOrderState.Name,
          shipmentState: v.PurchaseOrderShipmentState.Name,
          paymentState: v.PurchaseOrderPaymentState.Name,
        } as Row;
      });
    };
  }
}