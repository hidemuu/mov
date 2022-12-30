using Mov.Schemas.Shapes;
using Mov.Schemas.Units;
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

        public UnitLength Width { get; }

        public UnitLength Height { get; }
        
        public Rectangle2D(Point2D upperLeft, Point2D lowerRight)
        {
            this.UpperLeftPoint = upperLeft;
            this.LowerRightPoint = lowerRight;
            this.CenterPoint = new Point2D((lowerRight.X.Value + upperLeft.X.Value) / 2, (lowerRight.Y.Value + upperLeft.Y.Value) / 2);
            this.Width = new UnitLength(lowerRight.X.Value - upperLeft.X.Value);
            this.Height = new UnitLength(lowerRight.Y.Value - upperLeft.Y.Value);
        }

        public Rectangle2D(Point2D center, UnitLength width, UnitLength height)
        {
            this.CenterPoint = center;
            this.Width = width;
            this.Height = height;
            this.UpperLeftPoint = new Point2D(center.X.Value - (width.Value / 2), center.Y.Value + (height.Value / 2));
            this.LowerRightPoint = new Point2D(center.X.Value + (width.Value / 2), center.Y.Value - (height.Value / 2));
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
