import { Component, Self } from '@angular/core';

import { M } from '@allors/default/workspace/meta';
import {
  Part,
  SerialisedItem,
  RequestForQuote,
  ProductQuote,
  SalesOrder,
  CustomerShipment,
  SalesInvoice,
} from '@allors/default/workspace/domain';
import {
  NavigationService,
  OldPanelService,
} from '@allors/base/workspace/angular/foundation';
import { WorkspaceService } from '@allors/base/workspace/angular/foundation';

@Component({
  selector: 'serialiseditem-overview-summary',
  templateUrl: './serialiseditem-overview-summary.component.html',
  providers: [OldPanelService],
})
export class SerialisedItemOverviewSummaryComponent {
  m: M;

  serialisedItem: SerialisedItem;
  part: Part;
  request: RequestForQuote;
  quote: ProductQuote;
  order: SalesOrder;
  shipment: CustomerShipment;
  invoice: SalesInvoice;

  constructor(
    @Self() public panel: OldPanelService,
    public workspaceService: WorkspaceService,
    public navigation: NavigationService
  ) {
    this.m = this.workspaceService.workspace.configuration.metaPopulation as M;
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    panel.name = 'summary';

    const serialisedItemPullName = `${panel.name}_${this.m.SerialisedItem.tag}`;
    const partPullName = `${panel.name}_${this.m.Part.tag}`;

    panel.onPull = (pulls) => {
      const id = this.panel.manager.id;

      pulls.push(
        pull.SerialisedItem({
          name: serialisedItemPullName,
          objectId: id,
          include: {
            SerialisedItemState: x,
            OwnedBy: x,
            RentedBy: x,
          },
        }),
        pull.SerialisedItem({
          name: partPullName,
          objectId: id,
          select: {
            PartWhereSerialisedItem: x,
          },
        }),
        pull.SerialisedItem({
          objectId: id,
          select: {
            RequestItemsWhereSerialisedItem: {
              RequestWhereRequestItem: x,
            },
          },
        }),
        pull.SerialisedItem({
          objectId: id,
          select: {
            QuoteItemsWhereSerialisedItem: {
              QuoteWhereQuoteItem: x,
            },
          },
        }),
        pull.SerialisedItem({
          objectId: id,
          select: {
            SalesOrderItemsWhereSerialisedItem: {
              SalesOrderWhereSalesOrderItem: x,
            },
          },
        }),
        pull.SerialisedItem({
          objectId: id,
          select: {
            ShipmentItemsWhereSerialisedItem: {
              ShipmentWhereShipmentItem: x,
            },
          },
        }),
        pull.SerialisedItem({
          objectId: id,
          select: {
            SalesInvoiceItemsWhereSerialisedItem: {
              SalesInvoiceWhereSalesInvoiceItem: x,
            },
          },
        })
      );
    };

    panel.onPulled = (loaded) => {
      this.serialisedItem = loaded.object<SerialisedItem>(
        serialisedItemPullName
      );
      this.part = loaded.object<Part>(partPullName);

      const requests =
        loaded.collection<RequestForQuote>(
          m.RequestItem.RequestWhereRequestItem
        ) || [];
      if (requests.length > 0) {
        this.request = requests?.reduce(function (a, b) {
          return a.RequestDate > b.RequestDate ? a : b;
        });
      }

      const quotes =
        loaded.collection<ProductQuote>(m.QuoteItem.QuoteWhereQuoteItem) || [];
      if (quotes.length > 0) {
        this.quote = quotes?.reduce(function (a, b) {
          return a.IssueDate > b.IssueDate ? a : b;
        });
      }

      const orders =
        loaded.collection<SalesOrder>(
          m.SalesOrderItem.SalesOrderWhereSalesOrderItem
        ) || [];
      if (orders.length > 0) {
        this.order = orders?.reduce(function (a, b) {
          return a.OrderDate > b.OrderDate ? a : b;
        });
      }

      const shipments =
        loaded.collection<CustomerShipment>(
          m.ShipmentItem.ShipmentWhereShipmentItem
        ) || [];
      if (shipments.length > 0) {
        this.shipment = shipments?.reduce(function (a, b) {
          return a.EstimatedShipDate > b.EstimatedShipDate ? a : b;
        });
      }

      const invoices =
        loaded.collection<SalesInvoice>(
          m.SalesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem
        ) || [];
      if (invoices.length > 0) {
        this.invoice = invoices?.reduce(function (a, b) {
          return a.InvoiceDate > b.InvoiceDate ? a : b;
        });
      }
    };
  }
}
