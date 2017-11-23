// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/base-domain";

import { OrderVersion } from './OrderVersion.g';

export class Order extends SessionObject  {
    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): OrderVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: OrderVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): OrderVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: OrderVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: OrderVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: OrderVersion[]) {
        this.set('AllVersions', value);
    }


}
