// <copyright file="v.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Workspace.Adapters.Local
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Database;
    using Database.Domain;
    using Database.Security;
    using Meta;
    using IRoleType = Database.Meta.IRoleType;

    internal class DatabaseAdapter
    {
        private readonly IPermissionsCache permissionCache;

        internal DatabaseAdapter(IMetaPopulation metaPopulation, IDatabase database)
        {
            this.MetaPopulation = metaPopulation;
            this.Database = database;
            this.RecordsById = new ConcurrentDictionary<long, DatabaseRecord>();
            this.WorkspaceIdGenerator = new WorkspaceIdGenerator();
            this.permissionCache = this.Database.Context().PermissionsCache;
            this.AccessControlById = new Dictionary<long, AccessControl>();
        }

        internal IDatabase Database { get; }

        internal WorkspaceIdGenerator WorkspaceIdGenerator { get; }

        private Database.Meta.IMetaPopulation DatabaseMetaPopulation => this.Database.MetaPopulation;
        private IMetaPopulation MetaPopulation { get; }

        private ConcurrentDictionary<long, DatabaseRecord> RecordsById { get; }

        private Dictionary<long, AccessControl> AccessControlById { get; }

        internal void Sync(IEnumerable<IObject> objects, IAccessControlLists accessControlLists)
        {
            // TODO: Prefetch objects
            static object GetRole(IObject @object, IRoleType roleType)
            {
                if (roleType.ObjectType.IsUnit)
                {
                    return @object.Strategy.GetUnitRole(roleType);
                }

                if (roleType.IsOne)
                {
                    return @object.Strategy.GetCompositeRole(roleType)?.Id;
                }

                var roles = @object.Strategy.GetCompositeRoles(roleType);
                return roles.Count > 0 ? @object.Strategy.GetCompositeRoles(roleType).Select(v => v.Id).ToArray() : Array.Empty<long>();
            }

            foreach (var @object in objects)
            {
                var id = @object.Id;
                var databaseClass = @object.Strategy.Class;
                var roleTypes = databaseClass.DatabaseRoleTypes.Where(w => w.RelationType.WorkspaceNames.Length > 0);

                var workspaceClass = (IClass)this.MetaPopulation.FindByTag(databaseClass.Tag);
                var roleByRoleType = roleTypes.ToDictionary(w =>
                        ((IRelationType)this.MetaPopulation.FindByTag(w.RelationType.Tag)).RoleType,
                    w => GetRole(@object, w));

                var acl = accessControlLists[@object];

                var deniedPermissions = acl.DeniedPermissionIds?.ToArray() ?? Array.Empty<long>();
                var accessControls = acl.AccessControls
                    ?.Select(this.GetAccessControl)
                    .ToArray() ?? Array.Empty<AccessControl>();

                this.RecordsById[id] = new DatabaseRecord(id, workspaceClass, @object.Strategy.ObjectVersion, roleByRoleType, deniedPermissions, accessControls);
            }
        }

        internal DatabaseRecord GetRecord(long id)
        {
            _ = this.RecordsById.TryGetValue(id, out var databaseObjects);
            return databaseObjects;
        }

        internal long GetPermission(IClass @class, IOperandType operandType, Operations operation)
        {
            var classId = this.DatabaseMetaPopulation.FindByTag(@class.Tag).Id;
            var operandId = this.DatabaseMetaPopulation.FindByTag(operandType.OperandTag).Id;

            long permission;
            var permissionCacheEntry = this.permissionCache.Get(classId);

            switch (operation)
            {
                case Operations.Read:
                    _ = permissionCacheEntry.RoleReadPermissionIdByRelationTypeId.TryGetValue(operandId, out permission);
                    break;
                case Operations.Write:
                    _ = permissionCacheEntry.RoleWritePermissionIdByRelationTypeId.TryGetValue(operandId, out permission);
                    break;
                default:
                    _ = permissionCacheEntry.MethodExecutePermissionIdByMethodTypeId.TryGetValue(operandId, out permission);
                    break;
            }

            return permission;
        }

        internal DatabaseRecord OnPushed(long id, IClass @class)
        {
            var record = new DatabaseRecord(id, @class);
            this.RecordsById[id] = record;
            return record;
        }

        internal IEnumerable<IObject> ObjectsToSync(Pull pull) =>
            pull.DatabaseObjects.Where(v =>
            {
                if (this.RecordsById.TryGetValue(v.Id, out var databaseRoles))
                {
                    return v.Strategy.ObjectVersion != databaseRoles.Version;
                }

                return true;
            });

        private AccessControl GetAccessControl(IAccessControl accessControl)
        {
            if (!this.AccessControlById.TryGetValue(accessControl.Strategy.ObjectId, out var acessControl))
            {
                acessControl = new AccessControl(accessControl.Strategy.ObjectId);
                this.AccessControlById.Add(accessControl.Strategy.ObjectId, acessControl);
            }

            if (acessControl.Version == accessControl.Strategy.ObjectVersion)
            {
                return acessControl;
            }

            acessControl.Version = accessControl.Strategy.ObjectVersion;
            acessControl.PermissionIds = new HashSet<long>(accessControl.Permissions.Select(v => v.Id));

            return acessControl;
        }
    }
}