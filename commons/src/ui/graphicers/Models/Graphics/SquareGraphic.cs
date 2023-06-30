using Mov.Core.Graphicers.Models.Shapes;

namespace Mov.Core.Graphicers.Models.Graphics
{
    public class SquareGraphic : GraphicObject
    {
        public SquareGraphic(IShape shape, string color, IRenderer renderer) : base(shape, color, renderer)
        {
        }

        public override string Name => "Square";
    }
}
