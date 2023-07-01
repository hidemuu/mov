using System;

namespace Mov.Core.Models.Units.Coordinates
{
    public sealed class Point2D : ValueObjectBase<Point2D>
    {
        public CoordinateUnit X { get; }

        public CoordinateUnit Y { get; }

        private Point2D(CoordinateUnit x, CoordinateUnit y)
        {
            X = x;
            Y = y;
        }

        public static class Factory
        {
            public static Point2D New(CoordinateUnit x, CoordinateUnit y)
            {
                return new Point2D(x, y);
            }

            public static Point2D NewCartesianPoint(double x, double y)
            {
                return new Point2D(new CoordinateUnit(x), new CoordinateUnit(y));
            }

            public static Point2D NewPolarPoint(double rho, double theta)
            {
                return new Point2D(new CoordinateUnit(rho * Math.Cos(theta)), new CoordinateUnit(rho * Math.Sin(theta)));
            }
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
                X.GetHashCode() * 397 ^
                Y.GetHashCode();
        }
    }
}
