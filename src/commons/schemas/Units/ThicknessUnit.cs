using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed class ThicknessUnit : ValueObjectBase<ThicknessUnit>
    {
        public decimal Value { get; }

        public ThicknessUnit(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(ThicknessUnit other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
