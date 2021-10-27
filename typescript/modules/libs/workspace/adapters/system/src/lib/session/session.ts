import { IChangeSet, IInvokeResult, InvokeOptions, IObject, IPullResult, IPushResult, IRule, ISession, IValidation, IWorkspaceResult, Method, Procedure, Pull } from '@allors/workspace/domain/system';
import { AssociationType, Class, Composite, Dependency, Origin } from '@allors/workspace/meta/system';

import { Workspace } from '../workspace/workspace';
import { WorkspaceResult } from '../workspace/workspace-result';
import { ObjectBase } from '../object-base';
import { DefaultObjectRanges } from '../collections/ranges/default-object-ranges';
import { Ranges } from '../collections/ranges/ranges';

import { SessionOriginState } from './originstate/session-origin-state';
import { Strategy } from './strategy';
import { ChangeSetTracker } from './trackers/change-set-tracker';
import { PushToDatabaseTracker } from './trackers/push-to-database-tracker';
import { PushToWorkspaceTracker } from './trackers/push-to-workspace-tracker';
import { ChangeSet } from './change-set';
import { Derivation } from './derivation/derivation';

export function isNewId(id: number): boolean {
  return id < 0;
}

export abstract class Session implements ISession {
  changeSetTracker: ChangeSetTracker;

  pushToDatabaseTracker: PushToDatabaseTracker;

  pushToWorkspaceTracker: PushToWorkspaceTracker;

  sessionOriginState: SessionOriginState;

  objectByWorkspaceId: Map<number, IObject>;

  readonly ranges: Ranges<IObject>;

  private objectsByClass: Map<Class, Set<IObject>>;

  private activeRules: Set<IRule>;

  protected dependencies: Set<Dependency>;

  constructor(public workspace: Workspace) {
    this.ranges = new DefaultObjectRanges();

    this.objectByWorkspaceId = new Map();
    this.objectsByClass = new Map();
    this.sessionOriginState = new SessionOriginState(this.ranges);

    this.changeSetTracker = new ChangeSetTracker();
    this.pushToDatabaseTracker = new PushToDatabaseTracker();
    this.pushToWorkspaceTracker = new PushToWorkspaceTracker();
  }

  activate(rules: IRule[]): void {
    if (rules == null) {
      return;
    }

    if (this.activeRules == null) {
      this.activeRules = new Set();
      this.dependencies = new Set();
    }

    for (const rule of rules) {
      this.activeRules.add(rule);
      if (rule.dependencies != null) {
        for (const dependency of rule.dependencies) {
          this.dependencies.add(dependency);
        }
      }
    }
  }

  get hasChanges(): boolean {
    // TODO: Optimize
    for (const [, object] of this.objectByWorkspaceId) {
      if (object.strategy.hasChanges) {
        return true;
      }
    }

    return false;
  }

  derive(): IValidation {
    if (this.activeRules == null) {
      return { errors: ['No active rules'] };
    }

    const configuration = this.workspace.database.configuration;
    const derivation = new Derivation(this, configuration.engine, this.activeRules, configuration.maxCycles ?? 10);
    return derivation.execute();
  }

  reset(): void {
    const changeSet = this.checkpoint();

    const objects: Set<IObject> = new Set(changeSet.created);

    for (const roles of changeSet.rolesByAssociationType.values()) {
      for (const role of roles) {
        objects.add(role);
      }
    }

    for (const associations of changeSet.associationsByRoleType.values()) {
      for (const association of associations) {
        objects.add(association);
      }
    }

    for (const object of objects) {
      object.strategy.reset();
    }
  }

  abstract create<T extends IObject>(cls: Composite): T;

  pullFromWorkspace(): IWorkspaceResult {
    const result = new WorkspaceResult();

    for (const [, object] of this.objectByWorkspaceId) {
      if (object.strategy.cls.origin != Origin.Session) {
        (object.strategy as Strategy).WorkspaceOriginState.onPulled(result);
      }
    }

    return result;
  }

  pushToWorkspace(): IWorkspaceResult {
    const pushResult = new WorkspaceResult();

    if (this.pushToWorkspaceTracker.created != null) {
      for (const object of this.pushToWorkspaceTracker.created) {
        (object.strategy as Strategy).WorkspaceOriginState.push();
      }
    }

    if (this.pushToWorkspaceTracker.changed != null) {
      for (const state of this.pushToWorkspaceTracker.changed) {
        if (this.pushToWorkspaceTracker.created?.has(state.object) == true) {
          continue;
        }

        state.push();
      }
    }

    this.pushToWorkspaceTracker.created = null;
    this.pushToWorkspaceTracker.changed = null;

    return pushResult;
  }

  checkpoint(): IChangeSet {
    const changeSet = new ChangeSet(this, this.changeSetTracker.created, this.changeSetTracker.instantiated);
    if (this.changeSetTracker.databaseOriginStates != null) {
      for (const databaseOriginState of this.changeSetTracker.databaseOriginStates) {
        databaseOriginState.checkpoint(changeSet);
      }
    }

    if (this.changeSetTracker.workspaceOriginStates != null) {
      for (const workspaceOriginState of this.changeSetTracker.workspaceOriginStates) {
        workspaceOriginState.checkpoint(changeSet);
      }
    }

    this.sessionOriginState.checkpoint(changeSet);

    this.changeSetTracker.created = null;
    this.changeSetTracker.instantiated = null;
    this.changeSetTracker.databaseOriginStates = null;
    this.changeSetTracker.workspaceOriginStates = null;

    return changeSet;
  }

  instantiate<T extends IObject>(id: number): T;
  instantiate<T extends IObject>(ids: number[]): T[];
  instantiate<T extends IObject>(objectType: Composite): T[];
  instantiate<T extends IObject>(obj: T): T[];
  instantiate<T extends IObject>(args: unknown): unknown {
    if (typeof args === 'number') {
      return (this.getObject(args) as unknown as T) ?? null;
    }

    if (args instanceof ObjectBase) {
      return (this.getObject(args.id) as unknown as T) ?? null;
    }

    if (Array.isArray(args)) {
      return args.map((v) => this.getObject(v)).filter((v) => v != null) as unknown as T[];
    }

    if (args && args['classes']) {
      const all: T[] = [];

      for (const cls of (args as Composite).classes) {
        switch (cls.origin) {
          case Origin.Workspace:
            if (this.workspace.workspaceIdsByWorkspaceClass.has(cls)) {
              const ids = this.workspace.workspaceIdsByWorkspaceClass.get(cls);
              for (const id of ids) {
                if (this.objectByWorkspaceId.has(id)) {
                  const object = this.objectByWorkspaceId.get(id);
                  all.push(object as T);
                } else {
                  const object = this.instantiateWorkspaceStrategy(id);
                  all.push(object as T);
                }
              }
            }

            break;
          case Origin.Database:
          case Origin.Session:
            if (this.objectsByClass.has(cls)) {
              const strategies = this.objectsByClass.get(cls);
              strategies.forEach((v) => {
                all.push(v as T);
              });
            }

            break;

          default:
            throw new Error(`Unknown Origin {@class.Origin}`);
        }
      }

      return all;
    }

    return null;
  }

  public getObject(id: number): IObject {
    if (id == 0) {
      return null;
    }

    if (this.objectByWorkspaceId.has(id)) {
      return this.objectByWorkspaceId.get(id);
    }

    return isNewId(id) ? this.instantiateWorkspaceStrategy(id) : null;
  }

  public getCompositeAssociation(role: IObject, associationType: AssociationType): IObject {
    const roleType = associationType.roleType;
    for (const association of this.strategiesForClass(associationType.objectType as Composite)) {
      if (!association.strategy.canRead(roleType)) {
        continue;
      }

      if ((association.strategy as Strategy).isCompositeAssociationForRole(roleType, role)) {
        return association;
      }
    }

    return null;
  }

  public getCompositesAssociation(role: IObject, associationType: AssociationType): IObject[] {
    const roleType = associationType.roleType;

    const associations: IObject[] = [];

    for (const association of this.strategiesForClass(associationType.objectType as Composite)) {
      if (!association.strategy.canRead(roleType)) {
        continue;
      }

      if ((association.strategy as Strategy).isCompositesAssociationForRole(roleType, role)) {
        associations.push(association);
      }
    }

    return associations;
  }

  protected addObject(object: IObject) {
    this.objectByWorkspaceId.set(object.id, object);

    let strategies = this.objectsByClass.get(object.strategy.cls);
    if (strategies == null) {
      strategies = new Set();
      this.objectsByClass.set(object.strategy.cls, strategies);
    }

    strategies.add(object);
  }

  onDatabasePushResponseNew(workspaceId: number, databaseId: number) {
    const object = this.objectByWorkspaceId.get(workspaceId);
    this.pushToDatabaseTracker.created.delete(object);
    (object.strategy as Strategy).onDatabasePushNewId(databaseId);
    this.addObject(object);
    (object.strategy as Strategy).onDatabasePushed();
  }

  private strategiesForClass(objectType: Composite): IObject[] {
    const classes = objectType.classes;

    // TODO: Optimize
    const objects: IObject[] = [];
    for (const [, object] of this.objectByWorkspaceId) {
      if (classes.has(object.strategy.cls) && objects.indexOf(object) < 0) {
        objects.push(object);
      }
    }

    return objects;
  }

  abstract invoke(methodOrMethods: Method | Method[], options?: InvokeOptions): Promise<IInvokeResult>;

  abstract call(procedure: Procedure, ...pulls: Pull[]): Promise<IPullResult>;

  abstract pull(pulls: Pull | Pull[]): Promise<IPullResult>;

  abstract push(): Promise<IPushResult>;

  abstract instantiateWorkspaceStrategy(id: number): IObject;
}
