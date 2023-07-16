namespace Mov.Core.Models.Physics
{
    public sealed class AngleValue : ValueObjectBase<AngleValue>
    {
        public double Value { get; }

        public AngleValue(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(AngleValue other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
