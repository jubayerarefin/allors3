// <copyright file="ObjectsBase.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using Derivations.Rules;
    using Meta;

    public static partial class Rules
    {
        public static Rule[] Create(MetaPopulation m) =>
            new Rule[]
            {
                // Core
                new UserNormalizedUserNameRule(m),
                new UserNormalizedUserEmailRule(m),
                new UserInUserPasswordRule(m),
                new GrantEffectiveUsersRule(m),
                new GrantEffectivePermissionsRule(m),

                // Base
                new MediaRule(m),
                new TransitionalDeniedPermissionRule(m),
                new NotificationListRule(m),

                // Apps
                new AccountingPeriodRule(m),
                new AgreementProductApplicabilityRule(m),
                new AgreementTermRule(m),
                new AutomatedAgentDisplayNameRule(m),
                new AutomatedAgentRule(m),
                new BankAccountIbanRule(m),
                new BankAccountRule(m),
                new BankRule(m),
                new BasePriceOrderQuantityBreakRule(m),
                new BasePriceOrderValueRule(m),
                new BasePriceProductFeatureRule(m),
                new BasePriceProductRule(m),
                new BudgetDeniedPermissionRule(m),
                new CarrierSearchStringRule(m),
                new CaseDeniedPermissionRule(m),
                new CashRule(m),
                new CatalogueImageRule(m),
                new CatalogueLocalisedDescriptionsRule(m),
                new CatalogueLocalisedNamesRule(m),
                new CatalogueSearchStringRule(m),
                new CommunicationEventDeniedPermissionRule(m),
                new CommunicationEventRule(m),
                new CommunicationTaskParticipantsRule(m),
                new CommunicationTaskRule(m),
                new CountryRule(m),
                new CountryVatRegimesRule(m),
                new CustomerRelationshipRule(m),
                new CustomerReturnDeniedPermissionRule(m),
                new CustomerReturnExistShipmentNumberRule(m),
                new CustomerReturnExistShipToAddressRule(m),
                new CustomerReturnRule(m),
                new CustomerReturnSearchStringRule(m),
                new CustomerShipmentDeniedPermissionRule(m),
                new CustomerShipmentExistShipmentNumberRule(m),
                new CustomerShipmentExistShipToAddressRule(m),
                new CustomerShipmentInvoiceRule(m),
                new CustomerShipmentRule(m),
                new CustomerShipmentSearchStringRule(m),
                new CustomerShipmentShipmentValueRule(m),
                new CustomerShipmentShipRule(m),
                new CustomerShipmentStateRule(m),
                new DeliverableBasedServiceDisplayNameRule(m),
                new DeliverableBasedServiceRule(m),
                new DeliverableBasedServiceSearchStringRule(m),
                new DiscountComponentRule(m),
                new DropShipmentDeniedPermissionRule(m),
                new DropShipmentExistShipmentNumberRule(m),
                new DropShipmentRule(m),
                new DropShipmentSearchStringRule(m),
                new DropShipmentShipToAddressRule(m),
                new EmailAddressDisplayNameRule(m),
                new EmailCommunicationRule(m),
                new EmailCommunicationSearchStringRule(m),
                new EmploymentRule(m),
                new EngagementBillToPartyRule(m),
                new EngagementPlacingPartyRule(m),
                new EngineeringChangeDeniedPermissionRule(m),
                new EquipmentSearchStringRule(m),
                new ExchangeRateRule(m),
                new ExchangeRateSearchStringRule(m),
                new FaceToFaceCommunicationRule(m),
                new FaceToFaceCommunicationSearchStringRule(m),
                new FaxCommunicationRule(m),
                new FaxCommunicationSearchStringRule(m),
                new GeneralLedgerAccountCostCenterAllowedRule(m),
                new GeneralLedgerAccountCostCenterRequiredRule(m),
                new GeneralLedgerAccountCostUnitAllowedRule(m),
                new GeneralLedgerAccountCostUnitRequiredRule(m),
                new GeneralLedgerAccountRule(m),
                new GoodLocalisedDescriptionRule(m),
                new GoodLocalisedNamesRule(m),
                new GoodProductIdentificationsRule(m),
                new InternalOrganisationCustomerReturnSequenceRule(m),
                new InternalOrganisationExistDefaultCollectionMethodRule(m),
                new InternalOrganisationInvoiceSequenceRule(m),
                new InternalOrganisationPurchaseShipmentSequenceRule(m),
                new InternalOrganisationQuoteSequenceRule(m),
                new InternalOrganisationRequestSequenceRule(m),
                new InternalOrganisationRequirementSequenceRule(m),
                new InternalOrganisationRule(m),
                new InternalOrganisationWorkEffortSequenceRule(m),
                new InventoryItemRule(m),
                new InventoryItemTransactionRule(m),
                new InvoiceItemTotalIncVatRule(m),
                new JournalContraAccountRule(m),
                new JournalTypeRule(m),
                new LetterCorrespondenceRule(m),
                new LetterCorrespondenceSearchStringRule(m),
                new NonSerialisedInventoryItemDeniedPermissionRule(m),
                new NonSerialisedInventoryItemQuantitiesRule(m),
                new NonSerialisedInventoryItemRule(m),
                new NonSerialisedInventoryItemSearchStringRule(m),
                new NonUnifiedGoodDeniedPermissionRule(m),
                new NonUnifiedGoodDisplayNameRule(m),
                new NonUnifiedGoodProductIdentificationsRule(m),
                new NonUnifiedGoodSearchStringRule(m),
                new NonUnifiedGoodVariantsRule(m),
                new NonUnifiedPartDeniedPermissionRule(m),
                new NonUnifiedPartDisplayNameRule(m),
                new NonUnifiedPartProductIdentificationsRule(m),
                new NonUnifiedPartRule(m),
                new NonUnifiedPartSearchStringRule(m),
                new OrderShipmentRule(m),
                new OrganisationContactRelationshipDateRule(m),
                new OrganisationContactRelationshipPartyRule(m),
                new OrganisationContactUserGroupRule(m),
                new OrganisationDeniedPermissionRule(m),
                new OrganisationDisplayNameRule(m),
                new OrganisationRollupRule(m),
                new OrganisationRule(m),
                new OrganisationSearchStringRule(m),
                new OrganisationSyncContactRelationshipsRule(m),
                new OwnBankAccountRule(m),
                new OwnCreditCardInternalOrganisationPaymentMethodsRule(m),
                new OwnCreditCardRule(m),
                new PackagingContentRule(m),
                new PartBrandNameRule(m),
                new PartCategoryDisplayNameRule(m),
                new PartCategoryImageRule(m),
                new PartCategoryLocalisedDescriptionsRule(m),
                new PartCategoryNameRule(m),
                new PartCategoryRule(m),
                new PartCategorySearchStringRule(m),
                new PartCurrentSupplierOfferingsNameRule(m),
                new PartDefaultFacilityNameRule(m),
                new PartInventoryItemKindNameRule(m),
                new PartInventoryItemRule(m),
                new PartManufacturedByDisplayNameRule(m),
                new PartModelNameRule(m),
                new PartPartCategoriesDisplayNameRule(m),
                new PartProductTypeNameRule(m),
                new PartQuantitiesRule(m),
                new PartRule(m),
                new PartSpecificationDeniedPermissionRule(m),
                new PartSuppliedByDisplayNameRule(m),
                new PartSuppliedByRule(m),
                new PartSyncInventoryItemsRule(m),
                new PartyContactMechanismRule(m),
                new PartyFinancialRelationshipAmountDueRule(m),
                new PartyFinancialRelationshipOpenOrderAmountRule(m),
                new PartyRule(m),
                new PayHistoryRule(m),
                new PaymentApplicationRule(m),
                new PaymentApplicationValidationRule(m),
                new PaymentRule(m),
                new PayrollPreferenceRule(m),
                new PersonDeniedPermissionRule(m),
                new PersonDisplayNameRule(m),
                new PersonRule(m),
                new PersonSearchStringRule(m),
                new PersonSalutationRule(m),
                new PersonTimeSheetWorkerRule(m),
                new PhoneCommunicationRule(m),
                new PhoneCommunicationSearchStringRule(m),
                new PickListDeniedPermissionRule(m),
                new PickListItemQuantityPickedRule(m),
                new PickListItemRule(m),
                new PickListRule(m),
                new PickListStateRule(m),
                new PositionTypeRateSearchStringRule(m),
                new PositionTypeSearchStringRule(m),
                new PostalAddressDisplayNameRule(m),
                new PostalAddressRule(m),
                new PriceComponentDerivePricedByRule(m),
                new PriceComponentRule(m),
                new ProductCategoryDisplayNameRule(m),
                new ProductCategoryImageRule(m),
                new ProductCategoryLocalisedDescriptionRule(m),
                new ProductCategoryLocalisedNameRule(m),
                new ProductCategoryRule(m),
                new ProductCategorySearchStringRule(m),
                new ProductProductCategoriesDisplayNameRule(m),
                new ProductQuoteApprovalParticipantsRule(m),
                new ProductQuoteApprovalRule(m),
                new ProductQuoteAwaitingApprovalRule(m),
                new ProductQuoteDeniedPermissionRule(m),
                new ProductQuoteItemByProductRule(m),
                new ProductQuotePrintRule(m),
                new ProductQuoteRule(m),
                new ProductQuoteSearchStringRule(m),
                new ProfessionalServicesRelationshipRule(m),
                new PropertySearchStringRule(m),
                new ProposalDeniedPermissionRule(m),
                new ProposalRule(m),
                new ProposalSearchStringRule(m),
                new PurchaseInvoiceAmountPaidRule(m),
                new PurchaseInvoiceApprovalParticipantsRule(m),
                new PurchaseInvoiceApprovalRule(m),
                new PurchaseInvoiceAwaitingApprovalRule(m),
                new PurchaseInvoiceBilledRule(m),
                new PurchaseInvoiceCreatedCurrencyRule(m),
                new PurchaseInvoiceCreatedInvoiceItemRule(m),
                new PurchaseInvoiceCreatedRule(m),
                new PurchaseInvoiceDeniedPermissionRule(m),
                new PurchaseInvoiceItemDeniedPermissionRule(m),
                new PurchaseInvoiceItemRule(m),
                new PurchaseInvoiceItemStateRule(m),
                new PurchaseInvoicePriceRule(m),
                new PurchaseInvoicePrintRule(m),
                new PurchaseInvoiceRule(m),
                new PurchaseInvoiceSerialisedItemRule(m),
                new PurchaseInvoiceStateRule(m),
                new PurchaseInvoiceSearchStringRule(m),
                new PurchaseOrderApprovalLevel1ParticipantsRule(m),
                new PurchaseOrderApprovalLevel1Rule(m),
                new PurchaseOrderApprovalLevel1Rule(m),
                new PurchaseOrderApprovalLevel2ParticipantsRule(m),
                new PurchaseOrderApprovalLevel2Rule(m),
                new PurchaseOrderApprovalLevel2Rule(m),
                new PurchaseOrderAwaitingApprovalLevel1Rule(m),
                new PurchaseOrderAwaitingApprovalLevel2Rule(m),
                new PurchaseOrderCreatedBillToContactMechanismRule(m),
                new PurchaseOrderCreatedCurrencyRule(m),
                new PurchaseOrderCreatedIrpfRegimeRule(m),
                new PurchaseOrderCreatedLocaleRule(m),
                new PurchaseOrderCreatedShipToAddressRule(m),
                new PurchaseOrderCreatedTakenViaContactMechanismRule(m),
                new PurchaseOrderCreatedVatRegimeRule(m),
                new PurchaseOrderDeniedPermissionRule(m),
                new PurchaseOrderDisplayNameRule(m),
                new PurchaseOrderItemBillingsWhereOrderItemRule(m),
                new PurchaseOrderItemByProductRule(m),
                new PurchaseOrderItemCreatedDeliveryDateRule(m),
                new PurchaseOrderItemCreatedIrpfRateRule(m),
                new PurchaseOrderItemCreatedVatRegimeRule(m),
                new PurchaseOrderItemDeniedPermissionRule(m),
                new PurchaseOrderItemDisplayNameRule(m),
                new PurchaseOrderItemIsReceivableRule(m),
                new PurchaseOrderItemRule(m),
                new PurchaseOrderItemStateRule(m),
                new PurchaseOrderPriceRule(m),
                new PurchaseOrderPriceRule(m),
                new PurchaseOrderPrintRule(m),
                new PurchaseOrderRule(m),
                new PurchaseOrderSearchStringRule(m),
                new PurchaseOrderStateRule(m),
                new PurchaseOrderStateRule(m),
                new PurchaseReturnDeniedPermissionRule(m),
                new PurchaseReturnExistShipmentNumberRule(m),
                new PurchaseReturnExistShipToAddressRule(m),
                new PurchaseReturnRule(m),
                new PurchaseReturnSearchStringRule(m),
                new PurchaseShipmentDeniedPermissionRule(m),
                new PurchaseShipmentSearchStringRule(m),
                new PurchaseShipmentShipFromAddressRule(m),
                new PurchaseShipmentShipToPartyRule(m),
                new PurchaseShipmentStateRule(m),
                new QuoteCreatedCurrencyRule(m),
                new QuoteCreatedIrpfRegimeRule(m),
                new QuoteCreatedLocalRule(m),
                new QuoteCreatedVatRegimeRule(m),
                new QuoteItemCreatedIrpfRegimeRule(m),
                new QuoteItemCreatedVatRegimeRule(m),
                new QuoteItemDeniedPermissionRule(m),
                new QuoteItemDetailsRule(m),
                new QuoteItemPriceRule(m),
                new QuoteItemRule(m),
                new QuotePriceRule(m),
                new QuoteQuoteItemsRule(m),
                new QuoteRule(m),
                new RepeatingPurchaseInvoiceRule(m),
                new RepeatingSalesInvoiceRule(m),
                new RequestAnonymousRule(m),
                new RequestCurrencyRule(m),
                new RequestForInformationDeniedPermissionRule(m),
                new RequestForInformationRequestItemsRule(m),
                new RequestForInformationRequestItemsRule(m),
                new RequestForInformationRule(m),
                new RequestForInformationSearchStringRule(m),
                new RequestForProposalDeniedPermissionRule(m),
                new RequestForProposalDeriveRequestItemsRule(m),
                new RequestForProposalRule(m),
                new RequestForProposalSearchStringRule(m),
                new RequestForQuoteDeniedPermissionRule(m),
                new RequestForQuoteRequestItemsRule(m),
                new RequestForQuoteRule(m),
                new RequestForQuoteSearchStringRule(m),
                new RequestItemDeniedPermissionRule(m),
                new RequestItemRule(m),
                new RequestItemValidationRule(m),
                new RequestRule(m),
                new RequirementOriginatorNameRule(m),
                new RequirementRequirementPriorityNameRule(m),
                new RequirementRequirementStateNameRule(m),
                new RequirementRequirementTypeNameRule(m),
                new RequirementServicedByNameRule(m),
                new SalesInvoiceBilledFromValidationRule(m),
                new SalesInvoiceBillingOrderItemBillingRule(m),
                new SalesInvoiceBillingShipmentItemBillingRule(m),
                new SalesInvoiceBillingtimeEntryBillingRule(m),
                new SalesInvoiceBillingWorkEffortBillingRule(m),
                new SalesInvoiceCustomerRule(m),
                new SalesInvoiceDeniedPermissionRule(m),
                new SalesInvoiceDueDateRule(m),
                new SalesInvoiceInvoiceNumberRule(m),
                new SalesInvoiceIsRepeatingInvoiceRule(m),
                new SalesInvoiceItemAssignedIrpfRegimeRule(m),
                new SalesInvoiceItemAssignedVatRegimeRule(m),
                new SalesInvoiceItemDeniedPermissionRule(m),
                new SalesInvoiceItemInvoiceItemTypeRule(m),
                new SalesInvoiceItemPaymentApplicationAmountAppliedRule(m),
                new SalesInvoiceItemRule(m),
                new SalesInvoiceItemSalesInvoiceRule(m),
                new SalesInvoiceItemSubTotalItemRule(m),
                new SalesInvoicePreviousBillToCustomerRule(m),
                new SalesInvoicePriceRule(m),
                new SalesInvoicePrintRule(m),
                new SalesInvoiceReadyForPostingDerivedBilledFromContactMechanismRule(m),
                new SalesInvoiceReadyForPostingDerivedBillToContactMechanismRule(m),
                new SalesInvoiceReadyForPostingDerivedBillToEndCustomerContactMechanismRule(m),
                new SalesInvoiceReadyForPostingDerivedCurrencyRule(m),
                new SalesInvoiceReadyForPostingDerivedLocaleRule(m),
                new SalesInvoiceReadyForPostingDerivedShipToAddressRule(m),
                new SalesInvoiceReadyForPostingDerivedShipToEndCustomerAddressRule(m),
                new SalesInvoiceReadyForPostingRule(m),
                new SalesInvoiceRule(m),
                new SalesInvoiceStateRule(m),
                new SalesInvoiceStoreRule(m),
                new SalesInvoiceSearchStringRule(m),
                new SalesOrderCanInvoiceRule(m),
                new SalesOrderCanShipRule(m),
                new SalesOrderCustomerRule(m),
                new SalesOrderDeniedPermissionRule(m),
                new SalesOrderItemByProductRule(m),
                new SalesOrderItemDeniedPermissionRule(m),
                new SalesOrderItemInventoryAssignmentRule(m),
                new SalesOrderItemInventoryItemRule(m),
                new SalesOrderItemInvoiceItemTypeRule(m),
                new SalesOrderItemPriceRule(m),
                new SalesOrderItemProvisionalDeliveryDateRule(m),
                new SalesOrderItemProvisionalIrpfRegimeRule(m),
                new SalesOrderItemProvisionalShipFromAddressRule(m),
                new SalesOrderItemProvisionalShipToAddressRule(m),
                new SalesOrderItemProvisionalShipToPartyRule(m),
                new SalesOrderItemProvisionalVatRegimeRule(m),
                new SalesOrderItemQuantitiesRule(m),
                new SalesOrderItemRule(m),
                new SalesOrderItemSalesOrderItemsByProductRule(m),
                new SalesOrderItemShipmentRule(m),
                new SalesOrderItemStateRule(m),
                new SalesOrderItemValidationRule(m),
                new SalesOrderOrderNumberRule(m),
                new SalesOrderPriceRule(m),
                new SalesOrderPrintRule(m),
                new SalesOrderProvisionalBillToContactMechanismRule(m),
                new SalesOrderProvisionalBillToEndCustomerContactMechanismRule(m),
                new SalesOrderProvisionalCurrencyRule(m),
                new SalesOrderProvisionalIrpfRegimeRule(m),
                new SalesOrderProvisionalLocaleRule(m),
                new SalesOrderProvisionalPaymentMethodRule(m),
                new SalesOrderProvisionalShipFromAddressRule(m),
                new SalesOrderProvisionalShipmentMethodRule(m),
                new SalesOrderProvisionalShipToAddressRule(m),
                new SalesOrderProvisionalShipToEndCustomerAddressRule(m),
                new SalesOrderProvisionalTakenByContactMechanismRule(m),
                new SalesOrderProvisionalVatClauseRule(m),
                new SalesOrderProvisionalVatRegimeRule(m),
                new SalesOrderRule(m),
                new SalesOrderSearchStringRule(m),
                new SalesOrderShipRule(m),
                new SalesOrderStateRule(m),
                new SalesOrderSyncSalesOrderItemsRule(m),
                new SalesOrderTransferRule(m),
                new SalesOrderValidationsRule(m),
                new SerialisedInventoryItemDeniedPermissionRule(m),
                new SerialisedInventoryItemQuantitiesRule(m),
                new SerialisedInventoryItemRule(m),
                new SerialisedInventoryItemSearchStringRule(m),
                new SerialisedItemCharacteristicRule(m),
                new SerialisedItemCharacteristicSearchStringRule(m),
                new SerialisedItemCharacteristicTypeDisplayNameRule(m),
                new SerialisedItemCharacteristicTypeRule(m),
                new SerialisedItemDeniedPermissionRule(m),
                new SerialisedItemDisplayNameRule(m),
                new SerialisedItemNameRule(m),
                new SerialisedItemOwnedByPartyNameRule(m),
                new SerialisedItemOwnerRule(m),
                new SerialisedItemOwnershipByOwnershipNameRule(m),
                new SerialisedItemPartWhereSerialisedItemRule(m),
                new SerialisedItemProductCategoriesDisplayNameRule(m),
                new SerialisedItemPurchaseInvoiceRule(m),
                new SerialisedItemPurchaseOrderRule(m),
                new SerialisedItemPurchasePriceRule(m),
                new SerialisedItemQuoteItemWhereSerialisedItemRule(m),
                new SerialisedItemRentedByPartyNameRule(m),
                new SerialisedItemRule(m),
                new SerialisedItemSalesOrderItemWhereSerialisedItemRule(m),
                new SerialisedItemSearchStringRule(m),
                new SerialisedItemSerialisedItemAvailabilityNameRule(m),
                new SerialisedItemSuppliedByPartyNameRule(m),
                new SerialisedItemSuppliedByRule(m),
                new SerialisedItemWorkEffortFixedAssetAssignemtsWhereFixedAssetRule(m),
                new ShipmentItemDeniedPermissionRule(m),
                new ShipmentItemRule(m),
                new ShipmentItemStateRule(m),
                new ShipmentPackageRule(m),
                new ShipmentReceiptRule(m),
                new ShipmentRule(m),
                new SingletonLocalesRule(m),
                new StatementOfWorkDeniedPermissionRule(m),
                new StatementOfWorkRule(m),
                new StatementOfWorkSearchStringRule(m),
                new StoreRule(m),
                new SubcontractorRelationshipRule(m),
                new SupplierOfferingExistCurrencyRule(m),
                new SupplierOfferingExistSupplierRule(m),
                new SupplierOfferingRule(m),
                new SupplierRelationshipRule(m),
                new SurchargeComponentRule(m),
                new SurchargeComponentRule(m),
                new TeleCommunicationsNumberDisplayNameRule(m),
                new TimeAndMaterialsServiceDisplayNameRule(m),
                new TimeAndMaterialsServiceRule(m),
                new TimeAndMaterialsServiceSearchStringRule(m),
                new TimeEntryRule(m),
                new TimeEntryWorkerRule(m),
                new TransferDeniedPermissionRule(m),
                new TransferDeriveShipFromAddressRule(m),
                new TransferDeriveShipToAddressRule(m),
                new TransferSearchStringRule(m),
                new UnifiedGoodDeniedPermissionRule(m),
                new UnifiedGoodDisplayNameRule(m),
                new UnifiedGoodRule(m),
                new UnifiedGoodSearchStringRule(m),
                new UnifiedProductProductIdentificationNamesRule(m),
                new UnifiedProductScopeNameRule(m),
                new UnifiedProductUnitOfMeasureAbbreviationRule(m),
                new VehicleSearchStringRule(m),
                new WebAddressDisplayNameRule(m),
                new WebSiteCommunicationSearchStringRule(m),
                new WebSiteCommunicationsRule(m),
                new WorkEffortAssignmentRateValidationRule(m),
                new WorkEffortAssignmentRateWorkEffortRule(m),
                new WorkEffortGrandTotalRule(m),
                new WorkEffortInventoryAssignmentCostOfGoodsSoldRule(m),
                new WorkEffortInventoryAssignmentDerivedBillableQuantityRule(m),
                new WorkEffortInventoryAssignmentSyncInventoryTransactionsRule(m),
                new WorkEffortInventoryAssignmentUnitSellingPriceRule(m),
                new WorkEffortInvoiceItemDeniedPermissionRule(m),
                new WorkEffortPartyAssignmentRule(m),
                new WorkEffortPurchaseOrderItemAssignmentPurchaseOrderItemRule(m),
                new WorkEffortPurchaseOrderItemAssignmentRule(m),
                new WorkEffortPurchaseOrderItemAssignmentUnitSellingRule(m),
                new WorkEffortTotalLabourRevenueRule(m),
                new WorkEffortTotalMaterialRevenueRule(m),
                new WorkEffortTotalOtherRevenueRule(m),
                new WorkEffortTotalRevenueRule(m),
                new WorkEffortTotalSubContractedRevenueRule(m),
                new WorkEffortTypeRule(m),
                new WorkRequirementDeniedPermissionRule(m),
                new WorkRequirementFixedAssetNameRule(m),
                new WorkRequirementFulfillmentDeniedPermissionRule(m),
                new WorkRequirementFulfillmentRule(m),
                new WorkRequirementFulfillmentWorkEffortRule(m),
                new WorkRequirementSearchStringRule(m),
                new WorkRequirementServicedByRule(m),
                new WorkRequirementStateRule(m),
                new WorkRequirementWorkEffortNumberRule(m),
                new WorkTaskActualHoursRule(m),
                new WorkTaskCanInvoiceRule(m),
                new WorkTaskDeniedPermissionRule(m),
                new WorkTaskExecutedByRule(m),
                new WorkTaskPrintRule(m),
                new WorkTaskRule(m),
                new WorkTaskSearchStringRule(m),
                new WorkTaskStateRule(m),
                new WorkTaskTakenByRule(m),
                new WorkTaskWorkEffortAssignmentRule(m),
            };
    }
}
