using Mov.Schemas.DesignPatterns.Structuals.Decorators.Shapes.Policies;
using Mov.Schemas.Units.Coordinates.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Decorators.Shapes
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
