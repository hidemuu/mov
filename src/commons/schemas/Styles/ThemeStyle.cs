using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Styles
{
    public sealed class ThemeStyle : ValueObjectBase<ThemeStyle>
    {
        public string Value { get; }

        public ThemeStyle(string value)
        {
            Value = value;
        }

        protected override bool EqualCore(ThemeStyle other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
