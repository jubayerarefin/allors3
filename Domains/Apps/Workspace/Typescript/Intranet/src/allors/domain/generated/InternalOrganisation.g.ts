// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { Auditable } from './Auditable.g';
import { JournalEntryNumber } from './JournalEntryNumber.g';
import { Country } from './Country.g';
import { Counter } from './Counter.g';
import { AccountingPeriod } from './AccountingPeriod.g';
import { InvoiceSequence } from './InvoiceSequence.g';
import { PaymentMethod } from './PaymentMethod.g';
import { Media } from './Media.g';
import { CostCenterSplitMethod } from './CostCenterSplitMethod.g';
import { LegalForm } from './LegalForm.g';
import { GeneralLedgerAccount } from './GeneralLedgerAccount.g';
import { CostOfGoodsSoldMethod } from './CostOfGoodsSoldMethod.g';
import { AccountingTransactionNumber } from './AccountingTransactionNumber.g';
import { Facility } from './Facility.g';
import { Person } from './Person.g';
import { Party } from './Party.g';
import { Organisation } from './Organisation.g';
import { BankAccount } from './BankAccount.g';
import { VatRegime } from './VatRegime.g';
import { ContactMechanism } from './ContactMechanism.g';
import { PostalAddress } from './PostalAddress.g';
import { User } from './User.g';
import { Singleton } from './Singleton.g';

export class InternalOrganisation extends SessionObject implements UniquelyIdentifiable, Auditable {
    get CanReadPurchaseOrderNumberPrefix(): boolean {
        return this.canRead('PurchaseOrderNumberPrefix');
    }

    get CanWritePurchaseOrderNumberPrefix(): boolean {
        return this.canWrite('PurchaseOrderNumberPrefix');
    }

    get PurchaseOrderNumberPrefix(): string {
        return this.get('PurchaseOrderNumberPrefix');
    }

    set PurchaseOrderNumberPrefix(value: string) {
        this.set('PurchaseOrderNumberPrefix', value);
    }

    get CanReadTransactionReferenceNumber(): boolean {
        return this.canRead('TransactionReferenceNumber');
    }

    get CanWriteTransactionReferenceNumber(): boolean {
        return this.canWrite('TransactionReferenceNumber');
    }

    get TransactionReferenceNumber(): string {
        return this.get('TransactionReferenceNumber');
    }

    set TransactionReferenceNumber(value: string) {
        this.set('TransactionReferenceNumber', value);
    }

    get CanReadJournalEntryNumbers(): boolean {
        return this.canRead('JournalEntryNumbers');
    }

    get CanWriteJournalEntryNumbers(): boolean {
        return this.canWrite('JournalEntryNumbers');
    }

    get JournalEntryNumbers(): JournalEntryNumber[] {
        return this.get('JournalEntryNumbers');
    }

    AddJournalEntryNumber(value: JournalEntryNumber) {
        return this.add('JournalEntryNumbers', value);
    }

    RemoveJournalEntryNumber(value: JournalEntryNumber) {
        return this.remove('JournalEntryNumbers', value);
    }

    set JournalEntryNumbers(value: JournalEntryNumber[]) {
        this.set('JournalEntryNumbers', value);
    }

    get CanReadEuListingState(): boolean {
        return this.canRead('EuListingState');
    }

    get CanWriteEuListingState(): boolean {
        return this.canWrite('EuListingState');
    }

    get EuListingState(): Country {
        return this.get('EuListingState');
    }

    set EuListingState(value: Country) {
        this.set('EuListingState', value);
    }

    get CanReadPurchaseInvoiceCounter(): boolean {
        return this.canRead('PurchaseInvoiceCounter');
    }

    get CanWritePurchaseInvoiceCounter(): boolean {
        return this.canWrite('PurchaseInvoiceCounter');
    }

    get PurchaseInvoiceCounter(): Counter {
        return this.get('PurchaseInvoiceCounter');
    }

    set PurchaseInvoiceCounter(value: Counter) {
        this.set('PurchaseInvoiceCounter', value);
    }

    get CanReadActualAccountingPeriod(): boolean {
        return this.canRead('ActualAccountingPeriod');
    }

    get CanWriteActualAccountingPeriod(): boolean {
        return this.canWrite('ActualAccountingPeriod');
    }

    get ActualAccountingPeriod(): AccountingPeriod {
        return this.get('ActualAccountingPeriod');
    }

    set ActualAccountingPeriod(value: AccountingPeriod) {
        this.set('ActualAccountingPeriod', value);
    }

    get CanReadInvoiceSequence(): boolean {
        return this.canRead('InvoiceSequence');
    }

    get CanWriteInvoiceSequence(): boolean {
        return this.canWrite('InvoiceSequence');
    }

    get InvoiceSequence(): InvoiceSequence {
        return this.get('InvoiceSequence');
    }

    set InvoiceSequence(value: InvoiceSequence) {
        this.set('InvoiceSequence', value);
    }

    get CanReadActivePaymentMethods(): boolean {
        return this.canRead('ActivePaymentMethods');
    }

    get ActivePaymentMethods(): PaymentMethod[] {
        return this.get('ActivePaymentMethods');
    }


    get CanReadMaximumAllowedPaymentDifference(): boolean {
        return this.canRead('MaximumAllowedPaymentDifference');
    }

    get CanWriteMaximumAllowedPaymentDifference(): boolean {
        return this.canWrite('MaximumAllowedPaymentDifference');
    }

    get MaximumAllowedPaymentDifference(): number {
        return this.get('MaximumAllowedPaymentDifference');
    }

    set MaximumAllowedPaymentDifference(value: number) {
        this.set('MaximumAllowedPaymentDifference', value);
    }

    get CanReadLogoImage(): boolean {
        return this.canRead('LogoImage');
    }

    get CanWriteLogoImage(): boolean {
        return this.canWrite('LogoImage');
    }

    get LogoImage(): Media {
        return this.get('LogoImage');
    }

    set LogoImage(value: Media) {
        this.set('LogoImage', value);
    }

    get CanReadCostCenterSplitMethod(): boolean {
        return this.canRead('CostCenterSplitMethod');
    }

    get CanWriteCostCenterSplitMethod(): boolean {
        return this.canWrite('CostCenterSplitMethod');
    }

    get CostCenterSplitMethod(): CostCenterSplitMethod {
        return this.get('CostCenterSplitMethod');
    }

    set CostCenterSplitMethod(value: CostCenterSplitMethod) {
        this.set('CostCenterSplitMethod', value);
    }

    get CanReadPurchaseOrderCounter(): boolean {
        return this.canRead('PurchaseOrderCounter');
    }

    get CanWritePurchaseOrderCounter(): boolean {
        return this.canWrite('PurchaseOrderCounter');
    }

    get PurchaseOrderCounter(): Counter {
        return this.get('PurchaseOrderCounter');
    }

    set PurchaseOrderCounter(value: Counter) {
        this.set('PurchaseOrderCounter', value);
    }

    get CanReadLegalForm(): boolean {
        return this.canRead('LegalForm');
    }

    get CanWriteLegalForm(): boolean {
        return this.canWrite('LegalForm');
    }

    get LegalForm(): LegalForm {
        return this.get('LegalForm');
    }

    set LegalForm(value: LegalForm) {
        this.set('LegalForm', value);
    }

    get CanReadSalesPaymentDifferencesAccount(): boolean {
        return this.canRead('SalesPaymentDifferencesAccount');
    }

    get CanWriteSalesPaymentDifferencesAccount(): boolean {
        return this.canWrite('SalesPaymentDifferencesAccount');
    }

    get SalesPaymentDifferencesAccount(): GeneralLedgerAccount {
        return this.get('SalesPaymentDifferencesAccount');
    }

    set SalesPaymentDifferencesAccount(value: GeneralLedgerAccount) {
        this.set('SalesPaymentDifferencesAccount', value);
    }

    get CanReadName(): boolean {
        return this.canRead('Name');
    }

    get CanWriteName(): boolean {
        return this.canWrite('Name');
    }

    get Name(): string {
        return this.get('Name');
    }

    set Name(value: string) {
        this.set('Name', value);
    }

    get CanReadPurchaseTransactionReferenceNumber(): boolean {
        return this.canRead('PurchaseTransactionReferenceNumber');
    }

    get CanWritePurchaseTransactionReferenceNumber(): boolean {
        return this.canWrite('PurchaseTransactionReferenceNumber');
    }

    get PurchaseTransactionReferenceNumber(): string {
        return this.get('PurchaseTransactionReferenceNumber');
    }

    set PurchaseTransactionReferenceNumber(value: string) {
        this.set('PurchaseTransactionReferenceNumber', value);
    }

    get CanReadFiscalYearStartMonth(): boolean {
        return this.canRead('FiscalYearStartMonth');
    }

    get CanWriteFiscalYearStartMonth(): boolean {
        return this.canWrite('FiscalYearStartMonth');
    }

    get FiscalYearStartMonth(): number {
        return this.get('FiscalYearStartMonth');
    }

    set FiscalYearStartMonth(value: number) {
        this.set('FiscalYearStartMonth', value);
    }

    get CanReadCostOfGoodsSoldMethod(): boolean {
        return this.canRead('CostOfGoodsSoldMethod');
    }

    get CanWriteCostOfGoodsSoldMethod(): boolean {
        return this.canWrite('CostOfGoodsSoldMethod');
    }

    get CostOfGoodsSoldMethod(): CostOfGoodsSoldMethod {
        return this.get('CostOfGoodsSoldMethod');
    }

    set CostOfGoodsSoldMethod(value: CostOfGoodsSoldMethod) {
        this.set('CostOfGoodsSoldMethod', value);
    }

    get CanReadVatDeactivated(): boolean {
        return this.canRead('VatDeactivated');
    }

    get CanWriteVatDeactivated(): boolean {
        return this.canWrite('VatDeactivated');
    }

    get VatDeactivated(): boolean {
        return this.get('VatDeactivated');
    }

    set VatDeactivated(value: boolean) {
        this.set('VatDeactivated', value);
    }

    get CanReadFiscalYearStartDay(): boolean {
        return this.canRead('FiscalYearStartDay');
    }

    get CanWriteFiscalYearStartDay(): boolean {
        return this.canWrite('FiscalYearStartDay');
    }

    get FiscalYearStartDay(): number {
        return this.get('FiscalYearStartDay');
    }

    set FiscalYearStartDay(value: number) {
        this.set('FiscalYearStartDay', value);
    }

    get CanReadGeneralLedgerAccounts(): boolean {
        return this.canRead('GeneralLedgerAccounts');
    }

    get GeneralLedgerAccounts(): GeneralLedgerAccount[] {
        return this.get('GeneralLedgerAccounts');
    }


    get CanReadAccountingTransactionCounter(): boolean {
        return this.canRead('AccountingTransactionCounter');
    }

    get CanWriteAccountingTransactionCounter(): boolean {
        return this.canWrite('AccountingTransactionCounter');
    }

    get AccountingTransactionCounter(): Counter {
        return this.get('AccountingTransactionCounter');
    }

    set AccountingTransactionCounter(value: Counter) {
        this.set('AccountingTransactionCounter', value);
    }

    get CanReadIncomingShipmentCounter(): boolean {
        return this.canRead('IncomingShipmentCounter');
    }

    get CanWriteIncomingShipmentCounter(): boolean {
        return this.canWrite('IncomingShipmentCounter');
    }

    get IncomingShipmentCounter(): Counter {
        return this.get('IncomingShipmentCounter');
    }

    set IncomingShipmentCounter(value: Counter) {
        this.set('IncomingShipmentCounter', value);
    }

    get CanReadRetainedEarningsAccount(): boolean {
        return this.canRead('RetainedEarningsAccount');
    }

    get CanWriteRetainedEarningsAccount(): boolean {
        return this.canWrite('RetainedEarningsAccount');
    }

    get RetainedEarningsAccount(): GeneralLedgerAccount {
        return this.get('RetainedEarningsAccount');
    }

    set RetainedEarningsAccount(value: GeneralLedgerAccount) {
        this.set('RetainedEarningsAccount', value);
    }

    get CanReadPurchaseInvoiceNumberPrefix(): boolean {
        return this.canRead('PurchaseInvoiceNumberPrefix');
    }

    get CanWritePurchaseInvoiceNumberPrefix(): boolean {
        return this.canWrite('PurchaseInvoiceNumberPrefix');
    }

    get PurchaseInvoiceNumberPrefix(): string {
        return this.get('PurchaseInvoiceNumberPrefix');
    }

    set PurchaseInvoiceNumberPrefix(value: string) {
        this.set('PurchaseInvoiceNumberPrefix', value);
    }

    get CanReadSalesPaymentDiscountDifferencesAccount(): boolean {
        return this.canRead('SalesPaymentDiscountDifferencesAccount');
    }

    get CanWriteSalesPaymentDiscountDifferencesAccount(): boolean {
        return this.canWrite('SalesPaymentDiscountDifferencesAccount');
    }

    get SalesPaymentDiscountDifferencesAccount(): GeneralLedgerAccount {
        return this.get('SalesPaymentDiscountDifferencesAccount');
    }

    set SalesPaymentDiscountDifferencesAccount(value: GeneralLedgerAccount) {
        this.set('SalesPaymentDiscountDifferencesAccount', value);
    }

    get CanReadSubAccountCounter(): boolean {
        return this.canRead('SubAccountCounter');
    }

    get CanWriteSubAccountCounter(): boolean {
        return this.canWrite('SubAccountCounter');
    }

    get SubAccountCounter(): Counter {
        return this.get('SubAccountCounter');
    }

    set SubAccountCounter(value: Counter) {
        this.set('SubAccountCounter', value);
    }

    get CanReadAccountingTransactionNumbers(): boolean {
        return this.canRead('AccountingTransactionNumbers');
    }

    get CanWriteAccountingTransactionNumbers(): boolean {
        return this.canWrite('AccountingTransactionNumbers');
    }

    get AccountingTransactionNumbers(): AccountingTransactionNumber[] {
        return this.get('AccountingTransactionNumbers');
    }

    AddAccountingTransactionNumber(value: AccountingTransactionNumber) {
        return this.add('AccountingTransactionNumbers', value);
    }

    RemoveAccountingTransactionNumber(value: AccountingTransactionNumber) {
        return this.remove('AccountingTransactionNumbers', value);
    }

    set AccountingTransactionNumbers(value: AccountingTransactionNumber[]) {
        this.set('AccountingTransactionNumbers', value);
    }

    get CanReadTransactionReferenceNumberPrefix(): boolean {
        return this.canRead('TransactionReferenceNumberPrefix');
    }

    get CanWriteTransactionReferenceNumberPrefix(): boolean {
        return this.canWrite('TransactionReferenceNumberPrefix');
    }

    get TransactionReferenceNumberPrefix(): string {
        return this.get('TransactionReferenceNumberPrefix');
    }

    set TransactionReferenceNumberPrefix(value: string) {
        this.set('TransactionReferenceNumberPrefix', value);
    }

    get CanReadQuoteCounter(): boolean {
        return this.canRead('QuoteCounter');
    }

    get CanWriteQuoteCounter(): boolean {
        return this.canWrite('QuoteCounter');
    }

    get QuoteCounter(): Counter {
        return this.get('QuoteCounter');
    }

    set QuoteCounter(value: Counter) {
        this.set('QuoteCounter', value);
    }

    get CanReadRequestCounter(): boolean {
        return this.canRead('RequestCounter');
    }

    get CanWriteRequestCounter(): boolean {
        return this.canWrite('RequestCounter');
    }

    get RequestCounter(): Counter {
        return this.get('RequestCounter');
    }

    set RequestCounter(value: Counter) {
        this.set('RequestCounter', value);
    }

    get CanReadPurchasePaymentDifferencesAccount(): boolean {
        return this.canRead('PurchasePaymentDifferencesAccount');
    }

    get CanWritePurchasePaymentDifferencesAccount(): boolean {
        return this.canWrite('PurchasePaymentDifferencesAccount');
    }

    get PurchasePaymentDifferencesAccount(): GeneralLedgerAccount {
        return this.get('PurchasePaymentDifferencesAccount');
    }

    set PurchasePaymentDifferencesAccount(value: GeneralLedgerAccount) {
        this.set('PurchasePaymentDifferencesAccount', value);
    }

    get CanReadSuspenceAccount(): boolean {
        return this.canRead('SuspenceAccount');
    }

    get CanWriteSuspenceAccount(): boolean {
        return this.canWrite('SuspenceAccount');
    }

    get SuspenceAccount(): GeneralLedgerAccount {
        return this.get('SuspenceAccount');
    }

    set SuspenceAccount(value: GeneralLedgerAccount) {
        this.set('SuspenceAccount', value);
    }

    get CanReadNetIncomeAccount(): boolean {
        return this.canRead('NetIncomeAccount');
    }

    get CanWriteNetIncomeAccount(): boolean {
        return this.canWrite('NetIncomeAccount');
    }

    get NetIncomeAccount(): GeneralLedgerAccount {
        return this.get('NetIncomeAccount');
    }

    set NetIncomeAccount(value: GeneralLedgerAccount) {
        this.set('NetIncomeAccount', value);
    }

    get CanReadDoAccounting(): boolean {
        return this.canRead('DoAccounting');
    }

    get CanWriteDoAccounting(): boolean {
        return this.canWrite('DoAccounting');
    }

    get DoAccounting(): boolean {
        return this.get('DoAccounting');
    }

    set DoAccounting(value: boolean) {
        this.set('DoAccounting', value);
    }

    get CanReadDefaultFacility(): boolean {
        return this.canRead('DefaultFacility');
    }

    get CanWriteDefaultFacility(): boolean {
        return this.canWrite('DefaultFacility');
    }

    get DefaultFacility(): Facility {
        return this.get('DefaultFacility');
    }

    set DefaultFacility(value: Facility) {
        this.set('DefaultFacility', value);
    }

    get CanReadPurchasePaymentDiscountDifferencesAccount(): boolean {
        return this.canRead('PurchasePaymentDiscountDifferencesAccount');
    }

    get CanWritePurchasePaymentDiscountDifferencesAccount(): boolean {
        return this.canWrite('PurchasePaymentDiscountDifferencesAccount');
    }

    get PurchasePaymentDiscountDifferencesAccount(): GeneralLedgerAccount {
        return this.get('PurchasePaymentDiscountDifferencesAccount');
    }

    set PurchasePaymentDiscountDifferencesAccount(value: GeneralLedgerAccount) {
        this.set('PurchasePaymentDiscountDifferencesAccount', value);
    }

    get CanReadQuoteNumberPrefix(): boolean {
        return this.canRead('QuoteNumberPrefix');
    }

    get CanWriteQuoteNumberPrefix(): boolean {
        return this.canWrite('QuoteNumberPrefix');
    }

    get QuoteNumberPrefix(): string {
        return this.get('QuoteNumberPrefix');
    }

    set QuoteNumberPrefix(value: string) {
        this.set('QuoteNumberPrefix', value);
    }

    get CanReadPurchaseTransactionReferenceNumberPrefix(): boolean {
        return this.canRead('PurchaseTransactionReferenceNumberPrefix');
    }

    get CanWritePurchaseTransactionReferenceNumberPrefix(): boolean {
        return this.canWrite('PurchaseTransactionReferenceNumberPrefix');
    }

    get PurchaseTransactionReferenceNumberPrefix(): string {
        return this.get('PurchaseTransactionReferenceNumberPrefix');
    }

    set PurchaseTransactionReferenceNumberPrefix(value: string) {
        this.set('PurchaseTransactionReferenceNumberPrefix', value);
    }

    get CanReadTaxNumber(): boolean {
        return this.canRead('TaxNumber');
    }

    get CanWriteTaxNumber(): boolean {
        return this.canWrite('TaxNumber');
    }

    get TaxNumber(): string {
        return this.get('TaxNumber');
    }

    set TaxNumber(value: string) {
        this.set('TaxNumber', value);
    }

    get CanReadCalculationDifferencesAccount(): boolean {
        return this.canRead('CalculationDifferencesAccount');
    }

    get CanWriteCalculationDifferencesAccount(): boolean {
        return this.canWrite('CalculationDifferencesAccount');
    }

    get CalculationDifferencesAccount(): GeneralLedgerAccount {
        return this.get('CalculationDifferencesAccount');
    }

    set CalculationDifferencesAccount(value: GeneralLedgerAccount) {
        this.set('CalculationDifferencesAccount', value);
    }

    get CanReadIncomingShipmentNumberPrefix(): boolean {
        return this.canRead('IncomingShipmentNumberPrefix');
    }

    get CanWriteIncomingShipmentNumberPrefix(): boolean {
        return this.canWrite('IncomingShipmentNumberPrefix');
    }

    get IncomingShipmentNumberPrefix(): string {
        return this.get('IncomingShipmentNumberPrefix');
    }

    set IncomingShipmentNumberPrefix(value: string) {
        this.set('IncomingShipmentNumberPrefix', value);
    }

    get CanReadRequestNumberPrefix(): boolean {
        return this.canRead('RequestNumberPrefix');
    }

    get CanWriteRequestNumberPrefix(): boolean {
        return this.canWrite('RequestNumberPrefix');
    }

    get RequestNumberPrefix(): string {
        return this.get('RequestNumberPrefix');
    }

    set RequestNumberPrefix(value: string) {
        this.set('RequestNumberPrefix', value);
    }

    get CanReadCurrentSalesReps(): boolean {
        return this.canRead('CurrentSalesReps');
    }

    get CanWriteCurrentSalesReps(): boolean {
        return this.canWrite('CurrentSalesReps');
    }

    get CurrentSalesReps(): Person[] {
        return this.get('CurrentSalesReps');
    }

    AddCurrentSalesRep(value: Person) {
        return this.add('CurrentSalesReps', value);
    }

    RemoveCurrentSalesRep(value: Person) {
        return this.remove('CurrentSalesReps', value);
    }

    set CurrentSalesReps(value: Person[]) {
        this.set('CurrentSalesReps', value);
    }

    get CanReadCurrentCustomers(): boolean {
        return this.canRead('CurrentCustomers');
    }

    get CanWriteCurrentCustomers(): boolean {
        return this.canWrite('CurrentCustomers');
    }

    get CurrentCustomers(): Party[] {
        return this.get('CurrentCustomers');
    }

    AddCurrentCustomer(value: Party) {
        return this.add('CurrentCustomers', value);
    }

    RemoveCurrentCustomer(value: Party) {
        return this.remove('CurrentCustomers', value);
    }

    set CurrentCustomers(value: Party[]) {
        this.set('CurrentCustomers', value);
    }

    get CanReadCurrentSuppliers(): boolean {
        return this.canRead('CurrentSuppliers');
    }

    get CanWriteCurrentSuppliers(): boolean {
        return this.canWrite('CurrentSuppliers');
    }

    get CurrentSuppliers(): Organisation[] {
        return this.get('CurrentSuppliers');
    }

    AddCurrentSupplier(value: Organisation) {
        return this.add('CurrentSuppliers', value);
    }

    RemoveCurrentSupplier(value: Organisation) {
        return this.remove('CurrentSuppliers', value);
    }

    set CurrentSuppliers(value: Organisation[]) {
        this.set('CurrentSuppliers', value);
    }

    get CanReadBankAccounts(): boolean {
        return this.canRead('BankAccounts');
    }

    get CanWriteBankAccounts(): boolean {
        return this.canWrite('BankAccounts');
    }

    get BankAccounts(): BankAccount[] {
        return this.get('BankAccounts');
    }

    AddBankAccount(value: BankAccount) {
        return this.add('BankAccounts', value);
    }

    RemoveBankAccount(value: BankAccount) {
        return this.remove('BankAccounts', value);
    }

    set BankAccounts(value: BankAccount[]) {
        this.set('BankAccounts', value);
    }

    get CanReadDefaultPaymentMethod(): boolean {
        return this.canRead('DefaultPaymentMethod');
    }

    get CanWriteDefaultPaymentMethod(): boolean {
        return this.canWrite('DefaultPaymentMethod');
    }

    get DefaultPaymentMethod(): PaymentMethod {
        return this.get('DefaultPaymentMethod');
    }

    set DefaultPaymentMethod(value: PaymentMethod) {
        this.set('DefaultPaymentMethod', value);
    }

    get CanReadVatRegime(): boolean {
        return this.canRead('VatRegime');
    }

    get CanWriteVatRegime(): boolean {
        return this.canWrite('VatRegime');
    }

    get VatRegime(): VatRegime {
        return this.get('VatRegime');
    }

    set VatRegime(value: VatRegime) {
        this.set('VatRegime', value);
    }

    get CanReadSalesReps(): boolean {
        return this.canRead('SalesReps');
    }

    get CanWriteSalesReps(): boolean {
        return this.canWrite('SalesReps');
    }

    get SalesReps(): Person[] {
        return this.get('SalesReps');
    }

    AddSalesRep(value: Person) {
        return this.add('SalesReps', value);
    }

    RemoveSalesRep(value: Person) {
        return this.remove('SalesReps', value);
    }

    set SalesReps(value: Person[]) {
        this.set('SalesReps', value);
    }

    get CanReadBillingAddress(): boolean {
        return this.canRead('BillingAddress');
    }

    get CanWriteBillingAddress(): boolean {
        return this.canWrite('BillingAddress');
    }

    get BillingAddress(): ContactMechanism {
        return this.get('BillingAddress');
    }

    set BillingAddress(value: ContactMechanism) {
        this.set('BillingAddress', value);
    }

    get CanReadOrderAddress(): boolean {
        return this.canRead('OrderAddress');
    }

    get CanWriteOrderAddress(): boolean {
        return this.canWrite('OrderAddress');
    }

    get OrderAddress(): ContactMechanism {
        return this.get('OrderAddress');
    }

    set OrderAddress(value: ContactMechanism) {
        this.set('OrderAddress', value);
    }

    get CanReadShippingAddress(): boolean {
        return this.canRead('ShippingAddress');
    }

    get CanWriteShippingAddress(): boolean {
        return this.canWrite('ShippingAddress');
    }

    get ShippingAddress(): PostalAddress {
        return this.get('ShippingAddress');
    }

    set ShippingAddress(value: PostalAddress) {
        this.set('ShippingAddress', value);
    }

    get CanReadActiveCustomers(): boolean {
        return this.canRead('ActiveCustomers');
    }

    get ActiveCustomers(): Party[] {
        return this.get('ActiveCustomers');
    }


    get CanReadActiveEmployees(): boolean {
        return this.canRead('ActiveEmployees');
    }

    get ActiveEmployees(): Person[] {
        return this.get('ActiveEmployees');
    }


    get CanReadActiveSuppliers(): boolean {
        return this.canRead('ActiveSuppliers');
    }

    get ActiveSuppliers(): Party[] {
        return this.get('ActiveSuppliers');
    }


    get CanReadUniqueId(): boolean {
        return this.canRead('UniqueId');
    }

    get CanWriteUniqueId(): boolean {
        return this.canWrite('UniqueId');
    }

    get UniqueId(): string {
        return this.get('UniqueId');
    }

    set UniqueId(value: string) {
        this.set('UniqueId', value);
    }

    get CanReadCreatedBy(): boolean {
        return this.canRead('CreatedBy');
    }

    get CanWriteCreatedBy(): boolean {
        return this.canWrite('CreatedBy');
    }

    get CreatedBy(): User {
        return this.get('CreatedBy');
    }

    set CreatedBy(value: User) {
        this.set('CreatedBy', value);
    }

    get CanReadLastModifiedBy(): boolean {
        return this.canRead('LastModifiedBy');
    }

    get CanWriteLastModifiedBy(): boolean {
        return this.canWrite('LastModifiedBy');
    }

    get LastModifiedBy(): User {
        return this.get('LastModifiedBy');
    }

    set LastModifiedBy(value: User) {
        this.set('LastModifiedBy', value);
    }

    get CanReadCreationDate(): boolean {
        return this.canRead('CreationDate');
    }

    get CanWriteCreationDate(): boolean {
        return this.canWrite('CreationDate');
    }

    get CreationDate(): Date {
        return this.get('CreationDate');
    }

    set CreationDate(value: Date) {
        this.set('CreationDate', value);
    }

    get CanReadLastModifiedDate(): boolean {
        return this.canRead('LastModifiedDate');
    }

    get CanWriteLastModifiedDate(): boolean {
        return this.canWrite('LastModifiedDate');
    }

    get LastModifiedDate(): Date {
        return this.get('LastModifiedDate');
    }

    set LastModifiedDate(value: Date) {
        this.set('LastModifiedDate', value);
    }


}
