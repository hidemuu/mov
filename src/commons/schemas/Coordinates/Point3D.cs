using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Point3D : ValueObjectBase<Point3D>
    {
        public Coordinate X { get; }

        public Coordinate Y { get; }

        public Coordinate Z { get; }

        public Point3D(decimal x, decimal y, decimal z)
        {
            this.X = new Coordinate(x);
            this.Y = new Coordinate(y);
            this.Z = new Coordinate(z);
        }

        protected override bool EqualCore(Point3D other)
        {
            return this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z);
        }

        protected override int GetHashCodeCore()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
        }
    }
}
