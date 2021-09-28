import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Person, Organisation, OrganisationContactRelationship, Party, InternalOrganisation, ContactMechanism, PartyContactMechanism, Currency, RequestForQuote } from '@allors/workspace/domain/default';
import { ObjectData, RefreshService, SaveService, SearchFactory, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { FetcherService } from '../../../services/fetcher/fetcher-service';

@Component({
  templateUrl: './requestforquote-create.component.html',
  providers: [SessionService],
})
export class RequestForQuoteCreateComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  title = 'Add Request for Quote';

  request: RequestForQuote;
  currencies: Currency[];
  contactMechanisms: ContactMechanism[] = [];
  contacts: Person[] = [];
  internalOrganisation: Organisation;
  scope: SessionService;

  addContactPerson = false;
  addContactMechanism = false;
  addOriginator = false;

  private previousOriginator: Party;
  private subscription: Subscription;

  customersFilter: SearchFactory;

  constructor(
    @Self() public allors: SessionService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<RequestForQuoteCreateComponent>,

    private refreshService: RefreshService,
    private saveService: SaveService,
    private fetcher: FetcherService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;

    this.subscription = combineLatest([this.refreshService.refresh$, this.internalOrganisationId.observable$])
      .pipe(
        switchMap(([, internalOrganisationId]) => {
          const pulls = [this.fetcher.internalOrganisation, pull.Currency({ sorting: [{ roleType: m.Currency.Name }] })];

          this.customersFilter = Filters.customersFilter(m, internalOrganisationId);

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        this.internalOrganisation = loaded.object<InternalOrganisation>(m.InternalOrganisation);
        this.currencies = loaded.collection<Currency>(m.Currency);

        this.request = this.allors.session.create<RequestForQuote>(m.RequestForQuote);
        this.request.Recipient = this.internalOrganisation;
        this.request.RequestDate = new Date();
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.allors.context.save().subscribe(() => {
      const data: IObject = {
        id: this.request.id,
        objectType: this.request.objectType,
      };

      this.dialogRef.close(data);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  get originatorIsPerson(): boolean {
    return !this.request.Originator || this.request.Originator.objectType.name === this.m.Person.name;
  }

  public originatorSelected(party: IObject) {
    if (party) {
      this.updateOriginator(party as Party);
    }
  }

  public originatorAdded(party: Party): void {
    const customerRelationship = this.allors.session.create<CustomerRelationship>(m.CustomerRelationship);
    customerRelationship.Customer = party;
    customerRelationship.InternalOrganisation = this.internalOrganisation;

    this.request.Originator = party;
  }

  public partyContactMechanismAdded(partyContactMechanism: PartyContactMechanism): void {
    this.contactMechanisms.push(partyContactMechanism.ContactMechanism);
    this.request.Originator.addPartyContactMechanism(partyContactMechanism);
    this.request.FullfillContactMechanism = partyContactMechanism.ContactMechanism;
  }

  public personAdded(person: Person): void {
    const organisationContactRelationship = this.allors.session.create<OrganisationContactRelationship>(m.OrganisationContactRelationship);
    organisationContactRelationship.Organisation = this.request.Originator as Organisation;
    organisationContactRelationship.Contact = person;

    this.contacts.push(person);
    this.request.ContactPerson = person;
  }

  private updateOriginator(party: Party) {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Party({
        objectId: party.id,
        select: {
          CurrentPartyContactMechanisms: {
            include: {
              ContactMechanism: {
                PostalAddress_Country: x,
              },
            },
          },
        },
      }),
      pull.Party({
        objectId: party.id,
        select: {
          CurrentContacts: x,
        },
      }),
    ];

    this.allors.context.load(new PullRequest({ pulls })).subscribe((loaded) => {
      if (this.request.Originator !== this.previousOriginator) {
        this.request.FullfillContactMechanism = null;
        this.request.ContactPerson = null;
        this.previousOriginator = this.request.Originator;
      }

      const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
      this.contactMechanisms = partyContactMechanisms.map((v: PartyContactMechanism) => v.ContactMechanism);
      this.contacts = loaded.collection<Person>(m.Person);
    });
  }
}
