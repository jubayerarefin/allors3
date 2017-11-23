import { SessionObject, Method } from "@allors/base-domain";
import { Deletable } from './Deletable.g';
export declare class SecurityToken extends SessionObject implements Deletable {
    readonly CanExecuteDelete: boolean;
    readonly Delete: Method;
}
