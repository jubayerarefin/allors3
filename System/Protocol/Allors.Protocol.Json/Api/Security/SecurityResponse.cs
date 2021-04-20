// <copyright file="SyncResponse.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Json.Api.Security
{
    using System.Text.Json.Serialization;
    using Push;

    public class SecurityResponse
    {
        [JsonPropertyName("a")]
        public SecurityResponseAccessControl[] AccessControls { get; set; }

        [JsonPropertyName("p")]
        public long[][] Permissions { get; set; }
    }
}
