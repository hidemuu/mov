using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed class WeightUnit : ValueObjectBase<WeightUnit>
    {
        public decimal Value { get; }

        public WeightUnit(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(WeightUnit other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
