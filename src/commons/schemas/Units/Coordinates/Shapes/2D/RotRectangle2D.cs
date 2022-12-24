using Mov.Schemas.Shapes;
using Mov.Schemas.Units;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Coordinates.Shapes.Layers
{
    public sealed class RotRectangle2D : ValueObjectBase<RotRectangle2D>
    {
        public PointXY CenterPoint { get; }

        public UnitLength Width { get; }

        public UnitLength Height { get; }

        public UnitAngle Angle { get; }

        
        public RotRectangle2D(PointXY center, UnitLength width, UnitLength height, UnitAngle angle)
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
