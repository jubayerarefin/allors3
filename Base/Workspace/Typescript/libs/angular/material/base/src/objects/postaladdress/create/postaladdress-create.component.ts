import { Component, OnDestroy, OnInit, Self, Optional, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription, combineLatest, BehaviorSubject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { isBefore, isAfter } from 'date-fns';

import { ContextService, TestScope, MetaService, RefreshService, SingletonId, Saved, NavigationService } from '@allors/angular/core';
import { PullRequest } from '@allors/protocol/system';
import { ObjectData, SaveService, AllorsMaterialDialogService } from '@allors/angular/material/core';
import {
  Organisation,
  Facility,
  ProductType,
  ProductIdentificationType,
  Settings,
  Part,
  SupplierRelationship,
  InventoryItemKind,
  SupplierOffering,
  Brand,
  Model,
  PartNumber,
  UnitOfMeasure,
  PartCategory,
  NonUnifiedPart,
  CustomOrganisationClassification,
  IndustryClassification,
  CustomerRelationship,
  InternalOrganisation,
  OrganisationRole,
  LegalForm,
  VatRegime,
  IrpfRegime,
  Currency,
  Person,
  OrganisationContactRelationship,
  Enumeration,
  OrganisationContactKind,
  PersonRole,
  Employment,
  PostalAddress,
  Country,
  Party,
  PartyContactMechanism,
} from '@allors/domain/generated';
import { Equals, Sort, And, Not, Exists } from '@allors/data/system';
import { FetcherService, InternalOrganisationId, FiltersService } from '@allors/angular/base';
import { IObject } from '@allors/domain/system';
import { Meta } from '@allors/meta/generated';

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
            .load(new PullRequest({ pulls }));
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
        this.refreshService.refresh();
      },
        this.saveService.errorHandler
      );
  }
}