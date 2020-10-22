// <copyright file="Step.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Data
{
    using System;

    public class Step
    {
        public Guid? AssociationType { get; set; }

        public Guid? RoleType { get; set; }

        public Step Next { get; set; }

        public Node[] Include { get; set; }
    }
}