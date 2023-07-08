using Mov.Core.Repositories.Cruds;
using Mov.Core.Templates.Crud;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;

namespace Mov.Game.Engine.Persistences
{
    public class RepositoryGameCommand : IGameCommand
    {
        #region プロパティ

        public IPersistenceCommand<LandmarkSchema> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public RepositoryGameCommand(IGameRepository repository)
        {
            Landmark = new DbObjectRepositoryCommand<LandmarkSchema, LandmarkSchemaCollection>(repository.Landmarks);
        }

        #endregion コンストラクター
    }
}