﻿using Mov.Schemas.Coordinates;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    public sealed  class Arc : ValueObjectBase<Arc>
    {
        public Point2D Point1 { get; }

        public Point2D Point2 { get; }

        public Angle Angle { get; }

        public Arc(Point2D point1, Point2D point2, Angle angle)
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Angle = angle;
        }

        protected override bool EqualCore(Arc other)
        {
            return this.Point1.Equals(other.Point1) && this.Point2.Equals(other.Point2) && this.Angle.Equals(other.Angle);
        }

        protected override int GetHashCodeCore()
        {
            return this.Point1.GetHashCode() ^ this.Point2.GetHashCode() ^ this.Angle.GetHashCode();
        }
    }
}