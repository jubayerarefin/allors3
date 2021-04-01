// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;
    using Database.Derivations;

    public class RequestForProposalDeniedPermissionRule : Rule
    {
        public RequestForProposalDeniedPermissionRule(M m) : base(m, new Guid("1eb65d1c-7164-4c98-aef5-47c3e96f26d7")) =>
            this.Patterns = new Pattern[]
        {
            new RolePattern(m.RequestForProposal, m.RequestForProposal.TransitionalDeniedPermissions),
            new RolePattern(m.RequestItem, m.RequestItem.RequestItemState) { Steps =  new IPropertyType[] { m.RequestItem.RequestWhereRequestItem}, OfType = m.RequestForProposal.Class },
            new AssociationPattern(m.Quote.Request) { OfType = m.RequestForProposal.Class },
        };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var transaction = cycle.Transaction;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<RequestForProposal>())
            {
                @this.DeniedPermissions = @this.TransitionalDeniedPermissions;

                var deletePermission = new Permissions(@this.Strategy.Transaction).Get(@this.Meta.ObjectType, @this.Meta.Delete);
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