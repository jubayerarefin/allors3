// <copyright file="ObjectsBase.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using Meta;

    public static partial class Rules
    {
        public static Rule[] Create(MetaPopulation m) =>
            new Rule[]
            {
                // Core
                new MediaRule(m),
                new TransitionalDeniedPermissionRule(m),

                // Apps
                new BasePriceRule(m),
                new DiscountComponentRule(m),
                new SurchargeComponentRule(m),
                new AccountingPeriodRule(m),
                new BankRule(m),
                new BankAccountIbanRule(m),
                new BankAccountRule(m),
                new CashRule(m),
                new GeneralLedgerAccountCostUnitAllowedRule(m),
                new GeneralLedgerAccountCostUnitRequiredRule(m),
                new GeneralLedgerAccountCostCenterAllowedRule(m),
                new GeneralLedgerAccountCostCenterRequiredRule(m),
                new GeneralLedgerAccountRule(m),
                new JournalContraAccountRule(m),
                new JournalTypeRule(m),
                new OwnBankAccountRule(m),
                new OwnCreditCardInternalOrganisationPaymentMethodsRule(m),
                new OwnCreditCardRule(m),
                new BudgetDeniedPermissionRule(m),
                new CaseDeniedPermissionRule(m),
                new CustomerReturnDeniedPermissionRule(m),
                new CustomerShipmentDeniedPermissionRule(m),
                new DropShipmentDeniedPermissionRule(m),
                new CommunicationEventDeniedPermissionRule(m),
                new EngineeringChangeDeniedPermissionRule(m),
                new NonSerialisedInventoryItemDeniedPermissionRule(m),
                new PartSpecificationDeniedPermissionRule(m),
                new PickListDeniedPermissionRule(m),
                new ProductQuoteDeniedPermissionRule(m),
                new ProposalDeniedPermissionRule(m),
                new CountryRule(m),
                new CountryVatRegimesRule(m),
                new PostalAddressRule(m),
                new StoreRule(m),
                new PurchaseInvoiceDeniedPermissionRule(m),
                new PurchaseInvoiceItemRule(m),
                new PurchaseInvoiceItemStateRule(m),
                new PurchaseInvoiceItemDeniedPermissionRule(m),
                new PurchaseOrderDeniedPermissionRule(m),
                new PurchaseOrderItemDeniedPermissionRule(m),
                new PurchaseReturnDeniedPermissionRule(m),
                new PurchaseShipmentDeniedPermissionRule(m),
                new QuoteItemDeniedPermissionRule(m),
                new RequestForInformationDeniedPermissionRule(m),
                new RequestForProposalDeniedPermissionRule(m),
                new RequestForQuoteDeniedPermissionRule(m),
                new RequestItemDeniedPermissionRule(m),
                new RequirementDeniedPermissionRule(m),
                new SalesOrderItemDeniedPermissionRule(m),
                new SalesOrderDeniedPermissionRule(m),
                new SalesOrderTransferRule(m),
                new SalesOrderCanInvoiceRule(m),
                new SalesOrderCanShipRule(m),
                new SalesOrderRule(m),
                new SalesOrderProvisionalRule(m),
                new SalesOrderPriceRule(m),
                new SalesOrderStateRule(m),
                new SalesOrderItemRule(m),
                new SalesOrderItemByProductRule(m),
                new SalesOrderItemPriceRule(m),
                new SalesOrderItemQuantitiesRule(m),
                new SalesOrderItemShipmentRule(m),
                new SalesOrderItemStateRule(m),
                new SalesOrderItemProvisionalRule(m),
                new SalesOrderItemInventoryAssignmentRule(m),
                new WorkTaskRule(m),
                new WorkTaskCanInvoiceRule(m),
                new SerialisedInventoryItemDeniedPermissionRule(m),
                new SerialisedItemPurchaseOrderRule(m),
                new SerialisedItemPurchaseInvoiceRule(m),
                new SerialisedItemPurchasePriceRule(m),
                new ShipmentItemDeniedPermissionRule(m),
                new StatementOfWorkDeniedPermissionRule(m),
                new TransferDeniedPermissionRule(m),
                new WorkTaskDeniedPermissionRule(m),
                new ShipmentRule(m),
                new SupplierOfferingRule(m),
                new SerialisedItemCharacteristicRule(m),
                new SerialisedItemCharacteristicTypeRule(m),
                new SerialisedItemOwnerRule(m),
                new SerialisedInventoryItemRule(m),
                new SerialisedInventoryItemQuantitiesRule(m),
                new PriceComponentRule(m),
                new PartCategoryRule(m),
                new NonUnifiedGoodRule(m),
                new StatementOfWorkRule(m),
                new SurchargeComponentRule(m),
                new SerialisedItemRule(m),
                new SerialisedItemDisplayProductCategoriesRule(m),
                new SerialisedItemDeniedPermissionRule(m),
                new QuoteItemRule(m),
                new QuoteItemCreatedRule(m),
                new QuoteItemDetailsRule(m),
                new QuoteItemPriceRule(m),
                new PurchaseOrderApprovalLevel1Rule(m),
                new ProposalRule(m),
                new ProductQuoteApprovalRule(m),
                new ProductQuoteApprovalParticipantsRule(m),
                new ProductQuoteRule(m),
                new ProductQuoteAwaitingApprovalRule(m),
                new ProductQuoteItemByProductRule(m),
                new EngagementRule(m),
                new QuoteRule(m),
                new QuoteCreatedRule(m),
                new QuotePriceRule(m),
                new PurchaseOrderApprovalLevel2Rule(m),
                new PurchaseReturnRule(m),
                new PurchaseShipmentRule(m),
                new PurchaseShipmentStateRule(m),
                new ShipmentPackageRule(m),
                new PickListItemRule(m),
                new PickListItemQuantityPickedRule(m),
                new PickListRule(m),
                new PickListStateRule(m),
                new PackagingContentRule(m),
                new DropShipmentRule(m),
                new TransferRule(m),
                new ShipmentReceiptRule(m),
                new CustomerReturnRule(m),
                new DeliverableBasedServiceRule(m),
                new TimeAndMaterialsServiceRule(m),
                new GoodRule(m),
                new UnifiedGoodRule(m),
                new NonSerialisedInventoryItemRule(m),
                new NonSerialisedInventoryItemQuantitiesRule(m),
                new NonUnifiedPartRule(m),
                new PartSuppliedByRule(m),
                new PartQuantitiesRule(m),
                new NonUnifiedPartDeniedPermissionRule(m),
                new UnifiedGoodDeniedPermissionRule(m),
                new NonUnifiedGoodDeniedPermissionRule(m),
                new PartRule(m),
                new InventoryItemTransactionRule(m),
                new InventoryItemRule(m),
                new InventoryItemPartDisplayNameRule(m),
                new InventoryItemSearchStringRule(m),
                new CatalogueRule(m),
                new SingletonLocalesRule(m),
                new PayrollPreferenceRule(m),
                new PayHistoryRule(m),
                new PhoneCommunicationRule(m),
                new ProfessionalServicesRelationshipRule(m),
                new OrganisationContactRelationshipDateRule(m),
                new OrganisationContactRelationshipPartyRule(m),
                new InternalOrganisationRule(m),
                new FaceToFaceCommunicationRule(m),
                new EmploymentRule(m),
                new CommunicationTaskRule(m),
                new CommunicationEventRule(m),
                new AutomatedAgentRule(m),
                new AgreementProductApplicabilityRule(m),
                new AgreementTermRule(m),
                new EmailCommunicationRule(m),
                new OrganisationRule(m),
                new OrganisationDeniedPermissionRule(m),
                new PersonRule(m),
                new PersonDeniedPermissionRule(m),
                new PartyRule(m),
                new WebSiteCommunicationsRule(m),
                new CustomerRelationshipRule(m),
                new FaxCommunicationRule(m),
                new LetterCorrespondenceRule(m),
                new OrganisationRollupRule(m),
                new PartyContactMechanismRule(m),
                new SubcontractorRelationshipRule(m),
                new RequestItemRule(m),
                new RequestForQuoteRule(m),
                new RequestForProposalRule(m),
                new RequestForInformationRule(m),
                new RequestRule(m),
                new RequestAnonymousRule(m),
                new PurchaseInvoiceRule(m),
                new PurchaseInvoiceCreatedRule(m),
                new PurchaseInvoiceStateRule(m),
                new PurchaseInvoicePriceRule(m),
                new PurchaseInvoiceSerialisedItemRule(m),
                new PurchaseInvoiceAwaitingApprovalRule(m),
                new PurchaseOrderItemRule(m),
                new PaymentRule(m),
                new PurchaseInvoiceApprovalRule(m),
                new SalesInvoiceItemRule(m),
                new SalesInvoiceItemSubTotalItemRule(m),
                new RepeatingPurchaseInvoiceRule(m),
                new RepeatingSalesInvoiceRule(m),
                new SalesInvoiceRule(m),
                new SalesInvoiceBillingRule(m),
                new SalesInvoiceReadyForPostingRule(m),
                new SalesInvoicePriceRule(m),
                new SalesInvoiceStateRule(m),
                new SalesInvoiceDeniedPermissionRule(m),
                new SalesInvoiceItemDeniedPermissionRule(m),
                new PartyFinancialRelationshipAmountDueRule(m),
                new PartyFinancialRelationshipOpenOrderAmountRule(m),
                new PaymentApplicationRule(m),
                new SupplierRelationshipRule(m),
                new PurchaseOrderItemIsReceivableRule(m),
                new PurchaseOrderItemCreatedRule(m),
                new PurchaseOrderItemStateRule(m),
                new PurchaseOrderItemByProductRule(m),
                new PurchaseOrderStateRule(m),
                new PurchaseOrderPriceRule(m),
                new PurchaseOrderRule(m),
                new PurchaseOrderCreatedRule(m),
                new PurchaseOrderAwaitingApprovalLevel1Rule(m),
                new PurchaseOrderAwaitingApprovalLevel2Rule(m),
                new PurchaseOrderApprovalLevel1Rule(m),
                new PurchaseOrderApprovalLevel2Rule(m),
                new PurchaseOrderStateRule(m),
                new PurchaseOrderPriceRule(m),
                new ShipmentItemRule(m),
                new ShipmentItemStateRule(m),
                new CustomerShipmentRule(m),
                new CustomerShipmentInvoiceRule(m),
                new CustomerShipmentShipmentValueRule(m),
                new CustomerShipmentShipRule(m),
                new CustomerShipmentStateRule(m),
                new OrderShipmentRule(m),
                new InvoiceItemTotalIncVatRule(m),
                new TimeEntryRule(m),
                new WorkEffortAssignmentRateRule(m),
                new WorkEffortInventoryAssignmentRule(m),
                new WorkEffortInventoryAssignmentCostOfGoodsSoldRule(m),
                new WorkEffortInventoryAssignmentDerivedBillableQuantityRule(m),
                new WorkEffortInventoryAssignmentUnitSellingPriceRule(m),
                new WorkEffortPartyAssignmentRule(m),
                new WorkEffortPurchaseOrderItemAssignmentRule(m),
                new WorkEffortPurchaseOrderItemAssignmentUnitSellingRule(m),
                new WorkEffortTotalLabourRevenueRule(m),
                new WorkEffortTotalMaterialRevenueRule(m),
                new WorkEffortTotalSubContractedRevenueRule(m),
                new WorkEffortGrandTotalRule(m),
                new WorkEffortTotalRevenueRule(m),
                new WorkEffortTypeRule(m),
                new PurchaseInvoiceApprovalParticipantsRule(m),
                new PurchaseOrderApprovalLevel1ParticipantsRule(m),
                new PurchaseOrderApprovalLevel2ParticipantsRule(m),
                new CommunicationTaskParticipantsRule(m),
                new ProductCategoryRule(m),
            };
    }
}
