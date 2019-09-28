// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrandBuilderExtensions.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Domain.End2End
{
    public static partial class BrandBuilderExtensions
    {
        public static BrandBuilder WithDefaults(this BrandBuilder @this, ISession session, Config config)
        {
            if (config.End2End)
            {
                @this.WithName(config.faker.Lorem.Word());
                @this.WithLogoImage(new MediaBuilder(session).WithInDataUri(config.faker.Image.PicsumUrl(width: 200, height: 56)).Build());
                @this.WithModel(new ModelBuilder(session).WithName(config.faker.Lorem.Word()).Build());
                @this.WithModel(new ModelBuilder(session).WithName(config.faker.Lorem.Word()).Build());
                @this.WithModel(new ModelBuilder(session).WithName(config.faker.Lorem.Word()).Build());
            }

            return @this;
        }
    }
}
