using Microsoft.AspNetCore.Mvc;
using MovieCup.Api.ViewModel;
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
        public async Task<IActionResult> Post([FromBody] NewCompetitionViewModel newCompetition)
        {
            var competitionCommand = new NewCompetitionCommand(newCompetition.PlayerIds, newCompetition.NumberOfPlayers);
            var result = await _competitionCommandHandler.Handler(competitionCommand);
            return Response(result);
        }
    }
}
