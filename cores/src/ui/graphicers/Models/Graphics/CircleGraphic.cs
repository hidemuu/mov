using Mov.Core.Graphicers.Models.Shapes;

namespace Mov.Core.Graphicers.Models.Graphics
{
    public class CircleGraphic : GraphicObject
    {
        public CircleGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Circle";
    }
}
