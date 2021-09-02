import { IRecord } from '../../IRecord';
import { ChangeSet } from '../ChangeSet';
import { Strategy } from '../Strategy';
import { Workspace } from '../../workspace/Workspace';
import { Session } from '../Session';
import { Class, RelationType, RoleType } from '@allors/workspace/meta/system';
import { ICompositeDiff, ICompositesDiff, IDiff, IUnit, IUnitDiff } from '@allors/workspace/domain/system';
import { frozenEmptyArray } from '../../collections/frozenEmptyArray';
import { IRange, Ranges } from '../../collections/ranges/Ranges';

export abstract class RecordBasedOriginState {
  abstract strategy: Strategy;

  protected hasChanges(): boolean {
    return this.record == null || this.changedRoleByRelationType?.size > 0;
  }

  protected abstract roleTypes: Set<RoleType>;

  protected abstract record: IRecord;

  protected previousRecord: IRecord;

  changedRoleByRelationType: Map<RelationType, unknown>;

  private previousChangedRoleByRelationType: Map<RelationType, unknown>;

  getUnitRole(roleType: RoleType): IUnit {
    if (this.changedRoleByRelationType != null && this.changedRoleByRelationType.has(roleType.relationType)) {
      return this.changedRoleByRelationType.get(roleType.relationType) as IUnit;
    }

    return this.record?.getRole(roleType) as IUnit;
  }

  setUnitRole(roleType: RoleType, role: IUnit) {
    this.setChangedRole(roleType, role);
  }

  getCompositeRole(roleType: RoleType): Strategy {
    if (this.changedRoleByRelationType != null && this.changedRoleByRelationType.has(roleType.relationType)) {
      return this.changedRoleByRelationType.get(roleType.relationType) as Strategy;
    }

    const role = this.record?.getRole(roleType) as number;
    return role != null ? this.session.getStrategy(role) : null;
  }

  setCompositeRole(roleType: RoleType, role?: Strategy) {
    const previousRole = this.getCompositeRole(roleType);

    if (previousRole == role) {
      return;
    }

    const associationType = roleType.associationType;
    if (associationType.isOne && role != null) {
      const previousAssociation = this.session.getCompositeAssociation(role, associationType);
      this.setChangedRole(roleType, role);

      if (associationType.isOne && previousAssociation != null) {
        //  OneToOne
        previousAssociation.setRole(roleType, null);
      }
    } else {
      this.setChangedRole(roleType, role);
    }
  }

  getCompositesRole(roleType: RoleType): IRange<Strategy> {
    if (this.changedRoleByRelationType != null && this.changedRoleByRelationType.has(roleType.relationType)) {
      return this.changedRoleByRelationType.get(roleType.relationType) as IRange<Strategy>;
    }

    const role = this.record?.getRole(roleType) as IRange<number>;
    return role != null ? this.strategyRanges.importFrom(role.map((v) => this.session.getStrategy(v))) : (frozenEmptyArray as Strategy[]);
  }

  addCompositesRole(roleType: RoleType, roleToAdd: Strategy) {
    const associationType = roleType.associationType;
    const previousAssociation = this.session.getCompositeAssociation(roleToAdd, associationType);

    let role = this.getCompositesRole(roleType);

    if (this.strategyRanges.has(role, roleToAdd)) {
      return;
    }

    role = this.strategyRanges.add(role, roleToAdd);
    this.setChangedRole(roleType, role);

    if (associationType.isMany) {
      return;
    }

    //  OneToMany
    previousAssociation?.setRole(roleType, null);
  }

  removeCompositesRole(roleType: RoleType, roleToRemove: Strategy) {
    let role = this.getCompositesRole(roleType);

    if (!this.strategyRanges.has(role, roleToRemove)) {
      return;
    }

    role = this.strategyRanges.remove(role, roleToRemove);
    this.setChangedRole(roleType, role);
  }

  setCompositesRole(roleType: RoleType, role: IRange<Strategy>) {
    const previousRole = this.getCompositesRole(roleType);

    this.setChangedRole(roleType, role);

    const associationType = roleType.associationType;
    if (associationType.isMany) {
      return;
    }

    //  OneToMany
    for (const addedRole of this.strategyRanges.enumerate(this.strategyRanges.difference(role, previousRole))) {
      const previousAssociation = this.session.getCompositeAssociation(addedRole, associationType);
      previousAssociation?.setRole(roleType, null);
    }
  }

  checkpoint(changeSet: ChangeSet) {
    //  Same record
    if (this.previousRecord == null || this.record == null || this.record.version == this.previousRecord.version) {
      //  No previous changed roles
      if (this.previousChangedRoleByRelationType == null) {
        if (this.changedRoleByRelationType != null) {
          //  Changed roles
          this.changedRoleByRelationType.forEach((current, relationType) => {
            const previous = this.record?.getRole(relationType.roleType);

            if (relationType.roleType.objectType.isUnit) {
              changeSet.diffUnit(this.strategy, relationType, current, previous);
            } else if (relationType.roleType.isOne) {
              changeSet.diffCompositeStrategyRecord(this.strategy, relationType, current as Strategy, previous as number);
            } else {
              changeSet.diffCompositesStrategyRecord(this.strategy, relationType, current as IRange<Strategy>, previous as IRange<number>);
            }
          });
        }
      } else {
        this.changedRoleByRelationType.forEach((current, relationType) => {
          const previous = this.previousChangedRoleByRelationType?.get(relationType);

          if (relationType.roleType.objectType.isUnit) {
            changeSet.diffUnit(this.strategy, relationType, current, previous);
          } else if (relationType.roleType.isOne) {
            changeSet.diffCompositeStrategyRecord(this.strategy, relationType, current as Strategy, previous as number);
          } else {
            changeSet.diffCompositesStrategyRecord(this.strategy, relationType, current as IRange<Strategy>, previous as IRange<number>);
          }
        });
      }

      //  Previous changed roles
    } else {
      //  Different record
      this.roleTypes.forEach((roleType) => {
        const relationType = roleType.relationType;

        if (this.previousChangedRoleByRelationType?.has(relationType)) {
          const previous = this.previousChangedRoleByRelationType.get(relationType);
          const current = this.changedRoleByRelationType?.has(relationType) ? this.changedRoleByRelationType.get(relationType) : this.record.getRole(roleType);

          if (relationType.roleType.objectType.isUnit) {
            changeSet.diffUnit(this.strategy, relationType, current, previous);
          } else if (relationType.roleType.isOne) {
            changeSet.diffCompositeStrategyStrategy(this.strategy, relationType, current as Strategy, previous as Strategy);
          } else {
            changeSet.diffCompositesStrategyStrategy(this.strategy, relationType, current as IRange<Strategy>, previous as IRange<Strategy>);
          }
        } else {
          const previous = this.previousRecord?.getRole(roleType);
          const current = this.changedRoleByRelationType?.has(relationType) ? this.changedRoleByRelationType?.get(relationType) : this.record.getRole(roleType);

          if (relationType.roleType.objectType.isUnit) {
            changeSet.diffUnit(this.strategy, relationType, current, previous);
          } else if (relationType.roleType.isOne) {
            changeSet.diffCompositeRecordRecord(this.strategy, relationType, current as number, previous as number);
          } else {
            changeSet.diffCompositesRecordRecord(this.strategy, relationType, current as IRange<number>, previous as IRange<number>);
          }
        }
      });
    }

    this.previousRecord = this.record;
    this.previousChangedRoleByRelationType = this.changedRoleByRelationType;
  }

  diff(diffs: IDiff[]) {
    if (this.changedRoleByRelationType == null) {
      return;
    }

    for (const [relationType, changed] of this.changedRoleByRelationType) {
      const roleType = relationType.roleType;
      const original = this.record?.getRole(roleType);

      if (roleType.objectType.isUnit) {
        const diff: IUnitDiff = {
          relationType,
          assocation: this.strategy,
          originalRole: original as IUnit,
          changedRole: changed as IUnit,
        };

        diffs.push(diff);
      } else if (roleType.isOne) {
        const diff: ICompositeDiff = {
          relationType,
          assocation: this.strategy,
          originalRole: original != null ? this.strategy.session.getStrategy(original as number) : null,
          changedRole: changed as Strategy,
        };

        diffs.push(diff);
      } else {
        const diff: ICompositesDiff = {
          relationType,
          assocation: this.strategy,
          originalRoles: original != null ? (original as IRange<number>)?.map((v) => this.strategy.session.getStrategy(v)) ?? frozenEmptyArray : frozenEmptyArray,
          changedRoles: [...(changed as Set<Strategy>)],
        };

        diffs.push(diff);
      }
    }
  }

  canMerge(newRecord: IRecord): boolean {
    if (this.changedRoleByRelationType == null) {
      return true;
    }

    for (const [relationType] of this.changedRoleByRelationType) {
      const roleType = relationType.roleType;
      const original = this.record?.getRole(roleType);
      const newOriginal = newRecord?.getRole(roleType);

      if (roleType.objectType.isUnit) {
        if (original !== newOriginal) {
          return false;
        }
      } else if (roleType.isOne) {
        if (original !== newOriginal) {
          return false;
        }
      } else if (!this.recordRanges.equals(original as number[], newOriginal as number[])) {
        return false;
      }
    }

    return true;
  }

  reset() {
    this.changedRoleByRelationType = null;
  }

  isAssociationForRole(roleType: RoleType, forRole: Strategy): boolean {
    if (roleType.isOne) {
      const compositeRole = this.getCompositeRole(roleType);
      return compositeRole == forRole;
    }
    const composites = this.getCompositesRole(roleType);
    if (composites != null) {
      for (const role of composites) {
        if (role === forRole) {
          return true;
        }
      }
    }

    return false;
  }

  protected abstract onChange();

  private setChangedRole(roleType: RoleType, role: unknown) {
    this.changedRoleByRelationType ??= new Map<RelationType, unknown>();
    this.changedRoleByRelationType.set(roleType.relationType, role);
    this.onChange();
  }

  //#region Proxy
  protected get id(): number {
    return this.strategy.id;
  }

  protected get class(): Class {
    return this.strategy.cls;
  }

  protected get session(): Session {
    return this.strategy.session;
  }

  protected get workspace(): Workspace {
    return this.strategy.session.workspace;
  }

  protected get strategyRanges(): Ranges<Strategy> {
    return this.strategy.session.ranges;
  }

  protected get recordRanges(): Ranges<number> {
    return this.strategy.session.workspace.ranges;
  }
  //#endregion
}
