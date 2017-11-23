import { SessionObject } from "@allors/base-domain";
import { Enumeration } from './Enumeration.g';
import { LocalisedText } from './LocalisedText.g';
export declare class Gender extends SessionObject implements Enumeration {
    readonly CanReadLocalisedNames: boolean;
    readonly CanWriteLocalisedNames: boolean;
    LocalisedNames: LocalisedText[];
    AddLocalisedName(value: LocalisedText): void;
    RemoveLocalisedName(value: LocalisedText): void;
    readonly CanReadName: boolean;
    readonly CanWriteName: boolean;
    Name: string;
    readonly CanReadIsActive: boolean;
    readonly CanWriteIsActive: boolean;
    IsActive: boolean;
    readonly CanReadUniqueId: boolean;
    readonly CanWriteUniqueId: boolean;
    UniqueId: string;
}
