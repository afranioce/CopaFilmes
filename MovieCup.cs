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

            var matches = new Tuple<Movie, Movie>(first, second);
            tournament.Add(matches);
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
            var matches = new List<Movie> { first, second };
            return OrderByTitle(matches).First();
        }

        return first.Note > second.Note ? first : second;
    }
}

public class Competition
{
    public readonly List<Movie> Participants;
    private readonly int NumberOfMovies;
    private readonly double NumberOfRounds;
    private readonly List<Match> Ranking = new List<Match>();
    private readonly Dictionary<int, List<Match>> BracketRound = new Dictionary<int, List<Match>>();

    public Competition(List<Movie> movies)
    {
        Participants = Prepare(OrderByTitle(movies));
        NumberOfMovies = Participants.Count;
        NumberOfRounds = Math.Ceiling(Math.Log(NumberOfMovies) / Math.Log(2));
    }

    public List<Movie> OrderByTitle(List<Movie> movies)
    {
        return movies.OrderBy(movie => movie.Title).ToList();
    }

    private int CurrentRound => BracketRound.Count();

    public List<Movie> Prepare(List<Movie> movies)
    {
        var numberOfMovies = movies.Count;
        var _movies = new List<Movie>();
        for (var i = 0; i < numberOfMovies / 2; i++)
        {
            _movies.AddRange(new Movie[] {
                movies[i],
                movies[numberOfMovies - 1 - i]
            });
        }
        return _movies;
    }

    public void NextRound()
    {
        var nextRound = CurrentRound + 1;
        var isLastRound = nextRound == NumberOfRounds;
        if (isLastRound)
        {
            return;
        }

        var matches = GenerateMatchesByRound(nextRound);
        BracketRound.Add(nextRound, matches);
    }

    public List<Match> GenerateMatchesByRound(int round)
    {
        var movies = round == 1 ? Participants : GetWinnersByPreviousRound(round - 1);

        var matches = new List<Match>();
        for (var i = 1; i < movies.Count; i += 2)
        {
            matches.Add(new Match(movies[i - 1], movies[i]));
        }

        return matches;
    }

    public List<Movie> GetWinnersByPreviousRound(int round)
    {
        var matches = GetMatchesByRound(round);
        return matches.Select(m => m.Winner).ToList();
    }

    public List<Match> GetMatchesByRound(int round)
    {
        return BracketRound.GetValueOrDefault(round);
    }
}

public class Match
{
    public Match(Movie first, Movie second)
    {
        First = first;
        Second = second;
        Winner = GetWinnerResult();
    }

    public Movie First { get; private set; }
    public Movie Second { get; private set; }

    public Movie Winner { get; private set; }

    private Movie GetWinnerResult()
    {
        if (First.Note == Second.Note)
        {
            return First.Title.CompareTo(Second.Title) <= 0 ? First : Second;
        }

        return First.Note > Second.Note ? First : Second;
    }
}
