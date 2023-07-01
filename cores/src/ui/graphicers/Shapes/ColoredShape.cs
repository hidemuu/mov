using Mov.Core.Graphicers.Shapes.Policies;
using Mov.Core.Models.Entities.Shapes;
using System.Linq;
using System.Text;

namespace Mov.Core.Graphicers.Shapes
{
    public class ColoredShape
    : ShapeDecorator<ColoredShape, AbsorbCyclePolicy>
    {

        private readonly string color;

        public ColoredShape(IShape shape, string color) : base(shape)
        {
            this.color = color;
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"{shape.ToString()}");

            if (policy.ApplicationAllowed(types[0], types.Skip(1).ToList()))
                sb.Append($" has the color {color}");

            return sb.ToString();
        }
    }
}
