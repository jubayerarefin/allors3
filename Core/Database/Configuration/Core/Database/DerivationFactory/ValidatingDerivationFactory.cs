// <copyright file="DefaultDerivationFactory.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Configuration
{
    using Database;
    using Domain;
    using Domain.Derivations.Validating;

    public class ValidatingDerivationFactory : IDerivationFactory
    {
        public IDerivation CreateDerivation(ISession session) => new ValidatingDerivation(session);
    }
}