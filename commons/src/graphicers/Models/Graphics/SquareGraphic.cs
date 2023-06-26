using System;
using System.Collections.Generic;
using System.Text;
using Mov.Graphicers.Models.Shapes;

namespace Mov.Graphicers.Models.Graphics
{
    public class SquareGraphic : GraphicObject
    {
        public SquareGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Square";
    }
}
