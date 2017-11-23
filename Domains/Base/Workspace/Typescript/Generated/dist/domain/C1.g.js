"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const base_domain_1 = require("@allors/base-domain");
class C1 extends base_domain_1.SessionObject {
    get CanReadC1AllorsBinary() {
        return this.canRead('C1AllorsBinary');
    }
    get CanWriteC1AllorsBinary() {
        return this.canWrite('C1AllorsBinary');
    }
    get C1AllorsBinary() {
        return this.get('C1AllorsBinary');
    }
    set C1AllorsBinary(value) {
        this.set('C1AllorsBinary', value);
    }
    get CanReadC1AllorsString() {
        return this.canRead('C1AllorsString');
    }
    get CanWriteC1AllorsString() {
        return this.canWrite('C1AllorsString');
    }
    get C1AllorsString() {
        return this.get('C1AllorsString');
    }
    set C1AllorsString(value) {
        this.set('C1AllorsString', value);
    }
    get CanReadC1C1One2Manies() {
        return this.canRead('C1C1One2Manies');
    }
    get CanWriteC1C1One2Manies() {
        return this.canWrite('C1C1One2Manies');
    }
    get C1C1One2Manies() {
        return this.get('C1C1One2Manies');
    }
    AddC1C1One2Many(value) {
        return this.add('C1C1One2Manies', value);
    }
    RemoveC1C1One2Many(value) {
        return this.remove('C1C1One2Manies', value);
    }
    set C1C1One2Manies(value) {
        this.set('C1C1One2Manies', value);
    }
    get CanReadC1C1One2One() {
        return this.canRead('C1C1One2One');
    }
    get CanWriteC1C1One2One() {
        return this.canWrite('C1C1One2One');
    }
    get C1C1One2One() {
        return this.get('C1C1One2One');
    }
    set C1C1One2One(value) {
        this.set('C1C1One2One', value);
    }
    get CanReadI1AllorsString() {
        return this.canRead('I1AllorsString');
    }
    get CanWriteI1AllorsString() {
        return this.canWrite('I1AllorsString');
    }
    get I1AllorsString() {
        return this.get('I1AllorsString');
    }
    set I1AllorsString(value) {
        this.set('I1AllorsString', value);
    }
    get CanExecuteClassMethod() {
        return this.canExecute('ClassMethod');
    }
    get ClassMethod() {
        return new base_domain_1.Method(this, 'ClassMethod');
    }
}
exports.C1 = C1;
