// <copyright file="InputTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests
{
    using Components;
    using Xunit;

    [Collection("Test collection")]
    public class InputTest : Test
    {
        private readonly FormComponent page;

        public InputTest(Fixture fixture)
            : base(fixture)
        {
            this.Login();
            this.page = this.Sidenav.NavigateToForm();
        }

        [Fact]
        public void String()
        {
            var before = new Datas(this.Transaction).Extent().ToArray();

            this.page.String.Value = "Hello";

            this.page.SAVE.Click();

            this.Driver.WaitForAngular();
            this.Transaction.Rollback();

            var after = new Datas(this.Transaction).Extent().ToArray();

            Assert.Equal(after.Length, before.Length + 1);

            var data = after.Except(before).First();

            Assert.Equal("Hello", data.String);
        }

        [Fact]
        public void Decimal()
        {
            var before = new Datas(this.Transaction).Extent().ToArray();

            this.page.Decimal.Value = 100.50m;

            this.page.SAVE.Click();

            this.Driver.WaitForAngular();
            this.Transaction.Rollback();

            var after = new Datas(this.Transaction).Extent().ToArray();

            Assert.Equal(after.Length, before.Length + 1);

            var data = after.Except(before).First();

            Assert.Equal(100.50m, data.Decimal);
        }
    }
}
