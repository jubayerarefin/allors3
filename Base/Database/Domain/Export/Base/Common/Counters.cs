// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Counters.cs" company="Allors bvba">
//   Copyright 2002-2017 Allors bvba.
//
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
//
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
//
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    using System;

    using Allors;

    public partial class Counters
    {
        private UniquelyIdentifiableSticky<Counter> sticky;
        
        private UniquelyIdentifiableSticky<Counter> Sticky => this.sticky ?? (this.sticky = new UniquelyIdentifiableSticky<Counter>(this.Session));
        
        public static int NextValue(ISession session, Guid counterId)
        {
            using (var separateSession = session.Database.CreateSession())
            {
                var counter = new Counters(separateSession).Sticky[counterId];
                var newValue = counter.Value + 1;

                separateSession.Commit();

                counter.Value = newValue;
                return counter.Value;
            }
        }
    }
}