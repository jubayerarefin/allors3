// dummy module for IDE support
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatExpansionModule } from '@angular/material/expansion';
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
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';

import {
  AllorsFocusDirective,
  AllorsBarcodeDirective,
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
} from './index';

@NgModule({
  declarations: [
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
  ],
  imports: [
    BrowserModule,
    NoopAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatExpansionModule,
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
    MatTabsModule,
    MatTableModule,
    MatToolbarModule,
  ],
})
export class AppModule {}
