using Mov.Layouts.Contexts.Contents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts
{
    public class LayoutContext
    {
        #region プロパティ

        public LayoutNode Node { get; }
        public LayoutContent Content { get; }
        public LayoutShell Shell { get; }
        public LayoutTheme Theme { get; }

        #endregion プロパティ

        public LayoutContext(LayoutNode node, LayoutContent content, LayoutShell shell, LayoutTheme theme) 
        {
            this.Node = node;
            this.Content = content;
            this.Shell = shell;
            this.Theme = theme;
        }
    }
}
