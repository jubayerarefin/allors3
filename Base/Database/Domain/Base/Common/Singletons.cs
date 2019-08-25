﻿// <copyright file="Singletons.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using Allors.Meta;

    public partial class Singletons
    {
        protected override void BasePrepare(Setup setup) => setup.AddDependency(this.ObjectType, M.Locale.ObjectType);

        protected override void BaseSetup(Setup setup)
        {
            var singleton = this.Instance;
            singleton.DefaultLocale = new Locales(this.Session).EnglishGreatBritain;

            singleton.EmployeeUserGroup = new UserGroups(this.Session).Employees;
            singleton.SalesAccountManagerUserGroup = new UserGroups(this.Session).SalesAccountManagers;

            if (setup.Config.SetupSecurity)
            {
                var employeeRole = new Roles(this.Session).Employee;

                singleton.EmployeeAccessControl = new AccessControlBuilder(this.Session)
                    .WithSubjectGroup(singleton.EmployeeUserGroup)
                    .WithRole(employeeRole)
                    .Build();

                singleton.DefaultSecurityToken.AddAccessControl(singleton.EmployeeAccessControl);

                var salesAccountManagerRole = new Roles(this.Session).SalesAccountManager;

                singleton.SalesAccountManagerAccessControl = new AccessControlBuilder(this.Session)
                    .WithSubjectGroup(singleton.SalesAccountManagerUserGroup)
                    .WithRole(salesAccountManagerRole)
                    .Build();

                singleton.DefaultSecurityToken.AddAccessControl(singleton.SalesAccountManagerAccessControl);
            }
        }
    }
}