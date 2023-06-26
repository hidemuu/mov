using Mov.Schemas.Units;
using Mov.Schemas.Units.Coordinates;
using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Shapes.TwoDimensions
{
    public sealed class Arc2D : ValueObjectBase<Arc2D>
    {
        public Point2D Point1 { get; }

        public Point2D Point2 { get; }

        public AngleUnit Angle { get; }

        public Arc2D(Point2D point1, Point2D point2, AngleUnit angle)
        {
            Point1 = point1;
            Point2 = point2;
            Angle = angle;
        }

        protected override bool EqualCore(Arc2D other)
        {
            return
                Point1.Equals(other.Point1) &&
                Point2.Equals(other.Point2) &&
                Angle.Equals(other.Angle);
        }

        protected override int GetHashCodeCore()
        {
            return
                Point1.GetHashCode() ^
                Point2.GetHashCode() ^
                Angle.GetHashCode();
        }
    }
}
