// <copyright file="MatDatePicker.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Components
{
    using System.Diagnostics.CodeAnalysis;
    using Allors.Database.Meta;
    using OpenQA.Selenium;
    using DateTime = System.DateTime;

    public class MatMonthpicker
    : SelectorComponent
    {
        public MatMonthpicker(IWebDriver driver, MetaPopulation m, RoleType roleType, params string[] scopes)
        : base(driver, m) =>
            this.Selector = By.XPath($".//a-mat-monthpicker{this.ByScopesPredicate(scopes)}//*[@data-allors-roletype='{roleType.RelationType.Tag}']//input");

        public override By Selector { get; }

        public DateTime? Value
        {
            get
            {
                this.Driver.WaitForAngular();
                var element = this.Driver.FindElement(this.Selector);
                var value = element.GetAttribute("value");
                if (!string.IsNullOrEmpty(value))
                {
                    return DateTime.Parse(value);
                }

                return null;
            }

            set
            {
                this.Driver.WaitForAngular();
                var element = this.Driver.FindElement(this.Selector);
                this.ScrollToElement(element);
                element.Clear();

                this.Driver.WaitForAngular();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);

                if (value != null)
                {
                    this.Driver.WaitForAngular();
                    element.SendKeys(value.Value.ToString("d"));
                }

                this.Driver.WaitForAngular();
                element.SendKeys(Keys.Tab);
            }
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class MatMonthpicker<T> : MatDatepicker where T : Component
    {
        public MatMonthpicker(T page, MetaPopulation m, RoleType roleType, params string[] scopes)
            : base(page.Driver, m, roleType, scopes) =>
            this.Page = page;

        public T Page { get; }

        public T Set(DateTime value)
        {
            this.Value = value;
            return this.Page;
        }
    }
}
