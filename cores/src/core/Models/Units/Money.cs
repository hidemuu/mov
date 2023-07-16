namespace Mov.Core.Models.Units
{
    public sealed class Money
    {
        public double Value { get; }

        public Money(double value)
        {
            Value = value;
        }
    }
}
