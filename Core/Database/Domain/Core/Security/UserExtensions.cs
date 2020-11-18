// <copyright file="UserExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
   

    public static partial class UserExtensions
    {
        public static bool IsAdministrator(this User @this)
        {
            var administrators = new UserGroups(@this.Session()).Administrators;
            return administrators.Members.Contains(@this);
        }

        public static T SetPassword<T>(this T @this, string clearTextPassword)
            where T : User
        {
            var passwordService = @this.Session().Database.Context().PasswordHasher;
            @this.UserPasswordHash = passwordService.HashPassword(@this.UserName, clearTextPassword);
            return @this;
        }

        public static bool VerifyPassword(this User @this, string clearTextPassword)
        {
            if (string.IsNullOrWhiteSpace(clearTextPassword))
            {
                return false;
            }

            var passwordService = @this.Session().Database.Context().PasswordHasher;
            return passwordService.VerifyHashedPassword(@this.UserName, @this.UserPasswordHash, clearTextPassword);
        }

        public static void CoreOnPostBuild(this User @this, ObjectOnPostBuild method)
        {
            if (!@this.ExistOwnerAccessControl)
            {
                var ownerRole = new Roles(@this.Strategy.Session).Owner;
                @this.OwnerAccessControl = new AccessControlBuilder(@this.Strategy.Session)
                    .WithRole(ownerRole)
                    .WithSubject(@this)
                    .Build();
            }

            if (!@this.ExistOwnerSecurityToken)
            {
                @this.OwnerSecurityToken = new SecurityTokenBuilder(@this.Strategy.Session)
                    .WithAccessControl(@this.OwnerAccessControl)
                    .Build();
            }

            if (!@this.ExistUserSecurityStamp)
            {
                @this.UserSecurityStamp = Guid.NewGuid().ToString();
            }
        }

        public static void CoreOnDerive(this User @this, ObjectOnDerive method)
        {
            @this.NormalizedUserName = Users.Normalize(@this.UserName);
            @this.NormalizedUserEmail = Users.Normalize(@this.UserEmail);

            if (@this.ExistInUserPassword)
            {
                var passwordService = @this.Session().Database.Context().PasswordHasher;
                @this.UserPasswordHash = passwordService.HashPassword(@this.UserName, @this.InUserPassword);
                @this.RemoveInUserPassword();
            }
        }

        public static void CoreDelete(this User @this, DeletableDelete method)
        {
            @this.OwnerAccessControl?.Delete();
            @this.OwnerSecurityToken?.Delete();

            foreach (Login login in @this.Logins)
            {
                login.Delete();
            }
        }
    }
}
