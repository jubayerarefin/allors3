// <copyright file="AuthenticationTokenResponse.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Json.Auth
{
    using System.Text.Json.Serialization;

    public class AuthenticationTokenResponse
    {
        [JsonPropertyName("a")]
        public bool Authenticated { get; set; }

        [JsonPropertyName("u")]
        public string UserId { get; set; }

        [JsonPropertyName("t")]
        public string Token { get; set; }
    }
}
