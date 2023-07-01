using Mov.Core.Contexts.Shapes.ValueObjects;
using Mov.Core.Templates.Controllers;

namespace Mov.Core.Contexts.Shapes.Entities
{
    public class CircleGraphic : GraphicObject
    {
        public CircleGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Circle";
    }
}