using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Codes
{
    public sealed class NewLineCode : ValueObjectBase<NewLineCode>
    {
        #region constant

        private const string CODE_CR = @"\r";

        private const string CODE_LF = @"\n";

        private const string CODE_CRLF = @"\r\n";

        #endregion constant

        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public NewLineCode(string code) 
        {
            this.Value = code;
        }

        public static NewLineCode CR = new NewLineCode(CODE_CR);

        public static NewLineCode LF = new NewLineCode(CODE_LF);

        public static NewLineCode CRLF = new NewLineCode(CODE_CRLF);

        #endregion constructor

        #region method

        protected override bool EqualCore(NewLineCode other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion method
    }
}
