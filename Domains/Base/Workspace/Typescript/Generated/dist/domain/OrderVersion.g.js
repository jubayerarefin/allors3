"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const base_domain_1 = require("@allors/base-domain");
class OrderVersion extends base_domain_1.SessionObject {
    get CanReadDerivationTimeStamp() {
        return this.canRead('DerivationTimeStamp');
    }
    get CanWriteDerivationTimeStamp() {
        return this.canWrite('DerivationTimeStamp');
    }
    get DerivationTimeStamp() {
        return this.get('DerivationTimeStamp');
    }
    set DerivationTimeStamp(value) {
        this.set('DerivationTimeStamp', value);
    }
}
exports.OrderVersion = OrderVersion;
