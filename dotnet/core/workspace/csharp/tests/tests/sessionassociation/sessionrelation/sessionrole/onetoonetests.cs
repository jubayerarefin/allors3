// <copyright file="Many2OneTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.SessionAssociation.SessionRelation.SessionRole
{
    using System.Threading.Tasks;
    using Allors.Workspace.Domain;
    using Allors.Workspace;
    using Xunit;
    using System;

    public abstract class OneToOneTests : Test
    {
        private Func<ISession, Task>[] pushes;

        private Func<Context>[] contextFactories;

        protected OneToOneTests(Fixture fixture) : base(fixture)
        {

        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await this.Login("administrator");

            this.pushes = new Func<ISession, Task>[]
            {
                (_) => Task.CompletedTask,
                (session) =>
                {
                    session.PushToWorkspace();
                    return Task.CompletedTask;
                },
                (session) =>
                {
                    session.PullFromWorkspace();
                    return Task.CompletedTask;
                },
                (session) =>
                {
                    session.PushToWorkspace();
                    session.PullFromWorkspace();
                    return Task.CompletedTask;
                },
                async (session) => await session.PushAsync(),
            };

            var multipleSessionContext = new MultipleSessionContext(this, "Multiple shared");

            this.contextFactories = new Func<Context>[]
            {
                () => multipleSessionContext,
                () => new MultipleSessionContext(this, "Multiple"),
            };
        }

        [Fact]
        public async void SetRole()
        {
            foreach (var push in this.pushes)
            {
                foreach (var contextFactory in this.contextFactories)
                {
                    var ctx = contextFactory();
                    var (session1, session2) = ctx;

                    var c1x_1 = ctx.Session1.Create<SC1>();
                    var c1y_2 = ctx.Session1.Create<SC1>();

                    c1x_1.ShouldNotBeNull(ctx);
                    c1y_2.ShouldNotBeNull(ctx);

                    await session1.PushAsync();

                    c1x_1.SessionSC1One2One = c1y_2;

                    c1x_1.SessionSC1One2One.ShouldEqual(c1y_2, ctx);
                    //c1y_2.SessionSC1One2One.ShouldEqual(c1x_1, ctx);
                    c1y_2.SC1WhereSessionSC1One2One.ShouldEqual(c1x_1, ctx);

                    await push(session1);

                    c1x_1.SessionSC1One2One.ShouldEqual(c1y_2, ctx);
                    //c1y_2.SessionSC1One2One.ShouldEqual(c1x_1, ctx);
                    c1y_2.SC1WhereSessionSC1One2One.ShouldEqual(c1x_1, ctx);
                }
            }
        }

        [Fact]
        public async void RemoveRole()
        {
            foreach (var push1 in this.pushes)
            {
                foreach (var contextFactory in this.contextFactories)
                {
                    var ctx = contextFactory();
                    var (session1, session2) = ctx;

                    var c1x_1 = ctx.Session1.Create<SC1>();
                    var c1y_2 = ctx.Session1.Create<SC1>();

                    c1x_1.ShouldNotBeNull(ctx);
                    c1y_2.ShouldNotBeNull(ctx);

                    await session1.PushAsync();

                    c1x_1.SessionSC1One2One = c1y_2;

                    c1x_1.SessionSC1One2One.ShouldEqual(c1y_2, ctx);
                    //c1y_2.SessionSC1One2One.ShouldEqual(c1x_1, ctx);
                    c1y_2.SC1WhereSessionSC1One2One.ShouldEqual(c1x_1, ctx);

                    c1x_1.RemoveSessionSC1One2One();

                    c1x_1.SessionSC1One2One.ShouldNotEqual(c1y_2, ctx);
                    //c1y_2.SessionSC1One2One.ShouldNotEqual(c1x_1, ctx);
                    c1y_2.SC1WhereSessionSC1One2One.ShouldNotEqual(c1x_1, ctx);

                    await push1(session1);

                    c1x_1.SessionSC1One2One.ShouldNotEqual(c1y_2, ctx);
                    //c1y_2.SessionSC1One2One.ShouldNotEqual(c1x_1, ctx);
                    c1y_2.SC1WhereSessionSC1One2One.ShouldNotEqual(c1x_1, ctx);
                }

            }
        }
    }
}
