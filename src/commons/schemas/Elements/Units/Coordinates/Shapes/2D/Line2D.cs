using Mov.Schemas.Elements.Units;
using Mov.Schemas.Elements.Units.Coordinates;
using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed class Line2D : ValueObjectBase<Line2D>
    {
        public Point2D Start { get; }

        public Point2D End { get; }

        public AngleUnit Angle { get; }

        public LengthUnit Length { get; }

        public LengthUnit LengthX { get; }

        public LengthUnit LengthY { get; }

        

        public Line2D(Point2D start, Point2D end)
        {
            this.Start = start;
            this.End = end;
        }

        protected override bool EqualCore(Line2D other)
        {
            return 
                this.Start.Equals(other.Start) && 
                this.End.Equals(other.End);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.Start.GetHashCode() ^ 
                this.End.GetHashCode();
        }
    }
}
