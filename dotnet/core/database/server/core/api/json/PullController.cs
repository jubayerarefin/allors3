
// <copyright file="PullController.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Protocol.Json
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Allors.Protocol.Json.Api.Pull;
    using Services;
    using Data;
    using Domain;

    [ApiController]
    [Route("allors/pull")]
    public class PullController : ControllerBase
    {
        public PullController(IDatabaseService databaseService, IWorkspaceService workspaceService, IPolicyService policyService, ILogger<PullController> logger)
        {
            this.DatabaseService = databaseService;
            this.WorkspaceService = workspaceService;
            this.PolicyService = policyService;

            var scope = this.DatabaseService.Database.Services();

            this.ExtentService = scope.PreparedExtents;
            this.PreparedSelects = scope.PreparedSelects;
            this.TreeCache = scope.TreeCache;
            this.Logger = logger;
        }

        private IDatabaseService DatabaseService { get; }

        public IWorkspaceService WorkspaceService { get; }

        private IPreparedExtents ExtentService { get; }

        private IPreparedSelects PreparedSelects { get; }

        private ILogger<PullController> Logger { get; }

        private IPolicyService PolicyService { get; }

        private ITreeCache TreeCache { get; }

        [HttpPost]
        [Authorize]
        [AllowAnonymous]
        public ActionResult<PullResponse> Post([FromBody] PullRequest request) =>
            this.PolicyService.InvokePolicy.Execute(
                () =>
                {
                    try
                    {
                        using var transaction = this.DatabaseService.Database.CreateTransaction();
                        var api = new Api(transaction, this.WorkspaceService.Name);
                        return api.Pull(request);
                    }
                    catch (Exception e)
                    {
                        this.Logger.LogError(e, "PullRequest {request}", request);
                        throw;
                    }
                });
    }
}