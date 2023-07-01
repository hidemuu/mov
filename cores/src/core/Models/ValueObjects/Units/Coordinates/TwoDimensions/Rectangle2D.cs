namespace Mov.Core.Models.ValueObjects.Units.Coordinates.TwoDimensions
{
    public sealed class Rectangle2D : ValueObjectBase<Rectangle2D>
    {
        public Point2D UpperLeftPoint { get; }

        public Point2D LowerRightPoint { get; }

        public Point2D CenterPoint { get; }

        public LengthUnit Width { get; }

        public LengthUnit Height { get; }



        public Rectangle2D(Point2D upperLeft, Point2D lowerRight)
        {
            UpperLeftPoint = upperLeft;
            LowerRightPoint = lowerRight;
            CenterPoint = Point2D.Factory.New(new CoordinateUnit((lowerRight.X.Value + upperLeft.X.Value) / 2), new CoordinateUnit((lowerRight.Y.Value + upperLeft.Y.Value) / 2));
            Width = new LengthUnit((double)(lowerRight.X.Value - upperLeft.X.Value));
            Height = new LengthUnit((double)(lowerRight.Y.Value - upperLeft.Y.Value));
        }

        public Rectangle2D(Point2D center, LengthUnit width, LengthUnit height)
        {
            CenterPoint = center;
            Width = width;
            Height = height;
            UpperLeftPoint = Point2D.Factory.New(new CoordinateUnit(center.X.Value - width.Value / 2), new CoordinateUnit(center.Y.Value + height.Value / 2));
            LowerRightPoint = Point2D.Factory.New(new CoordinateUnit(center.X.Value + width.Value / 2), new CoordinateUnit(center.Y.Value - height.Value / 2));
        }

        protected override bool EqualCore(Rectangle2D other)
        {
            return
                UpperLeftPoint.Equals(other.UpperLeftPoint) &&
                LowerRightPoint.Equals(other.LowerRightPoint);
        }

        protected override int GetHashCodeCore()
        {
            return
                UpperLeftPoint.GetHashCode() ^
                LowerRightPoint.GetHashCode();
        }
    }
}
