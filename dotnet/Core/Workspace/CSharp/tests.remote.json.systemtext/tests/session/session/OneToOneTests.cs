// <copyright file="Many2OneTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.OriginSession.SessionSession.Remote
{
    using Xunit;

    public class OneToOneTests : SessionSession.OneToOneTests, IClassFixture<Fixture>
    {
        public OneToOneTests(Fixture fixture) : base(fixture) => this.Profile = new Workspace.Remote.Profile();

        public override IProfile Profile { get; }
    }
}
