import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Disbursement, Invoice, PaymentApplication } from '@allors/workspace/domain/default';
import { ObjectData, RefreshService, SaveService, TestScope } from '@allors/workspace/angular/base';
import { ContextService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

@Component({
  templateUrl: './disbursement-edit.component.html',
  providers: [ContextService],
})
export class DisbursementEditComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  disbursement: Disbursement;
  invoice: Invoice;

  title: string;

  private subscription: Subscription;
  paymentApplication: PaymentApplication;

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<DisbursementEditComponent>,

    public refreshService: RefreshService,
    private saveService: SaveService
  ) {
    super();

    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.subscription = combineLatest([this.refreshService.refresh$])
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id == null;

          const pulls = [];

          if (!isCreate) {
            pulls.push(
              pull.Disbursement({
                objectId: this.data.id,
                include: {
                  PaymentApplications: x,
                },
              })
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.Invoice({
                objectId: this.data.associationId,
              })
            );
          }

          return this.allors.context.pull(pulls).pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.invoice = loaded.object<Invoice>(m.Invoice);

        if (isCreate) {
          this.title = 'Add Disbursement';
          this.paymentApplication = this.allors.context.create<PaymentApplication>(m.PaymentApplication);
          this.paymentApplication.Invoice = this.invoice;

          this.disbursement = this.allors.context.create<Disbursement>(m.Disbursement);
          this.disbursement.addPaymentApplication(this.paymentApplication);
        } else {
          this.disbursement = loaded.object<Disbursement>(m.Disbursement);
          this.paymentApplication = this.disbursement.PaymentApplications[0];

          if (this.disbursement.canWriteAmount) {
            this.title = 'Edit Disbursement';
          } else {
            this.title = 'View Disbursement';
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
    this.paymentApplication.AmountApplied = this.disbursement.Amount;

    this.allors.context.push().subscribe(() => {
      this.dialogRef.close(this.disbursement.id);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }
}
