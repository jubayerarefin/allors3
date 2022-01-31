// <copyright file="SelectTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests
{
    using System.Linq;
    using Allors.Database.Domain;
    using Components;
    using src.app.tests.form;
    using Xunit;

    [Collection("Test collection")]
    public class SelectTest : Test
    {
        private readonly FormComponent page;

        public SelectTest(Fixture fixture)
            : base(fixture)
        {
            this.Login();
            this.page = this.Sidenav.NavigateToForm();
        }

        [Fact]
        public void Initial()
        {
            var administrator = new People(this.Transaction).FindBy(this.M.Person.UserName, "administrator");
            var before = new Datas(this.Transaction).Extent().ToArray();

            this.page.Select.Select(administrator);

            this.page.SAVE.Click();

            this.Driver.WaitForAngular();
            this.Transaction.Rollback();

            var after = new Datas(this.Transaction).Extent().ToArray();

            Assert.Equal(after.Length, before.Length + 1);

            var data = after.Except(before).First();

            Assert.Equal(administrator, data.Select);
        }


        [Fact]
        public void EmptyOptions()
        {
            var administrator = new People(this.Transaction).FindBy(this.M.Person.UserName, "administrator");
            var before = new Datas(this.Transaction).Extent().ToArray();

            this.page.Select.Select(administrator);

            this.page.SAVE.Click();

            this.Driver.WaitForAngular();
            this.Transaction.Rollback();

            var after = new Datas(this.Transaction).Extent().ToArray();

            Assert.Equal(after.Length, before.Length + 1);

            var data = after.Except(before).First();

            Assert.Equal(administrator, data.Select);
        }
    }
}