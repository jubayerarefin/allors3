// <copyright file="PushTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests
{
    
    using Allors.Database.Domain;
    using Allors.Protocol.Json.Api.Push;
    using Allors.Database.Protocol.Json;
    using Xunit;

    public class PushExistingObjectTests : ApiTest, IClassFixture<Fixture>
    {
        private WorkspaceXObject1 x1;
        private long x1Version;

        private WorkspaceYObject1 y1;
        private long y1Version;

        private WorkspaceNoneObject1 none1;
        private long none1Version;

        public PushExistingObjectTests(Fixture fixture) : base(fixture)
        {
            this.x1 = new WorkspaceXObject1Builder(this.Transaction).Build();
            this.y1 = new WorkspaceYObject1Builder(this.Transaction).Build();
            this.none1 = new WorkspaceNoneObject1Builder(this.Transaction).Build();

            this.x1Version = this.x1.Strategy.ObjectVersion;
            this.y1Version = this.y1.Strategy.ObjectVersion;
            this.none1Version = this.none1.Strategy.ObjectVersion;

            this.Transaction.Commit();
        }

        [Fact]
        public void WorkspaceX1ObjectInWorkspaceX()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                Objects = new[]
                {
                    new PushRequestObject
                    {
                        DatabaseId = this.x1.Id,
                        Version = this.x1.Strategy.ObjectVersion,
                        Roles = new []
                        {
                            new PushRequestRole
                            {
                                RelationType = this.M.WorkspaceXObject1.WorkspaceXString.RelationType.Tag,
                                SetUnitRole = "x string"
                            },
                        }
                    },
                }
            };

            var api = new Api(this.Transaction, "X");
            var pushResponse = api.Push(pushRequest);

            this.Transaction.Rollback();

            Assert.NotEqual(this.x1.Strategy.ObjectVersion, this.x1Version);
            Assert.Equal("x string", this.x1.WorkspaceXString);
        }


        [Fact]
        public void WorkspaceX1ObjectInWorkspaceY()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                Objects = new[]
                {
                    new PushRequestObject
                    {
                        DatabaseId = this.x1.Id,
                        Version = this.x1.Strategy.ObjectVersion,
                        Roles = new []
                        {
                            new PushRequestRole
                            {
                                RelationType = this.M.WorkspaceXObject1.WorkspaceXString.RelationType.Tag,
                                SetUnitRole = "x string"
                            },
                        }
                    },
                }
            };

            var api = new Api(this.Transaction, "Y");
            var pushResponse = api.Push(pushRequest);

            this.Transaction.Rollback();

            Assert.Equal(this.x1.Strategy.ObjectVersion, this.x1Version);
            Assert.Null(this.x1.WorkspaceXString);
        }
    }
}
