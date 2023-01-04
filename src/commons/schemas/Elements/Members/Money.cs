using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Members
{
    public sealed class Money
    {
        public double Value { get; }

        public Money(double value)
        {
            this.Value = value;
        }
    }
}
