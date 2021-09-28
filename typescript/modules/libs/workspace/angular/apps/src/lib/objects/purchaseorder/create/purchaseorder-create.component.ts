import { Component, OnDestroy, OnInit, Self, Optional, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import {
  Person,
  Organisation,
  OrganisationContactRelationship,
  Party,
  Facility,
  InternalOrganisation,
  SupplierRelationship,
  ContactMechanism,
  PartyContactMechanism,
  PostalAddress,
  Currency,
  PurchaseOrder,
  VatRegime,
  IrpfRegime,
} from '@allors/workspace/domain/default';
import { ObjectData, RefreshService, SaveService, SearchFactory, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { FetcherService } from '../../../services/fetcher/fetcher-service';

@Component({
  templateUrl: './purchaseorder-create.component.html',
  providers: [SessionService],
})
export class PurchaseOrderCreateComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  title = 'Add Purchase Order';

  order: PurchaseOrder;
  currencies: Currency[];
  takenViaContactMechanisms: ContactMechanism[] = [];
  takenViaContacts: Person[] = [];
  billToContactMechanisms: ContactMechanism[] = [];
  billToContacts: Person[] = [];
  shipToAddresses: ContactMechanism[] = [];
  shipToContacts: Person[] = [];
  vatRegimes: VatRegime[];
  internalOrganisation: Organisation;
  facilities: Facility[];
  selectedFacility: Facility;
  addFacility = false;

  addSupplier = false;

  addTakenViaContactMechanism = false;
  addTakenViaContactPerson = false;

  addBillToContactMechanism = false;
  addBillToContactPerson = false;

  addShipToAddress = false;
  addShipToContactPerson = false;

  private takenVia: Party;

  private subscription: Subscription;

  suppliersFilter: SearchFactory;
  irpfRegimes: IrpfRegime[];
  currencyInitialRole: Currency;
  shipToAddressInitialRole: PostalAddress;
  billToContactMechanismInitialRole: ContactMechanism;
  takenViaContactMechanismInitialRole: ContactMechanism;
  showIrpf: boolean;

  constructor(
    @Self() public allors: SessionService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<PurchaseOrderCreateComponent>,

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
          const pulls = [
            this.fetcher.internalOrganisation,
            pull.IrpfRegime({}),
            pull.Currency({
              predicate: { kind: 'Equals', propertyType: m.Currency.IsActive, value: true },
              sorting: [{ roleType: m.Currency.IsoCode }],
            }),
            pull.Facility({ sorting: [{ roleType: m.Facility.Name }] }),
            pull.Organisation({
              predicate: { kind: 'Equals', propertyType: m.Organisation.IsInternalOrganisation, value: true },
              sorting: [{ roleType: m.Organisation.PartyName }],
            }),
          ];

          this.suppliersFilter = Filters.suppliersFilter(m, internalOrganisationId);

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.internalOrganisation = loaded.object<InternalOrganisation>(m.InternalOrganisation);
        this.showIrpf = this.internalOrganisation.Country.IsoCode === 'ES';
        this.vatRegimes = this.internalOrganisation.Country.DerivedVatRegimes;
        this.irpfRegimes = loaded.collection<IrpfRegime>(m.IrpfRegime);
        this.currencies = loaded.collection<Currency>(m.Currency);
        this.facilities = loaded.collection<Facility>(m.Facility);

        this.order = this.allors.session.create<PurchaseOrder>(m.PurchaseOrder);
        this.order.OrderedBy = this.internalOrganisation;

        if (this.order.TakenViaSupplier) {
          this.takenVia = this.order.TakenViaSupplier;
          this.updateSupplier(this.takenVia);
        }

        if (this.order.OrderedBy) {
          this.updateOrderedBy(this.order.OrderedBy);
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
      this.dialogRef.close(this.order);
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  public supplierAdded(supplier: Organisation): void {
    const supplierRelationship = this.allors.session.create<SupplierRelationship>(m.SupplierRelationship);
    supplierRelationship.Supplier = supplier;
    supplierRelationship.InternalOrganisation = this.internalOrganisation;

    this.order.TakenViaSupplier = supplier;
    this.takenVia = supplier;
    this.supplierSelected(supplier);
  }

  public takenViaContactPersonAdded(person: Person): void {
    const organisationContactRelationship = this.allors.session.create<OrganisationContactRelationship>(m.OrganisationContactRelationship);
    organisationContactRelationship.Organisation = this.order.TakenViaSupplier as Organisation;
    organisationContactRelationship.Contact = person;

    this.takenViaContacts.push(person);
    this.order.TakenViaContactPerson = person;
  }

  public takenViaContactMechanismAdded(partyContactMechanism: PartyContactMechanism): void {
    this.takenViaContactMechanisms.push(partyContactMechanism.ContactMechanism);
    this.takenVia.addPartyContactMechanism(partyContactMechanism);
    this.order.AssignedTakenViaContactMechanism = partyContactMechanism.ContactMechanism;
  }

  public billToContactPersonAdded(person: Person): void {
    const organisationContactRelationship = this.allors.session.create<OrganisationContactRelationship>(m.OrganisationContactRelationship);
    organisationContactRelationship.Organisation = this.order.OrderedBy as Organisation;
    organisationContactRelationship.Contact = person;

    this.billToContacts.push(person);
    this.order.BillToContactPerson = person;
  }

  public billToContactMechanismAdded(partyContactMechanism: PartyContactMechanism): void {
    this.billToContactMechanisms.push(partyContactMechanism.ContactMechanism);
    this.order.OrderedBy.addPartyContactMechanism(partyContactMechanism);
    this.order.AssignedBillToContactMechanism = partyContactMechanism.ContactMechanism;
  }

  public shipToContactPersonAdded(person: Person): void {
    const organisationContactRelationship = this.allors.session.create<OrganisationContactRelationship>(m.OrganisationContactRelationship);
    organisationContactRelationship.Organisation = this.order.OrderedBy as Organisation;
    organisationContactRelationship.Contact = person;

    this.shipToContacts.push(person);
    this.order.ShipToContactPerson = person;
  }

  public shipToAddressAdded(partyContactMechanism: PartyContactMechanism): void {
    this.shipToAddresses.push(partyContactMechanism.ContactMechanism);
    this.order.OrderedBy.addPartyContactMechanism(partyContactMechanism);
    this.order.AssignedShipToAddress = partyContactMechanism.ContactMechanism as PostalAddress;
  }

  public supplierSelected(supplier: IObject) {
    this.updateSupplier(supplier as Party);
  }

  public facilityAdded(facility: Facility): void {
    this.facilities.push(facility);
    this.selectedFacility = facility;
  }

  private updateSupplier(supplier: Party): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Organisation({
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
      pull.Organisation({
        object: supplier,
        select: {
          CurrentContacts: x,
        },
      }),
      pull.Organisation({
        object: supplier,
        name: 'selectedSupplier',
        include: {
          OrderAddress: x,
        },
      }),
    ];

    this.allors.client.pullReactive(this.allors.session, pulls).subscribe((loaded) => {
      const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
      this.takenViaContactMechanisms = partyContactMechanisms.map((v: PartyContactMechanism) => v.ContactMechanism);
      this.takenViaContacts = loaded.collection<Person>(m.Person);

      const selectedSupplier = loaded.object<selectedSupplier>(m.selectedSupplier);
      this.takenViaContactMechanismInitialRole = selectedSupplier.OrderAddress;
    });
  }

  private updateOrderedBy(organisation: Party): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Organisation({
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
      pull.Organisation({
        object: organisation,
        select: {
          CurrentContacts: x,
        },
      }),
      pull.Organisation({
        object: organisation,
        name: 'selectedOrganisation',
        include: {
          PreferredCurrency: x,
          ShippingAddress: x,
          BillingAddress: x,
          GeneralCorrespondence: x,
        },
      }),
    ];

    this.allors.client.pullReactive(this.allors.session, pulls).subscribe((loaded) => {
      const partyContactMechanisms: PartyContactMechanism[] = loaded.collection<PartyContactMechanism>(m.PartyContactMechanism);
      this.billToContactMechanisms = partyContactMechanisms.map((v: PartyContactMechanism) => v.ContactMechanism);
      this.shipToAddresses = partyContactMechanisms.filter((v: PartyContactMechanism) => v.ContactMechanism.objectType.name === 'PostalAddress').map((v: PartyContactMechanism) => v.ContactMechanism);
      this.billToContacts = loaded.collection<Person>(m.Person);
      this.shipToContacts = this.billToContacts;

      const selectedOrganisation = loaded.object<selectedOrganisation>(m.selectedOrganisation);
      this.currencyInitialRole = selectedOrganisation.PreferredCurrency;
      this.shipToAddressInitialRole = selectedOrganisation.ShippingAddress;
      this.billToContactMechanismInitialRole = selectedOrganisation.BillingAddress ?? selectedOrganisation.GeneralCorrespondence;
    });
  }
}
