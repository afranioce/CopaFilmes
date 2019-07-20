using MovieCup.Domain.Commands;
using MovieCup.Domain.Events;
using MovieCup.Domain.Models;
using MovieCup.Shared.Commands;
using System;

namespace MovieCup.Domain.CommandHandlers
{
    class CompetitionCommandHandler
        : ICommandHandler<NewCompetitionCommand>
    {
        public ICommandResult Handle(NewCompetitionCommand command)
        {
            var competition = new Competition(Guid.NewGuid(), 8);
            competition.AddParticipants(_movies);

            return new CompetitionCompletedEvent();
        }
    }
}
