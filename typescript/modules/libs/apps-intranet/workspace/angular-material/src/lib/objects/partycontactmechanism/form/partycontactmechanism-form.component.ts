import { Component, Self } from '@angular/core';
import { NgForm } from '@angular/forms';

import {
  EditIncludeHandler,
  Node,
  CreateOrEditPullHandler,
  Pull,
  IPullResult,
  PostCreatePullHandler,
} from '@allors/system/workspace/domain';
import {
  BasePrice,
  InternalOrganisation,
} from '@allors/default/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  ErrorService,
  AllorsFormComponent,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './partycontactmechanism-form.component.html',
  providers: [ContextService],
})
export class PartyContactmechanismFormComponent implements OnInit, OnDestroy {
  readonly m: M;

  partyContactMechanism: PartyContactMechanism;
  contactMechanismPurposes: Enumeration[];
  contactMechanisms: ContactMechanism[] = [];
  organisationContactMechanisms: ContactMechanism[];
  ownContactMechanisms: ContactMechanism[] = [];
  title: string;

  private subscription: Subscription;
  party: Party;

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<PartyContactmechanismFormComponent>,
    public refreshService: RefreshService,
    private errorService: ErrorService,
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

          const pulls = [
            pull.ContactMechanismPurpose({
              predicate: {
                kind: 'Equals',
                propertyType: m.ContactMechanismPurpose.IsActive,
                value: true,
              },
              sorting: [{ roleType: this.m.ContactMechanismPurpose.Name }],
            }),
          ];

          if (!isCreate) {
            pulls.push(
              pull.PartyContactMechanism({
                objectId: this.data.id,
                include: {
                  ContactMechanism: x,
                },
              }),
              pull.PartyContactMechanism({
                objectId: this.data.id,
                select: {
                  PartyWherePartyContactMechanism: {
                    include: {
                      CurrentPartyContactMechanisms: {
                        ContactMechanism: x,
                      },
                    },
                  },
                },
              })
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.Party({
                objectId: this.data.associationId,
                include: {
                  CurrentPartyContactMechanisms: {
                    ContactMechanism: x,
                  },
                },
              }),
              pull.Person({
                objectId: this.data.associationId,
                select: {
                  CurrentOrganisationContactMechanisms: x,
                },
              })
            );
          }

          return this.allors.context
            .pull(pulls)
            .pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.contactMechanisms = [];
        this.ownContactMechanisms = [];

        this.contactMechanismPurposes =
          loaded.collection<ContactMechanismPurpose>(m.ContactMechanismPurpose);

        this.party =
          loaded.object<Party>(m.Party) ||
          loaded.object<Party>('PARTYWHEREPARTYCONTACTMECHANISM');

        this.organisationContactMechanisms =
          loaded.collection<ContactMechanism>(
            m.Person.CurrentOrganisationContactMechanisms
          );

        this.party.CurrentPartyContactMechanisms.forEach((v) =>
          this.ownContactMechanisms.push(v.ContactMechanism)
        );

        if (this.organisationContactMechanisms != null) {
          this.contactMechanisms = this.contactMechanisms.concat(
            this.organisationContactMechanisms
          );
        }

        if (this.ownContactMechanisms != null) {
          this.contactMechanisms = this.contactMechanisms.concat(
            this.ownContactMechanisms
          );
        }

        if (isCreate) {
          this.title = 'Add Party ContactMechanism';

          this.partyContactMechanism =
            this.allors.context.create<PartyContactMechanism>(
              m.PartyContactMechanism
            );
          this.partyContactMechanism.FromDate = new Date();
          this.partyContactMechanism.UseAsDefault = true;

          this.party.addPartyContactMechanism(this.partyContactMechanism);
        } else {
          this.partyContactMechanism = loaded.object<PartyContactMechanism>(
            m.PartyContactMechanism
          );

          if (this.partyContactMechanism.canWriteComment) {
            this.title = 'Edit Party ContactMechanism';
          } else {
            this.title = 'View Party ContactMechanism';
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
    this.allors.context.push().subscribe(() => {
      this.dialogRef.close(this.partyContactMechanism);
      this.refreshService.refresh();
    }, this.errorService.errorHandler);
  }
}
