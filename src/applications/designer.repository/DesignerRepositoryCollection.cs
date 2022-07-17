using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Designer.Repository.Xml
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class DesignerRepositoryCollection : DbObjectRepositoryCollectionBase, IDesignerRepositoryCollection
    {

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DesignerRepositoryCollection(string resourceDir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            Shells = new DbObjectRepository<Shell, ShellCollection>(this.dir, GetRelativePath("shell"), encoding);
            LayoutNodes = new DbObjectRepository<LayoutNode, LayoutNodeCollection>(this.dir, GetRelativePath("layout_node"), encoding);
            Contents = new DbObjectRepository<Content, ContentCollection>(this.dir, GetRelativePath("content"), encoding);
            Themes = new DbObjectRepository<Theme, ThemeCollection>(this.dir, GetRelativePath("theme"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public DbObjectRepository<Shell, ShellCollection> Shells { get; }

        public DbObjectRepository<LayoutNode, LayoutNodeCollection> LayoutNodes { get; }

        public DbObjectRepository<Content, ContentCollection> Contents { get; }

        public DbObjectRepository<Theme, ThemeCollection> Themes { get; }

        #endregion

    }
}
