using Mov.Accessors;
using Mov.Accessors.Repository;
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
    public class DesignerRepositoryCollection : FileRepositoryCollectionBase, IDesignerRepositoryCollection
    {

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DesignerRepositoryCollection(string resourceDir, string extension, string encoding = "utf-8") : base(resourceDir, extension)
        {
            ShellLayouts = new ShellLayoutRepository(GetRepositoryPath("shell_layout"), encoding);
            PartsLayouts = new PartsLayoutRepository(GetRepositoryPath("parts_layout"), encoding);
            Themes = new ThemeRepository(GetRepositoryPath("theme"), encoding);
        }

        #region プロパティ

        public IShellLayoutRepository ShellLayouts { get; }

        public IPartsLayoutRepository PartsLayouts { get; }

        public IThemeRepository Themes { get; }

        #endregion

    }
}
