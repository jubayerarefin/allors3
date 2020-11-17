// <copyright file="PullTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace
{
    using System;
    using System.Threading.Tasks;
    using Allors.Workspace;
    using Allors.Workspace.Adapters.Remote;
    using Allors.Workspace.Data;
    using Allors.Workspace.Domain;
    using Xunit;

    public abstract class LoadTests : Test
    {
        [Fact]
        public void WithAccessControl()
        {
            var session = this.Workspace.CreateSession();

            var pull = new Pull
            {
                Extent = new Extent(this.M.C1.ObjectType),
            };

            var result = session.Load(pull).Result;

            var c1s = result.GetCollection<C1>("C1s");
            Assert.Equal(4, c1s.Length);

            result = session.Load(pull).Result;

            var c1s2 = result.GetCollection<C1>("C1s");
            Assert.Equal(4, c1s2.Length);
        }

        [Fact]
        public async void WithoutAccessControl()
        {
            await this.Login("noacl");

            var session = this.Workspace.CreateSession();

            var pull = new Pull
            {
                Extent = new Extent(this.M.C1.ObjectType),
            };

            var result = session.Load(pull).Result;

            var c1s = result.GetCollection<C1>("C1s");

            foreach (var c1 in c1s)
            {
                foreach (var roleType in this.M.C1.ObjectType.RoleTypes)
                {
                    var role = c1.Strategy.Get(roleType);
                    Assert.True(role == null || role is Array array && array.Length == 0);
                }

                foreach (var associationType in this.M.C1.ObjectType.AssociationTypes)
                {
                    if (associationType.IsOne)
                    {
                        var association = c1.Strategy.GetAssociation(associationType);
                        Assert.Null(association);
                    }
                    else
                    {
                        var association = c1.Strategy.GetAssociations(associationType);
                        Assert.Empty(association);
                    }
                }
            }
        }

        [Fact]
        public void WithoutPermissions()
        {
            this.Login("noperm");

            var session = this.Workspace.CreateSession();

            var pull = new Pull
            {
                Extent = new Extent(this.M.C1.ObjectType),
            };

            var result = session.Load(pull).Result;

            var c1s = result.GetCollection<C1>("C1s");

            foreach (var c1 in c1s)
            {
                foreach (var roleType in this.M.C1.ObjectType.RoleTypes)
                {
                    var role = c1.Strategy.Get(roleType);
                    Assert.True(role == null || role is Array array && array.Length == 0);
                }

                foreach (var associationType in this.M.C1.ObjectType.AssociationTypes)
                {
                    if (associationType.IsOne)
                    {
                        var association = c1.Strategy.GetAssociation(associationType);
                        Assert.Null(association);
                    }
                    else
                    {
                        var association = c1.Strategy.GetAssociations(associationType);
                        Assert.Empty(association);
                    }
                }
            }
        }
    }
}