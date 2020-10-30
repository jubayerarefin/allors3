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

    public class RequestForInformationDeniedPermissionDerivation : DomainDerivation
    {
        public RequestForInformationDeniedPermissionDerivation(M m) : base(m, new Guid("3227f658-588b-42eb-bf4f-f76d1d4b85c4")) =>
            this.Patterns = new Pattern[]
        {
            new ChangedPattern(this.M.RequestForInformation.TransitionalDeniedPermissions),
        };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var session = cycle.Session;
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<RequestForInformation>())
            {
                @this.DeniedPermissions = @this.TransitionalDeniedPermissions;
            }
        }
    }
}
