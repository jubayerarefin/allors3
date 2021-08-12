// <copyright file="Profile.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.Local
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Allors.Database;
    using Allors.Database.Adapters.Memory;
    using Allors.Database.Configuration;
    using Allors.Database.Domain;
    using Allors.Ranges;
    using Allors.Workspace;
    using Allors.Workspace.Adapters;
    using Allors.Workspace.Adapters.Local;
    using Allors.Workspace.Domain;
    using Allors.Workspace.Meta;
    using Allors.Workspace.Meta.Lazy;
    using Configuration = Allors.Workspace.Adapters.Local.Configuration;
    using DatabaseConnection = Allors.Workspace.Adapters.Local.DatabaseConnection;
    using Person = Allors.Workspace.Domain.Person;
    using User = Allors.Database.Domain.User;

    public class Profile : IProfile
    {
        private readonly Func<IRanges> rangesFactory;
        private readonly Func<IWorkspaceServices> servicesBuilder;
        private readonly Configuration configuration;

        private User user;

        public Database Database { get; }

        public DatabaseConnection DatabaseConnection { get; private set; }

        IWorkspace IProfile.Workspace => this.Workspace;

        public IWorkspace Workspace { get; private set; }

        public M M => this.Workspace.Context().M;

        public Profile(Fixture fixture)
        {
            this.rangesFactory = () => new DefaultRanges();
            this.servicesBuilder = () => new WorkspaceContext();

            this.AsyncDatabaseClient = new AsyncDatabaseClient();

            var metaPopulation = new MetaBuilder().Build();
            var objectFactory = new ReflectionObjectFactory(metaPopulation, typeof(Person));
            this.configuration = new Configuration("Default", metaPopulation, objectFactory);

            this.Database = new Database(
                new DefaultDatabaseServices(fixture.Engine),
                new Allors.Database.Adapters.Memory.Configuration
                {
                    ObjectFactory = new ObjectFactory(fixture.M, typeof(Allors.Database.Domain.Person)),
                });

            this.Database.Init();

            using var transaction = this.Database.CreateTransaction();
            var config = new Config();
            new Setup(transaction, config).Apply();
            transaction.Derive();
            transaction.Commit();

            var administrator = new PersonBuilder(transaction).WithUserName("administrator").Build();
            new UserGroups(transaction).Administrators.AddMember(administrator);
            transaction.Services.Get<IUserService>().User = administrator;

            new TestPopulation(transaction, "full").Apply();
            transaction.Derive();
            transaction.Commit();
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public Task DisposeAsync() => Task.CompletedTask;

        public IAsyncDatabaseClient AsyncDatabaseClient { get; }

        public IWorkspace CreateExclusiveWorkspace()
        {
            var database = new DatabaseConnection(this.configuration, this.Database, this.servicesBuilder, this.rangesFactory) { UserId = this.user.Id };
            return database.CreateWorkspace();
        }
        public IWorkspace CreateWorkspace() => this.DatabaseConnection.CreateWorkspace();

        public Task Login(string userName)
        {
            using var transaction = this.Database.CreateTransaction();
            this.user = new Users(transaction).Extent().ToArray().First(v => v.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
            transaction.Services.Get<IUserService>().User = this.user;

            this.DatabaseConnection = new DatabaseConnection(this.configuration, this.Database, this.servicesBuilder, this.rangesFactory) { UserId = this.user.Id };

            this.Workspace = this.DatabaseConnection.CreateWorkspace();

            return Task.CompletedTask;
        }
    }
}
