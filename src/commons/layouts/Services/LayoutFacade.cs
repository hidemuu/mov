using Mov.Layouts.Contexts;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Services
{
    public class LayoutFacade : ILayoutFacade
    {

        private readonly ILayoutEngine engine;

        public LayoutFacade(LayoutContext context)
        {
            this.engine = new LayoutEngine(context);
        }

        public LayoutNode GetRegionNode(RegionStyle region)
        {
            return this.engine.GetRegionNode(region);
        }

        public IEnumerable<LayoutShell> GetShells()
        {
            return this.engine.GetShells();
        }

        public LayoutShell GetRegionShell(RegionStyle region)
        {
            return this.engine.GetRegionShell(region);
        }

        
    }
}
