import { Component, OnInit, Self, OnDestroy } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { switchMap, filter } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Locale, Organisation, Part, Facility, InternalOrganisation, SerialisedInventoryItem, SerialisedItem, Enumeration } from '@allors/workspace/domain/default';
import { NavigationService, PanelService, RefreshService, SaveService, SearchFactory, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';

import { FetcherService } from '../../../../services/fetcher/fetcher-service';
import { InternalOrganisationId } from '../../../../services/state/internal-organisation-id';
import { Filters } from '../../../../filters/filters';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'serialiseditem-overview-detail',
  templateUrl: './serialiseditem-overview-detail.component.html',
  providers: [PanelService, SessionService],
})
export class SerialisedItemOverviewDetailComponent extends TestScope implements OnInit, OnDestroy {
  readonly m: M;

  serialisedItem: SerialisedItem;

  internalOrganisation: InternalOrganisation;
  locales: Locale[];
  serialisedItemStates: Enumeration[];
  ownerships: Enumeration[];
  part: Part;
  currentSuppliers: Organisation[];
  currentFacility: Facility;

  private subscription: Subscription;
  serialisedItemAvailabilities: Enumeration[];
  internalOrganisationsFilter: SearchFactory;
  partiesFilter: SearchFactory;

  constructor(
    @Self() public allors: SessionService,
    @Self() public panel: PanelService,

    public refreshService: RefreshService,
    public navigationService: NavigationService,
    private saveService: SaveService,
    private snackBar: MatSnackBar,
    private fetcher: FetcherService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    panel.name = 'detail';
    panel.title = 'Serialised Asset data';
    panel.icon = 'business';
    panel.expandable = true;

    // Minimized
    const pullName = `${this.panel.name}_${this.m.SerialisedItem.tag}`;

    panel.onPull = (pulls) => {
      this.serialisedItem = undefined;

      if (this.panel.isCollapsed) {
        const { pullBuilder: pull } = this.m;
        const id = this.panel.manager.id;

        pulls.push(
          pull.SerialisedItem({
            name: pullName,
            objectId: id,
          })
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.serialisedItem = loaded.object<SerialisedItem>(pullName);
      }
    };
  }

  public ngOnInit(): void {
    const m = this.m;

    // Maximized
    this.subscription = this.panel.manager.on$
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {
          this.serialisedItem = undefined;

          const m = this.allors.workspace.configuration.metaPopulation as M;
          const { pullBuilder: pull } = m;
          const x = {};
          const id = this.panel.manager.id;

          const pulls = [
            pull.SerialisedItem({
              objectId: id,
              include: {
                SerialisedItemState: x,
                SerialisedItemCharacteristics: {
                  SerialisedItemCharacteristicType: {
                    UnitOfMeasure: x,
                  },
                },
                LocalisedNames: {
                  Locale: x,
                },
                LocalisedDescriptions: {
                  Locale: x,
                },
                LocalisedComments: {
                  Locale: x,
                },
                LocalisedKeywords: {
                  Locale: x,
                },
                Ownership: x,
                Buyer: x,
                Seller: x,
                OwnedBy: x,
                RentedBy: x,
                PrimaryPhoto: x,
                SecondaryPhotos: x,
                AdditionalPhotos: x,
                PrivatePhotos: x,
                PublicElectronicDocuments: x,
                PrivateElectronicDocuments: x,
                PublicLocalisedElectronicDocuments: x,
                PrivateLocalisedElectronicDocuments: x,
                PurchaseInvoice: x,
                PurchaseOrder: x,
                SuppliedBy: x,
                AssignedSuppliedBy: x,
              },
            }),
            this.fetcher.internalOrganisation,
            this.fetcher.locales,
            pull.SerialisedItem({
              objectId: id,
              select: {
                PartWhereSerialisedItem: x,
              },
            }),
            pull.SerialisedItem({
              objectId: id,
              select: {
                SerialisedInventoryItemsWhereSerialisedItem: {
                  include: {
                    Facility: x,
                  },
                },
              },
            }),
            pull.InternalOrganisation({
              objectId: this.internalOrganisationId.value,
              select: {
                ObsoleteCurrentSuppliers: x,
              },
            }),
            pull.SerialisedItemState({
              predicate: { kind: 'Equals', propertyType: m.SerialisedItemState.IsActive, value: true },
              sorting: [{ roleType: m.SerialisedItemState.Name }],
            }),
            pull.SerialisedItemAvailability({
              predicate: { kind: 'Equals', propertyType: m.SerialisedItemAvailability.IsActive, value: true },
              sorting: [{ roleType: m.SerialisedItemAvailability.Name }],
            }),
            pull.Ownership({
              predicate: { kind: 'Equals', propertyType: m.Ownership.IsActive, value: true },
              sorting: [{ roleType: m.Ownership.Name }],
            }),
          ];

          this.internalOrganisationsFilter = Filters.internalOrganisationsFilter(m);
          this.partiesFilter = Filters.partiesFilter(m);

          return this.allors.client.pullReactive(this.allors.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.session.reset();

        this.currentSuppliers = loaded.collection<Organisation>(m.Organisation);

        this.serialisedItem = loaded.object<SerialisedItem>(m.SerialisedItem);
        this.locales = loaded.collection<Locale>(m.Locale);
        this.serialisedItemStates = loaded.collection<Enumeration>(m.Enumeration);
        this.serialisedItemAvailabilities = loaded.collection<Enumeration>(m.Enumeration);
        this.ownerships = loaded.collection<Enumeration>(m.Enumeration);
        this.part = loaded.object<Part>(m.Part);

        const serialisedInventoryItems = loaded.collection<SerialisedInventoryItem>(m.SerialisedInventoryItem);
        const inventoryItem = serialisedInventoryItems.find((v) => v.Quantity === 1);
        if (inventoryItem) {
          this.currentFacility = inventoryItem.Facility;
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public partSelected(part: Part): void {
    if (part) {
      this.part = part;
    }
  }

  public save(): void {
    // this.onSave();

    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      this.refreshService.refresh();
      this.panel.toggle();
    }, this.saveService.errorHandler);
  }

  public update(): void {
    this.onSave();

    this.allors.client.pushReactive(this.allors.session).subscribe(() => {
      this.snackBar.open('Successfully saved.', 'close', { duration: 5000 });
      this.refreshService.refresh();
    }, this.saveService.errorHandler);
  }

  private onSave() {
    this.part.addSerialisedItem(this.serialisedItem);
  }
}
