import { Component, OnDestroy, OnInit, Self } from '@angular/core';

import { Subscription } from 'rxjs';

import { Saved, ContextService, MetaService, PanelService, RefreshService, FetcherService, TestScope } from '../../../../../../angular';
import { Organisation, ProductQuote, Currency, ContactMechanism, Person, PartyContactMechanism, OrganisationContactRelationship, SalesOrder, Party, RequestForQuote, CustomerRelationship } from '../../../../../../domain';
import { PullRequest, Sort } from '../../../../../../framework';
import { Meta } from '../../../../../../meta';
import { switchMap, filter } from 'rxjs/operators';
import { SaveService, FiltersService } from '../../../../../../material';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'productquote-overview-detail',
  templateUrl: './productquote-overview-detail.component.html',
  providers: [ContextService, PanelService]
})
export class ProductQuoteOverviewDetailComponent extends TestScope implements OnInit, OnDestroy {

  readonly m: Meta;

  productQuote: ProductQuote;
  salesOrder: SalesOrder;
  request: RequestForQuote;
  currencies: Currency[];
  contactMechanisms: ContactMechanism[];
  contacts: Person[];
  internalOrganisation: Organisation;

  addContactPerson = false;
  addContactMechanism = false;
  addReceiver = false;

  private previousReceiver: Party;
  private subscription: Subscription;

  get receiverIsPerson(): boolean {
    return !this.productQuote.Receiver || this.productQuote.Receiver.objectType.name === this.m.Person.name;
  }

  constructor(
    @Self() public allors: ContextService,
    @Self() public panel: PanelService,
    public filtersService: FiltersService,
    public metaService: MetaService,
    public refreshService: RefreshService,
    private saveService: SaveService,
    private fetcher: FetcherService
  ) {
    super();

    this.m = this.metaService.m;

    panel.name = 'detail';
    panel.title = 'ProductQuote Details';
    panel.icon = 'business';
    panel.expandable = true;

    // Collapsed
    const productQuotePullName = `${panel.name}_${this.m.ProductQuote.name}`;
    const salesOrderPullName = `${panel.name}_${this.m.SalesOrder.name}`;

    panel.onPull = (pulls) => {
      if (this.panel.isCollapsed) {
        const { pull, x } = this.metaService;

        pulls.push(
          pull.ProductQuote(
            {
              name: productQuotePullName,
              object: this.panel.manager.id,
              include: {
                QuoteItems: {
                  Product: x,
                  QuoteItemState: x,
                },
                Receiver: x,
                ContactPerson: x,
                QuoteState: x,
                CreatedBy: x,
                LastModifiedBy: x,
                Request: x,
                FullfillContactMechanism: {
                  PostalAddress_Country: x
                }
              }
            }),
          pull.ProductQuote(
            {
              name: salesOrderPullName,
              object: this.panel.manager.id,
              fetch: {
                SalesOrderWhereQuote: x,
              }
            }
          )
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.productQuote = loaded.objects.ProductQuote as ProductQuote;
        this.salesOrder = loaded.objects.SalesOrder as SalesOrder;
      }
    };
  }

  public ngOnInit(): void {

    // Expanded
    this.subscription = this.panel.manager.on$
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {

          this.productQuote = undefined;

          const { m, pull, x } = this.metaService;
          const id = this.panel.manager.id;

          const pulls = [
            this.fetcher.internalOrganisation,
            pull.Currency({ sort: new Sort(m.Currency.Name) }),
            pull.ProductQuote({
              object: id,
              include: {
                Currency: x,
                Receiver: x,
                FullfillContactMechanism: x,
                QuoteState: x,
                Request: x,
              }
            })
          ];

          return this.allors.context
            .load('Pull', new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        this.internalOrganisation = loaded.objects.InternalOrganisation as Organisation;
        this.productQuote = loaded.objects.ProductQuote as ProductQuote;
        this.currencies = loaded.collections.Currencies as Currency[];

        if (this.productQuote.Receiver) {
          this.previousReceiver = this.productQuote.Receiver;
          this.update(this.productQuote.Receiver);
        }

      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {

    this.allors.context
      .save()
      .subscribe(() => {
        this.panel.toggle();
      },
        this.saveService.errorHandler
      );
  }

  public personAdded(person: Person): void {

    const organisationContactRelationship = this.allors.context.create('OrganisationContactRelationship') as OrganisationContactRelationship;
    organisationContactRelationship.Organisation = this.productQuote.Receiver as Organisation;
    organisationContactRelationship.Contact = person;

    this.contacts.push(person);
    this.productQuote.ContactPerson = person;
  }

  public partyContactMechanismAdded(partyContactMechanism: PartyContactMechanism): void {

    this.contactMechanisms.push(partyContactMechanism.ContactMechanism);
    this.productQuote.Receiver.AddPartyContactMechanism(partyContactMechanism);
    this.productQuote.FullfillContactMechanism = partyContactMechanism.ContactMechanism;
  }

  public receiverSelected(party: Party): void {
    if (party) {
      this.update(party);
    }
  }

  public receiverAdded(party: Party): void {

    const customerRelationship = this.allors.context.create('CustomerRelationship') as CustomerRelationship;
    customerRelationship.Customer = party;
    customerRelationship.InternalOrganisation = this.internalOrganisation;

    this.request.Originator = party;
  }

  private update(party: Party) {

    const { pull, x } = this.metaService;

    const pulls = [
      pull.Party(
        {
          object: party,
          fetch: {
            CurrentPartyContactMechanisms: {
              include: {
                ContactMechanism: {
                  PostalAddress_Country: x
                }
              }
            }
          }
        }
      ),
      pull.Party({
        object: party,
        fetch: {
          CurrentContacts: x
        }
      })
    ];

    this.allors.context
      .load('Pull', new PullRequest({ pulls }))
      .subscribe((loaded) => {

        if (this.productQuote.Receiver !== this.previousReceiver) {
          this.productQuote.ContactPerson = null;
          this.productQuote.FullfillContactMechanism = null;
          this.previousReceiver = this.productQuote.Receiver;
        }

        const partyContactMechanisms: PartyContactMechanism[] = loaded.collections.CurrentPartyContactMechanisms as PartyContactMechanism[];
        this.contactMechanisms = partyContactMechanisms.map((v: PartyContactMechanism) => v.ContactMechanism);
        this.contacts = loaded.collections.CurrentContacts as Person[];

        this.productQuote.Currency = this.productQuote.Receiver.PreferredCurrency;
      });
  }
}
