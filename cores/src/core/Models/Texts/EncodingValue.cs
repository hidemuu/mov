using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Texts
{
    public sealed class EncodingValue : ValueObjectBase<EncodingValue>
    {
        #region property

        public Encoding Value { get; }

        #endregion property

        #region constructor

        public EncodingValue(Encoding encoding)
        {
            Value = encoding;
        }

        #endregion constructor

        #region method

        protected override bool EqualCore(EncodingValue other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion method
    }
}
