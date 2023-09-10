using Mov.Core.Repositories.Cruds;
using Mov.Core.Templates.Crud;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;

namespace Mov.Game.Engine.Persistences
{
    public class RepositoryGameQuery : IGameQuery
    {
        #region プロパティ

        public IPersistenceQuery<LandmarkSchema> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public RepositoryGameQuery(IGameRepository repository)
        {
            Landmark = new DbObjectRepositoryQuery<LandmarkSchema, LandmarkSchemaCollection>(repository.Landmarks);
        }

        #endregion コンストラクター
    }
}