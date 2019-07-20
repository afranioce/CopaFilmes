using Microsoft.AspNetCore.Mvc;
using MovieCup.Domain.Commands;
using MovieCup.Shared.Commands;
using System.Threading.Tasks;

namespace MovieCup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : BaseController
    {
        private readonly ICommandHandler<NewCompetitionCommand> _competitionCommandHandler;

        public CompetitionsController(ICommandHandler<NewCompetitionCommand> competitionCommandHandler)
        {
            _competitionCommandHandler = competitionCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewCompetitionCommand newCompetitionCommand)
        {
            var result = await _competitionCommandHandler.Handler(newCompetitionCommand);
            return Response(result);
        }
    }
}
