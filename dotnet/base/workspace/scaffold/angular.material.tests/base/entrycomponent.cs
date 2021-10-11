// <copyright file="EntryComponent.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Components
{
    using Allors.Database.Meta;
    using OpenQA.Selenium;

    public abstract class EntryComponent : Component
    {
        protected EntryComponent(IWebDriver driver, MetaPopulation m) : base(driver, m)
        {
        }
    }
}
