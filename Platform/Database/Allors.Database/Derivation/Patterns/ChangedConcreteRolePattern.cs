// <copyright file="ChangedRoles.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the IDomainDerivation type.</summary>

namespace Allors
{
    using Allors.Meta;

    public class ChangedConcreteRolePattern : Pattern
    {
        public ChangedConcreteRolePattern(IConcreteRoleType concreteRoleType) => this.ConcreteRoleType = concreteRoleType;

        public IConcreteRoleType ConcreteRoleType { get; }
    }
}
