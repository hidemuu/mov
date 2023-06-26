using Mov.Drawer.Models;
using Mov.Repositories.Services;
using Mov.Repositories.Services.Repositories.DbObjects;
using Mov.Repositories.Services.Repositories.Domains;
using Mov.Utilities;

namespace Mov.Drawer.Repository
{
    public class FileDrawerRepository : FileDomainRepositoryBase, IDrawerRepository
    {
        public override string DomainPath => "drawer";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDrawerRepository(string endpoint, string fileDir, string extension, string encoding = UtilityConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            DrawItems = new FileDbObjectRepository<DrawItem, DrawItemCollection>(GetPath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}