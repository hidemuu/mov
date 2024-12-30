using Mov.Core.Models;

namespace Mov.Core.Valuables.Dimensions.Coordinates.TwoDimensions
{
    public sealed class Line2D : ValueObjectBase<Line2D>
    {
        public Point2D Start { get; }

        public Point2D End { get; }

        public AngleValue Angle { get; }

        public LengthValue Length { get; }

        public LengthValue LengthX { get; }

        public LengthValue LengthY { get; }



        public Line2D(Point2D start, Point2D end)
        {
            Start = start;
            End = end;
        }

        protected override bool EqualCore(Line2D other)
        {
            return
                Start.Equals(other.Start) &&
                End.Equals(other.End);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return (Start != null ? Start.GetHashCode() : 0) * 397 ^ (End != null ? End.GetHashCode() : 0);
            }
        }
    }
}
