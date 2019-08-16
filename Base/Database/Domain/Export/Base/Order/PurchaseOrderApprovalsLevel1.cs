
// <copyright file="PurchaseOrderApprovalsLevel1.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using Meta;

    public partial class PurchaseOrderApprovalsLevel1
    {
        protected override void BaseSecure(Security config)
        {
            var full = new[] { Operations.Read, Operations.Write, Operations.Execute };
            config.GrantOwner(this.ObjectType, full);
        }
    }
}
