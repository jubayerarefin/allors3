// <copyright file="PullResponseBuilder.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Direct.Api.Pull
{
    using System.Collections.Generic;
    using System.Linq;
    using Database;
    using Database.Data;
    using Database.Meta;
    using Database.Security;

    public class PullResponseBuilder
    {
        private readonly Dictionary<string, ISet<IObject>> collectionsByName = new Dictionary<string, ISet<IObject>>();
        private readonly Dictionary<string, IObject> objectByName = new Dictionary<string, IObject>();
        private readonly Dictionary<string, string> valueByName = new Dictionary<string, string>();

        private readonly HashSet<IObject> objects;

        public PullResponseBuilder(ISession session, IAccessControlLists accessControlLists, ISet<IClass> allowedClasses, IPreparedFetches preparedFetches, IPreparedExtents preparedExtents)
        {
            this.Session = session;

            this.AccessControlLists = accessControlLists;
            this.AllowedClasses = allowedClasses;
            this.PreparedFetches = preparedFetches;
            this.PreparedExtents = preparedExtents;

            this.objects = new HashSet<IObject>();
        }

        public ISession Session { get; }

        public IAccessControlLists AccessControlLists { get; }

        public ISet<IClass> AllowedClasses { get; }

        public IPreparedFetches PreparedFetches { get; }

        public IPreparedExtents PreparedExtents { get; }

        public void AddCollection(string name, in IEnumerable<IObject> collection)
        {
            switch (collection)
            {
                case ICollection<IObject> asCollection:
                    this.AddCollectionInternal(name, asCollection, null);
                    break;
                default:
                    this.AddCollectionInternal(name, collection.ToArray(), null);
                    break;
            }
        }

        public void AddCollection(string name, in ICollection<IObject> collection) => this.AddCollectionInternal(name, collection, null);

        public void AddCollection(string name, IEnumerable<IObject> collection, Node[] tree)
        {
            switch (collection)
            {
                case ICollection<IObject> list:
                    this.AddCollectionInternal(name, list, tree);
                    break;
                default:
                {
                    this.AddCollectionInternal(name, collection.ToArray(), tree);
                    break;
                }
            }
        }

        public void AddObject(string name, IObject @object)
        {
            if (@object != null)
            {
                this.AddObject(name, @object, null);
            }
        }

        public void AddObject(string name, IObject @object, Node[] tree)
        {
            if (@object != null)
            {
                if (this.AllowedClasses?.Contains(@object.Strategy.Class) == true)
                {
                    if (tree != null)
                    {
                        // Prefetch
                        var session = @object.Strategy.Session;
                        var prefetcher = tree.BuildPrefetchPolicy();
                        session.Prefetch(prefetcher, @object);
                    }

                    this.objects.Add(@object);
                    this.objectByName[name] = @object;
                    tree?.Resolve(@object, this.AccessControlLists, this.objects);
                }
            }
        }

        public void AddValue(string name, string value)
        {
            if (value != null)
            {
                this.valueByName.Add(name, value);
            }
        }

        private void AddCollectionInternal(string name, in ICollection<IObject> collection, Node[] tree)
        {
            if (collection?.Count > 0)
            {
                this.collectionsByName.TryGetValue(name, out var existingCollection);

                var filteredCollection = collection.Where(v => this.AllowedClasses != null && this.AllowedClasses.Contains(v.Strategy.Class));

                if (tree != null)
                {
                    var prefetchPolicy = tree.BuildPrefetchPolicy();

                    ICollection<IObject> newCollection;

                    if (existingCollection != null)
                    {
                        newCollection = filteredCollection.ToArray();
                        this.Session.Prefetch(prefetchPolicy, newCollection);
                        existingCollection.UnionWith(newCollection);
                    }
                    else
                    {
                        var newSet = new HashSet<IObject>(filteredCollection);
                        newCollection = newSet;
                        this.Session.Prefetch(prefetchPolicy, newCollection);
                        this.collectionsByName.Add(name, newSet);
                    }

                    this.objects.UnionWith(newCollection);

                    foreach (var newObject in newCollection)
                    {
                        tree.Resolve(newObject, this.AccessControlLists, this.objects);
                    }
                }
                else
                {
                    if (existingCollection != null)
                    {
                        existingCollection.UnionWith(filteredCollection);
                    }
                    else
                    {
                        var newWorkspaceCollection = new HashSet<IObject>(filteredCollection);
                        this.collectionsByName.Add(name, newWorkspaceCollection);
                        this.objects.UnionWith(newWorkspaceCollection);
                    }
                }
            }
        }

        public PullResponseBuilder With(Pull pull)
        {
            if (pull.Object != null)
            {
                var pullInstantiate = new PullInstantiate(this.Session, pull, this.AccessControlLists, this.PreparedFetches);
                pullInstantiate.Execute(this);
            }
            else
            {
                var pullExtent = new PullExtent(this.Session, pull, this.AccessControlLists, this.PreparedFetches, this.PreparedExtents);
                pullExtent.Execute(this);
            }

            return this;
        }

        public PullResponse Build() =>
            new PullResponse
            {
                Objects = this.objects.Select(v =>
                {
                    var strategy = v.Strategy;
                    var accessControlLists = this.AccessControlLists[strategy.GetObject()];
                    var accessControls = accessControlLists.AccessControls?.Select(w => w.Strategy.ObjectId);
                    var deniedPermissions = accessControlLists.DeniedPermissionIds;
                    return new Object(strategy, accessControls?.ToArray(), deniedPermissions?.ToArray());
                }).ToArray(),
                NamedObjects = this.objectByName.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Id),
                NamedCollections =
                    this.collectionsByName.ToDictionary(kvp => kvp.Key,
                        kvp => kvp.Value.Select(obj => obj.Id).ToArray()),
                NamedValues = this.valueByName,
                AccessControls = this.AccessControlLists.EffectivePermissionIdsByAccessControl.Keys
                    .Select(v => new AccessControl(v.Strategy.ObjectId, v.Strategy.ObjectVersion, v.Permissions.Select(w => w.Id).ToArray()))
                    .ToArray(),
            };
    }
}
