using Mov.Core;
using Mov.Core.Repositories.Repositories.DbObjects;
using Mov.Core.Repositories.Repositories.Domains;
using Mov.Core.Templates.Repositories;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;

namespace Mov.Designer.Repository.File
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
        public FileDesignerRepository(string endpoint, string fileDir, string extension, string encoding = CoreConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            Shells = new FileDbObjectRepository<ShellSchema, ShellSchemaCollection>(GetPath("shell"), encoding);
            Nodes = new FileDbObjectRepository<NodeSchema, NodeSchemaCollection>(GetPath("node"), encoding);
            Contents = new FileDbObjectRepository<ContentSchema, ContentSchemaCollection>(GetPath("content"), encoding);
            Themes = new FileDbObjectRepository<ThemeSchema, ThemeSchemaCollection>(GetPath("theme"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<ShellSchema, ShellSchemaCollection> Shells { get; }

        public IDbObjectRepository<NodeSchema, NodeSchemaCollection> Nodes { get; }

        public IDbObjectRepository<ContentSchema, ContentSchemaCollection> Contents { get; }

        public IDbObjectRepository<ThemeSchema, ThemeSchemaCollection> Themes { get; }

        #endregion プロパティ
    }
}