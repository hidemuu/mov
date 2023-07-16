namespace Mov.Core.Models.Physics
{
    public sealed class LengthValue : ValueObjectBase<LengthValue>
    {
        public static LengthValue Default = new LengthValue(0);

        public double Value { get; }

        public LengthValue(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(LengthValue other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
