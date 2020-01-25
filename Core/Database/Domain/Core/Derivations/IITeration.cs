// <copyright file="IValidation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System.Collections.Generic;

    public interface IIteration
    {
        IAccumulatedChangeSet ChangeSet { get; }

        object this[string name] { get; set; }

        ICycle Cycle { get; }

        IPreparation Preparation { get; }

        ISet<Object> Objects { get; }

        void Schedule(Object @object);

        void Mark(Object @object);

        void Mark(params Object[] objects);

        bool IsMarked(Object @object);

        /// <summary>
        /// The dependee is derived before the dependent object.
        /// </summary>
        /// <param name="dependent">The dependent object.</param>
        /// <param name="dependee">The dependee object.</param>
        void AddDependency(Object dependent, Object dependee);
    }
}
