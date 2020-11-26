// <copyright file="PushResponse.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Json.Api.Push
{
    using System.Text.Json.Serialization;

    public class PushResponse : Response
    {
        [JsonPropertyName("newObjects")]
        public PushResponseNewObject[] NewObjects { get; set; }
    }
}