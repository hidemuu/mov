using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class PointXY : ValueObjectBase<PointXY>
    {
        public UnitCoordinate X { get; }

        public UnitCoordinate Y { get; }

        public PointXY(decimal x, decimal y)
        {
            this.X = new UnitCoordinate(x);
            this.Y = new UnitCoordinate(y);

        }

        protected override bool EqualCore(PointXY other)
        {
            return 
                this.X.Equals(other.X) && 
                this.Y.Equals(other.Y);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.X.GetHashCode() ^ 
                this.Y.GetHashCode();
        }
    }
}
