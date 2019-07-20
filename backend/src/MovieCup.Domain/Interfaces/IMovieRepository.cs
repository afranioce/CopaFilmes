using MovieCup.Domain.Models;
using MovieCup.Shared.Interfaces;

namespace MovieCup.Domain.Interfaces
{
    public interface IMovieRepository : IRepository<Movie, string>
    {
    }
}
