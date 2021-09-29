import { Component, OnDestroy, OnInit, Self, Inject, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Person, Organisation, OrganisationContactRelationship, Party, Facility, InternalOrganisation, PartyContactMechanism, PostalAddress, Currency, PurchaseReturn } from '@allors/workspace/domain/default';
import { ObjectData, RefreshService, SaveService, SearchFactory, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { FetcherService } from '../../../services/fetcher/fetcher-service';
import { Filters } from '../../../filters/filters';

@Component({
  templateUrl: './purchasereturn-create.component.html',
  providers: [SessionService],
})
export class PurchaseReturnCreateComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  title = 'Add Purchase Return';

  purchaseReturn: PurchaseReturn;
  currencies: Currency[];
  shipToAddresses: PostalAddress[] = [];
  shipToContacts: Person[] = [];
  shipFromAddresses: PostalAddress[] = [];
  shipFromContacts: Person[] = [];
  internalOrganisation: Organisation;

  addShipToAddress = false;
  addShipToContactPerson = false;

  private subscription: Subscription;
  facilities: Facility[];

  suppliersFilter: SearchFactory;

  constructor(
    @Self() public allors: SessionService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<PurchaseReturnCreateComponent>,
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

    this.subscription = combineLatest(this.refreshService.refresh$, this.internalOrganisationId.observable$)
      .pipe(
        switchMap(() => {
          const pulls = [
            this.fetcher.internalOrganisation,
            this.fetcher.ownWarehouses,
            pull.Organisation({
              predicate: { kind: 'Equals', propertyType: m.Organisation.IsInternalOrganisation, value: true },
              sorting: [{ roleType: m.Organisation.PartyName }],
            }),
          ];

          this.suppliersFilter = Filters.suppliersFilter(m, this.internalOrganisationId.value);

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.internalOrganisation = loaded.object<Organisation>(m.InternalOrganisation);
        this.facilities = loaded.collection<Facility>(m.Facility);

        this.purchaseReturn = this.allors.session.create<PurchaseReturn>(m.PurchaseReturn);
        this.purchaseReturn.ShipFromParty = this.internalOrganisation;

        if (this.facilities.length > 0) {
          this.purchaseReturn.ShipFromFacility = this.facilities[0];
        }

        if (this.purchaseReturn.ShipToParty) {
          this.updateShipToParty(this.purchaseReturn.ShipToParty);
        }

        if (this.purchaseReturn.ShipFromParty) {
          this.updateShipFromParty(this.purchaseReturn.ShipFromParty);
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      this.dialogRef.close(this.purchaseReturn);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  public shipToContactPersonAdded(person: Person): void {
    const organisationContactRelationship = this.allors.session.create<OrganisationContactRelationship>(m.OrganisationContactRelationship);
    organisationContactRelationship.Organisation = this.purchaseReturn.ShipToParty as Organisation;
    organisationContactRelationship.Contact = person;

    this.shipToContacts.push(person);
    this.purchaseReturn.ShipToContactPerson = person;
  }

  public shipToAddressAdded(partyContactMechanism: PartyContactMechanism): void {
    this.purchaseReturn.ShipToParty.addPartyContactMechanism(partyContactMechanism);

    const postalAddress = partyContactMechanism.ContactMechanism as PostalAddress;
    this.shipToAddresses.push(postalAddress);
    this.purchaseReturn.ShipToAddress = postalAddress;
  }

  public supplierSelected(supplier: IObject) {
    this.updateShipToParty(supplier as Party);
  }

  private updateShipToParty(supplier: Party): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Party({
        object: supplier,
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
        object: supplier,
        select: {
          CurrentContacts: x,
        },
      }),
    ];

    this.allors.client.pullReactive(this.allors.session, pulls).subscribe((loaded) => {
      const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
      this.shipToAddresses = partyContactMechanisms.filter((v: PartyContactMechanism) => v.ContactMechanism.strategy.cls === m.PostalAddress).map((v: PartyContactMechanism) => v.ContactMechanism) as PostalAddress[];
      this.shipToContacts = loaded.collection<Person>(m.Person);
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

    this.allors.client.pullReactive(this.allors.session, pulls).subscribe((loaded) => {
      const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
      this.shipFromAddresses = partyContactMechanisms.filter((v: PartyContactMechanism) => v.ContactMechanism.strategy.cls === m.PostalAddress).map((v: PartyContactMechanism) => v.ContactMechanism) as PostalAddress[];
      this.shipToContacts = loaded.collection<Person>(m.Person);
    });
  }
}
