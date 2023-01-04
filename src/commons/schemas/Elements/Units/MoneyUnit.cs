using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Units
{
    public sealed class MoneyUnit
    {
        public double Value { get; }

        public MoneyUnit(double value)
        {
            Value = value;
        }
    }
}
