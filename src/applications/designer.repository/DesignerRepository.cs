using Mov.Accessors;
using Mov.Designer.Models;

namespace Mov.Designer.Repository
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class DesignerRepository : DbObjectRepositoryBase, IDesignerRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DesignerRepository(string dir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            Shells = new DbObjectRepository<Shell, ShellCollection>(dir, GetRelativePath("shell"), encoding);
            LayoutNodes = new DbObjectRepository<LayoutNode, LayoutNodeCollection>(dir, GetRelativePath("layout_node"), encoding);
            Contents = new DbObjectRepository<Content, ContentCollection>(dir, GetRelativePath("content"), encoding);
            Themes = new DbObjectRepository<Theme, ThemeCollection>(dir, GetRelativePath("theme"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IRepository<Shell, ShellCollection> Shells { get; }

        public IRepository<LayoutNode, LayoutNodeCollection> LayoutNodes { get; }

        public IRepository<Content, ContentCollection> Contents { get; }

        public IRepository<Theme, ThemeCollection> Themes { get; }

        #endregion プロパティ
    }
}