using System.Collections.Generic;
using Xunit;

public class MovieCupTest
{
    private List<Movie> _movies;

    public MovieCupTest()
    {
        _movies = new List<Movie>{
            new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5),
            new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7),
            new Movie("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3),
            new Movie("tt7784604", "Hereditário", 2018, 7.8),
            new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8),
            new Movie("tt5463162", "Deadpool 2", 2018, 8.1),
            new Movie("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2),
            new Movie("tt3501632", "Thor: Ragnarok", 2017, 7.9)
        };
    }

    [Fact]
    public void Sort_Movies()
    {
        var movies = MovieCup.OrderByTitle(_movies);

        Assert.Equal("Deadpool 2", movies[0].Title);
        Assert.Equal("Han Solo: Uma História Star Wars", movies[1].Title);
        Assert.Equal("Hereditário", movies[2].Title);
        Assert.Equal("Jurassic World: Reino Ameaçado", movies[3].Title);
        Assert.Equal("Oito Mulheres e um Segredo", movies[4].Title);
        Assert.Equal("Os Incríveis 2", movies[5].Title);
        Assert.Equal("Thor: Ragnarok", movies[6].Title);
        Assert.Equal("Vingadores: Guerra Infinita", movies[7].Title);
    }

    [Fact]
    public void Winner_First_Round()
    {
        var movies = MovieCup.OrderByTitle(_movies);
        var tournament = MovieCup.MakeTournament(movies);

        var winner1 = MovieCup.RoundWinner(tournament[0].Item1, tournament[0].Item2);
        var winner2 = MovieCup.RoundWinner(tournament[1].Item1, tournament[1].Item2);
        var winner3 = MovieCup.RoundWinner(tournament[2].Item1, tournament[2].Item2);
        var winner4 = MovieCup.RoundWinner(tournament[3].Item1, tournament[3].Item2);

        Assert.Equal("Vingadores: Guerra Infinita", winner1.Title);
        Assert.Equal("Thor: Ragnarok", winner2.Title);
        Assert.Equal("Os Incríveis 2", winner3.Title);
        Assert.Equal("Jurassic World: Reino Ameaçado", winner4.Title);
    }
}