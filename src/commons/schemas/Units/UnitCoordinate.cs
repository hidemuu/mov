using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    /// <summary>
    /// 座標
    /// </summary>
    public sealed class UnitCoordinate : ValueObjectBase<UnitCoordinate>
    {
        public decimal Value { get; }

        public UnitCoordinate(decimal value)
        {
            this.Value = value;
        }
        
        protected override bool EqualCore(UnitCoordinate other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
