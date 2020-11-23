// <copyright file="Sort.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Data
{
    using Meta;

    public class Sort : IVisitable
    {
        public Sort(IRoleType roleType = null) => this.RoleType = roleType;

        public IRoleType RoleType { get; set; }

        public bool Descending { get; set; }

        public void Build(Database.Extent extent) => extent.AddSort(this.RoleType, this.Descending ? SortDirection.Descending : SortDirection.Ascending);

        public void Accept(IVisitor visitor) => visitor.VisitSort(this);
    }
}
