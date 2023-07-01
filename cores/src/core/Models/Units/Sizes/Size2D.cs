namespace Mov.Core.Models.Units.Sizes
{
    public sealed class Size2D : ValueObjectBase<Size2D>
    {
        public static Size2D Default = new Size2D(0, 0);

        public LengthUnit Height { get; }

        public LengthUnit Width { get; }

        public double Area => Width.Value * Height.Value;

        public Size2D(double width, double height)
        {
            Width = new LengthUnit(width);
            Height = new LengthUnit(height);

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
