using Microsoft.AspNetCore.Mvc;
using MovieCup.Domain.Interfaces;
using System.Threading.Tasks;

namespace MovieCup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : BaseController
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _movieRepository.GetAllAsync();
            return Response(result);
        }
    }
}