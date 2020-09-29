// <copyright file="Intersect.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Workspace.Data
{
    using System.Linq;
    using Allors.Protocol.Data;
    using Allors.Workspace.Meta;

    public class Intersect : IExtentOperator
    {
        public Intersect(params IExtent[] operands) => this.Operands = operands;

        public IComposite ObjectType => this.Operands?[0].ObjectType;

        public IExtent[] Operands { get; set; }

        public Sort[] Sorting { get; set; }

        public Protocol.Data.Extent ToJson() =>
            new Protocol.Data.Extent
            {
                Kind = ExtentKind.Intersect,
                Operands = this.Operands.Select(v => v.ToJson()).ToArray(),
                Sorting = this.Sorting.Select(v => new Protocol.Data.Sort { Descending = v.Descending, RoleType = v.RoleType?.RelationType.Id }).ToArray(),
            };
    }
}
