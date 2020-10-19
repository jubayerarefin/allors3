// <copyright file="UserExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;

    public static partial class UserExtensions
    {

        public static void BaseOnPostBuild(this User @this, ObjectOnPostBuild method)
        {
            if (!@this.ExistNotificationList)
            {
                @this.NotificationList = new NotificationListBuilder(@this.Strategy.Session).Build();
            }
        }

        public static void BaseDelete(this User @this, DeletableDelete method)
        {
            @this.NotificationList?.Delete();
        }
    }
}
