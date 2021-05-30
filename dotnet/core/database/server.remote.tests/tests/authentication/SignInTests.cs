// <copyright file="SignInTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Server.Tests
{
    using System;

    using Database.Domain;
    using Protocol.Json.Auth;
    using Xunit;

    [Collection("Api")]

    public class SignInTests : ApiTest
    {
        public SignInTests()
        {
            _ = new PersonBuilder(this.Transaction).WithUserName("John").Build();
            _ = new PersonBuilder(this.Transaction).WithUserName("Jane").Build().SetPassword("p@ssw0rd");
            _ = this.Transaction.Derive();
            this.Transaction.Commit();
        }

        [Fact]
        public async void CorrectUserAndPassword()
        {
            var args = new AuthenticationTokenRequest
            {
                Login = "Jane",
                Password = "p@ssw0rd",
            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var siginInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.True(siginInResponse.Authenticated);
        }

        [Fact]
        public async void NonExistingUser()
        {
            var args = new AuthenticationTokenRequest
            {
                Login = "Jeff",
                Password = "p@ssw0rd",
            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var siginInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.False(siginInResponse.Authenticated);
        }

        [Fact]
        public async void EmptyStringPassword()
        {
            var args = new AuthenticationTokenRequest
            {
                Login = "John",
                Password = "",
            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var siginInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.False(siginInResponse.Authenticated);
        }

        [Fact]
        public async void NoPassword()
        {
            var args = new AuthenticationTokenRequest
            {
                Login = "John",
            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var signInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.False(signInResponse.Authenticated);
        }
    }
}