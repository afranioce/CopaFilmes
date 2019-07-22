using MovieCup.Domain.Interfaces;
using MovieCup.Domain.Models;
using MovieCup.Infra.Data.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCup.Infra.Data.Repository
{
    public class MovieRepository : Repository<Movie, string>, IMovieRepository
    {
        public async Task<IEnumerable<Movie>> GetByIdsAsync(string[] movieIds)
        {
            var movies = await GetAllAsync<MovieViewModel>("filmes");

            return movies
                .Where(movie => movieIds.Contains(movie.Id))
                .Select(movie => movie.ToDomain())
                .ToList();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var movies = await GetAllAsync<MovieViewModel>("filmes");
            return movies
                .Select(movie => movie.ToDomain())
                .ToList();
        }
    }
}
