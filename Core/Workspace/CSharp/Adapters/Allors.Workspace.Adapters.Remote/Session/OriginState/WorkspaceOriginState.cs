// <copyright file="Object.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Workspace.Adapters.Remote
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;

    internal sealed class WorkspaceOriginState
    {
        private readonly Strategy strategy;

        private WorkspaceRecord workspaceRecord;
        private Dictionary<IRelationType, object> changedRoleByRelationType;

        private WorkspaceRecord previousWorkspaceRecord;
        private Dictionary<IRelationType, object> previousChangedRoleByRelationType;

        internal WorkspaceOriginState(Strategy strategy)
        {
            this.strategy = strategy;
            this.workspaceRecord = this.Workspace.Get(this.Identity);
            this.previousWorkspaceRecord = this.workspaceRecord;
        }

        internal bool HasWorkspaceChanges => this.changedRoleByRelationType != null;

        private long Identity => this.strategy.Id;

        private IClass Class => this.strategy.Class;

        private Session Session => this.strategy.Session;

        private Workspace Workspace => this.Session.Workspace;

        internal object GetRole(IRoleType roleType)
        {
            if (roleType.ObjectType.IsUnit)
            {

                if (this.changedRoleByRelationType == null || !this.changedRoleByRelationType.TryGetValue(roleType.RelationType, out var unit))
                {
                    unit = this.workspaceRecord?.GetRole(roleType);
                }

                return unit;
            }

            if (roleType.IsOne)
            {
                if (this.changedRoleByRelationType != null &&
                    this.changedRoleByRelationType.TryGet<Strategy>(roleType.RelationType, out var workspaceRole))
                {
                    return workspaceRole?.Object;
                }

                var identity = (long?)this.workspaceRecord?.GetRole(roleType);
                workspaceRole = this.Session.GetStrategy(identity);

                return workspaceRole?.Object;
            }

            if (this.changedRoleByRelationType != null &&
                this.changedRoleByRelationType.TryGet<Strategy[]>(roleType.RelationType, out var workspaceRoles))
            {
                return workspaceRoles != null ? workspaceRoles.Select(v => v.Object).ToArray() : Array.Empty<IObject>();
            }

            var identities = (long[])this.workspaceRecord?.GetRole(roleType);
            return identities == null ? Array.Empty<IObject>() : identities.Select(v => this.Session.Get<IObject>(v)).ToArray();
        }

        internal void SetUnitRole(IRoleType roleType, object role)
        {
            var previousRole = this.GetRole(roleType);
            if (Equals(previousRole, role))
            {
                return;
            }

            this.changedRoleByRelationType ??= new Dictionary<IRelationType, object>();
            this.changedRoleByRelationType[roleType.RelationType] = role;

            this.Session.OnChange(this);
        }

        internal void SetCompositeRole(IRoleType roleType, object value)
        {
            var role = (IObject)value;
            var previousRole = (IObject)this.GetRole(roleType);
            if (Equals(previousRole, role))
            {
                return;
            }

            // OneToOne
            if (previousRole != null)
            {
                var associationType = roleType.AssociationType;
                if (associationType.IsOne)
                {
                    var previousAssociationObject = this.Session.GetAssociation<IObject>((Strategy)previousRole.Strategy, associationType).FirstOrDefault();
                    previousAssociationObject?.Strategy.Set(roleType, null);
                }
            }

            this.changedRoleByRelationType ??= new Dictionary<IRelationType, object>();
            this.changedRoleByRelationType[roleType.RelationType] = role?.Strategy;

            this.Session.OnChange(this);
        }

        internal void SetCompositesRole(IRoleType roleType, object value)
        {
            var previousRole = (IObject[])this.GetRole(roleType);

            var role = Array.Empty<IObject>();
            if (value != null)
            {
                role = ((IEnumerable<IObject>)value).ToArray();
            }

            var addedRoles = role.Except(previousRole).ToArray();
            var removedRoles = previousRole.Except(role).ToArray();

            if (addedRoles.Length == 0 && removedRoles.Length == 0)
            {
                return;
            }

            // OneToMany
            if (previousRole.Length > 0)
            {
                var associationType = roleType.AssociationType;
                if (associationType.IsOne)
                {
                    var addedObjects = this.Session.Get<IObject>(addedRoles);
                    foreach (var addedObject in addedObjects)
                    {
                        var previousAssociationObject = this.Session.GetAssociation<IObject>((Strategy)addedObject.Strategy, associationType).FirstOrDefault();
                        previousAssociationObject?.Strategy.Remove(roleType, addedObject);
                    }
                }
            }

            this.changedRoleByRelationType ??= new Dictionary<IRelationType, object>();
            this.changedRoleByRelationType[roleType.RelationType] = role;

            this.Session.OnChange(this);
        }

        internal void Push()
        {
            if (this.HasWorkspaceChanges)
            {
                this.Workspace.Push(this.Identity, this.Class, this.workspaceRecord?.Version ?? 0, this.changedRoleByRelationType);
            }

            this.workspaceRecord = this.Workspace.Get(this.Identity);
            this.changedRoleByRelationType = null;
        }

        internal void Reset()
        {
            this.workspaceRecord = this.Workspace.Get(this.Identity);
            this.changedRoleByRelationType = null;
        }

        internal void Checkpoint(ChangeSet changeSet)
        {
            // Same workspace object
            if (this.workspaceRecord.Version == this.previousWorkspaceRecord.Version)
            {
                // No previous changed roles
                if (this.previousChangedRoleByRelationType == null)
                {
                    if (this.changedRoleByRelationType != null)
                    {
                        // Changed roles
                        foreach (var kvp in this.changedRoleByRelationType)
                        {
                            var relationType = kvp.Key;
                            var cooked = kvp.Value;
                            var raw = this.workspaceRecord.GetRole(relationType.RoleType);

                            changeSet.DiffCookedWithRaw(this.strategy, relationType, cooked, raw);
                        }
                    }
                }
                // Previous changed roles
                else
                {
                    foreach (var kvp in this.changedRoleByRelationType)
                    {
                        var relationType = kvp.Key;
                        var role = kvp.Value;

                        _ = this.previousChangedRoleByRelationType.TryGetValue(relationType, out var previousRole);
                        changeSet.DiffCookedWithCooked(this.strategy, relationType, role, previousRole);
                    }
                }
            }
            // Different workspace objects
            else
            {
                var hasPreviousCooked = this.previousChangedRoleByRelationType != null;
                var hasCooked = this.changedRoleByRelationType != null;

                foreach (var roleType in this.Class.WorkspaceOriginRoleTypes)
                {
                    var relationType = roleType.RelationType;

                    if (hasPreviousCooked && this.previousChangedRoleByRelationType.TryGetValue(relationType, out var previousCooked))
                    {
                        if (hasCooked && this.changedRoleByRelationType.TryGetValue(relationType, out var cooked))
                        {
                            changeSet.DiffCookedWithCooked(this.strategy, relationType, cooked, previousCooked);
                        }
                        else
                        {
                            var raw = this.workspaceRecord.GetRole(roleType);
                            changeSet.DiffRawWithCooked(this.strategy, relationType, raw, previousCooked);
                        }
                    }
                    else
                    {
                        var previousRaw = this.previousWorkspaceRecord?.GetRole(roleType);
                        if (hasCooked && this.changedRoleByRelationType.TryGetValue(relationType, out var cooked) == true)
                        {
                            changeSet.DiffCookedWithRaw(this.strategy, relationType, cooked, previousRaw);
                        }
                        else
                        {
                            var raw = this.workspaceRecord.GetRole(roleType);
                            changeSet.DiffRawWithRaw(this.strategy, relationType, raw, previousRaw);
                        }
                    }
                }
            }

            this.previousWorkspaceRecord = this.workspaceRecord;
            this.previousChangedRoleByRelationType = this.changedRoleByRelationType;
        }

        public bool IsAssociationForRole(IRoleType roleType, Strategy forRole)
        {
            if (roleType.ObjectType.IsUnit)
            {
                return false;
            }

            if (roleType.IsOne)
            {
                if (this.changedRoleByRelationType != null &&
                    this.changedRoleByRelationType.TryGet<Strategy>(roleType.RelationType, out var workspaceRole))
                {
                    return workspaceRole?.Equals(forRole) == true;
                }

                var identity = (long?)this.workspaceRecord?.GetRole(roleType);
                return identity?.Equals(forRole.Id) == true;
            }

            if (this.changedRoleByRelationType != null &&
                this.changedRoleByRelationType.TryGet<Strategy[]>(roleType.RelationType, out var workspaceRoles))
            {
                return workspaceRoles?.Contains(forRole) == true;
            }

            var identities = (long[])this.workspaceRecord?.GetRole(roleType);
            return identities?.Contains(forRole.Id) == true;
        }

    }
}