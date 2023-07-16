using System;

namespace Mov.Core.Models.Shapes.Coordinates
{
    public sealed class Point2D : ValueObjectBase<Point2D>
    {
        public CoordinateValue X { get; }

        public CoordinateValue Y { get; }

        private Point2D(CoordinateValue x, CoordinateValue y)
        {
            X = x;
            Y = y;
        }

        public static class Factory
        {
            public static Point2D New(CoordinateValue x, CoordinateValue y)
            {
                return new Point2D(x, y);
            }

            public static Point2D NewCartesianPoint(double x, double y)
            {
                return new Point2D(new CoordinateValue(x), new CoordinateValue(y));
            }

            public static Point2D NewPolarPoint(double rho, double theta)
            {
                return new Point2D(new CoordinateValue(rho * Math.Cos(theta)), new CoordinateValue(rho * Math.Sin(theta)));
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
