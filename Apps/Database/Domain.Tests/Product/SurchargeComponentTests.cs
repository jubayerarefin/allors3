// <copyright file="SurchargeComponentTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using System.Collections.Generic;
    using Allors.Database.Derivations;
    using Resources;
    using Xunit;

    public class SurchargeComponentTests : DomainTest, IClassFixture<Fixture>
    {
        public SurchargeComponentTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void OnCreatedThrowValidationError()
        {
            var surchargeComponent = new SurchargeComponentBuilder(this.Session).Build();

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("SurchargeComponent.Price, SurchargeComponent.Percentage at least one"));
        }

        [Fact]
        public void ChangedPriceThrowValidationError()
        {
            var surchargeComponent = new SurchargeComponentBuilder(this.Session).WithPrice(1).Build();
            this.Session.Derive(false);

            surchargeComponent.RemovePrice();

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("SurchargeComponent.Price, SurchargeComponent.Percentage at least one"));
        }

        [Fact]
        public void ChangedPercentageThrowValidationError()
        {
            var surchargeComponent = new SurchargeComponentBuilder(this.Session).WithPercentage(1).Build();
            this.Session.Derive(false);

            surchargeComponent.RemovePercentage();

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.StartsWith("SurchargeComponent.Price, SurchargeComponent.Percentage at least one"));
        }

        [Fact]
        public void ChangedPriceThrowValidationErrorAtmostOne()
        {
            var surchargeComponent = new SurchargeComponentBuilder(this.Session).WithPercentage(1).Build();
            this.Session.Derive(false);

            surchargeComponent.Price = 1;

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals("AssertExistsAtMostOne: SurchargeComponent.Price\nSurchargeComponent.Percentage"));
        }

        [Fact]
        public void ChangedPercentageThrowValidationErrorAtmostOne()
        {
            var surchargeComponent = new SurchargeComponentBuilder(this.Session).WithPrice(1).Build();
            this.Session.Derive(false);

            surchargeComponent.Percentage = 1;

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals("AssertExistsAtMostOne: SurchargeComponent.Price\nSurchargeComponent.Percentage"));
        }
    }
}