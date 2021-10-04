// <copyright file="AutoCompleteOptionsTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests
{
    using Components;
    using Xunit;

    [Collection("Test collection")]
    public class AutoCompleteOptionsTest : Test
    {
        private readonly FormComponent page;

        public AutoCompleteOptionsTest(Fixture fixture)
            : base(fixture)
        {
            this.Login();
            this.page = this.Sidenav.NavigateToForm();
        }

        [Fact]
        public void Initial()
        {
            var jane = new Users(this.Transaction).GetUser("jane@example.com");
            var before = new Datas(this.Transaction).Extent().ToArray();

            this.page.AutocompleteOptions.Select("jane", "jane@example.com");

            this.page.SAVE.Click();

            this.Driver.WaitForAngular();
            this.Transaction.Rollback();

            var after = new Datas(this.Transaction).Extent().ToArray();

            Assert.Equal(after.Length, before.Length + 1);

            var data = after.Except(before).First();

            Assert.Equal(jane, data.AutocompleteOptions);
        }
    }
}
