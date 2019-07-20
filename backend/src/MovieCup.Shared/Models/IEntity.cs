namespace src.MovieCup.Shared.Models
{
    public interface IEntity<T>
    {
         T Id { get; }
    }
}