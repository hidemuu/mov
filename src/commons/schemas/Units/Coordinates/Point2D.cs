using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Point2D : ValueObjectBase<Point2D>
    {
        public UnitCoordinate X { get; }

        public UnitCoordinate Y { get; }

        public Point2D(decimal x, decimal y)
        {
            this.X = new UnitCoordinate(x);
            this.Y = new UnitCoordinate(y);

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
