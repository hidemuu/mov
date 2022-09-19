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
        public FileDesignerRepository(string endpoint, string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) 
            : base(endpoint, fileDir, extension, encoding)
        {
            Shells = new FileDbObjectRepository<Shell, ShellCollection>(GetPath("shell"), encoding);
            Nodes = new FileDbObjectRepository<LayoutNode, LayoutNodeCollection>(GetPath("node"), encoding);
            Contents = new FileDbObjectRepository<LayoutContent, LayoutContentCollection>(GetPath("content"), encoding);
            Themes = new FileDbObjectRepository<Theme, ThemeCollection>(GetPath("theme"), encoding);
            Icons = new FileDbObjectRepository<Icon, IconCollection>(GetPath("icon"), encoding);
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