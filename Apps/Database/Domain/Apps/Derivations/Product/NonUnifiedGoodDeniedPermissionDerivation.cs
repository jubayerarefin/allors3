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

    public class NonUnifiedGoodDeniedPermissionDerivation : DomainDerivation
    {
        public NonUnifiedGoodDeniedPermissionDerivation(M m) : base(m, new Guid("af1b5c08-9903-4d80-ad7c-d8588e324e3d")) =>
            this.Patterns = new Pattern[]
        {
            new AssociationPattern(m.NonUnifiedGood.Part),
            new RolePattern(m.Deployment.ProductOffering) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.GoodOrderItem.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.GeneralLedgerAccount.DerivedCostUnitsAllowed) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.GeneralLedgerAccount.DefaultCostUnit) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.QuoteItem.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.ShipmentItem.Good) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.WorkEffortGoodStandard.UnifiedProduct) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.MarketingPackage.ProductsUsedIn) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.MarketingPackage.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.OrganisationGlAccount.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.ProductConfiguration.ProductsUsedIn) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.ProductConfiguration.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.RequestItem.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.SalesInvoiceItem.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.SalesOrderItem.Product) { OfType = m.NonUnifiedGood.Class },
            new RolePattern(m.WorkEffortType.ProductToProduce) { OfType = m.NonUnifiedGood.Class },
        };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var transaction = cycle.Transaction;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<NonUnifiedGood>())
            {
                var deletePermission = new Permissions(@this.Strategy.Transaction).Get(@this.Meta.ObjectType, @this.Meta.Delete);
                if (@this.IsDeletable)
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
