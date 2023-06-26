using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using Mov.Repositories.Services;
using Mov.Repositories.Services.Repositories.DbObjects;
using Mov.Repositories.Services.Repositories.Domains;
using Mov.Utilities;

namespace Mov.Designer.Repository
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class FileDesignerRepository : FileDomainRepositoryBase, IDesignerRepository
    {
        public override string DomainPath => "designer";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public FileDesignerRepository(string endpoint, string fileDir, string extension, string encoding = UtilityConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            Shells = new FileDbObjectRepository<ShellSchema, ShellCollection>(GetPath("shell"), encoding);
            Nodes = new FileDbObjectRepository<NodeSchema, NodeCollection>(GetPath("node"), encoding);
            Contents = new FileDbObjectRepository<ContentSchema, ContentCollection>(GetPath("content"), encoding);
            Themes = new FileDbObjectRepository<ThemeSchema, ThemeCollection>(GetPath("theme"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<ShellSchema, ShellCollection> Shells { get; }

        public IDbObjectRepository<NodeSchema, NodeCollection> Nodes { get; }

        public IDbObjectRepository<ContentSchema, ContentCollection> Contents { get; }

        public IDbObjectRepository<ThemeSchema, ThemeCollection> Themes { get; }

        #endregion プロパティ
    }
}