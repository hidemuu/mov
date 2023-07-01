using System;

namespace Mov.Core.Templates.Controllers.Shapes.Renderers
{
    public class GraphicRenderer : IRenderer
    {
        private readonly string color;

        public GraphicRenderer(string color)
        {
            this.color = color;
        }

        public void RenderCircle(float radius)
        {
            throw new NotImplementedException();
        }
    }
}
