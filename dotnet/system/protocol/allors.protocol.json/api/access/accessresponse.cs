// <copyright file="SyncResponse.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Json.Api.Security
{
    public class AccessResponse
    {
        /// <summary>
        /// Grants
        /// </summary>
        public AccessResponseGrant[] g { get; set; }

        /// <summary>
        /// Revocations
        /// </summary>
        public AccessResponseRevocation[] r { get; set; }
    }
}