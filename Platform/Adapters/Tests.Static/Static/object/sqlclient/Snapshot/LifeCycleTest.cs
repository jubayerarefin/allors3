
// <copyright file="LifeCycleTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

using Allors.Adapters;

namespace Allors.Adapters.Object.SqlClient.Snapshot
{
    using System;

    using Adapters;

    using Allors;

    public class LifeCycleTest : Adapters.LifeCycleTest, IDisposable
    {
        private readonly Profile profile = new Profile();

        protected override IProfile Profile => this.profile;

        public override void Dispose() => this.profile.Dispose();

        protected override void SwitchDatabase() => this.profile.SwitchDatabase();

        protected override IDatabase CreatePopulation() => this.profile.CreateDatabase();

        protected override ISession CreateSession() => this.profile.CreateSession();
    }
}
