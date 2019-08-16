
// <copyright file="ExtentTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

using Xunit;

namespace Allors.Adapters.Object.Npgsql.ReadCommitted
{
    using Allors;

    [Collection(Fixture.Collection)]
    public class ExtentTest : Npgsql.ExtentTest
    {
        private readonly Profile profile;

        public ExtentTest(Fixture fixture) => this.profile = new Profile(fixture.Server);

        protected override IProfile Profile => this.profile;

        public override void Dispose() => this.profile.Dispose();

        protected override ISession CreateSession() => this.profile.CreateSession();
    }
}
