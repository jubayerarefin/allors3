// <copyright file="Preparation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain.Derivations.Persistent
{
    using System.Collections.Generic;
    using System.Linq;

    public class Preparation : IPreparation
    {
        public Preparation(Iteration iteration, IEnumerable<Object> marked, AccumulatedChangeSet domainAccumulatedChangeSet = null)
        {
            this.Iteration = iteration;
            var cycle = this.Iteration.Cycle;
            var derivation = cycle.Derivation;
            var session = derivation.Session;

            var changeSet = domainAccumulatedChangeSet ?? session.Checkpoint();

            iteration.ChangeSet.Add(changeSet);
            cycle.ChangeSet.Add(changeSet);
            derivation.ChangeSet.Add(changeSet);

            // Initialization
            if (changeSet.Created.Any())
            {
                var newObjects = changeSet.Created.Select(v=>(Object)v.GetObject());
                foreach (var newObject in newObjects)
                {
                    newObject.OnInit();
                }
            }

            // ChangedObjects
            var changedObjectIds = new HashSet<long>(changeSet.Associations);
            changedObjectIds.UnionWith(changeSet.Roles);
            changedObjectIds.UnionWith(changeSet.Created.Select(v=>v.ObjectId));

            this.Objects = new HashSet<Object>(derivation.Session.Instantiate(changedObjectIds).Cast<Object>());
            this.Objects.ExceptWith(this.Iteration.Cycle.Derivation.DerivedObjects);

            if (marked != null)
            {
                this.Objects.UnionWith(marked);
            }

            this.PreDerived = new HashSet<Object>();
        }

        public Iteration Iteration { get; }

        public ISet<Object> Objects { get; set; }

        public ISet<Object> PreDerived { get; set; }

        public void Execute()
        {
            foreach (var @object in this.Objects)
            {
                if (!@object.Strategy.IsDeleted)
                {
                    @object.OnPreDerive(x => x.WithIteration(this.Iteration));
                    this.PreDerived.Add(@object);
                }
            }
        }
    }
}
