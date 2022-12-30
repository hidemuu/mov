using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Coordinates
{
    public sealed class AngleUnit : ValueObjectBase<AngleUnit>
    {
        public decimal Value { get; }

        public AngleUnit(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(AngleUnit other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
