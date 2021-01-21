// <copyright file="GeneralLedgerAccountTests.cs" company="Allors bvba">
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

    public class GeneralLedgerAccountTests : DomainTest, IClassFixture<Fixture>
    {
        public GeneralLedgerAccountTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void GivenGeneralLedgerAccount_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var accountGroup = new GeneralLedgerAccountGroupBuilder(this.Session).WithDescription("accountGroup").Build();
            var accountType = new GeneralLedgerAccountTypeBuilder(this.Session).WithDescription("accountType").Build();

            this.Session.Commit();

            var builder = new GeneralLedgerAccountBuilder(this.Session);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithAccountNumber("0001");
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithName("GeneralLedgerAccount");
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithBalanceSheetAccount(true);
            builder.Build();

            this.Session.Rollback();

            builder.WithSide(new DebitCreditConstants(this.Session).Debit);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithGeneralLedgerAccountGroup(accountGroup);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithGeneralLedgerAccountType(accountType);
            builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenGeneralLedgerAccount_WhenBuild_ThenPostBuildRelationsMustExist()
        {
            var generalLedgerAccount = new GeneralLedgerAccountBuilder(this.Session)
                .WithAccountNumber("0001")
                .WithName("GeneralLedgerAccount")
                .WithBalanceSheetAccount(true)
                .Build();

            Assert.True(generalLedgerAccount.ExistUniqueId);
            Assert.False(generalLedgerAccount.CashAccount);
            Assert.False(generalLedgerAccount.CostCenterAccount);
            Assert.False(generalLedgerAccount.CostCenterRequired);
            Assert.False(generalLedgerAccount.CostUnitAccount);
            Assert.False(generalLedgerAccount.CostUnitRequired);
            Assert.False(generalLedgerAccount.Protected);
            Assert.False(generalLedgerAccount.ReconciliationAccount);
        }

        [Fact]
        public void GivenGeneralLedgerAccount_WhenAddedToChartOfAccounts_ThenAccountNumberMustBeUnique()
        {
            var glAccount0001 = new GeneralLedgerAccountBuilder(this.Session)
                .WithAccountNumber("0001")
                .WithName("GeneralLedgerAccount")
                .WithBalanceSheetAccount(true)
                .WithSide(new DebitCreditConstants(this.Session).Debit)
                .WithGeneralLedgerAccountType(new GeneralLedgerAccountTypeBuilder(this.Session).WithDescription("accountType").Build())
                .WithGeneralLedgerAccountGroup(new GeneralLedgerAccountGroupBuilder(this.Session).WithDescription("accountGroup").Build())
                .Build();

            var glAccount0001Dup = new GeneralLedgerAccountBuilder(this.Session)
                .WithAccountNumber("0001")
                .WithName("GeneralLedgerAccount duplicate number")
                .WithBalanceSheetAccount(true)
                .WithSide(new DebitCreditConstants(this.Session).Debit)
                .WithGeneralLedgerAccountType(new GeneralLedgerAccountTypeBuilder(this.Session).WithDescription("accountType").Build())
                .WithGeneralLedgerAccountGroup(new GeneralLedgerAccountGroupBuilder(this.Session).WithDescription("accountGroup").Build())
                .Build();

            var chart = new ChartOfAccountsBuilder(this.Session).WithName("name").WithGeneralLedgerAccount(glAccount0001).Build();

            Assert.False(this.Session.Derive(false).HasErrors);

            chart.AddGeneralLedgerAccount(glAccount0001Dup);

            var expectedMessage = $"{glAccount0001Dup}, { this.M.GeneralLedgerAccount.AccountNumber}, { ErrorMessages.AccountNumberUniqueWithinChartOfAccounts}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));

            new ChartOfAccountsBuilder(this.Session).WithName("another Chart").WithGeneralLedgerAccount(glAccount0001Dup).Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenGeneralLedgerAccount_WhenSettingCostCenterRequired_ThenAccountMustBeMarkedAsCostCenterAccount()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session)
                .WithAccountNumber("0001")
                .WithName("GeneralLedgerAccount")
                .WithCostCenterRequired(true)
                .WithBalanceSheetAccount(true)
                .WithSide(new DebitCreditConstants(this.Session).Debit)
                .WithGeneralLedgerAccountType(new GeneralLedgerAccountTypeBuilder(this.Session).WithDescription("accountType").Build())
                .WithGeneralLedgerAccountGroup(new GeneralLedgerAccountGroupBuilder(this.Session).WithDescription("accountGroup").Build())
                .Build();

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.CostCenterRequired}, { ErrorMessages.NotACostCenterAccount}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void GivenGeneralLedgerAccount_WhenSettingCostUnitRequired_ThenAccountMustBeMarkedAsCostUnitAccount()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session)
                .WithAccountNumber("0001")
                .WithName("GeneralLedgerAccount")
                .WithCostUnitRequired(true)
                .WithBalanceSheetAccount(true)
                .WithSide(new DebitCreditConstants(this.Session).Debit)
                .WithGeneralLedgerAccountType(new GeneralLedgerAccountTypeBuilder(this.Session).WithDescription("accountType").Build())
                .WithGeneralLedgerAccountGroup(new GeneralLedgerAccountGroupBuilder(this.Session).WithDescription("accountGroup").Build())
                .Build();

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.CostUnitRequired}, { ErrorMessages.NotACostUnitAccount}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }
    }

    public class GeneralLedgerAccountDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public GeneralLedgerAccountDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedDefaultCostCenterDeriveDerivedCostCentersAllowed()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session).Build();
            this.Session.Derive(false);

            glAccount.DefaultCostCenter = new CostCenterBuilder(this.Session).Build();
            this.Session.Derive(false);

            Assert.Contains(glAccount.DefaultCostCenter, glAccount.DerivedCostCentersAllowed);
        }

        [Fact]
        public void ChangedAssignedCostCentersAllowedDeriveDerivedCostCentersAllowed()
        {
            var defaultCostCenter = new CostCenterBuilder(this.Session).Build();
            var allowedCostCenter = new CostCenterBuilder(this.Session).Build();

            var glAccount = new GeneralLedgerAccountBuilder(this.Session).WithDefaultCostCenter(defaultCostCenter).Build();
            this.Session.Derive(false);

            glAccount.AddAssignedCostCentersAllowed(allowedCostCenter);
            this.Session.Derive(false);

            Assert.Contains(defaultCostCenter, glAccount.DerivedCostCentersAllowed);
            Assert.Contains(allowedCostCenter, glAccount.DerivedCostCentersAllowed);
        }

        [Fact]
        public void ChangedDefaultCostUnitDeriveDerivedCostUnitsAllowed()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session).Build();
            this.Session.Derive(false);

            glAccount.DefaultCostUnit = new UnifiedGoodBuilder(this.Session).Build();
            this.Session.Derive(false);

            Assert.Contains(glAccount.DefaultCostUnit, glAccount.DerivedCostUnitsAllowed);
        }

        [Fact]
        public void ChangedAssignedCostUnitsAllowedDeriveDerivedCostUnitsAllowed()
        {
            var defaultCostUnit = new UnifiedGoodBuilder(this.Session).Build();
            var allowedCostUnit = new UnifiedGoodBuilder(this.Session).Build();

            var glAccount = new GeneralLedgerAccountBuilder(this.Session).WithDefaultCostUnit(defaultCostUnit).Build();
            this.Session.Derive(false);

            glAccount.AddAssignedCostUnitsAllowed(allowedCostUnit);
            this.Session.Derive(false);

            Assert.Contains(defaultCostUnit, glAccount.DerivedCostUnitsAllowed);
            Assert.Contains(allowedCostUnit, glAccount.DerivedCostUnitsAllowed);
        }

        [Fact]
        public void ChangedChartOfAccountsGeneralLedgerAccountsThrowValidationError()
        {
            var chartOfAccounts = new ChartOfAccountsBuilder(this.Session)
                .WithGeneralLedgerAccount(new GeneralLedgerAccountBuilder(this.Session).WithAccountNumber("1").Build())
                .Build();
            this.Session.Derive(false);

            var glAccount = new GeneralLedgerAccountBuilder(this.Session).WithAccountNumber("1").Build();
            chartOfAccounts.AddGeneralLedgerAccount(glAccount);

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.AccountNumber}, { ErrorMessages.AccountNumberUniqueWithinChartOfAccounts}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void ChangedAccountNumberThrowValidationError()
        {
            var chartOfAccounts = new ChartOfAccountsBuilder(this.Session)
                .WithGeneralLedgerAccount(new GeneralLedgerAccountBuilder(this.Session).WithAccountNumber("1").Build())
                .Build();
            this.Session.Derive(false);

            var glAccount = new GeneralLedgerAccountBuilder(this.Session).WithAccountNumber("2").Build();
            chartOfAccounts.AddGeneralLedgerAccount(glAccount);

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.AccountNumber}, { ErrorMessages.AccountNumberUniqueWithinChartOfAccounts}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.DoesNotContain(errors, e => e.Message.Equals(expectedMessage));

            glAccount.AccountNumber = "1";

            errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void ChangedCostCenterRequiredThrowValidationError()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session).Build();
            this.Session.Derive(false);

            glAccount.CostCenterRequired = true;

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.CostCenterRequired}, { ErrorMessages.NotACostCenterAccount}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void ChangedCostCenterAccountThrowValidationError()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session).WithCostCenterAccount(true).WithCostCenterRequired(true).Build();
            this.Session.Derive(false);

            glAccount.CostCenterAccount = false;

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.CostCenterRequired}, { ErrorMessages.NotACostCenterAccount}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void ChangedCostUnitRequiredThrowValidationError()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session).Build();
            this.Session.Derive(false);

            glAccount.CostUnitRequired = true;

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.CostUnitRequired}, { ErrorMessages.NotACostUnitAccount}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void ChangedCostUnitAccountThrowValidationError()
        {
            var glAccount = new GeneralLedgerAccountBuilder(this.Session).WithCostUnitAccount(true).WithCostUnitRequired(true).Build();
            this.Session.Derive(false);

            glAccount.CostUnitAccount = false;

            var expectedMessage = $"{glAccount}, { this.M.GeneralLedgerAccount.CostUnitRequired}, { ErrorMessages.NotACostUnitAccount}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }
    }
}
