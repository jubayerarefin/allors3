// <copyright file="RequirementSequence.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    public partial class RequirementSequence
    {
        public bool IsEnforcedSequence => Equals(this.UniqueId, RequirementSequences.EnforcedSequenceId);

        public bool IsRestartOnFiscalYear => Equals(this.UniqueId, RequirementSequences.RestartOnFiscalYearId);
    }
}
