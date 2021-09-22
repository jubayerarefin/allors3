// <copyright file="DefaultDatabaseScope.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the DomainTest type.</summary>

using System;
using Allors.Database.Configuration.Derivations.Default;
using Allors.Database.Derivations;
using Allors.Database.Services;
using Allors.Ranges;

namespace Allors.Database.Configuration
{
    using Database.Data;
    using Domain;
    using Meta;
    using Microsoft.AspNetCore.Http;

    public abstract class DatabaseServices : IDatabaseServices
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private IDatabase database;

        private IRanges<long> ranges;

        private IMetaCache metaCache;

        private IClassById classById;

        private IVersionedIdByStrategy versionedIdByStrategy;

        private IPrefetchPolicyCache prefetchPolicyCache;

        private IPreparedSelects preparedSelects;

        private IPreparedExtents preparedExtents;

        private ITreeCache treeCache;

        private IPermissionsCache permissionsCache;

        private IGrantCache grantCache;

        private ITime time;

        private ICaches caches;

        private ISingletonId singletonId;

        private IPasswordHasher passwordHasher;

        private IMailer mailer;

        private IBarcodeGenerator barcodeGenerator;

        private ITemplateObjectCache templateObjectCache;

        private IDerivationService derivationFactory;

        protected DatabaseServices(Engine engine, IHttpContextAccessor httpContextAccessor = null)
        {
            this.Engine = engine;
            this.httpContextAccessor = httpContextAccessor;
        }

        public virtual void OnInit(IDatabase database)
        {
            this.database = database;
            this.M = (MetaPopulation)this.database.MetaPopulation;
        }

        public MetaPopulation M { get; private set; }

        public ITransactionServices CreateTransactionServices() => new TransactionServices(this.httpContextAccessor);

        public T Get<T>() =>
            typeof(T) switch
            {
                // Core
                { } type when type == typeof(MetaPopulation) => (T)(object)this.M,
                { } type when type == typeof(IRanges<long>) => (T)(this.ranges ??= new DefaultStructRanges<long>()),
                { } type when type == typeof(IMetaCache) => (T)(this.metaCache ??= new MetaCache(this.database)),
                { } type when type == typeof(IClassById) => (T)(this.classById ??= new ClassById()),
                { } type when type == typeof(IVersionedIdByStrategy) => (T)(this.versionedIdByStrategy ??= new VersionedIdByStrategy()),
                { } type when type == typeof(IPrefetchPolicyCache) => (T)(this.prefetchPolicyCache ??= new PrefetchPolicyCache(this.database)),
                { } type when type == typeof(IPreparedSelects) => (T)(this.preparedSelects ??= new PreparedSelects(this.database)),
                { } type when type == typeof(IPreparedExtents) => (T)(this.preparedExtents ??= new PreparedExtents(this.database)),
                { } type when type == typeof(ITreeCache) => (T)(this.treeCache ??= new TreeCache()),
                { } type when type == typeof(IPermissionsCache) => (T)(this.permissionsCache ??= new PermissionsCache(this.database)),
                { } type when type == typeof(IGrantCache) => (T)(this.grantCache ??= new GrantCache()),
                { } type when type == typeof(ITime) => (T)(this.time ??= new Time()),
                { } type when type == typeof(ICaches) => (T)(this.caches ??= new Caches()),
                { } type when type == typeof(IPasswordHasher) => (T)(this.passwordHasher ??= this.CreatePasswordHasher()),
                { } type when type == typeof(IDerivationService) => (T)(this.derivationFactory ??= this.CreateDerivationFactory()),
                // Base
                { } type when type == typeof(ISingletonId) => (T)(this.singletonId ??= new SingletonId()),
                { } type when type == typeof(IMailer) => (T)(this.mailer ??= new MailKitMailer()),
                { } type when type == typeof(IBarcodeGenerator) => (T)(this.barcodeGenerator ??= new ZXingBarcodeGenerator()),
                { } type when type == typeof(ITemplateObjectCache) => (T)(this.templateObjectCache ??= new TemplateObjectCache()),
                _ => throw new NotSupportedException($"Service {typeof(T)} not supported")
            };

        protected IPasswordHasher CreatePasswordHasher() => new PasswordHasher();

        protected IDerivationService CreateDerivationFactory() => new DerivationService(this.Engine);

        protected Engine Engine { get; }

        public void Dispose() { }
    }
}