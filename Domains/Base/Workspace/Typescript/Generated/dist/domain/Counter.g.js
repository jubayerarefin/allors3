"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const base_domain_1 = require("@allors/base-domain");
class Counter extends base_domain_1.SessionObject {
    get CanReadUniqueId() {
        return this.canRead('UniqueId');
    }
    get CanWriteUniqueId() {
        return this.canWrite('UniqueId');
    }
    get UniqueId() {
        return this.get('UniqueId');
    }
    set UniqueId(value) {
        this.set('UniqueId', value);
    }
}
exports.Counter = Counter;
