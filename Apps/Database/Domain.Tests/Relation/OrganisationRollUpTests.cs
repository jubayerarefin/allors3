// <copyright file="OrganisationRollUpTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//   Defines the PersonTests type.
// </summary>

namespace Allors.Database.Domain.Tests
{
    using Xunit;

    public class OrganisationRollUpTests : DomainTest, IClassFixture<Fixture>
    {
        public OrganisationRollUpTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedParentDeriveParties()
        {
            var parent = new OrganisationBuilder(this.Transaction).Build();
            var child = new OrganisationBuilder(this.Transaction).Build();
            var rollup = new OrganisationRollUpBuilder(this.Transaction).WithChild(child).Build();
            this.Transaction.Derive(false);

            rollup.Parent = parent;
            this.Transaction.Derive(false);

            Assert.Contains(parent, rollup.Parties);
        }

        [Fact]
        public void ChangedChildDeriveParties()
        {
            var parent = new OrganisationBuilder(this.Transaction).Build();
            var child = new OrganisationBuilder(this.Transaction).Build();
            var rollup = new OrganisationRollUpBuilder(this.Transaction).WithParent(parent).Build();
            this.Transaction.Derive(false);

            rollup.Child = child;
            this.Transaction.Derive(false);

            Assert.Contains(child, rollup.Parties);
        }
    }
}
