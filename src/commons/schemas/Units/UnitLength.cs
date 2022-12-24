using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed  class UnitLength : ValueObjectBase<UnitLength>
    {
        public decimal Value { get; }

        public UnitLength(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(UnitLength other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
