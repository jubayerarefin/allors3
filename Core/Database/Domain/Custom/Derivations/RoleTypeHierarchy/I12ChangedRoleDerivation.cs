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

    public class I12ChangedRoleDerivation : DomainDerivation
    {
        public I12ChangedRoleDerivation(M m) : base(m, new Guid("48656EC9-5331-4AC6-B899-738D1983FD5F")) =>
            this.Patterns = new[]
            {
                new ChangedPattern(this.M.I12.ChangedRolePing)
            };


        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var s12 in matches.Cast<I12>())
            {
                s12.ChangedRolePong = s12.ChangedRolePing;
            }
        }
    }
}