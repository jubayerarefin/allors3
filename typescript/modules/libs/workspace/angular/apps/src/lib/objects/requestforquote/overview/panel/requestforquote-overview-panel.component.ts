import { Component, Self, OnInit, HostBinding } from '@angular/core';
import { formatDistance } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import { RequestForQuote } from '@allors/workspace/domain/default';
import { Action, DeleteService, NavigationService, ObjectData, PanelService, RefreshService, Table, TableRow, TestScope, OverviewService } from '@allors/workspace/angular/base';

interface Row extends TableRow {
  object: RequestForQuote;
  number: string;
  state: string;
  customer: string;
  lastModifiedDate: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'requestforquote-overview-panel',
  templateUrl: './requestforquote-overview-panel.component.html',
  providers: [PanelService],
})
export class RequestForQuoteOverviewPanelComponent extends TestScope implements OnInit {
  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  objects: RequestForQuote[] = [];

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
    this.delete = this.deleteService.delete(this.panel.manager.client, this.panel.manager.session);

    this.panel.name = 'requestsforquote';
    this.panel.title = 'Requests For Quote';
    this.panel.icon = 'shopping_cart';
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

    const assetPullName = `${this.panel.name}_${this.m.RequestForQuote.name}_fixedasset`;
    const customerPullName = `${this.panel.name}_${this.m.RequestForQuote.name}_customer`;

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
            RequestItemsWhereSerialisedItem: {
              RequestWhereRequestItem: {
                include: {
                  RequestState: x,
                  Originator: x,
                },
              },
            },
          },
        }),
        pull.Party({
          name: customerPullName,
          objectId: id,
          select: {
            RequestsWhereOriginator: {
              include: {
                RequestState: x,
                Originator: x,
              },
            },
          },
        })
      );
    };

    this.panel.onPulled = (loaded) => {
      const fromAsset = loaded.collection<RequestForQuote>(assetPullName);
      const fromParty = loaded.collection<RequestForQuote>(customerPullName);

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
            number: v.RequestNumber,
            customer: v.Originator && displayName(v.Originator),
            state: v.RequestState ? v.RequestState.Name : '',
            lastModifiedDate: formatDistance(new Date(v.LastModifiedDate), new Date()),
          } as Row;
        });
      }
    };
  }
}
