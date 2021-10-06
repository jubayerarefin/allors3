import { InvokeRequest, PullRequest, PullResponse, PushRequest } from '@allors/protocol/json/system';
import { Session as SystemSession } from '@allors/workspace/adapters/system';
import { IInvokeResult, InvokeOptions, IObject, IPullResult, IPushResult, Method, Procedure, Pull } from '@allors/workspace/domain/system';
import { Class, Origin } from '@allors/workspace/meta/system';
import { DatabaseConnection } from '../database/database-connection';
import { DatabaseRecord } from '../database/database-record';
import { InvokeResult } from '../database/invoke/invoke-result';
import { PullResult } from '../database/pull/pull-result';
import { PushResult } from '../database/push/push-result';
import { procedureToJson, pullToJson } from '../json/to-json';
import { Workspace } from '../workspace/workspace';
import { DatabaseOriginState } from './originstate/database-origin-state';
import { Strategy } from './strategy';

export class Session extends SystemSession {
  database: DatabaseConnection;

  constructor(workspace: Workspace, dependencyId?: string) {
    super(workspace, dependencyId);

    this.database = this.workspace.database as DatabaseConnection;
  }

  create<T extends IObject>(cls: Class): T {
    const workspaceId = this.workspace.database.nextId();
    const strategy = new Strategy(this, cls, workspaceId);
    this.addStrategy(strategy);

    if (cls.origin != Origin.Session) {
      this.pushToWorkspaceTracker.onCreated(strategy);
      if (cls.origin == Origin.Database) {
        this.pushToDatabaseTracker.onCreated(strategy);
      }
    }

    this.changeSetTracker.onCreated(strategy);
    return strategy.object as T;
  }

  instantiateDatabaseStrategy(id: number): void {
    const databaseRecord = this.workspace.database.getRecord(id) as DatabaseRecord;
    const strategy = Strategy.fromDatabaseRecord(this, databaseRecord);
    this.addStrategy(strategy);
    this.changeSetTracker.onInstantiated(strategy);
  }

  instantiateWorkspaceStrategy(id: number): Strategy {
    if (!this.workspace.workspaceClassByWorkspaceId.has(id)) {
      return null;
    }

    const cls = this.workspace.workspaceClassByWorkspaceId.get(id);

    const strategy = new Strategy(this, cls, id);
    this.addStrategy(strategy);

    this.changeSetTracker.onInstantiated(strategy);

    return strategy;
  }

  async invoke(methodOrMethods: Method | Method[], options?: InvokeOptions): Promise<IInvokeResult> {
    const methods = Array.isArray(methodOrMethods) ? methodOrMethods : [methodOrMethods];
    const invokeRequest: InvokeRequest = {
      l: methods.map((v) => {
        return {
          i: v.object.id,
          v: (v.object.strategy as Strategy).DatabaseOriginState.version,
          m: v.methodType.tag,
        };
      }),
      o:
        options != null
          ? {
              c: options.continueOnError,
              i: options.isolated,
            }
          : null,
    };

    const invokeResponse = await this.database.client.invoke(invokeRequest);
    return new InvokeResult(this, invokeResponse);
  }

  async call(procedure: Procedure, ...pulls: Pull[]): Promise<IPullResult> {
    const pullRequest: PullRequest = {
      d: this.dependencyId,
      p: procedureToJson(procedure),
      l: pulls.map((v) => pullToJson(v)),
    };

    const pullResponse = await this.database.client.pull(pullRequest);
    return await this.onPull(pullResponse);
  }

  async pull(pullOrPulls: Pull | Pull[]): Promise<IPullResult> {
    const pulls = Array.isArray(pullOrPulls) ? pullOrPulls : [pullOrPulls];

    for (const pull of pulls) {
      if (pull.objectId < 0 || pull.object?.id < 0) {
        throw new Error('Id is not in the database');
      }

      if (pull.object != null && pull.object.strategy.cls.origin != Origin.Database) {
        throw new Error('Origin is not Database');
      }
    }

    const pullRequest: PullRequest = {
      d: this.dependencyId,
      l: pulls.map((v) => pullToJson(v)),
    };

    const pullResponse = await this.database.client.pull(pullRequest);
    return await this.onPull(pullResponse);
  }

  async push(): Promise<IPushResult> {
    const pushRequest: PushRequest = {};

    if (this.pushToDatabaseTracker.created) {
      pushRequest.n = [...this.pushToDatabaseTracker.created].map((v) => (v.DatabaseOriginState as DatabaseOriginState).pushNew());
    }

    if (this.pushToDatabaseTracker.changed) {
      pushRequest.o = [...this.pushToDatabaseTracker.changed].map((v) => (v.strategy.DatabaseOriginState as DatabaseOriginState).pushExisting());
    }

    const pushResponse = await this.database.client.push(pushRequest);

    const pushResult = new PushResult(this, pushResponse);

    if (pushResult.hasErrors) {
      return pushResult;
    }

    if (pushResponse.n != null) {
      for (const pushResponseNewObject of pushResponse.n) {
        const workspaceId = pushResponseNewObject.w;
        const databaseId = pushResponseNewObject.d;
        this.onDatabasePushResponseNew(workspaceId, databaseId);
      }
    }

    this.pushToDatabaseTracker.created = null;
    this.pushToDatabaseTracker.changed = null;

    if (pushRequest.o != null) {
      for (const id of pushRequest.o.map((v) => v.d)) {
        const strategy = this.getStrategy(id);
        strategy.onDatabasePushed();
      }
    }

    return pushResult;
  }

  private async onPull(pullResponse: PullResponse): Promise<IPullResult> {
    const pullResult = new PullResult(this, pullResponse);

    if (pullResponse.p == null || pullResult.hasErrors) {
      return pullResult;
    }

    const syncRequest = this.database.onPullResonse(pullResponse);
    if (syncRequest.o.length > 0) {
      const syncResponse = await this.database.client.sync(syncRequest);
      const accessRequest = this.database.onSyncResponse(syncResponse);

      if (accessRequest != null) {
        const accessResponse = await this.database.client.access(accessRequest);
        const permissionRequest = this.database.accessResponse(accessResponse);
        if (permissionRequest != null) {
          const permissionResponse = await this.database.client.permission(permissionRequest);
          this.database.permissionResponse(permissionResponse);
        }
      }
    }

    for (const v of pullResponse.p) {
      if (this.strategyByWorkspaceId.has(v.i)) {
        const strategy = this.strategyByWorkspaceId.get(v.i);
        strategy.DatabaseOriginState.onPulled(pullResult);
      } else {
        this.instantiateDatabaseStrategy(v.i);
      }
    }

    return pullResult;
  }
}
