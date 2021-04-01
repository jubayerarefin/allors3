// <copyright file="RemotePullResult.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Workspace.Adapters.Remote
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Protocol.Json.Api.Pull;

    public class RemotePullResult : RemoteResult, IPullResult
    {
        public RemotePullResult(RemoteSession session, PullResponse response) : base(session, response)
        {
            this.Workspace = session.Workspace;

            var identities = session.Database.Identities;

            this.Objects = response.NamedObjects.ToDictionary(
                pair => pair.Key,
                pair => session.Get<IObject>(long.Parse(pair.Value)),
                StringComparer.OrdinalIgnoreCase);
            this.Collections = response.NamedCollections.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Select(v => session.Get<IObject>(long.Parse(v))).ToArray(),
                StringComparer.OrdinalIgnoreCase);
            this.Values = response.NamedValues.ToDictionary(
                pair => pair.Key,
                pair => pair.Value,
                StringComparer.OrdinalIgnoreCase);
        }

        public IDictionary<string, IObject> Objects { get; }

        public IDictionary<string, IObject[]> Collections { get; }

        public IDictionary<string, object> Values { get; }

        private IWorkspace Workspace { get; }

        public T[] GetCollection<T>()
        {
            var objectType = this.Workspace.ObjectFactory.GetObjectType<T>();
            var key = objectType.PluralName;
            return this.GetCollection<T>(key);
        }

        public T[] GetCollection<T>(string key) => this.Collections.TryGetValue(key, out var collection) ? collection?.Cast<T>().ToArray() : null;

        public T GetObject<T>()
            where T : class, IObject
        {
            var objectType = this.Workspace.ObjectFactory.GetObjectType<T>();
            var key = objectType.SingularName;
            return this.GetObject<T>(key);
        }

        public T GetObject<T>(string key)
            where T : class, IObject => this.Objects.TryGetValue(key, out var @object) ? (T)@object : null;

        public object GetValue(string key) => this.Values[key];

        public T GetValue<T>(string key) => (T)this.GetValue(key);
    }
}