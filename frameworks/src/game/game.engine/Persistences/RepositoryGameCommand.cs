using Mov.Game.Models;
using Mov.Game.Models.Entities.Schemas;
using Mov.Repositories.Services.Cruds;

namespace Mov.Game.Engine.Persistences
{
    public class RepositoryGameCommand : IGameCommand
    {
        #region プロパティ

        public IPersistenceCommand<Landmark> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public RepositoryGameCommand(IGameRepository repository)
        {
            Landmark = new DbObjectRepositoryCommand<Landmark, LandmarkCollection>(repository.Landmarks);
        }

        #endregion コンストラクター
    }
}