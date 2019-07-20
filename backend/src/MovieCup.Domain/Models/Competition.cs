using System;
using System.Collections.Generic;
using System.Linq;
using src.MovieCup.Shared.Models;

namespace MovieCup.Domain.Models
{
    public class Competition : Entity<Guid>
    {
        private readonly List<Bracket> _brackets = new List<Bracket>();
        private readonly List<Movie> _players = new List<Movie>();

        public Competition(Guid id, int numberOfPlayers)
        {
            Id = id;
            CalculateRounds(numberOfPlayers);
        }

        public void AddParticipants(List<Movie> movies)
        {
            _players.AddRange(movies);
        }

        public int NumberOfPlayers { get; private set; }
        public int NumberOfRounds { get; private set; }
        public IReadOnlyList<Movie> Players => _players;
        public IReadOnlyList<Bracket> Brackets => _brackets;

        private void CalculateRounds(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            NumberOfRounds = (int)Math.Ceiling(Math.Log(numberOfPlayers) / Math.Log(2));
        }

        public List<Movie> SortPlayersByTitle()
        {
            return _players.OrderBy(player => player.Title).ToList();
        }

        private int CurrentRound => _brackets.Any() ? _brackets.Max(bracket => bracket.Round) : 0;

        private List<Movie> GetPlayersOfFirstRound()
        {
            var players = SortPlayersByTitle();
            var _players = new List<Movie>();
            for (var i = 0; i < NumberOfPlayers / 2; i++)
            {
                _players.AddRange(new Movie[] {
                    players[i],
                    players[NumberOfPlayers - 1 - i]
                });
            }
            return _players;
        }

        public void NextRound()
        {
            var nextRound = CurrentRound + 1;
            var isLastRound = nextRound == NumberOfRounds;
            if (isLastRound)
            {
                return;
            }

            GenerateMatchesOfRound(nextRound);
        }

        public void GenerateMatchesOfRound(int round)
        {
            var players = round == 1 ? GetPlayersOfFirstRound() : GetWinnersOfRound(round - 1);

            var bracket = new Bracket(Guid.NewGuid(), round);
            for (var i = 1; i < players.Count; i += 2)
            {
                var match = new Match(Guid.NewGuid(), players[i - 1], players[i]);
                bracket.AddMatch(match);
            }
            _brackets.Add(bracket);
        }

        public List<Movie> GetWinnersOfRound(int round)
        {
            var matches = GetMatchesOfRound(round);
            return matches.Select(match => 
            {
                match.Play();
                return match.Winner;
            }).ToList();
        }

        public IReadOnlyCollection<Match> GetMatchesOfRound(int round)
        {
            return _brackets.Find(bracket => bracket.Round == round).Matches;
        }
    }
}