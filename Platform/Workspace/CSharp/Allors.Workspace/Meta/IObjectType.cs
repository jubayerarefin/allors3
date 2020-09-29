// <copyright file="IObjectType.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the IObjectType type.</summary>

namespace Allors.Workspace.Meta
{
    using System;

    public interface IObjectType : IMetaObject, IMetaIdentity, IComparable
    {
        bool IsUnit { get; }

        bool IsComposite { get; }

        bool IsInterface { get; }

        bool IsClass { get; }

        string SingularName { get; }

        string Name { get; }

        string PluralName { get; }

        Type ClrType { get; }
    }
}
