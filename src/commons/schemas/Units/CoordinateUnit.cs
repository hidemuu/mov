using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    /// <summary>
    /// 座標
    /// </summary>
    public sealed class CoordinateUnit : ValueObjectBase<CoordinateUnit>
    {
        public decimal Value { get; }

        public CoordinateUnit(decimal value)
        {
            this.Value = value;
        }
        
        protected override bool EqualCore(CoordinateUnit other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
