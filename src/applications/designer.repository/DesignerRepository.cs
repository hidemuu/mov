using Mov.Accessors;
using Mov.Designer.Models;
using Mov.Framework;

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
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Shell, ShellCollection> Shells { get; }

        public IDbObjectRepository<LayoutNode, LayoutNodeCollection> Nodes { get; }

        public IDbObjectRepository<LayoutContent, LayoutContentCollection> Contents { get; }

        public IDbObjectRepository<Theme, ThemeCollection> Themes { get; }

        #endregion プロパティ
    }
}