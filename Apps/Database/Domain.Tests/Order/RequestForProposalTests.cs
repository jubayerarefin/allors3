// <copyright file="OrderTermTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using System.Collections.Generic;
    using Allors.Database.Derivations;
    using Resources;
    using Xunit;

    public class RequestForProposalDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public RequestForProposalDerivationTests(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void ChangedRecipientDeriveValidationError()
        {
            var request = new RequestForProposalBuilder(this.Session).Build();
            this.Session.Derive(false);

            request.Recipient = new OrganisationBuilder(this.Session).WithIsInternalOrganisation(true).Build();

            var expectedMessage = $"{request} { this.M.RequestForProposal.Recipient} { ErrorMessages.InternalOrganisationChanged}";
            var errors = new List<IDerivationError>(this.Session.Derive(false).Errors);
            Assert.Contains(errors, e => e.Message.Equals(expectedMessage));
        }

        [Fact]
        public void ChangedRequestItemsDeriveRequestItemsSyncedRequest()
        {
            var request = new RequestForProposalBuilder(this.Session).Build();
            this.Session.Derive(false);

            var requestItem = new RequestItemBuilder(this.Session).Build();
            request.AddRequestItem(requestItem);
            this.Session.Derive(false);

            Assert.Equal(request, requestItem.SyncedRequest);
        }
    }

    [Trait("Category", "Security")]
    public class RequestForProposalDeniedPermissionDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public RequestForProposalDeniedPermissionDerivationTests(Fixture fixture) : base(fixture) => this.deletePermission = new Permissions(this.Session).Get(this.M.RequestForProposal.ObjectType, this.M.RequestForProposal.Delete);

        public override Config Config => new Config { SetupSecurity = true };

        private readonly Permission deletePermission;

        [Fact]
        public void OnChangedRequestForProposalStateCreatedDeriveDeletePermissionAllowed()
        {
            var request = new RequestForProposalBuilder(this.Session)
                .WithRequestState(new RequestStates(this.Session).Anonymous)
                .Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, request.DeniedPermissions);
        }

        [Fact]
        public void OnChangedRequestForProposalStateDeriveDeletePermission()
        {
            var request = new RequestForProposalBuilder(this.Session).Build();
            this.Session.Derive(false);

            request.RequestState = new RequestStates(this.Session).Submitted;
            this.Session.Derive(false);

            Assert.DoesNotContain(this.deletePermission, request.DeniedPermissions);
        }

        [Fact]
        public void OnChangedQuoteRequestDeriveDeletePermission()
        {
            var request = new RequestForProposalBuilder(this.Session).Build();
            this.Session.Derive(false);

            new ProductQuoteBuilder(this.Session).WithRequest(request).Build();
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, request.DeniedPermissions);
        }

        [Fact]
        public void OnChangedRequestItemsRequestItemStateDeriveDeletePermission()
        {
            var request = new RequestForProposalBuilder(this.Session)
                .WithRequestState(new RequestStates(this.Session).Submitted)
                .Build();
            this.Session.Derive(false);

            var requestItem = new RequestItemBuilder(this.Session).Build();
            request.AddRequestItem(requestItem);
            this.Session.Derive(false);

            Assert.DoesNotContain(this.deletePermission, request.DeniedPermissions);

            requestItem.RequestItemState = new RequestItemStates(this.Session).Quoted;
            this.Session.Derive(false);

            Assert.Contains(this.deletePermission, request.DeniedPermissions);
        }
    }
}
