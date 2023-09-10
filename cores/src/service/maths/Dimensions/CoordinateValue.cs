using Mov.Core.Models;

namespace Mov.Core.Maths.Dimensions
{
    /// <summary>
    /// 座標
    /// </summary>
    public sealed class CoordinateValue : ValueObjectBase<CoordinateValue>
    {
        public double Value { get; }

        public CoordinateValue(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(CoordinateValue other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
