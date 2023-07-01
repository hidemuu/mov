namespace Mov.Core.Models.ValueObjects.Units
{
    public sealed class AngleUnit : ValueObjectBase<AngleUnit>
    {
        public double Value { get; }

        public AngleUnit(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(AngleUnit other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
