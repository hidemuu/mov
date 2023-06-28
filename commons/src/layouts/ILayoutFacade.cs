using Mov.Layouts.Models.Nodes.Entities;
using Mov.Layouts.Models.Shells.Entities;
using Mov.Layouts.Models.Shells.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public interface ILayoutFacade
    {
        void Update(ILayoutContext context);

        LayoutNode GetRegionNode(RegionStyle region);

        IEnumerable<LayoutShell> GetShells();

        LayoutShell GetRegionShell(RegionStyle region);
    }
}
