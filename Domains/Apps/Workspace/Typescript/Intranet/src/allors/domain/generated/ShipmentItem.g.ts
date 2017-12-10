// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Deletable } from './Deletable.g';
import { ShipmentVersion } from './ShipmentVersion.g';

export class ShipmentItem extends SessionObject implements Deletable {

    get CanExecuteDelete(): boolean {
        return this.canExecute('Delete');
    }

    get Delete(): Method {
        return new Method(this, 'Delete');
    }
}
