using Mov.Core.Models.Physics;

namespace Mov.Core.Models.Dimensions.Coordinates.TwoDimensions
{
    public sealed class RotRectangle2D : ValueObjectBase<RotRectangle2D>
    {
        public Point2D CenterPoint { get; }

        public LengthValue Width { get; }

        public LengthValue Height { get; }

        public AngleValue Angle { get; }


        public RotRectangle2D(Point2D center, LengthValue width, LengthValue height, AngleValue angle)
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
