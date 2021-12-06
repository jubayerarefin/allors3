// <copyright file="MatInput.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Angular.Components
{
    using System.Threading.Tasks;
    using Allors.Database.Meta;
    using Microsoft.Playwright;
    using Tests;
    using Task = System.Threading.Tasks.Task;

    public class AllorsMaterialSlideToggleComponent : RoleControl
    {
        public AllorsMaterialSlideToggleComponent(IComponent container, RoleType roleType) : base(container, roleType, "a-mat-slidetoggle")
        {
        }

        public ILocator InputLocator => this.Locator.Locator("input[type=checkbox]");

        public ILocator LabelLocator => this.Locator.Locator("label");

        public async Task<bool> GetAsync()
        {
            await this.Page.WaitForAngular();
            return await this.InputLocator.IsCheckedAsync();
        }

        public async Task SetAsync(bool value)
        {
            await this.Page.WaitForAngular();

            var isSelected = await this.GetAsync();
            if (isSelected)
            {
                if (!value)
                {
                    await this.LabelLocator.ClickAsync();
                }
            }
            else if (value)
            {
                await this.LabelLocator.ClickAsync();
            }
        }
    }
}
