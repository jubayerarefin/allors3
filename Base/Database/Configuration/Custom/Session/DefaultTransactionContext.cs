// <copyright file="DefaultTransactionContext.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the DomainTest type.</summary>

namespace Allors.Database.Configuration
{
    using Database;
    using Domain;
    using Microsoft.AspNetCore.Http;

    public class DefaultTransactionContext : ITransactionContext
    {
        private readonly HttpContext httpContext;

        public DefaultTransactionContext(IHttpContextAccessor httpContextAccessor) => this.httpContext = new HttpContext(httpContextAccessor);

        public virtual void OnInit(ITransaction session) => this.httpContext.OnInit(session);

        public void Dispose()
        {
        }

        public User User
        {
            get => this.httpContext.User;
            set => this.httpContext.User = value;
        }
    }
}
