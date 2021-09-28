import { Component, OnDestroy, OnInit, Self, Inject, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Person, Organisation, OrganisationContactRelationship, Party, InternalOrganisation, ContactMechanism, PartyContactMechanism, Currency, RequestForQuote, ProductQuote, VatRegime, IrpfRegime } from '@allors/workspace/domain/default';
import { ObjectData, RefreshService, SaveService, SearchFactory, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { FetcherService } from '../../../services/fetcher/fetcher-service';

@Component({
  templateUrl: './productquote-create.component.html',
  providers: [SessionService],
})
export class ProductQuoteCreateComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  title = 'Add Quote';

  quote: ProductQuote;
  request: RequestForQuote;
  currencies: Currency[];
  contactMechanisms: ContactMechanism[] = [];
  contacts: Person[] = [];
  irpfRegimes: IrpfRegime[];
  vatRegimes: VatRegime[];
  showIrpf: boolean;

  addContactPerson = false;
  addContactMechanism = false;
  addReceiver = false;
  internalOrganisation: Organisation;

  private subscription: Subscription;
  private previousReceiver: Party;

  customersFilter: SearchFactory;
  currencyInitialRole: Currency;

  constructor(
    @Self() public allors: SessionService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<ProductQuoteCreateComponent>,

    private saveService: SaveService,
    public refreshService: RefreshService,
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
          const pulls = [this.fetcher.internalOrganisation, pull.Currency({ sorting: [{ roleType: m.Currency.Name }] }), pull.IrpfRegime({ sorting: [{ roleType: m.IrpfRegime.Name }] })];

          this.customersFilter = Filters.customersFilter(m, internalOrganisationId);

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        this.quote = loaded.object<ProductQuote>(m.ProductQuote);
        this.internalOrganisation = loaded.object<Organisation>(m.InternalOrganisation);
        this.showIrpf = this.internalOrganisation.Country.IsoCode === 'ES';
        this.vatRegimes = this.internalOrganisation.Country.DerivedVatRegimes;
        this.irpfRegimes = loaded.collection<IrpfRegime>(m.IrpfRegime);
        this.currencies = loaded.collection<Currency>(m.Currency);

        this.quote = this.allors.session.create<ProductQuote>(m.ProductQuote);
        this.quote.Issuer = this.internalOrganisation;
        this.quote.IssueDate = new Date();
        this.quote.ValidFromDate = new Date();
      });
  }

  get receiverIsPerson(): boolean {
    return !this.quote.Receiver || this.quote.Receiver.objectType.name === this.m.Person.name;
  }

  public receiverSelected(party: IObject): void {
    if (party) {
      this.update(party as Party);
    }
  }

  public receiverAdded(party: Party): void {
    const customerRelationship = this.allors.session.create<CustomerRelationship>(m.CustomerRelationship);
    customerRelationship.Customer = party;
    customerRelationship.InternalOrganisation = this.internalOrganisation;

    this.quote.Receiver = party;
  }

  public personAdded(person: Person): void {
    const organisationContactRelationship = this.allors.session.create<OrganisationContactRelationship>(m.OrganisationContactRelationship);
    organisationContactRelationship.Organisation = this.quote.Receiver as Organisation;
    organisationContactRelationship.Contact = person;

    this.contacts.push(person);
    this.quote.ContactPerson = person;
  }

  public partyContactMechanismAdded(partyContactMechanism: PartyContactMechanism): void {
    this.contactMechanisms.push(partyContactMechanism.ContactMechanism);
    this.quote.Receiver.addPartyContactMechanism(partyContactMechanism);
    this.quote.FullfillContactMechanism = partyContactMechanism.ContactMechanism;
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      this.dialogRef.close(this.quote);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  private update(party: Party) {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Party({
        object: party,
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
        object: party,
        select: {
          CurrentContacts: x,
        },
      }),
      pull.Party({
        object: party,
        name: 'selectedParty',
        include: {
          PreferredCurrency: x,
          Locale: x,
        },
      }),
    ];

    this.allors.client.pullReactive(this.allors.session, pulls).subscribe((loaded) => {
      if (this.previousReceiver && this.quote.Receiver !== this.previousReceiver) {
        this.quote.ContactPerson = null;
        this.quote.FullfillContactMechanism = null;
      }

      this.previousReceiver = this.quote.Receiver;

      const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
      this.contactMechanisms = partyContactMechanisms.map((v: PartyContactMechanism) => v.ContactMechanism);
      this.contacts = loaded.collection<Person>(m.Person);

      const selectedParty = loaded.object<selectedParty>(m.selectedParty);
      this.currencyInitialRole = selectedParty.PreferredCurrency ?? this.quote.Issuer.PreferredCurrency;
    });
  }
}
