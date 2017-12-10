// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { ShipmentVersion } from './ShipmentVersion.g';
import { Version } from './Version.g';
import { CustomerShipmentState } from './CustomerShipmentState.g';
import { PaymentMethod } from './PaymentMethod.g';
import { ShipmentMethod } from './ShipmentMethod.g';
import { ContactMechanism } from './ContactMechanism.g';
import { ShipmentPackage } from './ShipmentPackage.g';
import { Document } from './Document.g';
import { Party } from './Party.g';
import { ShipmentItem } from './ShipmentItem.g';
import { PostalAddress } from './PostalAddress.g';
import { Carrier } from './Carrier.g';
import { Store } from './Store.g';
import { ShipmentRouteSegment } from './ShipmentRouteSegment.g';
import { CustomerShipment } from './CustomerShipment.g';

export class CustomerShipmentVersion extends SessionObject implements ShipmentVersion {
    get CanReadCustomerShipmentState(): boolean {
        return this.canRead('CustomerShipmentState');
    }

    get CanWriteCustomerShipmentState(): boolean {
        return this.canWrite('CustomerShipmentState');
    }

    get CustomerShipmentState(): CustomerShipmentState {
        return this.get('CustomerShipmentState');
    }

    set CustomerShipmentState(value: CustomerShipmentState) {
        this.set('CustomerShipmentState', value);
    }

    get CanReadReleasedManually(): boolean {
        return this.canRead('ReleasedManually');
    }

    get CanWriteReleasedManually(): boolean {
        return this.canWrite('ReleasedManually');
    }

    get ReleasedManually(): boolean {
        return this.get('ReleasedManually');
    }

    set ReleasedManually(value: boolean) {
        this.set('ReleasedManually', value);
    }

    get CanReadPaymentMethod(): boolean {
        return this.canRead('PaymentMethod');
    }

    get CanWritePaymentMethod(): boolean {
        return this.canWrite('PaymentMethod');
    }

    get PaymentMethod(): PaymentMethod {
        return this.get('PaymentMethod');
    }

    set PaymentMethod(value: PaymentMethod) {
        this.set('PaymentMethod', value);
    }

    get CanReadWithoutCharges(): boolean {
        return this.canRead('WithoutCharges');
    }

    get CanWriteWithoutCharges(): boolean {
        return this.canWrite('WithoutCharges');
    }

    get WithoutCharges(): boolean {
        return this.get('WithoutCharges');
    }

    set WithoutCharges(value: boolean) {
        this.set('WithoutCharges', value);
    }

    get CanReadHeldManually(): boolean {
        return this.canRead('HeldManually');
    }

    get CanWriteHeldManually(): boolean {
        return this.canWrite('HeldManually');
    }

    get HeldManually(): boolean {
        return this.get('HeldManually');
    }

    set HeldManually(value: boolean) {
        this.set('HeldManually', value);
    }

    get CanReadShipmentValue(): boolean {
        return this.canRead('ShipmentValue');
    }

    get ShipmentValue(): number {
        return this.get('ShipmentValue');
    }


    get CanReadShipmentMethod(): boolean {
        return this.canRead('ShipmentMethod');
    }

    get CanWriteShipmentMethod(): boolean {
        return this.canWrite('ShipmentMethod');
    }

    get ShipmentMethod(): ShipmentMethod {
        return this.get('ShipmentMethod');
    }

    set ShipmentMethod(value: ShipmentMethod) {
        this.set('ShipmentMethod', value);
    }

    get CanReadBillToContactMechanism(): boolean {
        return this.canRead('BillToContactMechanism');
    }

    get CanWriteBillToContactMechanism(): boolean {
        return this.canWrite('BillToContactMechanism');
    }

    get BillToContactMechanism(): ContactMechanism {
        return this.get('BillToContactMechanism');
    }

    set BillToContactMechanism(value: ContactMechanism) {
        this.set('BillToContactMechanism', value);
    }

    get CanReadShipmentPackages(): boolean {
        return this.canRead('ShipmentPackages');
    }

    get CanWriteShipmentPackages(): boolean {
        return this.canWrite('ShipmentPackages');
    }

    get ShipmentPackages(): ShipmentPackage[] {
        return this.get('ShipmentPackages');
    }

    AddShipmentPackage(value: ShipmentPackage) {
        return this.add('ShipmentPackages', value);
    }

    RemoveShipmentPackage(value: ShipmentPackage) {
        return this.remove('ShipmentPackages', value);
    }

    set ShipmentPackages(value: ShipmentPackage[]) {
        this.set('ShipmentPackages', value);
    }

    get CanReadShipmentNumber(): boolean {
        return this.canRead('ShipmentNumber');
    }

    get CanWriteShipmentNumber(): boolean {
        return this.canWrite('ShipmentNumber');
    }

    get ShipmentNumber(): string {
        return this.get('ShipmentNumber');
    }

    set ShipmentNumber(value: string) {
        this.set('ShipmentNumber', value);
    }

    get CanReadDocuments(): boolean {
        return this.canRead('Documents');
    }

    get CanWriteDocuments(): boolean {
        return this.canWrite('Documents');
    }

    get Documents(): Document[] {
        return this.get('Documents');
    }

    AddDocument(value: Document) {
        return this.add('Documents', value);
    }

    RemoveDocument(value: Document) {
        return this.remove('Documents', value);
    }

    set Documents(value: Document[]) {
        this.set('Documents', value);
    }

    get CanReadBillToParty(): boolean {
        return this.canRead('BillToParty');
    }

    get CanWriteBillToParty(): boolean {
        return this.canWrite('BillToParty');
    }

    get BillToParty(): Party {
        return this.get('BillToParty');
    }

    set BillToParty(value: Party) {
        this.set('BillToParty', value);
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

    get CanReadShipmentItems(): boolean {
        return this.canRead('ShipmentItems');
    }

    get CanWriteShipmentItems(): boolean {
        return this.canWrite('ShipmentItems');
    }

    get ShipmentItems(): ShipmentItem[] {
        return this.get('ShipmentItems');
    }

    AddShipmentItem(value: ShipmentItem) {
        return this.add('ShipmentItems', value);
    }

    RemoveShipmentItem(value: ShipmentItem) {
        return this.remove('ShipmentItems', value);
    }

    set ShipmentItems(value: ShipmentItem[]) {
        this.set('ShipmentItems', value);
    }

    get CanReadReceiverContactMechanism(): boolean {
        return this.canRead('ReceiverContactMechanism');
    }

    get CanWriteReceiverContactMechanism(): boolean {
        return this.canWrite('ReceiverContactMechanism');
    }

    get ReceiverContactMechanism(): ContactMechanism {
        return this.get('ReceiverContactMechanism');
    }

    set ReceiverContactMechanism(value: ContactMechanism) {
        this.set('ReceiverContactMechanism', value);
    }

    get CanReadShipToAddress(): boolean {
        return this.canRead('ShipToAddress');
    }

    get CanWriteShipToAddress(): boolean {
        return this.canWrite('ShipToAddress');
    }

    get ShipToAddress(): PostalAddress {
        return this.get('ShipToAddress');
    }

    set ShipToAddress(value: PostalAddress) {
        this.set('ShipToAddress', value);
    }

    get CanReadEstimatedShipCost(): boolean {
        return this.canRead('EstimatedShipCost');
    }

    get CanWriteEstimatedShipCost(): boolean {
        return this.canWrite('EstimatedShipCost');
    }

    get EstimatedShipCost(): number {
        return this.get('EstimatedShipCost');
    }

    set EstimatedShipCost(value: number) {
        this.set('EstimatedShipCost', value);
    }

    get CanReadEstimatedShipDate(): boolean {
        return this.canRead('EstimatedShipDate');
    }

    get CanWriteEstimatedShipDate(): boolean {
        return this.canWrite('EstimatedShipDate');
    }

    get EstimatedShipDate(): Date {
        return this.get('EstimatedShipDate');
    }

    set EstimatedShipDate(value: Date) {
        this.set('EstimatedShipDate', value);
    }

    get CanReadLatestCancelDate(): boolean {
        return this.canRead('LatestCancelDate');
    }

    get CanWriteLatestCancelDate(): boolean {
        return this.canWrite('LatestCancelDate');
    }

    get LatestCancelDate(): Date {
        return this.get('LatestCancelDate');
    }

    set LatestCancelDate(value: Date) {
        this.set('LatestCancelDate', value);
    }

    get CanReadCarrier(): boolean {
        return this.canRead('Carrier');
    }

    get CanWriteCarrier(): boolean {
        return this.canWrite('Carrier');
    }

    get Carrier(): Carrier {
        return this.get('Carrier');
    }

    set Carrier(value: Carrier) {
        this.set('Carrier', value);
    }

    get CanReadInquireAboutContactMechanism(): boolean {
        return this.canRead('InquireAboutContactMechanism');
    }

    get CanWriteInquireAboutContactMechanism(): boolean {
        return this.canWrite('InquireAboutContactMechanism');
    }

    get InquireAboutContactMechanism(): ContactMechanism {
        return this.get('InquireAboutContactMechanism');
    }

    set InquireAboutContactMechanism(value: ContactMechanism) {
        this.set('InquireAboutContactMechanism', value);
    }

    get CanReadEstimatedReadyDate(): boolean {
        return this.canRead('EstimatedReadyDate');
    }

    get CanWriteEstimatedReadyDate(): boolean {
        return this.canWrite('EstimatedReadyDate');
    }

    get EstimatedReadyDate(): Date {
        return this.get('EstimatedReadyDate');
    }

    set EstimatedReadyDate(value: Date) {
        this.set('EstimatedReadyDate', value);
    }

    get CanReadShipFromAddress(): boolean {
        return this.canRead('ShipFromAddress');
    }

    get CanWriteShipFromAddress(): boolean {
        return this.canWrite('ShipFromAddress');
    }

    get ShipFromAddress(): PostalAddress {
        return this.get('ShipFromAddress');
    }

    set ShipFromAddress(value: PostalAddress) {
        this.set('ShipFromAddress', value);
    }

    get CanReadBillFromContactMechanism(): boolean {
        return this.canRead('BillFromContactMechanism');
    }

    get BillFromContactMechanism(): ContactMechanism {
        return this.get('BillFromContactMechanism');
    }


    get CanReadHandlingInstruction(): boolean {
        return this.canRead('HandlingInstruction');
    }

    get CanWriteHandlingInstruction(): boolean {
        return this.canWrite('HandlingInstruction');
    }

    get HandlingInstruction(): string {
        return this.get('HandlingInstruction');
    }

    set HandlingInstruction(value: string) {
        this.set('HandlingInstruction', value);
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

    get CanReadShipFromParty(): boolean {
        return this.canRead('ShipFromParty');
    }

    get CanWriteShipFromParty(): boolean {
        return this.canWrite('ShipFromParty');
    }

    get ShipFromParty(): Party {
        return this.get('ShipFromParty');
    }

    set ShipFromParty(value: Party) {
        this.set('ShipFromParty', value);
    }

    get CanReadShipmentRouteSegments(): boolean {
        return this.canRead('ShipmentRouteSegments');
    }

    get CanWriteShipmentRouteSegments(): boolean {
        return this.canWrite('ShipmentRouteSegments');
    }

    get ShipmentRouteSegments(): ShipmentRouteSegment[] {
        return this.get('ShipmentRouteSegments');
    }

    AddShipmentRouteSegment(value: ShipmentRouteSegment) {
        return this.add('ShipmentRouteSegments', value);
    }

    RemoveShipmentRouteSegment(value: ShipmentRouteSegment) {
        return this.remove('ShipmentRouteSegments', value);
    }

    set ShipmentRouteSegments(value: ShipmentRouteSegment[]) {
        this.set('ShipmentRouteSegments', value);
    }

    get CanReadEstimatedArrivalDate(): boolean {
        return this.canRead('EstimatedArrivalDate');
    }

    get CanWriteEstimatedArrivalDate(): boolean {
        return this.canWrite('EstimatedArrivalDate');
    }

    get EstimatedArrivalDate(): Date {
        return this.get('EstimatedArrivalDate');
    }

    set EstimatedArrivalDate(value: Date) {
        this.set('EstimatedArrivalDate', value);
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
