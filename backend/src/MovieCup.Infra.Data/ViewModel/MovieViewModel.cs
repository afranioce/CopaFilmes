using MovieCup.Domain.Models;

namespace MovieCup.Infra.Data.ViewModel
{
    class MovieViewModel
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }

        public Movie ToDomain() => new Movie(
            Id,
            Titulo,
            Ano,
            Nota
        );
    }
}
