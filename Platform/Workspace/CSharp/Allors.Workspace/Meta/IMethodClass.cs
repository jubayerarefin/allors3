// <copyright file="IMethodClass.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the RoleType type.</summary>

namespace Allors.Workspace.Meta
{
    public interface IMethodClass : IMethodType
    {
        new IClass ObjectType { get; }

        IMethodInterface MethodInterface { get; }
    }
}
