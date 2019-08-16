
// <copyright file="RoleInstanceOf.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Adapters.Memory
{
    using Allors.Meta;
    using Adapters;

    internal sealed class RoleInstanceof : Predicate
    {
        private readonly IRoleType roleType;
        private readonly IComposite objectType;

        internal RoleInstanceof(ExtentFiltered extent, IRoleType roleType, IComposite objectType)
        {
            extent.CheckForRoleType(roleType);
            PredicateAssertions.ValidateRoleInstanceOf(roleType, objectType);

            this.roleType = roleType;
            this.objectType = objectType;
        }

        internal override ThreeValuedLogic Evaluate(Strategy strategy)
        {
            var role = strategy.GetCompositeRole(this.roleType.RelationType);

            if (role == null)
            {
                return ThreeValuedLogic.False;
            }

            // TODO: Optimize
            var roleObjectType = role.Strategy.Class;
            if (roleObjectType.Equals(this.objectType))
            {
                return ThreeValuedLogic.True;
            }

            var @interface = this.objectType as IInterface;
            return (@interface != null && roleObjectType.ExistSupertype(@interface))
                       ? ThreeValuedLogic.True
                       : ThreeValuedLogic.False;
        }
    }
}
