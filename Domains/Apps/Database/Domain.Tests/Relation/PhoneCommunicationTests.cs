//------------------------------------------------------------------------------------------------- 
// <copyright file="PhoneCommunicationTests.cs" company="Allors bvba">
// Copyright 2002-2009 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// <summary>Defines the MediaTests type.</summary>
//-------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    using Xunit;

    
    public class PhoneCommunicationTests : DomainTest
    {
        [Fact]
        public void GivenPhoneCommunication_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var receiver = new PersonBuilder(this.DatabaseSession).WithLastName("receiver").Build();
            var caller = new PersonBuilder(this.DatabaseSession).WithLastName("caller").Build();
            var owner = new PersonBuilder(this.DatabaseSession).WithLastName("owner").Build();

            this.DatabaseSession.Derive();
            this.DatabaseSession.Commit();

            var builder = new PhoneCommunicationBuilder(this.DatabaseSession);
            var communication = builder.Build();

            this.DatabaseSession.Derive();
            Assert.True(communication.Strategy.IsDeleted);

            this.DatabaseSession.Rollback();

            builder.WithSubject("Phonecall");
            communication = builder.Build();

            this.DatabaseSession.Derive();
            Assert.True(communication.Strategy.IsDeleted);

            this.DatabaseSession.Rollback();

            builder.WithReceiver(receiver);
            builder.WithCaller(caller);
            communication = builder.Build();

            Assert.True(this.DatabaseSession.Derive().HasErrors);

            this.DatabaseSession.Rollback();

            builder.WithOwner(owner);
            communication = builder.Build();

            Assert.False(this.DatabaseSession.Derive().HasErrors);

            Assert.Equal(communication.CurrentCommunicationEventStatus.CommunicationEventObjectState, new CommunicationEventObjectStates(this.DatabaseSession).Scheduled);
            Assert.Equal(communication.CurrentObjectState, new CommunicationEventObjectStates(this.DatabaseSession).Scheduled);
            Assert.Equal(communication.CurrentObjectState, communication.LastObjectState);
        }

        [Fact]
        public void GivenPhoneCommunicationIsBuild_WhenDeriving_ThenStatusIsSet()
        {
            var communication = new PhoneCommunicationBuilder(this.DatabaseSession)
                .WithSubject("Hello world!")
                .WithOwner(new PersonBuilder(this.DatabaseSession).WithLastName("owner").Build())
                .WithCaller(new PersonBuilder(this.DatabaseSession).WithLastName("caller").Build())
                .WithReceiver(new PersonBuilder(this.DatabaseSession).WithLastName("receiver").Build())
                .Build();

            Assert.False(this.DatabaseSession.Derive().HasErrors);

            Assert.Equal(communication.CurrentCommunicationEventStatus.CommunicationEventObjectState, new CommunicationEventObjectStates(this.DatabaseSession).Scheduled);
            Assert.Equal(communication.CurrentObjectState, new CommunicationEventObjectStates(this.DatabaseSession).Scheduled);
            Assert.Equal(communication.CurrentObjectState, communication.LastObjectState);
        }

        [Fact]
        public void GivenPhoneCommunication_WhenDeriving_ThenInvolvedPartiesAreDerived()
        {
            var owner = new PersonBuilder(this.DatabaseSession).WithLastName("owner").Build();
            var caller = new PersonBuilder(this.DatabaseSession).WithLastName("caller").Build();
            var receiver = new PersonBuilder(this.DatabaseSession).WithLastName("receiver").Build();

            this.DatabaseSession.Derive(true);
            this.DatabaseSession.Commit();

            var communication = new PhoneCommunicationBuilder(this.DatabaseSession)
                .WithSubject("Hello world!")
                .WithOwner(owner)
                .WithCaller(caller)
                .WithReceiver(receiver)
                .Build();

            this.DatabaseSession.Derive(true);

            Assert.Equal(3, communication.InvolvedParties.Count);
            Assert.Contains(owner, communication.InvolvedParties);
            Assert.Contains(caller, communication.InvolvedParties);
            Assert.Contains(receiver, communication.InvolvedParties);
        }
    }
}