using System.Threading.Tasks;

namespace MovieCup.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handler(T command);
    }
}
