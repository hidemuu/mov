using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Texts
{
    public sealed class EncodingValue : ValueObjectBase<EncodingValue>
    {
        #region constant

        private const string ENCODE_NAME_UTF8 = "utf-8";
        
        private const string ENCODE_NAME_SHIFT_JIS = "SHIFT⁠-⁠JIS";

        #endregion constant

        #region property

        public Encoding Value { get; }

        #endregion property

        #region constructor

        public EncodingValue(Encoding encoding)
        {
            Value = encoding;
        }

        public static EncodingValue Empty = new EncodingValue(Encoding.UTF8);

        public static EncodingValue UTF8 = new EncodingValue(Encoding.GetEncoding(ENCODE_NAME_UTF8));

        //public static EncodingValue ShiftJis = new EncodingValue(Encoding.GetEncoding(ENCODE_NAME_SHIFT_JIS));

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
