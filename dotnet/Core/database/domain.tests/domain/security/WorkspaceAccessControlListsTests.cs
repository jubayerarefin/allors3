// <copyright file="DatabaseAccessControlListTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain.Tests
{
    using System.Linq;
    using Meta;
    using Xunit;
    using Permission = Domain.Permission;

    public class WorkspaceAccessControlListsTests : DomainTest, IClassFixture<Fixture>
    {
        private string workspaceName = "Default";

        public WorkspaceAccessControlListsTests(Fixture fixture) : base(fixture) { }

        public override Config Config => new Config { SetupSecurity = true };

        [Fact]
        public void InitialWithoutAccessControl()
        {
            var person = new PersonBuilder(this.Transaction).WithFirstName("John").WithLastName("Doe").Build();

            this.Transaction.Derive();
            this.Transaction.Commit();

            var organisation = new OrganisationBuilder(this.Transaction).WithName("Organisation").Build();

            var acl = new WorkspaceAccessControlLists(this.workspaceName, person)[organisation];

            Assert.False(acl.CanRead(this.M.Organisation.Name));
        }

        [Fact]
        public void Initial()
        {
            var permission = this.FindPermission(this.M.Organisation.Name, Operations.Read);
            var role = new RoleBuilder(this.Transaction).WithName("Role").WithPermission(permission).Build();
            var person = new PersonBuilder(this.Transaction).WithFirstName("John").WithLastName("Doe").Build();
            var accessControl = new AccessControlBuilder(this.Transaction).WithSubject(person).WithRole(role).Build();

            var intialSecurityToken = new SecurityTokens(this.Transaction).InitialSecurityToken;
            intialSecurityToken.AddAccessControl(accessControl);

            this.Transaction.Derive();
            this.Transaction.Commit();

            var organisation = new OrganisationBuilder(this.Transaction).WithName("Organisation").Build();

            var acl = new WorkspaceAccessControlLists(this.workspaceName, person)[organisation];

            Assert.True(acl.CanRead(this.M.Organisation.Name));
        }

        [Fact]
        public void GivenAWorkspaceAccessControlListsThenADatabaseDeniedPermissionsIsNotPresent()
        {
            var administrator = new PersonBuilder(this.Transaction).WithUserName("administrator").Build();
            var administrators = new UserGroups(this.Transaction).Administrators;
            administrators.AddMember(administrator);

            var databaseOnlyPermissions = new Permissions(this.Transaction).Extent().Where(v => v.OperandType.Equals(M.Person.DatabaseOnlyField));
            var databaseOnlyReadPermission = databaseOnlyPermissions.First(v => v.Operation == Operations.Read);

            var restriction = new RestrictionBuilder(this.Transaction).WithDeniedPermission(databaseOnlyReadPermission).Build();

            administrator.AddRestriction(restriction);

            this.Transaction.Derive();
            this.Transaction.Commit();

            var workspaceAccessControlLists = new WorkspaceAccessControlLists(this.workspaceName, administrator);
            var acl = workspaceAccessControlLists[administrator];

            Assert.DoesNotContain(restriction, acl.Restrictions);
        }

        [Fact]
        public void GivenAWorkspaceAccessControlListsThenAWorkspaceDeniedPermissionsIsNotPresent()
        {
            var administrator = new PersonBuilder(this.Transaction).WithUserName("administrator").Build();
            var administrators = new UserGroups(this.Transaction).Administrators;
            administrators.AddMember(administrator);

            var workspacePermissions = new Permissions(this.Transaction).Extent().Where(v => v.OperandType.Equals(M.Person.DefaultWorkspaceField));
            var workspaceReadPermission = workspacePermissions.First(v => v.Operation == Operations.Read);
            var restriction = new RestrictionBuilder(this.Transaction).WithDeniedPermission(workspaceReadPermission).Build();

            administrator.AddRestriction(restriction);

            this.Transaction.Derive();
            this.Transaction.Commit();

            var workspaceAccessControlLists = new WorkspaceAccessControlLists(this.workspaceName, administrator);
            var acl = workspaceAccessControlLists[administrator];

            Assert.Contains(restriction, acl.Restrictions);
        }

        [Fact]
        public void GivenAWorkspaceAccessControlListsThenAnotherWorkspaceDeniedPermissionsIsNotPresent()
        {
            var administrator = new PersonBuilder(this.Transaction).WithUserName("administrator").Build();
            var administrators = new UserGroups(this.Transaction).Administrators;
            administrators.AddMember(administrator);

            var workspacePermissions = new Permissions(this.Transaction).Extent().Where(v => v.OperandType.Equals(M.Person.DefaultWorkspaceField));
            var workspaceReadPermission = workspacePermissions.First(v => v.Operation == Operations.Read);
            var restriction = new RestrictionBuilder(this.Transaction).WithDeniedPermission(workspaceReadPermission).Build();

            administrator.AddRestriction(restriction);

            this.Transaction.Derive();
            this.Transaction.Commit();

            var workspaceAccessControlLists = new WorkspaceAccessControlLists("Another", administrator);
            var acl = workspaceAccessControlLists[administrator];

            Assert.DoesNotContain(restriction, acl.Restrictions);
        }


        private Permission FindPermission(IRoleType roleType, Operations operation)
        {
            var objectType = (Class)roleType.AssociationType.ObjectType;
            return new Permissions(this.Transaction).Get(objectType, roleType, operation);
        }
    }
}
