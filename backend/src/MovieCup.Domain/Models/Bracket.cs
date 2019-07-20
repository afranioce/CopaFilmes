using MovieCup.Domain.Enums;
using src.MovieCup.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieCup.Domain.Models
{
    public class Bracket : Entity<Guid>
    {
        private readonly List<Match> _matches = new List<Match>();
        private readonly List<Movie> _ranking = new List<Movie>();

        public Bracket(Guid id, int round)
        {
            Id = id;
            Round = round;
        }

        public int Round { get; private set; }
        public IReadOnlyCollection<Match> Matches => _matches;
        public IReadOnlyCollection<Movie> Ranking => _ranking;

        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }

        public IReadOnlyCollection<Match> Complete()
        {
            foreach (Match match in Matches)
            {
                if (match.Winner != MatchWinner.Unknown)
                    continue;
                match.Play();
                PopulateRanking(match);
            }
            return Matches;
        }

        public List<Movie> GetWinners()
        {
            return Matches
                .Where(match => match.Winner != MatchWinner.Unknown)
                .Select(match => match.Winner == MatchWinner.FirstPlayer ? match.First : match.Second)
                .ToList();
        }

        private void PopulateRanking(Match match)
        {
            if (match.Winner == MatchWinner.FirstPlayer)
            {
                _ranking.Add(match.First);
                _ranking.Add(match.Second);
            }
            else
            {
                _ranking.Add(match.Second);
                _ranking.Add(match.First);
            }
        }
    }
}
