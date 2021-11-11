import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest, Observable } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Action, ObjectData, RefreshService, SaveService, TestScope } from '@allors/workspace/angular/base';
import { ContextService } from '@allors/workspace/angular/core';
import { IResult } from '@allors/workspace/domain/system';

import { PrintService } from '../../../actions/print/print.service';
import { PurchaseInvoiceApproval } from '@allors/workspace/domain/default';

@Component({
  templateUrl: './purchaseinvoiceapproval-edit.component.html',
  providers: [ContextService],
})
export class PurchaseInvoiceApprovalEditComponent extends TestScope implements OnInit, OnDestroy {
  title: string;
  subTitle: string;

  readonly m: M;

  private subscription: Subscription;

  purchaseInvoiceApproval: PurchaseInvoiceApproval;

  print: Action;

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<PurchaseInvoiceApprovalEditComponent>,
    public printService: PrintService,
    public refreshService: RefreshService,
    private saveService: SaveService
  ) {
    super();

    this.m = this.allors.context.configuration.metaPopulation as M;

    this.print = printService.print(this.m.PurchaseInvoiceApproval.PurchaseInvoice);
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(() => {
          const pulls = [
            pull.PurchaseInvoiceApproval({
              objectId: this.data.id,
              include: {
                PurchaseInvoice: {
                  PrintDocument: x,
                },
              },
            }),
          ];

          return this.allors.context.pull(pulls).pipe(map((loaded) => loaded));
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();
        this.purchaseInvoiceApproval = loaded.object<PurchaseInvoiceApproval>(m.PurchaseInvoiceApproval);

        this.title = this.purchaseInvoiceApproval.Title;
      });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  approve(): void {
    this.saveAndInvoke(() => this.allors.context.invoke(this.purchaseInvoiceApproval.Approve));
  }

  reject(): void {
    this.saveAndInvoke(() => this.allors.context.invoke(this.purchaseInvoiceApproval.Reject));
  }

  saveAndInvoke(methodCall: () => Observable<IResult>): void {
    const m = this.m;
    const { pullBuilder: pull } = m;

    this.allors.context
      .push()
      .pipe(
        switchMap(() => {
          return this.allors.context.pull([pull.PurchaseInvoiceApproval({ objectId: this.data.id })]);
        }),
        switchMap(() => {
          this.allors.context.reset();
          return methodCall();
        })
      )
      .subscribe(() => {
        this.dialogRef.close(this.purchaseInvoiceApproval);
        this.refreshService.refresh();
      }, this.saveService.errorHandler);
  }
}