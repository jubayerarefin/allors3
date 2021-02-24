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

    public class WorkEffortPurchaseOrderItemAssignmentDerivation : DomainDerivation
    {
        public WorkEffortPurchaseOrderItemAssignmentDerivation(M m) : base(m, new Guid("db1b303e-40e2-446a-a04c-a51521bc8fcd")) =>
            this.Patterns = new Pattern[]
        {
            new AssociationPattern(m.WorkEffortPurchaseOrderItemAssignment.Assignment),
            new AssociationPattern(m.WorkEffortPurchaseOrderItemAssignment.PurchaseOrderItem),
            new AssociationPattern(m.PurchaseOrderItem.UnitPrice) { Steps = new IPropertyType[] { m.PurchaseOrderItem.WorkEffortPurchaseOrderItemAssignmentsWherePurchaseOrderItem } },
        };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var transaction = cycle.Transaction;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<WorkEffortPurchaseOrderItemAssignment>())
            {
                if (@this.ExistPurchaseOrderItem)
                {
                    @this.PurchaseOrder = @this.PurchaseOrderItem.PurchaseOrderWherePurchaseOrderItem;
                    @this.UnitPurchasePrice = @this.PurchaseOrderItem.UnitPrice;
                }

                if (@this.ExistAssignment)
                {
                    @this.Assignment.ResetPrintDocument();
                }
            }
        }
    }
}
