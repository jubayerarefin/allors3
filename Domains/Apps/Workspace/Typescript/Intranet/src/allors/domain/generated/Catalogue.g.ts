// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { Deletable } from './Deletable.g';
import { LocalisedText } from './LocalisedText.g';
import { Media } from './Media.g';
import { ProductCategory } from './ProductCategory.g';
import { CatScope } from './CatScope.g';
import { Store } from './Store.g';

export class Catalogue extends SessionObject implements UniquelyIdentifiable, Deletable {
    get CanReadName(): boolean {
        return this.canRead('Name');
    }

    get Name(): string {
        return this.get('Name');
    }


    get CanReadDescription(): boolean {
        return this.canRead('Description');
    }

    get Description(): string {
        return this.get('Description');
    }


    get CanReadLocalisedNames(): boolean {
        return this.canRead('LocalisedNames');
    }

    get CanWriteLocalisedNames(): boolean {
        return this.canWrite('LocalisedNames');
    }

    get LocalisedNames(): LocalisedText[] {
        return this.get('LocalisedNames');
    }

    AddLocalisedName(value: LocalisedText) {
        return this.add('LocalisedNames', value);
    }

    RemoveLocalisedName(value: LocalisedText) {
        return this.remove('LocalisedNames', value);
    }

    set LocalisedNames(value: LocalisedText[]) {
        this.set('LocalisedNames', value);
    }

    get CanReadLocalisedDescriptions(): boolean {
        return this.canRead('LocalisedDescriptions');
    }

    get CanWriteLocalisedDescriptions(): boolean {
        return this.canWrite('LocalisedDescriptions');
    }

    get LocalisedDescriptions(): LocalisedText[] {
        return this.get('LocalisedDescriptions');
    }

    AddLocalisedDescription(value: LocalisedText) {
        return this.add('LocalisedDescriptions', value);
    }

    RemoveLocalisedDescription(value: LocalisedText) {
        return this.remove('LocalisedDescriptions', value);
    }

    set LocalisedDescriptions(value: LocalisedText[]) {
        this.set('LocalisedDescriptions', value);
    }

    get CanReadCatalogueImage(): boolean {
        return this.canRead('CatalogueImage');
    }

    get CanWriteCatalogueImage(): boolean {
        return this.canWrite('CatalogueImage');
    }

    get CatalogueImage(): Media {
        return this.get('CatalogueImage');
    }

    set CatalogueImage(value: Media) {
        this.set('CatalogueImage', value);
    }

    get CanReadProductCategories(): boolean {
        return this.canRead('ProductCategories');
    }

    get CanWriteProductCategories(): boolean {
        return this.canWrite('ProductCategories');
    }

    get ProductCategories(): ProductCategory[] {
        return this.get('ProductCategories');
    }

    AddProductCategory(value: ProductCategory) {
        return this.add('ProductCategories', value);
    }

    RemoveProductCategory(value: ProductCategory) {
        return this.remove('ProductCategories', value);
    }

    set ProductCategories(value: ProductCategory[]) {
        this.set('ProductCategories', value);
    }

    get CanReadCatScope(): boolean {
        return this.canRead('CatScope');
    }

    get CanWriteCatScope(): boolean {
        return this.canWrite('CatScope');
    }

    get CatScope(): CatScope {
        return this.get('CatScope');
    }

    set CatScope(value: CatScope) {
        this.set('CatScope', value);
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


    get CanExecuteDelete(): boolean {
        return this.canExecute('Delete');
    }

    get Delete(): Method {
        return new Method(this, 'Delete');
    }
}
