import { ObjectType, AssociationType, RoleType } from '@allors/meta/system';

import { Session } from './Session';

export interface WorkspaceObject {
  readonly id: string;
  readonly objectType: ObjectType;

  readonly session: Session;

  get(roleType: RoleType): any;
  set(roleType: RoleType, value: any): void;
  add(roleType: RoleType, value: any): void;
  remove(roleType: RoleType, value: any): void;

  getAssociation(associationType: AssociationType): any;
}