// <copyright file="WorkspaceObject.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Server
{
    using System.Linq;
    using Domain;
    using Protocol;
    using Protocol.Database;

    internal class PermissionsWriter
    {
        private readonly IAccessControlLists acls;

        internal PermissionsWriter(IAccessControlLists acls) => this.acls = acls;

        public string Write(IObject @object)
        {
            var deniedPermissionIds = this.acls[@object].DeniedPermissionIds;
            return deniedPermissionIds == null ? null : string.Join(Encoding.Separator, deniedPermissionIds.OrderBy(v => v));
        }
    }
}
