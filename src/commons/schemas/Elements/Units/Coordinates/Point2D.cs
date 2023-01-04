using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Units.Coordinates
{
    public sealed class Point2D : ValueObjectBase<Point2D>
    {
        public CoordinateUnit X { get; }

        public CoordinateUnit Y { get; }

        public Point2D(decimal x, decimal y)
        {
            X = new CoordinateUnit(x);
            Y = new CoordinateUnit(y);

        }

        protected override bool EqualCore(Point2D other)
        {
            return
                X.Equals(other.X) &&
                Y.Equals(other.Y);
        }

        protected override int GetHashCodeCore()
        {
            return
                X.GetHashCode() ^
                Y.GetHashCode();
        }
    }
}
