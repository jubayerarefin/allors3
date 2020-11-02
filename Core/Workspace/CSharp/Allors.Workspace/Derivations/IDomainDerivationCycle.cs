// <copyright file="IDomainDerivationCycle.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the IDomainDerivation type.</summary>

namespace Allors.Workspace.Derivations
{
    public interface IDomainDerivationCycle
    {
        ISession Session { get; }

        IChangeSet ChangeSet { get; }

        IDomainValidation Validation { get; }
    }
}
