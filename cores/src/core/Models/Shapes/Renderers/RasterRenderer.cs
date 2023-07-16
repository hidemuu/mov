using Mov.Core.Templates.Controllers;
using System;

namespace Mov.Core.Models.Shapes.Renderers
{
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }
}
