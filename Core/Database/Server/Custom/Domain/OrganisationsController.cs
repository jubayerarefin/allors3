﻿// <copyright file="OrganisationsController.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Server.Controllers
{
    using System.Threading.Tasks;

    using Allors.Domain;
    using Allors.Server;
    using Allors.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class OrganisationsController : Controller
    {
        public OrganisationsController(ISessionService sessionService) => this.Session = sessionService.Session;

        private ISession Session { get; }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Pull()
        {
            var response = new PullResponseBuilder(this.Session.GetUser());
            var people = new Organisations(this.Session).Extent().ToArray();
            response.AddCollection("organisations", people, true);
            return this.Ok(response.Build());
        }
    }
}
