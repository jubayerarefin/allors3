import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

import { M } from '@allors/default/workspace/meta';
import {
  Person,
  Organisation,
  OrganisationContactRelationship,
  Party,
  InternalOrganisation,
  CommunicationEventPurpose,
  CommunicationEventState,
  FaceToFaceCommunication,
} from '@allors/default/workspace/domain';
import {
  ObjectData,
  RefreshService,
  SaveService,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';
import { IObject } from '@allors/system/workspace/domain';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './facetofacecommunication-edit.component.html',
  providers: [ContextService],
})
export class FaceToFaceCommunicationEditComponent implements OnInit, OnDestroy {
  readonly m: M;

  addFromParty = false;
  addToParty = false;

  party: Party;
  person: Person;
  organisation: Organisation;
  purposes: CommunicationEventPurpose[];
  contacts: Party[] = [];
  communicationEvent: FaceToFaceCommunication;
  eventStates: CommunicationEventState[];
  title: string;

  private subscription: Subscription;
  parties: Party[];

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<FaceToFaceCommunicationEditComponent>,

    public refreshService: RefreshService,
    private saveService: SaveService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.subscription = combineLatest(
      this.refreshService.refresh$,
      this.internalOrganisationId.observable$
    )
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id == null;

          let pulls = [
            pull.Organisation({
              objectId: this.internalOrganisationId.value,
              name: 'InternalOrganisation',
              include: {
                ActiveEmployees: {
                  CurrentPartyContactMechanisms: {
                    ContactMechanism: x,
                  },
                },
              },
            }),
            pull.CommunicationEventPurpose({
              predicate: {
                kind: 'Equals',
                propertyType: m.CommunicationEventPurpose.IsActive,
                value: true,
              },
              sorting: [{ roleType: m.CommunicationEventPurpose.Name }],
            }),
            pull.CommunicationEventState({
              sorting: [{ roleType: m.CommunicationEventState.Name }],
            }),
          ];

          if (!isCreate) {
            pulls = [
              ...pulls,
              pull.FaceToFaceCommunication({
                objectId: this.data.id,
                include: {
                  FromParty: {
                    CurrentPartyContactMechanisms: {
                      ContactMechanism: x,
                    },
                  },
                  ToParty: {
                    CurrentPartyContactMechanisms: {
                      ContactMechanism: x,
                    },
                  },
                  EventPurposes: x,
                  CommunicationEventState: x,
                },
              }),
              pull.CommunicationEvent({
                objectId: this.data.id,
                select: {
                  InvolvedParties: {
                    include: {
                      CurrentContacts: x,
                    },
                  },
                },
              }),
            ];
          }

          if (isCreate && this.data.associationId) {
            pulls = [
              ...pulls,
              pull.Organisation({
                objectId: this.data.associationId,
                include: {
                  CurrentContacts: x,
                  CurrentPartyContactMechanisms: {
                    ContactMechanism: x,
                  },
                },
              }),
              pull.Person({
                objectId: this.data.associationId,
              }),
              pull.Person({
                objectId: this.data.associationId,
                select: {
                  OrganisationContactRelationshipsWhereContact: {
                    Organisation: {
                      include: {
                        CurrentContacts: x,
                        CurrentPartyContactMechanisms: {
                          ContactMechanism: x,
                        },
                      },
                    },
                  },
                },
              }),
            ];
          }

          return this.allors.context
            .pull(pulls)
            .pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.purposes = loaded.collection<CommunicationEventPurpose>(
          m.CommunicationEventPurpose
        );
        this.eventStates = loaded.collection<CommunicationEventState>(
          m.CommunicationEventState
        );
        this.parties = loaded.collection<Party>(
          m.CommunicationEvent.InvolvedParties
        );
        const internalOrganisation = loaded.object<InternalOrganisation>(
          m.InternalOrganisation
        );

        this.person = loaded.object<Person>(m.Person);
        this.organisation = loaded.object<Organisation>(
          m.OrganisationContactRelationship.Organisation
        );

        if (isCreate) {
          this.title = 'Add Meeting';
          this.communicationEvent =
            this.allors.context.create<FaceToFaceCommunication>(
              m.FaceToFaceCommunication
            );

          this.party = this.organisation || this.person;
        } else {
          this.communicationEvent = loaded.object<FaceToFaceCommunication>(
            m.FaceToFaceCommunication
          );

          if (this.communicationEvent.canWriteActualEnd) {
            this.title = 'Edit Meeting';
          } else {
            this.title = 'View Meeting';
          }
        }

        const contacts = new Set<Party>();

        if (this.organisation) {
          contacts.add(this.organisation);
        }

        if (internalOrganisation.ActiveEmployees != null) {
          internalOrganisation.ActiveEmployees?.reduce(
            (c, e) => c.add(e),
            contacts
          );
        }

        if (this.organisation && this.organisation.CurrentContacts != null) {
          this.organisation.CurrentContacts?.reduce(
            (c, e) => c.add(e),
            contacts
          );
        }

        if (this.person) {
          contacts.add(this.person);
        }

        if (this.parties) {
          this.parties?.reduce((c, e) => c.add(e), contacts);
        }

        this.contacts.push(...contacts);
        this.sortContacts();
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public fromPartyAdded(fromParty: Person): void {
    this.addContactRelationship(fromParty);
    this.communicationEvent.FromParty = fromParty;
    this.contacts.push(fromParty);
    this.sortContacts();
  }

  public toPartyAdded(toParty: Person): void {
    this.addContactRelationship(toParty);
    this.communicationEvent.ToParty = toParty;
    this.contacts.push(toParty);
    this.sortContacts();
  }

  private sortContacts(): void {
    this.contacts.sort((a, b) =>
      a.DisplayName > b.DisplayName ? 1 : b.DisplayName > a.DisplayName ? -1 : 0
    );
  }

  public save(): void {
    this.allors.context.push().subscribe(() => {
      this.dialogRef.close(this.communicationEvent);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  private addContactRelationship(party: Person): void {
    if (this.organisation) {
      const relationShip: OrganisationContactRelationship =
        this.allors.context.create<OrganisationContactRelationship>(
          this.m.OrganisationContactRelationship
        );
      relationShip.Contact = party;
      relationShip.Organisation = this.organisation;
    }
  }
}
