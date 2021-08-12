// <copyright file="Many2OneTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.OriginSession.SessionWorkspace.Local
{
    using Workspace.Local;
    using Xunit;

    public class ManyToManyTests : SessionWorkspace.ManyToManyTests, IClassFixture<Fixture>
    {
        public ManyToManyTests(Fixture fixture) : base(fixture) => this.Profile = new Profile(fixture);

        public override IProfile Profile { get; }
    }
}
