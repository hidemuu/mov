using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Point2D : ValueObjectBase<Point2D>
    {
        public CoordinateUnit X { get; }

        public CoordinateUnit Y { get; }

        public Point2D(decimal x, decimal y)
        {
            this.X = new CoordinateUnit(x);
            this.Y = new CoordinateUnit(y);

        }

        protected override bool EqualCore(Point2D other)
        {
            return 
                this.X.Equals(other.X) && 
                this.Y.Equals(other.Y);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.X.GetHashCode() ^ 
                this.Y.GetHashCode();
        }
    }
}
