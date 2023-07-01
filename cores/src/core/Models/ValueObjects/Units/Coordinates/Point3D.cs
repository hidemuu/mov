namespace Mov.Core.Models.ValueObjects.Units.Coordinates
{
    public sealed class Point3D : ValueObjectBase<Point3D>
    {
        public CoordinateUnit X { get; }

        public CoordinateUnit Y { get; }

        public CoordinateUnit Z { get; }

        public Point3D(double x, double y, double z)
        {
            X = new CoordinateUnit(x);
            Y = new CoordinateUnit(y);
            Z = new CoordinateUnit(z);
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
