using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Graphics.Renderers
{
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }
}
