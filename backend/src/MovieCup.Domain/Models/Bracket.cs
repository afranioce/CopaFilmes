using System;
using System.Collections.Generic;
using src.MovieCup.Shared.Models;

namespace MovieCup.Domain.Models
{
    public class Bracket : Entity<Guid>
    {
        private readonly List<Match> _matches = new List<Match>();

        public Bracket(Guid id, int round)
        {
            Id = id;
            Round = round;
        }

        public int Round { get; private set; }
        public IReadOnlyCollection<Match> Matches => _matches;

        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }
    }
}
