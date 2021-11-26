// <copyright file="MatTextarea.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Components
{
    using System.Diagnostics.CodeAnalysis;
    using Allors.Database.Meta;
    using OpenQA.Selenium;

    public class MatMarkdown : SelectorComponent
    {
        public MatMarkdown(IWebDriver driver, MetaPopulation m, RoleType roleType, params string[] scopes)
        : base(driver, m)
        {
            this.Selector = By.XPath($".//a-mat-markdown{this.ByScopesPredicate(scopes)}//*[@data-allors-roletype='{roleType.RelationType.Tag}']");
        }

        public override By Selector { get; }

        public string Value
        {
            get
            {
                this.Driver.WaitForAngular();
                var element = this.Driver.FindElement(this.Selector);
                return element.GetAttribute("value");
            }

            set
            {
                this.Driver.WaitForAngular();
                var element = this.Driver.FindElement(this.Selector);

                var setValue =
$@"const element = arguments[0];
element.easyMDE.value('{value}');";
                var javaScriptExecutor = (IJavaScriptExecutor)this.Driver;
                javaScriptExecutor.ExecuteScript(setValue, element);
            }
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class MatMarkdown<T> : MatMarkdown where T : Component
    {
        public MatMarkdown(T page, MetaPopulation m, RoleType roleType, params string[] scopes)
            : base(page.Driver, m, roleType, scopes) =>
            this.Page = page;

        public T Page { get; }

        public T Set(string value)
        {
            this.Value = value;
            return this.Page;
        }
    }
}
