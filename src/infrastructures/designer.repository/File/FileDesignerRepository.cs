using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;

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
        public FileDesignerRepository(string endpoint, string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) 
            : base(endpoint, fileDir, extension, encoding)
        {
            Shells = new FileDbObjectRepository<Shell, ShellCollection>(GetPath("shell"), encoding);
            Nodes = new FileDbObjectRepository<Node, NodeCollection>(GetPath("node"), encoding);
            Contents = new FileDbObjectRepository<Content, ContentCollection>(GetPath("content"), encoding);
            Themes = new FileDbObjectRepository<Theme, ThemeCollection>(GetPath("theme"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Shell, ShellCollection> Shells { get; }

        public IDbObjectRepository<Node, NodeCollection> Nodes { get; }

        public IDbObjectRepository<Content, ContentCollection> Contents { get; }

        public IDbObjectRepository<Theme, ThemeCollection> Themes { get; }

        #endregion プロパティ
    }
}