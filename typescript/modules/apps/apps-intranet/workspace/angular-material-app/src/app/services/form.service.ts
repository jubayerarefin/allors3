import { M, tags } from '@allors/default/workspace/meta';
import { Composite } from '@allors/system/workspace/meta';
import {
  FormService,
  WorkspaceService,
} from '@allors/base/workspace/angular/foundation';

import { Injectable } from '@angular/core';
import {
  BasepriceFormComponent,
  BrandFormComponent,
  CarrierFormComponent,
  CatalogueFormComponent,
  CustomerRelationshipFormComponent,
  CustomerShipmentCreateFormComponent,
  CustomerShipmentEditFormComponent,
  DisbursementFormComponent,
  EmailAddressCreateFormComponent,
  EmailAddressEditFormComponent,
  EmailCommunicationFormComponent,
  EmailMessageFormComponent,
  EmploymentFormComponent,
  ExchangeRateFormComponent,
  FaceToFaceCommunicationFormComponent,
  InventoryItemTransactionCreateFormComponent,
  LetterCorrespondenceFormComponent,
  ModelFormComponent,
  NonSerialisedInventoryItemFormComponent,
  NonUnifiedGoodCreateFormComponent,
  NonUnifiedGoodEditFormComponent,
  NonUnifiedPartCreateFormComponent,
  NonUnifiedPartEditFormComponent,
  OrderAdjustmentFormComponent,
  OrganisationContactRelationshipFormComponent,
  OrganisationCreateFormComponent,
  OrganisationEditFormComponent,
  PartCategoryFormComponent,
  PartyContactmechanismFormComponent,
  PartyRateFormComponent,
  PersonFormComponent,
  PhoneCommunicationFormComponent,
  PositionTypeFormComponent,
  PositionTypeRateFormComponent,
  PostalAddressCreateFormComponent,
  PostalAddressEditFormComponent,
  ProductCategoryFormComponent,
  ProductIdentificationFormComponent,
  ProductQuoteApprovalFormComponent,
  ProductQuoteCreateFormComponent,
  ProductQuoteEditFormComponent,
  ProductTypeFormComponent,
  PurchaseInvoiceApprovalFormComponent,
  PurchaseInvoiceCreateFormComponent,
  PurchaseInvoiceEditFormComponent,
  PurchaseInvoiceItemFormComponent,
  PurchaseOrderApprovalLevel1FormComponent,
  PurchaseOrderApprovalLevel2FormComponent,
  PurchaseOrderCreateFormComponent,
  PurchaseOrderEditFormComponent,
  PurchaseOrderItemFormComponent,
  PurchaseReturnCreateFormComponent,
  PurchaseReturnEditFormComponent,
  PurchaseShipmentCreateFormComponent,
  PurchaseShipmentEditFormComponent,
  QuoteItemFormComponent,
  ReceiptFormComponent,
  RepeatingPurchaseInvoiceFormComponent,
  RepeatingSalesInvoiceFormComponent,
  RequestForQuoteCreateFormComponent,
  RequestForQuoteEditFormComponent,
  RequestItemFormComponent,
  SalesInvoiceCreateFormComponent,
  SalesInvoiceEditFormComponent,
  SalesInvoiceItemFormComponent,
  SalesOrderCreateFormComponent,
  SalesOrderEditFormComponent,
  SalesOrderItemFormComponent,
  SalesTermFormComponent,
  SerialisedItemCharacteristicTypeFormComponent,
  SerialisedItemCreateFormComponent,
  SerialisedItemEditFormComponent,
  ShipmentItemFormComponent,
  SubContractorRelationshipFormComponent,
  SupplierOfferingFormComponent,
  SupplierRelationshipFormComponent,
  TelecommunicationsNumberCreateFormComponent,
  TelecommunicationsNumberEditFormComponent,
  TimeEntryFormComponent,
  UnifiedGoodCreateFormComponent,
  UnifiedGoodEditFormComponent,
  UserProfileFormComponent,
  WebAddressCreateFormComponent,
  WebAddressEditFormComponent,
  WorkEffortAssignmentRateFormComponent,
  WorkEffortFixedAssetAssignmentFormComponent,
  WorkEffortInventoryAssignmentFormComponent,
  WorkEffortInvoiceItemAssignmentFormComponent,
  WorkEffortPartyAssignmentFormComponent,
  WorkEffortPurchaseOrderItemAssignmentFormComponent,
  WorkRequirementCreateFormComponent,
  WorkRequirementEditFormComponent,
  WorkRequirementFulfillmentCreateFormComponent,
  WorkTaskCreateFormComponent,
  WorkTaskEditFormComponent,
} from '@allors/apps-intranet/workspace/angular-material';

@Injectable()
export class AppFormService implements FormService {
  createFormByObjectType: Map<Composite, unknown>;
  editFormByObjectType: Map<Composite, unknown>;
  formByObjectType: Map<Composite, unknown>;

  constructor(workspaceService: WorkspaceService) {
    const m = workspaceService.workspace.configuration.metaPopulation as M;

    this.createFormByObjectType = new Map<Composite, unknown>([
      [m.CustomerShipment, CustomerShipmentCreateFormComponent],
      [m.EmailAddress, EmailAddressCreateFormComponent],
      [m.InventoryItemTransaction, InventoryItemTransactionCreateFormComponent],
      [m.NonUnifiedGood, NonUnifiedGoodCreateFormComponent],
      [m.NonUnifiedPart, NonUnifiedPartCreateFormComponent],
      [m.Organisation, OrganisationCreateFormComponent],
      [m.PostalAddress, PostalAddressCreateFormComponent],
      [m.ProductQuote, ProductQuoteCreateFormComponent],
      [m.PurchaseInvoice, PurchaseInvoiceCreateFormComponent],
      [m.PurchaseOrder, PurchaseOrderCreateFormComponent],
      [m.PurchaseReturn, PurchaseReturnCreateFormComponent],
      [m.PurchaseShipment, PurchaseShipmentCreateFormComponent],
      [m.RequestForQuote, RequestForQuoteCreateFormComponent],
      [m.SalesInvoice, SalesInvoiceCreateFormComponent],
      [m.SalesOrder, SalesOrderCreateFormComponent],
      [m.SerialisedItem, SerialisedItemCreateFormComponent],
      [m.TelecommunicationsNumber, TelecommunicationsNumberCreateFormComponent],
      [m.UnifiedGood, UnifiedGoodCreateFormComponent],
      [m.WebAddress, WebAddressCreateFormComponent],
      [m.WorkRequirement, WorkRequirementCreateFormComponent],
      [
        m.WorkRequirementFulfillment,
        WorkRequirementFulfillmentCreateFormComponent,
      ],
      [m.WorkTask, WorkTaskCreateFormComponent],
    ]);

    this.editFormByObjectType = new Map<Composite, unknown>([
      [m.CustomerShipment, CustomerShipmentEditFormComponent],
      [m.EmailAddress, EmailAddressEditFormComponent],
      [m.EmailMessage, EmailMessageFormComponent],
      [m.NonUnifiedGood, NonUnifiedGoodEditFormComponent],
      [m.NonUnifiedPart, NonUnifiedPartEditFormComponent],
      [m.Organisation, OrganisationEditFormComponent],
      [m.PostalAddress, PostalAddressEditFormComponent],
      [m.ProductQuote, ProductQuoteEditFormComponent],
      [m.PurchaseInvoice, PurchaseInvoiceEditFormComponent],
      [m.PurchaseOrder, PurchaseOrderEditFormComponent],
      [m.PurchaseReturn, PurchaseReturnEditFormComponent],
      [m.PurchaseShipment, PurchaseShipmentEditFormComponent],
      [m.RequestForQuote, RequestForQuoteEditFormComponent],
      [m.SalesInvoice, SalesInvoiceEditFormComponent],
      [m.SalesOrder, SalesOrderEditFormComponent],
      [m.SerialisedItem, SerialisedItemEditFormComponent],
      [m.TelecommunicationsNumber, TelecommunicationsNumberEditFormComponent],
      [m.UnifiedGood, UnifiedGoodEditFormComponent],
      [m.WebAddress, WebAddressEditFormComponent],
      [m.WorkRequirement, WorkRequirementEditFormComponent],
      // TODO:
      // [
      //   m.WorkRequirementFulfillment,
      //   WorkRequirementFulfillmentEditFormComponent,
      // ],
      [m.WorkTask, WorkTaskEditFormComponent],
    ]);

    this.formByObjectType = new Map<Composite, unknown>([
      [m.BasePrice, BasepriceFormComponent],
      [m.Brand, BrandFormComponent],
      [m.Carrier, CarrierFormComponent],
      [m.Catalogue, CatalogueFormComponent],
      [m.CustomerRelationship, CustomerRelationshipFormComponent],
      [m.Disbursement, DisbursementFormComponent],
      [m.EmailCommunication, EmailCommunicationFormComponent],
      [m.Employment, EmploymentFormComponent],
      [m.ExchangeRate, ExchangeRateFormComponent],
      [m.FaceToFaceCommunication, FaceToFaceCommunicationFormComponent],
      [m.LetterCorrespondence, LetterCorrespondenceFormComponent],
      [m.Model, ModelFormComponent],
      [m.NonSerialisedInventoryItem, NonSerialisedInventoryItemFormComponent],
      [m.OrderAdjustment, OrderAdjustmentFormComponent],
      [
        m.OrganisationContactRelationship,
        OrganisationContactRelationshipFormComponent,
      ],
      [m.PartCategory, PartCategoryFormComponent],
      [m.PartyContactMechanism, PartyContactmechanismFormComponent],
      [m.PartyRate, PartyRateFormComponent],
      [m.Person, PersonFormComponent],
      [m.PhoneCommunication, PhoneCommunicationFormComponent],
      [m.PositionType, PositionTypeFormComponent],
      [m.PositionTypeRate, PositionTypeRateFormComponent],
      [m.ProductCategory, ProductCategoryFormComponent],
      [m.ProductIdentification, ProductIdentificationFormComponent],
      [m.ProductQuoteApproval, ProductQuoteApprovalFormComponent],
      [m.ProductType, ProductTypeFormComponent],
      [m.PurchaseInvoiceApproval, PurchaseInvoiceApprovalFormComponent],
      [m.PurchaseInvoiceItem, PurchaseInvoiceItemFormComponent],
      [m.PurchaseOrderApprovalLevel1, PurchaseOrderApprovalLevel1FormComponent],
      [m.PurchaseOrderApprovalLevel2, PurchaseOrderApprovalLevel2FormComponent],
      [m.PurchaseOrderItem, PurchaseOrderItemFormComponent],
      [m.QuoteItem, QuoteItemFormComponent],
      [m.Receipt, ReceiptFormComponent],
      [m.RepeatingPurchaseInvoice, RepeatingPurchaseInvoiceFormComponent],
      [m.RepeatingSalesInvoice, RepeatingSalesInvoiceFormComponent],
      [m.RequestItem, RequestItemFormComponent],
      [m.SalesInvoiceItem, SalesInvoiceItemFormComponent],
      [m.SalesOrderItem, SalesOrderItemFormComponent],
      [m.SalesTerm, SalesTermFormComponent],
      [
        m.SerialisedItemCharacteristicType,
        SerialisedItemCharacteristicTypeFormComponent,
      ],
      [m.ShipmentItem, ShipmentItemFormComponent],
      [m.SubContractorRelationship, SubContractorRelationshipFormComponent],
      [m.SupplierOffering, SupplierOfferingFormComponent],
      [m.SupplierRelationship, SupplierRelationshipFormComponent],
      [m.TimeEntry, TimeEntryFormComponent],
      [m.UserProfile, UserProfileFormComponent],
      [m.WorkEffortAssignmentRate, WorkEffortAssignmentRateFormComponent],
      [
        m.WorkEffortFixedAssetAssignment,
        WorkEffortFixedAssetAssignmentFormComponent,
      ],
      [
        m.WorkEffortInventoryAssignment,
        WorkEffortInventoryAssignmentFormComponent,
      ],
      [
        m.WorkEffortInvoiceItemAssignment,
        WorkEffortInvoiceItemAssignmentFormComponent,
      ],
      [m.WorkEffortPartyAssignment, WorkEffortPartyAssignmentFormComponent],
      [
        m.WorkEffortPurchaseOrderItemAssignment,
        WorkEffortPurchaseOrderItemAssignmentFormComponent,
      ],
    ]);
  }

  createForm(objectType: Composite) {
    return (
      this.createFormByObjectType.get(objectType) ??
      this.formByObjectType.get(objectType)
    );
  }

  editForm(objectType: Composite) {
    return (
      this.editFormByObjectType.get(objectType) ??
      this.formByObjectType.get(objectType)
    );
  }
}

export const createComponents: any[] = [
  CustomerShipmentCreateFormComponent,
  EmailAddressCreateFormComponent,
  NonUnifiedGoodCreateFormComponent,
  NonUnifiedPartCreateFormComponent,
  OrganisationCreateFormComponent,
  PostalAddressCreateFormComponent,
  ProductQuoteCreateFormComponent,
  PurchaseInvoiceCreateFormComponent,
  PurchaseOrderCreateFormComponent,
  PurchaseReturnCreateFormComponent,
  PurchaseShipmentCreateFormComponent,
  RequestForQuoteCreateFormComponent,
  SalesInvoiceCreateFormComponent,
  SalesOrderCreateFormComponent,
  SerialisedItemCreateFormComponent,
  TelecommunicationsNumberCreateFormComponent,
  UnifiedGoodCreateFormComponent,
  WebAddressCreateFormComponent,
  WorkRequirementCreateFormComponent,
  WorkRequirementFulfillmentCreateFormComponent,
  WorkTaskCreateFormComponent,
];

export const editComponents: any[] = [
  CustomerShipmentEditFormComponent,
  EmailAddressEditFormComponent,
  NonUnifiedGoodEditFormComponent,
  NonUnifiedPartEditFormComponent,
  OrganisationEditFormComponent,
  PostalAddressEditFormComponent,
  ProductQuoteEditFormComponent,
  PurchaseInvoiceEditFormComponent,
  PurchaseOrderEditFormComponent,
  PurchaseReturnEditFormComponent,
  PurchaseShipmentEditFormComponent,
  RequestForQuoteEditFormComponent,
  SalesInvoiceEditFormComponent,
  SalesOrderEditFormComponent,
  SerialisedItemEditFormComponent,
  TelecommunicationsNumberEditFormComponent,
  UnifiedGoodEditFormComponent,
  WebAddressEditFormComponent,
  WorkRequirementEditFormComponent,
  // TODO:
  // WorkRequirementFulfillmentEditFormComponent,
  WorkTaskEditFormComponent,
];

export const components: any[] = [
  BasepriceFormComponent,
  BrandFormComponent,
  CarrierFormComponent,
  CatalogueFormComponent,
  CustomerRelationshipFormComponent,
  DisbursementFormComponent,
  EmailCommunicationFormComponent,
  EmailMessageFormComponent,
  EmploymentFormComponent,
  ExchangeRateFormComponent,
  FaceToFaceCommunicationFormComponent,
  InventoryItemTransactionCreateFormComponent,
  LetterCorrespondenceFormComponent,
  ModelFormComponent,
  NonSerialisedInventoryItemFormComponent,
  OrderAdjustmentFormComponent,
  OrganisationContactRelationshipFormComponent,
  PartCategoryFormComponent,
  PartyContactmechanismFormComponent,
  PartyRateFormComponent,
  PersonFormComponent,
  PhoneCommunicationFormComponent,
  PositionTypeFormComponent,
  PositionTypeRateFormComponent,
  ProductCategoryFormComponent,
  ProductIdentificationFormComponent,
  ProductQuoteApprovalFormComponent,
  ProductTypeFormComponent,
  PurchaseInvoiceApprovalFormComponent,
  PurchaseInvoiceItemFormComponent,
  PurchaseOrderApprovalLevel1FormComponent,
  PurchaseOrderApprovalLevel2FormComponent,
  PurchaseOrderItemFormComponent,
  QuoteItemFormComponent,
  ReceiptFormComponent,
  RepeatingPurchaseInvoiceFormComponent,
  RepeatingSalesInvoiceFormComponent,
  RequestItemFormComponent,
  SalesInvoiceItemFormComponent,
  SalesOrderItemFormComponent,
  SalesTermFormComponent,
  SerialisedItemCharacteristicTypeFormComponent,
  ShipmentItemFormComponent,
  SubContractorRelationshipFormComponent,
  SupplierOfferingFormComponent,
  SupplierRelationshipFormComponent,
  TimeEntryFormComponent,
  UserProfileFormComponent,
  WorkEffortAssignmentRateFormComponent,
  WorkEffortFixedAssetAssignmentFormComponent,
  WorkEffortInventoryAssignmentFormComponent,
  WorkEffortInvoiceItemAssignmentFormComponent,
  WorkEffortPartyAssignmentFormComponent,
  WorkEffortPurchaseOrderItemAssignmentFormComponent,
];
