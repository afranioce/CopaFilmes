using MovieCup.Shared.Interfaces;
using Newtonsoft.Json;
using src.MovieCup.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieCup.Infra.Data.Repository
{
    public abstract class Repository<TEntity, TType> : IRepository<TEntity, TType> where TEntity : IEntity<TType>
    {
        private static readonly string _baseUrl = "https://copadosfilmes.azurewebsites.net/api/";

        protected static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        protected async Task<IEnumerable<T>> GetAllAsync<T>(string url)
        {
            var movieJson = await GetStringAsync(_baseUrl + url);
            return JsonConvert.DeserializeObject<List<T>>(movieJson);
        }
    }
}
