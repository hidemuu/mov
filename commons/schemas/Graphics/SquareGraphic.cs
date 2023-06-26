using Mov.Schemas.DesignPatterns.Structuals.Bridges.Renderers;
using Mov.Schemas.Units.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Graphics
{
    public class SquareGraphic : GraphicObject
    {
        public SquareGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Square";
    }
}
