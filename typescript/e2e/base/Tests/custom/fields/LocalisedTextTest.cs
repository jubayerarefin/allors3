// <copyright file="InputTest.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Form
{
    using System.Linq;
    using Allors.Database.Domain;
    using Allors.E2E.Test;
    using NUnit.Framework;
    using Task = System.Threading.Tasks.Task;

    public class LocalisedTextTest : Test
    {
        public FieldsFormComponent FormComponent => new FieldsFormComponent(this.AppRoot);

        [SetUp]
        public async Task Setup()
        {
            await this.LoginAsync("jane@example.com");
            await this.GotoAsync("/fields");
        }

        [Test]
        public async Task Populated()
        {
            var locale = new Locales(this.Transaction).DutchBelgium;
            var localisedMarkdown = new LocalisedTextBuilder(this.Transaction).WithLocale(locale).WithText("*** Hello ***").Build();
            var data = new DataBuilder(this.Transaction).Build();
            data.AddLocalisedText(localisedMarkdown);
            this.Transaction.Commit();

            await this.GotoAsync("/fields");

            var actual = await this.FormComponent.LocalisedTexts.GetAsync();

            Assert.That(actual, Is.EqualTo("*** Hello ***"));
        }

        [Test]
        public async Task Set()
        {
            var locale = new Locales(this.Transaction).DutchBelgium;
            var before = new Datas(this.Transaction).Extent().ToArray();

            await this.FormComponent.LocalisedTexts.SetAsync("*** Hello ***");

            await this.FormComponent.SaveAsync();
            this.Transaction.Rollback();

            var after = new Datas(this.Transaction).Extent().ToArray();
            Assert.AreEqual(after.Length, before.Length + 1);
            var data = after.Except(before).First();
            Assert.AreEqual("*** Hello ***", data.LocalisedTexts.First(v => v.Locale.Equals(locale)).Text);
        }
    }
}
