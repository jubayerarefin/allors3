// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Period } from './Period.g';
import { Deletable } from './Deletable.g';
import { Person } from './Person.g';
import { PayrollPreference } from './PayrollPreference.g';
import { EmploymentTerminationReason } from './EmploymentTerminationReason.g';
import { EmploymentTermination } from './EmploymentTermination.g';

export class Employment extends SessionObject implements Period, Deletable {
    get CanReadEmployee(): boolean {
        return this.canRead('Employee');
    }

    get CanWriteEmployee(): boolean {
        return this.canWrite('Employee');
    }

    get Employee(): Person {
        return this.get('Employee');
    }

    set Employee(value: Person) {
        this.set('Employee', value);
    }

    get CanReadPayrollPreferences(): boolean {
        return this.canRead('PayrollPreferences');
    }

    get CanWritePayrollPreferences(): boolean {
        return this.canWrite('PayrollPreferences');
    }

    get PayrollPreferences(): PayrollPreference[] {
        return this.get('PayrollPreferences');
    }

    AddPayrollPreference(value: PayrollPreference) {
        return this.add('PayrollPreferences', value);
    }

    RemovePayrollPreference(value: PayrollPreference) {
        return this.remove('PayrollPreferences', value);
    }

    set PayrollPreferences(value: PayrollPreference[]) {
        this.set('PayrollPreferences', value);
    }

    get CanReadEmploymentTerminationReason(): boolean {
        return this.canRead('EmploymentTerminationReason');
    }

    get CanWriteEmploymentTerminationReason(): boolean {
        return this.canWrite('EmploymentTerminationReason');
    }

    get EmploymentTerminationReason(): EmploymentTerminationReason {
        return this.get('EmploymentTerminationReason');
    }

    set EmploymentTerminationReason(value: EmploymentTerminationReason) {
        this.set('EmploymentTerminationReason', value);
    }

    get CanReadEmploymentTermination(): boolean {
        return this.canRead('EmploymentTermination');
    }

    get CanWriteEmploymentTermination(): boolean {
        return this.canWrite('EmploymentTermination');
    }

    get EmploymentTermination(): EmploymentTermination {
        return this.get('EmploymentTermination');
    }

    set EmploymentTermination(value: EmploymentTermination) {
        this.set('EmploymentTermination', value);
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


    get CanExecuteDelete(): boolean {
        return this.canExecute('Delete');
    }

    get Delete(): Method {
        return new Method(this, 'Delete');
    }
}
