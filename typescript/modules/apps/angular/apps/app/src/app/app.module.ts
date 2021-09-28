import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, NativeDateAdapter } from '@angular/material/core';
import { MAT_AUTOCOMPLETE_DEFAULT_OPTIONS } from '@angular/material/autocomplete';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { enGB } from 'date-fns/locale';

import { WorkspaceService } from '@allors/workspace/angular/core';
import { Configuration, IdGenerator, PrototypeObjectFactory, ServicesBuilder } from '@allors/workspace/adapters/system';
import { DatabaseConnection, ReactiveDatabaseClient } from '@allors/workspace/adapters/json/system';
import { LazyMetaPopulation } from '@allors/workspace/meta/json/system';
import { data } from '@allors/workspace/meta/json/default';
import { M, tags } from '@allors/workspace/meta/default';
import { ruleBuilder } from '@allors/workspace/derivations/apps-custom';

import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';

import { WorkspaceServices } from '../allors/workspace-services';
import { AngularClient } from '../allors/angular-client';
import { AuthorizationService } from './auth/authorization.service';
import { AppComponent } from './app.component';
import { environment } from '../environments/environment';

import {
  DateConfig,
  MediaConfig,
  AuthenticationConfig,
  AuthenticationInterceptor,
  AllorsFocusDirective,
  AllorsBarcodeDirective,
  AuthenticationServiceBase,
  DateServiceCore,
  MediaServiceCore,
  AllorsBarcodeServiceCore,
  AllorsFocusServiceCore,
  NavigationServiceCore,
  RefreshServiceCore,
  AuthenticationService,
  DateService,
  AllorsFocusService,
  RefreshService,
  AllorsBarcodeService,
  NavigationService,
  MediaService,
  AllorsMaterialDialogService,
  ObjectService,
  SaveService,
  AllorsMaterialSideNavService,
  AllorsMaterialAssociationAutoCompleteComponent,
  AllorsMaterialDialogComponent,
  AllorsMaterialErrorDialogComponent,
  AllorsMaterialFilterFieldDialogComponent,
  AllorsMaterialFilterFieldSearchComponent,
  AllorsMaterialFilterComponent,
  AllorsMaterialFooterComponent,
  AllorsMaterialFooterSaveCancelComponent,
  AllorsMaterialHeaderComponent,
  AllorsMaterialLauncherComponent,
  AllorsMaterialMediaComponent,
  AllorMediaPreviewComponent,
  AllorsMaterialAutocompleteComponent,
  AllorsMaterialCheckboxComponent,
  AllorsMaterialChipsComponent,
  AllorsMaterialDatepickerComponent,
  AllorsMaterialDatetimepickerComponent,
  AllorsMaterialFileComponent,
  AllorsMaterialFilesComponent,
  AllorsMaterialInputComponent,
  AllorsMaterialLocalisedMarkdownComponent,
  AllorsMaterialLocalisedTextComponent,
  AllorsMaterialMarkdownComponent,
  AllorsMaterialMonthpickerComponent,
  AllorsMaterialRadioGroupComponent,
  AllorsMaterialSelectComponent,
  AllorsMaterialSliderComponent,
  AllorsMaterialSlideToggleComponent,
  AllorsMaterialStaticComponent,
  AllorsMaterialTextareaComponent,
  AllorsMaterialScannerComponent,
  AllorsMaterialSideMenuComponent,
  AllorsMaterialSideNavToggleComponent,
  AllorsMaterialTableComponent,
  FactoryFabComponent,
  AllorsMaterialDialogServiceCore,
  ObjectServiceCore,
  SaveServiceCore,
  AllorsMaterialSideNavServiceCore,
  OBJECT_CREATE_TOKEN,
  OBJECT_EDIT_TOKEN,
} from '@allors/workspace/angular/base';

// Angular Material Base
import {
  BasepriceEditComponent,
  BrandEditComponent,
  InlineBrandComponent,
  BrandsOverviewComponent,
  CarrierEditComponent,
  CarrierListComponent,
  CatalogueEditComponent,
  CataloguesListComponent,
  CommunicationEventListComponent,
  CommunicationEventOverviewPanelComponent,
  CommunicationEventWorkTaskComponent,
  ContactMechanismInlineComponent,
  ContactMechanismOverviewPanelComponent,
  CustomerRelationshipEditComponent,
  CustomerShipmentCreateComponent,
  CustomerShipmentOverviewComponent,
  CustomerShipmentOverviewDetailComponent,
  CustomerShipmentOverviewSummaryComponent,
  DisbursementEditComponent,
  EmailAddressCreateComponent,
  EmailAddressEditComponent,
  PartyContactMechanismEmailAddressInlineComponent,
  EmailCommunicationEditComponent,
  EmploymentEditComponent,
  ExchangeRateEditComponent,
  ExchangeRateListComponent,
  FaceToFaceCommunicationEditComponent,
  FacilityInlineComponent,
  GoodListComponent,
  SelectInternalOrganisationComponent,
  InventoryItemTransactionEditComponent,
  LetterCorrespondenceEditComponent,
  InlineModelComponent,
  NonSerialisedInventoryItemEditComponent,
  NonSerialisedInventoryItemComponent,
  NonUnifiedGoodCreateComponent,
  NonUnifiedGoodOverviewComponent,
  NonUnifiedGoodOverviewDetailComponent,
  NonUnifiedGoodOverviewSummaryComponent,
  NonUnifiedPartCreateComponent,
  NonUnifiedPartListComponent,
  NonUnifiedPartOverviewComponent,
  NonUnifiedPartOverviewDetailComponent,
  NonUnifiedPartOverviewSummaryComponent,
  NotificationLinkComponent,
  NotificationListComponent,
  OrderAdjustmentEditComponent,
  OrderAdjustmentOverviewPanelComponent,
  OrganisationCreateComponent,
  OrganisationInlineComponent,
  OrganisationListComponent,
  OrganisationOverviewComponent,
  OrganisationOverviewDetailComponent,
  OrganisationOverviewSummaryComponent,
  OrganisationContactRelationshipEditComponent,
  PartListComponent,
  PartCategoryEditComponent,
  PartCategoryListComponent,
  PartyInlineComponent,
  PartyContactmechanismEditComponent,
  PartyContactMechanismOverviewPanelComponent,
  PartyRateEditComponent,
  PartyRateOverviewPanelComponent,
  PartyRelationshipOverviewPanelComponent,
  PaymentOverviewPanelComponent,
  PersonCreateComponent,
  PersonInlineComponent,
  PersonListComponent,
  PersonOverviewComponent,
  PersonOverviewDetailComponent,
  PersonOverviewSummaryComponent,
  PhoneCommunicationEditComponent,
  PositionTypeEditComponent,
  PositionTypesOverviewComponent,
  PositionTypeRateEditComponent,
  PositionTypeRatesOverviewComponent,
  PostalAddressCreateComponent,
  PostalAddressEditComponent,
  PartyContactMechanismPostalAddressInlineComponent,
  PriceComponentOverviewPanelComponent,
  ProductCategoryEditComponent,
  ProductCategoryListComponent,
  ProductIdentificationEditComponent,
  ProductIdentificationsPanelComponent,
  ProductQuoteCreateComponent,
  ProductQuoteListComponent,
  ProductQuoteOverviewComponent,
  ProductQuoteOverviewDetailComponent,
  ProductQuoteOverviewPanelComponent,
  ProductQuoteOverviewSummaryComponent,
  ProductQuoteApprovalEditComponent,
  ProductTypeEditComponent,
  ProductTypesOverviewComponent,
  PurchaseInvoiceCreateComponent,
  PurchaseInvoiceListComponent,
  PurchaseInvoiceOverviewComponent,
  PurchaseInvoiceOverviewDetailComponent,
  PurchasInvoiceOverviewSummaryComponent,
  PurchaseInvoiceApprovalEditComponent,
  PurchaseInvoiceItemEditComponent,
  PurchaseInvoiceItemOverviewPanelComponent,
  PurchaseOrderCreateComponent,
  PurchaseOrderListComponent,
  PurchaseOrderOverviewComponent,
  PurchaseOrderOverviewDetailComponent,
  PurchaseOrderInvoiceOverviewPanelComponent,
  PurchaseOrderOverviewPanelComponent,
  PurchaseOrderOverviewSummaryComponent,
  PurchaseOrderApprovalLevel1EditComponent,
  PurchaseOrderApprovalLevel2EditComponent,
  PurchaseOrderItemEditComponent,
  PurchaseOrderItemOverviewPanelComponent,
  PurchaseReturnCreateComponent,
  PurchaseShipmentCreateComponent,
  PurchaseShipmentOverviewComponent,
  PurchaseShipmentOverviewDetailComponent,
  PurchaseShipmentOverviewSummaryComponent,
  QuoteItemEditComponent,
  QuoteItemOverviewPanelComponent,
  ReceiptEditComponent,
  RepeatingPurchaseInvoiceEditComponent,
  RepeatingPurchaseInvoiceOverviewPanelComponent,
  RepeatingSalesInvoiceEditComponent,
  RepeatingSalesInvoiceOverviewPanelComponent,
  RequestForQuoteCreateComponent,
  RequestForQuoteListComponent,
  RequestForQuoteOverviewComponent,
  RequestForQuoteOverviewDetailComponent,
  RequestForQuoteOverviewPanelComponent,
  RequestForQuoteOverviewSummaryComponent,
  RequestItemEditComponent,
  RequestItemOverviewPanelComponent,
  SalesInvoiceCreateComponent,
  SalesInvoiceListComponent,
  SalesInvoiceOverviewComponent,
  SalesInvoiceOverviewDetailComponent,
  SalesInvoiceOverviewPanelComponent,
  SalesInvoiceOverviewSummaryComponent,
  SalesInvoiceItemEditComponent,
  SalesInvoiceItemOverviewPanelComponent,
  SalesOrderCreateComponent,
  SalesOrderListComponent,
  SalesOrderOverviewComponent,
  SalesOrderOverviewDetailComponent,
  SalesOrderOverviewPanelComponent,
  SalesOrderOverviewSummaryComponent,
  SalesOrderItemEditComponent,
  SalesOrderItemOverviewPanelComponent,
  SalesOrderTransferEditComponent,
  SalesOrderTransferOverviewPanelComponent,
  SalesTermEditComponent,
  SalesTermOverviewPanelComponent,
  SerialisedInventoryItemComponent,
  SerialisedItemCreateComponent,
  SerialisedItemListComponent,
  SerialisedItemOverviewComponent,
  SerialisedItemOverviewDetailComponent,
  SerialisedItemOverviewPanelComponent,
  SerialisedItemOverviewSummaryComponent,
  SerialisedItemCharacteristicEditComponent,
  SerialisedItemCharacteristicListComponent,
  ShipmentListComponent,
  ShipmentItemEditComponent,
  ShipmentItemOverviewPanelComponent,
  SubContractorRelationshipEditComponent,
  SupplierOfferingEditComponent,
  SupplierOfferingOverviewPanelComponent,
  SupplierRelationshipEditComponent,
  TaskAssignmentLinkComponent,
  TaskAssignmentListComponent,
  TelecommunicationsNumberCreateComponent,
  TelecommunicationsNumberEditComponent,
  PartyContactMechanismTelecommunicationsNumberInlineComponent,
  TimeEntryEditComponent,
  TimeEntryOverviewPanelComponent,
  UnifiedGoodCreateComponent,
  UnifiedGoodListComponent,
  UnifiedGoodOverviewComponent,
  UnifiedGoodOverviewDetailComponent,
  UnifiedGoodOverviewSummaryComponent,
  UserProfileEditComponent,
  UserProfileLinkComponent,
  WebAddressCreateComponent,
  WebAddressEditComponent,
  InlineWebAddressComponent,
  WorkEffortListComponent,
  WorkEffortOverviewPanelComponent,
  WorkEffortAssignmentRateEditComponent,
  WorkEffortAssignmentRateOverviewPanelComponent,
  WorkEffortFixedAssetAssignmentEditComponent,
  WorkEffortFAAssignmentOverviewPanelComponent,
  WorkEffortInventoryAssignmentEditComponent,
  WorkEffortInventoryAssignmentOverviewPanelComponent,
  WorkEffortPartyAssignmentEditComponent,
  WorkEffortPartyAssignmentOverviewPanelComponent,
  WorkEffortPurchaseOrderItemAssignmentEditComponent,
  WorkEffortPOIAssignmentOverviewPanelComponent,
  WorkTaskCreateComponent,
  WorkTaskOverviewComponent,
  WorkTaskOverviewDetailComponent,
  WorkTaskOverviewPanelComponent,
  WorkTaskOverviewSummaryComponent,
  PrintService,
  PrintConfig,
} from '@allors/workspace/angular/apps';

import { LoginComponent } from './auth/login.component';
import { MainComponent } from './main/main.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { configure } from './configure';
import { ErrorComponent } from './error/error.component';

export function appInitFactory(workspaceService: WorkspaceService, httpClient: HttpClient) {
  return async () => {
    const client = new AngularClient(httpClient, environment.baseUrl, environment.authUrl);
    workspaceService.client = new ReactiveDatabaseClient(client);

    const metaPopulation = new LazyMetaPopulation(data);
    const m = metaPopulation as unknown as M;
    const configuration = new Configuration('Default', metaPopulation, new PrototypeObjectFactory(metaPopulation));
    let nextId = -1;
    const idGenerator: IdGenerator = () => nextId--;
    const serviceBuilder: ServicesBuilder = () => {
      return new WorkspaceServices(ruleBuilder(m));
    };
    const database = new DatabaseConnection(configuration, idGenerator, serviceBuilder);
    const workspace = database.createWorkspace();
    workspaceService.workspace = workspace;

    const angularMeta = workspace.services.angularMetaService;
    configure(m, angularMeta);
  };
}

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'error', component: ErrorComponent },
  {
    canActivate: [AuthorizationService],
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        component: DashboardComponent,
        pathMatch: 'full',
      },
      {
        path: 'contacts',
        children: [
          { path: 'people', component: PersonListComponent },
          { path: 'person/:id', component: PersonOverviewComponent },
          { path: 'organisations', component: OrganisationListComponent },
          { path: 'organisation/:id', component: OrganisationOverviewComponent },
          { path: 'communicationevents', component: CommunicationEventListComponent },
        ],
      },

      {
        path: 'sales',
        children: [
          { path: 'requestsforquote', component: RequestForQuoteListComponent },
          { path: 'requestforquote/:id', component: RequestForQuoteOverviewComponent },
          { path: 'productquotes', component: ProductQuoteListComponent },
          { path: 'productquote/:id', component: ProductQuoteOverviewComponent },
          { path: 'salesorders', component: SalesOrderListComponent },
          { path: 'salesorder/:id', component: SalesOrderOverviewComponent },
          { path: 'salesinvoices', component: SalesInvoiceListComponent },
          { path: 'salesinvoice/:id', component: SalesInvoiceOverviewComponent },
        ],
      },

      {
        path: 'products',
        children: [
          { path: 'goods', component: GoodListComponent },
          { path: 'nonunifiedgood/:id', component: NonUnifiedGoodOverviewComponent },
          { path: 'parts', component: PartListComponent },
          { path: 'nonunifiedpart/:id', component: NonUnifiedPartOverviewComponent },
          { path: 'catalogues', component: CataloguesListComponent },
          { path: 'productcategories', component: ProductCategoryListComponent },
          { path: 'serialiseditemcharacteristics', component: SerialisedItemCharacteristicListComponent },
          { path: 'producttypes', component: ProductTypesOverviewComponent },
          { path: 'serialiseditems', component: SerialisedItemListComponent },
          { path: 'serialisedItem/:id', component: SerialisedItemOverviewComponent },
          { path: 'unifiedgoods', component: UnifiedGoodListComponent },
          { path: 'unifiedgood/:id', component: UnifiedGoodOverviewComponent },
        ],
      },

      {
        path: 'purchasing',
        children: [
          { path: 'purchaseorders', component: PurchaseOrderListComponent },
          { path: 'purchaseorder/:id', component: PurchaseOrderOverviewComponent },
          { path: 'purchaseinvoices', component: PurchaseInvoiceListComponent },
          { path: 'purchaseinvoice/:id', component: PurchaseInvoiceOverviewComponent },
        ],
      },

      {
        path: 'shipment',
        children: [
          { path: 'shipments', component: ShipmentListComponent },
          { path: 'customershipment/:id', component: CustomerShipmentOverviewComponent },
          { path: 'purchaseshipment/:id', component: PurchaseShipmentOverviewComponent },
          { path: 'carriers', component: CarrierListComponent },
        ],
      },

      {
        path: 'workefforts',
        children: [
          { path: 'workefforts', component: WorkEffortListComponent },
          { path: 'worktask/:id', component: WorkTaskOverviewComponent },
        ],
      },

      {
        path: 'humanresource',
        children: [
          { path: 'positiontypes', component: PositionTypesOverviewComponent },
          { path: 'positiontyperates', component: PositionTypeRatesOverviewComponent },
        ],
      },

      {
        path: 'workflow',
        children: [{ path: 'taskassignments', component: TaskAssignmentListComponent }],
      },
      {
        path: 'accounting',
        children: [{ path: 'exchangerates', component: ExchangeRateListComponent }],
      },
    ],
  },
];

export const create = {
  [tags.BasePrice]: BasepriceEditComponent,
  [tags.Carrier]: CarrierEditComponent,
  [tags.Catalogue]: CatalogueEditComponent,
  [tags.CustomerRelationship]: CustomerRelationshipEditComponent,
  [tags.CustomerShipment]: CustomerShipmentCreateComponent,
  [tags.Disbursement]: DisbursementEditComponent,
  [tags.DiscountAdjustment]: OrderAdjustmentEditComponent,
  [tags.EanIdentification]: ProductIdentificationEditComponent,
  [tags.EmailAddress]: EmailAddressCreateComponent,
  [tags.EmailCommunication]: EmailCommunicationEditComponent,
  [tags.Employment]: EmploymentEditComponent,
  [tags.ExchangeRate]: ExchangeRateEditComponent,
  [tags.FaceToFaceCommunication]: FaceToFaceCommunicationEditComponent,
  [tags.Fee]: OrderAdjustmentEditComponent,
  [tags.IncoTerm]: SalesTermEditComponent,
  [tags.InventoryItemTransaction]: InventoryItemTransactionEditComponent,
  [tags.InvoiceTerm]: SalesTermEditComponent,
  [tags.IsbnIdentification]: ProductIdentificationEditComponent,
  [tags.LetterCorrespondence]: LetterCorrespondenceEditComponent,
  [tags.ManufacturerIdentification]: ProductIdentificationEditComponent,
  [tags.MiscellaneousCharge]: OrderAdjustmentEditComponent,
  [tags.OrderTerm]: SalesTermEditComponent,
  [tags.Organisation]: OrganisationCreateComponent,
  [tags.OrganisationContactRelationship]: OrganisationContactRelationshipEditComponent,
  [tags.NonSerialisedInventoryItem]: NonSerialisedInventoryItemEditComponent,
  [tags.NonUnifiedGood]: NonUnifiedGoodCreateComponent,
  [tags.NonUnifiedPart]: NonUnifiedPartCreateComponent,
  [tags.PartNumber]: ProductIdentificationEditComponent,
  [tags.PartyContactMechanism]: PartyContactmechanismEditComponent,
  [tags.PartyRate]: PartyRateEditComponent,
  [tags.Person]: PersonCreateComponent,
  [tags.PhoneCommunication]: PhoneCommunicationEditComponent,
  [tags.PositionType]: PositionTypeEditComponent,
  [tags.PositionTypeRate]: PositionTypeRateEditComponent,
  [tags.PostalAddress]: PostalAddressCreateComponent,
  [tags.ProductCategory]: ProductCategoryEditComponent,
  [tags.ProductNumber]: ProductIdentificationEditComponent,
  [tags.ProductQuote]: ProductQuoteCreateComponent,
  [tags.ProductType]: ProductTypeEditComponent,
  [tags.PurchaseInvoice]: PurchaseInvoiceCreateComponent,
  [tags.PurchaseInvoiceItem]: PurchaseInvoiceItemEditComponent,
  [tags.PurchaseOrder]: PurchaseOrderCreateComponent,
  [tags.PurchaseOrderItem]: PurchaseOrderItemEditComponent,
  [tags.PurchaseReturn]: PurchaseReturnCreateComponent,
  [tags.PurchaseShipment]: PurchaseShipmentCreateComponent,
  [tags.QuoteItem]: QuoteItemEditComponent,
  [tags.Receipt]: ReceiptEditComponent,
  [tags.RepeatingPurchaseInvoice]: RepeatingPurchaseInvoiceEditComponent,
  [tags.RepeatingSalesInvoice]: RepeatingSalesInvoiceEditComponent,
  [tags.RequestItem]: RequestItemEditComponent,
  [tags.RequestForQuote]: RequestForQuoteCreateComponent,
  [tags.SalesInvoice]: SalesInvoiceCreateComponent,
  [tags.SalesInvoiceItem]: SalesInvoiceItemEditComponent,
  [tags.SalesOrder]: SalesOrderCreateComponent,
  [tags.SalesOrderItem]: SalesOrderItemEditComponent,
  [tags.SerialisedItem]: SerialisedItemCreateComponent,
  [tags.SerialisedItemCharacteristicType]: SerialisedItemCharacteristicEditComponent,
  [tags.ShipmentItem]: ShipmentItemEditComponent,
  [tags.ShippingAndHandlingCharge]: OrderAdjustmentEditComponent,
  [tags.SkuIdentification]: ProductIdentificationEditComponent,
  [tags.SubContractorRelationship]: SubContractorRelationshipEditComponent,
  [tags.SupplierOffering]: SupplierOfferingEditComponent,
  [tags.SupplierRelationship]: SupplierRelationshipEditComponent,
  [tags.SurchargeAdjustment]: OrderAdjustmentEditComponent,
  [tags.TelecommunicationsNumber]: TelecommunicationsNumberCreateComponent,
  [tags.TimeEntry]: TimeEntryEditComponent,
  [tags.UnifiedGood]: UnifiedGoodCreateComponent,
  [tags.UpcaIdentification]: ProductIdentificationEditComponent,
  [tags.UpceIdentification]: ProductIdentificationEditComponent,
  [tags.WebAddress]: WebAddressCreateComponent,
  [tags.WorkEffortAssignmentRate]: WorkEffortAssignmentRateEditComponent,
  [tags.WorkEffortFixedAssetAssignment]: WorkEffortFixedAssetAssignmentEditComponent,
  [tags.WorkEffortInventoryAssignment]: WorkEffortInventoryAssignmentEditComponent,
  [tags.WorkEffortPartyAssignment]: WorkEffortPartyAssignmentEditComponent,
  // [tags.WorkEffortPurchaseOrderItemAssignment]: WorkEffortPurchaseOrderItemAssignmentEditComponent,
  [tags.WorkTask]: WorkTaskCreateComponent,
};

export const edit = {
  [tags.BasePrice]: BasepriceEditComponent,
  [tags.Carrier]: CarrierEditComponent,
  [tags.Catalogue]: CatalogueEditComponent,
  [tags.CustomerRelationship]: CustomerRelationshipEditComponent,
  [tags.Disbursement]: DisbursementEditComponent,
  [tags.DiscountAdjustment]: OrderAdjustmentEditComponent,
  [tags.EanIdentification]: ProductIdentificationEditComponent,
  [tags.EmailAddress]: EmailAddressEditComponent,
  [tags.EmailCommunication]: EmailCommunicationEditComponent,
  [tags.Employment]: EmploymentEditComponent,
  [tags.ExchangeRate]: ExchangeRateEditComponent,
  [tags.FaceToFaceCommunication]: FaceToFaceCommunicationEditComponent,
  [tags.Fee]: OrderAdjustmentEditComponent,
  [tags.IncoTerm]: SalesTermEditComponent,
  [tags.InventoryItemTransaction]: InventoryItemTransactionEditComponent,
  [tags.InvoiceTerm]: SalesTermEditComponent,
  [tags.IsbnIdentification]: ProductIdentificationEditComponent,
  [tags.LetterCorrespondence]: LetterCorrespondenceEditComponent,
  [tags.ManufacturerIdentification]: ProductIdentificationEditComponent,
  [tags.MiscellaneousCharge]: OrderAdjustmentEditComponent,
  [tags.NonSerialisedInventoryItem]: NonSerialisedInventoryItemEditComponent,
  [tags.OrderTerm]: SalesTermEditComponent,
  [tags.OrganisationContactRelationship]: OrganisationContactRelationshipEditComponent,
  [tags.PartyContactMechanism]: PartyContactmechanismEditComponent,
  [tags.PartyRate]: PartyRateEditComponent,
  [tags.PhoneCommunication]: PhoneCommunicationEditComponent,
  [tags.PositionType]: PositionTypeEditComponent,
  [tags.PositionTypeRate]: PositionTypeRateEditComponent,
  [tags.PostalAddress]: PostalAddressEditComponent,
  [tags.ProductCategory]: ProductCategoryEditComponent,
  [tags.PartNumber]: ProductIdentificationEditComponent,
  [tags.ProductNumber]: ProductIdentificationEditComponent,
  [tags.ProductType]: ProductTypeEditComponent,
  [tags.ProductQuoteApproval]: ProductQuoteApprovalEditComponent,
  [tags.PurchaseInvoiceApproval]: PurchaseInvoiceApprovalEditComponent,
  [tags.PurchaseInvoiceItem]: PurchaseInvoiceItemEditComponent,
  [tags.PurchaseOrderApprovalLevel1]: PurchaseOrderApprovalLevel1EditComponent,
  [tags.PurchaseOrderApprovalLevel2]: PurchaseOrderApprovalLevel2EditComponent,
  [tags.PurchaseOrderItem]: PurchaseOrderItemEditComponent,
  [tags.QuoteItem]: QuoteItemEditComponent,
  [tags.Receipt]: ReceiptEditComponent,
  [tags.RepeatingPurchaseInvoice]: RepeatingPurchaseInvoiceEditComponent,
  [tags.RepeatingSalesInvoice]: RepeatingSalesInvoiceEditComponent,
  [tags.RequestItem]: RequestItemEditComponent,
  [tags.SalesInvoiceItem]: SalesInvoiceItemEditComponent,
  [tags.SalesOrderItem]: SalesOrderItemEditComponent,
  [tags.SerialisedItemCharacteristicType]: SerialisedItemCharacteristicEditComponent,
  [tags.ShipmentItem]: ShipmentItemEditComponent,
  [tags.ShippingAndHandlingCharge]: OrderAdjustmentEditComponent,
  [tags.SkuIdentification]: ProductIdentificationEditComponent,
  [tags.SupplierOffering]: SupplierOfferingEditComponent,
  [tags.SubContractorRelationship]: SubContractorRelationshipEditComponent,
  [tags.SupplierRelationship]: SupplierRelationshipEditComponent,
  [tags.SurchargeAdjustment]: OrderAdjustmentEditComponent,
  [tags.TelecommunicationsNumber]: TelecommunicationsNumberEditComponent,
  [tags.TimeEntry]: TimeEntryEditComponent,
  [tags.UpcaIdentification]: ProductIdentificationEditComponent,
  [tags.UpceIdentification]: ProductIdentificationEditComponent,
  [tags.UserProfile]: UserProfileEditComponent,
  [tags.WebAddress]: WebAddressEditComponent,
  [tags.WorkEffortAssignmentRate]: WorkEffortAssignmentRateEditComponent,
  [tags.WorkEffortFixedAssetAssignment]: WorkEffortFixedAssetAssignmentEditComponent,
  [tags.WorkEffortInventoryAssignment]: WorkEffortInventoryAssignmentEditComponent,
  // [tags.WorkEffortPurchaseOrderItemAssignment]: WorkEffortPurchaseOrderItemAssignmentEditComponent,
  [tags.WorkEffortPartyAssignment]: WorkEffortPartyAssignmentEditComponent,
};

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    // Allors Angular Core
    AllorsFocusDirective,
    AllorsBarcodeDirective,
    AllorsMaterialAssociationAutoCompleteComponent,
    AllorsMaterialDialogComponent,
    AllorsMaterialErrorDialogComponent,
    AllorsMaterialFilterComponent,
    AllorsMaterialFilterFieldDialogComponent,
    AllorsMaterialFilterFieldSearchComponent,
    AllorsMaterialFooterComponent,
    AllorsMaterialFooterSaveCancelComponent,
    AllorsMaterialHeaderComponent,
    AllorsMaterialLauncherComponent,
    AllorsMaterialMediaComponent,
    AllorMediaPreviewComponent,
    AllorsMaterialAutocompleteComponent,
    AllorsMaterialCheckboxComponent,
    AllorsMaterialChipsComponent,
    AllorsMaterialDatepickerComponent,
    AllorsMaterialDatetimepickerComponent,
    AllorsMaterialFileComponent,
    AllorsMaterialFilesComponent,
    AllorsMaterialInputComponent,
    AllorsMaterialLocalisedMarkdownComponent,
    AllorsMaterialLocalisedTextComponent,
    AllorsMaterialMarkdownComponent,
    AllorsMaterialMonthpickerComponent,
    AllorsMaterialRadioGroupComponent,
    AllorsMaterialSelectComponent,
    AllorsMaterialSliderComponent,
    AllorsMaterialSlideToggleComponent,
    AllorsMaterialStaticComponent,
    AllorsMaterialTextareaComponent,
    AllorsMaterialScannerComponent,
    AllorsMaterialSideMenuComponent,
    AllorsMaterialSideNavToggleComponent,
    AllorsMaterialTableComponent,
    FactoryFabComponent,
    // Apps
    BasepriceEditComponent,
    BrandEditComponent,
    InlineBrandComponent,
    BrandsOverviewComponent,
    CarrierEditComponent,
    CarrierListComponent,
    CatalogueEditComponent,
    CataloguesListComponent,
    CommunicationEventListComponent,
    CommunicationEventOverviewPanelComponent,
    CommunicationEventWorkTaskComponent,
    ContactMechanismInlineComponent,
    ContactMechanismOverviewPanelComponent,
    CustomerRelationshipEditComponent,
    CustomerShipmentCreateComponent,
    CustomerShipmentOverviewComponent,
    CustomerShipmentOverviewDetailComponent,
    CustomerShipmentOverviewSummaryComponent,
    DisbursementEditComponent,
    EmailAddressCreateComponent,
    EmailAddressEditComponent,
    PartyContactMechanismEmailAddressInlineComponent,
    EmailCommunicationEditComponent,
    EmploymentEditComponent,
    ExchangeRateEditComponent,
    ExchangeRateListComponent,
    FaceToFaceCommunicationEditComponent,
    FacilityInlineComponent,
    GoodListComponent,
    SelectInternalOrganisationComponent,
    InventoryItemTransactionEditComponent,
    LetterCorrespondenceEditComponent,
    InlineModelComponent,
    NonSerialisedInventoryItemEditComponent,
    NonSerialisedInventoryItemComponent,
    NonUnifiedGoodCreateComponent,
    NonUnifiedGoodOverviewComponent,
    NonUnifiedGoodOverviewDetailComponent,
    NonUnifiedGoodOverviewSummaryComponent,
    NonUnifiedPartCreateComponent,
    NonUnifiedPartListComponent,
    NonUnifiedPartOverviewComponent,
    NonUnifiedPartOverviewDetailComponent,
    NonUnifiedPartOverviewSummaryComponent,
    NotificationLinkComponent,
    NotificationListComponent,
    OrderAdjustmentEditComponent,
    OrderAdjustmentOverviewPanelComponent,
    OrganisationCreateComponent,
    OrganisationInlineComponent,
    OrganisationListComponent,
    OrganisationOverviewComponent,
    OrganisationOverviewDetailComponent,
    OrganisationOverviewSummaryComponent,
    OrganisationContactRelationshipEditComponent,
    PartListComponent,
    PartCategoryEditComponent,
    PartCategoryListComponent,
    PartyInlineComponent,
    PartyContactmechanismEditComponent,
    PartyContactMechanismOverviewPanelComponent,
    PartyRateEditComponent,
    PartyRateOverviewPanelComponent,
    PartyRelationshipOverviewPanelComponent,
    PaymentOverviewPanelComponent,
    PersonCreateComponent,
    PersonInlineComponent,
    PersonListComponent,
    PersonOverviewComponent,
    PersonOverviewDetailComponent,
    PersonOverviewSummaryComponent,
    PhoneCommunicationEditComponent,
    PositionTypeEditComponent,
    PositionTypesOverviewComponent,
    PositionTypeRateEditComponent,
    PositionTypeRatesOverviewComponent,
    PostalAddressCreateComponent,
    PostalAddressEditComponent,
    PartyContactMechanismPostalAddressInlineComponent,
    PriceComponentOverviewPanelComponent,
    ProductCategoryEditComponent,
    ProductCategoryListComponent,
    ProductIdentificationEditComponent,
    ProductIdentificationsPanelComponent,
    ProductQuoteCreateComponent,
    ProductQuoteListComponent,
    ProductQuoteOverviewComponent,
    ProductQuoteOverviewDetailComponent,
    ProductQuoteOverviewPanelComponent,
    ProductQuoteOverviewSummaryComponent,
    ProductQuoteApprovalEditComponent,
    ProductTypeEditComponent,
    ProductTypesOverviewComponent,
    PurchaseInvoiceCreateComponent,
    PurchaseInvoiceListComponent,
    PurchaseInvoiceOverviewComponent,
    PurchaseInvoiceOverviewDetailComponent,
    PurchasInvoiceOverviewSummaryComponent,
    PurchaseInvoiceApprovalEditComponent,
    PurchaseInvoiceItemEditComponent,
    PurchaseInvoiceItemOverviewPanelComponent,
    PurchaseOrderCreateComponent,
    PurchaseOrderListComponent,
    PurchaseOrderOverviewComponent,
    PurchaseOrderOverviewDetailComponent,
    PurchaseOrderInvoiceOverviewPanelComponent,
    PurchaseOrderOverviewPanelComponent,
    PurchaseOrderOverviewSummaryComponent,
    PurchaseOrderApprovalLevel1EditComponent,
    PurchaseOrderApprovalLevel2EditComponent,
    PurchaseOrderItemEditComponent,
    PurchaseOrderItemOverviewPanelComponent,
    PurchaseReturnCreateComponent,
    PurchaseShipmentCreateComponent,
    PurchaseShipmentOverviewComponent,
    PurchaseShipmentOverviewDetailComponent,
    PurchaseShipmentOverviewSummaryComponent,
    QuoteItemEditComponent,
    QuoteItemOverviewPanelComponent,
    ReceiptEditComponent,
    RepeatingPurchaseInvoiceEditComponent,
    RepeatingPurchaseInvoiceOverviewPanelComponent,
    RepeatingSalesInvoiceEditComponent,
    RepeatingSalesInvoiceOverviewPanelComponent,
    RequestForQuoteCreateComponent,
    RequestForQuoteListComponent,
    RequestForQuoteOverviewComponent,
    RequestForQuoteOverviewDetailComponent,
    RequestForQuoteOverviewPanelComponent,
    RequestForQuoteOverviewSummaryComponent,
    RequestItemEditComponent,
    RequestItemOverviewPanelComponent,
    SalesInvoiceCreateComponent,
    SalesInvoiceListComponent,
    SalesInvoiceOverviewComponent,
    SalesInvoiceOverviewDetailComponent,
    SalesInvoiceOverviewPanelComponent,
    SalesInvoiceOverviewSummaryComponent,
    SalesInvoiceItemEditComponent,
    SalesInvoiceItemOverviewPanelComponent,
    SalesOrderCreateComponent,
    SalesOrderListComponent,
    SalesOrderOverviewComponent,
    SalesOrderOverviewDetailComponent,
    SalesOrderOverviewPanelComponent,
    SalesOrderOverviewSummaryComponent,
    SalesOrderItemEditComponent,
    SalesOrderItemOverviewPanelComponent,
    SalesOrderTransferEditComponent,
    SalesOrderTransferOverviewPanelComponent,
    SalesTermEditComponent,
    SalesTermOverviewPanelComponent,
    SerialisedInventoryItemComponent,
    SerialisedItemCreateComponent,
    SerialisedItemListComponent,
    SerialisedItemOverviewComponent,
    SerialisedItemOverviewDetailComponent,
    SerialisedItemOverviewPanelComponent,
    SerialisedItemOverviewSummaryComponent,
    SerialisedItemCharacteristicEditComponent,
    SerialisedItemCharacteristicListComponent,
    ShipmentListComponent,
    ShipmentItemEditComponent,
    ShipmentItemOverviewPanelComponent,
    SubContractorRelationshipEditComponent,
    SupplierOfferingEditComponent,
    SupplierOfferingOverviewPanelComponent,
    SupplierRelationshipEditComponent,
    TaskAssignmentLinkComponent,
    TaskAssignmentListComponent,
    TelecommunicationsNumberCreateComponent,
    TelecommunicationsNumberEditComponent,
    PartyContactMechanismTelecommunicationsNumberInlineComponent,
    TimeEntryEditComponent,
    TimeEntryOverviewPanelComponent,
    UnifiedGoodCreateComponent,
    UnifiedGoodListComponent,
    UnifiedGoodOverviewComponent,
    UnifiedGoodOverviewDetailComponent,
    UnifiedGoodOverviewSummaryComponent,
    UserProfileEditComponent,
    UserProfileLinkComponent,
    WebAddressCreateComponent,
    WebAddressEditComponent,
    InlineWebAddressComponent,
    WorkEffortListComponent,
    WorkEffortOverviewPanelComponent,
    WorkEffortAssignmentRateEditComponent,
    WorkEffortAssignmentRateOverviewPanelComponent,
    WorkEffortFixedAssetAssignmentEditComponent,
    WorkEffortFAAssignmentOverviewPanelComponent,
    WorkEffortInventoryAssignmentEditComponent,
    WorkEffortInventoryAssignmentOverviewPanelComponent,
    WorkEffortPartyAssignmentEditComponent,
    WorkEffortPartyAssignmentOverviewPanelComponent,
    WorkEffortPurchaseOrderItemAssignmentEditComponent,
    WorkEffortPOIAssignmentOverviewPanelComponent,
    WorkTaskCreateComponent,
    WorkTaskOverviewComponent,
    WorkTaskOverviewDetailComponent,
    WorkTaskOverviewPanelComponent,
    WorkTaskOverviewSummaryComponent,
    // App
    LoginComponent,
    MainComponent,
    DashboardComponent,
    AppComponent,
  ],
  imports: [
    BrowserModule,
    environment.production ? BrowserAnimationsModule : NoopAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' }),
    MatAutocompleteModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatPaginatorModule,
    MatRadioModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatToolbarModule,
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: appInitFactory,
      deps: [WorkspaceService, HttpClient],
      multi: true,
    },
    WorkspaceService,
    { provide: AuthenticationService, useClass: AuthenticationServiceBase },
    {
      provide: AuthenticationConfig,
      useValue: {
        url: environment.baseUrl + environment.authUrl,
      },
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true,
    },
    { provide: AllorsBarcodeService, useClass: AllorsBarcodeServiceCore },
    { provide: DateService, useClass: DateServiceCore },
    {
      provide: DateConfig,
      useValue: {
        locale: enGB,
      },
    },
    { provide: AllorsFocusService, useClass: AllorsFocusServiceCore },
    { provide: MediaService, useClass: MediaServiceCore },
    { provide: MediaConfig, useValue: { url: environment.baseUrl } },
    { provide: NavigationService, useClass: NavigationServiceCore },
    { provide: RefreshService, useClass: RefreshServiceCore },
    {
      provide: MAT_AUTOCOMPLETE_DEFAULT_OPTIONS,
      useValue: { autoActiveFirstOption: true },
    },
    { provide: DateAdapter, useClass: NativeDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'nl-BE' },
    {
      provide: MAT_DATE_FORMATS,
      useValue: {
        parse: {
          dateInput: 'dd/MM/yyyy',
        },
        display: {
          dateInput: 'dd/MM/yyyy',
          monthYearLabel: 'LLL y',
          dateA11yLabel: 'MMMM d, y',
          monthYearA11yLabel: 'MMMM y',
        },
      },
    },
    { provide: AllorsMaterialDialogService, useClass: AllorsMaterialDialogServiceCore },
    { provide: ObjectService, useClass: ObjectServiceCore },
    { provide: SaveService, useClass: SaveServiceCore },
    { provide: AllorsMaterialSideNavService, useClass: AllorsMaterialSideNavServiceCore },
    PrintService,
    { provide: PrintConfig, useValue: { url: environment.baseUrl } },
    { provide: ObjectService, useClass: ObjectServiceCore },
    { provide: OBJECT_CREATE_TOKEN, useValue: create },
    { provide: OBJECT_EDIT_TOKEN, useValue: edit },
  ],
})
export class AppModule {}
