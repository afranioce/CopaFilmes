using MovieCup.Domain.Models;
using MovieCup.Shared.Commands;
using System.Collections.Generic;

namespace MovieCup.Domain.Events
{
    public class CompetitionCompletedEvent : ICommandResult
    {
        public CompetitionCompletedEvent(List<Movie> ranking)
        {
            Ranking = ranking;
        }

        public List<Movie> Ranking { get; private set; }
    }
}
