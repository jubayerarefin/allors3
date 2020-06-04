import { Component, Self, OnInit, HostBinding } from '@angular/core';
import { NavigationService, Action, PanelService, RefreshService, MetaService, TestScope } from '../../../../../../angular';
import { SalesInvoice, SerialisedItem } from '../../../../../../domain';
import { Meta } from '../../../../../../meta';
import { DeleteService, TableRow, Table, OverviewService, ObjectData } from '../../../../..';
import * as moment from 'moment/moment';

interface Row extends TableRow {
  object: SalesInvoice;
  number: string;
  state: string;
  customer: string;
  lastModifiedDate: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'salesinvoice-overview-panel',
  templateUrl: './salesinvoice-overview-panel.component.html',
  providers: [PanelService]
})
export class SalesInvoiceOverviewPanelComponent extends TestScope implements OnInit {

  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: Meta;

  objects: SalesInvoice[] = [];

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
    public metaService: MetaService,
    public refreshService: RefreshService,
    public navigation: NavigationService,
    public overviewService: OverviewService,
    public deleteService: DeleteService,
  ) {
    super();

    this.m = this.metaService.m;
  }

  ngOnInit() {

    this.delete = this.deleteService.delete(this.panel.manager.context);

    this.panel.name = 'salesinvoice';
    this.panel.title = 'Sales Invoices';
    this.panel.icon = 'money';
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
      actions: [
        this.overviewService.overview(),
        this.delete,
      ],
      defaultAction: this.overviewService.overview(),
      autoSort: true,
      autoFilter: true,
    });

    const assetPullName = `${this.panel.name}_${this.m.SalesInvoice.name}_fixedasset`;
    const customerPullName = `${this.panel.name}_${this.m.SalesInvoice.name}_customer`;

    this.panel.onPull = (pulls) => {
      const { pull, x } = this.metaService;

      const id = this.panel.manager.id;

      pulls.push(
        pull.SerialisedItem({
          name: assetPullName,
          object: id,
          fetch: {
            SalesInvoiceItemsWhereSerialisedItem: {
              SalesInvoiceWhereSalesInvoiceItem: {
                include: {
                  SalesInvoiceState: x,
                  BillToCustomer: x,
                }
              }
            }
          }
        }),
        pull.Party({
          name: customerPullName,
          object: id,
          fetch: {
            SalesInvoicesWhereBillToCustomer: {
              include: {
                SalesInvoiceState: x,
                BillToCustomer: x,
              }
            }
          }
        }),
      );
    };

    this.panel.onPulled = (loaded) => {

      const fromAsset = loaded.collections[assetPullName] as SalesInvoice[];
      const fromParty = loaded.collections[customerPullName] as SalesInvoice[];

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
            number: v.InvoiceNumber,
            customer: v.BillToCustomer.displayName,
            state: v.SalesInvoiceState ? v.SalesInvoiceState.Name : '',
            lastModifiedDate: moment(v.LastModifiedDate).fromNow()
          } as Row;
        });
      }
    };
  }
}
