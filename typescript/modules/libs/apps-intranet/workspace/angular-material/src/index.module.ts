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
  AllorsMaterialDynamicEditExtentPanelComponent,
  AllorsMaterialDynamicSummaryPanelComponent,
  AllorsMaterialDynamicViewDetailPanelComponent,
  AllorsMaterialDynamicViewExtentPanelComponent,
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
  NonUnifiedGoodCreateFormComponent,
  NonUnifiedGoodOverviewComponent,
  NonUnifiedGoodEditFormComponent,
  NonUnifiedGoodSummaryPanelComponent,
  NonUnifiedPartCreateFormComponent,
  NonUnifiedPartListComponent,
  NonUnifiedPartOverviewComponent,
  NonUnifiedPartEditFormComponent,
  NonUnifiedPartSummaryPanelComponent,
  NotificationLinkComponent,
  NotificationListComponent,
  OrderAdjustmentFormComponent,
  OrganisationCreateFormComponent,
  OrganisationInlineComponent,
  OrganisationListComponent,
  OrganisationOverviewPageComponent,
  OrganisationEditFormComponent,
  OrganisationSummaryPanelComponent,
  OrganisationContactRelationshipFormComponent,
  PartListComponent,
  PartCategoryFormComponent,
  PartCategoryListComponent,
  PartyInlineComponent,
  PartyContactmechanismFormComponent,
  PartyRateFormComponent,
  PersonCreateFormComponent,
  PersonInlineComponent,
  PersonListComponent,
  PersonOverviewPageComponent,
  PersonEditFormComponent,
  PersonSummaryPanelComponent,
  PhoneCommunicationFormComponent,
  PositionTypeFormComponent,
  PositionTypesOverviewComponent,
  PositionTypeRateFormComponent,
  PositionTypeRatesOverviewComponent,
  PostalAddressCreateFormComponent,
  PostalAddressFormComponent,
  PartyContactMechanismPostalAddressInlineComponent,
  ProductCategoryFormComponent,
  ProductCategoryListComponent,
  ProductIdentificationFormComponent,
  ProductQuoteCreateFormComponent,
  ProductQuoteListComponent,
  ProductQuoteOverviewComponent,
  ProductQuoteEditFormComponent,
  ProductQuoteSummaryPanelComponent,
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
  PurchaseOrderCreateFormComponent,
  PurchaseOrderListComponent,
  PurchaseOrderOverviewComponent,
  PurchaseOrderEditFormComponent,
  PurchaseOrderOverviewSummaryComponent,
  PurchaseOrderApprovalLevel1FormComponent,
  PurchaseOrderApprovalLevel2FormComponent,
  PurchaseOrderItemFormComponent,
  PurchaseReturnCreateFormComponent,
  PurchaseShipmentCreateFormComponent,
  PurchaseShipmentOverviewComponent,
  PurchaseShipmentEditFormComponent,
  PurchaseShipmentOverviewSummaryComponent,
  QuoteItemFormComponent,
  ReceiptFormComponent,
  RepeatingPurchaseInvoiceFormComponent,
  RepeatingSalesInvoiceFormComponent,
  RequestForQuoteCreateFormComponent,
  RequestForQuoteListComponent,
  RequestForQuoteOverviewComponent,
  RequestForQuoteEditFormComponent,
  RequestForQuoteOverviewSummaryComponent,
  RequestItemFormComponent,
  SalesInvoiceCreateFormComponent,
  SalesInvoiceListComponent,
  SalesInvoiceOverviewComponent,
  SalesInvoiceEditFormComponent,
  SalesInvoiceOverviewSummaryComponent,
  SalesInvoiceItemFormComponent,
  SalesOrderCreateFormComponent,
  SalesOrderListComponent,
  SalesOrderOverviewComponent,
  SalesOrderEditFormComponent,
  SalesOrderOverviewSummaryComponent,
  SalesOrderItemFormComponent,
  SalesTermFormComponent,
  SerialisedItemCreateFormComponent,
  SerialisedItemListComponent,
  SerialisedItemOverviewComponent,
  SerialisedItemEditFormComponent,
  SerialisedItemOverviewSummaryComponent,
  SerialisedItemCharacteristicFormComponent,
  SerialisedItemCharacteristicListComponent,
  ShipmentListComponent,
  ShipmentItemFormComponent,
  SubContractorRelationshipFormComponent,
  SupplierOfferingFormComponent,
  SupplierRelationshipFormComponent,
  TaskAssignmentLinkComponent,
  TaskAssignmentListComponent,
  TelecommunicationsNumberCreateFormComponent,
  TelecommunicationsNumberFormComponent,
  PartyContactMechanismTelecommunicationsNumberInlineComponent,
  TimeEntryFormComponent,
  UnifiedGoodCreateFormComponent,
  UnifiedGoodListComponent,
  UnifiedGoodOverviewComponent,
  UnifiedGoodEditFormComponent,
  UnifiedGoodOverviewSummaryComponent,
  UserProfileFormComponent,
  UserProfileLinkComponent,
  WebAddressCreateFormComponent,
  WebAddressEditFormComponent,
  InlineWebAddressComponent,
  WorkEffortListComponent,
  WorkEffortAssignmentRateFormComponent,
  WorkEffortFixedAssetAssignmentFormComponent,
  WorkEffortInventoryAssignmentFormComponent,
  WorkEffortInvoiceItemAssignmentFormComponent,
  WorkEffortPartyAssignmentFormComponent,
  WorkEffortPurchaseOrderItemAssignmentFormComponent,
  WorkRequirementCreateFormComponent,
  WorkRequirementListComponent,
  WorkRequirementOverviewComponent,
  WorkRequirementEditFormComponent,
  WorkRequirementOverviewSummaryComponent,
  WorkRequirementFulfillmentCreateFormComponent,
  WorkTaskCreateFormComponent,
  WorkTaskOverviewComponent,
  WorkTaskEditFormComponent,
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
    AllorsMaterialDynamicEditExtentPanelComponent,
    AllorsMaterialDynamicSummaryPanelComponent,
    AllorsMaterialDynamicViewDetailPanelComponent,
    AllorsMaterialDynamicViewExtentPanelComponent,
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
    NonUnifiedGoodCreateFormComponent,
    NonUnifiedGoodOverviewComponent,
    NonUnifiedGoodEditFormComponent,
    NonUnifiedGoodSummaryPanelComponent,
    NonUnifiedPartCreateFormComponent,
    NonUnifiedPartListComponent,
    NonUnifiedPartOverviewComponent,
    NonUnifiedPartEditFormComponent,
    NonUnifiedPartSummaryPanelComponent,
    NotificationLinkComponent,
    NotificationListComponent,
    OrderAdjustmentFormComponent,
    OrganisationCreateFormComponent,
    OrganisationInlineComponent,
    OrganisationListComponent,
    OrganisationOverviewPageComponent,
    OrganisationEditFormComponent,
    OrganisationSummaryPanelComponent,
    OrganisationContactRelationshipFormComponent,
    PartListComponent,
    PartCategoryFormComponent,
    PartCategoryListComponent,
    PartyInlineComponent,
    PartyContactmechanismFormComponent,
    PartyRateFormComponent,
    PersonCreateFormComponent,
    PersonInlineComponent,
    PersonListComponent,
    PersonOverviewPageComponent,
    PersonEditFormComponent,
    PersonSummaryPanelComponent,
    PhoneCommunicationFormComponent,
    PositionTypeFormComponent,
    PositionTypesOverviewComponent,
    PositionTypeRateFormComponent,
    PositionTypeRatesOverviewComponent,
    PostalAddressCreateFormComponent,
    PostalAddressFormComponent,
    PartyContactMechanismPostalAddressInlineComponent,
    ProductCategoryFormComponent,
    ProductCategoryListComponent,
    ProductIdentificationFormComponent,
    ProductQuoteCreateFormComponent,
    ProductQuoteListComponent,
    ProductQuoteOverviewComponent,
    ProductQuoteEditFormComponent,
    ProductQuoteSummaryPanelComponent,
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
    PurchaseOrderCreateFormComponent,
    PurchaseOrderListComponent,
    PurchaseOrderOverviewComponent,
    PurchaseOrderEditFormComponent,
    PurchaseOrderOverviewSummaryComponent,
    PurchaseOrderApprovalLevel1FormComponent,
    PurchaseOrderApprovalLevel2FormComponent,
    PurchaseOrderItemFormComponent,
    PurchaseReturnCreateFormComponent,
    PurchaseShipmentCreateFormComponent,
    PurchaseShipmentOverviewComponent,
    PurchaseShipmentEditFormComponent,
    PurchaseShipmentOverviewSummaryComponent,
    QuoteItemFormComponent,
    ReceiptFormComponent,
    RepeatingPurchaseInvoiceFormComponent,
    RepeatingSalesInvoiceFormComponent,
    RequestForQuoteCreateFormComponent,
    RequestForQuoteListComponent,
    RequestForQuoteOverviewComponent,
    RequestForQuoteEditFormComponent,
    RequestForQuoteOverviewSummaryComponent,
    RequestItemFormComponent,
    SalesInvoiceCreateFormComponent,
    SalesInvoiceListComponent,
    SalesInvoiceOverviewComponent,
    SalesInvoiceEditFormComponent,
    SalesInvoiceOverviewSummaryComponent,
    SalesInvoiceItemFormComponent,
    SalesOrderCreateFormComponent,
    SalesOrderListComponent,
    SalesOrderOverviewComponent,
    SalesOrderEditFormComponent,
    SalesOrderOverviewSummaryComponent,
    SalesOrderItemFormComponent,
    SalesTermFormComponent,
    SerialisedItemCreateFormComponent,
    SerialisedItemListComponent,
    SerialisedItemOverviewComponent,
    SerialisedItemEditFormComponent,
    SerialisedItemOverviewSummaryComponent,
    SerialisedItemCharacteristicFormComponent,
    SerialisedItemCharacteristicListComponent,
    ShipmentListComponent,
    ShipmentItemFormComponent,
    SubContractorRelationshipFormComponent,
    SupplierOfferingFormComponent,
    SupplierRelationshipFormComponent,
    TaskAssignmentLinkComponent,
    TaskAssignmentListComponent,
    TelecommunicationsNumberCreateFormComponent,
    TelecommunicationsNumberFormComponent,
    PartyContactMechanismTelecommunicationsNumberInlineComponent,
    TimeEntryFormComponent,
    UnifiedGoodCreateFormComponent,
    UnifiedGoodListComponent,
    UnifiedGoodOverviewComponent,
    UnifiedGoodEditFormComponent,
    UnifiedGoodOverviewSummaryComponent,
    UserProfileFormComponent,
    UserProfileLinkComponent,
    WebAddressCreateFormComponent,
    WebAddressEditFormComponent,
    InlineWebAddressComponent,
    WorkEffortListComponent,
    WorkEffortAssignmentRateFormComponent,
    WorkEffortFixedAssetAssignmentFormComponent,
    WorkEffortInventoryAssignmentFormComponent,
    WorkEffortInvoiceItemAssignmentFormComponent,
    WorkEffortPartyAssignmentFormComponent,
    WorkEffortPurchaseOrderItemAssignmentFormComponent,
    WorkRequirementCreateFormComponent,
    WorkRequirementListComponent,
    WorkRequirementOverviewComponent,
    WorkRequirementEditFormComponent,
    WorkRequirementOverviewSummaryComponent,
    WorkRequirementFulfillmentCreateFormComponent,
    WorkTaskCreateFormComponent,
    WorkTaskOverviewComponent,
    WorkTaskEditFormComponent,
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
