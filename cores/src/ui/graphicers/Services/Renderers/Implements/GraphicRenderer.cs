﻿using System;

namespace Mov.Core.Graphicers.Services.Renderers.Implements
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
