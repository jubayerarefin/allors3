// <copyright file="PersonEditTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Objects
{
    using Allors.E2E.Angular.Material.Person;

    public class PersonEditTest : Test
    {
        private readonly PersonListComponent people;

        //[Test]
        //public void Title()
        //{
        //    this.people.AddNew.Click();
        //    Assert.Equal("Person", this.Driver.Title);
        //}

        //[Test]
        //public void Add()
        //{
        //    this.people.AddNew.Click();
        //    var before = new People(this.Transaction).Extent().ToArray();

        //    var personEditPage = new PersonComponent(this.Driver, this.M);

        //    personEditPage.FirstName.Set("Jos")
        //                  .LastName.Set("Smos")
        //                  .SAVE.Click();

        //    this.Driver.WaitForAngular();
        //    this.Transaction.Rollback();

        //    var after = new People(this.Transaction).Extent().ToArray();

        //    Assert.Equal(after.Length, before.Length + 1);

        //    var person = after.Except(before).First();

        //    Assert.Equal("Jos", person.FirstName);
        //    Assert.Equal("Smos", person.LastName);
        //}

        //[Test]
        //public void Edit()
        //{
        //    var before = new People(this.Transaction).Extent().ToArray();

        //    var person = new People(this.Transaction).FindBy(this.M.Person.UserName, "john@example.com");

        //    var page = this.people.Select(person).EditAndNavigate();

        //    page.FirstName.Set("Jos")
        //        .LastName.Set("Smos")
        //        .SAVE.Click();

        //    this.Driver.WaitForAngular();
        //    this.Transaction.Rollback();

        //    var after = new People(this.Transaction).Extent().ToArray();

        //    Assert.Equal(after.Length, before.Length);

        //    Assert.Equal("Jos", person.FirstName);
        //    Assert.Equal("Smos", person.LastName);
        //}
    }
}