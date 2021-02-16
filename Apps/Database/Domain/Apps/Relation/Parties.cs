// <copyright file="Parties.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    public partial class Parties
    {
        public static void Daily(ITransaction transaction)
        {
            var parties = new Parties(transaction).Extent();

            foreach (Party party in parties)
            {
                party.DeriveRelationships();
            }
        }

        protected override void AppsPrepare(Setup setup)
        {
            setup.AddDependency(this.ObjectType, this.M.ContactMechanismPurpose);
            setup.AddDependency(this.ObjectType, this.M.Settings);
        }
    }
}
