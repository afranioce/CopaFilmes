using FluentValidation;
using MovieCup.Domain.Models;

namespace MovieCup.Domain.Validations
{
    class NewCompetitionCommandValidation : AbstractValidator<Competition>
    {
        public NewCompetitionCommandValidation()
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
