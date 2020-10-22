// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Domain.Derivations;
    using Allors.Meta;

    public class PartyContactMechanismDerivation : DomainDerivation
    {
        public PartyContactMechanismDerivation(M m) : base(m, new Guid("7C4E6217-8D71-4544-B8E4-8B2C51F6A5C1")) =>
            this.Patterns = new Pattern[]
            {
                new CreatedPattern(this.M.PartyContactMechanism.Class),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var partyContactMechanism in matches.Cast<PartyContactMechanism>())
            {
                if (partyContactMechanism.ExistUseAsDefault && partyContactMechanism.UseAsDefault)
                {
                    cycle.Validation.AssertExists(partyContactMechanism, this.M.PartyContactMechanism.ContactPurposes);
                }

                if (partyContactMechanism.UseAsDefault && partyContactMechanism.ExistPartyWherePartyContactMechanism && partyContactMechanism.ExistContactPurposes)
                {
                    foreach (var contactMechanismPurpose in partyContactMechanism.ContactPurposes)
                    {
                        var partyContactMechanisms = partyContactMechanism.PartyWherePartyContactMechanism.PartyContactMechanisms;
                        partyContactMechanisms.Filter.AddContains(this.M.PartyContactMechanism.ContactPurposes, (IObject)contactMechanismPurpose);

                        foreach (PartyContactMechanism partyContactMechanismFromOrganisationWherePartyContactMechanism in partyContactMechanisms)
                        {
                            if (!partyContactMechanismFromOrganisationWherePartyContactMechanism.Equals(partyContactMechanism))
                            {
                                partyContactMechanismFromOrganisationWherePartyContactMechanism.UseAsDefault = false;
                            }
                        }
                    }
                }
            }
        }
    }
}