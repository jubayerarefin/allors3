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
  AllorsMaterialPaginatorComponent,
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
  BrandListPageComponent,
  CarrierFormComponent,
  CarrierListPageComponent,
  CatalogueFormComponent,
  CataloguesListPageComponent,
  CommunicationEventListPageComponent,
  ContactMechanismInlineComponent,
  CustomerRelationshipFormComponent,
  CustomerShipmentCreateFormComponent,
  CustomerShipmentOverviewPageComponent,
  CustomerShipmentEditFormComponent,
  CustomerShipmentSummaryPanelComponent,
  DisbursementFormComponent,
  EmailAddressCreateFormComponent,
  EmailAddressEditFormComponent,
  EmailMessageFormComponent,
  EmailMessageListPageComponent,
  PartyContactMechanismEmailAddressInlineComponent,
  EmailCommunicationFormComponent,
  EmploymentFormComponent,
  ExchangeRateFormComponent,
  ExchangeRateListPageComponent,
  FaceToFaceCommunicationFormComponent,
  FacilityInlineComponent,
  GoodListPageComponent,
  SelectInternalOrganisationComponent,
  InventoryItemTransactionCreateFormComponent,
  LetterCorrespondenceFormComponent,
  InlineModelComponent,
  NonSerialisedInventoryItemFormComponent,
  NonUnifiedGoodCreateFormComponent,
  NonUnifiedGoodOverviewPageComponent,
  NonUnifiedGoodEditFormComponent,
  NonUnifiedGoodSummaryPanelComponent,
  NonUnifiedPartCreateFormComponent,
  NonUnifiedPartListPageComponent,
  NonUnifiedPartOverviewPageComponent,
  NonUnifiedPartEditFormComponent,
  NonUnifiedPartSummaryPanelComponent,
  NotificationLinkComponent,
  NotificationListPageComponent,
  OrderAdjustmentFormComponent,
  OrganisationCreateFormComponent,
  OrganisationInlineComponent,
  OrganisationListPageComponent,
  OrganisationOverviewPageComponent,
  OrganisationEditFormComponent,
  OrganisationSummaryPanelComponent,
  OrganisationContactRelationshipFormComponent,
  PartListPageComponent,
  PartCategoryFormComponent,
  PartCategoryListPageComponent,
  PartyInlineComponent,
  PartyContactmechanismFormComponent,
  PartyRateFormComponent,
  PaymentPanelViewComponent,
  PaymentPanelEditComponent,
  PersonInlineComponent,
  PersonListPageComponent,
  PersonOverviewPageComponent,
  PersonFormComponent,
  PersonSummaryPanelComponent,
  PhoneCommunicationFormComponent,
  PositionTypeFormComponent,
  PositionTypesListPageComponent,
  PositionTypeRateFormComponent,
  PositionTypeRateListPageComponent,
  PostalAddressCreateFormComponent,
  PostalAddressEditFormComponent,
  PartyContactMechanismPostalAddressInlineComponent,
  ProductCategoryFormComponent,
  ProductCategoryListPageComponent,
  ProductIdentificationFormComponent,
  ProductQuoteCreateFormComponent,
  ProductQuoteListPageComponent,
  ProductQuoteOverviewPageComponent,
  ProductQuoteEditFormComponent,
  ProductQuoteSummaryPanelComponent,
  ProductQuoteApprovalFormComponent,
  ProductTypeFormComponent,
  ProductTypesOverviewPageComponent,
  PurchaseInvoiceCreateFormComponent,
  PurchaseInvoiceListPageComponent,
  PurchaseInvoiceOverviewPageComponent,
  PurchaseInvoiceEditFormComponent,
  PurchasInvoiceSummaryPanelComponent,
  PurchaseInvoiceApprovalFormComponent,
  PurchaseInvoiceItemFormComponent,
  PurchaseOrderCreateFormComponent,
  PurchaseOrderInvoicePanelEditComponent,
  PurchaseOrderInvoicePanelViewComponent,
  PurchaseOrderListPageComponent,
  PurchaseOrderOverviewPageComponent,
  PurchaseOrderEditFormComponent,
  PurchaseOrderSummaryPanelComponent,
  PurchaseOrderApprovalLevel1FormComponent,
  PurchaseOrderApprovalLevel2FormComponent,
  PurchaseOrderItemFormComponent,
  PurchaseReturnCreateFormComponent,
  PurchaseReturnEditFormComponent,
  PurchaseReturnOverviewPageComponent,
  PurchaseReturnSummaryPanelComponent,
  PurchaseShipmentCreateFormComponent,
  PurchaseShipmentOverviewPageComponent,
  PurchaseShipmentEditFormComponent,
  PurchaseShipmentSummaryPanelComponent,
  QuoteItemFormComponent,
  ReceiptFormComponent,
  RepeatingPurchaseInvoiceFormComponent,
  RepeatingSalesInvoiceFormComponent,
  RepeatingSalesInvoicePanelEditComponent,
  RepeatingSalesInvoicePanelViewComponent,
  RequestForQuoteCreateFormComponent,
  RequestForQuoteListPageComponent,
  RequestForQuoteOverviewPageComponent,
  RequestForQuoteEditFormComponent,
  RequestForQuoteSummaryPanelComponent,
  RequestItemFormComponent,
  SalesInvoiceCreateFormComponent,
  SalesInvoiceListPageComponent,
  SalesInvoiceOverviewPageComponent,
  SalesInvoiceEditFormComponent,
  SalesInvoiceSummaryPanelComponent,
  SalesInvoiceItemFormComponent,
  SalesOrderCreateFormComponent,
  SalesOrderListPageComponent,
  SalesOrderOverviewPageComponent,
  SalesOrderEditFormComponent,
  SalesOrderSummaryPanelComponent,
  SalesOrderItemFormComponent,
  SalesTermFormComponent,
  SerialisedItemCreateFormComponent,
  SerialisedItemListPageComponent,
  SerialisedItemOverviewPageComponent,
  SerialisedItemEditFormComponent,
  SerialisedItemSummaryPanelComponent,
  SerialisedItemCharacteristicTypeFormComponent,
  SerialisedItemCharacteristicListPageComponent,
  ShipmentListPageComponent,
  ShipmentItemFormComponent,
  SubContractorRelationshipFormComponent,
  SupplierOfferingFormComponent,
  SupplierRelationshipFormComponent,
  TaskAssignmentLinkComponent,
  TaskAssignmentListPageComponent,
  TelecommunicationsNumberCreateFormComponent,
  TelecommunicationsNumberEditFormComponent,
  PartyContactMechanismTelecommunicationsNumberInlineComponent,
  TimeEntryFormComponent,
  UnifiedGoodCreateFormComponent,
  UnifiedGoodListPageComponent,
  UnifiedGoodOverviewPageComponent,
  UnifiedGoodEditFormComponent,
  UnifiedGoodSummaryPanelComponent,
  UserProfileFormComponent,
  UserProfileLinkComponent,
  WebAddressCreateFormComponent,
  WebAddressEditFormComponent,
  InlineWebAddressComponent,
  WorkEffortListPageComponent,
  WorkEffortAssignmentRateFormComponent,
  WorkEffortFixedAssetAssignmentFormComponent,
  WorkEffortInventoryAssignmentFormComponent,
  WorkEffortInvoiceItemAssignmentFormComponent,
  WorkEffortPartyAssignmentFormComponent,
  WorkEffortPurchaseOrderItemAssignmentFormComponent,
  WorkRequirementCreateFormComponent,
  WorkRequirementListPageComponent,
  WorkRequirementOverviewPageComponent,
  WorkRequirementEditFormComponent,
  WorkRequirementSummaryPanelComponent,
  WorkRequirementFulfillmentCreateFormComponent,
  WorkTaskCreateFormComponent,
  WorkTaskOverviewPageComponent,
  WorkTaskEditFormComponent,
  WorkTaskSummaryPanelComponent,
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
    AllorsMaterialPaginatorComponent,
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
    BrandListPageComponent,
    CarrierFormComponent,
    CarrierListPageComponent,
    CatalogueFormComponent,
    CataloguesListPageComponent,
    CommunicationEventListPageComponent,
    ContactMechanismInlineComponent,
    CustomerRelationshipFormComponent,
    CustomerShipmentCreateFormComponent,
    CustomerShipmentOverviewPageComponent,
    CustomerShipmentEditFormComponent,
    CustomerShipmentSummaryPanelComponent,
    DisbursementFormComponent,
    EmailAddressCreateFormComponent,
    EmailAddressEditFormComponent,
    PartyContactMechanismEmailAddressInlineComponent,
    EmailCommunicationFormComponent,
    EmailMessageListPageComponent,
    EmailMessageFormComponent,
    EmploymentFormComponent,
    ExchangeRateFormComponent,
    ExchangeRateListPageComponent,
    FaceToFaceCommunicationFormComponent,
    FacilityInlineComponent,
    GoodListPageComponent,
    SelectInternalOrganisationComponent,
    InventoryItemTransactionCreateFormComponent,
    LetterCorrespondenceFormComponent,
    InlineModelComponent,
    NonSerialisedInventoryItemFormComponent,
    NonUnifiedGoodCreateFormComponent,
    NonUnifiedGoodOverviewPageComponent,
    NonUnifiedGoodEditFormComponent,
    NonUnifiedGoodSummaryPanelComponent,
    NonUnifiedPartCreateFormComponent,
    NonUnifiedPartListPageComponent,
    NonUnifiedPartOverviewPageComponent,
    NonUnifiedPartEditFormComponent,
    NonUnifiedPartSummaryPanelComponent,
    NotificationLinkComponent,
    NotificationListPageComponent,
    OrderAdjustmentFormComponent,
    OrganisationCreateFormComponent,
    OrganisationInlineComponent,
    OrganisationListPageComponent,
    OrganisationOverviewPageComponent,
    OrganisationEditFormComponent,
    OrganisationSummaryPanelComponent,
    OrganisationContactRelationshipFormComponent,
    PartListPageComponent,
    PartCategoryFormComponent,
    PartCategoryListPageComponent,
    PartyInlineComponent,
    PartyContactmechanismFormComponent,
    PartyRateFormComponent,
    PaymentPanelViewComponent,
    PaymentPanelEditComponent,
    PersonInlineComponent,
    PersonListPageComponent,
    PersonOverviewPageComponent,
    PersonFormComponent,
    PersonSummaryPanelComponent,
    PhoneCommunicationFormComponent,
    PositionTypeFormComponent,
    PositionTypesListPageComponent,
    PositionTypeRateFormComponent,
    PositionTypeRateListPageComponent,
    PostalAddressCreateFormComponent,
    PostalAddressEditFormComponent,
    PartyContactMechanismPostalAddressInlineComponent,
    ProductCategoryFormComponent,
    ProductCategoryListPageComponent,
    ProductIdentificationFormComponent,
    ProductQuoteCreateFormComponent,
    ProductQuoteListPageComponent,
    ProductQuoteOverviewPageComponent,
    ProductQuoteEditFormComponent,
    ProductQuoteSummaryPanelComponent,
    ProductQuoteApprovalFormComponent,
    ProductTypeFormComponent,
    ProductTypesOverviewPageComponent,
    PurchaseInvoiceCreateFormComponent,
    PurchaseInvoiceListPageComponent,
    PurchaseInvoiceOverviewPageComponent,
    PurchaseInvoiceEditFormComponent,
    PurchasInvoiceSummaryPanelComponent,
    PurchaseInvoiceApprovalFormComponent,
    PurchaseInvoiceItemFormComponent,
    PurchaseOrderCreateFormComponent,
    PurchaseOrderInvoicePanelEditComponent,
    PurchaseOrderInvoicePanelViewComponent,
    PurchaseOrderListPageComponent,
    PurchaseOrderOverviewPageComponent,
    PurchaseOrderEditFormComponent,
    PurchaseOrderSummaryPanelComponent,
    PurchaseOrderApprovalLevel1FormComponent,
    PurchaseOrderApprovalLevel2FormComponent,
    PurchaseOrderItemFormComponent,
    PurchaseReturnCreateFormComponent,
    PurchaseReturnEditFormComponent,
    PurchaseReturnOverviewPageComponent,
    PurchaseReturnSummaryPanelComponent,
    PurchaseShipmentCreateFormComponent,
    PurchaseShipmentOverviewPageComponent,
    PurchaseShipmentEditFormComponent,
    PurchaseShipmentSummaryPanelComponent,
    QuoteItemFormComponent,
    ReceiptFormComponent,
    RepeatingPurchaseInvoiceFormComponent,
    RepeatingSalesInvoiceFormComponent,
    RepeatingSalesInvoicePanelEditComponent,
    RepeatingSalesInvoicePanelViewComponent,
    RequestForQuoteCreateFormComponent,
    RequestForQuoteListPageComponent,
    RequestForQuoteOverviewPageComponent,
    RequestForQuoteEditFormComponent,
    RequestForQuoteSummaryPanelComponent,
    RequestItemFormComponent,
    SalesInvoiceCreateFormComponent,
    SalesInvoiceListPageComponent,
    SalesInvoiceOverviewPageComponent,
    SalesInvoiceEditFormComponent,
    SalesInvoiceSummaryPanelComponent,
    SalesInvoiceItemFormComponent,
    SalesOrderCreateFormComponent,
    SalesOrderListPageComponent,
    SalesOrderOverviewPageComponent,
    SalesOrderEditFormComponent,
    SalesOrderSummaryPanelComponent,
    SalesOrderItemFormComponent,
    SalesTermFormComponent,
    SerialisedItemCreateFormComponent,
    SerialisedItemListPageComponent,
    SerialisedItemOverviewPageComponent,
    SerialisedItemEditFormComponent,
    SerialisedItemSummaryPanelComponent,
    SerialisedItemCharacteristicTypeFormComponent,
    SerialisedItemCharacteristicListPageComponent,
    ShipmentListPageComponent,
    ShipmentItemFormComponent,
    SubContractorRelationshipFormComponent,
    SupplierOfferingFormComponent,
    SupplierRelationshipFormComponent,
    TaskAssignmentLinkComponent,
    TaskAssignmentListPageComponent,
    TelecommunicationsNumberCreateFormComponent,
    TelecommunicationsNumberEditFormComponent,
    PartyContactMechanismTelecommunicationsNumberInlineComponent,
    TimeEntryFormComponent,
    UnifiedGoodCreateFormComponent,
    UnifiedGoodListPageComponent,
    UnifiedGoodOverviewPageComponent,
    UnifiedGoodEditFormComponent,
    UnifiedGoodSummaryPanelComponent,
    UserProfileFormComponent,
    UserProfileLinkComponent,
    WebAddressCreateFormComponent,
    WebAddressEditFormComponent,
    InlineWebAddressComponent,
    WorkEffortListPageComponent,
    WorkEffortAssignmentRateFormComponent,
    WorkEffortFixedAssetAssignmentFormComponent,
    WorkEffortInventoryAssignmentFormComponent,
    WorkEffortInvoiceItemAssignmentFormComponent,
    WorkEffortPartyAssignmentFormComponent,
    WorkEffortPurchaseOrderItemAssignmentFormComponent,
    WorkRequirementCreateFormComponent,
    WorkRequirementListPageComponent,
    WorkRequirementOverviewPageComponent,
    WorkRequirementEditFormComponent,
    WorkRequirementSummaryPanelComponent,
    WorkRequirementFulfillmentCreateFormComponent,
    WorkTaskCreateFormComponent,
    WorkTaskOverviewPageComponent,
    WorkTaskEditFormComponent,
    WorkTaskSummaryPanelComponent,
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
