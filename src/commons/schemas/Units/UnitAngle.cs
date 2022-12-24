using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Coordinates
{
    public sealed class UnitAngle : ValueObjectBase<UnitAngle>
    {
        public decimal Value { get; }

        public UnitAngle(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(UnitAngle other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
