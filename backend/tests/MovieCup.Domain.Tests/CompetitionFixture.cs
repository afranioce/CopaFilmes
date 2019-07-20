using Moq;
using Moq.AutoMock;
using MovieCup.Domain.CommandHandlers;
using MovieCup.Domain.Interfaces;
using MovieCup.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCup.Domain.Tests
{
    public class CompetitionFixture
    {
        public Mock<IMovieRepository> MovieRepositoryMock { get; set; }

        public CompetitionCommandHandler GetCompetitionCommandHandler()
        {
            var mocker = new AutoMocker();
            MovieRepositoryMock = mocker.GetMock<IMovieRepository>();

            return mocker.CreateInstance<CompetitionCommandHandler>();
        }

        public List<Movie> GetMovies()
        {
            return new List<Movie>{
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

        public Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var movies = GetMovies().AsEnumerable();
            return Task.FromResult(movies);
        }
    }
}
