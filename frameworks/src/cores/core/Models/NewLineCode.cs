using System;

namespace Mov.Core.Models
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
            Value = code;
        }

        public static NewLineCode CR = new NewLineCode(CODE_CR);

        public static NewLineCode LF = new NewLineCode(CODE_LF);

        public static NewLineCode CRLF = new NewLineCode(CODE_CRLF);

        public static NewLineCode Default = new NewLineCode(Environment.NewLine);

		#endregion constructor

		#region method

		public override string ToString()
		{
			return this.Value;
		}

		#endregion method

		#region inner method

		protected override bool EqualCore(NewLineCode other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion inner method
    }
}
