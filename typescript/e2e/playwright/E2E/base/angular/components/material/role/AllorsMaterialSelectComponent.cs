// <copyright file="MatInput.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Angular.Components
{
    using System.Threading.Tasks;
    using Allors.Database;
    using Allors.Database.Meta;
    using Microsoft.Playwright;
    using Tests;
    using Task = System.Threading.Tasks.Task;

    public class AllorsMaterialSelectComponent : RoleControl
    {
        public AllorsMaterialSelectComponent(IComponent container, RoleType roleType) : base(container, roleType, "a-mat-select")
        {
        }

        public ILocator ArrowLocator => this.Locator.Locator(".mat-select-arrow");

        public ILocator ValueTextLocator => this.Locator.Locator(".mat-select-value-text");

        public async Task<string> GetAsync()
        {
            await this.Page.WaitForAngular();
            return await this.ValueTextLocator.TextContentAsync();
        }

        public async Task SetAsync(string value)
        {
            await this.Page.WaitForAngular();
            await this.ArrowLocator.ClickAsync();

            await this.Page.WaitForAngular();
            var optionLocator = this.Page.Locator($"mat-option[data-allors-option-display='{value}'] span");
            await optionLocator.ClickAsync();
        }

        public async Task SelectAsync(IObject @object)
        {
            await this.Page.WaitForAngular();
            await this.ArrowLocator.ClickAsync();

            await this.Page.WaitForAngular();
            var optionLocator = this.Page.Locator($"mat-option[data-allors-option-id='{@object?.Id ?? 0}'] span");
            await optionLocator.ClickAsync();
        }
    }
}
