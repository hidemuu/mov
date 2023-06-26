using System;
using System.Collections.Generic;
using System.Text;
using Mov.Graphicers;

namespace Mov.Schemas.DesignPatterns.Structuals.Bridges.Renderers
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
