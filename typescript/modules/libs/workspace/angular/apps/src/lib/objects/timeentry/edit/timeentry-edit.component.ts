import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { SessionService, MetaService, RefreshService, Saved } from '@allors/angular/services/core';
import {
  Party,
  PartyRate,
  TimeFrequency,
  RateType,
  TimeEntry,
  TimeSheet,
  WorkEffort,
  WorkEffortAssignmentRate,
  WorkEffortPartyAssignment,
} from '@allors/domain/generated';
import { PullRequest } from '@allors/protocol/system';
import { Meta } from '@allors/meta/generated';
import { SaveService, ObjectData } from '@allors/angular/material/services/core';
import { IObject } from '@allors/domain/system';
import { Sort } from '@allors/data/system';
import { TestScope } from '@allors/angular/core';

@Component({
  templateUrl: './timeentry-edit.component.html',
  providers: [SessionService],
})
export class TimeEntryEditComponent extends TestScope implements OnInit, OnDestroy {
  title: string;
  subTitle: string;

  readonly m: M;

  frequencies: TimeFrequency[];

  private subscription: Subscription;
  timeEntry: TimeEntry;
  timeSheet: TimeSheet;
  workers: Party[];
  selectedWorker: Party;
  workEffort: WorkEffort;
  rateTypes: RateType[];
  workEffortAssignmentRates: WorkEffortAssignmentRate[];
  workEffortRate: WorkEffortAssignmentRate;
  partyRate: PartyRate;
  derivedBillingRate: string;
  customerRate: PartyRate;

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<TimeEntryEditComponent>,
    
    public refreshService: RefreshService,
    private snackBar: MatSnackBar,
    private saveService: SaveService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m; const { pullBuilder: pull } = m; const x = {};

    const workEffortPartyAssignmentPullName = `${this.m.WorkEffortPartyAssignment.name}`;

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id === undefined;

          let pulls = [
            pull.RateType({ sorting: [{ roleType: this.m.RateType.Name }] }),
            pull.TimeFrequency({ sorting: [{ roleType: this.m.TimeFrequency.Name }] }),
          ];

          if (!isCreate) {
            pulls.push(
              pull.TimeEntry({
                objectId: this.data.id,
                include: {
                  TimeFrequency: x,
                  BillingFrequency: x,
                },
              }),
              pull.TimeEntry({
                objectId: this.data.id,
                select: {
                  WorkEffort: {
                    WorkEffortPartyAssignmentsWhereAssignment: {
                      include: {
                        Party: x,
                      },
                    },
                  },
                },
              }),
            );
          }

          if (isCreate) {
            pulls = [
              ...pulls,
              pull.WorkEffort({
                object: this.data.associationId,
              }),
              pull.WorkEffort({
                name: workEffortPartyAssignmentPullName,
                object: this.data.associationId,
                select: {
                  WorkEffortPartyAssignmentsWhereAssignment: {
                    include: {
                      Party: x,
                    },
                  },
                },
              }),
            ];
          }

          return this.allors.client.pullReactive(this.allors.session, pulls).pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.session.reset();

        this.rateTypes = loaded.collection<RateType>(m.RateType);
        this.frequencies = loaded.collection<TimeFrequency>(m.TimeFrequency);
        const hour = this.frequencies.find((v) => v.UniqueId === 'db14e5d5-5eaf-4ec8-b149-c558a28d99f5');

        if (isCreate) {
          this.workEffort = loaded.object<WorkEffort>(m.WorkEffort);

          this.title = 'Add Time Entry';
          this.timeEntry = this.allors.session.create<TimeEntry>(m.TimeEntry);
          this.timeEntry.WorkEffort = this.workEffort;
          this.timeEntry.IsBillable = true;
          this.timeEntry.BillingFrequency = hour;
          this.timeEntry.TimeFrequency = hour;

          const workEffortPartyAssignments = loaded.collections[workEffortPartyAssignmentPullName] as WorkEffortPartyAssignment[];
          this.workers = Array.from(new Set(workEffortPartyAssignments.map((v) => v.Party)).values());
        } else {
          this.timeEntry = loaded.object<TimeEntry>(m.TimeEntry);
          this.selectedWorker = this.timeEntry.Worker;
          this.workEffort = this.timeEntry.WorkEffort;

          const workEffortPartyAssignments = loaded.collection<WorkEffortPartyAssignment>(m.WorkEffortPartyAssignment);
          this.workers = Array.from(new Set(workEffortPartyAssignments.map((v) => v.Party)).values());

          if (this.timeEntry.canWriteAssignedAmountOfTime) {
            this.title = 'Edit Time Entry';
          } else {
            this.title = 'View Time Entry';
          }
        }

        if (!isCreate) {
          this.workerSelected(this.selectedWorker);
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public setDirty(): void {
    this.allors.session.hasChanges = true;
  }

  public findBillingRate(): void {
    if (this.selectedWorker && this.timeEntry.RateType && this.timeEntry.FromDate) {
      this.workerSelected(this.selectedWorker);
    }
  }

  public workerSelected(party: Party): void {
    const { pull } = this.metaService;

    const pulls = [
      pull.Party({
        object: party.id,
        select: {
          Person_TimeSheetWhereWorker: {},
        },
      }),
    ];

    this.allors.client.pullReactive(this.allors.session, pulls).subscribe((loaded) => {
      this.timeSheet = loaded.object<TimeSheet>(m.TimeSheet);
    });
  }

  public update(): void {
    const { context } = this.allors;

    context.save().subscribe(() => {
      this.snackBar.open('Successfully saved.', 'close', { duration: 5000 });
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  public save(): void {
    if (!this.timeEntry.TimeSheetWhereTimeEntry) {
      this.timeSheet.AddTimeEntry(this.timeEntry);
    }

    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      const data: IObject = {
        id: this.timeEntry.id,
        objectType: this.timeEntry.objectType,
      };

      this.dialogRef.close(data);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }
}
