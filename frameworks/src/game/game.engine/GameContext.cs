using Mov.Game.Engine.Persistences;
using Mov.Game.Models;

namespace Mov.Game.Engine
{
    public class GameContext : IGameContext
    {
        public IGameRepository Repository { get; }

        public IGameCommand Command { get; }

        public IGameQuery Query { get; }

        public GameContext(IGameRepository repository)
        {
            Repository = repository;
            Command = new RepositoryGameCommand(repository);
            Query = new RepositoryGameQuery(repository);
        }
    }
}