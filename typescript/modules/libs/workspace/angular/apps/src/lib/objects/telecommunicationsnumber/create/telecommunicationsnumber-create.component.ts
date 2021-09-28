import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Party, PartyContactMechanism, Enumeration, TelecommunicationsNumber } from '@allors/workspace/domain/default';
import { ObjectData, RefreshService, SaveService, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './telecommunicationsnumber-create.component.html',
  providers: [SessionService],
})
export class TelecommunicationsNumberCreateComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  public title = 'Add Phone number';

  contactMechanism: TelecommunicationsNumber;
  contactMechanismTypes: Enumeration[];
  contactMechanismPurposes: Enumeration[];

  private subscription: Subscription;
  party: Party;
  partyContactMechanism: PartyContactMechanism;

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<TelecommunicationsNumberCreateComponent>,

    public refreshService: RefreshService,
    private saveService: SaveService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;

    this.subscription = combineLatest(this.refreshService.refresh$, this.internalOrganisationId.observable$)
      .pipe(
        switchMap(() => {
          const pulls = [
            pull.Party({
              objectId: this.data.associationId,
            }),
            pull.ContactMechanismType({
              predicate: { kind: 'Equals', propertyType: m.ContactMechanismType.IsActive, value: true },
              sorting: [{ roleType: this.m.ContactMechanismType.Name }],
            }),
            pull.ContactMechanismPurpose({
              predicate: { kind: 'Equals', propertyType: m.ContactMechanismPurpose.IsActive, value: true },
              sorting: [{ roleType: this.m.ContactMechanismPurpose.Name }],
            }),
          ];

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        this.contactMechanismTypes = loaded.collection<Enumeration>(m.Enumeration);
        this.contactMechanismPurposes = loaded.collection<Enumeration>(m.Enumeration);
        this.party = loaded.object<Party>(m.Party);

        this.contactMechanism = this.allors.session.create<TelecommunicationsNumber>(m.TelecommunicationsNumber);

        this.partyContactMechanism = this.allors.session.create<PartyContactMechanism>(m.PartyContactMechanism);
        this.partyContactMechanism.UseAsDefault = true;
        this.partyContactMechanism.ContactMechanism = this.contactMechanism;

        this.party.addPartyContactMechanism(this.partyContactMechanism);
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
        id: this.contactMechanism.id,
        objectType: this.contactMechanism.objectType,
      };

      this.dialogRef.close(data);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }
}
