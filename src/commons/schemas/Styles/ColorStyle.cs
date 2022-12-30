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
            Value = value;
        }

        protected override bool EqualCore(ColorStyle other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
