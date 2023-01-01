using Mov.Layouts.Contexts;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Mov.Layouts
{
    public interface ILayoutEngine
    {
        #region プロパティ

        int DomainId { get; }

        #endregion プロパティ

        #region メソッド

        void Build();

        IEnumerable<LayoutNode> GetNodes();

        LayoutNode GetRegionNode(RegionStyle region);

        IEnumerable<LayoutContent> GetContents();

        IEnumerable<LayoutShell> GetShells();

        LayoutShell GetRegionShell(RegionStyle region);

        IEnumerable<LayoutTheme> GetThemes();

        #endregion メソッド

    }
}
