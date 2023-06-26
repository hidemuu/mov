using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Models;

namespace Mov.Utilities.Models.ValueObjects.Units
{
    /// <summary>
    /// 座標
    /// </summary>
    public sealed class CoordinateUnit : ValueObjectBase<CoordinateUnit>
    {
        public double Value { get; }

        public CoordinateUnit(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(CoordinateUnit other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
