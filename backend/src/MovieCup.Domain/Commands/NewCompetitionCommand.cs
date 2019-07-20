using MovieCup.Shared.Commands;

namespace MovieCup.Domain.Commands
{
    public class NewCompetitionCommand : ICommand
    {
        public NewCompetitionCommand(string[] playerIds)
        {
            PlayerIds = playerIds;
        }

        public string[] PlayerIds { get; private set; }
    }
}
