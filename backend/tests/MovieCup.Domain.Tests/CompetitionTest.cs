using MovieCup.Domain.Enums;
using MovieCup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MovieCup.Domain.Tests
{
    public class CompetitionTest : IClassFixture<CompetitionFixture>
    {
        private readonly CompetitionFixture _fixture;

        public CompetitionTest(CompetitionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Sort_Movies()
        {
            // Arrange
            var players = _fixture.GetMovies();
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddPlayers(players);

            // Act
            var movies = competition.SortPlayersByTitle();

            // Assert
            Assert.Equal("Deadpool 2", movies[0].Title);
            Assert.Equal("Han Solo: Uma História Star Wars", movies[1].Title);
            Assert.Equal("Hereditário", movies[2].Title);
            Assert.Equal("Jurassic World: Reino Ameaçado", movies[3].Title);
            Assert.Equal("Oito Mulheres e um Segredo", movies[4].Title);
            Assert.Equal("Os Incríveis 2", movies[5].Title);
            Assert.Equal("Thor: Ragnarok", movies[6].Title);
            Assert.Equal("Vingadores: Guerra Infinita", movies[7].Title);
        }

        [Fact]
        public void Winner_First_Round()
        {
            // Arrange
            var players = _fixture.GetMovies();
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddPlayers(players);

            // Act
            competition.Start();
            var winners = competition.GetBracketByRound(1).GetWinners();

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", winners[0].Title);
            Assert.Equal("Thor: Ragnarok", winners[1].Title);
            Assert.Equal("Os Incríveis 2", winners[2].Title);
            Assert.Equal("Jurassic World: Reino Ameaçado", winners[3].Title);
        }

        [Fact]
        public void Winner_Second_Round()
        {
            // Arrange
            var players = _fixture.GetMovies();
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddPlayers(players);

            // Act
            competition.Start();
            var winners = competition.GetBracketByRound(2).GetWinners();

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", winners[0].Title);
            Assert.Equal("Os Incríveis 2", winners[1].Title);
        }

        [Fact]
        public void Winner_Three_Round()
        {
            // Arrange
            var players = _fixture.GetMovies();
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddPlayers(players);

            // Act
            competition.Start();
            var winners = competition.GetBracketByRound(3).GetWinners();

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", winners[0].Title);
        }

        [Fact]
        public void Classification_Last_Round()
        {
            // Arrange
            var players = _fixture.GetMovies();
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddPlayers(players);

            // Act
            competition.Start();
            var ranking = competition.GetBracketByRound(3).Ranking.ToList();

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", ranking[0].Title);
            Assert.Equal("Os Incríveis 2", ranking[1].Title);
        }
    }
}