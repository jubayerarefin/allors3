// <copyright file="ChangeSet.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//   Defines the AllorsChangeSetMemory type.
// </summary>

namespace Allors.Database.Adapters.Memory
{
    using System.Collections.Generic;
    using System.Linq;
    using Adapters;

    using Meta;

    internal sealed class ChangeSet : IChangeSet
    {
        private IDictionary<IRoleType, ISet<IObject>> associationsByRoleType;
        private IDictionary<IAssociationType, ISet<IObject>> rolesByAssociationType;

        internal ChangeSet(ChangeLog changeLog)
        {
            this.Created = new HashSet<IObject>(changeLog.Created.Select(v => v.GetObject()));
            this.Deleted = new HashSet<IStrategy>(changeLog.Deleted);

            this.Associations = new HashSet<IObject>(changeLog.Associations.Select(v => v.GetObject()));
            this.Roles = new HashSet<IObject>(changeLog.Roles.Select(v => v.GetObject()));
            this.RoleTypesByAssociation = changeLog.RoleTypesByAssociation.ToDictionary(kvp => kvp.Key.GetObject(), kvp => kvp.Value);
            this.AssociationTypesByRole = changeLog.AssociationTypesByRole.ToDictionary(kvp => kvp.Key.GetObject(), kvp => kvp.Value);
        }

        public ISet<IObject> Created { get; }

        public ISet<IStrategy> Deleted { get; }

        public ISet<IObject> Associations { get; }

        public ISet<IObject> Roles { get; }

        public IDictionary<IObject, ISet<IRoleType>> RoleTypesByAssociation { get; }

        public IDictionary<IObject, ISet<IAssociationType>> AssociationTypesByRole { get; }

        public IDictionary<IRoleType, ISet<IObject>> AssociationsByRoleType => this.associationsByRoleType ??=
            (from kvp in this.RoleTypesByAssociation
             from value in kvp.Value
             group kvp.Key by value)
                 .ToDictionary(grp => grp.Key, grp => new HashSet<IObject>(grp) as ISet<IObject>);

        public IDictionary<IAssociationType, ISet<IObject>> RolesByAssociationType => this.rolesByAssociationType ??=
            (from kvp in this.AssociationTypesByRole
             from value in kvp.Value
             group kvp.Key by value)
                   .ToDictionary(grp => grp.Key, grp => new HashSet<IObject>(grp) as ISet<IObject>);
    }
}
