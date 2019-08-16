
// <copyright file="SessionExtension.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using Allors.Services;

    using Microsoft.Extensions.DependencyInjection;

    public static partial class SessionExtension
    {
        public static User GetUser(this ISession @this)
        {
            var userService = @this.ServiceProvider.GetRequiredService<IUserService>();
            var userName = userService.UserName;
            var users = new Users(@this);
            var user = users.GetUser(userName) ?? @this.GetSingleton()?.Guest;
            return user;
        }

        public static void SetUser(this ISession @this, User user)
        {
            var userService = @this.ServiceProvider.GetRequiredService<IUserService>();
            userService.UserName = user?.UserName;
        }
    }
}
