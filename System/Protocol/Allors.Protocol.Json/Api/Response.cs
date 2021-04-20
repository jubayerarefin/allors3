// <copyright file="ErrorResponse.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Json.Api
{
    public abstract class Response
    {
        public bool HasErrors => this.VersionErrors?.Length > 0 || this.AccessErrors?.Length > 0 || this.MissingErrors?.Length > 0 || this.DerivationErrors?.Length > 0 || !string.IsNullOrWhiteSpace(this.ErrorMessage);

        public string ErrorMessage { get; set; }

        public long[] VersionErrors { get; set; }

        public long[] AccessErrors { get; set; }

        public long[] MissingErrors { get; set; }

        public ResponseDerivationError[] DerivationErrors { get; set; }
    }
}
