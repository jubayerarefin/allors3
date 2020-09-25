import { ObjectType, MetaPopulation, OperandType, Origin } from '@allors/meta/system';
import {
  Operations,
  Compressor,
  PullResponse,
  SyncRequest,
  SyncResponse,
  SecurityRequest,
  SecurityResponse,
} from '@allors/protocol/system';
import { Permission, Database, Record, Session, AccessControl } from '@allors/workspace/system';

import { MemorySession } from '../Session/Session';
import { MemoryWorkspace } from '../Workspace/Workspace';

import { databaseClasses } from '../Session/databaseClasses';
import { workspaceClasses } from '../Session/workspaceClasses';

import { MemoryRecord } from './Record';

export class MemoryDatabase implements Database {
  constructorByObjectType: Map<ObjectType, any>;

  readonly workspace: MemoryWorkspace;

  readonly databaseObjectById: Map<string, MemoryRecord>;
  readonly databaseObjectsByClass: Map<ObjectType, Set<MemoryRecord>>;

  readonly accessControlById: Map<string, AccessControl>;
  readonly permissionById: Map<string, Permission>;

  private readPermissionByOperandTypeByClass: Map<ObjectType, Map<OperandType, Permission>>;
  private writePermissionByOperandTypeByClass: Map<ObjectType, Map<OperandType, Permission>>;
  private executePermissionByOperandTypeByClass: Map<ObjectType, Map<OperandType, Permission>>;

  constructor(public metaPopulation: MetaPopulation) {
    this.constructorByObjectType = new Map();

    this.databaseObjectById = new Map();
    this.databaseObjectsByClass = new Map();
    for (const objectType of metaPopulation.classes) {
      this.databaseObjectsByClass.set(objectType, new Set());
    }

    this.accessControlById = new Map();
    this.permissionById = new Map();

    this.readPermissionByOperandTypeByClass = new Map();
    this.writePermissionByOperandTypeByClass = new Map();
    this.executePermissionByOperandTypeByClass = new Map();

    metaPopulation.classes.forEach((v) => {
      this.readPermissionByOperandTypeByClass.set(v, new Map());
      this.writePermissionByOperandTypeByClass.set(v, new Map());
      this.executePermissionByOperandTypeByClass.set(v, new Map());
    });

    const classes = metaPopulation.classes;
    databaseClasses(
      classes.filter((v) => v.origin === Origin.Database),
      this.constructorByObjectType
    );
    workspaceClasses(
      classes.filter((v) => v.origin === Origin.Workspace),
      this.constructorByObjectType
    );

    this.workspace = new MemoryWorkspace(metaPopulation);
  }

  createSession(): Session {
    return new MemorySession(this);
  }

  get(id: string): Record | undefined {
    const databaseObject = this.databaseObjectById.get(id);
    if (databaseObject === undefined) {
      throw new Error(`Object with id ${id} is not present.`);
    }

    return databaseObject ?? null;
  }

  getForAssociation(id: string): Record | undefined {
    return this.databaseObjectById.get(id);
  }

  diff(response: PullResponse): SyncRequest {
    const syncRequest: SyncRequest = {
      objects: (response.objects ?? [])
        .filter((syncRequestObject) => {
          const [id, version, sortedAccessControlIds, sortedDeniedPermissionIds] = syncRequestObject;
          const databaseObject = this.databaseObjectById.get(id);

          const sync =
            databaseObject == null ||
            databaseObject.version !== version ||
            databaseObject.sortedAccessControlIds !== sortedAccessControlIds ||
            databaseObject.sortedDeniedPermissionIds !== sortedDeniedPermissionIds;

          return sync;
        })
        .map((syncRequestObject) => {
          return syncRequestObject[0];
        }),
    };

    return syncRequest;
  }

  sync(syncResponse: SyncResponse): SecurityRequest | undefined {
    const missingAccessControlIds = new Set<string>();
    const missingPermissionIds = new Set<string>();

    const sortedAccessControlIdsDecompress = (compressed: string): string => {
      if (compressed) {
        compressed.split(Compressor.itemSeparator).forEach((v) => {
          if (!this.accessControlById.has(v)) {
            missingAccessControlIds.add(v);
          }
        });
      }

      return compressed;
    };

    const sortedDeniedPermissionIdsDecompress = (compressed: string): string => {
      if (compressed) {
        compressed.split(Compressor.itemSeparator).forEach((v) => {
          if (!this.permissionById.has(v)) {
            missingPermissionIds.add(v);
          }
        });
      }

      return compressed;
    };

    if (syncResponse.objects) {
      syncResponse.objects.forEach((v) => {
        const databaseObject = new MemoryRecord(
          this,
          this.metaPopulation,
          v,
          sortedAccessControlIdsDecompress,
          sortedDeniedPermissionIdsDecompress
        );

        this.add(databaseObject);
      });
    }

    if (missingAccessControlIds.size > 0 || missingPermissionIds.size > 0) {
      const securityRequest: SecurityRequest = {
        accessControls: [...missingAccessControlIds],
        permissions: [...missingPermissionIds],
      };

      return securityRequest;
    }

    return undefined;
  }

  private getOrCreate<T, U, V>(map: Map<T, Map<U, V>>, key: T) {
    let value = map.get(key);
    if (!value) {
      value = new Map();
      map.set(key, value);
    }

    return value;
  }

  security(securityResponse: SecurityResponse): SecurityRequest | undefined {
    if (securityResponse.permissions) {
      securityResponse.permissions.forEach((v) => {
        const id = v[0];
        const objectType = this.metaPopulation.metaObjectById.get(v[1]) as ObjectType;
        const operandType = this.metaPopulation.metaObjectById.get(v[2]) as OperandType;
        const operation = parseInt(v[3], 10);

        let permission = this.permissionById.get(id);
        if (!permission) {
          permission = new Permission(id, objectType, operandType, operation);
          this.permissionById.set(id, permission);
        }

        switch (operation) {
          case Operations.Read:
            this.getOrCreate(this.readPermissionByOperandTypeByClass, objectType).set(operandType, permission);
            break;

          case Operations.Write:
            this.getOrCreate(this.writePermissionByOperandTypeByClass, objectType).set(operandType, permission);
            break;

          case Operations.Execute:
            this.getOrCreate(this.executePermissionByOperandTypeByClass, objectType).set(operandType, permission);
            break;
        }
      });
    }

    if (securityResponse.accessControls) {
      let missingPermissionIds: Set<string> = new Set();

      securityResponse.accessControls.forEach((v) => {
        const id = v.i;
        const version = v.v;
        const permissionIds = new Set<string>();
        v.p?.split(',').forEach((w) => {
          if (!this.permissionById.has(w)) {
            if (missingPermissionIds === undefined) {
              missingPermissionIds = new Set();
            }
            missingPermissionIds.add(w);
          }
          permissionIds.add(w);
        });
        const accessControl = new AccessControl(id, version, permissionIds);
        this.accessControlById.set(id, accessControl);
      });

      if (missingPermissionIds.size > 0) {
        const securityRequest: SecurityRequest = {
          permissions: [...missingPermissionIds],
        };

        return securityRequest;
      }
    }

    return undefined;
  }

  new(id: string, objectType: ObjectType): Record {
    const databaseObject = new MemoryRecord(this, objectType, id);
    this.add(databaseObject);
    return databaseObject;
  }

  permission(objectType: ObjectType, operandType: OperandType, operation: Operations): Permission | undefined {
    switch (operation) {
      case Operations.Read:
        return this.readPermissionByOperandTypeByClass.get(objectType)?.get(operandType);
      case Operations.Write:
        return this.writePermissionByOperandTypeByClass.get(objectType)?.get(operandType);
      default:
        return this.executePermissionByOperandTypeByClass.get(objectType)?.get(operandType);
    }
  }

  private add(databaseObject: MemoryRecord) {
    this.databaseObjectById.set(databaseObject.id, databaseObject);
    this.databaseObjectsByClass.get(databaseObject.objectType)?.add(databaseObject);
  }
}