using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Shapes
{
    /// <summary>
    /// 座標
    /// </summary>
    public sealed class Coordinate : ValueObjectBase<Coordinate>
    {
        public decimal Value { get; }

        public Coordinate(decimal value)
        {
            this.Value = value;
        }
        
        protected override bool EqualCore(Coordinate other)
        {
            return this.Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }
    }
}
