﻿using Mov.Core.Templates.Controllers;

namespace Mov.Core.Contexts.Shapes.Entities
{
    internal class CircleShape : ShapeBase
    {
        private float radius;

        public CircleShape(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
}