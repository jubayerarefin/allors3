import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Subscription, combineLatest } from 'rxjs';

import { ContextService, MetaService, RefreshService, InternalOrganisationId, TestScope } from '../../../../../angular';
import { PostalAddress, Enumeration, Country, Party, PartyContactMechanism } from '../../../../../domain';
import { PullRequest, Sort, Equals, IObject } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { switchMap } from 'rxjs/operators';
import { ObjectData } from '../../../../../../allors/material/core/services/object';
import { SaveService } from '../../../../../../allors/material';

@Component({
  templateUrl: './postaladdress-create.component.html',
  providers: [ContextService]
})
export class PostalAddressCreateComponent extends TestScope implements OnInit, OnDestroy {

  readonly m: Meta;

  public title = 'Add Postal Address';

  contactMechanism: PostalAddress;
  countries: Country[];
  party: Party;
  contactMechanismPurposes: Enumeration[];
  partyContactMechanism: PartyContactMechanism;

  private subscription: Subscription;

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<PostalAddressCreateComponent>,
    public metaService: MetaService,
    public refreshService: RefreshService,
    private saveService: SaveService,
    private internalOrganisationId: InternalOrganisationId,
  ) {

    super();

    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    const { m, pull } = this.metaService;

    this.subscription = combineLatest(this.refreshService.refresh$, this.internalOrganisationId.observable$)
      .pipe(
        switchMap(() => {

          const pulls = [
            pull.Party({
              object: this.data.associationId,
            }),
            pull.Country({
              sort: new Sort(m.Country.Name)
            }),
            pull.ContactMechanismPurpose({
              predicate: new Equals({ propertyType: m.ContactMechanismPurpose.IsActive, value: true }),
              sort: new Sort(this.m.ContactMechanismPurpose.Name)
            })
          ];

          return this.allors.context
            .load('Pull', new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {

        this.allors.context.reset();

        this.countries = loaded.collections.Countries as Country[];
        this.contactMechanismPurposes = loaded.collections.ContactMechanismPurposes as Enumeration[];
        this.party = loaded.objects.Party as Party;

        this.contactMechanism = this.allors.context.create('PostalAddress') as PostalAddress;

        this.partyContactMechanism = this.allors.context.create('PartyContactMechanism') as PartyContactMechanism;
        this.partyContactMechanism.UseAsDefault = true;
        this.partyContactMechanism.ContactMechanism = this.contactMechanism;

        this.party.AddPartyContactMechanism(this.partyContactMechanism);
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {

    this.allors.context.save()
      .subscribe(() => {
        const data: IObject = {
          id: this.contactMechanism.id,
          objectType: this.contactMechanism.objectType,
        };

        this.dialogRef.close(data);
      },
        this.saveService.errorHandler
      );
  }
}
