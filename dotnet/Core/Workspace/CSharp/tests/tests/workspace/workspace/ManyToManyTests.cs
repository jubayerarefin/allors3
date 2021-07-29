// <copyright file="Many2OneTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.OriginWorkspace.WorkspaceWorkspace
{
    using System.Threading.Tasks;
    using Allors.Workspace.Domain;
    using Allors.Workspace;
    using Xunit;
    using System;
    using System.Linq;

    public abstract class ManyToManyTests : Test
    {
        private Func<Context>[] contextFactories;
        private Action<ISession>[] pushes;

        protected ManyToManyTests(Fixture fixture) : base(fixture)
        {

        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await this.Login("administrator");

            var singleSessionContext = new SingleSessionContext(this, "Single shared");
            var multipleSessionContext = new MultipleSessionContext(this, "Multiple shared");

            this.pushes = new Action<ISession>[]
            {
                (session) => { },
                (session) => session.PushToWorkspace(),
                (session) => {session.PushToWorkspace(); session.PullFromWorkspace(); }
            };

            this.contextFactories = new Func<Context>[]
            {
                () => singleSessionContext,
                () => new SingleSessionContext(this, "Single"),
                () => multipleSessionContext,
                () => new MultipleSessionContext(this, "Multiple"),
            };
        }

        [Fact]
        public async void SetRole()
        {
            foreach (var push in this.pushes)
            {
                foreach (WorkspaceMode mode1 in Enum.GetValues(typeof(WorkspaceMode)))
                {
                    foreach (WorkspaceMode mode2 in Enum.GetValues(typeof(WorkspaceMode)))
                    {
                        foreach (var contextFactory in this.contextFactories)
                        {
                            var ctx = contextFactory();
                            var (session1, session2) = ctx;

                            var c1x_1 = await ctx.Create<WorkspaceC1>(session1, mode1);
                            var c1y_2 = await ctx.Create<WorkspaceC1>(session2, mode2);

                            c1x_1.ShouldNotBeNull(ctx, mode1, mode2);
                            c1y_2.ShouldNotBeNull(ctx, mode1, mode2);

                            session2.PushToWorkspace();
                            session1.PullFromWorkspace();

                            var c1y_1 = session1.Instantiate(c1y_2);

                            c1y_1.ShouldNotBeNull(ctx, mode1, mode2);

                            c1x_1.AddWorkspaceC1WorkspaceC1Many2Many(c1y_1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldContains(c1x_1, ctx, mode1, mode2);
                            Assert.Single(c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.Where(v => v.Equals(c1x_1)));


                            push(session1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldContains(c1x_1, ctx, mode1, mode2);
                            Assert.Single(c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.Where(v => v.Equals(c1x_1)));
                        }
                    }
                }
            }
        }

        [Fact]
        public async void SetRoleToNull()
        {
            foreach (var push in this.pushes)
            {
                foreach (WorkspaceMode mode1 in Enum.GetValues(typeof(WorkspaceMode)))
                {
                    foreach (WorkspaceMode mode2 in Enum.GetValues(typeof(WorkspaceMode)))
                    {
                        foreach (var contextFactory in this.contextFactories)
                        {
                            var ctx = contextFactory();
                            var (session1, session2) = ctx;

                            var c1x_1 = await ctx.Create<WorkspaceC1>(session1, mode1);
                            var c1y_2 = await ctx.Create<WorkspaceC1>(session2, mode2);

                            c1x_1.ShouldNotBeNull(ctx, mode1, mode2);
                            c1y_2.ShouldNotBeNull(ctx, mode1, mode2);

                            session2.PushToWorkspace();
                            session1.PullFromWorkspace();

                            var c1y_1 = session1.Instantiate(c1y_2);

                            c1y_1.ShouldNotBeNull(ctx, mode1, mode2);

                            c1x_1.AddWorkspaceC1WorkspaceC1Many2Many(null);

                            Assert.Empty(c1x_1.WorkspaceC1WorkspaceC1Many2Manies);

                            c1x_1.AddWorkspaceC1WorkspaceC1Many2Many(c1y_1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldContains(c1x_1, ctx, mode1, mode2);
                            Assert.Single(c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.Where(v => v.Equals(c1x_1)));


                            push(session1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldContains(c1x_1, ctx, mode1, mode2);
                            Assert.Single(c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.Where(v => v.Equals(c1x_1)));
                        }
                    }
                }
            }
        }

        [Fact]
        public async void RemoveRole()
        {
            foreach (var push in this.pushes)
            {
                foreach (WorkspaceMode mode1 in Enum.GetValues(typeof(WorkspaceMode)))
                {
                    foreach (WorkspaceMode mode2 in Enum.GetValues(typeof(WorkspaceMode)))
                    {
                        foreach (var contextFactory in this.contextFactories)
                        {
                            var ctx = contextFactory();
                            var (session1, session2) = ctx;

                            var c1x_1 = await ctx.Create<WorkspaceC1>(session1, mode1);
                            var c1y_2 = await ctx.Create<WorkspaceC1>(session2, mode2);

                            c1x_1.ShouldNotBeNull(ctx, mode1, mode2);
                            c1y_2.ShouldNotBeNull(ctx, mode1, mode2);

                            session2.PushToWorkspace();
                            session1.PullFromWorkspace();

                            var c1y_1 = session1.Instantiate(c1y_2);

                            c1y_1.ShouldNotBeNull(ctx, mode1, mode2);

                            c1x_1.AddWorkspaceC1WorkspaceC1Many2Many(c1y_1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldContains(c1x_1, ctx, mode1, mode2);
                            Assert.Single(c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.Where(v => v.Equals(c1x_1)));

                            c1x_1.RemoveWorkspaceC1WorkspaceC1Many2Many(c1y_1);
                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldNotContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldNotContains(c1x_1, ctx, mode1, mode2);

                            push(session1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldNotContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldNotContains(c1x_1, ctx, mode1, mode2);
                        }
                    }
                }
            }
        }

        [Fact]
        public async void RemoveNullRole()
        {
            foreach (var push in this.pushes)
            {
                foreach (WorkspaceMode mode1 in Enum.GetValues(typeof(WorkspaceMode)))
                {
                    foreach (WorkspaceMode mode2 in Enum.GetValues(typeof(WorkspaceMode)))
                    {
                        foreach (var contextFactory in this.contextFactories)
                        {
                            var ctx = contextFactory();
                            var (session1, session2) = ctx;

                            var c1x_1 = await ctx.Create<WorkspaceC1>(session1, mode1);
                            var c1y_2 = await ctx.Create<WorkspaceC1>(session2, mode2);

                            c1x_1.ShouldNotBeNull(ctx, mode1, mode2);
                            c1y_2.ShouldNotBeNull(ctx, mode1, mode2);

                            session2.PushToWorkspace();
                            session1.PullFromWorkspace();

                            var c1y_1 = session1.Instantiate(c1y_2);

                            c1y_1.ShouldNotBeNull(ctx, mode1, mode2);

                            c1x_1.AddWorkspaceC1WorkspaceC1Many2Many(c1y_1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldContains(c1x_1, ctx, mode1, mode2);
                            Assert.Single(c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.Where(v => v.Equals(c1x_1)));

                            c1x_1.RemoveWorkspaceC1WorkspaceC1Many2Many(null);
                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldContains(c1x_1, ctx, mode1, mode2);

                            c1x_1.RemoveWorkspaceC1WorkspaceC1Many2Many(c1y_1);
                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldNotContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldNotContains(c1x_1, ctx, mode1, mode2);

                            push(session1);

                            c1x_1.WorkspaceC1WorkspaceC1Many2Manies.ShouldNotContains(c1y_1, ctx, mode1, mode2);
                            c1y_1.WorkspaceC1sWhereWorkspaceC1WorkspaceC1Many2Many.ShouldNotContains(c1x_1, ctx, mode1, mode2);
                        }
                    }
                }
            }
        }

    }
}
