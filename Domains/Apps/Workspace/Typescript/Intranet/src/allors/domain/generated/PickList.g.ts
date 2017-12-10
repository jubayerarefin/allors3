// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Printable } from './Printable.g';
import { PickListState } from './PickListState.g';
import { PickListVersion } from './PickListVersion.g';
import { CustomerShipment } from './CustomerShipment.g';
import { PickListItem } from './PickListItem.g';
import { Person } from './Person.g';
import { Party } from './Party.g';
import { Store } from './Store.g';

export class PickList extends SessionObject implements Printable {
    get CanReadPickListState(): boolean {
        return this.canRead('PickListState');
    }

    get CanWritePickListState(): boolean {
        return this.canWrite('PickListState');
    }

    get PickListState(): PickListState {
        return this.get('PickListState');
    }

    set PickListState(value: PickListState) {
        this.set('PickListState', value);
    }

    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): PickListVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: PickListVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): PickListVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: PickListVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: PickListVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: PickListVersion[]) {
        this.set('AllVersions', value);
    }

    get CanReadCustomerShipmentCorrection(): boolean {
        return this.canRead('CustomerShipmentCorrection');
    }

    get CanWriteCustomerShipmentCorrection(): boolean {
        return this.canWrite('CustomerShipmentCorrection');
    }

    get CustomerShipmentCorrection(): CustomerShipment {
        return this.get('CustomerShipmentCorrection');
    }

    set CustomerShipmentCorrection(value: CustomerShipment) {
        this.set('CustomerShipmentCorrection', value);
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

    get CanReadPickListItems(): boolean {
        return this.canRead('PickListItems');
    }

    get CanWritePickListItems(): boolean {
        return this.canWrite('PickListItems');
    }

    get PickListItems(): PickListItem[] {
        return this.get('PickListItems');
    }

    AddPickListItem(value: PickListItem) {
        return this.add('PickListItems', value);
    }

    RemovePickListItem(value: PickListItem) {
        return this.remove('PickListItems', value);
    }

    set PickListItems(value: PickListItem[]) {
        this.set('PickListItems', value);
    }

    get CanReadPicker(): boolean {
        return this.canRead('Picker');
    }

    get CanWritePicker(): boolean {
        return this.canWrite('Picker');
    }

    get Picker(): Person {
        return this.get('Picker');
    }

    set Picker(value: Person) {
        this.set('Picker', value);
    }

    get CanReadShipToParty(): boolean {
        return this.canRead('ShipToParty');
    }

    get CanWriteShipToParty(): boolean {
        return this.canWrite('ShipToParty');
    }

    get ShipToParty(): Party {
        return this.get('ShipToParty');
    }

    set ShipToParty(value: Party) {
        this.set('ShipToParty', value);
    }

    get CanReadStore(): boolean {
        return this.canRead('Store');
    }

    get CanWriteStore(): boolean {
        return this.canWrite('Store');
    }

    get Store(): Store {
        return this.get('Store');
    }

    set Store(value: Store) {
        this.set('Store', value);
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


}
