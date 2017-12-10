// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";


export class GeneralLedgerAccountGroup extends SessionObject  {
    get CanReadParent(): boolean {
        return this.canRead('Parent');
    }

    get CanWriteParent(): boolean {
        return this.canWrite('Parent');
    }

    get Parent(): GeneralLedgerAccountGroup {
        return this.get('Parent');
    }

    set Parent(value: GeneralLedgerAccountGroup) {
        this.set('Parent', value);
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


}
