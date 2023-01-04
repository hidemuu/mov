using Mov.Schemas.Elements.Units;
using Mov.Schemas.Elements.Units.Coordinates;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Coordinates.Shapes.Layers
{
    public sealed class RotRectangle2D : ValueObjectBase<RotRectangle2D>
    {
        public Point2D CenterPoint { get; }

        public LengthUnit Width { get; }

        public LengthUnit Height { get; }

        public AngleUnit Angle { get; }

        
        public RotRectangle2D(Point2D center, LengthUnit width, LengthUnit height, AngleUnit angle)
        {
            this.CenterPoint = center;
            this.Width = width;
            this.Height = height;
            this.Angle = angle;
        }

        protected override bool EqualCore(RotRectangle2D other)
        {
            return 
                this.CenterPoint.Equals(other.CenterPoint) && 
                this.Width.Equals(other.Width) &&
                this.Height.Equals(other.Height) &&
                this.Angle.Equals(other.Angle);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.CenterPoint.GetHashCode() ^ 
                this.Width.GetHashCode() ^
                this.Height.GetHashCode() ^
                this.Angle.GetHashCode();
        }
    }
}
