// <copyright file="LocalTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Mock
{
    using System;

    using Allors.Workspace;
    using Allors.Workspace.Domain;
    using Allors.Workspace.Meta;

    public class MockTest : IDisposable
    {
        public Workspace Workspace { get; set; }

        public M M { get; }

        public MockTest()
        {
            var objectFactory = new ObjectFactory(new MetaBuilder().Build(), typeof(User));
            this.Workspace = new Workspace(objectFactory, new WorkspaceState());

            this.M = this.Workspace.Scope().M;
        }

        public void Dispose()
        {
        }
    }
}
