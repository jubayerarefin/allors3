// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Shipment } from './Shipment.g';
import { Printable } from './Printable.g';
import { Commentable } from './Commentable.g';
import { Auditable } from './Auditable.g';
import { TransferState } from './TransferState.g';
import { TransferVersion } from './TransferVersion.g';
import { User } from './User.g';
import { SalesInvoiceVersion } from './SalesInvoiceVersion.g';
import { SalesInvoice } from './SalesInvoice.g';

export class Transfer extends SessionObject implements Shipment {
    get CanReadTransferState(): boolean {
        return this.canRead('TransferState');
    }

    get CanWriteTransferState(): boolean {
        return this.canWrite('TransferState');
    }

    get TransferState(): TransferState {
        return this.get('TransferState');
    }

    set TransferState(value: TransferState) {
        this.set('TransferState', value);
    }

    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): TransferVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: TransferVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): TransferVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: TransferVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: TransferVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: TransferVersion[]) {
        this.set('AllVersions', value);
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


}
