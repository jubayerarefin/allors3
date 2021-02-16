// <copyright file="IExtent.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Data
{
    using System.Collections.Generic;
    using Meta;

    public interface IExtent : IVisitable
    {
        IComposite ObjectType { get; }

        Sort[] Sorting { get; set; }

        Database.Extent Build(ITransaction transaction, IDictionary<string, string> parameters = null);

        bool HasMissingArguments(IDictionary<string, string> parameters);
    }
}
