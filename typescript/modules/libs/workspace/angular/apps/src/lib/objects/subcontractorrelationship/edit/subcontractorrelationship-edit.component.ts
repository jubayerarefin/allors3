import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { SessionService, MetaService, RefreshService, Context } from '@allors/angular/services/core';
import { Organisation, SubContractorRelationship } from '@allors/domain/generated';
import { PullRequest } from '@allors/protocol/system';
import { Meta, ids } from '@allors/meta/generated';
import { SaveService, ObjectData } from '@allors/angular/material/services/core';
import { InternalOrganisationId, FetcherService } from '@allors/angular/base';
import { IObject } from '@allors/domain/system';
import { TestScope } from '@allors/angular/core';

@Component({
  templateUrl: './subcontractorrelationship-edit.component.html',
  providers: [SessionService]
})
export class SubContractorRelationshipEditComponent extends TestScope implements OnInit, OnDestroy {

  readonly m: M;

  partyRelationship: SubContractorRelationship;
  internalOrganisation: Organisation;
  organisation: Organisation;
  title: string;

  private subscription: Subscription;

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<SubContractorRelationshipEditComponent>,
    
    public refreshService: RefreshService,
    private saveService: SaveService,
    private internalOrganisationId: InternalOrganisationId,
    private fetcher: FetcherService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  static canCreate(createData: ObjectData) {

    const personId = ids.Person;
    if (createData.associationObjectType.id === personId) {
      return false;
    }

    return true;
  }

  public ngOnInit(): void {

    const m = this.m; const { pullBuilder: pull } = m; const x = {};

    this.subscription = combineLatest(this.refreshService.refresh$, this.internalOrganisationId.observable$)
      .pipe(
        switchMap(() => {

          const isCreate = this.data.id === undefined;

          const pulls = [
            this.fetcher.internalOrganisation,
          ];

          if (!isCreate) {
            pulls.push(
              pull.SubContractorRelationship({
                objectId: this.data.id,
                include: {
                  Contractor: x,
                  SubContractor: x,
                  Parties: x
                }
              }),
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.Organisation({
                object: this.data.associationId,
              }),
            );
          }

          return this.allors.context
            .load(new PullRequest({ pulls }))
            .pipe(
              map((loaded) => ({ loaded, isCreate }))
            );
        })
      )
      .subscribe(({ loaded, isCreate }) => {

        this.allors.session.reset();

        this.internalOrganisation = loaded.object<InternalOrganisation>(m.InternalOrganisation);
        this.organisation = loaded.object<Organisation>(m.Organisation);

        if (isCreate) {

          if (this.organisation === undefined) {
            this.dialogRef.close();
          }

          this.title = 'Add SubContractor Relationship';

          this.partyRelationship = this.allors.session.create<SubContractorRelationship>(m.SubContractorRelationship);
          this.partyRelationship.FromDate = new Date().toISOString();
          this.partyRelationship.SubContractor = this.organisation;
          this.partyRelationship.Contractor = this.internalOrganisation;
        } else {
          this.partyRelationship = loaded.object<SubContractorRelationship>(m.SubContractorRelationship);

          if (this.partyRelationship.canWriteFromDate) {
            this.title = 'Edit SubContractor Relationship';
          } else {
            this.title = 'View SubContractor Relationship';
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

    this.allors.client.pushReactive(this.allors.session)
      .subscribe(() => {
        const data: IObject = {
          id: this.partyRelationship.id,
          objectType: this.partyRelationship.objectType,
        };

        this.dialogRef.close(data);
        this.refreshService.refresh();
      },
        this.saveService.errorHandler
      );
  }
}
