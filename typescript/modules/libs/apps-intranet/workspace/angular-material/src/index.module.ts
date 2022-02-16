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
} from '@allors/base/workspace/angular/foundation';

import {
  AllorsMaterialAssociationAutoCompleteComponent,
  AllorsMaterialCancelComponent,
  AllorsMaterialSaveComponent,
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
  AllorsMaterialRadioGroupComponent,
  AllorsMaterialSelectComponent,
  AllorsMaterialSliderComponent,
  AllorsMaterialSlideToggleComponent,
  AllorsMaterialStaticComponent,
  AllorsMaterialTextareaComponent,
  AllorsMaterialPeriodSelectionToggleComponent,
  AllorsMaterialTableComponent,
} from '@allors/base/workspace/angular-material/foundation';

import {
  AllorsMaterialErrorDialogComponent,
  AllorsMaterialFilterFieldDialogComponent,
  AllorsMaterialFilterFieldSearchComponent,
  AllorsMaterialFilterComponent,
  AllorsMaterialMediaComponent,
  AllorMediaPreviewComponent,
  AllorsMaterialBarcodeEntryComponent,
  AllorsMaterialSideMenuComponent,
  AllorsMaterialSideNavToggleComponent,
  FactoryFabComponent,
  AllorsMaterialDynamicCreateComponent,
  AllorsMaterialDynamicEditComponent,
  AllorsMaterialDynamicEditDetailPanelComponent,
  AllorsMaterialDynamicEditObjectPanelComponent,
  AllorsMaterialDynamicEditRelationPanelComponent,
  AllorsMaterialDynamicEditRelationshipPanelComponent,
  AllorsMaterialDynamicSummaryPanelComponent,
  AllorsMaterialDynamicViewDetailPanelComponent,
  AllorsMaterialDynamicViewObjectPanelComponent,
  AllorsMaterialDynamicViewRelationPanelComponent,
  AllorsMaterialDynamicViewRelationshipPanelComponent,
} from '@allors/base/workspace/angular-material/application';

import {
  BasepriceFormComponent,
  BrandFormComponent,
  InlineBrandComponent,
  BrandsOverviewComponent,
  CarrierFormComponent,
  CarrierListComponent,
  CatalogueFormComponent,
  CataloguesListComponent,
  CommunicationEventListComponent,
  ContactMechanismInlineComponent,
  CustomerRelationshipFormComponent,
  CustomerShipmentCreateFormComponent,
  CustomerShipmentOverviewComponent,
  CustomerShipmentEditFormComponent,
  CustomerShipmentSummaryPanelComponent,
  DisbursementFormComponent,
  EmailAddressCreateFormComponent,
  EmailAddressFormComponent,
  PartyContactMechanismEmailAddressInlineComponent,
  EmailCommunicationFormComponent,
  EmploymentFormComponent,
  ExchangeRateFormComponent,
  ExchangeRateListComponent,
  FaceToFaceCommunicationFormComponent,
  FacilityInlineComponent,
  GoodListComponent,
  SelectInternalOrganisationComponent,
  InventoryItemTransactionFormComponent,
  LetterCorrespondenceFormComponent,
  InlineModelComponent,
  NonSerialisedInventoryItemFormComponent,
  NonSerialisedInventoryItemComponent,
  NonUnifiedGoodCreateFormComponent,
  NonUnifiedGoodOverviewComponent,
  NonUnifiedGoodEditFormComponent,
  NonUnifiedGoodOverviewSummaryComponent,
  NonUnifiedPartCreateFormComponent,
  NonUnifiedPartListComponent,
  NonUnifiedPartOverviewComponent,
  NonUnifiedPartEditFormComponent,
  NonUnifiedPartOverviewSummaryComponent,
  NotificationLinkComponent,
  NotificationListComponent,
  OrderAdjustmentFormComponent,
  OrderAdjustmentOverviewPanelComponent,
  OrganisationCreateFormComponent,
  OrganisationInlineComponent,
  OrganisationListComponent,
  OrganisationOverviewPageComponent,
  OrganisationEditFormComponent,
  OrganisationOverviewSummaryComponent,
  OrganisationContactRelationshipFormComponent,
  PartListComponent,
  PartCategoryFormComponent,
  PartCategoryListComponent,
  PartyInlineComponent,
  PartyContactmechanismFormComponent,
  PartyContactMechanismOverviewPanelComponent,
  PartyRateFormComponent,
  PartyRateOverviewPanelComponent,
  PartyRelationshipOverviewPanelComponent,
  PaymentOverviewPanelComponent,
  PersonCreateFormComponent,
  PersonInlineComponent,
  PersonListComponent,
  PersonOverviewPageComponent,
  PersonEditFormComponent,
  PersonOverviewSummaryComponent,
  PhoneCommunicationFormComponent,
  PositionTypeFormComponent,
  PositionTypesOverviewComponent,
  PositionTypeRateFormComponent,
  PositionTypeRatesOverviewComponent,
  PostalAddressCreateFormComponent,
  PostalAddressFormComponent,
  PartyContactMechanismPostalAddressInlineComponent,
  PriceComponentOverviewPanelComponent,
  ProductCategoryFormComponent,
  ProductCategoryListComponent,
  ProductIdentificationFormComponent,
  ProductIdentificationsPanelComponent,
  ProductQuoteCreateFormComponent,
  ProductQuoteListComponent,
  ProductQuoteOverviewComponent,
  ProductQuoteEditFormComponent,
  ProductQuoteOverviewPanelComponent,
  ProductQuoteOverviewSummaryComponent,
  ProductQuoteApprovalFormComponent,
  ProductTypeFormComponent,
  ProductTypesOverviewComponent,
  PurchaseInvoiceCreateFormComponent,
  PurchaseInvoiceListComponent,
  PurchaseInvoiceOverviewComponent,
  PurchaseInvoiceEditFormComponent,
  PurchasInvoiceOverviewSummaryComponent,
  PurchaseInvoiceApprovalFormComponent,
  PurchaseInvoiceItemFormComponent,
  PurchaseInvoiceItemOverviewPanelComponent,
  PurchaseOrderCreateFormComponent,
  PurchaseOrderListComponent,
  PurchaseOrderOverviewComponent,
  PurchaseOrderEditFormComponent,
  PurchaseOrderInvoiceOverviewPanelComponent,
  PurchaseOrderOverviewPanelComponent,
  PurchaseOrderOverviewSummaryComponent,
  PurchaseOrderApprovalLevel1FormComponent,
  PurchaseOrderApprovalLevel2FormComponent,
  PurchaseOrderItemFormComponent,
  PurchaseOrderItemOverviewPanelComponent,
  PurchaseReturnCreateFormComponent,
  PurchaseShipmentCreateFormComponent,
  PurchaseShipmentOverviewComponent,
  PurchaseShipmentEditFormComponent,
  PurchaseShipmentOverviewSummaryComponent,
  QuoteItemFormComponent,
  QuoteItemOverviewPanelComponent,
  ReceiptFormComponent,
  RepeatingPurchaseInvoiceFormComponent,
  RepeatingPurchaseInvoiceOverviewPanelComponent,
  RepeatingSalesInvoiceFormComponent,
  RepeatingSalesInvoiceOverviewPanelComponent,
  RequestForQuoteCreateFormComponent,
  RequestForQuoteListComponent,
  RequestForQuoteOverviewComponent,
  RequestForQuoteEditFormComponent,
  RequestForQuoteOverviewPanelComponent,
  RequestForQuoteOverviewSummaryComponent,
  RequestItemFormComponent,
  RequestItemOverviewPanelComponent,
  SalesInvoiceCreateFormComponent,
  SalesInvoiceListComponent,
  SalesInvoiceOverviewComponent,
  SalesInvoiceEditFormComponent,
  SalesInvoiceOverviewPanelComponent,
  SalesInvoiceOverviewSummaryComponent,
  SalesInvoiceItemFormComponent,
  SalesInvoiceItemOverviewPanelComponent,
  SalesOrderCreateFormComponent,
  SalesOrderListComponent,
  SalesOrderOverviewComponent,
  SalesOrderEditFormComponent,
  SalesOrderOverviewPanelComponent,
  SalesOrderOverviewSummaryComponent,
  SalesOrderItemFormComponent,
  SalesOrderItemOverviewPanelComponent,
  SalesTermFormComponent,
  SalesTermOverviewPanelComponent,
  SerialisedInventoryItemComponent,
  SerialisedItemCreateFormComponent,
  SerialisedItemListComponent,
  SerialisedItemOverviewComponent,
  SerialisedItemEditFormComponent,
  SerialisedItemOverviewPanelComponent,
  SerialisedItemOverviewSummaryComponent,
  SerialisedItemCharacteristicFormComponent,
  SerialisedItemCharacteristicListComponent,
  ShipmentListComponent,
  ShipmentItemFormComponent,
  ShipmentItemOverviewPanelComponent,
  SubContractorRelationshipFormComponent,
  SupplierOfferingFormComponent,
  SupplierOfferingOverviewPanelComponent,
  SupplierRelationshipFormComponent,
  TaskAssignmentLinkComponent,
  TaskAssignmentListComponent,
  TelecommunicationsNumberCreateFormComponent,
  TelecommunicationsNumberFormComponent,
  PartyContactMechanismTelecommunicationsNumberInlineComponent,
  TimeEntryFormComponent,
  TimeEntryOverviewPanelComponent,
  UnifiedGoodCreateFormComponent,
  UnifiedGoodListComponent,
  UnifiedGoodOverviewComponent,
  UnifiedGoodEditFormComponent,
  UnifiedGoodOverviewSummaryComponent,
  UserProfileFormComponent,
  UserProfileLinkComponent,
  WebAddressCreateFormComponent,
  WebAddressFormComponent,
  InlineWebAddressComponent,
  WorkEffortListComponent,
  WorkEffortOverviewPanelComponent,
  WorkEffortAssignmentRateFormComponent,
  WorkEffortAssignmentRateOverviewPanelComponent,
  WorkEffortFixedAssetAssignmentFormComponent,
  WorkEffortFAAssignmentOverviewPanelComponent,
  WorkEffortInventoryAssignmentFormComponent,
  WorkEffortInventoryAssignmentOverviewPanelComponent,
  WorkEffortInvoiceItemAssignmentFormComponent,
  WorkEffortInvoiceItemAssignmentOverviewPanelComponent,
  WorkEffortPartyAssignmentFormComponent,
  WorkEffortPartyAssignmentOverviewPanelComponent,
  WorkEffortPurchaseOrderItemAssignmentFormComponent,
  WorkEffortPOIAssignmentOverviewPanelComponent,
  WorkRequirementCreateFormComponent,
  WorkRequirementListComponent,
  WorkRequirementOverviewComponent,
  WorkRequirementEditFormComponent,
  WorkRequirementOverviewPanelComponent,
  WorkRequirementOverviewSummaryComponent,
  WorkRequirementFulfillmentCreateFormComponent,
  WorkRequirementFulfillmentOverviewPanelComponent,
  WorkTaskCreateFormComponent,
  WorkTaskOverviewComponent,
  WorkTaskEditFormComponent,
  WorkTaskOverviewPanelComponent,
  WorkTaskOverviewSummaryComponent,
} from './index';

@NgModule({
  declarations: [
    // Base Foundation
    AllorsFocusDirective,
    AllorsBarcodeDirective,
    // Base Material Foundation
    AllorsMaterialAssociationAutoCompleteComponent,
    AllorsMaterialCancelComponent,
    AllorsMaterialSaveComponent,
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
    AllorsMaterialRadioGroupComponent,
    AllorsMaterialSelectComponent,
    AllorsMaterialSliderComponent,
    AllorsMaterialSlideToggleComponent,
    AllorsMaterialStaticComponent,
    AllorsMaterialTextareaComponent,
    AllorsMaterialPeriodSelectionToggleComponent,
    AllorsMaterialTableComponent,
    // Base Material Application
    AllorsMaterialErrorDialogComponent,
    AllorsMaterialFilterFieldDialogComponent,
    AllorsMaterialFilterFieldSearchComponent,
    AllorsMaterialFilterComponent,
    AllorsMaterialMediaComponent,
    AllorMediaPreviewComponent,
    AllorsMaterialBarcodeEntryComponent,
    AllorsMaterialSideMenuComponent,
    AllorsMaterialSideNavToggleComponent,
    FactoryFabComponent,
    AllorsMaterialDynamicCreateComponent,
    AllorsMaterialDynamicEditComponent,
    AllorsMaterialDynamicEditDetailPanelComponent,
    AllorsMaterialDynamicEditObjectPanelComponent,
    AllorsMaterialDynamicEditRelationPanelComponent,
    AllorsMaterialDynamicEditRelationshipPanelComponent,
    AllorsMaterialDynamicSummaryPanelComponent,
    AllorsMaterialDynamicViewDetailPanelComponent,
    AllorsMaterialDynamicViewObjectPanelComponent,
    AllorsMaterialDynamicViewRelationPanelComponent,
    AllorsMaterialDynamicViewRelationshipPanelComponent,
    // Intranet Material
    BasepriceFormComponent,
    BrandFormComponent,
    InlineBrandComponent,
    BrandsOverviewComponent,
    CarrierFormComponent,
    CarrierListComponent,
    CatalogueFormComponent,
    CataloguesListComponent,
    CommunicationEventListComponent,
    ContactMechanismInlineComponent,
    CustomerRelationshipFormComponent,
    CustomerShipmentCreateFormComponent,
    CustomerShipmentOverviewComponent,
    CustomerShipmentEditFormComponent,
    CustomerShipmentSummaryPanelComponent,
    DisbursementFormComponent,
    EmailAddressCreateFormComponent,
    EmailAddressFormComponent,
    PartyContactMechanismEmailAddressInlineComponent,
    EmailCommunicationFormComponent,
    EmploymentFormComponent,
    ExchangeRateFormComponent,
    ExchangeRateListComponent,
    FaceToFaceCommunicationFormComponent,
    FacilityInlineComponent,
    GoodListComponent,
    SelectInternalOrganisationComponent,
    InventoryItemTransactionFormComponent,
    LetterCorrespondenceFormComponent,
    InlineModelComponent,
    NonSerialisedInventoryItemFormComponent,
    NonSerialisedInventoryItemComponent,
    NonUnifiedGoodCreateFormComponent,
    NonUnifiedGoodOverviewComponent,
    NonUnifiedGoodEditFormComponent,
    NonUnifiedGoodOverviewSummaryComponent,
    NonUnifiedPartCreateFormComponent,
    NonUnifiedPartListComponent,
    NonUnifiedPartOverviewComponent,
    NonUnifiedPartEditFormComponent,
    NonUnifiedPartOverviewSummaryComponent,
    NotificationLinkComponent,
    NotificationListComponent,
    OrderAdjustmentFormComponent,
    OrderAdjustmentOverviewPanelComponent,
    OrganisationCreateFormComponent,
    OrganisationInlineComponent,
    OrganisationListComponent,
    OrganisationOverviewPageComponent,
    OrganisationEditFormComponent,
    OrganisationOverviewSummaryComponent,
    OrganisationContactRelationshipFormComponent,
    PartListComponent,
    PartCategoryFormComponent,
    PartCategoryListComponent,
    PartyInlineComponent,
    PartyContactmechanismFormComponent,
    PartyContactMechanismOverviewPanelComponent,
    PartyRateFormComponent,
    PartyRateOverviewPanelComponent,
    PartyRelationshipOverviewPanelComponent,
    PaymentOverviewPanelComponent,
    PersonCreateFormComponent,
    PersonInlineComponent,
    PersonListComponent,
    PersonOverviewPageComponent,
    PersonEditFormComponent,
    PersonOverviewSummaryComponent,
    PhoneCommunicationFormComponent,
    PositionTypeFormComponent,
    PositionTypesOverviewComponent,
    PositionTypeRateFormComponent,
    PositionTypeRatesOverviewComponent,
    PostalAddressCreateFormComponent,
    PostalAddressFormComponent,
    PartyContactMechanismPostalAddressInlineComponent,
    PriceComponentOverviewPanelComponent,
    ProductCategoryFormComponent,
    ProductCategoryListComponent,
    ProductIdentificationFormComponent,
    ProductIdentificationsPanelComponent,
    ProductQuoteCreateFormComponent,
    ProductQuoteListComponent,
    ProductQuoteOverviewComponent,
    ProductQuoteEditFormComponent,
    ProductQuoteOverviewPanelComponent,
    ProductQuoteOverviewSummaryComponent,
    ProductQuoteApprovalFormComponent,
    ProductTypeFormComponent,
    ProductTypesOverviewComponent,
    PurchaseInvoiceCreateFormComponent,
    PurchaseInvoiceListComponent,
    PurchaseInvoiceOverviewComponent,
    PurchaseInvoiceEditFormComponent,
    PurchasInvoiceOverviewSummaryComponent,
    PurchaseInvoiceApprovalFormComponent,
    PurchaseInvoiceItemFormComponent,
    PurchaseInvoiceItemOverviewPanelComponent,
    PurchaseOrderCreateFormComponent,
    PurchaseOrderListComponent,
    PurchaseOrderOverviewComponent,
    PurchaseOrderEditFormComponent,
    PurchaseOrderInvoiceOverviewPanelComponent,
    PurchaseOrderOverviewPanelComponent,
    PurchaseOrderOverviewSummaryComponent,
    PurchaseOrderApprovalLevel1FormComponent,
    PurchaseOrderApprovalLevel2FormComponent,
    PurchaseOrderItemFormComponent,
    PurchaseOrderItemOverviewPanelComponent,
    PurchaseReturnCreateFormComponent,
    PurchaseShipmentCreateFormComponent,
    PurchaseShipmentOverviewComponent,
    PurchaseShipmentEditFormComponent,
    PurchaseShipmentOverviewSummaryComponent,
    QuoteItemFormComponent,
    QuoteItemOverviewPanelComponent,
    ReceiptFormComponent,
    RepeatingPurchaseInvoiceFormComponent,
    RepeatingPurchaseInvoiceOverviewPanelComponent,
    RepeatingSalesInvoiceFormComponent,
    RepeatingSalesInvoiceOverviewPanelComponent,
    RequestForQuoteCreateFormComponent,
    RequestForQuoteListComponent,
    RequestForQuoteOverviewComponent,
    RequestForQuoteEditFormComponent,
    RequestForQuoteOverviewPanelComponent,
    RequestForQuoteOverviewSummaryComponent,
    RequestItemFormComponent,
    RequestItemOverviewPanelComponent,
    SalesInvoiceCreateFormComponent,
    SalesInvoiceListComponent,
    SalesInvoiceOverviewComponent,
    SalesInvoiceEditFormComponent,
    SalesInvoiceOverviewPanelComponent,
    SalesInvoiceOverviewSummaryComponent,
    SalesInvoiceItemFormComponent,
    SalesInvoiceItemOverviewPanelComponent,
    SalesOrderCreateFormComponent,
    SalesOrderListComponent,
    SalesOrderOverviewComponent,
    SalesOrderEditFormComponent,
    SalesOrderOverviewPanelComponent,
    SalesOrderOverviewSummaryComponent,
    SalesOrderItemFormComponent,
    SalesOrderItemOverviewPanelComponent,
    SalesTermFormComponent,
    SalesTermOverviewPanelComponent,
    SerialisedInventoryItemComponent,
    SerialisedItemCreateFormComponent,
    SerialisedItemListComponent,
    SerialisedItemOverviewComponent,
    SerialisedItemEditFormComponent,
    SerialisedItemOverviewPanelComponent,
    SerialisedItemOverviewSummaryComponent,
    SerialisedItemCharacteristicFormComponent,
    SerialisedItemCharacteristicListComponent,
    ShipmentListComponent,
    ShipmentItemFormComponent,
    ShipmentItemOverviewPanelComponent,
    SubContractorRelationshipFormComponent,
    SupplierOfferingFormComponent,
    SupplierOfferingOverviewPanelComponent,
    SupplierRelationshipFormComponent,
    TaskAssignmentLinkComponent,
    TaskAssignmentListComponent,
    TelecommunicationsNumberCreateFormComponent,
    TelecommunicationsNumberFormComponent,
    PartyContactMechanismTelecommunicationsNumberInlineComponent,
    TimeEntryFormComponent,
    TimeEntryOverviewPanelComponent,
    UnifiedGoodCreateFormComponent,
    UnifiedGoodListComponent,
    UnifiedGoodOverviewComponent,
    UnifiedGoodEditFormComponent,
    UnifiedGoodOverviewSummaryComponent,
    UserProfileFormComponent,
    UserProfileLinkComponent,
    WebAddressCreateFormComponent,
    WebAddressFormComponent,
    InlineWebAddressComponent,
    WorkEffortListComponent,
    WorkEffortOverviewPanelComponent,
    WorkEffortAssignmentRateFormComponent,
    WorkEffortAssignmentRateOverviewPanelComponent,
    WorkEffortFixedAssetAssignmentFormComponent,
    WorkEffortFAAssignmentOverviewPanelComponent,
    WorkEffortInventoryAssignmentFormComponent,
    WorkEffortInventoryAssignmentOverviewPanelComponent,
    WorkEffortInvoiceItemAssignmentFormComponent,
    WorkEffortInvoiceItemAssignmentOverviewPanelComponent,
    WorkEffortPartyAssignmentFormComponent,
    WorkEffortPartyAssignmentOverviewPanelComponent,
    WorkEffortPurchaseOrderItemAssignmentFormComponent,
    WorkEffortPOIAssignmentOverviewPanelComponent,
    WorkRequirementCreateFormComponent,
    WorkRequirementListComponent,
    WorkRequirementOverviewComponent,
    WorkRequirementEditFormComponent,
    WorkRequirementOverviewPanelComponent,
    WorkRequirementOverviewSummaryComponent,
    WorkRequirementFulfillmentCreateFormComponent,
    WorkRequirementFulfillmentOverviewPanelComponent,
    WorkTaskCreateFormComponent,
    WorkTaskOverviewComponent,
    WorkTaskEditFormComponent,
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
