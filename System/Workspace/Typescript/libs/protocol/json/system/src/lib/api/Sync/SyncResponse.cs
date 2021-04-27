// <copyright file="SyncResponse.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Json.Api.Sync
{
    using System.Text.Json.Serialization;

    public class SyncResponse
    {
        [JsonPropertyName("o")]
        public SyncResponseObject[] Objects { get; set; }

        [JsonPropertyName("a")]
        public long[][] AccessControls { get; set; }
    }
}
