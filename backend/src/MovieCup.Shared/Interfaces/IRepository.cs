using src.MovieCup.Shared.Models;

namespace MovieCup.Shared.Interfaces
{
    public interface IRepository<TEntity, TType> where TEntity : IEntity<TType>
    {
    }
}
