using Mov.Schemas.Elements.Units;
using Mov.Schemas.Elements.Units.Coordinates;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Coordinates.Shapes.Layers
{
    public sealed class Rectangle2D : ValueObjectBase<Rectangle2D>
    {
        public Point2D UpperLeftPoint { get; }

        public Point2D LowerRightPoint { get; }

        public Point2D CenterPoint { get; }

        public LengthUnit Width { get; }

        public LengthUnit Height { get; }
        
        

        public Rectangle2D(Point2D upperLeft, Point2D lowerRight)
        {
            this.UpperLeftPoint = upperLeft;
            this.LowerRightPoint = lowerRight;
            this.CenterPoint = new Point2D(new CoordinateUnit((lowerRight.X.Value + upperLeft.X.Value) / 2), new CoordinateUnit((lowerRight.Y.Value + upperLeft.Y.Value) / 2));
            this.Width = new LengthUnit((double)(lowerRight.X.Value - upperLeft.X.Value));
            this.Height = new LengthUnit((double)(lowerRight.Y.Value - upperLeft.Y.Value));
        }

        public Rectangle2D(Point2D center, LengthUnit width, LengthUnit height)
        {
            this.CenterPoint = center;
            this.Width = width;
            this.Height = height;
            this.UpperLeftPoint = new Point2D(new CoordinateUnit(center.X.Value - (width.Value / 2)), new CoordinateUnit(center.Y.Value + (height.Value / 2)));
            this.LowerRightPoint = new Point2D(new CoordinateUnit(center.X.Value + (width.Value / 2)), new CoordinateUnit(center.Y.Value - (height.Value / 2)));
        }

        protected override bool EqualCore(Rectangle2D other)
        {
            return 
                this.UpperLeftPoint.Equals(other.UpperLeftPoint) && 
                this.LowerRightPoint.Equals(other.LowerRightPoint);
        }

        protected override int GetHashCodeCore()
        {
            return 
                this.UpperLeftPoint.GetHashCode() ^ 
                this.LowerRightPoint.GetHashCode();
        }
    }
}
