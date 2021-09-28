import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Person, Party, WorkEffort, WorkEffortPartyAssignment } from '@allors/workspace/domain/default';
import { ObjectData, RefreshService, SaveService, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './workeffortpartyassignment-edit.component.html',
  providers: [SessionService],
})
export class WorkEffortPartyAssignmentEditComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  workEffortPartyAssignment: WorkEffortPartyAssignment;
  people: Person[];
  person: Person;
  party: Party;
  workEffort: WorkEffort;
  assignment: WorkEffort;
  contacts: Person[] = [];
  title: string;

  private subscription: Subscription;
  employees: Person[];

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<WorkEffortPartyAssignmentEditComponent>,

    public refreshService: RefreshService,
    private saveService: SaveService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.allors.workspace.configuration.metaPopulation as M;
    const { pullBuilder: pull } = m;
    const x = {};

    this.subscription = combineLatest(this.refreshService.refresh$, this.internalOrganisationId.observable$)
      .pipe(
        switchMap(([, internalOrganisationId]) => {
          const isCreate = this.data.id === undefined;

          let pulls = [
            pull.Organisation({
              objectId: internalOrganisationId,
              select: {
                EmploymentsWhereEmployer: {
                  include: {
                    Employee: x,
                  },
                },
              },
              sorting: [{ roleType: m.Person.PartyName }],
            }),
          ];

          if (!isCreate) {
            pulls.push(
              pull.WorkEffortPartyAssignment({
                objectId: this.data.id,
                include: {
                  Assignment: x,
                  Party: x,
                },
              })
            );
          }

          if (isCreate) {
            pulls = [
              ...pulls,
              pull.Party({
                objectId: this.data.associationId,
              }),
              pull.WorkEffort({
                objectId: this.data.associationId,
              }),
            ];
          }

          return this.allors.client.pullReactive(this.allors.session, pulls).pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.session.reset();

        if (isCreate) {
          this.title = 'Add Party Assignment';

          this.workEffortPartyAssignment = this.allors.session.create<WorkEffortPartyAssignment>(m.WorkEffortPartyAssignment);
          this.party = loaded.object<Party>(m.Party);
          this.workEffort = loaded.object<WorkEffort>(m.WorkEffort);

          if (this.party !== undefined && this.party.objectType.name === m.Person.name) {
            this.person = this.party as Person;
            this.workEffortPartyAssignment.Party = this.person;
          }

          if (this.workEffort !== undefined && this.workEffort.objectType.name === m.WorkTask.name) {
            this.assignment = this.workEffort as WorkEffort;
            this.workEffortPartyAssignment.Assignment = this.assignment;
          }
        } else {
          this.workEffortPartyAssignment = loaded.object<WorkEffortPartyAssignment>(m.WorkEffortPartyAssignment);
          this.party = this.workEffortPartyAssignment.Party;
          this.workEffort = this.workEffortPartyAssignment.Assignment;
          this.person = this.workEffortPartyAssignment.Party as Person;
          this.assignment = this.workEffortPartyAssignment.Assignment;

          if (this.workEffortPartyAssignment.canWriteFromDate) {
            this.title = 'Edit Party Assignment';
          } else {
            this.title = 'View Party Assignment';
          }
        }

        // TODO: Martien
        const employments = loaded.collection<Employment>(m.Employment);
        if (this.workEffort && this.workEffort.ScheduledStart) {
          this.employees = employments.filter((v) => v.FromDate <= this.workEffort.ScheduledStart && (v.ThroughDate === null || v.ThroughDate >= this.workEffort.ScheduledStart)).map((v) => v.Employee);
        } else {
          this.employees = [this.person];
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
        id: this.workEffortPartyAssignment.id,
        objectType: this.workEffortPartyAssignment.objectType,
      };

      this.dialogRef.close(data);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }
}
