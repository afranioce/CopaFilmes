using MovieCup.Domain.Commands;
using MovieCup.Domain.Events;
using MovieCup.Domain.Interfaces;
using MovieCup.Domain.Models;
using MovieCup.Domain.Validations;
using MovieCup.Shared.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCup.Domain.CommandHandlers
{
    public class CompetitionCommandHandler : ICommandHandler<NewCompetitionCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public CompetitionCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ICommandResult> Handler(NewCompetitionCommand command)
        {
            var movies = await _movieRepository.GetByIdsAsync(command.PlayerIds);

            var competition = new Competition(Guid.NewGuid(), command.NumberOfPlayers);
            competition.AddPlayers(movies.ToList());

            var validator = new CompetitionValidator();
            var validateResult = validator.Validate(competition);
            if (!validateResult.IsValid)
            {
                return new ValidationFailureEvent(validateResult.Errors);
            }

            competition.Start();
            var ranking = competition.GetBracketByRound(competition.NumberOfRounds).Ranking;

            return new CompetitionCompletedEvent(ranking.ToList());
        }
    }
}
