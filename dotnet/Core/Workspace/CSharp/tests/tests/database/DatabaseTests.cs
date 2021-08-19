// <copyright file="Many2OneTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.OriginDatabase
{
    using System.Threading.Tasks;
    using Allors.Workspace.Domain;
    using Xunit;
    using Allors.Workspace.Data;
    using System;
    using System.Linq;

    public abstract class DatabaseTests : Test
    {
        protected DatabaseTests(Fixture fixture) : base(fixture)
        {

        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await this.Login("administrator");
        }

        [Fact]
        public async void PullingANotPushedObjectShouldThrowException()
        {
            var session1 = this.Workspace.CreateSession();

            var c1 = session1.Create<C1>();
            Assert.NotNull(c1);

            var session2 = this.Workspace.CreateSession();

            bool hasErrors;

            try
            {
                var result = await this.AsyncDatabaseClient.PullAsync(session2, new Pull { Object = c1 });
                hasErrors = false;
            }
            catch (Exception)
            {
                hasErrors = true;
            }

            Assert.True(hasErrors);
        }

        [Fact]
        public async void Unit()
        {
            await this.Login("administrator");

            var pull = new[]
            {
                new Pull
                {
                    Extent = new Filter(this.M.C1)
                }
            };

            var session = this.Workspace.CreateSession();
            var result = await this.AsyncDatabaseClient.PullAsync(session, pull);

            var c1s = result.GetCollection<C1>();

            var c1A = c1s.First(v => v.Name.Equals("c1A"));
            var c1B = c1s.First(v => v.Name.Equals("c1B"));
            var c1C = c1s.First(v => v.Name.Equals("c1C"));
            var c1D = c1s.First(v => v.Name.Equals("c1D"));

            Assert.Equal("ᴀbra", c1B.C1AllorsString);
        }
    }
}
