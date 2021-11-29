// <copyright file="EntryComponent.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Components
{
    using Allors.Database.Meta;
    using Microsoft.Playwright;

    public abstract class EntryComponent : Component
    {
        protected EntryComponent(IPage page, MetaPopulation m) : base(page, m)
        {
        }
    }
}
