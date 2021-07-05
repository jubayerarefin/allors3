// <copyright file="DefaultDomainTransactionServices.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Configuration
{
    using System;
    using Database;
    using Domain;
    using Domain.Derivations.Rules.Default;
    using Microsoft.AspNetCore.Http;
    using Services;

    public class DefaultDomainTransactionServices : IDomainTransactionServices
    {
        private readonly HttpContext httpContext;

        public DefaultDomainTransactionServices(IHttpContextAccessor httpContextAccessor) => this.httpContext = new HttpContext(httpContextAccessor);

        public virtual void OnInit(ITransaction transaction)
        {
            this.Derive = new DefaultDerive(transaction);
            this.httpContext.OnInit(transaction);
        }

        public IDerive Derive { get; private set; }

        public User User
        {
            get => this.httpContext.User;
            set => this.httpContext.User = value;
        }

        public T Get<T>() => throw new NotSupportedException($"Service {typeof(T)} not supported");

        public void Dispose()
        {
        }
    }
}
