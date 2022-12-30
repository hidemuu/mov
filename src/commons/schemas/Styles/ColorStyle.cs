using Mov.Schemas.Units;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Styles
{
    public sealed class ColorStyle : ValueObjectBase<ColorStyle>
    {
        public string Value { get; }

        public ColorStyle(string value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(ColorStyle other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
