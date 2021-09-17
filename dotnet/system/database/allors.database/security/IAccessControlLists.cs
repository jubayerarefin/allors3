// <copyright file="AccessControlListFactory.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Security
{
    using System.Collections.Generic;

    public interface IAccessControlLists
    {
        IAccessControlList this[IObject @object]
        {
            get;
        }

        ISet<long> PermissionIds(IAccessControl accessControl);

        ISet<long> DeniedPermissionIds(IRestriction restriction);
    }
}
