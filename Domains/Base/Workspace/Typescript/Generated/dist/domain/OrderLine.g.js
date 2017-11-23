"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const base_domain_1 = require("@allors/base-domain");
class OrderLine extends base_domain_1.SessionObject {
    get CanReadCurrentVersion() {
        return this.canRead('CurrentVersion');
    }
    get CanWriteCurrentVersion() {
        return this.canWrite('CurrentVersion');
    }
    get CurrentVersion() {
        return this.get('CurrentVersion');
    }
    set CurrentVersion(value) {
        this.set('CurrentVersion', value);
    }
    get CanReadAllVersions() {
        return this.canRead('AllVersions');
    }
    get CanWriteAllVersions() {
        return this.canWrite('AllVersions');
    }
    get AllVersions() {
        return this.get('AllVersions');
    }
    AddAllVersion(value) {
        return this.add('AllVersions', value);
    }
    RemoveAllVersion(value) {
        return this.remove('AllVersions', value);
    }
    set AllVersions(value) {
        this.set('AllVersions', value);
    }
}
exports.OrderLine = OrderLine;
