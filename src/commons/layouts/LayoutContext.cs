using Mov.Layouts.Contexts;
using Mov.Layouts.Contexts.Contents;
using Mov.Schemas.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContext
    {
        #region プロパティ

        public CodeKey Code { get; }
        public IEnumerable<LayoutNode> Nodes { get; }
        public IEnumerable<LayoutContent> Contents { get; }
        public IEnumerable<LayoutShell> Shells { get; }
        public IEnumerable<LayoutTheme> Themes { get; }

        #endregion プロパティ

        public LayoutContext(
            CodeKey code,
            IEnumerable<LayoutNode> nodes, 
            IEnumerable<LayoutContent> contents, 
            IEnumerable<LayoutShell> shells, 
            IEnumerable<LayoutTheme> themes)
        {
            this.Code = code;
            this.Nodes = nodes;
            this.Contents = contents;
            this.Shells = shells;
            this.Themes = themes;
        }
    }
}
