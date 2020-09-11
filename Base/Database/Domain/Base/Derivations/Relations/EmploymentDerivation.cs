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

    public class EmploymentDerivation : IDomainDerivation
    {
        public Guid Id => new Guid("F0587A19-E7CF-40FF-B715-5A6021525326");

        public IEnumerable<Pattern> Patterns { get; } = new Pattern[]
        {
            new CreatedPattern(M.Employment.Class),
        };

        public void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var employment in matches.Cast<Employment>())
            {
                employment.Parties = new Party[] { employment.Employee, employment.Employer };
            }
        }
    }
}