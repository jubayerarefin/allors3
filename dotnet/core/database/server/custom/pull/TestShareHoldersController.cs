// <copyright file="TestShareHoldersController.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Server.Controllers
{
    using System;

    using Database.Domain;
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using Database;
    using Database.Data;
    using Database.Protocol.Json;

    public class TestShareHoldersController : Controller
    {
        public TestShareHoldersController(ITransactionService transactionService, IWorkspaceService workspaceService)
        {
            this.WorkspaceService = workspaceService;
            this.Transaction = transactionService.Transaction;
            this.TreeCache = this.Transaction.Database.Services().TreeCache;
        }

        private ITransaction Transaction { get; }

        public IWorkspaceService WorkspaceService { get; }

        public ITreeCache TreeCache { get; }

        [HttpPost]
        public IActionResult Pull()
        {
            try
            {
                var api = new Api(this.Transaction, this.WorkspaceService.Name);
                var response = api.CreatePullResponseBuilder();

                var m = this.Transaction.Database.Services().M;
                var organisation = new Organisations(this.Transaction).FindBy(m.Organisation.Owner, this.Transaction.Services().User);
                response.AddObject("root", organisation,
                    new[] {
                                new Node(m.Organisation.Shareholders)
                                });
                return this.Ok(response.Build());
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}