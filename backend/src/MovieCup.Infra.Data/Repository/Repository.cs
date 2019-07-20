using MovieCup.Shared.Interfaces;
using src.MovieCup.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieCup.Infra.Data.Repository
{
    public abstract class Repository<TEntity, TType> : IRepository<TEntity, TType> where TEntity : IEntity<TType>
    {
        protected static string baseUrl = "https://example.com/api/";

        protected static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(baseUrl + url);
            }
        }
    }
}
