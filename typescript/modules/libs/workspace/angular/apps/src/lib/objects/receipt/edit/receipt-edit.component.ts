import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { SessionService, MetaService, RefreshService } from '@allors/angular/services/core';
import { Receipt, SalesInvoice, PaymentApplication, Invoice } from '@allors/domain/generated';
import { PullRequest } from '@allors/protocol/system';
import { Meta } from '@allors/meta/generated';
import { SaveService, ObjectData } from '@allors/angular/material/services/core';
import { IObject } from '@allors/domain/system';
import { TestScope } from '@allors/angular/core';

@Component({
  templateUrl: './receipt-edit.component.html',
  providers: [SessionService],
})
export class ReceiptEditComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  receipt: Receipt;
  invoice: Invoice;

  title: string;

  private subscription: Subscription;
  paymentApplication: PaymentApplication;

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<ReceiptEditComponent>,
    
    public refreshService: RefreshService,
    private saveService: SaveService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const { pullBuilder: pull } = this.m; const x = {};

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id === undefined;

          const pulls = [
          ];

          if (!isCreate) {
            pulls.push(
              pull.Receipt({
                object: this.data.id,
                include: {
                  PaymentApplications: x,
                },
              }),
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.Invoice({
                object: this.data.associationId,
              })
            );
          }

          return this.allors.context.load(new PullRequest({ pulls })).pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.invoice = loaded.objects.Invoice as Invoice;

        if (isCreate) {
          this.title = 'Add Receipt';
          this.paymentApplication = this.allors.context.create('PaymentApplication') as PaymentApplication;
          this.paymentApplication.Invoice = this.invoice;

          this.receipt = this.allors.context.create('Receipt') as Receipt;
          this.receipt.AddPaymentApplication(this.paymentApplication);
        } else {
          this.receipt = loaded.objects.Receipt as Receipt;
          this.paymentApplication = this.receipt.PaymentApplications[0];

          if (this.receipt.CanWriteAmount) {
            this.title = 'Edit Receipt';
          } else {
            this.title = 'View Receipt';
          }
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.paymentApplication.AmountApplied = this.receipt.Amount;

    this.allors.context.save().subscribe(() => {
      const data: IObject = {
        id: this.receipt.id,
        objectType: this.receipt.objectType,
      };

      this.dialogRef.close(data);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }
}
