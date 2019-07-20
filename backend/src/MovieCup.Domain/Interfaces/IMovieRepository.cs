using MovieCup.Domain.Models;
using MovieCup.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCup.Domain.Interfaces
{
    public interface IMovieRepository : IRepository<Movie, string>
    {
        Task<IEnumerable<Movie>> GetByIdsAsync(string[] movieIds);
        Task<IEnumerable<Movie>> GetAllAsync();
    }
}
