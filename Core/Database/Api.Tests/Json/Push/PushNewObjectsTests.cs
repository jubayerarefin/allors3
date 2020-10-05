// <copyright file="PushTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests
{
    using Allors.Api.Json;
    using Allors.Domain;
    using Allors.Protocol.Remote.Push;
    using Xunit;

    public class PushNewObjectTests : ApiTest, IClassFixture<Fixture>
    {
        public PushNewObjectTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void WorkspaceX1ObjectInWorkspaceX()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                NewObjects = new[] { new PushRequestNewObject { T = M.WorkspaceXObject1.Class.IdAsString, NI = "-1" }, },
            };

            var api = new Api(this.Session, "X");
            var pushResponse = api.Push(pushRequest);

            this.Session.Rollback();

            var x1 = (WorkspaceXObject1)this.Session.Instantiate(pushResponse.NewObjects[0].I);

            Assert.NotNull(x1);
        }

        [Fact]
        public void WorkspaceX1ObjectInWorkspaceY()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                NewObjects = new[] { new PushRequestNewObject { T = M.WorkspaceXObject1.Class.IdAsString, NI = "-1" }, },
            };

            var api = new Api(this.Session, "Y");
            var pushResponse = api.Push(pushRequest);

            this.Session.Rollback();

            var x1 = (WorkspaceXObject1)this.Session.Instantiate(pushResponse.NewObjects[0].I);

            Assert.Null(x1);
        }

        [Fact]
        public void WorkspaceX1ObjectInWorkspaceNone()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                NewObjects = new[] { new PushRequestNewObject { T = M.WorkspaceXObject1.Class.IdAsString, NI = "-1" }, },
            };

            var api = new Api(this.Session, "None");
            var pushResponse = api.Push(pushRequest);

            this.Session.Rollback();

            var x1 = (WorkspaceNoneObject1)this.Session.Instantiate(pushResponse.NewObjects[0].I);

            Assert.Null(x1);
        }

        public void WorkspaceY1ObjectInWorkspaceNone()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                NewObjects = new[] { new PushRequestNewObject { T = M.WorkspaceYObject1.Class.IdAsString, NI = "-1" }, },
            };

            var api = new Api(this.Session, "None");
            var pushResponse = api.Push(pushRequest);

            this.Session.Rollback();

            var y1 = (WorkspaceNoneObject1)this.Session.Instantiate(pushResponse.NewObjects[0].I);

            Assert.Null(y1);
        }

        [Fact]
        public void WorkspaceNoneObjectInWorkspaceX()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                NewObjects = new[] { new PushRequestNewObject { T = M.WorkspaceNoneObject1.Class.IdAsString, NI = "-1" }, },
            };

            var api = new Api(this.Session, "X");
            var pushResponse = api.Push(pushRequest);

            this.Session.Rollback();

            var none1 = (WorkspaceNoneObject1)this.Session.Instantiate(pushResponse.NewObjects[0].I);

            Assert.Null(none1);
        }

        [Fact]
        public void WorkspaceNoneObjectInWorkspaceY()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                NewObjects = new[] { new PushRequestNewObject { T = M.WorkspaceNoneObject1.Class.IdAsString, NI = "-1" }, },
            };

            var api = new Api(this.Session, "Y");
            var pushResponse = api.Push(pushRequest);

            this.Session.Rollback();

            var none1 = (WorkspaceNoneObject1)this.Session.Instantiate(pushResponse.NewObjects[0].I);

            Assert.Null(none1);
        }

        [Fact]
        public void WorkspaceNoneObjectInWorkspaceNone()
        {
            this.SetUser("jane@example.com");

            var pushRequest = new PushRequest
            {
                NewObjects = new[] { new PushRequestNewObject { T = M.WorkspaceNoneObject1.Class.IdAsString, NI = "-1" }, },
            };

            var api = new Api(this.Session, "None");
            var pushResponse = api.Push(pushRequest);

            this.Session.Rollback();

            var none1 = (WorkspaceNoneObject1)this.Session.Instantiate(pushResponse.NewObjects[0].I);

            Assert.Null(none1);
        }
    }
}
