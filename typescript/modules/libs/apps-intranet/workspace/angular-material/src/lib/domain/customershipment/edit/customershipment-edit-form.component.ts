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
  CustomerShipment,
  InternalOrganisation,
} from '@allors/default/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  ErrorService,
  AllorsFormComponent,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { Filters } from '../../../../filters/filters';
import { FetcherService } from '../../../../services/fetcher/fetcher-service';
import { InternalOrganisationId } from '../../../../services/state/internal-organisation-id';

@Component({
  selector: 'customershipment-edit-form',
  templateUrl: './customershipment-edit-form.component.html',
  providers: [OldPanelService, ContextService],
})
export class CustomerShipmentEditFormComponent
  extends AllorsFormComponent<CustomerShipment>
  implements CreateOrEditPullHandler, EditIncludeHandler, PostCreatePullHandler
{
  readonly m: M;

  customerShipment: CustomerShipment;

  currencies: Currency[];
  shipToAddresses: PostalAddress[] = [];
  shipToContacts: Person[] = [];
  shipFromAddresses: PostalAddress[] = [];
  shipFromContacts: Person[] = [];
  internalOrganisation: InternalOrganisation;
  facilities: Facility[];
  shipmentMethods: ShipmentMethod[];
  carriers: Carrier[];

  addShipFromAddress = false;

  addShipToAddress = false;
  addShipToContactPerson = false;

  private previousShipToparty: Party;

  private subscription: Subscription;
  private refresh$: BehaviorSubject<Date>;

  customersFilter: SearchFactory;

  get shipToCustomerIsPerson(): boolean {
    return (
      !this.customerShipment.ShipToParty ||
      this.customerShipment.ShipToParty.strategy.cls === this.m.Person
    );
  }

  constructor(
    @Self() public allors: ContextService,
    errorService: ErrorService,
    form: NgForm,
    private fetcher: FetcherService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super(allors, errorService, form);
    this.m = allors.metaPopulation as M;

    panel.onPull = (pulls) => {
      this.customerShipment = undefined;

      if (this.panel.isCollapsed) {
        const m = this.m;
        const { pullBuilder: pull } = m;
        const id = this.panel.manager.id;

        pulls.push(
          this.fetcher.internalOrganisation,
          pull.CustomerShipment({
            name: pullName,
            objectId: id,
          })
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.customerShipment = loaded.object<CustomerShipment>(pullName);
        this.internalOrganisation =
          this.fetcher.getInternalOrganisation(loaded);
      }
    };
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    // Maximized
    this.subscription = combineLatest([this.refresh$, this.panel.manager.on$])
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {
          this.customerShipment = undefined;

          const id = this.panel.manager.id;

          const pulls = [
            this.fetcher.ownWarehouses,
            pull.ShipmentMethod({
              sorting: [{ roleType: m.ShipmentMethod.Name }],
            }),
            pull.Carrier({ sorting: [{ roleType: m.Carrier.Name }] }),
            pull.Organisation({
              predicate: {
                kind: 'Equals',
                propertyType: m.Organisation.IsInternalOrganisation,
                value: true,
              },
              sorting: [{ roleType: m.Organisation.DisplayName }],
            }),
            pull.CustomerShipment({
              objectId: id,
              include: {
                ShipFromParty: x,
                ShipFromAddress: x,
                ShipFromFacility: x,
                ShipToParty: x,
                ShipToAddress: x,
                ShipToContactPerson: x,
                Carrier: x,
                ShipmentState: x,
                ElectronicDocuments: x,
              },
            }),
          ];

          this.customersFilter = Filters.customersFilter(
            m,
            this.internalOrganisationId.value
          );

          return this.allors.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        this.customerShipment = loaded.object<CustomerShipment>(
          m.CustomerShipment
        );
        this.facilities = this.fetcher.getOwnWarehouses(loaded);
        this.shipmentMethods = loaded.collection<ShipmentMethod>(
          m.ShipmentMethod
        );
        this.carriers = loaded.collection<Carrier>(m.Carrier);

        if (this.customerShipment.ShipToParty) {
          this.updateShipToParty(this.customerShipment.ShipToParty);
        }

        if (this.customerShipment.ShipFromParty) {
          this.updateShipFromParty(this.customerShipment.ShipFromParty);
        }

        this.previousShipToparty = this.customerShipment.ShipToParty;
      });
  }

  public shipToContactPersonAdded(person: Person): void {
    const organisationContactRelationship =
      this.allors.context.create<OrganisationContactRelationship>(
        this.m.OrganisationContactRelationship
      );
    organisationContactRelationship.Organisation = this.customerShipment
      .ShipToParty as Organisation;
    organisationContactRelationship.Contact = person;

    this.shipToContacts.push(person);
    this.customerShipment.ShipToContactPerson = person;
  }

  public shipToAddressAdded(
    partyContactMechanism: PartyContactMechanism
  ): void {
    this.customerShipment.ShipToParty.addPartyContactMechanism(
      partyContactMechanism
    );

    const postalAddress =
      partyContactMechanism.ContactMechanism as PostalAddress;
    this.shipToAddresses.push(postalAddress);
    this.customerShipment.ShipToAddress = postalAddress;
  }

  public shipFromAddressAdded(
    partyContactMechanism: PartyContactMechanism
  ): void {
    this.shipFromAddresses.push(
      partyContactMechanism.ContactMechanism as PostalAddress
    );
    this.customerShipment.ShipFromParty.addPartyContactMechanism(
      partyContactMechanism
    );
    this.customerShipment.ShipFromAddress =
      partyContactMechanism.ContactMechanism as PostalAddress;
  }

  public customerSelected(customer: IObject) {
    this.updateShipToParty(customer as Party);
  }

  private updateShipToParty(customer: Party): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Party({
        object: customer,
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
        object: customer,
        select: {
          CurrentContacts: x,
        },
      }),
    ];

    this.allors.context.pull(pulls).subscribe((loaded) => {
      if (this.customerShipment.ShipToParty !== this.previousShipToparty) {
        this.customerShipment.ShipToAddress = null;
        this.customerShipment.ShipToContactPerson = null;
        this.previousShipToparty = this.customerShipment.ShipToParty;
      }

      const partyContactMechanisms: PartyContactMechanism[] =
        loaded.collection<PartyContactMechanism>(
          m.Party.CurrentPartyContactMechanisms
        );
      this.shipToAddresses = partyContactMechanisms
        ?.filter(
          (v: PartyContactMechanism) =>
            v.ContactMechanism.strategy.cls === m.PostalAddress
        )
        ?.map(
          (v: PartyContactMechanism) => v.ContactMechanism
        ) as PostalAddress[];
      this.shipToContacts = loaded.collection<Person>(m.Party.CurrentContacts);
    });
  }

  private updateShipFromParty(organisation: Party): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Party({
        object: organisation,
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
        object: organisation,
        select: {
          CurrentContacts: x,
        },
      }),
    ];

    this.allors.context.pull(pulls).subscribe((loaded) => {
      const partyContactMechanisms: PartyContactMechanism[] =
        loaded.collection<PartyContactMechanism>(
          m.Party.CurrentPartyContactMechanisms
        );
      this.shipFromAddresses = partyContactMechanisms
        ?.filter(
          (v: PartyContactMechanism) =>
            v.ContactMechanism.strategy.cls === m.PostalAddress
        )
        ?.map(
          (v: PartyContactMechanism) => v.ContactMechanism
        ) as PostalAddress[];
      this.shipToContacts = loaded.collection<Person>(m.Party.CurrentContacts);
    });
  }
}