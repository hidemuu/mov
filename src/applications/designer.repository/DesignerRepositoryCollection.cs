using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Designer.Repository.Xml
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class DesignerRepositoryCollection : FileRepositoryCollectionBase, IDesignerRepositoryCollection
    {

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DesignerRepositoryCollection(string resourceDir, string extension, string encoding = "utf-8") : base(resourceDir, extension)
        {
            ShellLayouts = new ShellLayoutRepository(GetRepositoryPath("shell_layout"), encoding);
            LayoutTrees = new LayoutTreeRepository(GetRepositoryPath("layout_tree"), encoding);
            ContentTables = new ContentTableRepository(GetRepositoryPath("content_table"), encoding);
            Themes = new ThemeRepository(GetRepositoryPath("theme"), encoding);
        }

        #region プロパティ

        public FileRepositoryBase<ShellLayout, ShellLayoutCollection> ShellLayouts { get; }

        public FileRepositoryBase<LayoutTree, LayoutTreeCollection> LayoutTrees { get; }

        public FileRepositoryBase<ContentTable, ContentTableCollection> ContentTables { get; }

        public FileRepositoryBase<Theme, ThemeCollection> Themes { get; }

        #endregion

    }
}
