using Mov.Layouts.Contexts;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Implements
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
