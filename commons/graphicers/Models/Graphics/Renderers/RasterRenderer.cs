using System;
using System.Collections.Generic;
using System.Text;
using Mov.Graphicers;

namespace Mov.Schemas.DesignPatterns.Structuals.Bridges.Renderers
{
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }
}
