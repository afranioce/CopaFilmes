using MovieCup.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace MovieCup.Domain.Tests
{
    public class CompetitionTest
    {
        private List<Movie> _movies;

        public CompetitionTest()
        {
            _movies = new List<Movie>{
                new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5),
                new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7),
                new Movie("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3),
                new Movie("tt7784604", "Hereditário", 2018, 7.8),
                new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8),
                new Movie("tt5463162", "Deadpool 2", 2018, 8.1),
                new Movie("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2),
                new Movie("tt3501632", "Thor: Ragnarok", 2017, 7.9)
            };
        }

        [Fact]
        public void Sort_Movies()
        {
            // Arrange
            var competition = new Competition(8);
            competition.AddParticipants(_movies);

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
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddParticipants(_movies);

            // Act
            competition.NextRound();
            var winners = competition.GetWinnersOfRound(1);

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
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddParticipants(_movies);

            // Act
            competition.NextRound();
            competition.NextRound();
            var winners = competition.GetWinnersOfRound(2);

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", winners[0].Title);
            Assert.Equal("Os Incríveis 2", winners[1].Title);
        }

        [Fact]
        public void Winner_Three_Round()
        {
            // Arrange
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddParticipants(_movies);

            // Act
            competition.NextRound();
            competition.NextRound();
            competition.NextRound();
            var winners = competition.GetWinnersOfRound(2);

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", winners[0].Title);
        }
    }
}