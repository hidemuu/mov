using Mov.Schemas.Units;
using Mov.Schemas.Units.Coordinates;
using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Shapes.TwoDimensions
{
    public sealed class RotRectangle2D : ValueObjectBase<RotRectangle2D>
    {
        public Point2D CenterPoint { get; }

        public LengthUnit Width { get; }

        public LengthUnit Height { get; }

        public AngleUnit Angle { get; }


        public RotRectangle2D(Point2D center, LengthUnit width, LengthUnit height, AngleUnit angle)
        {
            CenterPoint = center;
            Width = width;
            Height = height;
            Angle = angle;
        }

        protected override bool EqualCore(RotRectangle2D other)
        {
            return
                CenterPoint.Equals(other.CenterPoint) &&
                Width.Equals(other.Width) &&
                Height.Equals(other.Height) &&
                Angle.Equals(other.Angle);
        }

        protected override int GetHashCodeCore()
        {
            return
                CenterPoint.GetHashCode() ^
                Width.GetHashCode() ^
                Height.GetHashCode() ^
                Angle.GetHashCode();
        }
    }
}
