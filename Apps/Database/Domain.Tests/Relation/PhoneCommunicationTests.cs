// <copyright file="PhoneCommunicationTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MediaTests type.</summary>

namespace Allors.Database.Domain.Tests
{
    using Xunit;

    public class PhoneCommunicationTests : DomainTest, IClassFixture<Fixture>
    {
        public PhoneCommunicationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void GivenPhoneCommunication_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var receiver = new PersonBuilder(this.Transaction).WithLastName("receiver").Build();
            var caller = new PersonBuilder(this.Transaction).WithLastName("caller").Build();

            this.Transaction.Derive();
            this.Transaction.Commit();

            var builder = new PhoneCommunicationBuilder(this.Transaction);
            builder.WithToParty(receiver);
            builder.WithFromParty(caller);
            builder.Build();

            Assert.True(this.Transaction.Derive(false).HasErrors);
            this.Transaction.Rollback();

            builder.WithSubject("Phonecall");
            var communication = builder.Build();

            Assert.False(this.Transaction.Derive(false).HasErrors);

            Assert.Equal(communication.CommunicationEventState, new CommunicationEventStates(this.Transaction).Scheduled);
            Assert.Equal(communication.CommunicationEventState, communication.LastCommunicationEventState);
        }

        [Fact]
        public void GivenPhoneCommunicationIsBuild_WhenDeriving_ThenStatusIsSet()
        {
            var communication = new PhoneCommunicationBuilder(this.Transaction)
                .WithSubject("Hello world!")
                .WithOwner(new PersonBuilder(this.Transaction).WithLastName("owner").Build())
                .WithFromParty(new PersonBuilder(this.Transaction).WithLastName("caller").Build())
                .WithToParty(new PersonBuilder(this.Transaction).WithLastName("receiver").Build())
                .Build();

            Assert.False(this.Transaction.Derive(false).HasErrors);

            Assert.Equal(communication.CommunicationEventState, new CommunicationEventStates(this.Transaction).Scheduled);
            Assert.Equal(communication.CommunicationEventState, communication.LastCommunicationEventState);
        }

        [Fact]
        public void GivenPhoneCommunication_WhenDeriving_ThenInvolvedPartiesAreDerived()
        {
            var owner = new PersonBuilder(this.Transaction).WithLastName("owner").Build();
            var caller = new PersonBuilder(this.Transaction).WithLastName("caller").Build();
            var receiver = new PersonBuilder(this.Transaction).WithLastName("receiver").Build();

            this.Transaction.Derive();
            this.Transaction.Commit();

            var communication = new PhoneCommunicationBuilder(this.Transaction)
                .WithSubject("Hello world!")
                .WithOwner(owner)
                .WithFromParty(caller)
                .WithToParty(receiver)
                .Build();

            this.Transaction.Derive();

            Assert.Equal(3, communication.InvolvedParties.Count);
            Assert.Contains(owner, communication.InvolvedParties);
            Assert.Contains(caller, communication.InvolvedParties);
            Assert.Contains(receiver, communication.InvolvedParties);
        }

        [Fact]
        public void GivenPhoneCommunication_WhenCallerIsDeleted_ThenCommunicationEventIsDeleted()
        {
            var owner = new PersonBuilder(this.Transaction).WithLastName("owner").Build();
            var originator = new PersonBuilder(this.Transaction).WithLastName("originator").Build();
            var receiver = new PersonBuilder(this.Transaction).WithLastName("receiver").Build();

            this.Transaction.Derive();
            this.Transaction.Commit();

            new PhoneCommunicationBuilder(this.Transaction)
                .WithSubject("Hello world!")
                .WithOwner(owner)
                .WithFromParty(originator)
                .WithToParty(receiver)
                .Build();

            this.Transaction.Derive();

            Assert.Single(this.Transaction.Extent<PhoneCommunication>());

            originator.Delete();
            this.Transaction.Derive();

            Assert.Empty(this.Transaction.Extent<PhoneCommunication>());
        }
    }

    public class PhoneCommunicationDerivationTests : DomainTest, IClassFixture<Fixture>
    {
        public PhoneCommunicationDerivationTests(Fixture fixture) : base(fixture) { }

        [Fact]
        public void ChangedSubjectDeriveWorkItemDescription()
        {
            var communication = new PhoneCommunicationBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            communication.Subject = "subject";
            this.Transaction.Derive(false);

            Assert.Contains("subject", communication.WorkItemDescription);
        }

        [Fact]
        public void ChangedToPartyDeriveWorkItemDescription()
        {
            var communication = new PhoneCommunicationBuilder(this.Transaction).Build();
            this.Transaction.Derive(false);

            var person = new PersonBuilder(this.Transaction).WithLastName("person").Build();
            this.Transaction.Derive(false);

            communication.ToParty = person;
            this.Transaction.Derive(false);

            Assert.Contains("person", communication.WorkItemDescription);
        }

        [Fact]
        public void ChangedPartyPartyNameDeriveWorkItemDescription()
        {
            var person = new PersonBuilder(this.Transaction).WithLastName("person").Build();
            this.Transaction.Derive(false);

            var communication = new PhoneCommunicationBuilder(this.Transaction).WithToParty(person).Build();
            this.Transaction.Derive(false);

            person.LastName = "changed";
            this.Transaction.Derive(false);

            Assert.Contains("changed", communication.WorkItemDescription);
        }
    }

}
