// <copyright file="Except.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Allors.Meta;
    using Allors.Protocol.Data;

    public class Except : IExtentOperator
    {
        public Except(params IExtent[] operands) => this.Operands = operands;

        public IComposite ObjectType => this.Operands?[0].ObjectType;

        public IExtent[] Operands { get; set; }

        public Sort[] Sorting { get; set; }

        public Extent Save() =>
            new Extent
            {
                Kind = ExtentKind.Except,
                Operands = this.Operands.Select(v => v.Save()).ToArray(),
                Sorting = this.Sorting.Select(v => new Protocol.Data.Sort { Descending = v.Descending, RoleType = v.RoleType?.Id }).ToArray(),
            };

        bool IExtent.HasMissingArguments(IReadOnlyDictionary<string, object> arguments) => this.Operands.Any(v => v.HasMissingArguments(arguments));

        Allors.Extent IExtent.Build(ISession session, IReadOnlyDictionary<string, object> arguments)
        {
            var extent = session.Except(this.Operands[0].Build(session, arguments), this.Operands[1].Build(session, arguments));
            foreach (var sort in this.Sorting)
            {
                sort.Build(extent);
            }

            return extent;
        }
    }
}