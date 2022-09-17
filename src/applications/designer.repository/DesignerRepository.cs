using Mov.Accessors;
using Mov.BaseModel;
using Mov.Designer.Models;

namespace Mov.Designer.Repository
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class DesignerRepository : DomainRepositoryBase, IDesignerRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DesignerRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            Shells = new DbObjectRepository<Shell, ShellCollection>(dir, GetRelativePath("shell"), encoding);
            Nodes = new DbObjectRepository<LayoutNode, LayoutNodeCollection>(dir, GetRelativePath("node"), encoding);
            Contents = new DbObjectRepository<LayoutContent, LayoutContentCollection>(dir, GetRelativePath("content"), encoding);
            Themes = new DbObjectRepository<Theme, ThemeCollection>(dir, GetRelativePath("theme"), encoding);
            Icons = new DbObjectRepository<Icon, IconCollection>(dir, GetRelativePath("icon"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Shell> Shells { get; }

        public IDbObjectRepository<LayoutNode> Nodes { get; }

        public IDbObjectRepository<LayoutContent> Contents { get; }

        public IDbObjectRepository<Theme> Themes { get; }

        public IDbObjectRepository<Icon> Icons { get; }

        #endregion プロパティ
    }
}