// <copyright file="SecurityResponseBuilder.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Server
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using Allors.Domain;
    using Allors.Protocol.Remote.Security;

    public class SecurityResponseBuilder
    {
        private readonly ISession session;
        private readonly SecurityRequest securityRequest;

        public SecurityResponseBuilder(ISession session, SecurityRequest securityRequest)
        {
            this.session = session;
            this.securityRequest = securityRequest;
        }

        public SecurityResponse Build()
        {
            var securityResponse = new SecurityResponse();

            if (this.securityRequest.AccessControls != null)
            {
                var accessControlIds = this.securityRequest.AccessControls;
                var accessControls = this.session.Instantiate(accessControlIds).Cast<AccessControl>().ToArray();

                securityResponse.AccessControls = accessControls
                    .Select(v => new SecurityResponseAccessControl
                    {
                        I = v.Strategy.ObjectId.ToString(),
                        V = v.Strategy.ObjectVersion.ToString(),
                        P = v.EffectiveWorkspacePermissionIds,
                    }).ToArray();
            }

            if (this.securityRequest.Permissions.Length > 0)
            {
                var permissionIds = this.securityRequest.Permissions;
                var permissions = this.session.Instantiate(permissionIds)
                    .Cast<Permission>()
                    .Where(v => v switch
                    {
                        RoleReadPermission permission => permission.RelationType.WorkspaceNames.Length > 0,
                        RoleWritePermission permission => permission.RelationType.WorkspaceNames.Length > 0,
                        AssociationReadPermission permission => permission.RelationType.WorkspaceNames.Length > 0,
                        MethodExecutePermission permission => permission.MethodType.WorkspaceNames.Length > 0,
                        _ => throw new Exception(),
                    });

                securityResponse.Permissions = permissions.Select(v =>
                    v switch
                    {
                        RoleReadPermission permission => new[]
                        {
                            permission.Strategy.ObjectId.ToString(),
                            permission.ConcreteClassPointer.ToString("D"),
                            permission.RelationTypePointer.ToString("D"),
                            Operations.Read.ToString(),
                        },
                        RoleWritePermission permission => new[]
                        {
                            permission.Strategy.ObjectId.ToString(),
                            permission.ConcreteClassPointer.ToString("D"),
                            permission.RelationTypePointer.ToString("D"),
                            Operations.Write.ToString(),
                        },
                        AssociationReadPermission permission => new[]
                        {
                            permission.Strategy.ObjectId.ToString(),
                            permission.ConcreteClassPointer.ToString("D"),
                            permission.RelationTypePointer.ToString("D"),
                            Operations.Read.ToString(),
                        },
                        MethodExecutePermission permission => new[]
                        {
                            permission.Strategy.ObjectId.ToString(),
                            permission.ConcreteClassPointer.ToString("D"),
                            permission.MethodTypePointer.ToString("D"),
                            Operations.Execute.ToString(),
                        },
                        _ => throw new Exception(),
                    }).ToArray();
            }

            return securityResponse;
        }
    }
}
