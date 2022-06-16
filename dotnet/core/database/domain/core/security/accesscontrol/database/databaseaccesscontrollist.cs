// <copyright file="AccessControlList.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Security;
    using Meta;

    /// <summary>
    /// List of permissions for an object/user combination.
    /// </summary>
    public class DatabaseAccessControlList : IAccessControlList
    {
        private readonly DatabaseAccessControl accessControl;
        private readonly IVersionedSecurityToken[] securityTokens;
        private readonly IVersionedRevocation[] revocations;

        private readonly IReadOnlyDictionary<Guid, long> readPermissionIdByRelationTypeId;
        private readonly IReadOnlyDictionary<Guid, long> writePermissionIdByRelationTypeId;
        private readonly IReadOnlyDictionary<Guid, long> executePermissionIdByMethodTypeId;

        internal DatabaseAccessControlList(DatabaseAccessControl accessControl, Object @object, IVersionedSecurityToken[] securityTokens, IVersionedRevocation[] revocations)
        {
            this.accessControl = accessControl;
            this.securityTokens = securityTokens;
            this.revocations = revocations;
            this.Object = @object;

            if (this.Object != null)
            {
                var @class = this.Object.Strategy.Class;
                this.readPermissionIdByRelationTypeId = @class.ReadPermissionIdByRelationTypeId;
                this.writePermissionIdByRelationTypeId = @class.WritePermissionIdByRelationTypeId;
                this.executePermissionIdByMethodTypeId = @class.ExecutePermissionIdByMethodTypeId;
            }
        }

        public Object Object { get; }

        IVersionedSecurityToken[] IAccessControlList.SecurityTokens => this.securityTokens;

        IVersionedRevocation[] IAccessControlList.Revocations => this.revocations;

        public bool CanRead(IRoleType roleType) => this.readPermissionIdByRelationTypeId?.TryGetValue(roleType.RelationType.Id, out var permissionId) == true && this.IsPermitted(permissionId);

        public bool CanWrite(IRoleType roleType) => !roleType.RelationType.IsDerived && this.writePermissionIdByRelationTypeId?.TryGetValue(roleType.RelationType.Id, out var permissionId) == true && this.IsPermitted(permissionId);

        public bool CanExecute(IMethodType methodType) => this.executePermissionIdByMethodTypeId?.TryGetValue(methodType.Id, out var permissionId) == true && this.IsPermitted(permissionId);

        public bool IsMasked() => this.accessControl.IsMasked(this.Object);

        private bool IsPermitted(long permissionId)
        {
            if (this.securityTokens.Any(v => v.PermissionSet.Contains(permissionId)))
            {
                return this.revocations?.Any(v => v.PermissionSet.Contains(permissionId)) != true;
            }

            return false;
        }
    }
}
