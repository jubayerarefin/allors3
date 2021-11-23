import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, scan } from 'rxjs/operators';
import { formatDistance } from 'date-fns';

import { M } from '@allors/workspace/meta/default';
import {
  Person,
  Organisation,
  Part,
  ProductIdentificationType,
  Facility,
  InventoryItemKind,
  ProductType,
  Brand,
  Model,
  PartCategory,
  NonUnifiedPart,
  NonUnifiedPartBarcodePrint,
  NonSerialisedInventoryItem,
  ProductIdentification,
  InternalOrganisation,
} from '@allors/workspace/domain/default';
import {
  Action,
  DeleteService,
  Filter,
  FilterDefinition,
  MediaService,
  NavigationService,
  ObjectService,
  RefreshService,
  SaveService,
  SearchFactory,
  Table,
  TableRow,
  UserId,
  OverviewService,
  SingletonId,
  Sorter,
  FilterField,
} from '@allors/workspace/angular/base';
import { ContextService } from '@allors/workspace/angular/core';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { PrintService } from '../../../actions/print/print.service';
import { FetcherService } from '../../../services/fetcher/fetcher-service';
import { Filters } from '../../../filters/filters';
import { And } from '@allors/workspace/domain/system';
import { Sort } from '@angular/material/sort';
import { PageEvent } from '@angular/material/paginator';

interface Row extends TableRow {
  object: Part;
  name: string;
  partNo: string;
  categories: string;
  qoh: string;
  localQoh: string;
  brand: string;
  model: string;
  kind: string;
  lastModifiedDate: string;
}

@Component({
  templateUrl: './nonunifiedpart-list.component.html',
  providers: [ContextService],
})
export class NonUnifiedPartListComponent implements OnInit, OnDestroy {
  public title = 'Parts';

  table: Table<Row>;

  edit: Action;
  delete: Action;
  print: Action;

  private subscription: Subscription;
  goodIdentificationTypes: ProductIdentificationType[];
  parts: NonUnifiedPart[];
  nonUnifiedPartBarcodePrint: NonUnifiedPartBarcodePrint;
  facilities: Facility[];
  user: Person;
  internalOrganisation: InternalOrganisation;
  filter: Filter;
  m: M;

  constructor(
    @Self() public allors: ContextService,
    public factoryService: ObjectService,
    public refreshService: RefreshService,
    public overviewService: OverviewService,
    public deleteService: DeleteService,
    public navigation: NavigationService,
    public mediaService: MediaService,
    public printService: PrintService,
    private saveService: SaveService,
    private singletonId: SingletonId,
    private fetcher: FetcherService,
    private internalOrganisationId: InternalOrganisationId,
    private userId: UserId,
    titleService: Title
  ) {
    titleService.setTitle(this.title);

    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;

    this.print = printService.print();

    this.delete = deleteService.delete(allors.context);
    this.delete.result.subscribe(() => {
      this.table.selection.clear();
    });

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'name', sort: true },
        { name: 'partNo', sort: true },
        { name: 'type' },
        { name: 'categories' },
        { name: 'qoh' },
        { name: 'localQoh' },
        { name: 'brand' },
        { name: 'model' },
        { name: 'kind' },
        { name: 'lastModifiedDate', sort: true },
      ],
      actions: [overviewService.overview(), this.delete],
      defaultAction: overviewService.overview(),
      pageSize: 50,
    });
  }

  ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const predicate: And = {
      kind: 'And',
      operands: [
        {
          kind: 'Or',
          operands: [
            { kind: 'Like', roleType: m.Part.Name, parameter: 'name' },
            { kind: 'ContainedIn', propertyType: m.Part.LocalisedNames, extent: { kind: 'Filter', objectType: m.LocalisedText, predicate: { kind: 'Like', roleType: m.LocalisedText.Text, parameter: 'name' } } },
          ],
        },
        { kind: 'Like', roleType: m.Part.Keywords, parameter: 'keyword' },
        { kind: 'Like', roleType: m.Part.HsCode, parameter: 'hsCode' },
        { kind: 'Contains', propertyType: m.Part.ProductIdentifications, parameter: 'identification' },
        { kind: 'Contains', propertyType: m.Part.SuppliedBy, parameter: 'supplier' },
        {
          kind: 'ContainedIn',
          propertyType: m.Part.SupplierOfferingsWherePart,
          extent: { kind: 'Filter', objectType: m.SupplierOffering, predicate: { kind: 'Like', roleType: m.SupplierOffering.SupplierProductId, parameter: 'supplierReference' } },
        },
        { kind: 'Equals', propertyType: m.Part.ManufacturedBy, parameter: 'manufacturer' },
        { kind: 'Equals', propertyType: m.Part.Brand, parameter: 'brand' },
        { kind: 'Equals', propertyType: m.Part.Model, parameter: 'model' },
        { kind: 'Equals', propertyType: m.Part.InventoryItemKind, parameter: 'kind' },
        { kind: 'Equals', propertyType: m.Part.ProductType, parameter: 'type' },
        { kind: 'Contains', propertyType: m.NonUnifiedPart.PartCategoriesWherePart, parameter: 'category' },
        {
          kind: 'ContainedIn',
          propertyType: m.Part.InventoryItemsWherePart,
          extent: { kind: 'Filter', objectType: m.NonSerialisedInventoryItem, predicate: { kind: 'Equals', propertyType: m.InventoryItem.Facility, parameter: 'inStock' } },
        },
        {
          kind: 'ContainedIn',
          propertyType: m.Part.InventoryItemsWherePart,
          extent: { kind: 'Filter', objectType: m.NonSerialisedInventoryItem, predicate: { kind: 'Equals', propertyType: m.InventoryItem.Facility, parameter: 'outOfStock' } },
        },
      ],
    };

    const typeSearch = new SearchFactory({
      objectType: m.ProductType,
      roleTypes: [m.ProductType.Name],
    });

    const kindSearch = new SearchFactory({
      objectType: m.InventoryItemKind,
      predicates: [{ kind: 'Equals', propertyType: m.Enumeration.IsActive, value: true }],
      roleTypes: [m.InventoryItemKind.Name],
    });

    const categorySearch = new SearchFactory({
      objectType: m.PartCategory,
      roleTypes: [m.PartCategory.Name],
    });

    const brandSearch = new SearchFactory({
      objectType: m.Brand,
      roleTypes: [m.Brand.Name],
    });

    const modelSearch = new SearchFactory({
      objectType: m.Model,
      roleTypes: [m.Model.Name],
    });

    const manufacturerSearch = new SearchFactory({
      objectType: m.Organisation,
      predicates: [{ kind: 'Equals', propertyType: m.Organisation.IsManufacturer, value: true }],
      roleTypes: [m.Organisation.PartyName],
    });

    const idSearch = new SearchFactory({
      objectType: m.ProductIdentification,
      roleTypes: [m.ProductIdentification.Identification],
    });

    const facilitySearch = new SearchFactory({
      objectType: m.Facility,
      roleTypes: [m.Facility.Name],
    });

    const filterDefinition = new FilterDefinition(predicate, {
      supplier: { search: () => Filters.allSuppliersFilter(m), display: (v: Organisation) => v && v.PartyName },
      manufacturer: { search: () => manufacturerSearch, display: (v: Organisation) => v && v.PartyName },
      brand: { search: () => brandSearch, display: (v: Brand) => v && v.Name },
      model: { search: () => modelSearch, display: (v: Model) => v && v.Name },
      kind: { search: () => kindSearch, display: (v: InventoryItemKind) => v && v.Name },
      type: { search: () => typeSearch, display: (v: ProductType) => v && v.Name },
      category: { search: () => categorySearch, display: (v: PartCategory) => v && v.Name },
      identification: { search: () => idSearch, display: (v: ProductIdentification) => v && v.Identification },
      inStock: { search: () => facilitySearch, display: (v: Facility) => v && v.Name },
      outOfStock: { search: () => facilitySearch, display: (v: Facility) => v && v.Name },
    });
    this.filter = new Filter(filterDefinition);

    const sorter = new Sorter({
      name: m.NonUnifiedPart.Name,
      partNo: m.NonUnifiedPart.ProductNumber,
      lastModifiedDate: m.UnifiedProduct.LastModifiedDate,
    });

    this.subscription = combineLatest(this.refreshService.refresh$, this.filter.fields$, this.table.sort$, this.table.pager$, this.internalOrganisationId.observable$)
      .pipe(
        scan(([previousRefresh, previousFilterFields], [refresh, filterFields, sort, pageEvent, internalOrganisationId]) => {
          pageEvent =
            previousRefresh !== refresh || filterFields !== previousFilterFields
              ? {
                  ...pageEvent,
                  pageIndex: 0,
                }
              : pageEvent;

          if (pageEvent.pageIndex === 0) {
            this.table.pageIndex = 0;
          }

          return [refresh, filterFields, sort, pageEvent, internalOrganisationId];
        }),
        switchMap(([, filterFields, sort, pageEvent, internalOrganisationId]: [Date, FilterField[], Sort, PageEvent, number]) => {
          const pulls = [
            this.fetcher.internalOrganisation,
            pull.InternalOrganisation({
              objectId: internalOrganisationId,
              include: { FacilitiesWhereOwner: x },
            }),
            pull.NonUnifiedPart({
              predicate,
              sorting: sorter.create(sort),
              include: {
                Brand: x,
                Model: x,
                ProductType: x,
                PrimaryPhoto: x,
                InventoryItemKind: x,
                InventoryItemsWherePart: {
                  Facility: x,
                },
                ProductIdentifications: {
                  ProductIdentificationType: x,
                },
              },
              arguments: this.filter.parameters(filterFields),
              skip: pageEvent.pageIndex * pageEvent.pageSize,
              take: pageEvent.pageSize,
            }),
            pull.Singleton({
              objectId: this.singletonId.value,
              select: {
                NonUnifiedPartBarcodePrint: {
                  include: {
                    PrintDocument: {
                      Media: x,
                    },
                  },
                },
              },
            }),
            pull.ProductIdentificationType({}),
            pull.BasePrice({}),
            pull.Person({
              objectId: this.userId.value,
              include: { Locale: x },
            }),
          ];

          return this.allors.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();

        this.user = loaded.object<Person>(m.Person);
        this.internalOrganisation = this.fetcher.getInternalOrganisation(loaded);
        this.facilities = loaded.collection<Facility>(m.Facility);
        this.nonUnifiedPartBarcodePrint = loaded.object<NonUnifiedPartBarcodePrint>(m.Singleton.NonUnifiedPartBarcodePrint);

        this.parts = loaded.collection<NonUnifiedPart>(m.NonUnifiedPart);

        const inStockSearch = this.filter.fields?.find((v) => v.definition.name === 'In Stock');
        let facilitySearchId = inStockSearch?.value;
        if (inStockSearch != null) {
          this.parts = this.parts?.filter((v) => {
            return v.InventoryItemsWherePart?.filter((i: NonSerialisedInventoryItem) => i.Facility.id === inStockSearch.value && Number(i.QuantityOnHand) > 0).length > 0;
          });
        }

        const outOStockSearch = this.filter.fields?.find((v) => v.definition.name === 'Out Of Stock');
        if (facilitySearchId == null) {
          facilitySearchId = outOStockSearch?.value;
        }

        if (outOStockSearch != null) {
          this.parts = this.parts?.filter((v) => {
            return v.InventoryItemsWherePart?.filter((i: NonSerialisedInventoryItem) => i.Facility.id === outOStockSearch.value && Number(i.QuantityOnHand) === 0).length > 0;
          });
        }

        this.goodIdentificationTypes = loaded.collection<ProductIdentificationType>(m.ProductIdentificationType);

        this.table.total = (loaded.value('NonUnifiedParts_total') ?? 0) as number;

        this.table.data = this.parts?.map((v) => {
          return {
            object: v,
            name: v.Name,
            partNo: v.ProductNumber,
            qoh: v.QuantityOnHand,
            localQoh: facilitySearchId && (v.InventoryItemsWherePart as NonSerialisedInventoryItem[])?.find((i) => i.Facility.id === facilitySearchId).QuantityOnHand,
            categories: v.PartCategoriesDisplayName,
            brand: v.Brand ? v.Brand.Name : '',
            model: v.Model ? v.Model.Name : '',
            kind: v.InventoryItemKind.Name,
            lastModifiedDate: formatDistance(new Date(v.LastModifiedDate), new Date()),
          } as Row;
        });
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public printBarcode(parts: any): void {
    this.nonUnifiedPartBarcodePrint.Parts = parts;
    this.nonUnifiedPartBarcodePrint.Facility = this.internalOrganisation.FacilitiesWhereOwner[0];
    this.nonUnifiedPartBarcodePrint.Locale = this.user.Locale;

    this.allors.context.push().subscribe(() => {
      const m = this.m;
      const { pullBuilder: pull } = m;
      const x = {};

      const pulls = [
        pull.Singleton({
          objectId: this.singletonId.value,
          select: {
            NonUnifiedPartBarcodePrint: {
              include: {
                PrintDocument: {
                  Media: x,
                },
              },
            },
          },
        }),
      ];

      this.allors.context.pull(pulls).subscribe((loaded) => {
        this.allors.context.reset();

        this.nonUnifiedPartBarcodePrint = loaded.object<NonUnifiedPartBarcodePrint>(m.Singleton.NonUnifiedPartBarcodePrint);

        this.print.execute(this.nonUnifiedPartBarcodePrint);
        this.refreshService.refresh();
      });
    }, this.saveService.errorHandler);
  }
}
