using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Designer.Models;

namespace Mov.Designer.Repository
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class FileDesignerRepository : FileDomainRepositoryBase, IDesignerRepository
    {
        public override string RelativePath => "designer";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public FileDesignerRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encoding)
        {
            Shells = new FileDbObjectRepository<Shell, ShellCollection>(dir, GetRelativePath("shell"), encoding);
            Nodes = new FileDbObjectRepository<LayoutNode, LayoutNodeCollection>(dir, GetRelativePath("node"), encoding);
            Contents = new FileDbObjectRepository<LayoutContent, LayoutContentCollection>(dir, GetRelativePath("content"), encoding);
            Themes = new FileDbObjectRepository<Theme, ThemeCollection>(dir, GetRelativePath("theme"), encoding);
            Icons = new FileDbObjectRepository<Icon, IconCollection>(dir, GetRelativePath("icon"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Shell, ShellCollection> Shells { get; }

        public IDbObjectRepository<LayoutNode, LayoutNodeCollection> Nodes { get; }

        public IDbObjectRepository<LayoutContent, LayoutContentCollection> Contents { get; }

        public IDbObjectRepository<Theme, ThemeCollection> Themes { get; }

        public IDbObjectRepository<Icon, IconCollection> Icons { get; }

        #endregion プロパティ
    }
}