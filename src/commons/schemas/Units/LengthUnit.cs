using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed  class LengthUnit : ValueObjectBase<LengthUnit>
    {
        public decimal Value { get; }

        public LengthUnit(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(LengthUnit other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
