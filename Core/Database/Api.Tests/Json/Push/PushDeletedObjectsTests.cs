// <copyright file="PushTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests
{
    using System;
    using Allors.Api.Json;
    using Allors.Domain;
    using Allors.Protocol.Database.Push;
    using Xunit;

    public class PushDeletedObjectsTests : ApiTest, IClassFixture<Fixture>
    {
        public PushDeletedObjectsTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void SameWorkspace()
        {
            this.SetUser("jane@example.com");

            var organisation = new OrganisationBuilder(this.Session).Build();
            this.Session.Commit();

            var organisationId = organisation.Id.ToString();
            var organisationVersion = organisation.Strategy.ObjectVersion.ToString();

            organisation.Delete();
            this.Session.Commit();

            var uri = new Uri(@"allors/push", UriKind.Relative);

            var pushRequest = new PushRequest
            {
                Objects = new[]
                {
                    new PushRequestObject
                    {
                        I = organisationId,
                        V = organisationVersion,
                        Roles = new[]
                        {
                            new PushRequestRole
                            {
                              T = this.M.Organisation.Name.RelationType.IdAsString,
                              S = "Acme"
                            },
                        },
                    },
                },
            };

            var api = new Api(this.Session, "Default");
            var pushResponse = api.Push(pushRequest);

            Assert.True(pushResponse.HasErrors);
            Assert.Single(pushResponse.MissingErrors);
            Assert.Contains(organisationId, pushResponse.MissingErrors);
        }
    }
}