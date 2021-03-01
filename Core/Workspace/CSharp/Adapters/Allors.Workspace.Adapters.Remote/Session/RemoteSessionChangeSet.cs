// <copyright file="RemoteSessionChangeSet.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//   Defines the AllorsChangeSetMemory type.
// </summary>

namespace Allors.Workspace.Adapters.Remote
{
    using System.Collections.Generic;
    using System.Linq;
    using Meta;

    internal sealed class RemoteSessionChangeSet : IChangeSet
    {
        private static readonly HashSet<IRoleType> EmptyRoleTypeSet = new HashSet<IRoleType>();
        private static readonly HashSet<IAssociationType> EmptyAssociationTypeSet = new HashSet<IAssociationType>();

        private readonly HashSet<IStrategy> created;
        private readonly HashSet<IStrategy> deleted;

        private readonly HashSet<Identity> associations;
        private readonly HashSet<Identity> roles;

        private readonly Dictionary<Identity, ISet<IRoleType>> roleTypesByAssociation;
        private readonly Dictionary<Identity, ISet<IAssociationType>> associationTypesByRole;

        private IDictionary<IRoleType, ISet<Identity>> associationsByRoleType;
        private IDictionary<IAssociationType, ISet<Identity>> rolesByAssociationType;

        internal RemoteSessionChangeSet(RemoteSession session)
        {
            this.Session = session;
            this.created = new HashSet<IStrategy>();
            this.deleted = new HashSet<IStrategy>();
            this.associations = new HashSet<Identity>();
            this.roles = new HashSet<Identity>();
            this.roleTypesByAssociation = new Dictionary<Identity, ISet<IRoleType>>();
            this.associationTypesByRole = new Dictionary<Identity, ISet<IAssociationType>>();
        }

        ISession IChangeSet.Session => this.Session;
        public RemoteSession Session { get; }

        public ISet<IStrategy> Created => this.created;

        public ISet<IStrategy> Deleted => this.deleted;

        public ISet<Identity> Associations => this.associations;

        public ISet<Identity> Roles => this.roles;

        public IDictionary<Identity, ISet<IRoleType>> RoleTypesByAssociation => this.roleTypesByAssociation;

        public IDictionary<Identity, ISet<IAssociationType>> AssociationTypesByRole => this.associationTypesByRole;

        public IDictionary<IRoleType, ISet<Identity>> AssociationsByRoleType => this.associationsByRoleType ??=
            (from kvp in this.RoleTypesByAssociation
             from value in kvp.Value
             group kvp.Key by value)
                 .ToDictionary(grp => grp.Key, grp => new HashSet<Identity>(grp) as ISet<Identity>);

        public IDictionary<IAssociationType, ISet<Identity>> RolesByAssociationType => this.rolesByAssociationType ??=
            (from kvp in this.AssociationTypesByRole
             from value in kvp.Value
             group kvp.Key by value)
                   .ToDictionary(grp => grp.Key, grp => new HashSet<Identity>(grp) as ISet<Identity>);

        internal void OnCreated(IStrategy strategy) => this.created.Add(strategy);

        internal void OnDeleted(IStrategy strategy) => this.deleted.Add(strategy);

        internal void OnChangingUnitRole(Identity association, IRoleType roleType)
        {
            this.associations.Add(association);

            this.RoleTypes(association).Add(roleType);
        }

        internal void OnChangingCompositeRole(Identity association, IRoleType roleType, Identity previousRole, Identity newRole)
        {
            this.associations.Add(association);

            if (previousRole != null)
            {
                this.roles.Add(previousRole);
                this.AssociationTypes(previousRole).Add(roleType.AssociationType);
            }

            if (newRole != null)
            {
                this.roles.Add(newRole);
                this.AssociationTypes(newRole).Add(roleType.AssociationType);
            }

            this.RoleTypes(association).Add(roleType);
        }

        internal void OnChangingCompositesRole(Identity association, IRoleType roleType, RemoteStrategy changedRole)
        {
            this.associations.Add(association);

            if (changedRole != null)
            {
                this.roles.Add(changedRole.Identity);
                this.AssociationTypes(changedRole.Identity).Add(roleType.AssociationType);
            }

            this.RoleTypes(association).Add(roleType);
        }

        internal void Merge(StateChangeSet workspaceChangeSet, StateChangeSet checkpoint)
        {
        }

        private ISet<IRoleType> RoleTypes(Identity associationId)
        {
            if (!this.RoleTypesByAssociation.TryGetValue(associationId, out var roleTypes))
            {
                roleTypes = new HashSet<IRoleType>();
                this.RoleTypesByAssociation[associationId] = roleTypes;
            }

            return roleTypes;
        }

        private ISet<IAssociationType> AssociationTypes(Identity roleId)
        {
            if (!this.AssociationTypesByRole.TryGetValue(roleId, out var associationTypes))
            {
                associationTypes = new HashSet<IAssociationType>();
                this.AssociationTypesByRole[roleId] = associationTypes;
            }

            return associationTypes;
        }
    }
}