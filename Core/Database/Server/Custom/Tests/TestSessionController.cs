﻿// <copyright file="TestSessionController.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Server.Controllers
{
    using Allors.Domain;
    using Allors.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TestSessionController : Controller
    {
        public TestSessionController(ISessionService sessionService) => this.Session = sessionService.Session;

        private ISession Session { get; }

        [HttpPost]
        [AllowAnonymous]
        [Authorize]
        public IActionResult UserName()
        {
            var user = this.Session.GetUser();
            var result = user.UserName;
            return this.Content(result);
        }
    }
}
