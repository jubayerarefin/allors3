﻿
// <copyright file="RequestForInformation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Allors.Domain
{
    using Allors.Meta;

    public partial class RequestForInformation
    {
        public static readonly TransitionalConfiguration[] StaticTransitionalConfigurations =
            {
                new TransitionalConfiguration(M.RequestForInformation, M.RequestForInformation.RequestState),
            };

        public TransitionalConfiguration[] TransitionalConfigurations => StaticTransitionalConfigurations;

        public void BaseOnDerive(ObjectOnDerive method) => this.Sync(this.Strategy.Session);

        private void Sync(ISession session)
        {
            //session.Prefetch(this.SyncPrefetch, this);

            foreach (RequestItem requestItem in this.RequestItems)
            {
                requestItem.Sync(this);
            }
        }
    }
}
