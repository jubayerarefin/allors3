// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Derivations;
    using Meta;
    using Derivations.Rules;

    public class ProposalDeniedPermissionRule : Rule
    {
        public ProposalDeniedPermissionRule(MetaPopulation m) : base(m, new Guid("bbb213db-af36-4686-8e6c-2555b21c4d8c")) =>
            this.Patterns = new Pattern[]
        {
            m.Proposal.RolePattern(v => v.TransitionalDeniedPermissions),
            m.Proposal.RolePattern(v => v.Request),
        };

        public override void Derive(ICycle cycle, IEnumerable<IObject> matches)
        {
            var transaction = cycle.Transaction;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<Proposal>())
            {
                @this.DeniedPermissions = @this.TransitionalDeniedPermissions;

                var deletePermission = new Permissions(@this.Strategy.Transaction).Get(@this.Meta, @this.Meta.Delete);
                if (@this.IsDeletable())
                {
                    @this.RemoveDeniedPermission(deletePermission);
                }
                else
                {
                    @this.AddDeniedPermission(deletePermission);
                }
            }
        }
    }
}
