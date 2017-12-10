// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Request } from './Request.g';
import { Commentable } from './Commentable.g';
import { Auditable } from './Auditable.g';
import { Printable } from './Printable.g';
import { RequestForQuoteVersion } from './RequestForQuoteVersion.g';
import { RequestState } from './RequestState.g';
import { RequestItem } from './RequestItem.g';
import { RespondingParty } from './RespondingParty.g';
import { Party } from './Party.g';
import { Currency } from './Currency.g';
import { ContactMechanism } from './ContactMechanism.g';
import { Person } from './Person.g';
import { User } from './User.g';
import { QuoteVersion } from './QuoteVersion.g';
import { Quote } from './Quote.g';

export class RequestForQuote extends SessionObject implements Request {
    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): RequestForQuoteVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: RequestForQuoteVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): RequestForQuoteVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: RequestForQuoteVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: RequestForQuoteVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: RequestForQuoteVersion[]) {
        this.set('AllVersions', value);
    }

    get CanReadRequestState(): boolean {
        return this.canRead('RequestState');
    }

    get CanWriteRequestState(): boolean {
        return this.canWrite('RequestState');
    }

    get RequestState(): RequestState {
        return this.get('RequestState');
    }

    set RequestState(value: RequestState) {
        this.set('RequestState', value);
    }

    get CanReadInternalComment(): boolean {
        return this.canRead('InternalComment');
    }

    get CanWriteInternalComment(): boolean {
        return this.canWrite('InternalComment');
    }

    get InternalComment(): string {
        return this.get('InternalComment');
    }

    set InternalComment(value: string) {
        this.set('InternalComment', value);
    }

    get CanReadDescription(): boolean {
        return this.canRead('Description');
    }

    get CanWriteDescription(): boolean {
        return this.canWrite('Description');
    }

    get Description(): string {
        return this.get('Description');
    }

    set Description(value: string) {
        this.set('Description', value);
    }

    get CanReadRequestDate(): boolean {
        return this.canRead('RequestDate');
    }

    get CanWriteRequestDate(): boolean {
        return this.canWrite('RequestDate');
    }

    get RequestDate(): Date {
        return this.get('RequestDate');
    }

    set RequestDate(value: Date) {
        this.set('RequestDate', value);
    }

    get CanReadRequiredResponseDate(): boolean {
        return this.canRead('RequiredResponseDate');
    }

    get CanWriteRequiredResponseDate(): boolean {
        return this.canWrite('RequiredResponseDate');
    }

    get RequiredResponseDate(): Date {
        return this.get('RequiredResponseDate');
    }

    set RequiredResponseDate(value: Date) {
        this.set('RequiredResponseDate', value);
    }

    get CanReadRequestItems(): boolean {
        return this.canRead('RequestItems');
    }

    get CanWriteRequestItems(): boolean {
        return this.canWrite('RequestItems');
    }

    get RequestItems(): RequestItem[] {
        return this.get('RequestItems');
    }

    AddRequestItem(value: RequestItem) {
        return this.add('RequestItems', value);
    }

    RemoveRequestItem(value: RequestItem) {
        return this.remove('RequestItems', value);
    }

    set RequestItems(value: RequestItem[]) {
        this.set('RequestItems', value);
    }

    get CanReadRequestNumber(): boolean {
        return this.canRead('RequestNumber');
    }

    get CanWriteRequestNumber(): boolean {
        return this.canWrite('RequestNumber');
    }

    get RequestNumber(): string {
        return this.get('RequestNumber');
    }

    set RequestNumber(value: string) {
        this.set('RequestNumber', value);
    }

    get CanReadRespondingParties(): boolean {
        return this.canRead('RespondingParties');
    }

    get CanWriteRespondingParties(): boolean {
        return this.canWrite('RespondingParties');
    }

    get RespondingParties(): RespondingParty[] {
        return this.get('RespondingParties');
    }

    AddRespondingParty(value: RespondingParty) {
        return this.add('RespondingParties', value);
    }

    RemoveRespondingParty(value: RespondingParty) {
        return this.remove('RespondingParties', value);
    }

    set RespondingParties(value: RespondingParty[]) {
        this.set('RespondingParties', value);
    }

    get CanReadOriginator(): boolean {
        return this.canRead('Originator');
    }

    get CanWriteOriginator(): boolean {
        return this.canWrite('Originator');
    }

    get Originator(): Party {
        return this.get('Originator');
    }

    set Originator(value: Party) {
        this.set('Originator', value);
    }

    get CanReadCurrency(): boolean {
        return this.canRead('Currency');
    }

    get CanWriteCurrency(): boolean {
        return this.canWrite('Currency');
    }

    get Currency(): Currency {
        return this.get('Currency');
    }

    set Currency(value: Currency) {
        this.set('Currency', value);
    }

    get CanReadFullfillContactMechanism(): boolean {
        return this.canRead('FullfillContactMechanism');
    }

    get CanWriteFullfillContactMechanism(): boolean {
        return this.canWrite('FullfillContactMechanism');
    }

    get FullfillContactMechanism(): ContactMechanism {
        return this.get('FullfillContactMechanism');
    }

    set FullfillContactMechanism(value: ContactMechanism) {
        this.set('FullfillContactMechanism', value);
    }

    get CanReadEmailAddress(): boolean {
        return this.canRead('EmailAddress');
    }

    get CanWriteEmailAddress(): boolean {
        return this.canWrite('EmailAddress');
    }

    get EmailAddress(): string {
        return this.get('EmailAddress');
    }

    set EmailAddress(value: string) {
        this.set('EmailAddress', value);
    }

    get CanReadTelephoneNumber(): boolean {
        return this.canRead('TelephoneNumber');
    }

    get CanWriteTelephoneNumber(): boolean {
        return this.canWrite('TelephoneNumber');
    }

    get TelephoneNumber(): string {
        return this.get('TelephoneNumber');
    }

    set TelephoneNumber(value: string) {
        this.set('TelephoneNumber', value);
    }

    get CanReadTelephoneCountryCode(): boolean {
        return this.canRead('TelephoneCountryCode');
    }

    get CanWriteTelephoneCountryCode(): boolean {
        return this.canWrite('TelephoneCountryCode');
    }

    get TelephoneCountryCode(): string {
        return this.get('TelephoneCountryCode');
    }

    set TelephoneCountryCode(value: string) {
        this.set('TelephoneCountryCode', value);
    }

    get CanReadContactPerson(): boolean {
        return this.canRead('ContactPerson');
    }

    get CanWriteContactPerson(): boolean {
        return this.canWrite('ContactPerson');
    }

    get ContactPerson(): Person {
        return this.get('ContactPerson');
    }

    set ContactPerson(value: Person) {
        this.set('ContactPerson', value);
    }

    get CanReadComment(): boolean {
        return this.canRead('Comment');
    }

    get CanWriteComment(): boolean {
        return this.canWrite('Comment');
    }

    get Comment(): string {
        return this.get('Comment');
    }

    set Comment(value: string) {
        this.set('Comment', value);
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

    get CanReadPrintContent(): boolean {
        return this.canRead('PrintContent');
    }

    get CanWritePrintContent(): boolean {
        return this.canWrite('PrintContent');
    }

    get PrintContent(): string {
        return this.get('PrintContent');
    }

    set PrintContent(value: string) {
        this.set('PrintContent', value);
    }


    get CanExecuteCreateQuote(): boolean {
        return this.canExecute('CreateQuote');
    }

    get CreateQuote(): Method {
        return new Method(this, 'CreateQuote');
    }
    get CanExecuteCancel(): boolean {
        return this.canExecute('Cancel');
    }

    get Cancel(): Method {
        return new Method(this, 'Cancel');
    }
    get CanExecuteReject(): boolean {
        return this.canExecute('Reject');
    }

    get Reject(): Method {
        return new Method(this, 'Reject');
    }
    get CanExecuteSubmit(): boolean {
        return this.canExecute('Submit');
    }

    get Submit(): Method {
        return new Method(this, 'Submit');
    }
    get CanExecuteHold(): boolean {
        return this.canExecute('Hold');
    }

    get Hold(): Method {
        return new Method(this, 'Hold');
    }
}
