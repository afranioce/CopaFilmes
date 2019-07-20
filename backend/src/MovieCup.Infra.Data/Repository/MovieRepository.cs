using MovieCup.Domain.Interfaces;
using MovieCup.Domain.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MovieCup.Infra.Data.Repository
{
    class MovieRepository : Repository<Movie, string>, IMovieRepository
    {

        public async Task<Movie> GetUserAsync(int userId)
        {
            var userJson = await GetStringAsync("users/" + userId);
            var user = JsonConvert.DeserializeObject<Movie>(userJson);
            return user;
        }
    }
}
