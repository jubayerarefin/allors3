// <copyright file="RepeatingPurchaseInvoiceTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using Allors.Database.Derivations;
    using Resources;
    using Xunit;

    public class RepeatingPurchaseInvoiceTests : DomainTest, IClassFixture<Fixture>
    {
        public RepeatingPurchaseInvoiceTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedFrequencyThrowValidationError()
        {
            var repeatingInvoice = new RepeatingPurchaseInvoiceBuilder(this.Session)
                .WithFrequency(new TimeFrequencies(this.Session).Hour)
                .Build();

            var expectedMessage = $"{repeatingInvoice} { this.M.RepeatingPurchaseInvoice.Frequency} { ErrorMessages.FrequencyNotSupported}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void ChangedDayOfWeekThrowValidationErrorAssertExistsDayOfWeek()
        {
            var repeatingInvoice = new RepeatingPurchaseInvoiceBuilder(this.Session)
                .WithFrequency(new TimeFrequencies(this.Session).Week)
                .WithDayOfWeek(new DaysOfWeek(this.Session).Monday)
                .Build();
            this.Session.Derive(false);

            repeatingInvoice.RemoveDayOfWeek();

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals("AssertExists: RepeatingPurchaseInvoice.DayOfWeek"));
        }

        [Fact]
        public void ChangedDayOfWeekThrowValidationErrorAssertnotExistsDayOfWeek()
        {
            var repeatingInvoice = new RepeatingPurchaseInvoiceBuilder(this.Session)
                .WithFrequency(new TimeFrequencies(this.Session).Month)
                .Build();
            this.Session.Derive(false);

            repeatingInvoice.DayOfWeek = new DaysOfWeek(this.Session).Monday;

            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals("AssertNotExists: RepeatingPurchaseInvoice.DayOfWeek"));
        }

        [Fact]
        public void ChangedNextExecutionDateThrowValidationError()
        {
            var repeatingInvoice = new RepeatingPurchaseInvoiceBuilder(this.Session)
                .WithFrequency(new TimeFrequencies(this.Session).Week)
                .WithDayOfWeek(new DaysOfWeek(this.Session).Monday)
                .Build();
            this.Session.Derive(false);

            repeatingInvoice.NextExecutionDate = new DateTime(2021, 01, 06, 12, 0, 0, DateTimeKind.Utc);

            var expectedMessage = $"{repeatingInvoice} { this.M.RepeatingPurchaseInvoice.DayOfWeek} { ErrorMessages.DateDayOfWeek}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }
    }
}