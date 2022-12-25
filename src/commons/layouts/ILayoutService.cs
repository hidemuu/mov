using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public interface ILayoutService
    {
        ILayoutNode GetNodeModel(ShellRegion region);

        IEnumerable<ILayoutShell> GetShells();
    }
}
