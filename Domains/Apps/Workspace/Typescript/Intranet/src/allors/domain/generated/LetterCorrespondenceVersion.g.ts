// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { CommunicationEventVersion } from './CommunicationEventVersion.g';
import { Version } from './Version.g';
import { PostalAddress } from './PostalAddress.g';
import { Party } from './Party.g';
import { CommunicationEventState } from './CommunicationEventState.g';
import { User } from './User.g';
import { ContactMechanism } from './ContactMechanism.g';
import { CommunicationEventPurpose } from './CommunicationEventPurpose.g';
import { WorkEffort } from './WorkEffort.g';
import { Media } from './Media.g';
import { Case } from './Case.g';
import { Priority } from './Priority.g';
import { Person } from './Person.g';
import { LetterCorrespondence } from './LetterCorrespondence.g';

export class LetterCorrespondenceVersion extends SessionObject implements CommunicationEventVersion {
    get CanReadPostalAddresses(): boolean {
        return this.canRead('PostalAddresses');
    }

    get CanWritePostalAddresses(): boolean {
        return this.canWrite('PostalAddresses');
    }

    get PostalAddresses(): PostalAddress[] {
        return this.get('PostalAddresses');
    }

    AddPostalAddress(value: PostalAddress) {
        return this.add('PostalAddresses', value);
    }

    RemovePostalAddress(value: PostalAddress) {
        return this.remove('PostalAddresses', value);
    }

    set PostalAddresses(value: PostalAddress[]) {
        this.set('PostalAddresses', value);
    }

    get CanReadOriginators(): boolean {
        return this.canRead('Originators');
    }

    get CanWriteOriginators(): boolean {
        return this.canWrite('Originators');
    }

    get Originators(): Party[] {
        return this.get('Originators');
    }

    AddOriginator(value: Party) {
        return this.add('Originators', value);
    }

    RemoveOriginator(value: Party) {
        return this.remove('Originators', value);
    }

    set Originators(value: Party[]) {
        this.set('Originators', value);
    }

    get CanReadReceivers(): boolean {
        return this.canRead('Receivers');
    }

    get CanWriteReceivers(): boolean {
        return this.canWrite('Receivers');
    }

    get Receivers(): Party[] {
        return this.get('Receivers');
    }

    AddReceiver(value: Party) {
        return this.add('Receivers', value);
    }

    RemoveReceiver(value: Party) {
        return this.remove('Receivers', value);
    }

    set Receivers(value: Party[]) {
        this.set('Receivers', value);
    }

    get CanReadIncomingLetter(): boolean {
        return this.canRead('IncomingLetter');
    }

    get CanWriteIncomingLetter(): boolean {
        return this.canWrite('IncomingLetter');
    }

    get IncomingLetter(): boolean {
        return this.get('IncomingLetter');
    }

    set IncomingLetter(value: boolean) {
        this.set('IncomingLetter', value);
    }

    get CanReadCommunicationEventState(): boolean {
        return this.canRead('CommunicationEventState');
    }

    get CommunicationEventState(): CommunicationEventState {
        return this.get('CommunicationEventState');
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

    get CanReadScheduledStart(): boolean {
        return this.canRead('ScheduledStart');
    }

    get CanWriteScheduledStart(): boolean {
        return this.canWrite('ScheduledStart');
    }

    get ScheduledStart(): Date {
        return this.get('ScheduledStart');
    }

    set ScheduledStart(value: Date) {
        this.set('ScheduledStart', value);
    }

    get CanReadToParties(): boolean {
        return this.canRead('ToParties');
    }

    get ToParties(): Party[] {
        return this.get('ToParties');
    }


    get CanReadContactMechanisms(): boolean {
        return this.canRead('ContactMechanisms');
    }

    get CanWriteContactMechanisms(): boolean {
        return this.canWrite('ContactMechanisms');
    }

    get ContactMechanisms(): ContactMechanism[] {
        return this.get('ContactMechanisms');
    }

    AddContactMechanism(value: ContactMechanism) {
        return this.add('ContactMechanisms', value);
    }

    RemoveContactMechanism(value: ContactMechanism) {
        return this.remove('ContactMechanisms', value);
    }

    set ContactMechanisms(value: ContactMechanism[]) {
        this.set('ContactMechanisms', value);
    }

    get CanReadInvolvedParties(): boolean {
        return this.canRead('InvolvedParties');
    }

    get InvolvedParties(): Party[] {
        return this.get('InvolvedParties');
    }


    get CanReadInitialScheduledStart(): boolean {
        return this.canRead('InitialScheduledStart');
    }

    get CanWriteInitialScheduledStart(): boolean {
        return this.canWrite('InitialScheduledStart');
    }

    get InitialScheduledStart(): Date {
        return this.get('InitialScheduledStart');
    }

    set InitialScheduledStart(value: Date) {
        this.set('InitialScheduledStart', value);
    }

    get CanReadEventPurposes(): boolean {
        return this.canRead('EventPurposes');
    }

    get CanWriteEventPurposes(): boolean {
        return this.canWrite('EventPurposes');
    }

    get EventPurposes(): CommunicationEventPurpose[] {
        return this.get('EventPurposes');
    }

    AddEventPurpose(value: CommunicationEventPurpose) {
        return this.add('EventPurposes', value);
    }

    RemoveEventPurpose(value: CommunicationEventPurpose) {
        return this.remove('EventPurposes', value);
    }

    set EventPurposes(value: CommunicationEventPurpose[]) {
        this.set('EventPurposes', value);
    }

    get CanReadScheduledEnd(): boolean {
        return this.canRead('ScheduledEnd');
    }

    get CanWriteScheduledEnd(): boolean {
        return this.canWrite('ScheduledEnd');
    }

    get ScheduledEnd(): Date {
        return this.get('ScheduledEnd');
    }

    set ScheduledEnd(value: Date) {
        this.set('ScheduledEnd', value);
    }

    get CanReadActualEnd(): boolean {
        return this.canRead('ActualEnd');
    }

    get CanWriteActualEnd(): boolean {
        return this.canWrite('ActualEnd');
    }

    get ActualEnd(): Date {
        return this.get('ActualEnd');
    }

    set ActualEnd(value: Date) {
        this.set('ActualEnd', value);
    }

    get CanReadWorkEfforts(): boolean {
        return this.canRead('WorkEfforts');
    }

    get CanWriteWorkEfforts(): boolean {
        return this.canWrite('WorkEfforts');
    }

    get WorkEfforts(): WorkEffort[] {
        return this.get('WorkEfforts');
    }

    AddWorkEffort(value: WorkEffort) {
        return this.add('WorkEfforts', value);
    }

    RemoveWorkEffort(value: WorkEffort) {
        return this.remove('WorkEfforts', value);
    }

    set WorkEfforts(value: WorkEffort[]) {
        this.set('WorkEfforts', value);
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

    get CanReadInitialScheduledEnd(): boolean {
        return this.canRead('InitialScheduledEnd');
    }

    get CanWriteInitialScheduledEnd(): boolean {
        return this.canWrite('InitialScheduledEnd');
    }

    get InitialScheduledEnd(): Date {
        return this.get('InitialScheduledEnd');
    }

    set InitialScheduledEnd(value: Date) {
        this.set('InitialScheduledEnd', value);
    }

    get CanReadFromParties(): boolean {
        return this.canRead('FromParties');
    }

    get FromParties(): Party[] {
        return this.get('FromParties');
    }


    get CanReadSubject(): boolean {
        return this.canRead('Subject');
    }

    get CanWriteSubject(): boolean {
        return this.canWrite('Subject');
    }

    get Subject(): string {
        return this.get('Subject');
    }

    set Subject(value: string) {
        this.set('Subject', value);
    }

    get CanReadDocuments(): boolean {
        return this.canRead('Documents');
    }

    get CanWriteDocuments(): boolean {
        return this.canWrite('Documents');
    }

    get Documents(): Media[] {
        return this.get('Documents');
    }

    AddDocument(value: Media) {
        return this.add('Documents', value);
    }

    RemoveDocument(value: Media) {
        return this.remove('Documents', value);
    }

    set Documents(value: Media[]) {
        this.set('Documents', value);
    }

    get CanReadCase(): boolean {
        return this.canRead('Case');
    }

    get CanWriteCase(): boolean {
        return this.canWrite('Case');
    }

    get Case(): Case {
        return this.get('Case');
    }

    set Case(value: Case) {
        this.set('Case', value);
    }

    get CanReadPriority(): boolean {
        return this.canRead('Priority');
    }

    get CanWritePriority(): boolean {
        return this.canWrite('Priority');
    }

    get Priority(): Priority {
        return this.get('Priority');
    }

    set Priority(value: Priority) {
        this.set('Priority', value);
    }

    get CanReadOwner(): boolean {
        return this.canRead('Owner');
    }

    get CanWriteOwner(): boolean {
        return this.canWrite('Owner');
    }

    get Owner(): Person {
        return this.get('Owner');
    }

    set Owner(value: Person) {
        this.set('Owner', value);
    }

    get CanReadNote(): boolean {
        return this.canRead('Note');
    }

    get CanWriteNote(): boolean {
        return this.canWrite('Note');
    }

    get Note(): string {
        return this.get('Note');
    }

    set Note(value: string) {
        this.set('Note', value);
    }

    get CanReadActualStart(): boolean {
        return this.canRead('ActualStart');
    }

    get CanWriteActualStart(): boolean {
        return this.canWrite('ActualStart');
    }

    get ActualStart(): Date {
        return this.get('ActualStart');
    }

    set ActualStart(value: Date) {
        this.set('ActualStart', value);
    }

    get CanReadSendNotification(): boolean {
        return this.canRead('SendNotification');
    }

    get CanWriteSendNotification(): boolean {
        return this.canWrite('SendNotification');
    }

    get SendNotification(): boolean {
        return this.get('SendNotification');
    }

    set SendNotification(value: boolean) {
        this.set('SendNotification', value);
    }

    get CanReadSendReminder(): boolean {
        return this.canRead('SendReminder');
    }

    get CanWriteSendReminder(): boolean {
        return this.canWrite('SendReminder');
    }

    get SendReminder(): boolean {
        return this.get('SendReminder');
    }

    set SendReminder(value: boolean) {
        this.set('SendReminder', value);
    }

    get CanReadRemindAt(): boolean {
        return this.canRead('RemindAt');
    }

    get CanWriteRemindAt(): boolean {
        return this.canWrite('RemindAt');
    }

    get RemindAt(): Date {
        return this.get('RemindAt');
    }

    set RemindAt(value: Date) {
        this.set('RemindAt', value);
    }

    get CanReadDerivationTimeStamp(): boolean {
        return this.canRead('DerivationTimeStamp');
    }

    get CanWriteDerivationTimeStamp(): boolean {
        return this.canWrite('DerivationTimeStamp');
    }

    get DerivationTimeStamp(): Date {
        return this.get('DerivationTimeStamp');
    }

    set DerivationTimeStamp(value: Date) {
        this.set('DerivationTimeStamp', value);
    }


}
