import { Component, OnDestroy, OnInit, Self, Inject, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { SessionService, MetaService, RefreshService } from '@allors/angular/services/core';
import { PullRequest } from '@allors/protocol/system';
import { SaveService, ObjectData } from '@allors/angular/material/services/core';
import {
  Organisation,
  Person,
  OrganisationContactRelationship,
  Party,
  PartyContactMechanism,
  Currency,
  PurchaseReturn,
  PostalAddress,
  Facility,
} from '@allors/domain/generated';
import { Sort, Equals } from '@allors/data/system';
import { FetcherService, InternalOrganisationId, Filters } from '@allors/angular/base';
import { IObject, ISessionObject } from '@allors/domain/system';
import { Meta } from '@allors/meta/generated';
import { TestScope, SearchFactory } from '@allors/angular/core';

@Component({
  templateUrl: './purchasereturn-create.component.html',
  providers: [SessionService]
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
    private internalOrganisationId: InternalOrganisationId) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {

    const { m, pull } = this.metaService;

    this.subscription = combineLatest(this.refreshService.refresh$, this.internalOrganisationId.observable$)
      .pipe(
        switchMap(() => {

          const pulls = [
            this.fetcher.internalOrganisation,
            this.fetcher.ownWarehouses,
            pull.Organisation({
              predicate: { kind: 'Equals', propertyType: m.Organisation.IsInternalOrganisation, value: true },
              sorting: [{ roleType: m.Organisation.PartyName }],
            })
          ];

          this.suppliersFilter = Filters.suppliersFilter(m, this.internalOrganisationId.value);

          return this.allors.context
            .load(new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {

        this.internalOrganisation = loaded.object<InternalOrganisation>(m.InternalOrganisation);
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

    this.allors.context
      .save()
      .subscribe(() => {
        const data: IObject = {
          id: this.purchaseReturn.id,
          objectType: this.purchaseReturn.objectType,
        };

        this.dialogRef.close(data);
        this.refreshService.refresh();
      },
        this.saveService.errorHandler
      );
  }

  public shipToContactPersonAdded(person: Person): void {

    const organisationContactRelationship = this.allors.session.create<OrganisationContactRelationship>(m.OrganisationContactRelationship);
    organisationContactRelationship.Organisation = this.purchaseReturn.ShipToParty as Organisation;
    organisationContactRelationship.Contact = person;

    this.shipToContacts.push(person);
    this.purchaseReturn.ShipToContactPerson = person;
  }

  public shipToAddressAdded(partyContactMechanism: PartyContactMechanism): void {

    this.purchaseReturn.ShipToParty.AddPartyContactMechanism(partyContactMechanism);

    const postalAddress = partyContactMechanism.ContactMechanism as PostalAddress;
    this.shipToAddresses.push(postalAddress);
    this.purchaseReturn.ShipToAddress = postalAddress;
  }

  public supplierSelected(supplier: ISessionObject) {
    this.updateShipToParty(supplier as Party);
  }

  private updateShipToParty(supplier: Party): void {

    const m = this.m; const { pullBuilder: pull } = m; const x = {};

    const pulls = [
      pull.Party(
        {
          object: supplier,
          select: {
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
        object: supplier,
        select: {
          CurrentContacts: x,
        }
      }),
    ];

    this.allors.context
      .load(new PullRequest({ pulls }))
      .subscribe((loaded) => {

        const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
        this.shipToAddresses = partyContactMechanisms.filter((v: PartyContactMechanism) => v.ContactMechanism.objectType.name === 'PostalAddress').map((v: PartyContactMechanism) => v.ContactMechanism) as PostalAddress[];
        this.shipToContacts = loaded.collection<Person>(m.Person);
      });
  }

  private updateShipFromParty(organisation: Party): void {

    const m = this.m; const { pullBuilder: pull } = m; const x = {};

    const pulls = [
      pull.Party(
        {
          object: organisation,
          select: {
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
        object: organisation,
        select: {
          CurrentContacts: x,
        }
      }),
    ];

    this.allors.context
      .load(new PullRequest({ pulls }))
      .subscribe((loaded) => {

        const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
        this.shipFromAddresses = partyContactMechanisms.filter((v: PartyContactMechanism) => v.ContactMechanism.objectType.name === 'PostalAddress').map((v: PartyContactMechanism) => v.ContactMechanism) as PostalAddress[];
        this.shipToContacts = loaded.collection<Person>(m.Person);
      });
  }
}
