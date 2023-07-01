namespace Mov.Core.Models.ValueObjects.Units
{
    public sealed class ThicknessUnit : ValueObjectBase<ThicknessUnit>
    {
        public static ThicknessUnit Default = new ThicknessUnit(0);

        public double Value { get; }

        public ThicknessUnit(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(ThicknessUnit other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
