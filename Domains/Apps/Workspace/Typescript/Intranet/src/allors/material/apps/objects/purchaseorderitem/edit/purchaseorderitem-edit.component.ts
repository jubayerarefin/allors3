import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatSnackBar } from '@angular/material';

import { Subscription, combineLatest } from 'rxjs';

import { ErrorService, ContextService, MetaService, RefreshService } from '../../../../../angular';
import { PurchaseOrder, PurchaseOrderItem, VatRate, VatRegime, Part, SupplierOffering } from '../../../../../domain';
import { PullRequest, Equals, And, LessThan } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { StateService } from '../../../services/state';
import { switchMap, map } from 'rxjs/operators';
import { CreateData, EditData, ObjectData } from '../../../../../material/base/services/object';
import * as moment from 'moment';

@Component({
  templateUrl: './purchaseorderitem-edit.component.html',
  providers: [ContextService]
})
export class PurchaseOrderItemEditComponent implements OnInit, OnDestroy {

  readonly m: Meta;

  title: string;
  order: PurchaseOrder;
  orderItem: PurchaseOrderItem;
  parts: Part[];
  vatRates: VatRate[];
  vatRegimes: VatRegime[];
  discount: number;
  surcharge: number;
  supplierOfferings: SupplierOffering[];
  supplierOffering: SupplierOffering;

  private subscription: Subscription;

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: CreateData & EditData,
    public dialogRef: MatDialogRef<PurchaseOrderItemEditComponent>,
    public metaService: MetaService,
    public refreshService: RefreshService,
    private errorService: ErrorService,
    public stateService: StateService,
    private snackBar: MatSnackBar) {

    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    const { pull, x } = this.metaService;

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(([]) => {

          const isCreate = (this.data as EditData).id === undefined;

          const pulls = [
            pull.PurchaseOrderItem({
              object: this.data.id,
              include: {
                PurchaseOrderItemState: x,
                Part: x,
                SerialisedItem: x,
                VatRate: x,
                VatRegime: {
                  VatRate: x,
                }
              }
            }),
            pull.PurchaseOrderItem({
              object: this.data.id,
              fetch: {
                PurchaseOrderWherePurchaseOrderItem: {
                  TakenViaSupplier: {
                    SupplierOfferingsWhereSupplier: {
                      include: {
                        Part: x
                      }
                    }
                  }
                }
              }
            }),
            pull.PurchaseOrderItem({
              object: this.data.id,
              fetch: {
                PurchaseOrderWherePurchaseOrderItem:
                {
                  include: {
                    VatRegime: x
                  }
                }
              }
            }),
            pull.VatRate(),
            pull.VatRegime(),
          ];

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.PurchaseOrder({
                object: this.data.associationId,
                include: {
                  VatRegime: x
                }
              })
            );
          }

          return this.allors.context
            .load('Pull', new PullRequest({ pulls }))
            .pipe(
              map((loaded) => ({ loaded, isCreate }))
            );
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.orderItem = loaded.objects.PurchaseOrderItem as PurchaseOrderItem;
        this.order = loaded.objects.PurchaseOrder as PurchaseOrder;
        this.vatRates = loaded.collections.VatRates as VatRate[];
        this.vatRegimes = loaded.collections.VatRegimes as VatRegime[];

        this.supplierOfferings = loaded.collections.SupplierOfferings as SupplierOffering[];
        this.parts = this.supplierOfferings.map(v => v.Part);

        if (isCreate) {
          this.title = 'Add Order Item';
          this.orderItem = this.allors.context.create('PurchaseOrderItem') as PurchaseOrderItem;
          this.order.AddPurchaseOrderItem(this.orderItem);

        } else {
          this.orderItem = loaded.objects.PurchaseOrderItem as PurchaseOrderItem;
          this.updateFromPart(this.orderItem.Part);

          if (this.orderItem.CanWriteAssignedUnitPrice) {
            this.title = 'Edit Purchase Order Item';
          } else {
            this.title = 'View Purchase Order Item';
          }
        }
      }, this.errorService.handler);
  }

  public partSelected(part: Part): void {
    if (part) {
      this.updateFromPart(part);
    }
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {

    this.allors.context.save()
      .subscribe(() => {
        const data: ObjectData = {
          id: this.orderItem.id,
          objectType: this.orderItem.objectType,
        };

        this.dialogRef.close(data);
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }

  public update(): void {
    const { context } = this.allors;

    context
      .save()
      .subscribe(() => {
        this.snackBar.open('Successfully saved.', 'close', { duration: 5000 });
        this.refreshService.refresh();
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }

  private updateFromPart(part: Part) {

    const { pull, x, m } = this.metaService;

    const pulls = [
      pull.Part(
        {
          object: part,
          fetch: {
            SupplierOfferingsWherePart: x
          }
        }
      ),
    ];

    this.allors.context
      .load('Pull', new PullRequest({ pulls }))
      .subscribe((loaded) => {

        const supplierOfferings = loaded.collections.SupplierOfferings as SupplierOffering[];
        this.supplierOffering = supplierOfferings.find(v => moment(v.FromDate).isBefore(moment())
          && (!v.ThroughDate || moment(v.ThroughDate).isAfter(moment()))
          && v.Supplier === this.order.TakenViaSupplier);

      }, this.errorService.handler);
  }
}
