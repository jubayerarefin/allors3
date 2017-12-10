// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { LocalisedText } from './LocalisedText.g';

export interface Enumeration extends SessionObject , UniquelyIdentifiable {
        LocalisedNames : LocalisedText[];
        AddLocalisedName(value: LocalisedText);
        RemoveLocalisedName(value: LocalisedText);


        Name : string;


        IsActive : boolean;


}