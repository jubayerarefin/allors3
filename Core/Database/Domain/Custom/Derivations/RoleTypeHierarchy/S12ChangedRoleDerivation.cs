// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Meta;

    public class S12ChangedRoleDerivation : DomainDerivation
    {
        public S12ChangedRoleDerivation(M m) : base(m, new Guid("475E8B38-21BB-40F9-AD67-9A7432F73CDD")) =>
            this.Patterns = new[]
            {
                new ChangedPattern(this.M.S12.ChangedRolePing)
            };


        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var s12 in matches.Cast<S12>())
            {
                s12.ChangedRolePong = s12.ChangedRolePing;
            }
        }
    }
}