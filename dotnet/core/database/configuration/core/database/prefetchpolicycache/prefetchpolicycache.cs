// <copyright file="IPreparedSelects.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Configuration
{
    using System.Collections.Generic;
    using Database;
    using Domain;
    using Meta;
    using Services;

    public partial class PrefetchPolicyCache : IPrefetchPolicyCache
    {
        private readonly IDictionary<string, IDictionary<IClass, PrefetchPolicy>> prefetchPolicyByClassByWorkspace;

        public PrefetchPolicyCache(IDatabase database, IMetaCache metaCache)
        {
            var m = database.Services.Get<MetaPopulation>();

            this.PermissionsWithClass = new PrefetchPolicyBuilder()
                    .WithRule(m.Permission.ClassPointer)
                    .Build();

            this.Security = new PrefetchPolicyBuilder().WithSecurityRules(m).Build();

            this.prefetchPolicyByClassByWorkspace = new Dictionary<string, IDictionary<IClass, PrefetchPolicy>>();
            foreach (var workspaceName in m.WorkspaceNames)
            {
                var roleTypesByClass = metaCache.GetWorkspaceRoleTypesByClass(workspaceName);

                var prefetchPolicyByClass = new Dictionary<IClass, PrefetchPolicy>();
                foreach (var @class in metaCache.GetWorkspaceClasses(workspaceName))
                {
                    var prefetchPolicyBuilder = new PrefetchPolicyBuilder();
                    prefetchPolicyBuilder.WithWorkspaceRules(m, roleTypesByClass[@class]);
                    var prefetchPolicy = prefetchPolicyBuilder.Build();
                    prefetchPolicyByClass[@class] = prefetchPolicy;
                }

                this.prefetchPolicyByClassByWorkspace[workspaceName] = prefetchPolicyByClass;
            }
        }

        public PrefetchPolicy PermissionsWithClass { get; }

        public PrefetchPolicy Security { get; }

        public IDictionary<IClass, PrefetchPolicy> WorkspacePrefetchPolicyByClass(string workspaceName) => this.prefetchPolicyByClassByWorkspace[workspaceName];
    }
}
