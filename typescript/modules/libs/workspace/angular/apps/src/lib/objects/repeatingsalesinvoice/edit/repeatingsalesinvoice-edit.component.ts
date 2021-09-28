import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { SessionService, MetaService, RefreshService } from '@allors/angular/services/core';
import { TimeFrequency, SalesInvoice, DayOfWeek, RepeatingSalesInvoice } from '@allors/domain/generated';
import { PullRequest } from '@allors/protocol/system';
import { Meta } from '@allors/meta/generated';
import { SaveService, ObjectData } from '@allors/angular/material/services/core';
import { IObject } from '@allors/domain/system';
import { Equals, Sort } from '@allors/data/system';
import { TestScope } from '@allors/angular/core';

@Component({
  templateUrl: './repeatingsalesinvoice-edit.component.html',
  providers: [SessionService],
})
export class RepeatingSalesInvoiceEditComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  title: string;
  repeatinginvoice: RepeatingSalesInvoice;
  frequencies: TimeFrequency[];
  daysOfWeek: DayOfWeek[];
  invoice: SalesInvoice;

  private subscription: Subscription;

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<RepeatingSalesInvoiceEditComponent>,
    
    private saveService: SaveService,
    public refreshService: RefreshService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const { m, pull, x } = this.metaService;

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id === undefined;
          const id = this.data.id;

          const pulls = [
            pull.TimeFrequency({
              predicate: { kind: 'Equals', propertyType: m.TimeFrequency.IsActive, value: true },
              sorting: [{ roleType: m.TimeFrequency.Name }],
            }),
            pull.DayOfWeek(),
          ];

          if (!isCreate) {
            pulls.push(
              pull.RepeatingSalesInvoice({
                objectId: id,
                include: {
                  Frequency: x,
                  DayOfWeek: x,
                },
              }),
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.SalesInvoice({ object: this.data.associationId }),
            );
          }

          return this.allors.client.pullReactive(this.allors.session, pulls).pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.session.reset();

        this.invoice = loaded.object<SalesInvoice>(m.SalesInvoice);
        this.repeatinginvoice = loaded.object<RepeatingSalesInvoice>(m.RepeatingSalesInvoice);
        this.frequencies = loaded.collection<TimeFrequency>(m.TimeFrequency);
        this.daysOfWeek = loaded.collection<DayOfWeek>(m.DayOfWeek);

        if (isCreate) {
          this.title = 'Create Repeating Invoice';
          this.repeatinginvoice = this.allors.session.create<RepeatingSalesInvoice>(m.RepeatingSalesInvoice);
          this.repeatinginvoice.Source = this.invoice;
        } else {
          if (this.repeatinginvoice.canWriteFrequency) {
            this.title = 'Edit Repeating Invoice';
          } else {
            this.title = 'View Repeating Invoice';
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
    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      const data: IObject = {
        id: this.repeatinginvoice.id,
        objectType: this.repeatinginvoice.objectType,
      };

      this.dialogRef.close(data);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }
}
