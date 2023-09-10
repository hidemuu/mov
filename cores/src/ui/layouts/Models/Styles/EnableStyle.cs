using Mov.Core.Models;

namespace Mov.Core.Models.Styles
{
    public sealed class EnableStyle : ValueObjectBase<EnableStyle>
    {
        #region property

        public bool Value { get; }

        public bool BindableValue { get; set; }

        #endregion property

        #region constructor

        public EnableStyle(bool isEnabled)
        {
            Value = isEnabled;
            BindableValue = Value;
        }

        public static EnableStyle Enable = new EnableStyle(true);

        public static EnableStyle Disable = new EnableStyle(false);

        #endregion constructor

        #region protected method

        protected override bool EqualCore(EnableStyle other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion protected method
    }
}