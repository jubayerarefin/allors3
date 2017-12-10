// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Deletable } from './Deletable.g';
import { Notification } from './Notification.g';
import { User } from './User.g';

export class NotificationList extends SessionObject implements Deletable {
    get CanReadUnconfirmedNotifications(): boolean {
        return this.canRead('UnconfirmedNotifications');
    }

    get UnconfirmedNotifications(): Notification[] {
        return this.get('UnconfirmedNotifications');
    }



    get CanExecuteDelete(): boolean {
        return this.canExecute('Delete');
    }

    get Delete(): Method {
        return new Method(this, 'Delete');
    }
}
