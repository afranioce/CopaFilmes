using src.MovieCup.Shared.Models;

namespace MovieCup.Domain.Models
{
    public class Movie : Entity<string>
    {
        public Movie(string id, string title, int year, double note)
        {
            Id = id;
            Title = title;
            Year = year;
            Note = note;
        }

        public string Title { get; private set; }
        public int Year { get; private set; }
        public double Note { get; private set; }
    }
}