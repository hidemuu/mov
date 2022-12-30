using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public interface ILayoutService
    {
        LayoutNode GetRegionNode(ShellRegion region);

        IEnumerable<LayoutShell> GetShells();

        LayoutShell GetRegionShell(ShellRegion region);
    }
}
