// <copyright file="PullResponseBuilder.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Protocol.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Protocol.Json;
    using Allors.Protocol.Json.Api.Pull;
    using Data;
    using Derivations;
    using Meta;
    using Ranges;
    using Security;
    using Services;

    public class PullResponseBuilder : IProcedureContext, IProcedureOutput
    {
        private readonly IUnitConvert unitConvert;
        private readonly IRanges<long> ranges;
        private readonly IDictionary<IClass, ISet<IPropertyType>> dependencies;

        private readonly Dictionary<string, ISet<IObject>> collectionsByName = new Dictionary<string, ISet<IObject>>();
        private readonly Dictionary<string, IObject> objectByName = new Dictionary<string, IObject>();
        private readonly Dictionary<string, object> valueByName = new Dictionary<string, object>();

        private readonly HashSet<IObject> objects;

        private List<IValidation> errors;
        private readonly Action<IEnumerable<IObject>> prefetch;

        public PullResponseBuilder(ITransaction transaction, IAccessControl accessControl, ISet<IClass> allowedClasses, IPreparedSelects preparedSelects, IPreparedExtents preparedExtents, IUnitConvert unitConvert, IRanges<long> ranges, IDictionary<IClass, ISet<IPropertyType>> dependencies, Action<IEnumerable<IObject>> prefetch)
        {
            this.unitConvert = unitConvert;
            this.ranges = ranges;
            this.dependencies = dependencies;
            this.Transaction = transaction;

            this.AccessControl = accessControl;
            this.AllowedClasses = allowedClasses;
            this.PreparedSelects = preparedSelects;
            this.PreparedExtents = preparedExtents;

            this.prefetch = prefetch;

            this.objects = new HashSet<IObject>();
        }

        public ITransaction Transaction { get; }

        public IAccessControl AccessControl { get; }

        public ISet<IClass> AllowedClasses { get; }

        public IPreparedSelects PreparedSelects { get; }

        public IPreparedExtents PreparedExtents { get; }

        public void AddError(IValidation validation)
        {
            this.errors ??= new List<IValidation>();
            this.errors.Add(validation);
        }

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

        public void AddCollection(string name, in IEnumerable<IObject> collection, Node[] tree)
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

        public void AddObject(string name, IObject @object) => this.AddObjectInternal(name, @object);

        public void AddObject(string name, IObject @object, Node[] tree) => this.AddObjectInternal(name, @object, tree);

        public void AddValue(string name, object value)
        {
            if (value != null)
            {
                this.valueByName.Add(name, value);
            }
        }

        private void AddObjectInternal(string name, IObject @object, Node[] tree = null)
        {
            if (@object != null && this.AllowedClasses?.Contains(@object.Strategy.Class) == true)
            {
                if (tree != null)
                {
                    // TODO: include dependencies
                    // Prefetch
                    var transaction = @object.Strategy.Transaction;
                    var prefetcher = tree.BuildPrefetchPolicy();
                    transaction.Prefetch(prefetcher, @object);
                }

                this.objects.Add(@object);
                this.objectByName[name] = @object;
                tree?.Resolve(@object, this.AccessControl, this.objects.Add);
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
                        this.Transaction.Prefetch(prefetchPolicy, newCollection);
                        existingCollection.UnionWith(newCollection);
                    }
                    else
                    {
                        var newSet = new HashSet<IObject>(filteredCollection);
                        newCollection = newSet;
                        this.Transaction.Prefetch(prefetchPolicy, newCollection);
                        this.collectionsByName.Add(name, newSet);
                    }

                    this.objects.UnionWith(newCollection);

                    foreach (var newObject in newCollection)
                    {
                        tree.Resolve(newObject, this.AccessControl, this.objects.Add);
                    }
                }
                else if (existingCollection != null)
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

        public PullResponse Build(PullRequest pullRequest = null)
        {
            var pullResponse = new PullResponse();

            var procedure = pullRequest?.p?.FromJson(this.Transaction, this.unitConvert);

            if (procedure != null)
            {
                if (procedure.Pool != null)
                {
                    foreach (var kvp in procedure.Pool)
                    {
                        var @object = kvp.Key;
                        var version = kvp.Value;

                        if (!@object.Strategy.ObjectVersion.Equals(version))
                        {
                            pullResponse.AddVersionError(@object);
                        }
                    }

                    if (pullResponse.HasErrors)
                    {
                        return pullResponse;
                    }
                }

                var procedures = this.Transaction.Database.Services.Get<IProcedures>();
                var proc = procedures.Get(procedure.Name);
                if (proc == null)
                {
                    pullResponse._e = $"Missing procedure {procedure.Name}";
                    return pullResponse;
                }

                var input = new ProcedureInput(this.Transaction.Database.ObjectFactory, procedure);

                proc.Execute(this, input, this);

                if (this.errors?.Count > 0)
                {
                    foreach (var error in this.errors)
                    {
                        pullResponse.AddDerivationErrors(error);
                    }

                    return pullResponse;
                }
            }

            if (pullRequest?.l != null)
            {
                foreach (var p in pullRequest.l)
                {
                    var pull = p.FromJson(this.Transaction, this.unitConvert);

                    if (pull.Object != null)
                    {
                        var pullInstantiate = new PullInstantiate(this.Transaction, pull, this.AccessControl, this.PreparedSelects);
                        pullInstantiate.Execute(this);
                    }
                    else
                    {
                        var pullExtent = new PullExtent(this.Transaction, pull, this.AccessControl, this.PreparedSelects, this.PreparedExtents);
                        pullExtent.Execute(this);
                    }
                }
            }

            // Add dependencies
            this.AddDependencies();

            this.prefetch(this.objects);

            // Serialize
            var grants = new HashSet<IGrant>();
            var revocations = new HashSet<IRevocation>();

            pullResponse = new PullResponse
            {
                p = this.objects.Select(v =>
                {
                    var accessControlList = this.AccessControl[v];

                    grants.UnionWith(accessControlList.Grants);
                    revocations.UnionWith(accessControlList.Revocations);

                    return new PullResponseObject
                    {
                        i = v.Strategy.ObjectId,
                        v = v.Strategy.ObjectVersion,
                        g = this.ranges.Import(accessControlList.Grants.Select(w => w.Strategy.ObjectId)).Save(),
                        r = this.ranges.Import(accessControlList.Revocations.Select(w => w.Strategy.ObjectId))
                            .Save(),
                    };
                }).ToArray(),
                o = this.objectByName.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Id),
                c = this.collectionsByName.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Select(obj => obj.Id).ToArray()),
                v = this.valueByName,
            };

            pullResponse.g = grants.Count > 0 ? grants.Select(v => new[] { v.Strategy.ObjectId, v.Strategy.ObjectVersion }).ToArray() : null;
            pullResponse.r = revocations.Count > 0 ? revocations.Select(v => new[] { v.Strategy.ObjectId, v.Strategy.ObjectVersion }).ToArray() : null;

            return pullResponse;
        }

        private void AddDependencies()
        {
            if (this.dependencies == null)
            {
                return;
            }

            var current = this.objects.ToArray();

            while (current.Length > 0)
            {
                var newObjects = new HashSet<IObject>();

                foreach (var grouping in current.GroupBy(v => v.Strategy.Class, v => v))
                {
                    var @class = grouping.Key;
                    var grouped = grouping.ToArray();

                    if (this.dependencies.TryGetValue(@class, out var propertyTypes))
                    {
                        var builder = new PrefetchPolicyBuilder();
                        foreach (var propertyType in propertyTypes)
                        {
                            builder.WithRule(propertyType);
                        }

                        var policy = builder.Build();

                        this.Transaction.Prefetch(policy, grouped);

                        foreach (var @object in grouped)
                        {
                            foreach (var propertyType in propertyTypes)
                            {
                                if (propertyType is IRoleType roleType)
                                {
                                    if (roleType.IsOne)
                                    {
                                        newObjects.Add(@object.Strategy.GetCompositeRole(roleType));
                                    }
                                    else
                                    {
                                        newObjects.UnionWith(@object.Strategy.GetCompositesRole<IObject>(roleType));
                                    }
                                }
                                else
                                {
                                    var associationType = (IAssociationType)propertyType;
                                    if (associationType.IsOne)
                                    {
                                        newObjects.Add(@object.Strategy.GetCompositeAssociation(associationType));
                                    }
                                    else
                                    {
                                        newObjects.UnionWith(@object.Strategy.GetCompositesAssociation<IObject>(associationType));
                                    }
                                }
                            }
                        }
                    }
                }

                newObjects.Remove(null);

                current = newObjects.Except(this.objects).ToArray();
                this.objects.UnionWith(newObjects);
            }
        }
    }
}
