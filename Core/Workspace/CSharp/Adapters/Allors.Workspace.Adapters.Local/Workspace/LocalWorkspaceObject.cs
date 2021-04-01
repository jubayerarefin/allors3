// <copyright file="LocalWorkspaceObject.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Workspace.Adapters.Local
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;

    internal class LocalWorkspaceObject
    {
        private readonly IReadOnlyDictionary<IRelationType, object> roleByRelationType;

        internal LocalWorkspaceObject(LocalDatabase database, long identity, IClass @class, long version, IReadOnlyDictionary<IRelationType, object> roleByRelationType)
        {
            this.Database = database;
            this.Identity = identity;
            this.Class = @class;
            this.Version = version;

            this.roleByRelationType = this.Import(roleByRelationType).ToDictionary(v => v.Key, v => v.Value);
        }

        public LocalWorkspaceObject(LocalWorkspaceObject originalWorkspaceObject, IReadOnlyDictionary<IRelationType, object> changedRoleByRoleType)
        {
            this.Database = originalWorkspaceObject.Database;
            this.Identity = originalWorkspaceObject.Identity;
            this.Class = originalWorkspaceObject.Class;
            this.Version = ++originalWorkspaceObject.Version;


            this.roleByRelationType = this.Import(changedRoleByRoleType, originalWorkspaceObject.roleByRelationType).ToDictionary(v => v.Key, v => v.Value);
        }

        internal LocalDatabase Database { get; }

        internal IClass Class { get; }

        internal long Identity { get; }

        internal long Version { get; private set; }

        internal object GetRole(IRoleType roleType)
        {
            object @object = null;
            this.roleByRelationType?.TryGetValue(roleType.RelationType, out @object);
            return @object;
        }

        private IEnumerable<KeyValuePair<IRelationType, object>> Import(IReadOnlyDictionary<IRelationType, object> changedRoleByRoleType, IReadOnlyDictionary<IRelationType, object> originalRoleByRoleType = null)
        {
            foreach (var roleType in this.Class.WorkspaceRoleTypes)
            {
                var relationType = roleType.RelationType;

                if (changedRoleByRoleType.TryGetValue(relationType, out var role))
                {
                    if (role != null)
                    {
                        if (roleType.ObjectType.IsUnit)
                        {
                            yield return new KeyValuePair<IRelationType, object>(relationType, role);
                        }
                        else
                        {
                            if (roleType.IsOne)
                            {
                                yield return new KeyValuePair<IRelationType, object>(relationType, ((LocalStrategy)role).Id);

                            }
                            else
                            {
                                var roles = ((LocalStrategy[])role);
                                if (roles.Length > 0)
                                {
                                    yield return new KeyValuePair<IRelationType, object>(relationType, roles.Select(v => v.Id).ToArray());
                                }
                            }
                        }
                    }
                }
                else if (originalRoleByRoleType?.TryGetValue(roleType.RelationType, out role) == true)
                {
                    yield return new KeyValuePair<IRelationType, object>(relationType, role);
                }
            }
        }
    }
}