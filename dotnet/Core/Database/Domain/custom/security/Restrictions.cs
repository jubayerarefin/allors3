// <copyright file="Roles.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the role type.</summary>

namespace Allors.Database.Domain
{
    using System;

    public partial class Restrictions
    {
        public static readonly Guid ToggleRestrictionId = new Guid("68BB6EC4-CF15-47D1-8F87-D817419C9482");

        public Restriction ToggleRestriction => this.Cache[ToggleRestrictionId];

        protected override void CustomSecure(Security security)
        {
            var merge = this.Cache.Merger().Action();

            merge(ToggleRestrictionId, _ => { });
        }
    }
}
