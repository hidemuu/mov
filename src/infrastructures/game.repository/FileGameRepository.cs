using Mov.Game.Models;
using Mov.Game.Models.Entities.Schemas;
using Mov.Repositories.Services;
using Mov.Repositories.Services.Repositories.DbObjects;
using Mov.Repositories.Services.Repositories.Domains;
using Mov.Utilities;

namespace Mov.Game.Repository
{
    public class FileGameRepository : FileDomainRepositoryBase, IGameRepository
    {
        public override string DomainPath => "game";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileGameRepository(string endpoint, string fileDir, string extension, string encoding = UtilityConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            Landmarks = new FileDbObjectRepository<Landmark, LandmarkCollection>(GetPath("landmark"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }

        #endregion プロパティ
    }
}