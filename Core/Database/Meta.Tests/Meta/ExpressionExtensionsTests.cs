// <copyright file="FilterTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//   Defines the ApplicationTests type.
// </summary>

namespace Allors.Database.Domain.Tests
{
    using System;
    using System.Collections;
    using System.Linq.Expressions;
    using Derivations;
    using Meta;
    using Xunit;

    public class ExpressionExtensionsTests
    {
        public ExpressionExtensionsTests()
        {
            var metaBuilder = new MetaBuilder();
            this.M = metaBuilder.Build();
        }

        private MetaPopulation M { get; }

        [Fact]
        public void InterfaceAssociation()
        {
            Expression<Func<User, IPropertyType>> expression = v => v.Logins;

            var path = expression.ToPath(this.M);

            Assert.Equal(this.M.User.Logins, path.PropertyType);
            Assert.Null(path.Next);
        }

        [Fact]
        public void ClassAssociation()
        {
            Expression<Func<Person, IPropertyType>> expression = v => v.OrganisationWhereEmployee;

            var path = expression.ToPath(this.M);

            Assert.Equal(this.M.Person.OrganisationWhereEmployee, path.PropertyType);
            Assert.Null(path.Next);
        }

        [Fact]
        public void ClassAssociationClassRole()
        {
            Expression<Func<Person, IPropertyType>> expression = v => v.OrganisationWhereEmployee.Organisation.Information;

            var path = expression.ToPath(this.M);

            Assert.Equal(this.M.Person.OrganisationWhereEmployee, path.PropertyType);

            var next = path.Next;

            Assert.Equal(this.M.Organisation.Information, next.PropertyType);
            Assert.Null(next.Next);
        }

        [Fact]
        public void ClassRole()
        {
            Expression<Func<Organisation, IPropertyType>> expression = v => v.Name;

            var path = expression.ToPath(this.M);

            Assert.Equal(this.M.Organisation.Name, path.PropertyType);
            Assert.Null(path.Next);
        }

        [Fact]
        public void ClassRoleOfType()
        {
            Expression<Func<UserGroup, IComposite>> expression = v => v.Members.User.AsPerson;

            var path = expression.ToPath(this.M);

            Assert.Equal(this.M.UserGroup.Members, path.PropertyType);
            Assert.Equal(this.M.Person, path.OfType);
            Assert.Null(path.Next);
        }

        [Fact]
        public void ClassRoleClassRole()
        {
            Expression<Func<Organisation, IPropertyType>> expression = v => v.Employees.Person.FirstName;

            var path = expression.ToPath(this.M);

            Assert.Equal(this.M.Organisation.Employees, path.PropertyType);

            var next = path.Next;

            Assert.Equal(this.M.Person.FirstName, next.PropertyType);
            Assert.Null(next.Next);
        }


        [Fact]
        public void ClassRoleInterfaceAsClassRole()
        {
            Expression<Func<UserGroup, IPropertyType>> expression = v => v.Members.User.AsPerson.FirstName;

            var path = expression.ToPath(this.M);

            Assert.Equal(this.M.UserGroup.Members, path.PropertyType);

            var next = path.Next;

            Assert.Equal(this.M.Person.FirstName, next.PropertyType);
            Assert.Null(next.Next);
        }
    }
}
