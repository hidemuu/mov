namespace Mov.Core.Models.Units
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
