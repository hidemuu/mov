using Mov.Core.Models;

namespace Mov.Core.Maths.Sizes
{
    public sealed class Size2D : ValueObjectBase<Size2D>
    {
        public static Size2D Default = new Size2D(0, 0);

        public LengthValue Height { get; }

        public LengthValue Width { get; }

        public double Area => Width.Value * Height.Value;

        public Size2D(double width, double height)
        {
            Width = new LengthValue(width);
            Height = new LengthValue(height);

        }

        protected override bool EqualCore(Size2D other)
        {
            return
                Width.Equals(other.Width) &&
                Height.Equals(other.Height);
        }

        protected override int GetHashCodeCore()
        {
            return
                Width.GetHashCode() ^
                Height.GetHashCode();
        }
    }
}
