namespace Mov.Core.Models.Shapes.Coordinates
{
    public sealed class Point3D : ValueObjectBase<Point3D>
    {
        public CoordinateValue X { get; }

        public CoordinateValue Y { get; }

        public CoordinateValue Z { get; }

        public Point3D(double x, double y, double z)
        {
            X = new CoordinateValue(x);
            Y = new CoordinateValue(y);
            Z = new CoordinateValue(z);
        }

        protected override bool EqualCore(Point3D other)
        {
            return
                X.Equals(other.X) &&
                Y.Equals(other.Y) &&
                Z.Equals(other.Z);
        }

        protected override int GetHashCodeCore()
        {
            return
                X.GetHashCode() ^
                Y.GetHashCode() ^
                Z.GetHashCode();
        }
    }
}
