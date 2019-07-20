using MovieCup.Domain.Enums;
using src.MovieCup.Shared.Models;
using System;

namespace MovieCup.Domain.Models
{
    public class Match : Entity<Guid>
    {
        public Match(Guid id, Movie first, Movie second)
        {
            Id = id;
            First = first;
            Second = second;
            Winner = MatchWinner.Unknown;
        }

        public Movie First { get; private set; }
        public Movie Second { get; private set; }

        public MatchWinner Winner { get; private set; }

        public void Play()
        {
            if (First.Note == Second.Note)
            {
                Winner = First.Title.CompareTo(Second.Title) <= 0 ? MatchWinner.FirstPlayer : MatchWinner.SecondPlayer;
                return;
            }
            else
            {
                Winner = First.Note > Second.Note ? MatchWinner.FirstPlayer : MatchWinner.SecondPlayer;
            }
        }
    }
}