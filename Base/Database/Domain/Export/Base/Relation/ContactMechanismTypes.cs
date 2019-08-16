
// <copyright file="ContactMechanismTypes.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;

    public partial class ContactMechanismTypes
    {
        private static readonly Guid PhoneId = new Guid("443EE069-2975-4FA3-88DF-C243171379FD");
        private static readonly Guid MobilePhoneId = new Guid("CFA76E30-42A9-46A6-8D0F-A3D1D7907743");
        private static readonly Guid FaxId = new Guid("7AC12B75-061D-4249-862B-49C38CD233DF");

        private UniquelyIdentifiableSticky<ContactMechanismType> cache;

        public ContactMechanismType Phone => this.Cache[PhoneId];

        public ContactMechanismType MobilePhone => this.Cache[MobilePhoneId];

        public ContactMechanismType Fax => this.Cache[FaxId];

        private UniquelyIdentifiableSticky<ContactMechanismType> Cache => this.cache ?? (this.cache = new UniquelyIdentifiableSticky<ContactMechanismType>(this.Session));

        protected override void BaseSetup(Setup setup)
        {
            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            new ContactMechanismTypeBuilder(this.Session)
                .WithName("Phone")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Telefoon").WithLocale(dutchLocale).Build())
                .WithUniqueId(PhoneId)
                .WithIsActive(true)
                .Build();

            new ContactMechanismTypeBuilder(this.Session)
                .WithName("Mobile Phone")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Mobiel").WithLocale(dutchLocale).Build())
                .WithUniqueId(MobilePhoneId)
                .WithIsActive(true)
                .Build();

            new ContactMechanismTypeBuilder(this.Session)
                .WithName("Fax")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Fax").WithLocale(dutchLocale).Build())
                .WithUniqueId(FaxId)
                .WithIsActive(true)
                .Build();
        }
    }
}
