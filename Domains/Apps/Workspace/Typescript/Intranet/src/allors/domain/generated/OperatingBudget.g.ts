// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Budget } from './Budget.g';
import { Period } from './Period.g';
import { Commentable } from './Commentable.g';
import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { OperatingBudgetVersion } from './OperatingBudgetVersion.g';
import { BudgetState } from './BudgetState.g';

export class OperatingBudget extends SessionObject implements Budget {
    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): OperatingBudgetVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: OperatingBudgetVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): OperatingBudgetVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: OperatingBudgetVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: OperatingBudgetVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: OperatingBudgetVersion[]) {
        this.set('AllVersions', value);
    }

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


}
