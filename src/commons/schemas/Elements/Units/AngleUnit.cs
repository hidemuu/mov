using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Units
{
    public sealed class AngleUnit : ValueObjectBase<AngleUnit>
    {
        public decimal Value { get; }

        public AngleUnit(decimal value)
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
