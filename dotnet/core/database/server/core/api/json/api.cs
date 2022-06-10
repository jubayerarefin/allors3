// <copyright file="PullExtent.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Protocol.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Allors.Protocol.Json.Api.Invoke;
    using Allors.Protocol.Json.Api.Pull;
    using Allors.Protocol.Json.Api.Push;
    using Allors.Protocol.Json.Api.Security;
    using Allors.Protocol.Json.Api.Sync;
    using Allors.Protocol.Json.SystemTextJson;
    using Data;
    using Derivations;
    using Domain;
    using Meta;
    using Ranges;
    using Security;
    using Services;
    using Tracing;
    using User = Domain.User;

    public class Api
    {
        public Api(ITransaction transaction, string workspaceName, CancellationToken cancellationToken)
        {
            this.Transaction = transaction;
            this.WorkspaceName = workspaceName;
            this.CancellationToken = cancellationToken;
            this.Sink = transaction.Database.Sink;

            var transactionServices = transaction.Services;
            var databaseServices = transaction.Database.Services;
            var metaCache = databaseServices.Get<IMetaCache>();

            this.Ranges = databaseServices.Get<IRanges<long>>();
            this.User = transactionServices.Get<IUserService>().User;
            this.AccessControl = transactionServices.Get<IWorkspaceAclsService>().Create(this.WorkspaceName);
            this.AllowedClasses = metaCache.GetWorkspaceClasses(this.WorkspaceName);
            this.M = databaseServices.Get<MetaPopulation>();
            this.MetaPopulation = this.M;
            this.PreparedSelects = databaseServices.Get<IPreparedSelects>();
            this.PreparedExtents = databaseServices.Get<IPreparedExtents>();
            this.Build = @class => DefaultObjectBuilder.Build(transaction, @class);
            this.Derive = () => this.Transaction.Derive(false);
            this.Security = databaseServices.Get<ISecurity>();

            this.UnitConvert = new UnitConvert();
        }

        public ITransaction Transaction { get; }

        public ISecurity Security { get; }

        public string WorkspaceName { get; set; }
        public CancellationToken CancellationToken { get; }

        public ISink Sink { get; }

        public IRanges<long> Ranges { get; }

        public User User { get; }

        public IAccessControl AccessControl { get; }

        public ISet<IClass> AllowedClasses { get; }

        public MetaPopulation M { get; }

        public MetaPopulation MetaPopulation { get; }

        public IPreparedSelects PreparedSelects { get; }

        public IPreparedExtents PreparedExtents { get; }

        public Func<IClass, IObject> Build { get; }

        public Func<IValidation> Derive { get; }

        public UnitConvert UnitConvert { get; }

        public InvokeResponse Invoke(InvokeRequest invokeRequest)
        {
            var @event = this.Sink?.OnInvoke(this.Transaction, invokeRequest);
            this.Sink?.OnBefore(@event);

            var invokeResponseBuilder = new InvokeResponseBuilder(this.Transaction, this.Derive, this.AccessControl, this.AllowedClasses);
            var invokeResponse = invokeResponseBuilder.Build(invokeRequest);

            if (@event != null)
            {
                @event.InvokeResponse = invokeResponse;
                this.Sink?.OnAfter(@event);
            }

            return invokeResponse;
        }

        public PullResponse Pull(PullRequest pullRequest)
        {
            var @event = this.Sink?.OnPull(this.Transaction, pullRequest);
            this.Sink?.OnBefore(@event);

            var pullResponsePrefetcher = new PullResponsePrefetcher(this.Transaction, this.M);
            var dependencies = this.ToDependencies(pullRequest.d);
            var pullResponseBuilder = new PullResponseBuilder(this.Transaction, this.AccessControl, this.AllowedClasses, this.PreparedSelects, this.PreparedExtents, this.UnitConvert, this.Ranges, dependencies, pullResponsePrefetcher, this.CancellationToken);
            var pullResponse = pullResponseBuilder.Build(pullRequest);

            if (@event != null)
            {
                @event.PullResponse = pullResponse;
                this.Sink?.OnAfter(@event);
            }

            return pullResponse;
        }

        public PushResponse Push(PushRequest pushRequest)
        {
            var @event = this.Sink?.OnPush(this.Transaction, pushRequest);
            this.Sink?.OnBefore(@event);

            var pushResponseBuilder = new PushResponseBuilder(this.Transaction, this.Derive, this.MetaPopulation, this.AccessControl, this.AllowedClasses, this.Build, this.UnitConvert);
            var pushResponse = pushResponseBuilder.Build(pushRequest);

            if (@event != null)
            {
                @event.PushResponse = pushResponse;
                this.Sink?.OnAfter(@event);
            }

            return pushResponse;
        }

        public SyncResponse Sync(SyncRequest syncRequest)
        {
            var @event = this.Sink?.OnSync(this.Transaction, syncRequest);
            this.Sink?.OnBefore(@event);


            void Prefetch(IEnumerable<IObject> objects)
            {
                // Prefetch
                foreach (var groupBy in objects.GroupBy(v => v.Strategy.Class, v => v))
                {
                    var prefetchClass = groupBy.Key;
                    var prefetchObjects = groupBy;

                    var prefetchPolicyBuilder = new PrefetchPolicyBuilder();
                    prefetchPolicyBuilder.WithWorkspaceRules(prefetchClass);
                    prefetchPolicyBuilder.WithSecurityRules((Class)prefetchClass, this.M);

                    var prefetcher = prefetchPolicyBuilder.Build();

                    this.Transaction.Prefetch(prefetcher, prefetchObjects);
                }
            }

            var syncResponseBuilder = new SyncResponseBuilder(this.Transaction, this.WorkspaceName, this.AccessControl, this.AllowedClasses, Prefetch, this.UnitConvert, this.Ranges);
            var syncResponse = syncResponseBuilder.Build(syncRequest);

            if (@event != null)
            {
                @event.SyncResponse = syncResponse;
                this.Sink?.OnAfter(@event);
            }

            return syncResponse;
        }

        public AccessResponse Access(AccessRequest accessRequest)
        {
            var responseBuilder = new AccessResponseBuilder(this.Transaction, this.Security, this.WorkspaceName);
            return responseBuilder.Build(accessRequest);
        }

        public PermissionResponse Permission(PermissionRequest permissionRequest)
        {
            var responseBuilder = new PermissionResponseBuilder(this.Transaction, this.AllowedClasses);
            return responseBuilder.Build(permissionRequest);
        }

        // TODO: Delete
        public PullResponseBuilder CreatePullResponseBuilder(string dependencyId = null)
        {
            // TODO: Dependencies
            var pullResponsePrefetcher = new PullResponsePrefetcher(this.Transaction, this.M);
            return new PullResponseBuilder(this.Transaction, this.AccessControl, this.AllowedClasses, this.PreparedSelects, this.PreparedExtents, this.UnitConvert, this.Ranges, null, pullResponsePrefetcher, this.CancellationToken);
        }

        private IDictionary<IClass, ISet<IPropertyType>> ToDependencies(PullDependency[] pullDependencies)
        {
            if (pullDependencies == null)
            {
                return null;
            }

            var classDependencies = new Dictionary<IClass, ISet<IPropertyType>>();

            foreach (var pullDependency in pullDependencies)
            {
                var objectType = (IComposite)this.M.FindByTag(pullDependency.o);
                IPropertyType propertyType;
                if (pullDependency.a != null)
                {
                    propertyType = ((IRelationType)this.M.FindByTag(pullDependency.a)).AssociationType;
                }
                else
                {
                    propertyType = ((IRelationType)this.M.FindByTag(pullDependency.r)).RoleType;
                }

                foreach (var @class in objectType.Classes)
                {
                    if (!classDependencies.TryGetValue(@class, out var classDependency))
                    {
                        classDependency = new HashSet<IPropertyType>();
                        classDependencies.Add(@class, classDependency);
                    }

                    classDependency.Add(propertyType);
                }
            }

            return classDependencies;
        }
    }
}
