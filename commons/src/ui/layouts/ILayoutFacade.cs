using Mov.Core.Layouts.Models.Nodes.Entities;
using Mov.Core.Layouts.Models.Shells.Entities;
using Mov.Core.Layouts.Models.Shells.ValueObjects;
using System.Collections.Generic;

namespace Mov.Core.Layouts
{
    public interface ILayoutFacade
    {
        void Update(ILayoutContext context);

        LayoutNode GetRegionNode(RegionStyle region);

        IEnumerable<LayoutShell> GetShells();

        LayoutShell GetRegionShell(RegionStyle region);
    }
}
