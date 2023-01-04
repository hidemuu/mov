using Mov.Layouts.Contexts;
using Mov.Layouts.Contexts.Contents;
using Mov.Schemas.Elements.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Implements
{
    public class LayoutContext : ILayoutContext
    {
        #region プロパティ

        public CodeKey DomainId { get; }
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
            DomainId = code;
            Nodes = nodes;
            Contents = contents;
            Shells = shells;
            Themes = themes;
        }

        public void Update()
        {

        }

        public void Read()
        {
            
        }

        public void Write()
        {
            
        }
    }
}
