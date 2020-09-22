// <copyright file="SingletonTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Domain
{
    using Allors.Meta;
    using Resources;
    using Xunit;

    public class SingletonTests : DomainTest
    {
        [Fact]
        public void GivenGeneralLedgerAccount_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            //TODO: NotificationConfirm that it works
            var singleton = this.Session.GetSingleton();
            Assert.True(singleton.ExistLogoImage);
            Assert.Contains(singleton.DefaultLocale, singleton.Locales);
        }
    }
}
