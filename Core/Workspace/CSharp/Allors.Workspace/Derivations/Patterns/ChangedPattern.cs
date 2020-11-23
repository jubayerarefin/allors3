// <copyright file="ChangedRoles.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the IDomainDerivation type.</summary>

namespace Allors.Workspace
{
    using Meta;

    public class ChangedPattern : Pattern
    {
        public ChangedPattern(IRoleType roleType) => this.RoleType = roleType;

        public IRoleType RoleType { get; }
    }
}
