import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { SearchFactory, ContextService, MetaService, RefreshService, TestScope } from '../../../../../angular';
import { InventoryItem, NonSerialisedInventoryItem, Product, ProductQuote, QuoteItem, RequestItem, SerialisedInventoryItem, UnitOfMeasure, SerialisedItem, Part, Good, InvoiceItemType, VatRate, VatRegime, RequestItemState, RequestState, QuoteItemState, QuoteState, SalesOrderItemState, SalesOrderState, ShipmentItemState, ShipmentState } from '../../../../../domain';
import { ObjectData } from '../../../../../material/core/services/object';
import { PullRequest, Sort, Equals, IObject } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { SaveService, FiltersService } from '../../../../../material';

@Component({
  templateUrl: './quoteitem-edit.component.html',
  providers: [ContextService]
})
export class QuoteItemEditComponent extends TestScope implements OnInit, OnDestroy {

  readonly m: Meta;

  title: string;
  quote: ProductQuote;
  invoiceItemTypes: InvoiceItemType[];
  productItemType: InvoiceItemType;
  quoteItem: QuoteItem;
  requestItem: RequestItem;
  inventoryItems: InventoryItem[];
  serialisedInventoryItem: SerialisedInventoryItem;
  nonSerialisedInventoryItem: NonSerialisedInventoryItem;
  unitsOfMeasure: UnitOfMeasure[];
  goodsFilter: SearchFactory;
  part: Part;
  parts: Part[];
  serialisedItem: SerialisedItem;
  serialisedItems: SerialisedItem[] = [];
  vatRates: VatRate[];
  vatRegimes: VatRegime[];

  private previousProduct;
  private subscription: Subscription;
  goods: Good[];

  draftRequestItem: RequestItemState;
  submittedRequestItem: RequestItemState;
  anonymousRequest: RequestState;
  submittedRequest: RequestState;
  pendingCustomerRequest: RequestState;
  draftQuoteItem: QuoteItemState;
  submittedQuoteItem: QuoteItemState;
  approvedQuoteItem: QuoteItemState;
  createdQuote: QuoteState;
  approvedQuote: QuoteState;
  provisionalOrderItem: SalesOrderItemState;
  requestsApprovalOrderItem: SalesOrderItemState;
  onHoldOrderItem: SalesOrderItemState;
  inProcessOrderItem: SalesOrderItemState;
  provisionalOrder: SalesOrderState;
  requestsApprovalOrder: SalesOrderState;
  onHoldOrder: SalesOrderState;
  inProcessOrder: SalesOrderState;
  createdOrderItem: SalesOrderItemState;
  createdShipmentItem: ShipmentItemState;
  pickingShipmentItem: ShipmentItemState;
  pickedShipmentItem: ShipmentItemState;
  packedShipmentItem: ShipmentItemState;
  createdShipment: ShipmentState;
  pickingShipment: ShipmentState;
  pickedShipment: ShipmentState;
  packedShipment: ShipmentState;
  onholdShipment: ShipmentState;

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public filtersService: FiltersService,
    public dialogRef: MatDialogRef<QuoteItemEditComponent>,
    public metaService: MetaService,
    private saveService: SaveService,
    public refreshService: RefreshService,
    public snackBar: MatSnackBar
  ) {
    super();

    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    const { m, pull, x } = this.metaService;

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(() => {

          const create = (this.data as IObject).id === undefined;

          const pulls = [
            pull.QuoteItem(
              {
                object: this.data.id,
                include: {
                  QuoteItemState: x,
                  RequestItem: x,
                  Product: x,
                  SerialisedItem: x,
                  VatRate: x,
                  VatRegime: {
                    VatRate: x,
                  }
                }
              }
            ),
            pull.QuoteItem(
              {
                object: this.data.id,
                fetch: {
                  RequestItem: x
                }
              }
            ),
            pull.QuoteItem({
              object: this.data.id,
              fetch: {
                QuoteWhereQuoteItem: {
                  include: {
                    VatRegime: x
                  }
                }
              }
            }),
            pull.VatRate(),
            pull.VatRegime(),
            pull.Good(
              {
                sort: new Sort(m.Good.Name),
              }
            ),
            pull.InvoiceItemType({
              predicate: new Equals({ propertyType: m.InvoiceItemType.IsActive, value: true }),
              sort: new Sort(m.InvoiceItemType.Name),
            }),
            pull.UnitOfMeasure({
              predicate: new Equals({ propertyType: m.UnitOfMeasure.IsActive, value: true }),
              sort: [
                new Sort(m.UnitOfMeasure.Name),
              ],
            }),
            pull.RequestItemState(),
            pull.RequestState(),
            pull.QuoteItemState(),
            pull.QuoteState(),
            pull.SalesOrderItemState(),
            pull.SalesOrderState(),
            pull.ShipmentItemState(),
            pull.ShipmentState(),
          ];

          if (create && this.data.associationId) {
            pulls.push(
              pull.ProductQuote({
                object: this.data.associationId,
                include: {
                  VatRegime: x
                }
              }),
            );
          }

          return this.allors.context
            .load(new PullRequest({ pulls }))
            .pipe(
              map((loaded) => ({ loaded, create }))
            );
        })
      )
      .subscribe(({ loaded, create }) => {
        this.allors.context.reset();

        this.quote = loaded.objects.ProductQuote as ProductQuote;
        this.quoteItem = loaded.objects.QuoteItem as QuoteItem;
        this.requestItem = loaded.objects.RequestItem as RequestItem;
        this.goods = loaded.collections.Goods as Good[];
        this.vatRates = loaded.collections.VatRates as VatRate[];
        this.vatRegimes = loaded.collections.VatRegimes as VatRegime[];
        this.unitsOfMeasure = loaded.collections.UnitsOfMeasure as UnitOfMeasure[];
        const piece = this.unitsOfMeasure.find((v: UnitOfMeasure) => v.UniqueId === 'f4bbdb52-3441-4768-92d4-729c6c5d6f1b');
        this.invoiceItemTypes = loaded.collections.InvoiceItemTypes as InvoiceItemType[];
        this.productItemType = this.invoiceItemTypes.find((v: InvoiceItemType) => v.UniqueId === '0d07f778-2735-44cb-8354-fb887ada42ad');

        const requestItemStates = loaded.collections.RequestItemStates as RequestItemState[];
        this.draftRequestItem = requestItemStates.find((v: RequestItemState) => v.UniqueId === 'b173dfbe-9421-4697-8ffb-e46afc724490');
        this.submittedRequestItem = requestItemStates.find((v: RequestItemState) => v.UniqueId === 'b118c185-de34-4131-be1f-e6162c1dea4b');

        const requestStates = loaded.collections.RequestStates as RequestState[];
        this.anonymousRequest = requestStates.find((v: RequestState) => v.UniqueId === '2f054949-e30c-4954-9a3c-191559de8315');
        this.submittedRequest = requestStates.find((v: RequestState) => v.UniqueId === 'db03407d-bcb1-433a-b4e9-26cea9a71bfd');
        this.pendingCustomerRequest = requestStates.find((v: RequestState) => v.UniqueId === '671fda2f-5aa6-4ea5-b5d6-c914f0911690');

        const quoteItemStates = loaded.collections.QuoteItemStates as QuoteItemState[];
        this.draftQuoteItem = quoteItemStates.find((v: QuoteItemState) => v.UniqueId === '84ad17a3-10f7-4fdb-b76a-41bdb1edb0e6');
        this.submittedQuoteItem = quoteItemStates.find((v: QuoteItemState) => v.UniqueId === 'e511ea2d-6eb9-428d-a982-b097938a8ff8');
        this.approvedQuoteItem = quoteItemStates.find((v: QuoteItemState) => v.UniqueId === '3335810c-9e26-4604-b272-d18b831e79e0');

        const quoteStates = loaded.collections.QuoteStates as QuoteState[];
        this.createdQuote = quoteStates.find((v: QuoteState) => v.UniqueId === 'b1565cd4-d01a-4623-bf19-8c816df96aa6');
        this.approvedQuote = quoteStates.find((v: QuoteState) => v.UniqueId === '675d6899-1ebb-4fdb-9dc9-b8aef0a135d2');

        const salesOrderItemStates = loaded.collections.SalesOrderItemStates as SalesOrderItemState[];
        this.createdOrderItem = salesOrderItemStates.find((v: SalesOrderItemState) => v.UniqueId === '5b0993b5-5784-4e8d-b1ad-93affac9a913');
        this.onHoldOrderItem = salesOrderItemStates.find((v: SalesOrderItemState) => v.UniqueId === '3b185d51-af4a-441e-be0d-f91cfcbdb5d8');
        this.inProcessOrderItem = salesOrderItemStates.find((v: SalesOrderItemState) => v.UniqueId === 'e08401f7-1deb-4b27-b0c5-8f034bffedb5');

        const salesOrderStates = loaded.collections.SalesOrderStates as SalesOrderState[];
        this.provisionalOrder = salesOrderStates.find((v: SalesOrderState) => v.UniqueId === '29abc67d-4be1-4af3-b993-64e9e36c3e6b');
        this.requestsApprovalOrder = salesOrderStates.find((v: SalesOrderState) => v.UniqueId === '6b6f6e25-4da1-455d-9c9f-21f2d4316d66');
        this.onHoldOrder = salesOrderStates.find((v: SalesOrderState) => v.UniqueId === 'f625fb7e-893e-4f68-ab7b-2bc29a644e5b');
        this.inProcessOrder = salesOrderStates.find((v: SalesOrderState) => v.UniqueId === 'ddbb678e-9a66-4842-87fd-4e628cff0a75');

        const shipmentItemStates = loaded.collections.ShipmentItemStates as ShipmentItemState[];
        this.createdShipmentItem = shipmentItemStates.find((v: ShipmentItemState) => v.UniqueId === 'e05818b1-2660-4879-b5a8-8ca96f324f7b');
        this.pickingShipmentItem = shipmentItemStates.find((v: ShipmentItemState) => v.UniqueId === 'f9043add-e106-4646-8b02-6b10efbb2e87');
        this.pickedShipmentItem = shipmentItemStates.find((v: ShipmentItemState) => v.UniqueId === 'a8e2014f-c4cb-4a6f-8ccf-0875e439d1f3');
        this.packedShipmentItem = shipmentItemStates.find((v: ShipmentItemState) => v.UniqueId === '91853258-c875-4f85-bd84-ef1ebd2e5930');

        const shipmentStates = loaded.collections.ShipmentStates as ShipmentState[];
        this.createdShipment = shipmentStates.find((v: ShipmentState) => v.UniqueId === '854ad6a0-b2d1-4b92-8c3d-e9e72dd19afd');
        this.pickingShipment = shipmentStates.find((v: ShipmentState) => v.UniqueId === '1d76de65-4de4-494d-8677-653b4d62aa42');
        this.pickedShipment = shipmentStates.find((v: ShipmentState) => v.UniqueId === 'c63c5d25-f139-490f-86d1-2e9e51f5c0a5');
        this.packedShipment = shipmentStates.find((v: ShipmentState) => v.UniqueId === 'dcabe845-a6f2-49d9-bbae-06fb47012a21');
        this.onholdShipment = shipmentStates.find((v: ShipmentState) => v.UniqueId === '268cb9a7-6965-47e8-af89-8f915242c23d');

        if (create) {
          this.title = 'Add Quote Item';
          this.quoteItem = this.allors.context.create('QuoteItem') as QuoteItem;
          this.quoteItem.UnitOfMeasure = piece;
          this.quote.AddQuoteItem(this.quoteItem);
        } else {

          if (this.quoteItem.Product) {
            this.previousProduct = this.quoteItem.Product;
            this.refreshSerialisedItems(this.quoteItem.Product);
          } else {
            this.serialisedItems.push(this.quoteItem.SerialisedItem);
          }

          if (this.quoteItem.CanWriteQuantity) {
            this.title = 'Edit Quote Item';
          } else {
            this.title = 'View Quote Item';
          }
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public goodSelected(product: Product): void {
    if (product) {
      this.refreshSerialisedItems(product);
    }
  }

  public serialisedItemSelected(serialisedItem: SerialisedItem): void {

    if (serialisedItem !== undefined) {
      const onRequestItem = serialisedItem.RequestItemsWhereSerialisedItem
        .find(v => (v.RequestItemState === this.draftRequestItem || v.RequestItemState === this.submittedRequestItem)
          && (v.RequestWhereRequestItem.RequestState === this.anonymousRequest || v.RequestWhereRequestItem.RequestState === this.submittedRequest || v.RequestWhereRequestItem.RequestState === this.pendingCustomerRequest));

      const onOtherQuoteItem = serialisedItem.QuoteItemsWhereSerialisedItem
        .find(v => (v.QuoteItemState === this.draftQuoteItem || v.QuoteItemState === this.submittedQuoteItem || v.QuoteItemState === this.approvedQuoteItem)
          && (v.QuoteWhereQuoteItem.QuoteState === this.createdQuote || v.QuoteWhereQuoteItem.QuoteState === this.approvedQuote));

      const onOrderItem = serialisedItem.SalesOrderItemsWhereSerialisedItem
        .find(v => (v.SalesOrderItemState === this.createdOrderItem || v.SalesOrderItemState === this.onHoldOrderItem || v.SalesOrderItemState === this.inProcessOrderItem)
          && (v.SalesOrderWhereSalesOrderItem.SalesOrderState === this.provisionalOrder || v.SalesOrderWhereSalesOrderItem.SalesOrderState === this.requestsApprovalOrder)
          || v.SalesOrderWhereSalesOrderItem.SalesOrderState === this.onHoldOrder || v.SalesOrderWhereSalesOrderItem.SalesOrderState === this.inProcessOrder);

      const onShipmentItem = serialisedItem.ShipmentItemsWhereSerialisedItem
        .find(v => (v.ShipmentItemState === this.createdShipmentItem || v.ShipmentItemState === this.pickingShipmentItem || v.ShipmentItemState === this.pickedShipmentItem || v.ShipmentItemState === this.packedShipmentItem)
          && (v.ShipmentWhereShipmentItem.ShipmentState === this.createdShipment || v.ShipmentWhereShipmentItem.ShipmentState === this.pickingShipment)
          || v.ShipmentWhereShipmentItem.ShipmentState === this.pickingShipment || v.ShipmentWhereShipmentItem.ShipmentState === this.packedShipment
          || v.ShipmentWhereShipmentItem.ShipmentState === this.onholdShipment);

      if (onRequestItem) {
        this.snackBar.open(`Item already requested with ${onRequestItem.RequestWhereRequestItem.RequestNumber}`, 'close');
      }

      if (onOtherQuoteItem) {
        this.snackBar.open(`Item already quoted with ${onOtherQuoteItem.QuoteWhereQuoteItem.QuoteNumber}`, 'close');
      }

      if (onOrderItem) {
        this.snackBar.open(`Item already ordered with ${onOrderItem.SalesOrderWhereSalesOrderItem.OrderNumber}`, 'close');
      }

      if (onShipmentItem) {
        this.snackBar.open(`Item already shipped with ${onShipmentItem.ShipmentWhereShipmentItem.ShipmentNumber}`, 'close');
      }

      this.serialisedItem = this.part.SerialisedItems.find(v => v === serialisedItem);
      this.quoteItem.AssignedUnitPrice = this.serialisedItem.ExpectedSalesPrice;
      this.quoteItem.Quantity = '1';
    }
  }

  public save(): void {

    this.allors.context.save()
      .subscribe(() => {
        const data: IObject = {
          id: this.quoteItem.id,
          objectType: this.quoteItem.objectType,
        };

        this.dialogRef.close(data);
      },
        this.saveService.errorHandler
      );
  }

  private refreshSerialisedItems(product: Product): void {

    const { pull, x } = this.metaService;

    const pulls = [
      pull.NonUnifiedGood({
        object: product.id,
        fetch: {
          Part: {
            include: {
              SerialisedItems: {
                RequestItemsWhereSerialisedItem: {
                  RequestItemState: x,
                  RequestWhereRequestItem: {
                    RequestState: x
                  }
                },
                QuoteItemsWhereSerialisedItem: {
                  QuoteItemState: x,
                  QuoteWhereQuoteItem: {
                    QuoteState: x
                  }
                },
                SalesOrderItemsWhereSerialisedItem: {
                  SalesOrderItemState: x,
                  SalesOrderWhereSalesOrderItem: {
                    SalesOrderState: x
                  }
                },
                ShipmentItemsWhereSerialisedItem: {
                  ShipmentItemState: x,
                  ShipmentWhereShipmentItem: {
                    ShipmentState: x
                  }
                }
              }
            }
          }
        }
      }),
      pull.UnifiedGood({
        object: product.id,
        include: {
          SerialisedItems: {
            RequestItemsWhereSerialisedItem: {
              RequestItemState: x,
              RequestWhereRequestItem: {
                RequestState: x
              }
            },
            QuoteItemsWhereSerialisedItem: {
              QuoteItemState: x,
              QuoteWhereQuoteItem: {
                QuoteState: x
              }
            },
            SalesOrderItemsWhereSerialisedItem: {
              SalesOrderItemState: x,
              SalesOrderWhereSalesOrderItem: {
                SalesOrderState: x
              }
            },
            ShipmentItemsWhereSerialisedItem: {
              ShipmentItemState: x,
              ShipmentWhereShipmentItem: {
                ShipmentState: x
              }
            }
          }
        }
      })
    ];

    this.allors.context
      .load(new PullRequest({ pulls }))
      .subscribe((loaded) => {
        this.part = (loaded.objects.UnifiedGood || loaded.objects.Part) as Part;
        this.serialisedItems = this.part.SerialisedItems.filter(v => v.AvailableForSale === true);

        if (this.quoteItem.Product !== this.previousProduct) {
          this.quoteItem.SerialisedItem = null;
          this.serialisedItem = null;
          this.previousProduct = this.quoteItem.Product;
        }

      });
  }
}
