using Mov.Core.Models.ValueObjects.Shapes;
using Mov.Core.Templates.Controllers;

namespace Mov.Core.Models.Entities.Shapes
{
    public class SquareGraphic : GraphicObject
    {
        public SquareGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Square";
    }
}
