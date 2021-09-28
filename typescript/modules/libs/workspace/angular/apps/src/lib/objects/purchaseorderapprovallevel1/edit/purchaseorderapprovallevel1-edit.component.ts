import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest, Observable } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { SessionService, MetaService, RefreshService, Invoked } from '@allors/angular/services/core';
import { PurchaseOrderApprovalLevel1 } from '@allors/domain/generated';
import { PullRequest } from '@allors/protocol/system';
import { Meta } from '@allors/meta/generated';
import { SaveService, ObjectData } from '@allors/angular/material/services/core';
import { PrintService } from '@allors/angular/base';
import { IObject } from '@allors/domain/system';
import { Action, TestScope } from '@allors/angular/core';

@Component({
  templateUrl: './purchaseorderapprovallevel1-edit.component.html',
  providers: [SessionService]
})
export class PurchaseOrderApprovalLevel1EditComponent extends TestScope implements OnInit, OnDestroy {

  title: string;
  subTitle: string;

  readonly m: M;

  private subscription: Subscription;

  purchaseOrderApproval: PurchaseOrderApprovalLevel1;

  print: Action;

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<PurchaseOrderApprovalLevel1EditComponent>,
    
    public printService: PrintService,
    public refreshService: RefreshService,
    private saveService: SaveService,
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    this.print = printService.print(this.m.PurchaseOrderApprovalLevel1.PurchaseOrder);
  }

  public ngOnInit(): void {

    const m = this.m; const { pullBuilder: pull } = m; const x = {};

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(() => {

          const pulls = [
            pull.PurchaseOrderApprovalLevel1({
              objectId: this.data.id,
              include: {
                PurchaseOrder: {
                  PrintDocument: x
                }
              }
            }),
          ];

          return this.allors.context
            .load(new PullRequest({ pulls }))
            .pipe(
              map((loaded) => (loaded))
            );
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();
        this.purchaseOrderApproval = loaded.object<PurchaseOrderApprovalLevel1>(m.PurchaseOrderApprovalLevel1);

        this.title = this.purchaseOrderApproval.Title;
      });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  approve(): void {
    this.saveAndInvoke(() => this.allors.context.invoke(this.purchaseOrderApproval.Approve));
  }

  reject(): void {
    this.saveAndInvoke(() => this.allors.context.invoke(this.purchaseOrderApproval.Reject));
  }

  saveAndInvoke(methodCall: () => Observable<Invoked>): void {
    const { pull } = this.metaService;

    this.allors.context
      .save()
      .pipe(
        switchMap(() => {
          return this.allors.context.load(pull.PurchaseOrderApprovalLevel1({ objectId: this.data.id }));
        }),
        switchMap(() => {
          this.allors.session.reset();
          return methodCall();
        })
      )
      .subscribe(() => {
        const data: IObject = {
          id: this.purchaseOrderApproval.id,
          objectType: this.purchaseOrderApproval.objectType,
        };

        this.dialogRef.close(data);
        this.refreshService.refresh();
      },
        this.saveService.errorHandler
      );
  }
}
