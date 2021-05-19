// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { 
SessionObject, Method } from '@allors/workspace/core';

import { Person } from './Person.g';
import { WorkspacePerson } from './WorkspacePerson.g';
import { SessionPerson } from './SessionPerson.g';

export interface SessionOrganisation extends 
SessionObject {


    SessionDatabaseEmployees: Person[];
    AddSessionDatabaseEmployee(value: Person) : void;
    RemoveSessionDatabaseEmployee(value: Person) : void;


    SessionDatabaseManager: Person | null;


    SessionDatabaseOwner: Person | null;


    SessionDatabaseShareholders: Person[];
    AddSessionDatabaseShareholder(value: Person) : void;
    RemoveSessionDatabaseShareholder(value: Person) : void;


    SessionWorkspaceEmployees: WorkspacePerson[];
    AddSessionWorkspaceEmployee(value: WorkspacePerson) : void;
    RemoveSessionWorkspaceEmployee(value: WorkspacePerson) : void;


    SessionWorkspaceManager: WorkspacePerson | null;


    SessionWorkspaceOwner: WorkspacePerson | null;


    SessionWorkspaceShareholders: WorkspacePerson[];
    AddSessionWorkspaceShareholder(value: WorkspacePerson) : void;
    RemoveSessionWorkspaceShareholder(value: WorkspacePerson) : void;


    SessionSessionEmployees: SessionPerson[];
    AddSessionSessionEmployee(value: SessionPerson) : void;
    RemoveSessionSessionEmployee(value: SessionPerson) : void;


    SessionSessionManager: SessionPerson | null;


    SessionSessionOwner: SessionPerson | null;


    SessionSessionShareholders: SessionPerson[];
    AddSessionSessionShareholder(value: SessionPerson) : void;
    RemoveSessionSessionShareholder(value: SessionPerson) : void;



}