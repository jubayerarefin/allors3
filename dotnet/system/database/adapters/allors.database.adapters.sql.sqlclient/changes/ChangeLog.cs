// <copyright file="ChangeSet.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//   Defines the AllorsChangeSetMemory type.
// </summary>

namespace Allors.Database.Adapters.Sql.SqlClient
{
    using System.Collections.Generic;
    using System.Linq;
    using Meta;

    internal sealed class ChangeLog
    {
        private readonly HashSet<Strategy> created;
        private readonly HashSet<IStrategy> deleted;

        private readonly HashSet<Strategy> changedRoleTypes;
        private readonly HashSet<Strategy> changedAssociationTypes;

        internal ChangeLog()
        {
            this.created = new HashSet<Strategy>();
            this.deleted = new HashSet<IStrategy>();
            this.changedRoleTypes = new HashSet<Strategy>();
            this.changedAssociationTypes = new HashSet<Strategy>();
        }

        internal void OnCreated(Strategy strategy) => this.created.Add(strategy);

        internal void OnDeleted(Strategy strategy) => this.deleted.Add(strategy);

        internal void OnChangedRoleTypes(Strategy strategy) => this.changedRoleTypes.Add(strategy);

        internal void OnChangedAssociationTypes(Strategy strategy) => this.changedAssociationTypes.Add(strategy);

        internal ChangeSet Checkpoint() =>
            new ChangeSet(
                this.created != null ? new HashSet<IObject>(this.created.Select(v => v.GetObject())) : null,
                this.deleted,
                this.RoleTypesByAssociation().ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                this.AssociationTypesByRole().ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
            );

        private IEnumerable<KeyValuePair<IObject, ISet<IRoleType>>> RoleTypesByAssociation()
        {
            foreach (var strategy in this.changedRoleTypes)
            {
                if (strategy.IsDeleted)
                {
                    continue;
                }

                var changedRoleTypes = strategy.CheckpointRoleTypes;
                if (changedRoleTypes != null)
                {
                    yield return new KeyValuePair<IObject, ISet<IRoleType>>(strategy.GetObject(), changedRoleTypes);
                }
            }
        }

        private IEnumerable<KeyValuePair<IObject, ISet<IAssociationType>>> AssociationTypesByRole()
        {
            foreach (var strategy in this.changedAssociationTypes)
            {
                if (strategy.IsDeleted)
                {
                    continue;
                }

                var changedAssociationTypes = strategy.CheckpointAssociationTypes;
                if (changedAssociationTypes != null)
                {
                    yield return new KeyValuePair<IObject, ISet<IAssociationType>>(strategy.GetObject(), changedAssociationTypes);
                }
            }
        }
    }
}
