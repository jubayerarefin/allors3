import { Component, Self, OnInit, HostBinding } from '@angular/core';
import { formatDistance } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import { ProductQuote } from '@allors/workspace/domain/default';
import { Action, DeleteService, NavigationService, ObjectData, PanelService, RefreshService, Table, TableRow, TestScope, OverviewService } from '@allors/workspace/angular/base';

interface Row extends TableRow {
  object: ProductQuote;
  number: string;
  state: string;
  customer: string;
  lastModifiedDate: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'productquote-overview-panel',
  templateUrl: './productquote-overview-panel.component.html',
  providers: [PanelService],
})
export class ProductQuoteOverviewPanelComponent extends TestScope implements OnInit {
  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  objects: ProductQuote[] = [];

  delete: Action;
  table: Table<TableRow>;

  get createData(): ObjectData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
    };
  }

  constructor(
    @Self() public panel: PanelService,

    public refreshService: RefreshService,
    public navigation: NavigationService,
    public overviewService: OverviewService,
    public deleteService: DeleteService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  ngOnInit() {
    this.delete = this.deleteService.delete(this.panel.manager.context);

    this.panel.name = 'productquote';
    this.panel.title = 'Product Quotes';
    this.panel.icon = 'forward';
    this.panel.expandable = true;

    const sort = true;
    this.table = new Table({
      selection: true,
      columns: [
        { name: 'number', sort },
        { name: 'state', sort },
        { name: 'customer', sort },
        { name: 'lastModifiedDate', sort },
      ],
      actions: [this.overviewService.overview(), this.delete],
      defaultAction: this.overviewService.overview(),
      autoSort: true,
      autoFilter: true,
    });

    const assetPullName = `${this.panel.name}_${this.m.ProductQuote.name}_fixedasset`;
    const customerPullName = `${this.panel.name}_${this.m.ProductQuote.name}_customer`;

    this.panel.onPull = (pulls) => {
      const m = this.m;
      const { pullBuilder: pull } = m;
      const x = {};

      const id = this.panel.manager.id;

      pulls.push(
        pull.SerialisedItem({
          name: assetPullName,
          objectId: id,
          select: {
            QuoteItemsWhereSerialisedItem: {
              QuoteWhereQuoteItem: {
                include: {
                  QuoteState: x,
                  Receiver: x,
                },
              },
            },
          },
        }),
        pull.Party({
          name: customerPullName,
          objectId: id,
          select: {
            QuotesWhereReceiver: {
              include: {
                QuoteState: x,
                Receiver: x,
              },
            },
          },
        })
      );
    };

    this.panel.onPulled = (loaded) => {
      const fromAsset = loaded.collections[assetPullName] as ProductQuote[];
      const fromParty = loaded.collections[customerPullName] as ProductQuote[];

      if (fromAsset !== undefined && fromAsset.length > 0) {
        this.objects = fromAsset;
      }

      if (fromParty !== undefined && fromParty.length > 0) {
        this.objects = fromParty;
      }

      if (this.objects) {
        this.table.total = this.objects.length;
        this.table.data = this.objects.map((v) => {
          return {
            object: v,
            number: v.QuoteNumber,
            customer: v.Receiver.displayName,
            state: v.QuoteState ? v.QuoteState.Name : '',
            lastModifiedDate: formatDistance(new Date(v.LastModifiedDate), new Date()),
          } as Row;
        });
      }
    };
  }
}
