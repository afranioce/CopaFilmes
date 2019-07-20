namespace src.MovieCup.Shared.Models
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; protected set; }
    }
}