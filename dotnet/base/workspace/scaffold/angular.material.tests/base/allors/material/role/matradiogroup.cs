// <copyright file="MatRadioGroup.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Components
{
    using System.Diagnostics.CodeAnalysis;
    using Allors.Database.Meta;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class MatRadioGroup : SelectorComponent
    {
        public MatRadioGroup(IWebDriver driver, MetaPopulation m, RoleType roleType, params string[] scopes)
            : base(driver, m) =>
            this.Selector = By.XPath($".//a-mat-radio-group{this.ByScopesPredicate(scopes)}//*[@data-allors-roletype='{roleType.RelationType.Tag}']");

        public override By Selector { get; }

        public void Select(string value)
        {
            this.Driver.WaitForAngular();
            var radioSelector = new ByChained(this.Selector, By.CssSelector($"mat-radio-button[data-allors-radio-value='{value}']"));
            var radio = this.Driver.FindElement(radioSelector);
            this.ScrollToElement(radio);
            radio.Click();
            this.Driver.WaitForAngular();
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class MatRadioGroup<T> : MatRadioGroup where T : Component
    {
        public MatRadioGroup(T page, MetaPopulation m, RoleType roleType, params string[] scopes)
            : base(page.Driver, m, roleType, scopes) =>
            this.Page = page;

        public T Page { get; }

        public new T Select(string value)
        {
            base.Select(value);
            return this.Page;
        }
    }
}
