// <copyright file="Model.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.E2E.Angular.Info
{
    using System.Text.Json;
    using System.Threading.Tasks;
    using Allors.E2E.Angular;

    public static partial class AppRootExtensions
    {
        public static async Task<MenuInfo[]> GetMenuInfos(this AppRoot @this)
        {
            var jsonString = await @this.GetAllors("menu");
            var menuInfos = JsonSerializer.Deserialize<MenuInfo[]>(
                jsonString,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            foreach (var menuInfo in menuInfos)
            {
                menuInfo.ConnectParentToChildren();
            }

            return menuInfos;
        }
    }
}
