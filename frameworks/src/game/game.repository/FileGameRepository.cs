using Mov.Core;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Repositories.DbObjects;
using Mov.Core.Repositories.Repositories.Domains;
using Mov.Core.Templates.Repositories;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;

namespace Mov.Game.Repository
{
    public class FileGameRepository : FileDomainRepositoryBase, IGameRepository
    {
        public override string DomainPath => "game";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileGameRepository(string endpoint, FileType extension, EncodingValue encoding)
            : base(endpoint, extension, encoding)
        {
            Landmarks = new FileDbObjectRepository<LandmarkSchema, LandmarkSchemaCollection>(GetPath("landmark"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<LandmarkSchema, LandmarkSchemaCollection> Landmarks { get; }

        #endregion プロパティ
    }
}