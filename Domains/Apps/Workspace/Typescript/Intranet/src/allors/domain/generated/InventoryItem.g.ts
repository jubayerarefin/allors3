// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { Deletable } from './Deletable.g';
import { ProductCharacteristicValue } from './ProductCharacteristicValue.g';
import { InventoryItemVariance } from './InventoryItemVariance.g';
import { Part } from './Part.g';
import { Lot } from './Lot.g';
import { UnitOfMeasure } from './UnitOfMeasure.g';
import { Good } from './Good.g';
import { ProductType } from './ProductType.g';
import { Facility } from './Facility.g';
import { WorkEffortVersion } from './WorkEffortVersion.g';
import { WorkEffort } from './WorkEffort.g';

export interface InventoryItem extends SessionObject , UniquelyIdentifiable, Deletable {
        ProductCharacteristicValues : ProductCharacteristicValue[];
        AddProductCharacteristicValue(value: ProductCharacteristicValue);
        RemoveProductCharacteristicValue(value: ProductCharacteristicValue);


        InventoryItemVariances : InventoryItemVariance[];
        AddInventoryItemVariance(value: InventoryItemVariance);
        RemoveInventoryItemVariance(value: InventoryItemVariance);


        Part : Part;


        Name : string;


        Lot : Lot;


        Sku : string;


        UnitOfMeasure : UnitOfMeasure;


        Good : Good;


        ProductType : ProductType;


        Facility : Facility;


    CanExecuteDelete: boolean;
    Delete: Method;

}