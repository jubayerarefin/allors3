// <copyright file="PostalAddressTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Database.Derivations;
    using Derivations.Errors;
    using Meta;
    using Xunit;

    public class PostalAddressGeographicBoundaryTests : DomainTest, IClassFixture<Fixture>
    {
        public PostalAddressGeographicBoundaryTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void GivenGeographicBoundary_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var country = new Countries(this.Transaction).CountryByIsoCode["BE"];

            new PostalAddressBuilder(this.Transaction).Build();

            Assert.True(this.Transaction.Derive(false).HasErrors);

            this.Transaction.Rollback();

            new PostalAddressBuilder(this.Transaction).WithAddress1("address1").Build();

            Assert.True(this.Transaction.Derive(false).HasErrors);

            this.Transaction.Rollback();

            new PostalAddressBuilder(this.Transaction).WithPostalAddressBoundary(country).Build();

            Assert.True(this.Transaction.Derive(false).HasErrors);

            this.Transaction.Rollback();

            Assert.False(this.Transaction.Derive(false).HasErrors);

            this.Transaction.Rollback();

            new PostalAddressBuilder(this.Transaction).WithAddress1("address1").WithPostalAddressBoundary(country).Build();

            Assert.False(this.Transaction.Derive(false).HasErrors);
        }
    }

    public class PostalAddressRuleTests : DomainTest, IClassFixture<Fixture>
    {
        public PostalAddressRuleTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedLocalityThrowValidationError()
        {
            var postalAddress = new PostalAddressBuilder(this.Transaction)
                .WithPostalAddressBoundary(new CityBuilder(this.Transaction).Build())
                .Build();
            this.Transaction.Derive(false);

            postalAddress.Locality = "locality";

            var errors = this.Transaction.Derive(false).Errors.Cast<DerivationErrorAtMostOne>();
            Assert.Equal(new IRoleType[]
            {
                this.M.PostalAddress.PostalAddressBoundaries,
                this.M.PostalAddress.Locality,
            }, errors.SelectMany(v => v.RoleTypes));
        }

        [Fact]
        public void ChangedRegionThrowValidationError()
        {
            var postalAddress = new PostalAddressBuilder(this.Transaction)
                .WithPostalAddressBoundary(new CityBuilder(this.Transaction).Build())
                .Build();
            this.Transaction.Derive(false);

            postalAddress.Region = "Region";

            var errors = this.Transaction.Derive(false).Errors.Cast<DerivationErrorAtMostOne>();
            Assert.Equal(new IRoleType[]
            {
                this.M.PostalAddress.PostalAddressBoundaries,
                this.M.PostalAddress.Region,
            }, errors.SelectMany(v => v.RoleTypes));
        }

        [Fact]
        public void ChangedPostalCodeThrowValidationError()
        {
            var postalAddress = new PostalAddressBuilder(this.Transaction)
                .WithPostalAddressBoundary(new CityBuilder(this.Transaction).Build())
                .Build();
            this.Transaction.Derive(false);

            postalAddress.PostalCode = "PostalCode";

            var errors = this.Transaction.Derive(false).Errors.Cast<DerivationErrorAtMostOne>();
            Assert.Equal(new IRoleType[]
            {
                this.M.PostalAddress.PostalAddressBoundaries,
                this.M.PostalAddress.PostalCode,
            }, errors.SelectMany(v => v.RoleTypes));
        }

        [Fact]
        public void ChangedCountryThrowValidationError()
        {
            var postalAddress = new PostalAddressBuilder(this.Transaction)
                .WithPostalAddressBoundary(new CityBuilder(this.Transaction).Build())
                .Build();
            this.Transaction.Derive(false);

            postalAddress.Country = new CountryBuilder(this.Transaction).Build();

            var errors = this.Transaction.Derive(false).Errors.Cast<DerivationErrorAtMostOne>();
            Assert.Equal(new IRoleType[]
            {
                this.M.PostalAddress.PostalAddressBoundaries,
                this.M.PostalAddress.Country,
            }, errors.SelectMany(v => v.RoleTypes));
        }

        [Fact]
        public void ChangedPostalAddressBoundariesThrowValidationError()
        {
            var postalAddress = new PostalAddressBuilder(this.Transaction)
                .WithLocality("Locality")
                .Build();
            this.Transaction.Derive(false);

            postalAddress.AddPostalAddressBoundary(new CityBuilder(this.Transaction).Build());

            var errors = this.Transaction.Derive(false).Errors.Cast<DerivationErrorAtMostOne>();
            Assert.Equal(new IRoleType[]
            {
                this.M.PostalAddress.PostalAddressBoundaries,
                this.M.PostalAddress.Locality,
            }, errors.SelectMany(v => v.RoleTypes));
        }

        [Fact]
        public void ChangedCountryThrowValidationErrorAssertExistsCountry()
        {
            var postalAddress = new PostalAddressBuilder(this.Transaction)
                .WithCountry(new CountryBuilder(this.Transaction).Build())
                .Build();
            this.Transaction.Derive(false);

            postalAddress.RemoveCountry();

            var errors = this.Transaction.Derive(false).Errors.Cast<DerivationErrorRequired>();
            Assert.Equal(new IRoleType[]
            {
                this.M.PostalAddress.Country,
            }, errors.SelectMany(v => v.RoleTypes));
        }

        [Fact]
        public void ChangedLocalityThrowValidationErrorAssertExistsLocality()
        {
            var postalAddress = new PostalAddressBuilder(this.Transaction)
                .WithLocality("Locality")
                .Build();
            this.Transaction.Derive(false);

            postalAddress.RemoveLocality();

            var errors = this.Transaction.Derive(false).Errors.Cast<DerivationErrorRequired>();
            Assert.Equal(new IRoleType[]
            {
                this.M.PostalAddress.Locality,
            }, errors.SelectMany(v => v.RoleTypes));
        }
    }
}
