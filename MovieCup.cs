using System.Linq;
using System.Collections.Generic;
using System;

public static class MovieCup
{
    public static List<Movie> OrderByTitle(List<Movie> movies) => movies.OrderBy(movie => movie.Title).ToList();

    public static List<Tuple<Movie, Movie>> MakeTournament(List<Movie> movies)
    {
        if (!IsValidTournament(movies))
        {
            throw new Exception("Deve ser divisivel por dois");
        }

        var tournament = new List<Tuple<Movie, Movie>>();
        for (var i = 0; i < movies.Count / 2; i++)
        {
            var first = movies[i];
            var second = movies[movies.Count - 1 - i];

            var opponents = new Tuple<Movie, Movie>(first, second);
            tournament.Add(opponents);
        }

        return tournament;
    }

    private static bool IsValidTournament(List<Movie> movies)
    {
        return movies.Count % 2 == 0;
    }

    public static Movie RoundWinner(Movie first, Movie second)
    {
        if (first.Note == second.Note)
        {
            var opponents = new List<Movie> { first, second };
            return OrderByTitle(opponents).First();
        }

        return first.Note > second.Note ? first : second;
    }
}
