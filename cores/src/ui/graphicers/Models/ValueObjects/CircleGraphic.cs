
using Mov.Core.Graphicers.Services.Renderers;
using Mov.Core.Graphicers.Services.Shapes;

namespace Mov.Core.Graphicers.Models.ValueObjects
{
    public class CircleGraphic : GraphicObject
    {
        public CircleGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Circle";
    }
}