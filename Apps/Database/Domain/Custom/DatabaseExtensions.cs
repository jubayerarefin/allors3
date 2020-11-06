// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    public static class DatabaseExtensions
    {
        public static void RegisterDerivations(this @IDatabase @this)
        {
            var m = @this.State().M;
            var derivations = new IDomainDerivation[]
            {
                // Core
                new AuditableDerivation(m),
                new MediaDerivation(m),
                new TransitionalDeniedPermissionDerivation(m),

                // Apps
                new OwnBankAccountCreationDerivation(m),
                new OwnCreditCardCreationDerivation(m),
                new FiscalYearInvoiceNumberCreationDerivation(m),
                new PurchaseInvoiceCreationDerivation(m),
                new PurchaseInvoiceItemCreationDerivation(m),
                new AccountingPeriodDerivation(m),
                new StoreCreationDerivation(m),
                new PurchaseOrderItemCreationDerivation(m),
                new QuoteItemCreationDerivation(m),
                new RequestItemCreationDerivation(m),
                new RequirementCreationDerivation(m),
                new BankDerivation(m),
                new BankAccountDerivation(m),
                new CashDerivation(m),
                new CostCenterCategoryDerivation(m),
                new GeneralLedgerAccountDerivation(m),
                new JournalDerivation(m),
                new OrganisationGlAccountDerivation(m),
                new OwnBankAccountDerivation(m),
                new OwnCreditCardDerivation(m),
                new BudgetDeniedPermissionDerivation(m),
                new CaseDeniedPermissionDerivation(m),
                new CustomerReturnDeniedPermissionDerivation(m),
                new CustomerShipmentDeniedPermissionDerivation(m),
                new DropShipmentDeniedPermissionDerivation(m),
                new CommunicationEventDeniedPermissionDerivation(m),
                new EngineeringChangeDeniedPermissionDerivation(m),
                new NonSerialisedInventoryItemDeniedPermissionDerivation(m),
                new PartSpecificationDeniedPermissionDerivation(m),
                new PickListDeniedPermissionDerivation(m),
                new ProductQuoteDeniedPermissionDerivation(m),
                new ProposalDeniedPermissionDerivation(m),
                new CountryDerivation(m),
                new PostalAddressDerivation(m),
                new StoreDerivation(m),
                new PurchaseInvoiceItemDerivation(m),
                new PurchaseInvoiceDeniedPermissionDerivation(m),
                new PurchaseInvoiceItemDeniedPermissionDerivation(m),
                new PurchaseOrderDeniedPermissionDerivation(m),
                new PurchaseOrderItemDeniedPermissionDerivation(m),
                new PurchaseReturnDeniedPermissionDerivation(m),
                new PurchaseShipmentDeniedPermissionDerivation(m),
                new QuoteItemDeniedPermissionDerivation(m),
                new RequestForInformationDeniedPermissionDerivation(m),
                new RequestForProposalDeniedPermissionDerivation(m),
                new RequestForQuoteDeniedPermissionDerivation(m),
                new RequestItemDeniedPermissionDerivation(m),
                new RequirementDeniedPermissionDerivation(m),
                new SalesInvoiceDeniedPermissionDerivation(m),
                new SalesInvoiceItemDeniedPermissionDerivation(m),
                new SalesOrderItemDeniedPermissionDerivation(m),
                new SalesOrderDeniedPermissionDerivation(m),
                new WorkTaskDerivation(m),
                new SerialisedInventoryItemDeniedPermissionDerivation(m),
                new SerialisedItemPurchaseOrderDervivation(m),
                new SerialisedItemPurchaseInvoiceDervivation(m),
                new SerialisedItemPurchasePriceDervivation(m),
                new ShipmentItemDeniedPermissionDerivation(m),
                new StatementOfWorkDeniedPermissionDerivation(m),
                new TransferDeniedPermissionDerivation(m),
                new WorkTaskDeniedPermissionDerivation(m),
                new ShipmentDerivation(m),
                new SupplierOfferingDerivation(m),
                new ServiceDerivation(m),
                new SerialisedItemCharacteristicDerivation(m),
                new SerialisedInventoryItemDerivation(m),
                new ProductCategoryDerivation(m),
                new PriceComponentDerivation(m),
                new PartCategoryDerivation(m),
                new OrderValueDerivation(m),
                new OrderQuantityBreakDerivation(m),
                new NonUnifiedGoodDerivation(m),
                new StatementOfWorkDerivation(m),
                new SurchargeComponentDerivation(m),
                new SerialisedItemDerivation(m),
                new SerialisedItemDeniedPermissionDerivation(m),
                new QuoteItemDerivation(m),
                new PurchaseOrderApprovalLevel1Derivation(m),
                new ProposalDerivation(m),
                new ProductQuoteApprovalDerivation(m),
                new ProductQuoteDerivation(m),
                new OrderAdjustmentDerivation(m),
                new EngagementDerivation(m),
                new SalesOrderTransferDerivation(m),
                new QuoteDerivation(m),
                new PurchaseOrderApprovalLevel2Derivation(m),
                new PurchaseReturnDerivation(m),
                new PurchaseShipmentDerivation(m),
                new ShipmentPackageDerivation(m),
                new ShipmentValueDerivation(m),
                new PickListItemDerivation(m),
                new PickListDerivation(m),
                new PackagingContentDerivation(m),
                new DropShipmentDerivation(m),
                new TransferDerivation(m),
                new ShipmentReceiptDerivation(m),
                new CustomerReturnDerivation(m),
                new SalesOrderItemInventoryAssignmentDerivation(m),
                new UnifiedGoodDerivation(m),
                new NonSerialisedInventoryItemDerivation(m),
                new NonUnifiedPartDerivation(m),
                new NonUnifiedPartDeniedPermissionDerivation(m),
                new UnifiedGoodDeniedPermissionDerivation(m),
                new NonUnifiedGoodDeniedPermissionDerivation(m),
                new PartDerivation(m),
                new InventoryItemTransactionDerivation(m),
                new InventoryItemDerivation(m),
                new CatalogueDerivation(m),
                new SingletonCreationDerivation(m),
                new SingletonLocalesDerivation(m),
                new SettingsDerivation(m),
                new PayrollPreferenceDerivation(m),
                new PayHistoryDerivation(m),
                new PhoneCommunicationDerivation(m),
                new ProfessionalServicesRelationshipDerivation(m),
                new OrganisationContactRelationshipDateDerivation(m),
                new OrganisationContactRelationshipPartyDerivation(m),
                new InternalOrganisationDerivation(m),
                new FaceToFaceCommunicationDerivation(m),
                new EmploymentDerivation(m),
                new CommunicationTaskDerivation(m),
                new CommunicationEventDerivation(m),
                new AutomatedAgentDerivation(m),
                new AgreementProductApplicabilityDerivation(m),
                new AgreementTermDerivation(m),
                new EmailCommunicationDerivation(m),
                new OrganisationDerivation(m),
                new OrganisationDeniedPermissionDerivation(m),
                new PersonDerivation(m),
                new PersonDeniedPermissionDerivation(m),
                new PartyDerivation(m),
                new EmailTemplateDerivation(m),
                new WebSiteCommunicationsDerivation(m),
                new CustomerRelationshipDerivation(m),
                new FaxCommunicationDerivation(m),
                new LetterCorrespondenceDerivation(m),
                new OrganisationRollupDerivation(m),
                new PartyContactMechanismDerivation(m),
                new SubcontractorRelationshipDerivation(m),
                new PassportDerivation(m),
                new RequestItemDerivation(m),
                new RequestForQuoteDerivation(m),
                new RequestForProposalDerivation(m),
                new RequestForInformationDerivation(m),
                new RequestDerivation(m),
                new PurchaseInvoiceDerivation(m),
                new PurchaseOrderItemDerivation(m),
                new PaymentDerivation(m),
                new PurchaseInvoiceApprovalDerivation(m),
                new SalesInvoiceItemDerivation(m),
                new SalesInvoiceItemCreateDerivation(m),
                new RepeatingPurchaseInvoiceDerivation(m),
                new RepeatingSalesInvoiceDerivation(m),
                new SalesInvoiceDerivation(m),
                new SalesInvoiceCreateDerivation(m),
                new SalesInvoicePriceDerivation(m),
                new SalesInvoiceStateDerivation(m),
                new PartyFinancialRelationshipCreationDerivation(m),
                new PartyFinancialRelationshipAmountDueDerivation(m),
                new PartyFinancialRelationshipOpenOrderAmountDerivation(m),
                new PaymentApplicationDerivation(m),
                new SupplierRelationshipDerivation(m),
                new PurchaseOrderItemIsReceivableDerivation(m),
                new PurchaseOrderDerivation(m), //Has Dependency on SupplierRelationship
                new ShipmentItemDerivation(m),
                new CustomerShipmentDerivation(m),
                new OrderShipmentDerivation(m),
                new SalesOrderItemCreateDerivation(m),
                new SalesOrderItemDerivation(m),
                new SalesOrderCanInvoiceDerivation(m),
                new SalesOrderCanShipDerivation(m),
                new SalesOrderCreateDerivation(m),
                new SalesOrderDerivation(m),
                new SalesOrderPriceDerivation(m),
                new SalesOrderStateDerivation(m),
                new InvoiceItemTotalIncVatDerivation(m),
                new DeliverableTurnoverDerivation(m),
                new ExpenseEntryDerivation(m),
                new MaterialsUsageDerivation(m),
                new TimeEntryDerivation(m),
                new WorkEffortAssignmentRateDerivation(m),
                new WorkEffortInventoryAssignmentDerivation(m),
                new WorkEffortPartyAssignmentDerivation(m),
                new WorkEffortPurchaseOrderItemAssignmentDerivation(m),
                new WorkEffortTypeDerivation(m),
            };

            foreach (var derivation in derivations)
            {
                @this.AddDerivation(derivation);
            }
        }
    }
}
