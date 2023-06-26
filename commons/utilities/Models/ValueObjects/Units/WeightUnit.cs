using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Models;

namespace Mov.Utilities.Models.ValueObjects.Units
{
    public sealed class WeightUnit : ValueObjectBase<WeightUnit>
    {
        public decimal Value { get; }

        public WeightUnit(decimal value)
        {
            Value = value;
        }

        protected override bool EqualCore(WeightUnit other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
