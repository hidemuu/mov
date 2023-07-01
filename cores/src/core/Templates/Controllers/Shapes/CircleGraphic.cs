using Mov.Core.Models.Entities.Shapes;

namespace Mov.Core.Templates.Controllers.Shapes
{
    public class CircleGraphic : GraphicObject
    {
        public CircleGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Circle";
    }
}
