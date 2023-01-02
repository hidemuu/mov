using Mov.Layouts.Contexts;
using Mov.Schemas.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public interface ILayoutContext
    {
        #region プロパティ

        CodeKey DomainId { get; }
        IEnumerable<LayoutNode> Nodes { get; }
        IEnumerable<LayoutContent> Contents { get; }
        IEnumerable<LayoutShell> Shells { get; }
        IEnumerable<LayoutTheme> Themes { get; }

        #endregion プロパティ

        #region メソッド

        void Read();

        void Write();

        void Update();

        #endregion メソッド

    }
}
