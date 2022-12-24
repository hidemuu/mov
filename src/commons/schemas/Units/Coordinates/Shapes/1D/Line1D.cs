using Mov.Schemas.Coordinates;
using Mov.Schemas.Units;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Line1D : ValueObjectBase<Line1D>
    {
        public PointXY Point1 { get; }

        public PointXY Point2 { get; }

        public UnitAngle Angle { get; }

        public UnitLength Length { get; }

        public UnitLength LengthX { get; }

        public UnitLength LengthY { get; }

        

        public Line1D(PointXY point1, PointXY point2)
        {
            this.Point1 = point1;
            this.Point2 = point2;
        }

        protected override bool EqualCore(Line1D other)
        {
            return 
                this.Point1.Equals(other.Point1) && 
                this.Point2.Equals(other.Point2);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.Point1.GetHashCode() ^ 
                this.Point2.GetHashCode();
        }
    }
}
