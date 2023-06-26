using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed class AngleUnit : ValueObjectBase<AngleUnit>
    {
        public double Value { get; }

        public AngleUnit(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(AngleUnit other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
