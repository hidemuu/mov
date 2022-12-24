using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed class UnitWeight : ValueObjectBase<UnitWeight>
    {
        public decimal Value { get; }

        public UnitWeight(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(UnitWeight other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
