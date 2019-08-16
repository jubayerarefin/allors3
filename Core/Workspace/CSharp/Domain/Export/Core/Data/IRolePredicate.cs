//-------------------------------------------------------------------------------------------------
// <copyright file="IRolePredicate.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
//-------------------------------------------------------------------------------------------------

using Allors.Workspace.Meta;

namespace Allors.Workspace.Data
{
    public interface IRolePredicate : IPredicate
    {
        IRoleType RoleType { get; set; }
    }
}
