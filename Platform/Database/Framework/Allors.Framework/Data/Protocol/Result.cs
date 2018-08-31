//------------------------------------------------------------------------------------------------- 
// <copyright file="Result.cs" company="Allors bvba">
// Copyright 2002-2017 Allors bvba.
// 
// Dual Licensed under
//   a) the Lesser General Public Licence v3 (LGPL)
//   b) the Allors License
// 
// The LGPL License is included in the file lgpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace Allors.Data.Protocol
{
    public class Result 
    {
        public string Name { get; set; }

        public Path Path { get; set; }

        public Tree Include { get; set; }

        public int? Skip { get; set; }

        public int? Take { get; set; }

        public Data.Result Load(ISession session)
        {
            var result = new Data.Result
            {
                Path = this.Path?.Load(session),
                Include = this.Include?.Load(session),
                Skip = this.Skip,
                Take = this.Take,
            };

            return result;
        }
    }
}