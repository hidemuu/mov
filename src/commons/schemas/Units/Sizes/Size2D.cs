﻿using Mov.Schemas.Shapes;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units.Sizes
{
    public sealed class Size2D : ValueObjectBase<Size2D>
    {
        public static Size2D Default = new Size2D(0, 0);

        public LengthUnit Height { get; }

        public LengthUnit Width { get; }

        public Size2D(double width, double height)
        {
            this.Width = new LengthUnit(width);
            this.Height = new LengthUnit(height);

        }

        protected override bool EqualCore(Size2D other)
        {
            return
                this.Width.Equals(other.Width) &&
                this.Height.Equals(other.Height);
        }

        protected override int GetHashCodeCore()
        {
            return
                this.Width.GetHashCode() ^
                this.Height.GetHashCode();
        }
    }
}