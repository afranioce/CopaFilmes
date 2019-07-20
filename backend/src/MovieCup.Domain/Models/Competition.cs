using src.MovieCup.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public int NumberOfPlayers { get; private set; }
        public int NumberOfRounds { get; private set; }
        public IReadOnlyList<Movie> Players => _players;
        public IReadOnlyList<Bracket> Brackets => _brackets;

        private void CalculateRounds(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            NumberOfRounds = (int)Math.Ceiling(Math.Log(numberOfPlayers) / Math.Log(2));
        }

        public void AddPlayers(List<Movie> movies)
        {
            _players.AddRange(movies);
        }

        public void Start()
        {
            for (var round = 1; round <= NumberOfRounds; round++)
            {
                CompleteOfRound(round);
            }
        }

        public void CompleteOfRound(int round)
        {
            var bracket = GenerateBracketOfRound(round);
            bracket.Complete();
            _brackets.Add(bracket);
        }

        public List<Movie> SortPlayersByTitle()
        {
            return _players.OrderBy(player => player.Title).ToList();
        }

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

        private Bracket GenerateBracketOfRound(int round)
        {
            var players = round == 1 ? GetPlayersOfFirstRound() : GetBracketByRound(round - 1).GetWinners();

            var bracket = new Bracket(Guid.NewGuid(), round);
            for (var i = 1; i < players.Count; i += 2)
            {
                var match = new Match(Guid.NewGuid(), players[i - 1], players[i]);
                bracket.AddMatch(match);
            }

            return bracket;
        }

        public Bracket GetBracketByRound(int round)
        {
            return _brackets.FirstOrDefault(bracket => bracket.Round == round);
        }
    }
}