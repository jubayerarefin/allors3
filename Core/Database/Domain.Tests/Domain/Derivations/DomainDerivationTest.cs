// <copyright file="DerivationNodesTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//
// </summary>

namespace Tests
{
    using System.Linq;
    using Allors;
    using Allors.Data;
    using Allors.Domain;
    using Xunit;

    public class DomainDerivationTest : DomainTest, IClassFixture<Fixture>
    {
        public DomainDerivationTest(Fixture fixture) : base(fixture) { }

        [Fact]
        public void Database()
        {
            var database = this.Session.Database;

            Assert.True(database.CreateDerivations.All(v => v.Patterns.OfType<CreatedPattern>().Any()));
            Assert.True(database.ChangeDerivations.All(v => !v.Patterns.OfType<CreatedPattern>().Any()));
        }

        [Fact]
        public void ClassCreation()
        {
            var c1 = new C1Builder(this.Session).Build();

            this.Session.Derive();

            Assert.True(c1.C1CreationDerivation);
        }

        [Fact]
        public void InterfaceCreation()
        {
            var c1 = new C1Builder(this.Session).Build();
            var c2 = new C2Builder(this.Session).Build();

            this.Session.Derive();

            Assert.True(c1.I12CreationDerivation);
            Assert.True(c2.I12CreationDerivation);
        }

        [Fact]
        public void UnitRoles()
        {
            var person = new PersonBuilder(this.Session)
                .WithFirstName("Jane")
                .WithLastName("Doe")
                .Build();

            this.Session.Derive();

            Assert.Equal("Jane Doe", person.DomainFullName);
            Assert.Equal("Hello Jane Doe!", person.DomainGreeting);
        }
    }
}
