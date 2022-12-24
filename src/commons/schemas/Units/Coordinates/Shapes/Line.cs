using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Line : ValueObjectBase<Line>
    {
        public Point2D Point1 { get; }

        public Point2D Point2 { get; }

        public Line(Point2D point1, Point2D point2)
        {
            this.Point1 = point1;
            this.Point2 = point2;
        }

        protected override bool EqualCore(Line other)
        {
            return this.Point1.Equals(other.Point1) && this.Point2.Equals(other.Point2);
        }

        protected override int GetHashCodeCore()
        {
            return this.Point1.GetHashCode() ^ this.Point2.GetHashCode();
        }
    }
}
