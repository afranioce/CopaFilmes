using FluentValidation;
using MovieCup.Domain.Models;

namespace MovieCup.Domain.Validations
{
    class CompetitionValidator : AbstractValidator<Competition>
    {
        public CompetitionValidator()
        {
            ValidatePlayers();
        }

        public void ValidatePlayers()
        {
            RuleFor(x => x.Players)
                .Must((competition, players) => players.Count == competition.NumberOfPlayers);
        }
    }
}
