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

    public class WorkTaskDeniedPermissionRule : Rule
    {
        public WorkTaskDeniedPermissionRule(M m) : base(m, new Guid("bbff43c6-24ad-4038-9bbd-d666c41751f6")) =>
            this.Patterns = new Pattern[]
        {
            new RolePattern(m.WorkTask, m.WorkTask.TransitionalDeniedPermissions),
            new RolePattern(m.WorkTask, m.WorkTask.CanInvoice),
            new RolePattern(m.WorkTask, m.WorkTask.Customer),
            new RolePattern(m.WorkTask, m.WorkTask.ExecutedBy),
            new AssociationPattern(m.ServiceEntry.WorkEffort),
            new RolePattern(m.ServiceEntry, m.ServiceEntry.ThroughDate) { Steps =  new IPropertyType[] {m.ServiceEntry.WorkEffort} },
        };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var transaction = cycle.Transaction;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<WorkTask>())
            {
                @this.DeniedPermissions = @this.TransitionalDeniedPermissions;

                if (!@this.CanInvoice)
                {
                    @this.AddDeniedPermission(new Permissions(@this.Strategy.Transaction).Get((Class)@this.Strategy.Class, @this.Meta.Invoice));
                }
                else
                {
                    @this.RemoveDeniedPermission(new Permissions(@this.Strategy.Transaction).Get((Class)@this.Strategy.Class, @this.Meta.Invoice));
                }

                var completePermission = new Permissions(@this.Strategy.Transaction).Get((Class)@this.Strategy.Class, @this.Meta.Complete);

                if (@this.ServiceEntriesWhereWorkEffort.Any(v => !v.ExistThroughDate))
                {
                    @this.AddDeniedPermission(new Permissions(@this.Strategy.Transaction).Get((Class)@this.Strategy.Class, @this.Meta.Complete));
                }
                else
                {
                    if (@this.WorkEffortState.IsInProgress)
                    {
                        @this.RemoveDeniedPermission(new Permissions(@this.Strategy.Transaction).Get((Class)@this.Strategy.Class, @this.Meta.Complete));
                    }
                }

                if (@this.WorkEffortState.IsFinished)
                {
                    if (@this.ExecutedBy.Equals(@this.Customer))
                    {
                        @this.RemoveDeniedPermission(new Permissions(@this.Strategy.Transaction).Get((Class)@this.Strategy.Class, @this.Meta.Revise));
                    }
                }
            }
        }
    }
}