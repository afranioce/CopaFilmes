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
        }

        public Movie First { get; private set; }
        public Movie Second { get; private set; }

        public Movie Winner { get; private set; }

        public void Play()
        {
            if (First.Note == Second.Note)
            {
                Winner = First.Title.CompareTo(Second.Title) <= 0 ? First : Second;
                return;
            }

            Winner = First.Note > Second.Note ? First : Second;
        }
    }
}