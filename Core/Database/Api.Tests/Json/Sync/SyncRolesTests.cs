// <copyright file="ContentTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the ContentTests type.</summary>

namespace Tests
{
    using Allors.Api.Json;
    using Allors.Domain;
    using Allors.Protocol.Database.Sync;
    using Xunit;

    public class SyncRolesTests : ApiTest, IClassFixture<Fixture>
    {
        public SyncRolesTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void Workspace()
        {
            var m = this.M;
            var user = this.SetUser("jane@example.com");

            var x1 = new WorkspaceXObject1Builder(this.Session)
                .WithWorkspaceXString("x1:x")
                .WithWorkspaceYString("x1:y")
                .WithWorkspaceXYString("x1:xy")
                .WithWorkspaceNonString("x1:none")
                .Build();

            this.Session.Commit();

            var syncRequest = new SyncRequest
            {
                Objects = new[] { x1.Id.ToString() },
            };
            var api = new Api(this.Session, "X");
            var syncResponse = api.Sync(syncRequest);

            Assert.Single(syncResponse.Objects);

            var wx1 = syncResponse.Objects[0];

            Assert.Equal(2, wx1.R.Length);

            var wx1WorkspaceXString = wx1.GetRole(m.WorkspaceXObject1.WorkspaceXString);
            var wx1WorkspaceXYString = wx1.GetRole(m.WorkspaceXObject1.WorkspaceXYString);

            Assert.Equal("x1:x", wx1WorkspaceXString.V);
            Assert.Equal("x1:xy", wx1WorkspaceXYString.V);
        }


        [Fact]
        public void WorkspaceNone()
        {
            var m = this.M;
            var user = this.SetUser("jane@example.com");

            var x1 = new WorkspaceXObject1Builder(this.Session)
                .WithWorkspaceXString("x1:x")
                .WithWorkspaceYString("x1:y")
                .WithWorkspaceXYString("x1:xy")
                .WithWorkspaceNonString("x1:none")
                .Build();

            this.Session.Commit();

            var syncRequest = new SyncRequest
            {
                Objects = new[] { x1.Id.ToString() },
            };
            var api = new Api(this.Session, "None");
            var syncResponse = api.Sync(syncRequest);

            Assert.Empty(syncResponse.Objects);
        }
    }
}