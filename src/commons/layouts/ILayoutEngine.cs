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

        IEnumerable<LayoutNode> GetNodes();

        LayoutNode GetRegionNode(RegionStyle region);

        IEnumerable<LayoutShell> GetShells();

        LayoutShell GetShell(RegionStyle region);

    }
}
