// <copyright file="ObjectTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.Remote
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Allors.Workspace;
    using Allors.Workspace.Adapters.Remote;
    using Allors.Workspace.Domain;
    using Allors.Workspace.Meta;
    using Xunit;

    public class Profile : IProfile
    {
        public const string Url = "http://localhost:5000";

        public const string SetupUrl = "/Test/Setup?population=full";
        public const string LoginUrl = "/TestAuthentication/Token";

        IWorkspace IProfile.Workspace => this.Workspace;

        public Workspace Workspace { get; }

        public Database Database => this.Workspace.Database;

        public M M => this.Workspace.State().M;

        public Profile() =>
            this.Workspace = new Workspace(
                new MetaBuilder().Build(),
                typeof(User),
                new WorkspaceState(),
                new HttpClient()
                {
                    BaseAddress = new Uri(Url),
                });
        
        public async Task InitializeAsync()
        {
            var response = await this.Database.HttpClient.GetAsync(SetupUrl);
            Assert.True(response.IsSuccessStatusCode);
            await this.Login("administrator");
        }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task Login(string user)
        {
            var uri = new Uri(LoginUrl, UriKind.Relative);
            var response = await this.Database.Login(uri, user, null);
            Assert.True(response);
        }
    }
}