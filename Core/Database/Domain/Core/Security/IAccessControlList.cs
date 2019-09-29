// <copyright file="AccessControlList.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System.Collections.Generic;
    using Allors.Meta;

    /// <summary>
    /// List of permissions for an object/user combination.
    /// </summary>
    public interface IAccessControlList
    {
        IAccessControlListFactory AccessControlListFactory { get; }

        IEnumerable<AccessControl> AccessControls { get; }

        IEnumerable<long> DeniedPermissionIds { get; }

        Object Object { get; }

        bool CanRead(IPropertyType propertyType);

        bool CanRead(IConcreteRoleType roleType);

        bool CanWrite(IRoleType roleType);

        bool CanWrite(IConcreteRoleType roleType);

        bool CanExecute(IMethodType methodType);

        bool IsPermitted(IOperandType operandType, Operations operation);
    }
}
