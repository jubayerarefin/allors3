
// <copyright file="Many2ManyTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//   Defines the Default type.
// </summary>

using Allors.Adapters;

namespace Allors.Adapters.Object.SqlClient.Snapshot
{
    using System;

    using Adapters;

    public class Many2ManyTest : Adapters.Many2ManyTest, IDisposable
    {
        private readonly Profile profile = new Profile();

        protected override IProfile Profile => this.profile;

        public override void Dispose() => this.profile.Dispose();
    }
}
