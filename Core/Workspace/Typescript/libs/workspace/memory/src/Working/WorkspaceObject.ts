import { ObjectType, AssociationType, RoleType } from '@allors/meta/core';
import { DatabaseObject, WorkspaceObject } from '@allors/workspace/core';
import { MemoryWorkspace } from '../Local/Workspace';
import { MemorySession } from './Session';

export abstract class MemoryWorkspaceObject implements WorkspaceObject {
  id: string;

  objectType: ObjectType;

  session: MemorySession;

  workspace: MemoryWorkspace;

  public get(roleType: RoleType): any {
    const role = this.workspace.getRole(this.id, roleType);
    return role;
  }

  public set(roleType: RoleType, role: any) {
    this.workspace.setRole(this.id, roleType, role as any);
  }

  public add(roleType: RoleType, role: DatabaseObject | WorkspaceObject) {}

  public remove(roleType: RoleType, role: DatabaseObject | WorkspaceObject) {}

  public getAssociation(associationType: AssociationType): any {
    return null;
  }

  // called after dynamic creation
  protected init() {
  }
}