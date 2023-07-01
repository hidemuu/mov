using Mov.Core.Models.ValueObjects;
using Mov.Core.Templates.Controllers;

namespace Mov.Core.Models.Entities.Shapes
{
    public class CircleGraphic : GraphicObject
    {
        public CircleGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Circle";
    }
}
