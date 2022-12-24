using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Coordinates
{
    public sealed class Angle : ValueObjectBase<Angle>
    {
        public decimal Value { get; }

        public Angle(decimal value)
        {
            this.Value = value;
        }

        protected override bool EqualCore(Angle other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
