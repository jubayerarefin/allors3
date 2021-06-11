// <copyright file="SyncResponse.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Json.Api.Sync
{
    public class SyncResponse
    {
        /// <summary>
        /// Objects
        /// </summary>
        public SyncResponseObject[] o { get; set; }

        /// <summary>
        /// AccessControls
        /// </summary>
        public long[][] a { get; set; }
    }
}
