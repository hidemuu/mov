using Mov.Layouts.Contexts;
using Mov.Layouts.Contexts.Contents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContext
    {
        #region プロパティ

        public IEnumerable<LayoutNode> Nodes { get; }
        public IEnumerable<LayoutContent> Contents { get; }
        public IEnumerable<LayoutShell> Shells { get; }
        public IEnumerable<LayoutTheme> Themes { get; }

        #endregion プロパティ

        public LayoutContext(
            IEnumerable<LayoutNode> nodes, 
            IEnumerable<LayoutContent> contents, 
            IEnumerable<LayoutShell> shells, 
            IEnumerable<LayoutTheme> themes)
        {
            Nodes = nodes;
            Contents = contents;
            Shells = shells;
            Themes = themes;
        }
    }
}
