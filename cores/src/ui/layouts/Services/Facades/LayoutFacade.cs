using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Models.Styles;
using System.Collections.Generic;

namespace Mov.Core.Layouts.Services.Facades
{
    public class LayoutFacade : ILayoutFacade
    {

        private readonly ILayoutEngine engine;

        public LayoutFacade(ILayoutContext context)
        {
            engine = new LayoutEngine(context);
            engine.Build(context);
        }

        public void Update(ILayoutContext context)
        {
            engine.Build(context);
        }

        public LayoutNode GetRegionNode(RegionStyle region)
        {
            return engine.GetRegionNode(region);
        }

        public IEnumerable<LayoutShell> GetShells()
        {
            return engine.GetShells();
        }

        public LayoutShell GetRegionShell(RegionStyle region)
        {
            return engine.GetRegionShell(region);
        }


    }
}
