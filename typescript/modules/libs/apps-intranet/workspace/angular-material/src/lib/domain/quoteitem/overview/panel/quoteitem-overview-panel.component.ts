import { Component, Self, HostBinding } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { formatDistance } from 'date-fns';

import { M } from '@allors/default/workspace/meta';
import { ProductQuote, QuoteItem } from '@allors/default/workspace/domain';
import {
  Action,
  DeleteService,
  EditService,
  MethodService,
  NavigationService,
  ObjectData,
  ScopedService,
  OldPanelService,
  RefreshService,
  Table,
  TableRow,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

interface Row extends TableRow {
  object: QuoteItem;
  itemType: string;
  item: string;
  itemId: string;
  state: string;
  quantity: string;
  price: string;
  totalAmount: string;
  lastModifiedDate: string;
}

@Component({
  selector: 'quoteitem-overview-panel',
  templateUrl: './quoteitem-overview-panel.component.html',
  providers: [ContextService, OldPanelService],
})
export class QuoteItemOverviewPanelComponent {
  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  quote: ProductQuote;
  quoteItems: QuoteItem[];
  table: Table<Row>;
  quoteItem: QuoteItem;

  delete: Action;
  edit: Action;
  cancel: Action;
  reject: Action;
  submit: Action;

  get createData(): ObjectData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
      associationRoleType: this.m.Quote.QuoteItems,
    };
  }

  constructor(
    @Self() public allors: ContextService,
    @Self() public panel: OldPanelService,
    public scopedService: ScopedService,
    public refreshService: RefreshService,
    public navigation: NavigationService,
    public methodService: MethodService,
    public editService: EditService,
    public deleteService: DeleteService,
    public snackBar: MatSnackBar
  ) {
    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;

    panel.name = 'quoteitem';
    panel.title = 'Quote Items';
    panel.icon = 'contacts';
    panel.expandable = true;

    this.delete = deleteService.delete(panel.manager.context);
    this.edit = this.editService.edit();
    this.cancel = methodService.create(
      allors.context,
      this.m.QuoteItem.Cancel,
      { name: 'Cancel' }
    );
    this.reject = methodService.create(
      allors.context,
      this.m.QuoteItem.Reject,
      { name: 'Reject' }
    );
    this.submit = methodService.create(
      allors.context,
      this.m.QuoteItem.Submit,
      { name: 'Submit' }
    );

    const sort = true;
    this.table = new Table({
      selection: true,
      columns: [
        { name: 'itemType' },
        { name: 'item' },
        { name: 'itemId' },
        { name: 'state' },
        { name: 'quantity' },
        { name: 'price' },
        { name: 'totalAmount' },
        { name: 'lastModifiedDate', sort },
      ],
      actions: [this.edit, this.delete, this.cancel, this.reject, this.submit],
      defaultAction: this.edit,
      autoSort: true,
      autoFilter: true,
    });

    const pullName = `${panel.name}_${this.m.QuoteItem.tag}`;
    const quotePullName = `${panel.name}_${this.m.ProductQuote.tag}`;

    panel.onPull = (pulls) => {
      const m = this.m;
      const { pullBuilder: pull } = m;
      const x = {};

      const id = this.panel.manager.id;

      pulls.push(
        pull.Quote({
          name: pullName,
          objectId: id,
          select: {
            QuoteItems: {
              include: {
                Product: x,
                SerialisedItem: x,
                InvoiceItemType: x,
              },
            },
          },
        }),
        pull.Quote({
          name: quotePullName,
          objectId: id,
        })
      );
    };

    panel.onPulled = (loaded) => {
      this.quoteItems = loaded.collection<QuoteItem>(pullName);
      this.quote = loaded.object<ProductQuote>(quotePullName);
      this.table.total =
        (loaded.value(`${pullName}_total`) as number) ??
        this.quoteItems?.length ??
        0;
      this.table.data = this.quoteItems?.map((v) => {
        return {
          object: v,
          itemType: v.InvoiceItemType.Name,
          item:
            (v.Product && v.Product.Name) ||
            (v.SerialisedItem && v.SerialisedItem.Name) ||
            '',
          itemId: `${v.SerialisedItem && v.SerialisedItem.ItemNumber}`,
          state: `${v.QuoteItemState && v.QuoteItemState.Name}`,
          quantity: v.Quantity,
          price: v.UnitPrice,
          totalAmount: v.TotalExVat,
          lastModifiedDate: formatDistance(
            new Date(v.LastModifiedDate),
            new Date()
          ),
        } as Row;
      });
    };
  }
}
