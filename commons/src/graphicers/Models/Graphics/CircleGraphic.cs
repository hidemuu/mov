using System;
using System.Collections.Generic;
using System.Text;
using Mov.Graphicers.Models.Shapes;

namespace Mov.Graphicers.Models.Graphics
{
    public class CircleGraphic : GraphicObject
    {
        public CircleGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Circle";
    }
}
