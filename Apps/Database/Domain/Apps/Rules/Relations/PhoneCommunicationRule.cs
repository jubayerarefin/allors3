// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;
    using Database.Derivations;

    public class PhoneCommunicationRule : Rule
    {
        public PhoneCommunicationRule(M m) : base(m, new Guid("6C8EB5C8-1E8C-41CF-B127-53C88E200F65")) =>
            this.Patterns = new Pattern[]
            {
                new RolePattern(m.PhoneCommunication, m.PhoneCommunication.Subject),
                new RolePattern(m.PhoneCommunication, m.PhoneCommunication.ToParty),
                new RolePattern(m.Party, m.Party.PartyName) { Steps = new IPropertyType[] { m.Party.CommunicationEventsWhereToParty}, OfType = m.PhoneCommunication.Class },
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (var @this in matches.Cast<PhoneCommunication>())
            {
                @this.WorkItemDescription = $"Call to {@this.ToParty?.PartyName} about {@this.Subject}";
            }
        }
    }
}