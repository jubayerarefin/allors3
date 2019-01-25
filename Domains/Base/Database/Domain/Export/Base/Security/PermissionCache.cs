// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionCache.cs" company="Allors bvba">
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
    using System.Collections.Generic;
    using System.Linq;

    public class PermissionCache
    {
        public Dictionary<Guid, Dictionary<Guid, Dictionary<Operations, long>>> PermissionIdByOperationByOperandTypeIdByClassId { get; }

        public PermissionCache(ISession session)
        {
            var xxx = new Permissions(session).Extent()
                .GroupBy(v => v.ConcreteClass.Id).ToDictionary(v => v.Key,
                    w => w.GroupBy(v => v.OperandType.Id).ToDictionary(v => v.Key, x => x.ToArray()));



            this.PermissionIdByOperationByOperandTypeIdByClassId = new Permissions(session).Extent()
                .GroupBy(v => v.ConcreteClass.Id).ToDictionary(v => v.Key,
                    w => w.GroupBy(v => v.OperandType.Id).ToDictionary(v => v.Key, x =>
                        x.ToDictionary(v => v.Operation, y => y.Id)));
        }
    }
}