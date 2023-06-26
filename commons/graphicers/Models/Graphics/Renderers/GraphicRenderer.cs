using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Graphics.Renderers
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
