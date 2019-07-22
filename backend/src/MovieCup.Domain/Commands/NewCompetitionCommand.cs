using MovieCup.Shared.Commands;

namespace MovieCup.Domain.Commands
{
    public class NewCompetitionCommand : ICommand
    {
        public NewCompetitionCommand(string[] playerIds, int numberOfPlayers)
        {
            PlayerIds = playerIds;
            NumberOfPlayers = numberOfPlayers;
        }

        public string[] PlayerIds { get; private set; }
        public int NumberOfPlayers { get; private set; }
    }
}
