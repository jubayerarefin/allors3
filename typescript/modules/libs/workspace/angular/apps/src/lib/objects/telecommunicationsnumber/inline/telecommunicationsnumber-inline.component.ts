import { Component, Output, EventEmitter, OnInit, OnDestroy } from '@angular/core';

import { SessionService, MetaService } from '@allors/angular/services/core';
import { PartyContactMechanism, ContactMechanismPurpose, Enumeration, ContactMechanismType, TelecommunicationsNumber } from '@allors/domain/generated';
import { Meta } from '@allors/meta/generated';
import { Equals, Sort } from '@allors/data/system';
import { PullRequest } from '@allors/protocol/system';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'party-contactmechanism-telecommunicationsnumber',
  templateUrl: './telecommunicationsnumber-inline.component.html',
})
export class PartyContactMechanismTelecommunicationsNumberInlineComponent implements OnInit, OnDestroy {

  @Output()
  public saved: EventEmitter<PartyContactMechanism> = new EventEmitter<PartyContactMechanism>();

  @Output()
  public cancelled: EventEmitter<any> = new EventEmitter();

  public contactMechanismPurposes: Enumeration[];
  public contactMechanismTypes: ContactMechanismType[];

  public partyContactMechanism: PartyContactMechanism;
  public telecommunicationsNumber: TelecommunicationsNumber;

  public m: M;

  constructor(
    private allors: SessionService,
    public ) {

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {

    const { pull } = this.metaService;

    const pulls = [
      pull.ContactMechanismPurpose({
        predicate: { kind: 'Equals', propertyType: this.m.ContactMechanismPurpose.IsActive, value: true },
        sorting: [{ roleType: this.m.ContactMechanismPurpose.Name }],
      }),
      pull.ContactMechanismType({
        predicate: { kind: 'Equals', propertyType: this.m.ContactMechanismType.IsActive, value: true },
        sorting: [{ roleType: this.m.ContactMechanismType.Name }],
      })
    ];

    this.allors.context
      .load(new PullRequest({ pulls }))
      .subscribe((loaded) => {
        this.contactMechanismPurposes = loaded.collection<ContactMechanismPurpose>(m.ContactMechanismPurpose);
        this.contactMechanismTypes = loaded.collection<ContactMechanismType>(m.ContactMechanismType);

        this.partyContactMechanism = this.allors.session.create<PartyContactMechanism>(m.PartyContactMechanism);
        this.telecommunicationsNumber = this.allors.session.create<TelecommunicationsNumber>(m.TelecommunicationsNumber);
        this.partyContactMechanism.ContactMechanism = this.telecommunicationsNumber;
      });
  }

  public ngOnDestroy(): void {

    if (!!this.partyContactMechanism) {
      this.allors.client.invokeReactive(this.allors.session, this.partyContactMechanism.Delete);
      this.allors.client.invokeReactive(this.allors.session, this.telecommunicationsNumber.Delete);
    }
  }

  public cancel(): void {
    this.cancelled.emit();
  }

  public save(): void {
    this.saved.emit(this.partyContactMechanism);

    this.partyContactMechanism = undefined;
    this.telecommunicationsNumber = undefined;
  }
}
