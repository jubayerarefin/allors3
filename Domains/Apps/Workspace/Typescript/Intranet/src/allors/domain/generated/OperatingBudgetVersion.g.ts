// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { BudgetVersion } from './BudgetVersion.g';
import { Version } from './Version.g';
import { BudgetState } from './BudgetState.g';
import { BudgetRevision } from './BudgetRevision.g';
import { BudgetReview } from './BudgetReview.g';
import { BudgetItem } from './BudgetItem.g';
import { OperatingBudget } from './OperatingBudget.g';

export class OperatingBudgetVersion extends SessionObject implements BudgetVersion {
    get CanReadBudgetState(): boolean {
        return this.canRead('BudgetState');
    }

    get CanWriteBudgetState(): boolean {
        return this.canWrite('BudgetState');
    }

    get BudgetState(): BudgetState {
        return this.get('BudgetState');
    }

    set BudgetState(value: BudgetState) {
        this.set('BudgetState', value);
    }

    get CanReadFromDate(): boolean {
        return this.canRead('FromDate');
    }

    get CanWriteFromDate(): boolean {
        return this.canWrite('FromDate');
    }

    get FromDate(): Date {
        return this.get('FromDate');
    }

    set FromDate(value: Date) {
        this.set('FromDate', value);
    }

    get CanReadThroughDate(): boolean {
        return this.canRead('ThroughDate');
    }

    get CanWriteThroughDate(): boolean {
        return this.canWrite('ThroughDate');
    }

    get ThroughDate(): Date {
        return this.get('ThroughDate');
    }

    set ThroughDate(value: Date) {
        this.set('ThroughDate', value);
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

    get CanReadBudgetRevisions(): boolean {
        return this.canRead('BudgetRevisions');
    }

    get CanWriteBudgetRevisions(): boolean {
        return this.canWrite('BudgetRevisions');
    }

    get BudgetRevisions(): BudgetRevision[] {
        return this.get('BudgetRevisions');
    }

    AddBudgetRevision(value: BudgetRevision) {
        return this.add('BudgetRevisions', value);
    }

    RemoveBudgetRevision(value: BudgetRevision) {
        return this.remove('BudgetRevisions', value);
    }

    set BudgetRevisions(value: BudgetRevision[]) {
        this.set('BudgetRevisions', value);
    }

    get CanReadBudgetNumber(): boolean {
        return this.canRead('BudgetNumber');
    }

    get CanWriteBudgetNumber(): boolean {
        return this.canWrite('BudgetNumber');
    }

    get BudgetNumber(): string {
        return this.get('BudgetNumber');
    }

    set BudgetNumber(value: string) {
        this.set('BudgetNumber', value);
    }

    get CanReadBudgetReviews(): boolean {
        return this.canRead('BudgetReviews');
    }

    get CanWriteBudgetReviews(): boolean {
        return this.canWrite('BudgetReviews');
    }

    get BudgetReviews(): BudgetReview[] {
        return this.get('BudgetReviews');
    }

    AddBudgetReview(value: BudgetReview) {
        return this.add('BudgetReviews', value);
    }

    RemoveBudgetReview(value: BudgetReview) {
        return this.remove('BudgetReviews', value);
    }

    set BudgetReviews(value: BudgetReview[]) {
        this.set('BudgetReviews', value);
    }

    get CanReadBudgetItems(): boolean {
        return this.canRead('BudgetItems');
    }

    get CanWriteBudgetItems(): boolean {
        return this.canWrite('BudgetItems');
    }

    get BudgetItems(): BudgetItem[] {
        return this.get('BudgetItems');
    }

    AddBudgetItem(value: BudgetItem) {
        return this.add('BudgetItems', value);
    }

    RemoveBudgetItem(value: BudgetItem) {
        return this.remove('BudgetItems', value);
    }

    set BudgetItems(value: BudgetItem[]) {
        this.set('BudgetItems', value);
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
