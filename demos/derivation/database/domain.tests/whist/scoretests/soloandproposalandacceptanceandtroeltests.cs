// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain.Tests.Whist.Score
{
    using System.Linq;
    using Xunit;

    public class SoloAndProposalAndAcceptanceAndTroelTests : DomainTest, IClassFixture<Fixture>
    {
        private Scoreboard scoreboard;
        private Person player1;
        private Person player2;
        private Person player3;
        private Person player4;

        private GameModes GameModes;

        public SoloAndProposalAndAcceptanceAndTroelTests(Fixture fixture) : base(fixture)
        {
            var people = new People(this.Transaction);

            this.player1 = people.FindBy(M.Person.UserName, "player1");
            this.player2 = people.FindBy(M.Person.UserName, "player2");
            this.player3 = people.FindBy(M.Person.UserName, "player3");
            this.player4 = people.FindBy(M.Person.UserName, "player4");

            this.scoreboard = new ScoreboardBuilder(this.Transaction)
                .WithPlayer(player1)
                .WithPlayer(player2)
                .WithPlayer(player3)
                .WithPlayer(player4)
                .Build();

            this.GameModes = new GameModes(this.Transaction);

            this.Transaction.Derive();
        }
        
        [Fact]
        public void TestSoloWithOneDeclarerAndNoWinnerAndNoTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.Solo;
            game.AddDeclarer(player1);

            this.Transaction.Derive();

            //Assert
            Assert.Equal(-6, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(2, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(2, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(2, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestSoloWithOneDeclarerAndNoWinnerAndTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.Solo;
            game.AddDeclarer(player1);
            game.ExtraTricks = 3;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(-15, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(5, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(5, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(5, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestSoloWithOneDeclarerAndOneWinnerAndNoTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.Solo;
            game.AddDeclarer(player1);
            game.AddWinner(player1);

            this.Transaction.Derive();

            //Assert
            Assert.Equal(6, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(-2, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-2, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-2, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestSoloWithOneDeclarerAndOneWinnerAndTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.Solo;
            game.AddDeclarer(player1);
            game.AddWinner(player1);
            game.ExtraTricks = 3;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(15, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(-5, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-5, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-5, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestSoloWithOneDeclarerAndOneWinnerAndAllTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.Solo;
            game.AddDeclarer(player1);
            game.AddWinner(player1);
            game.ExtraTricks = 8;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(60, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(-20, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-20, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-20, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestProposalAndAcceptanceWithTwoDeclarersAndNoWinnersAndNoTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.ProposalAndAcceptance;
            game.AddDeclarer(player1);
            game.AddDeclarer(player2);

            this.Transaction.Derive();

            //Assert
            Assert.Equal(-2, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(-2, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(2, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(2, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestProposalAndAcceptanceWithTwoDeclarersAndNoWinnersAndTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.ProposalAndAcceptance;
            game.AddDeclarer(player1);
            game.AddDeclarer(player2);

            game.ExtraTricks = 3;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(-5, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(-5, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(5, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(5, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestProposalAndAcceptanceWithTwoDeclarersAndTwoWinnersAndNoTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.ProposalAndAcceptance;
            game.AddDeclarer(player1);
            game.AddDeclarer(player2);

            game.AddWinner(player1);
            game.AddWinner(player2);

            this.Transaction.Derive();

            //Assert
            Assert.Equal(2, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(2, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-2, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-2, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestProposalAndAcceptanceWithTwoDeclarersAndTwoWinnersAndTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.ProposalAndAcceptance;
            game.AddDeclarer(player1);
            game.AddDeclarer(player2);

            game.AddWinner(player1);
            game.AddWinner(player2);

            game.ExtraTricks = 3;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(5, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(5, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-5, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-5, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestProposalAndAcceptanceWithTwoDeclarersAndTwoWinnersAndAllTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.ProposalAndAcceptance;
            game.AddDeclarer(player1);
            game.AddDeclarer(player2);

            game.AddWinner(player1);
            game.AddWinner(player2);

            game.ExtraTricks = 5;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(14, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(14, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-14, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-14, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestTrullWithTwoDeclarersAndTwoWinnersAndAllTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.Trull;
            game.AddDeclarer(player1);
            game.AddDeclarer(player2);

            game.AddWinner(player1);
            game.AddWinner(player2);

            game.ExtraTricks = 5;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(28, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(28, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-28, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-28, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }

        [Fact]
        public void TestTrullWithTwoDeclarersAndTwoWinnersAndTricks()
        {
            //Arrange
            var game = new GameBuilder(this.Transaction).Build();
            scoreboard.AddGame(game);

            game.StartDate = this.Transaction.Now();
            game.EndDate = game.StartDate.Value.AddHours(1);

            //Act
            game.GameMode = this.GameModes.Trull;
            game.AddDeclarer(player1);
            game.AddDeclarer(player2);

            game.AddWinner(player1);
            game.AddWinner(player2);

            game.ExtraTricks = 3;

            this.Transaction.Derive();

            //Assert
            Assert.Equal(10, game.Scores.First(v => v.Player == player1).Value);
            Assert.Equal(10, game.Scores.First(v => v.Player == player2).Value);
            Assert.Equal(-10, game.Scores.First(v => v.Player == player3).Value);
            Assert.Equal(-10, game.Scores.First(v => v.Player == player4).Value);
            Assert.True(this.scoreboard.ZeroTest());
        }
    }
}
