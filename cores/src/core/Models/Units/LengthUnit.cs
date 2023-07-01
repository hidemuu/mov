namespace Mov.Core.Models.Units
{
    public sealed class LengthUnit : ValueObjectBase<LengthUnit>
    {
        public static LengthUnit Default = new LengthUnit(0);

        public double Value { get; }

        public LengthUnit(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(LengthUnit other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
