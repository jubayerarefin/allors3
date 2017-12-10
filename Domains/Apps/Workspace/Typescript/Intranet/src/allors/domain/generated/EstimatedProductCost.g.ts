// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Period } from './Period.g';
import { Deletable } from './Deletable.g';
import { Product } from './Product.g';
import { ProductFeature } from './ProductFeature.g';

export interface EstimatedProductCost extends SessionObject , Period, Deletable {

    CanExecuteDelete: boolean;
    Delete: Method;

}