// <copyright file="RequestAnonymousDerivation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Derivations;
    using Meta;

    public class RequestAnonymousDerivation : DomainDerivation
    {
        public RequestAnonymousDerivation(M m) : base(m, new Guid("c4e0b3b7-681d-46ba-8382-4a78a2e361e1")) =>
            this.Patterns = new Pattern[]
            {
                new ChangedPattern(this.M.Request.Originator),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var session = cycle.Session;

            foreach (var @this in matches.Cast<Request>().Where(v => v.RequestState.IsAnonymous))
            {
                if (@this.ExistOriginator)
                {
                    @this.RequestState = new RequestStates(session).Submitted;

                    if (@this.ExistEmailAddress
                        && @this.Originator.PartyContactMechanisms.Where(v => v.ContactMechanism.GetType().Name == typeof(EmailAddress).Name).FirstOrDefault(v => ((EmailAddress)v.ContactMechanism).ElectronicAddressString.Equals(@this.EmailAddress)) == null)
                    {
                        @this.Originator.AddPartyContactMechanism(
                            new PartyContactMechanismBuilder(session)
                                .WithContactMechanism(new EmailAddressBuilder(session).WithElectronicAddressString(@this.EmailAddress).Build())
                                .WithContactPurpose(new ContactMechanismPurposes(session).GeneralEmail)
                                .Build());
                    }

                    if (@this.ExistTelephoneNumber
                        && @this.Originator.PartyContactMechanisms.Where(v => v.ContactMechanism.GetType().Name == typeof(TelecommunicationsNumber).Name).FirstOrDefault(v => ((TelecommunicationsNumber)v.ContactMechanism).ContactNumber.Equals(@this.TelephoneNumber)) == null)
                    {
                        @this.Originator.AddPartyContactMechanism(
                            new PartyContactMechanismBuilder(session)
                                .WithContactMechanism(new TelecommunicationsNumberBuilder(session).WithContactNumber(@this.TelephoneNumber).WithCountryCode(@this.TelephoneCountryCode).Build())
                                .WithContactPurpose(new ContactMechanismPurposes(session).GeneralPhoneNumber)
                                .Build());
                    }
                }
            }
        }
    }
}