﻿using Mov.Core.Models;

namespace Mov.Core.Valuables.Dimensions.Coordinates.TwoDimensions
{
    public sealed class Arc2D : ValueObjectBase<Arc2D>
    {
        public Point2D Point1 { get; }

        public Point2D Point2 { get; }

        public AngleValue Angle { get; }

        public Arc2D(Point2D point1, Point2D point2, AngleValue angle)
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
