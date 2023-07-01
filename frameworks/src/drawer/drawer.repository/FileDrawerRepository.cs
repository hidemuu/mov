using Mov.Core;
using Mov.Core.Repositories.Services;
using Mov.Core.Repositories.Services.Repositories.DbObjects;
using Mov.Core.Repositories.Services.Repositories.Domains;
using Mov.Drawer.Models;

namespace Mov.Drawer.Repository
{
    public class FileDrawerRepository : FileDomainRepositoryBase, IDrawerRepository
    {
        public override string DomainPath => "drawer";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDrawerRepository(string endpoint, string fileDir, string extension, string encoding = CoreConstants.ENCODE_NAME_UTF8)
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