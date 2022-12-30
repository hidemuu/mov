using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Point3D : ValueObjectBase<Point3D>
    {
        public CoordinateUnit X { get; }

        public CoordinateUnit Y { get; }

        public CoordinateUnit Z { get; }

        public Point3D(decimal x, decimal y, decimal z)
        {
            this.X = new CoordinateUnit(x);
            this.Y = new CoordinateUnit(y);
            this.Z = new CoordinateUnit(z);
        }

        protected override bool EqualCore(Point3D other)
        {
            return 
                this.X.Equals(other.X) && 
                this.Y.Equals(other.Y) && 
                this.Z.Equals(other.Z);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.X.GetHashCode() ^ 
                this.Y.GetHashCode() ^ 
                this.Z.GetHashCode();
        }
    }
}
