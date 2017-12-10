// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Commentable } from './Commentable.g';
import { Deletable } from './Deletable.g';
import { QuoteItemState } from './QuoteItemState.g';
import { QuoteItemVersion } from './QuoteItemVersion.g';
import { Party } from './Party.g';
import { Deliverable } from './Deliverable.g';
import { Product } from './Product.g';
import { UnitOfMeasure } from './UnitOfMeasure.g';
import { ProductFeature } from './ProductFeature.g';
import { Skill } from './Skill.g';
import { WorkEffort } from './WorkEffort.g';
import { QuoteTerm } from './QuoteTerm.g';
import { RequestItem } from './RequestItem.g';
import { OrderItemVersion } from './OrderItemVersion.g';
import { QuoteVersion } from './QuoteVersion.g';
import { OrderItem } from './OrderItem.g';
import { Quote } from './Quote.g';

export class QuoteItem extends SessionObject implements Commentable, Deletable {
    get CanReadQuoteItemState(): boolean {
        return this.canRead('QuoteItemState');
    }

    get CanWriteQuoteItemState(): boolean {
        return this.canWrite('QuoteItemState');
    }

    get QuoteItemState(): QuoteItemState {
        return this.get('QuoteItemState');
    }

    set QuoteItemState(value: QuoteItemState) {
        this.set('QuoteItemState', value);
    }

    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): QuoteItemVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: QuoteItemVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): QuoteItemVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: QuoteItemVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: QuoteItemVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: QuoteItemVersion[]) {
        this.set('AllVersions', value);
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

    get CanReadAuthorizer(): boolean {
        return this.canRead('Authorizer');
    }

    get CanWriteAuthorizer(): boolean {
        return this.canWrite('Authorizer');
    }

    get Authorizer(): Party {
        return this.get('Authorizer');
    }

    set Authorizer(value: Party) {
        this.set('Authorizer', value);
    }

    get CanReadDeliverable(): boolean {
        return this.canRead('Deliverable');
    }

    get CanWriteDeliverable(): boolean {
        return this.canWrite('Deliverable');
    }

    get Deliverable(): Deliverable {
        return this.get('Deliverable');
    }

    set Deliverable(value: Deliverable) {
        this.set('Deliverable', value);
    }

    get CanReadProduct(): boolean {
        return this.canRead('Product');
    }

    get CanWriteProduct(): boolean {
        return this.canWrite('Product');
    }

    get Product(): Product {
        return this.get('Product');
    }

    set Product(value: Product) {
        this.set('Product', value);
    }

    get CanReadEstimatedDeliveryDate(): boolean {
        return this.canRead('EstimatedDeliveryDate');
    }

    get CanWriteEstimatedDeliveryDate(): boolean {
        return this.canWrite('EstimatedDeliveryDate');
    }

    get EstimatedDeliveryDate(): Date {
        return this.get('EstimatedDeliveryDate');
    }

    set EstimatedDeliveryDate(value: Date) {
        this.set('EstimatedDeliveryDate', value);
    }

    get CanReadRequiredByDate(): boolean {
        return this.canRead('RequiredByDate');
    }

    get RequiredByDate(): Date {
        return this.get('RequiredByDate');
    }


    get CanReadUnitOfMeasure(): boolean {
        return this.canRead('UnitOfMeasure');
    }

    get CanWriteUnitOfMeasure(): boolean {
        return this.canWrite('UnitOfMeasure');
    }

    get UnitOfMeasure(): UnitOfMeasure {
        return this.get('UnitOfMeasure');
    }

    set UnitOfMeasure(value: UnitOfMeasure) {
        this.set('UnitOfMeasure', value);
    }

    get CanReadProductFeature(): boolean {
        return this.canRead('ProductFeature');
    }

    get CanWriteProductFeature(): boolean {
        return this.canWrite('ProductFeature');
    }

    get ProductFeature(): ProductFeature {
        return this.get('ProductFeature');
    }

    set ProductFeature(value: ProductFeature) {
        this.set('ProductFeature', value);
    }

    get CanReadUnitPrice(): boolean {
        return this.canRead('UnitPrice');
    }

    get CanWriteUnitPrice(): boolean {
        return this.canWrite('UnitPrice');
    }

    get UnitPrice(): number {
        return this.get('UnitPrice');
    }

    set UnitPrice(value: number) {
        this.set('UnitPrice', value);
    }

    get CanReadSkill(): boolean {
        return this.canRead('Skill');
    }

    get CanWriteSkill(): boolean {
        return this.canWrite('Skill');
    }

    get Skill(): Skill {
        return this.get('Skill');
    }

    set Skill(value: Skill) {
        this.set('Skill', value);
    }

    get CanReadWorkEffort(): boolean {
        return this.canRead('WorkEffort');
    }

    get CanWriteWorkEffort(): boolean {
        return this.canWrite('WorkEffort');
    }

    get WorkEffort(): WorkEffort {
        return this.get('WorkEffort');
    }

    set WorkEffort(value: WorkEffort) {
        this.set('WorkEffort', value);
    }

    get CanReadQuoteTerms(): boolean {
        return this.canRead('QuoteTerms');
    }

    get CanWriteQuoteTerms(): boolean {
        return this.canWrite('QuoteTerms');
    }

    get QuoteTerms(): QuoteTerm[] {
        return this.get('QuoteTerms');
    }

    AddQuoteTerm(value: QuoteTerm) {
        return this.add('QuoteTerms', value);
    }

    RemoveQuoteTerm(value: QuoteTerm) {
        return this.remove('QuoteTerms', value);
    }

    set QuoteTerms(value: QuoteTerm[]) {
        this.set('QuoteTerms', value);
    }

    get CanReadQuantity(): boolean {
        return this.canRead('Quantity');
    }

    get CanWriteQuantity(): boolean {
        return this.canWrite('Quantity');
    }

    get Quantity(): number {
        return this.get('Quantity');
    }

    set Quantity(value: number) {
        this.set('Quantity', value);
    }

    get CanReadRequestItem(): boolean {
        return this.canRead('RequestItem');
    }

    get CanWriteRequestItem(): boolean {
        return this.canWrite('RequestItem');
    }

    get RequestItem(): RequestItem {
        return this.get('RequestItem');
    }

    set RequestItem(value: RequestItem) {
        this.set('RequestItem', value);
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


    get CanExecuteCancel(): boolean {
        return this.canExecute('Cancel');
    }

    get Cancel(): Method {
        return new Method(this, 'Cancel');
    }
    get CanExecuteSubmit(): boolean {
        return this.canExecute('Submit');
    }

    get Submit(): Method {
        return new Method(this, 'Submit');
    }
    get CanExecuteDelete(): boolean {
        return this.canExecute('Delete');
    }

    get Delete(): Method {
        return new Method(this, 'Delete');
    }
}
