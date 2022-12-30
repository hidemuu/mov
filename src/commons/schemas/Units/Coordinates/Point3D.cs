using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Point3D : ValueObjectBase<Point3D>
    {
        public UnitCoordinate X { get; }

        public UnitCoordinate Y { get; }

        public UnitCoordinate Z { get; }

        public Point3D(decimal x, decimal y, decimal z)
        {
            this.X = new UnitCoordinate(x);
            this.Y = new UnitCoordinate(y);
            this.Z = new UnitCoordinate(z);
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
