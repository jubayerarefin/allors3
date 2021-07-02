import { Operations } from '@allors/workspace/domain/system';
import { MethodType, RoleType } from '@allors/workspace/meta/system';
import { DatabaseRecord } from '../../database/DatabaseRecord';
import { IRecord } from '../../IRecord';
import { Strategy } from '../Strategy';
import { RecordBasedOriginState } from './RecordBasedOriginState';

export const UnknownVersion = 0;
export const InitialVersion = 1;

export abstract class DatabaseOriginState extends RecordBasedOriginState {
  DatabaseRecord: DatabaseRecord;

  protected constructor(strategy: Strategy, record: DatabaseRecord) {
    super(strategy);
    this.DatabaseRecord = record;
    this.PreviousRecord = this.DatabaseRecord;
  }

  public get Version(): number {
    return this.DatabaseRecord?.version ?? UnknownVersion;
  }

  private get IsVersionUnknown(): boolean {
    return this.Version == UnknownVersion;
  }

  protected get ExistDatabaseRecord(): boolean {
    return this.Record != null;
  }

  get RoleTypes(): Set<RoleType> {
    return this.Class.databaseOriginRoleTypes;
  }

  get Record(): IRecord {
    return this.DatabaseRecord;
  }

  public CanRead(roleType: RoleType): boolean {
    if (!this.ExistDatabaseRecord) {
      return true;
    }

    if (this.IsVersionUnknown) {
      return false;
    }

    const permission = this.Session.workspace.database.getPermission(this.Class, roleType, Operations.Read);
    return this.DatabaseRecord.isPermitted(permission);
  }

  public CanWrite(roleType: RoleType): boolean {
    if (!this.ExistDatabaseRecord) {
      return true;
    }

    if (this.IsVersionUnknown) {
      return false;
    }

    const permission = this.Session.workspace.database.getPermission(this.Class, roleType, Operations.Write);
    return this.DatabaseRecord.isPermitted(permission);
  }

  public CanExecute(methodType: MethodType): boolean {
    if (!this.ExistDatabaseRecord) {
      return true;
    }

    if (this.IsVersionUnknown) {
      return false;
    }

    const permission = this.Session.workspace.database.getPermission(this.Class, methodType, Operations.Execute);
    return this.DatabaseRecord.isPermitted(permission);
  }

  public PushResponse(newDatabaseRecord: DatabaseRecord) {
    this.DatabaseRecord = newDatabaseRecord;
    this.ChangedRoleByRelationType = null;
  }

  public OnPulled() {
    this.DatabaseRecord = this.Session.workspace.database.getRecord(this.Id);
  }

  OnChange() {
    this.Session.changeSetTracker.OnDatabaseChanged(this);
    this.Session.pushToDatabaseTracker.OnChanged(this);
  }
}