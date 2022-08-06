using Mov.Accessors;
using Mov.Designer.Models;

namespace Mov.Designer.Repository.Xml
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class DesignerDatabase : DbObjectRepositoryBase, IDesignerDatabase
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DesignerDatabase(string resourceDir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            Shells = new DbObjectRepository<Shell, ShellCollection>(this.dir, GetRelativePath("shell"), encoding);
            LayoutNodes = new DbObjectRepository<LayoutNode, LayoutNodeCollection>(this.dir, GetRelativePath("layout_node"), encoding);
            Contents = new DbObjectRepository<Content, ContentCollection>(this.dir, GetRelativePath("content"), encoding);
            Themes = new DbObjectRepository<Theme, ThemeCollection>(this.dir, GetRelativePath("theme"), encoding);
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