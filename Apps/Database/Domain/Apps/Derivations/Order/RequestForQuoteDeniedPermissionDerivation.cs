// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Meta;

    public class RequestForQuoteDeniedPermissionDerivation : DomainDerivation
    {
        public RequestForQuoteDeniedPermissionDerivation(M m) : base(m, new Guid("eb67ef60-1a60-4b52-85ac-979fb9346242")) =>
            this.Patterns = new Pattern[]
        {
            new ChangedPattern(this.M.RequestForQuote.TransitionalDeniedPermissions),
            new ChangedPattern(this.M.RequestForQuote.RequestState),
        };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var session = cycle.Session;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<RequestForQuote>())
            {
                @this.DeniedPermissions = @this.TransitionalDeniedPermissions;

                if (!@this.ExistOriginator)
                {
                    @this.AddDeniedPermission(new Permissions(@this.Strategy.Session).Get(@this.Meta.Class, @this.Meta.Submit));
                }

                var deletePermission = new Permissions(@this.Strategy.Session).Get(@this.Meta.ObjectType, @this.Meta.Delete);
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