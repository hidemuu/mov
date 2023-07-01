using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Models.ValueObjects.Layouts;
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
