using Mov.Schemas.Coordinates;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed  class Arc1D : ValueObjectBase<Arc1D>
    {
        public PointXY Point1 { get; }

        public PointXY Point2 { get; }

        public UnitAngle Angle { get; }

        public Arc1D(PointXY point1, PointXY point2, UnitAngle angle)
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Angle = angle;
        }

        protected override bool EqualCore(Arc1D other)
        {
            return 
                this.Point1.Equals(other.Point1) && 
                this.Point2.Equals(other.Point2) && 
                this.Angle.Equals(other.Angle);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.Point1.GetHashCode() ^ 
                this.Point2.GetHashCode() ^ 
                this.Angle.GetHashCode();
        }
    }
}
