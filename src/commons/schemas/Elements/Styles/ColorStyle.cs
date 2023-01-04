using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Styles
{
    public sealed class ColorStyle : ValueObjectBase<ColorStyle>
    {
        public static ColorStyle Transrarent = new ColorStyle("Transparent");

        public static ColorStyle Black = new ColorStyle("Brack");

        public static ColorStyle White = new ColorStyle("White");

        public static ColorStyle DarkGray = new ColorStyle("DarkGray");

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
